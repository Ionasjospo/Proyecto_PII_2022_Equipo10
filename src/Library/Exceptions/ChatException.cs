using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Exepción creada para los inconvenientes cuando desea usar el Chat.
    /// </summary>
    public class ChatException : Exception
    {
        
        /// <summary>
        /// Constructor de ChatException
        /// </summary>
        public ChatException()
        {
        }

        /// <summary>
        /// Constructor de ChatException
        /// </summary>
        /// <param name="message">Mensaje el cual se le envia al usuario para advertirle que hubo inconvenientes con el Chat.</param>
        public ChatException(string message)
        : base(message)
        {
        }
    }
}