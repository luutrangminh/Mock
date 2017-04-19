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
        string connStr = "Data Source=.;Initial Catalog=SPM_URD;Integrated Security=True";
        SqlConnection con;
        public Connections()
        {
            con = OpenConnection();
            this.Dispose();
        }

        private SqlConnection OpenConnection()
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

        public void ExecuteScalar(string queryStr)
        {

        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
            }
        }
    }
}
