using System;

namespace Common
{
    [Serializable]
    public class ApplicationGeneralException : Exception
    {

        public readonly string Code;

        public ApplicationGeneralException() { }
        public ApplicationGeneralException(string message) : base(message) { }
        public ApplicationGeneralException(string message, Exception inner) : base(message, inner) { }

        public ApplicationGeneralException(string code, string message) : base(message)
        {
            Code = code;
        }

        public ApplicationGeneralException(string code, string message, Exception inner) : base(message, inner)
        {
            Code = code;
        }
        protected ApplicationGeneralException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }
}
