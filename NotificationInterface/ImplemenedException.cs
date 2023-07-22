using System.Runtime.Serialization;

namespace NotificationInterface
{
    [Serializable]
    internal class ImplemenedException : Exception
    {
        public ImplemenedException()
        {
        }

        public ImplemenedException(string? message) : base(message)
        {
        }

        public ImplemenedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ImplemenedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}