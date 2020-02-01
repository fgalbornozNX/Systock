using System;

namespace SyStock.AccesoDatos
{

    /// <summary>
    /// Class to throw and handle Exceptions caused in DAO operations
    /// </summary>
    [Serializable]
    public class DAOException : Exception
    {
        /// <summary>
        /// Represent an Exception caused in DAO objects and methods
        /// </summary>
        public DAOException() : base() { }

        /// <summary>
        /// Represent an Exception caused in DAO objects and methods
        /// </summary>
        /// <param name="pDescription">A short message that describes the problem</param>
        public DAOException(string pDescription) : base(pDescription) { }

        /// <summary>
        /// Represent an Exception caused in DAO objects and methods
        /// </summary>
        /// <param name="pDescription">A short message that describes the problem</param>
        /// <param name="pException">The Exception that triggers it</param>
        public DAOException(string pDescription, Exception pException) : base(pDescription, pException) { }

        /// <summary>
        /// Represent an Exception caused in DAO objects and methods
        /// </summary>
        protected DAOException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext) {}
    }
}