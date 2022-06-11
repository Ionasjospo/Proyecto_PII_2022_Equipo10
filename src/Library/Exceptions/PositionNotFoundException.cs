using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public class PositioNotFoundException : Exception
    {
        public PositioNotFoundException()
        {
        }

        public PositioNotFoundException(string message)
        : base(message)
        {
        }

        public PositioNotFoundException(string message, Exception innerException)
        : base(message, innerException)
        {
        }

        protected PositioNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }

        //preguntar si los ultimos dos constructores van.
    }
}