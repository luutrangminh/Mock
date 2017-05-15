using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OnlineTest
    {
        private static Connections con = null;

        public static IDataReader Get(int studentId)
        {
            con = new Connections();
            string queryStr = "SELECT Id, StudentId, StartDate, " +
            "ExpiryDate, Score, SubmitAt FROM OnlineTest " +
            "WHERE StudentId = " + studentId;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetById(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Id, StudentId, StartDate, " +
            "ExpiryDate, Score, SubmitAt FROM OnlineTest " +
            " WHERE Id = '" + id + "'";
            return con.ExecuteReader(queryStr);
        }

        public static void Add(int studentId, DateTime expiryDate)
        {
            con = new Connections();
            string queryStr = "INSERT INTO [dbo].[OnlineTest] " +
                "([StudentId], [StartDate], [ExpiryDate], [Score], [SubmitAt])" +
                "VALUES (" + studentId + ", CONVERT( datetime, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', 103),  CONVERT( datetime, '" + expiryDate.ToString("dd/MM/yyyy") + "', 103), " +
                0 + ", CONVERT( datetime, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', 103))";
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, int score, DateTime submitAt)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[OnlineTest] SET [Score] = " + score +
                ", [SubmitAt] = CONVERT( datetime, '" + submitAt.ToString("dd/MM/yyyy") + "', 103)" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

    }
}
