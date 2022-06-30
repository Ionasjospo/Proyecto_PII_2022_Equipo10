using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Exepción creada por si no existen partidas listas para unirse.
    /// </summary>
    public class MatchOpenToJoinException : Exception
    {
        
        /// <summary>
        /// Constructor de MatchFullException
        /// </summary>
        public MatchOpenToJoinException()
        {
        }

        /// <summary>
        /// Constructor de MatchFullException
        /// </summary>
        /// <param name="message">Mensaje el cual se le envia al usuario para advertirle que no existen partidas disponibles.</param>
        public MatchOpenToJoinException(string message)
        : base(message)
        {
        }
    }
}