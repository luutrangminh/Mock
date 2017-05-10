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
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartDate, EndDate " +
            "FROM Project " +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetByProfessor(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartDate, EndDate " +
            "FROM Project" +
            " WHERE CreatedBy = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(string projectCode)
        {
            con = new Connections();
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartDate, EndDate " +
            "FROM Project " +
            "WHERE ProjectCode = '" + projectCode + "'";
            return con.ExecuteReader(queryStr);
        }

        public static void Add(string name, DateTime createdAt, int createdBy, DateTime startDate, DateTime endDate)
        {
            con = new Connections();
            string queryStr = "INSERT INTO [dbo].[Project] " +
                "(ProjectCode, Name, CreatedAt, CreatedBy, StartDate, EndDate)" +
                "VALUES ('PJ-' + CONVERT(VARCHAR, (SELECT IDENT_CURRENT('Project') AS INDENTITY)) + '" + createdAt.Day.ToString() + "', N'" + name + "', CONVERT(datetime, '" + createdAt + "', 103), " + createdBy + ", CONVERT(datetime, '" + startDate + "', 103), CONVERT(datetime, '" + endDate + "', 103))";
         
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

        public static void Update(int id, DateTime startDate, DateTime endDate)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Project] SET ";
            if (startDate != null && endDate != null) queryStr += "[StartDate] = CONVERT(datetime, '" + startDate + "', 103), [EndDate] = CONVERT(datetime, '" + endDate + "', 103) ";
            else if (startDate != null && endDate == null) queryStr += "[StartDate] = CONVERT(datetime, '" + startDate + "', 103) ";
            else if (startDate == null && endDate != null) queryStr += "[EndDate] = CONVERT(datetime, '" + endDate + "', 103) ";
            queryStr += " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string name, DateTime startDate, DateTime endDate)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Project] SET [Name] = N'" + name + "', ";
            if (startDate != null && endDate != null) queryStr += "[StartDate] = CONVERT(datetime, '" + startDate + "', 103), [EndDate] = CONVERT(datetime, '" + endDate + "', 103) ";
            else if (startDate != null && endDate == null) queryStr += "[StartDate] = CONVERT(datetime, '" + startDate + "', 103) ";
            else if (startDate == null && endDate != null) queryStr += "[EndDate] = CONVERT(datetime, '" + endDate + "', 103) ";
            queryStr += " WHERE Id = " + id;
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
