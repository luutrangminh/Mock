using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Administrator
    {
        private static Connections con = null;

        public static IDataReader TestSelect()
        {
            return con.ExecuteReader("Select * From Administrator");
        }

        public static IDataReader Get(string username)
        {
            con = new Connections();
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, Avatar FROM Administrator" +
            " WHERE Username = '" + username + "'";
            return con.ExecuteReader(queryStr);
        }
        public static IDataReader Get(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, Avatar FROM Administrator" +
            " WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static void Close()
        {
            con.CloseConnection();
        }
    }
}
