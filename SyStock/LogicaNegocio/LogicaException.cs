using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyStock.LogicaNegocio
{
    /// <summary>
    /// Class to throw and handle Exceptions caused in Domain operations
    /// </summary>
    [Serializable]
    public class LogicaException: Exception
    {
        /// <summary>
        /// Represent an Exception caused in Domain methods
        /// </summary>
        public LogicaException() : base() { }

        /// <summary>
        /// Represent an Exception caused in Domain methods
        /// </summary>
        public LogicaException(string message) : base(message) {}

        /// <summary>
        /// Represent an Exception caused in Domain methods
        /// </summary>
        public LogicaException(string message, Exception innerException) : base(message, innerException) {}

        /// <summary>
        /// Represent an Exception caused in Domain methods
        /// </summary>
        protected LogicaException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext): base(serializationInfo, streamingContext) { }
    }
}