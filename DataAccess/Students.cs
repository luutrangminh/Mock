using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Students
    {

        private static Connections con = null;

        public static IDataReader Get(int professorId)
        {
            con = new Connections();
            string queryStr = "SELECT Id, FullName, College, " +
            "Subject, Age, Birthday FROM Student " +
            "WHERE AssignBy = " + professorId;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(string username)
        {
            con = new Connections();
            string queryStr = "SELECT Id, Username, Password, FullName, College, " +
            "Subject, Age, Birthday FROM Student " +
            " WHERE Username = '" + username + "'";
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetById(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Id, FullName, College, " +
            "Subject, Age, Birthday FROM Student " +
            " WHERE Id = '" + id + "'";
            return con.ExecuteReader(queryStr);
        }

        public static void Add(string username, string password, string fullName, string college, string subject, int age, DateTime birthday)
        {
            con = new Connections();
            string queryStr = "INSERT INTO [dbo].[Student] " +
                "([Username], [Password], [FullName], [College], [Subject], [Age], [Assigned], [Birthday])" +
                "VALUES ('" + username + "', '" + password + "', N'" + fullName + "', N'" +
                college + "', N'" + subject + "', 0, " + age + ", CONVERT(datetime, '" + birthday + "', 103))";
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Professors] SET [Assigned] = True" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

    }
}
