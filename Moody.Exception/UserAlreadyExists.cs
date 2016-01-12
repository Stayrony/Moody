// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserAlreadyExists.cs" company="">
//   
// </copyright>
// <summary>
//   The user already exists.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.Exception
{
    /// <summary>
    /// The user already exists.
    /// </summary>
    public class UserAlreadyExists : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAlreadyExists"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public UserAlreadyExists(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAlreadyExists"/> class.
        /// </summary>
        public UserAlreadyExists()
        {
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected override void SetExceptionMessage()
        {
            this.exceptionMassage = "User : [LoginName] already exists";
        }
    }
}