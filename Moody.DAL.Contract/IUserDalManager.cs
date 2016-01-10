// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserDalManager.cs" company="">
//   
// </copyright>
// <summary>
//   The UserDalManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.DAL.Contract
{
    using Moody.Service.Domain;

    /// <summary>
    ///     The UserDalManager interface.
    /// </summary>
    public interface IUserDalManager
    {
        /// <summary>
        /// The get user on login.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        User GetUserOnLogin(string login);

        User AddNewUser(User newUser);

        void DeleteUser(User user);
    }
}