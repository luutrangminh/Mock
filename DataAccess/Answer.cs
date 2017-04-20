using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Answer
    {
        Connections con = new Connections();

        public IDataReader Get(int id)
        {
            string queryStr = "SELECT Id, Answer, QuestionId, Status" +
            "FROM Answer" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public IDataReader GetByQuestion(int questionId)
        {
            string queryStr = "SELECT Id, Answer, QuestionId, Status" +
            "FROM Answer" +
            "WHERE QuestionId = " + questionId;
            return con.ExecuteReader(queryStr);
        }

        public IDataReader Add(int questionId, string answer, bool status)
        {
            string queryStr = "INSERT INTO [dbo].[Answer] " +
                "([Answer], [QuestionId], [Status])" +
                "VALUES (N'" + answer + "', " + questionId + ", " + status + ")";
            return (IDataReader)con.ExecuteScalar(queryStr);
        }

        public void Update(string answer)
        {
            string queryStr = "UPDATE [dbo].[Answer] SET [Answer] = N'" + answer + "'";
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(int questionId)
        {
            string queryStr = "UPDATE [dbo].[Answer] SET [QuestionId] = " + questionId;
            con.ExecuteNonQuery(queryStr);
        }

        public void UpdateStatus(int status)
        {
            string queryStr = "UPDATE [dbo].[Answer] SET [Status] = " + status;
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(string answer, int questionId, bool status)
        {
            string queryStr = "UPDATE [dbo].[Answer] SET [Answer] = N'" + answer + "'" +
                ", [QuestionId] = " + questionId +
                ", [Status] = " + status;
            con.ExecuteNonQuery(queryStr);
        }

        public void Delete(int id)
        {
            string queryStr = "DELETE FROM [dbo].[Answer] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public void Delete(string questionId)
        {
            string queryStr = "DELETE FROM [dbo].[Answer] WHERE [QuestionId] = '" + questionId + "'";
            con.ExecuteNonQuery(queryStr);
        }
    }
}
