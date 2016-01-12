// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDalManager.cs" company="">
//   
// </copyright>
// <summary>
//   The user dal manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.DAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using Moody.DAL.Contract;
    using Moody.DAL.Utility;
    using Moody.Service.Domain;

    /// <summary>
    ///     The user dal manager.
    /// </summary>
    public class UserDalManager : IUserDalManager
    {
        /// <summary>
        ///     The sql data manager.
        /// </summary>
        private readonly SqlDataManager sqlDataManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserDalManager" /> class.
        /// </summary>
        public UserDalManager()
        {
            this.sqlDataManager = new SqlDataManager();
        }

        /// <summary>
        /// The get user on login.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User GetUserOnLogin(string login)
        {
            var user = new User();

            var sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@Login", SqlDbType.VarChar) { Value = login };
            var dataTable = this.sqlDataManager.SelectProcedure("GetUserOnLogin", sqlParameter);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    user.LoginName = dataRow["Login"].ToString();
                    user.HashPassword = dataRow["KeyPassword"].ToString();
                    user.Salt = dataRow["Salt"].ToString();
                    user.Email = dataRow["Email"].ToString();
                }
            }
            else
            {
                return null;
            }

            return user;
        }

        /// <summary>
        /// The save or update.
        /// </summary>
        /// <param name="newUser">
        /// The new user.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User AddNewUser(User newUser)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            sqlParameter[0] = new SqlParameter("@Login", SqlDbType.VarChar) { Value = newUser.LoginName };
            sqlParameter[1] = new SqlParameter("@Email", SqlDbType.VarChar) { Value = newUser.Email };
            sqlParameter[2] = new SqlParameter("@Salt", SqlDbType.VarChar) { Value = newUser.Salt };
            sqlParameter[3] = new SqlParameter("@KeyPassword", SqlDbType.VarChar) { Value = newUser.HashPassword };
            try
            {
                this.sqlDataManager.InsertProcedure("AddUser", sqlParameter);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return newUser;
            // return newUser;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void DeleteUser(User user)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@Login", SqlDbType.VarChar) { Value = user.LoginName };

            this.sqlDataManager.InsertProcedure("DeleteUser", sqlParameter);
        }

    }
}