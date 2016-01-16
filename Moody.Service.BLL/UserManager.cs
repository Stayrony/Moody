// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="">
//   
// </copyright>
// <summary>
//   The user manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.Service.BLL
{
    using System;

    using Moody.DAL;
    using Moody.Exception;
    using Moody.Service.Contract;
    using Moody.Service.Domain;
    using Moody.Service.Utility;

    /// <summary>
    ///     The user manager.
    /// </summary>
    public class UserManager : IFrontServiceClient
    {
        /// <summary>
        ///     The password manager.
        /// </summary>
        private readonly PasswordManager passwordManager = new PasswordManager();

        /// <summary>
        ///     The user dal manager.
        /// </summary>
        private readonly UserDalManager userDalManager = new UserDalManager();

        /// <summary>
        /// The enter the system.
        /// </summary>
        /// <param name="loginInfo">
        /// The login info.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User EnterTheSystem(LoginInfo loginInfo)
        {
            return this.GetUser(loginInfo.LoginName, loginInfo.Password);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User Get(string login)
        {
            return this.userDalManager.GetUserOnLogin(login);
        }

        /// <summary>
        /// The get user.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public User GetUser(string login, string password)
        {
            var user = this.Get(login);

            if (user != null)
            {
                var result = this.passwordManager.IsPasswordMatch(password, user.Salt, user.HashPassword);
                if (result)
                {
                    return user;
                }
                else
                {
                    var incorrectPasswordException = new IncorrectPasswordException();
                    incorrectPasswordException.Data.Add("login", login);
                    throw incorrectPasswordException;

                    // throw new Exception("Incorrect password!");
                }
            }
            else
            {
                var undefinedUserException = new UndefinedUserException();
                undefinedUserException.Data.Add("login", login);
                throw undefinedUserException;

                // throw new Exception("User {0} not found!" + login);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="registerInfo">
        /// The register info.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User CreateUser(RegisterInfo registerInfo)
        {
            var newUser = new User();
            if (this.Validate(registerInfo))
            {
                if (!this.AlreadyExist(registerInfo))
                {
                    string salt = null;
                    string hashPassword = this.passwordManager.GeneratePasswordHash(registerInfo.Password, out salt);

                    newUser.LoginName = registerInfo.LoginName;
                    newUser.Email = registerInfo.Email;
                    newUser.Salt = salt;
                    newUser.HashPassword = hashPassword;

                    //TODO user not add to DataBase
                    this.userDalManager.AddNewUser(newUser);
                }
                else
                {
                    var userAlreadyExists = new UserAlreadyExists();
                    userAlreadyExists.Data.Add("LoginName", registerInfo.LoginName);
                    throw userAlreadyExists;
                }
            }

            return newUser;
        }

        /// <summary>
        /// The already exist.
        /// </summary>
        /// <param name="registerInfo">
        /// The register info.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AlreadyExist(RegisterInfo registerInfo)
        {
            bool result = false;
            User userResult = this.Get(registerInfo.LoginName);
            if (userResult != null)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="registerInfo">
        /// The register info.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Validate(RegisterInfo registerInfo)
        {
            return true;

        }

        /// <summary>
        /// The delete user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void DeleteUser(User user)
        {
            User deletingUser = this.Get(user.LoginName);
            if (deletingUser != null)
            {
                this.userDalManager.DeleteUser(user);
            }
            else
            {
                UserNotExists userNotExists = new UserNotExists();
                userNotExists.Data.Add("LoginName", user.LoginName);
                throw userNotExists;
            }

        }

        /// <summary>
        /// The check policy.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        private bool CheckPolicy(string login, string password)
        {
            if (login == string.Empty)
            {
                throw new Exception("Login is empty!");
            }

            if (password == string.Empty)
            {
                throw new Exception("Password is empty!");
            }

            return true;
        }
    }
}