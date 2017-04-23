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
        private static Connections con = new Connections();

        public static IDataReader Get(int id)
        {
            string queryStr = "SELECT Id, Question, ProjectId" +
            "FROM Question" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetByProject(int projectId)
        {
            string queryStr = "SELECT Id, Question, ProjectId" +
            "FROM Question" +
            "WHERE ProjectId = " + projectId;
            return con.ExecuteReader(queryStr);
        }

        public static void Add(int projectId, string question)
        {
            string queryStr = "INSERT INTO [dbo].[Question] " +
                "([Question], [ProjectId])" +
                "VALUES (N'" + question + "', " + projectId + ")";
            con.ExecuteScalar(queryStr);
        }

        public static void Update(int id, string question)
        {
            string queryStr = "UPDATE [dbo].[Question] SET [Question] = N'" + question + "'" +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, int projectId)
        {
            string queryStr = "UPDATE [dbo].[Question] SET [ProjectId] = " + projectId +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, string question, int projectId)
        {
            string queryStr = "UPDATE [dbo].[Question] SET [Question] = N'" + question + "'" +
                ", [ProjectId] = " + projectId +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Delete(int id)
        {
            string queryStr = "DELETE FROM [dbo].[Question] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Delete(string projectId)
        {
            string queryStr = "DELETE FROM [dbo].[Question] WHERE [ProjectId] = '" + projectId + "'";
            con.ExecuteNonQuery(queryStr);
        }
    }
}
