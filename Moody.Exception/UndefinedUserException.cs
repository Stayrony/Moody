// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UndefinedUserException.cs" company="">
//   
// </copyright>
// <summary>
//   The undefined user exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.Exception
{
    /// <summary>
    /// The undefined user exception.
    /// </summary>
    public class UndefinedUserException : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedUserException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public UndefinedUserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedUserException"/> class.
        /// </summary>
        public UndefinedUserException()
        {
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected override void SetExceptionMessage()
        {
            this.exceptionMassage = "User: [login] is not defined";
        }
    }
}