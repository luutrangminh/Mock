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
        Connections con = new Connections();

        public IDataReader Get(int id)
        {
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time" +
            "FROM Project" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public IDataReader Get(string projectCode)
        {
            string queryStr = "SELECT Id, ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time" +
            "FROM Project" +
            "WHERE ProjectCode = '" + projectCode + "'";
            return con.ExecuteReader(queryStr);
        }

        public IDataReader Add(string projectCode,string name, DateTime createdAt, int createdBy, DateTime startAt, int time)
        {
            string queryStr = "INSERT INTO [dbo].[Project] " +
                "(ProjectCode, Name, CreatedAt, CreatedBy, StartAt, Time)" +
                "VALUES ('" + projectCode + "', N'" + name + "', '" + createdAt + "', " + createdBy + ", '" + startAt + "'" + time + ")";
            return (IDataReader)con.ExecuteScalar(queryStr);
        }

        public void Update(int id, string name)
        {
            string queryStr = "UPDATE [dbo].[Project] SET [Name] = N'" + name + "'" +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(int id, DateTime startAt)
        {
            string queryStr = "UPDATE [dbo].[Project] SET [StartAt] = '" + startAt + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(int id, int time)
        {
            string queryStr = "UPDATE [dbo].[Project] SET [Time] = " + time +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public void Delete(int id)
        {
            string queryStr = "DELETE FROM [dbo].[Project] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
        }

    }
}
