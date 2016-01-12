// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserNotExists.cs" company="">
//   
// </copyright>
// <summary>
//   The user not exists.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.Exception
{
    /// <summary>
    ///     The user not exists.
    /// </summary>
    public class UserNotExists : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotExists"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public UserNotExists(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotExists"/> class.
        /// </summary>
        public UserNotExists()
        {
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected override void SetExceptionMessage()
        {
            this.exceptionMassage = "User : [LoginName] not exists.";
        }
    }
}