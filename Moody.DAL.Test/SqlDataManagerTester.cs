// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlDataManagerTester.cs" company="">
//   
// </copyright>
// <summary>
//   The sql data manager tester.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.DAL.Test
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    using Moody.DAL.Utility;

    using NUnit.Framework;

    /// <summary>
    ///     The sql data manager tester.
    /// </summary>
    [TestFixture]
    public class SqlDataManagerTester
    {
        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            var sqlDataManager = new SqlDataManager();
        }

        /// <summary>
        ///     The connect to data base.
        /// </summary>
        [Test]
        public void ConnectToDataBase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();

            Assert.AreEqual(ConnectionState.Open, connection.State);
            connection.Close();
        }
    }
}