// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDalManagerTester.cs" company="">
//   
// </copyright>
// <summary>
//   The user dal manager tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.DAL.Test
{
    using System.Collections;

    using Moody.DAL.Contract;
    using Moody.Service.Domain;

    using NUnit.Framework;

    /// <summary>
    ///     The user dal manager tester.
    /// </summary>
    [TestFixture]
    internal class UserDalManagerTester
    {
        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.userDalManager = new UserDalManager();
        }

        /// <summary>
        ///     The _user dal manager.
        /// </summary>
        private IUserDalManager userDalManager;

        /// <summary>
        ///     The get user on login basic test.
        /// </summary>
        [Test]
        public void GetUserOnLoginBasicTest()
        {
            var login = "admin";
            var user = this.userDalManager.GetUserOnLogin(login);
            Assert.That(user.LoginName, Is.EqualTo("admin"));
        }

        [Test]
        public void AddNewUserBasicTest()
        {
            User newUser = new User();
            newUser.LoginName = "qwerty5";
            newUser.Email = "qwerty@gmail.com";
            newUser.HashPassword = "I8OPKrMt1x2QcKYtTGgdG3LYb34=";
            newUser.Salt = "mLbjTL3rmvrEEu40Tcia8c3ZAtg=";
            User resultUser = this.userDalManager.AddNewUser(newUser);
            User getNewUser = this.userDalManager.GetUserOnLogin(newUser.LoginName);
            Assert.That(getNewUser.LoginName, Is.EqualTo("qwerty5"));

            //Delete new user
            this.userDalManager.DeleteUser(newUser);
        }

        [Test]
        public void DeleteUserBasicTest()
        {
            // Create new user
            User newUser = new User();
            newUser.LoginName = "qwerty1";
            newUser.Email = "qwerty@gmail.com";
            newUser.HashPassword = "I8OPKrMt1x2QcKYtTGgdG3LYb34=";
            newUser.Salt = "mLbjTL3rmvrEEu40Tcia8c3ZAtg=";
            User user = this.userDalManager.AddNewUser(newUser);

            // Delete new user
            this.userDalManager.DeleteUser(user);

            User resultUser = this.userDalManager.GetUserOnLogin(newUser.LoginName);

            Assert.That(resultUser, Is.EqualTo(null));
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}