// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionBase.cs" company="">
//   
// </copyright>
// <summary>
//   The exception base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Exception
{
    using System;
    using System.Collections;

    /// <summary>
    ///     The exception base.
    /// </summary>
    public class ExceptionBase : ApplicationException
    {
        /// <summary>
        ///     The exceptionmassage.
        /// </summary>
        protected string exceptionMassage = string.Empty;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        public ExceptionBase()
        {
            this.SetExceptionMessage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public ExceptionBase(string message)
            : base(message)
        {
            this.SetExceptionMessage();
        }

        /// <summary>
        ///     The set exception message.
        /// </summary>
        protected virtual void SetExceptionMessage()
        {
        }

        /// <summary>
        ///     The get message.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string GetMessage()
        {
            var result = this.AddDetails(this.exceptionMassage);
            result = string.Format("{0} - {1}", result, this.Message);
            return result;
        }

        /// <summary>
        /// The add details.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string AddDetails(string message)
        {
            var messageResult = message;
            foreach (DictionaryEntry de in this.Data)
            {
                messageResult = messageResult.Replace("[" + de.Key + "]", "[" + de.Value + "]");
            }

            return messageResult;
        }
    }
}