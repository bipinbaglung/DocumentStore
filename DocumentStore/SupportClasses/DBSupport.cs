
using System;
using System.Data;
using System.Data.SqlClient;

namespace DocumentStore
{

    public class DBSupport
    {
        private static SqlConnection _documentStoreConnection;
        public static int TimeOut = 12000;
        private static string _username;
        private static string _password;
        private static string _servername;
        private static string _database;
        private static bool _windowsAuthentication;

        public static void StartUp(string DatabaseSuffix)
        {
            _username = ConfigValues.DBUserName;
            _password = ConfigValues.DBPassword;
            _servername = ConfigValues.DBServerName;
            _database = ConfigValues.DBName;
            if (!string.IsNullOrWhiteSpace(DatabaseSuffix))
                _database = _database + "_" + DatabaseSuffix; ;
            _windowsAuthentication = ConfigValues.DBWindowsAuthentication;
            _documentStoreConnection = GetSqlConnection();
            _documentStoreConnection.Open();
        }

        public static SqlConnectionStringBuilder GetSqlConnectionStringBuilder(string servername, string database, string username, string password, bool windowsAuthentication)
        {
            return new SqlConnectionStringBuilder()
            {
                UserID = username,
                Password = password,
                DataSource = servername,
                InitialCatalog = database,
                IntegratedSecurity = windowsAuthentication
            };
        }

        public static string GetConnectionString(string servername, string database, string username, string password, bool windowsAuthentication)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = servername,
                InitialCatalog = database,
                MultipleActiveResultSets = true,
                IntegratedSecurity = windowsAuthentication
            };
            if (!windowsAuthentication)
            {
                sqlConnectionStringBuilder.UserID = username;
                sqlConnectionStringBuilder.Password = password;
            }

            return sqlConnectionStringBuilder.ToString();
        }

        public static SqlConnection GetSqlConnection(string host, string database, string username, string password, bool windowsAuthentication)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString(host, database, username, password, windowsAuthentication));
            return conn;
        }

        public static SqlConnection GetSqlConnection(string connectionString)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(connectionString);
            return conn;
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(GetConnectionString(_servername, _database, _username, _password, _windowsAuthentication));

        }

        public static DataTable GetDataTable(string query)
        {

            SqlCommand command = new SqlCommand()
            {
                CommandText = query,
                CommandTimeout = TimeOut,
                Connection = _documentStoreConnection
            };
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(dataTable);
            command.Dispose();
            sqlDataAdapter.Dispose();
            return dataTable;

        }


        public static DataTable ExecuteQueryAndGetDataTable(SqlCommand command)
        {

            DataTable dTableLocal = new DataTable();
            command.Connection = _documentStoreConnection;
            command.CommandTimeout = TimeOut;
            SqlDataAdapter sqlAdp = new SqlDataAdapter(command);
            sqlAdp.Fill(dTableLocal);
            command.Dispose();
            sqlAdp.Dispose();
            return dTableLocal;

        }

        public static object ExecuteScalar(string query)
        {
            try
            {
                SqlCommand sqlCom = new SqlCommand(query, _documentStoreConnection)
                {
                    CommandTimeout = TimeOut
                };
                object obj = sqlCom.ExecuteScalar();
                sqlCom.Dispose();
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object ExecuteScalar(SqlCommand command)
        {
            command.Connection = _documentStoreConnection;
            command.CommandTimeout = TimeOut;
            object obj = command.ExecuteScalar();
            command.Dispose();
            return obj;
        }

        public static object ExecuteNonQueryWithIdentity(string query)
        {
            try
            {
                SqlCommand sqlCom = new SqlCommand(query, _documentStoreConnection)
                {
                    CommandTimeout = TimeOut
                };
                if (sqlCom.ExecuteNonQuery() > 0)
                {
                    sqlCom.CommandText = "SELECT SCOPE_IDENTITY()";
                    object obj = sqlCom.ExecuteScalar();
                    sqlCom.Dispose();
                    return obj;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static long ExecuteNonQueryWithIdentity(SqlCommand command)
        {
            try
            {
                command.Connection = _documentStoreConnection;
                command.CommandTimeout = TimeOut;
                command.CommandText += " SELECT SCOPE_IDENTITY()";
                object obj = command.ExecuteScalar();
                command.Dispose();
                long id = -1;
                long.TryParse(obj.ToString(), out id);
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            try
            {
                SqlCommand sqlCom = new SqlCommand(query, _documentStoreConnection)
                {
                    CommandTimeout = TimeOut
                };
                int count = sqlCom.ExecuteNonQuery();
                sqlCom.Dispose();
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                command.Connection = _documentStoreConnection;
                command.CommandTimeout = TimeOut;
                int count = command.ExecuteNonQuery();
                command.Dispose();
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }


        public static void DropTable(string tableName)
        {
            string query = @"IF EXISTS (SELECT TABLE_NAME FROM TEMPDB.INFORMATION_SCHEMA.TABLES 
							 WHERE TABLE_NAME = '" + tableName + "') "
                             + "DROP TABLE " + tableName;

            DBSupport.ExecuteNonQuery(query);


        }

    }
}
