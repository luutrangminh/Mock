using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Question
    {
        private static Connections con = null;

        public static IDataReader Get(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Id, Question, ProjectId" +
            "FROM Question" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetByProject(int projectId)
        {
            con = new Connections();
            string queryStr = "SELECT Id, Question, ProjectId" +
            "FROM Question" +
            "WHERE ProjectId = " + projectId;
            return con.ExecuteReader(queryStr);
        }

        public static void Add(int projectId, string question)
        {
            con = new Connections();
            string queryStr = "INSERT INTO [dbo].[Question] " +
                "([Question], [ProjectId])" +
                "VALUES (N'" + question + "', " + projectId + ")";
            con.ExecuteScalar(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string question)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Question] SET [Question] = N'" + question + "'" +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, int projectId)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Question] SET [ProjectId] = " + projectId +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string question, int projectId)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Question] SET [Question] = N'" + question + "'" +
                ", [ProjectId] = " + projectId +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Delete(int id)
        {
            con = new Connections();
            string queryStr = "DELETE FROM [dbo].[Question] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Delete(string projectId)
        {
            con = new Connections();
            string queryStr = "DELETE FROM [dbo].[Question] WHERE [ProjectId] = '" + projectId + "'";
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }
    }
}
