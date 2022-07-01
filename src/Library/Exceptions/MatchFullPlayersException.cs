using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Exepción creada por si un usuario intenta unirse a una partida que esta llena.
    /// </summary>
    public class MatchFullPlayersException : Exception
    {
        
        /// <summary>
        /// Constructor de MatchFullException
        /// </summary>
        public MatchFullPlayersException()
        {
        }

        /// <summary>
        /// Constructor de MatchFullException
        /// </summary>
        /// <param name="message">Mensaje el cual se le envia al usuario para advertirle que la partida ya tiene todos los jugadores posibles.</param>
        public MatchFullPlayersException(string message)
        : base(message)
        {
        }
    }
}