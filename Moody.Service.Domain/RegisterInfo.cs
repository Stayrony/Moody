// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The register info for user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.Service.Domain
{
    /// <summary>
    /// The register info.
    /// </summary>
    public class RegisterInfo
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

    }
}