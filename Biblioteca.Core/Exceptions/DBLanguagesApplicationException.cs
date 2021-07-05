using System;
using System.Runtime.Serialization;

namespace Biblioteca.Core.Exceptions
{
    [Serializable]
    public class DBLanguagesApplicationException : Exception
    {
        public DBLanguagesApplicationException() : base()
        {           
        }

        public DBLanguagesApplicationException(string message) : base(message)
        {            
        }

        public DBLanguagesApplicationException(string message, Exception innerException) : base(message, innerException)
        {            
        }

        protected DBLanguagesApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
