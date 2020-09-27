using System;

namespace Api.Exceptions
{
    /// <summary>
    /// Exception that is thrown when Google returns a status code 
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Constructor, accepting a error message and a optional status.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ApiException(string message)
            : base(message)
        {
            
        }

        /// <summary>
        /// Constructor, accepting a error message and a optional status.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}