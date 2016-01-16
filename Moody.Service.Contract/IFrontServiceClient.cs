// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFrontServiceClient.cs" company="">
//   
// </copyright>
// <summary>
//   The FrontServiceClient interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Service.Contract
{
    using Moody.Service.Domain;

    /// <summary>
    ///     The FrontServiceClient interface.
    /// </summary>
    public interface IFrontServiceClient
    {
        /// <summary>
        /// The enter the system.
        /// </summary>
        /// <param name="loginInfo">
        /// The login info.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        User EnterTheSystem(LoginInfo loginInfo);
    }
}