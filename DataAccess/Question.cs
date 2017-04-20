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
        Connections con = new Connections();

        public IDataReader Get(int id)
        {
            string queryStr = "SELECT Id, Question, ProjectId" +
            "FROM Question" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public IDataReader Get(int projectId)
        {
            string queryStr = "SELECT Id, Question, ProjectId" +
            "FROM Question" +
            "WHERE ProjectId = " + projectId;
            return con.ExecuteReader(queryStr);
        }

        public IDataReader Add(int projectId, string question)
        {
            string queryStr = "INSERT INTO [dbo].[Question] " +
                "([Question], [ProjectId])" +
                "VALUES (N'" + question + "', " + projectId + ")";
            return (IDataReader)con.ExecuteScalar(queryStr);
        }

        public void Update(string question)
        {
            string queryStr = "UPDATE [dbo].[Question] SET [Question] = N'" + question + "'";
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(int projectId)
        {
            string queryStr = "UPDATE [dbo].[Question] SET [ProjectId] = " + projectId;
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(string question, int projectId)
        {
            string queryStr = "UPDATE [dbo].[Question] SET [Question] = N'" + question + "'" +
                ", [ProjectId] = " + projectId;
            con.ExecuteNonQuery(queryStr);
        }

        public void Delete(int id)
        {
            string queryStr = "DELETE FROM [dbo].[Question] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public void Delete(string projectId)
        {
            string queryStr = "DELETE FROM [dbo].[Question] WHERE [ProjectId] = '" + projectId + "'";
            con.ExecuteNonQuery(queryStr);
        }
    }
}
