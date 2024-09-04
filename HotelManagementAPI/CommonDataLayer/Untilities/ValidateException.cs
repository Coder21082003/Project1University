using System.Runtime.Serialization;

namespace CommonDataLayer.Untilities
{
    [Serializable]
    internal class ValidateException : Exception
    {
        private List<string> error;

        public ValidateException()
        {
        }

        public ValidateException(List<string> error)
        {
            this.error = error;
        }

        public ValidateException(string? message) : base(message)
        {
        }

        public ValidateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ValidateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}