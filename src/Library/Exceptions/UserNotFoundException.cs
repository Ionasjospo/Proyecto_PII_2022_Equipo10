using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Exepción creada para cuando se busca un usuario y no es encontrado.
    /// </summary>
    public class UserNotFoundException : Exception
    {
        
        /// <summary>
        /// Constructor de MatchFullException
        /// </summary>
        public UserNotFoundException()
        {
        }

        /// <summary>
        /// Constructor de MatchFullException
        /// </summary>
        /// <param name="message">Mensaje el cual se le envia al usuario para advertirle que no existe usuario buscado.</param>
        public UserNotFoundException(string message)
        : base(message)
        {
        }
    }
}