// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IncorrectPasswordException.cs" company="">
//   
// </copyright>
// <summary>
//   The incorrect password exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Exception
{
    /// <summary>
    ///     The incorrect password exception.
    /// </summary>
    public class IncorrectPasswordException : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncorrectPasswordException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public IncorrectPasswordException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncorrectPasswordException"/> class.
        /// </summary>
        public IncorrectPasswordException()
        {
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected override void SetExceptionMessage()
        {
            this.exceptionMassage = "User: [login] entered incorrect password";
        }
    }
}