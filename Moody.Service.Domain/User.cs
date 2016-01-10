// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Service.Domain
{
    using System.ComponentModel;

    /// <summary>
    ///     The user.
    /// </summary>
    public class User //: IDataErrorInfo
    {
        /// <summary>
        ///     Gets or sets the login name.
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        ///     Gets or sets the hash password.
        /// </summary>
        public string HashPassword { get; set; }

        /// <summary>
        ///     Gets or sets the salt.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        //#region IDataErrorInfo Members

        ///// <summary>
        /////     Gets the error.
        ///// </summary>
        //string IDataErrorInfo.Error
        //{
        //    get
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// The i data error info.this.
        ///// </summary>
        ///// <param name="propertyName">
        ///// The property name.
        ///// </param>
        ///// <returns>
        ///// The <see cref="string"/>.
        ///// </returns>
        //string IDataErrorInfo.this[string propertyName]
        //{
        //    get
        //    {
        //        return null;

        //        // return this.GetValidationError(propertyName);
        //    }
        //}

        //#endregion IDataErrorInfo Members
    }
}