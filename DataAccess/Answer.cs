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
        private static Connections con = new Connections();

        public static IDataReader Get(int id)
        {
            string queryStr = "SELECT Id, Answer, QuestionId, Status" +
            "FROM Answer" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetByQuestion(int questionId)
        {
            string queryStr = "SELECT Id, Answer, QuestionId, Status" +
            "FROM Answer" +
            "WHERE QuestionId = " + questionId;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Add(int questionId, string answer, bool status)
        {
            string queryStr = "INSERT INTO [dbo].[Answer] " +
                "([Answer], [QuestionId], [Status])" +
                "VALUES (N'" + answer + "', " + questionId + ", " + status + ")";
            return (IDataReader)con.ExecuteScalar(queryStr);
        }

        public static void Update(int id, string answer)
        {
            string queryStr = "UPDATE [dbo].[Answer] SET [Answer] = N'" + answer + "'" +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, int questionId)
        {
            string queryStr = "UPDATE [dbo].[Answer] SET [QuestionId] = " + questionId +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void UpdateStatus(int id, int status)
        {
            string queryStr = "UPDATE [dbo].[Answer] SET [Status] = " + status +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, string answer, int questionId, bool status)
        {
            string queryStr = "UPDATE [dbo].[Answer] SET [Answer] = N'" + answer + "'" +
                ", [QuestionId] = " + questionId +
                ", [Status] = " + status +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Delete(int id)
        {
            string queryStr = "DELETE FROM [dbo].[Answer] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void DeleteByQuestion(int questionId)
        {
            string queryStr = "DELETE FROM [dbo].[Answer] WHERE [QuestionId] = '" + questionId + "'";
            con.ExecuteNonQuery(queryStr);
        }
    }
}
