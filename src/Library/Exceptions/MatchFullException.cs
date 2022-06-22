using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Exepción creada por si un usuario intenta unirse a una partida que esta llena.
    /// </summary>
    public class MatchFullException : Exception
    {
        
        /// <summary>
        /// Constructor de MatchFullException
        /// </summary>
        public MatchFullException()
        {
        }

        /// <summary>
        /// Constructor de MatchFullException
        /// </summary>
        /// <param name="message">Mensaje el cual se le envia al usuario para advertirle que puso mal la ubicación.</param>
        public MatchFullException(string message)
        : base(message)
        {
        }
    }
}