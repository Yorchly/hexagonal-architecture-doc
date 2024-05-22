using System;

namespace GtMotive.Estimate.Microservice.Infrastructure.Exceptions
{
    [Serializable]
    public class InfrastructureException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
        /// </summary>
        public InfrastructureException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public InfrastructureException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public InfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected InfrastructureException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
