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
        private static Connections con = null;

        public static IDataReader Get(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Id, Answer, QuestionId, Status" +
            "FROM Answer" +
            "WHERE Id = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetByQuestion(int questionId)
        {
            con = new Connections();
            string queryStr = "SELECT Id, Answer, QuestionId, Status" +
            "FROM Answer" +
            "WHERE QuestionId = " + questionId;
            return con.ExecuteReader(queryStr);
        }

        public static void Add(int questionId, string answer, bool status)
        {
            con = new Connections();
            string queryStr = "INSERT INTO [dbo].[Answer] " +
                "([Answer], [QuestionId], [Status])" +
                "VALUES (N'" + answer + "', " + questionId + ", " + status + ")";
            con.ExecuteScalar(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string answer)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Answer] SET [Answer] = N'" + answer + "'" +
                "WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, int questionId)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Answer] SET [QuestionId] = " + questionId +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void UpdateStatus(int id, int status)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Answer] SET [Status] = " + status +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string answer, int questionId, bool status)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Answer] SET [Answer] = N'" + answer + "'" +
                ", [QuestionId] = " + questionId +
                ", [Status] = " + status +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Delete(int id)
        {
            con = new Connections();
            string queryStr = "DELETE FROM [dbo].[Answer] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void DeleteByQuestion(int questionId)
        {
            con = new Connections();
            string queryStr = "DELETE FROM [dbo].[Answer] WHERE [QuestionId] = '" + questionId + "'";
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }
    }
}
