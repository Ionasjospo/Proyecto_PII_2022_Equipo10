using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Exepción creada por si un usuario intenta crear una partida y no es posible.
    /// </summary>
    public class CreateMatchException : Exception
    {
        
        /// <summary>
        /// Constructor de CreateMatchException
        /// </summary>
        public CreateMatchException()
        {
        }

        /// <summary>
        /// Constructor de CreateMatchException
        /// </summary>
        /// <param name="message">Mensaje el cual se le envia al usuario para advertirle que la partida ya tiene todos los jugadores posibles.</param>
        public CreateMatchException(string message)
        : base(message)
        {
        }
    }
}