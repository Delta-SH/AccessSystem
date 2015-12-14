using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Values Pair Class
    /// </summary>
    [Serializable]
    public class ValuesPair<Type1, Type2, Type3, Type4, Type5>
    {
        /// <summary>
        /// Value1
        /// </summary>
        public Type1 Value1 { get; set; }

        /// <summary>
        /// Value2
        /// </summary>
        public Type2 Value2 { get; set; }

        /// <summary>
        /// Value3
        /// </summary>
        public Type3 Value3 { get; set; }

        /// <summary>
        /// Value4
        /// </summary>
        public Type4 Value4 { get; set; }

        /// <summary>
        /// Value5
        /// </summary>
        public Type5 Value5 { get; set; }
    }
}
