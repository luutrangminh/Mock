using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Group
    {
        private static Connections con = null;

        public static IDataReader Get()
        {
            con = new Connections();
            string queryStr = "SELECT [dbo].[Group].Id, [dbo].[Group].GroupCode, [dbo].[Group].GroupName, " +
            "[dbo].[Group].CreatedAt, [dbo].[Group].CreatedBy, Student.FullName as CreatedByStr, [dbo].[Group].AssignBy, [dbo].[Group].ProjectId  " +
            " FROM [dbo].[Group], Student WHERE [dbo].[Group].CreatedBy = Student.Id AND [dbo].[Group].CreatedBy = Student.Id";
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(int professorId)
        {
            con = new Connections();
            string queryStr = "SELECT [dbo].[Group].Id, [dbo].[Group].GroupCode, [dbo].[Group].GroupName, " +
            "[dbo].[Group].CreatedAt, [dbo].[Group].CreatedBy, Student.FullName as CreatedByStr, [dbo].[Group].AssignBy, [dbo].[Group].ProjectId  " +
            " FROM [dbo].[Group], Student WHERE [dbo].[Group].CreatedBy = Student.Id AND AssignBy = " + professorId;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetById(int id)
        {
            con = new Connections();
            string queryStr = "SELECT [dbo].[Group].Id, [dbo].[Group].GroupCode, [dbo].[Group].GroupName, " +
            "[dbo].[Group].CreatedAt, [dbo].[Group].CreatedBy, Student.FullName as CreatedByStr, [dbo].[Group].AssignBy, [dbo].[Group].ProjectId  " +
            " FROM [dbo].[Group], Student WHERE [dbo].[Group].CreatedBy = Student.Id AND Id = '" + id + "'";
            return con.ExecuteReader(queryStr);
        }

        public static void Update(int id, int professorId, int projectId)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Group] SET [ProjectId] = " + projectId +
                ", [AssignBy] = " + professorId + 
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

    }
}
