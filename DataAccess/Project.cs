using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Project
    {
        private static Connections con = null;

        public static IDataReader Get(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time" +
            "FROM Project" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(string projectCode)
        {
            con = new Connections();
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time" +
            "FROM Project" +
            "WHERE ProjectCode = '" + projectCode + "'";
            return con.ExecuteReader(queryStr);
        }

        public static void Add(string projectCode, string name, DateTime createdAt, int createdBy, DateTime startAt, int time)
        {
            con = new Connections();
            string queryStr = "INSERT INTO [dbo].[Project] " +
                "(ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time)" +
                "VALUES ('" + projectCode + "', N'" + name + "', CONVERT(datetime, '" + createdAt + "', 103), " + createdBy + ", CONVERT(datetime, '" + startAt + "', 103), " + time + ")";
         
            con.ExecuteScalar(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string name)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Project] SET [Name] = N'" + name + "'" +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, DateTime startAt)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Project] SET [StartAt] = CONVERT(datetime, '" + startAt + "', 103)" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, int time)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Project] SET [Time] = " + time +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Delete(int id)
        {
            con = new Connections();
            string queryStr = "DELETE FROM [dbo].[Project] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }
    }
}
