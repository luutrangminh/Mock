using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class Connections : IDisposable
    {
        SqlConnection con;

        public Connections()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            con = OpenConnection(connStr);
            if (con == null) this.Dispose();
        }

        public Connections(string connStr)
        {
            con = OpenConnection(connStr);
            if (con == null) this.Dispose();
        }

        private SqlConnection OpenConnection(string connStr)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connStr;
                conn.Open();
                return conn;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }
        
        public void CloseConnection()
        {
            con.Close();
        }

        public IDataReader ExecuteReader(string queryStr)
        {
            SqlCommand cmd = new SqlCommand(queryStr, con);
            return cmd.ExecuteReader();
        }

        public void ExecuteNonQuery(string queryStr)
        {
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.ExecuteNonQuery();
        }

        public object ExecuteScalar(string queryStr)
        {
            SqlCommand cmd = new SqlCommand(queryStr, con);
            try
            {
                var result = cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void Dispose()
        {
          con.Dispose();
        }
    }
}
