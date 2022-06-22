using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    /// <summary>
    /// Exepción creada por si el usuario pone una coordenada invalida.
    /// </summary>
    public class PositionNotFoundException : Exception
    {
        
        /// <summary>
        /// Constructor de PositionNotFoundException
        /// </summary>
        public PositionNotFoundException()
        {
        }

        /// <summary>
        /// Constructor de PositionNotFoundException
        /// </summary>
        /// <param name="message">Mensaje el cual se le envia al usuario para advertirle que puso mal la ubicación.</param>
        public PositionNotFoundException(string message)
        : base(message)
        {
        }
    }
}