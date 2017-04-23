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
        private static Connections con = new Connections();

        public static IDataReader Get(int id)
        {
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time" +
            "FROM Project" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(string projectCode)
        {
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time" +
            "FROM Project" +
            "WHERE ProjectCode = '" + projectCode + "'";
            return con.ExecuteReader(queryStr);
        }

        public static void Add(string projectCode, string name, DateTime createdAt, int createdBy, DateTime startAt, int time)
        {
            string queryStr = "INSERT INTO [dbo].[Project] " +
                "(ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time)" +
                "VALUES ('" + projectCode + "', N'" + name + "', CONVERT(datetime, '" + createdAt + "', 103), " + createdBy + ", CONVERT(datetime, '" + startAt + "', 103), " + time + ")";
         
            con.ExecuteScalar(queryStr);
        }

        public static void Update(int id, string name)
        {
            string queryStr = "UPDATE [dbo].[Project] SET [Name] = N'" + name + "'" +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, DateTime startAt)
        {
            string queryStr = "UPDATE [dbo].[Project] SET [StartAt] = '" + startAt + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, int time)
        {
            string queryStr = "UPDATE [dbo].[Project] SET [Time] = " + time +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Delete(int id)
        {
            string queryStr = "DELETE FROM [dbo].[Project] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
        }

    }
}
