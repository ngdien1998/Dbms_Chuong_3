using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnectDatabaseDbms.Models.DatabaseAccessModels
{
    public class DatabaseConnection
    {
        protected SqlConnection conn;
        private readonly string connectionString;

        public DatabaseConnection(string constr)
        {
            connectionString = constr;
        }

        public int ExecuteNonQuery(string sql, CommandType commandType)
        {
            try
            {
                OpenConnection();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                command.CommandType = commandType;
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExecuteQuery(string sql, CommandType commandType)
        {
            try
            {
                OpenConnection();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                command.CommandType = commandType;
                DataSet sinhVienSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(sinhVienSet, "SinhVien");
                return sinhVienSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void OpenConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void CloseConnection()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            conn = null;
        }
    }
}