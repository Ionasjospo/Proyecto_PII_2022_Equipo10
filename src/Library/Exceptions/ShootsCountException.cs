using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Exepción creada para los inconvenientes cuando desea ver la cantidad de disparos realizados en una batalla.
    /// </summary>
    public class ShootsCountException : Exception
    {
        
        /// <summary>
        /// Constructor de ShootsCountException
        /// </summary>
        public ShootsCountException()
        {
        }

        /// <summary>
        /// Constructor de ShootsCountException
        /// </summary>
        /// <param name="message">Mensaje el cual se le envia al usuario para advertirle que hubo inconvenientes al ver la cantidad de disparos realizados en una batalla.</param>
        public ShootsCountException(string message)
        : base(message)
        {
        }
    }
}