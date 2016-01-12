// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlDataManager.cs" company="">
//   
// </copyright>
// <summary>
//   The sql data manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moody.DAL.Utility
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     The sql data manager.
    /// </summary>
    public class SqlDataManager
    {
        /// <summary>
        ///     The conn.
        /// </summary>
        private readonly SqlConnection conn;

        /// <summary>
        ///     The sql data adapter.
        /// </summary>
        private readonly SqlDataAdapter sqlDataAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDataManager"/> class. 
        /// </summary>
        public SqlDataManager()
        {
            this.sqlDataAdapter = new SqlDataAdapter();

            // TODO NullReference
            this.conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);

            // if (conn == null)
            // {
            // throw new ArgumentNullException("Null reference on SQL connection object");
            // }
        }

        /// <summary>
        ///     The open connection.
        /// </summary>
        /// <returns>
        ///     The <see cref="SqlConnection" />.
        /// </returns>
        public SqlConnection OpenConnection()
        {
            if (this.conn.State == ConnectionState.Closed || this.conn.State == ConnectionState.Broken)
            {
                this.conn.Open();
            }

            return this.conn;
        }

        /// <summary>
        /// Insert Query
        /// </summary>
        /// <param name="query">
        /// </param>
        /// <param name="sqlParameter">
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ExecuteInsertQuery(string query, DbParameter[] sqlParameter)
        {
            using (var cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = this.OpenConnection();
                    cmd.CommandText = query;
                    cmd.Parameters.AddRange(sqlParameter);
                    this.sqlDataAdapter.InsertCommand = cmd;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw new Exception(
                        "Error - ExecuteInsertQuery - Query:" + query + "\nException" + exception.StackTrace);
                    return false;
                }
                finally
                {
                    this.conn.Close();
                }

                return true;
            }
        }

        /// <summary>
        /// The execute select query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="sqlParameter">
        /// The sql parameter.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public DataTable ExecuteSelectQuery(string query, DbParameter[] sqlParameter)
        {
            using (var cmd = new SqlCommand())
            {
                var dataTable = new DataTable();
                dataTable = null;
                var dataSet = new DataSet();

                try
                {
                    cmd.Connection = this.OpenConnection();
                    cmd.CommandText = query;
                    cmd.Parameters.AddRange(sqlParameter);
                    cmd.ExecuteNonQuery();
                    this.sqlDataAdapter.SelectCommand = cmd;
                    this.sqlDataAdapter.Fill(dataSet);
                    dataTable = dataSet.Tables[0];
                }
                catch (SqlException exception)
                {
                    throw new Exception(
                        "Error - Connection.executeSelectQuery - Query: " + query + " \nException: "
                        + exception.StackTrace);
                }
                finally
                {
                    this.conn.Close();
                }

                return dataTable;
            }
        }

        /// <summary>
        /// The execute select all query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public DataTable ExecuteSelectAllQuery(string query)
        {
            using (var cmd = new SqlCommand())
            {
                var dataTable = new DataTable();
                dataTable = null;
                var dataSet = new DataSet();

                try
                {
                    cmd.Connection = this.OpenConnection();
                    cmd.CommandText = query;
                 //   cmd.Parameters.AddRange(sqlParameter);
                    cmd.ExecuteNonQuery();
                    this.sqlDataAdapter.SelectCommand = cmd;
                    this.sqlDataAdapter.Fill(dataSet);
                    dataTable = dataSet.Tables[0];
                }
                catch (SqlException exception)
                {
                    throw new Exception(
                        "Error - Connection.executeSelectAllQuery - Query: " + query + " \nException: "
                        + exception.StackTrace);
                }
                finally
                {
                    this.conn.Close();
                }

                return dataTable;
            }
        }


        /// <summary>
        /// The execute update query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="sqlParameter">
        /// The sql parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public bool ExecuteUpdateQuery(string query, DbParameter[] sqlParameter)
        {
            using (var cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = this.OpenConnection();
                    cmd.CommandText = query;
                    cmd.Parameters.AddRange(sqlParameter);
                    this.sqlDataAdapter.UpdateCommand = cmd;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw new Exception(
                        "Error - Connection.ExecuteUpdateQuery - Query:" + query + "nException: " + exception.StackTrace);
                    return false;
                }
                finally
                {
                    this.conn.Close();
                }

                return true;
            }
        }

        /// <summary>
        /// The execute procedure query.
        /// </summary>
        /// <param name="procedureName">
        /// The procedure name.
        /// </param>
        /// <param name="sqlParameter">
        /// The sql parameter.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public DataTable ExecuteProcedureQuery(string procedureName, DbParameter[] sqlParameter)
        {
            using (var cmd = new SqlCommand())
            {
                var dataTable = new DataTable();
                dataTable = null;
                var dataSet = new DataSet();
                try
                {
                    // SqlConnection connectionString = OpenConnection();
                    // SqlCommand command = new SqlCommand(procedureName, new SqlConnection(ConfigurationManager.ConnectionStrings));
                    cmd.Connection = this.OpenConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameter);
                    cmd.ExecuteNonQuery();
                    this.sqlDataAdapter.Fill(dataSet);
                    dataTable = dataSet.Tables[0];
                }
                catch (SqlException exception)
                {
                    throw new Exception(
                        "Error - Connection. ExecuteProcedureQuery - Procedure: " + procedureName + " \nException: "
                        + exception.StackTrace);
                }
                finally
                {
                    this.conn.Close();
                }

                return dataTable;
            }
        }

        /// <summary>
        /// The execute stored procedure query.
        /// </summary>
        /// <param name="procedureName">
        /// The procedure name.
        /// </param>
        /// <param name="sqlParameter">
        /// The sql parameter.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public DataTable SelectProcedure(string procedureName, DbParameter[] sqlParameter)
        {
            using (var cmd = new SqlCommand(procedureName, this.conn))
            {
                var dataTable = new DataTable();
                var dataSet = new DataSet();
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameter);

                    var dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataSet);
                    dataTable = dataSet.Tables[0];
                }
                catch (SqlException exception)
                {
                    throw new Exception(
                        "Error - Connection. ExecuteProcedureQuery - Procedure: " + procedureName + " \nException: "
                        + exception.StackTrace);
                }
                finally
                {
                    this.conn.Close();
                }

                return dataTable;
            }
        }


        /// <summary>
        /// The execute stored procedure insert query.
        /// </summary>
        /// <param name="procedureName">
        /// The procedure name.
        /// </param>
        /// <param name="sqlParameter">
        /// The sql parameter.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void ExecuteStoredProcedureQuery(string procedureName, DbParameter[] sqlParameter)
        {
            using (var cmd = new SqlCommand(procedureName, this.conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameter);
                }
                catch (SqlException exception)
                {
                    throw new Exception(
                        "Error - Connection.ExecuteStoredProcedureQuery - Procedure: " + procedureName + " \nException: "
                        + exception.StackTrace);
                }
                finally
                {
                    this.conn.Close();
                }

            }
        }

        public void InsertProcedure(string procedureName, SqlParameter[] sqlParameters)
        {
            using (SqlCommand cmd = new SqlCommand(procedureName, this.conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParameters);
                cmd.Connection = this.OpenConnection();
                cmd.ExecuteNonQuery();
            }
        }
    }


}