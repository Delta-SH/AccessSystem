using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Client Information Class
    /// </summary>
    [Serializable]
    public class ClientInfo
    {
        #region Global Variables
        private const int maxReceiveBufferSize = 65535;
        private const int maxSendBufferSize = 65535;
        private const int maxReceiveTimeout = 5;
        private const int maxWriteTimeout = 5;

        private InterfaceInfo config = null;
        private TcpClient client = null;
        private NetworkStream netStream = null;
        private byte[] readBuffer = new byte[maxReceiveBufferSize];
        private List<byte> bytesBuffer = new List<byte>();
        private EnmLinkState linkState = EnmLinkState.Disconnect;
        private int curPackNo = 0;
        private int connectCnt = 0;
        private int loginCnt = 0;
        private int logoutCnt = 0;
        private int heartBeatCnt = 0;
        public delegate void RevPackCallback(IAsyncResult iar);
        public delegate void SedPackCallback(IAsyncResult iar);
        #endregion

        #region Class Constructor
        public ClientInfo(InterfaceInfo config) {
            this.config = config;
        }
        #endregion

        #region Attributes
        /// <summary>
        /// Client
        /// </summary>
        public TcpClient Client {
            get { return this.client; }
        }

        /// <summary>
        /// NetStream
        /// </summary>
        public NetworkStream NetStream {
            get { return this.netStream; }
        }

        /// <summary>
        /// ReadBuffer
        /// </summary>
        public byte[] ReadBuffer {
            get { return this.readBuffer; }
        }

        /// <summary>
        /// Config
        /// </summary>
        public InterfaceInfo Config {
            get { return this.config; }
        }

        /// <summary>
        /// Bytes Buffer
        /// </summary>
        public List<byte> BytesBuffer {
            get { return this.bytesBuffer; }
        }

        /// <summary>
        /// LinkState
        /// </summary>
        public EnmLinkState LinkState {
            get { return this.linkState; }
            set { this.linkState = value; }
        }

        /// <summary>
        /// CurPackNo
        /// </summary>
        public int CurPackNo {
            get {
                if (this.curPackNo == Int32.MaxValue)
                    this.curPackNo = 0;

                this.curPackNo += 1;
                return this.curPackNo;
            }
        }

        /// <summary>
        /// ConnectCnt
        /// </summary>
        public int ConnectCnt {
            get { return this.connectCnt; }
            set {
                if (value == Int32.MaxValue)
                    this.connectCnt = 0;
                else
                    this.connectCnt = value;
            }
        }

        /// <summary>
        /// LoginCnt
        /// </summary>
        public int LoginCnt {
            get { return this.loginCnt; }
            set {
                if (value == Int32.MaxValue)
                    this.loginCnt = 0;
                else
                    this.loginCnt = value;
            }
        }

        /// <summary>
        /// LogoutCnt
        /// </summary>
        public int LogoutCnt {
            get { return this.logoutCnt; }
            set {
                if (value == Int32.MaxValue)
                    this.logoutCnt = 0;
                else
                    this.logoutCnt = value;
            }
        }

        /// <summary>
        /// HeartBeatCnt
        /// </summary>
        public int HeartBeatCnt {
            get { return this.heartBeatCnt; }
            set {
                if (value == Int32.MaxValue)
                    this.heartBeatCnt = 0;
                else
                    this.heartBeatCnt = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Init Read Buffer
        /// </summary>
        private void InitReadBuffer() {
            Array.Clear(this.readBuffer, 0, this.readBuffer.Length);
        }

        /// <summary>
        /// Init Bytes Buffer
        /// </summary>
        private void InitBytesBuffer() {
            this.bytesBuffer.Clear();
        }

        /// <summary>
        /// Connect
        /// </summary>
        public void Connect() {
            try {
                this.client = new TcpClient();
                this.client.ReceiveBufferSize = maxReceiveBufferSize;
                this.client.SendBufferSize = maxSendBufferSize;
                this.client.ReceiveTimeout = maxReceiveTimeout;
                this.client.SendTimeout = maxWriteTimeout;
                this.client.Connect(this.config.InterfaceIP, this.config.InterfacePort);
                this.netStream = this.client.GetStream();
                this.netStream.ReadTimeout = maxReceiveTimeout;
                this.netStream.WriteTimeout = maxWriteTimeout;

                this.InitReadBuffer();
                this.InitBytesBuffer();
                this.connectCnt = 0;
                this.logoutCnt = 0;
                this.heartBeatCnt = 0;
                this.linkState = EnmLinkState.Connected;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Send Bytes
        /// </summary>
        /// <param name="revPack">revPack</param>
        public void Send(byte[] sedPack) {
            try {
                if (this.netStream != null && this.netStream.CanWrite && this.client.Connected) {
                    this.netStream.Write(sedPack, 0, sedPack.Length);
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Send Bytes
        /// </summary>
        /// <param name="revPack">revPack</param>
        /// <param name="sedPackCallback">sedPackCallback</param>
        public void Send(byte[] sedPack, SedPackCallback sedPackCallback) {
            try {
                if (this.netStream != null)
                    this.netStream.BeginWrite(sedPack, 0, sedPack.Length, new AsyncCallback(sedPackCallback), this);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Read Stream
        /// </summary>
        public byte[] Read() {
            try {
                if (this.netStream != null && this.netStream.CanRead && this.client.Available > 0) {
                    byte[] revPack = new byte[this.client.Available];
                    this.netStream.Read(revPack, 0, revPack.Length);
                    return revPack;
                }

                return null;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Read Stream
        /// </summary>
        /// <param name="revPackCallback">revPackCallback</param>
        public void Read(RevPackCallback revPackCallback) {
            try {
                if (this.netStream != null) {
                    this.InitReadBuffer();
                    this.netStream.BeginRead(this.ReadBuffer, 0, this.ReadBuffer.Length, new AsyncCallback(revPackCallback), this);
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get Receive Pack
        /// </summary>
        public byte[] GetReceivePack() {
            try {
                byte[] pack = null;
                int startIndex = this.FindPHeadIndex(this.bytesBuffer, 0);
                if (startIndex == -1)
                    return pack;

                if (startIndex > 0) {
                    this.bytesBuffer.RemoveRange(0, startIndex);
                }

                int packLen = BitConverter.ToInt32(new byte[] { this.bytesBuffer[4], this.bytesBuffer[5], this.bytesBuffer[6], this.bytesBuffer[7] }, 0);
                int endIndex = this.FindPHeadIndex(this.bytesBuffer, startIndex + 4);
                if (endIndex == -1) {
                    if (this.bytesBuffer.Count >= packLen) {
                        pack = new byte[packLen];
                        this.bytesBuffer.CopyTo(0, pack, 0, packLen);
                        this.InitBytesBuffer();
                    }
                } else {
                    if (endIndex == packLen) {
                        pack = new byte[packLen];
                        this.bytesBuffer.CopyTo(0, pack, 0, packLen);
                    }

                    this.bytesBuffer.RemoveRange(0, endIndex);
                }

                return pack;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Find Package Head Index
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <param name="offset">offset</param>
        private int FindPHeadIndex(List<byte> bytes, int offset) {
            try {
                int index = -1;
                int cnt = bytes.Count;
                for (int i = offset; i < cnt - 3; i++) {
                    if (bytes[i] == 0x5A
                        && bytes[i + 1] == 0x6B
                        && bytes[i + 2] == 0x7C
                        && bytes[i + 3] == 0x7E) {
                        index = i;
                        break;
                    }
                }

                return index;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Client Dispose
        /// </summary>
        public void ClientDispose() {
            if (netStream != null)
                netStream.Dispose();

            if (client != null)
                client.Close();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        ~ClientInfo() {
            if (netStream != null)
                netStream.Dispose();

            if (client != null)
                client.Close();
        }
        #endregion
    }
}
