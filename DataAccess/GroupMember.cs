using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GroupMember
    {
        private static Connections con = null;

        public static IDataReader Get(int groupId)
        {
            con = new Connections();
            string queryStr = "SELECT Student.Id, Student.FullName, Student.Email, Student.College, Student.Username, Student.Password, " +
            "Student.Subject, Student.Age, Student.Birthday, Student.Assigned, JoinAt FROM Student, GroupMember " +
            " WHERE Student.Id = GroupMember.StudentId AND GroupId = " + groupId;
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(string code)
        {
            con = new Connections();
            string queryStr = "SELECT Student.Id, Student.FullName, Student.Email, Student.College, Student.Username, Student.Password, " +
            "Student.Subject, Student.Age, Student.Birthday, Student.Assigned, JoinAt FROM Student, GroupMember, [dbo].[Group] " +
            " WHERE Student.Id = GroupMember.StudentId AND [dbo].[Group].Id = GroupMember.GroupId AND [dbo].[Group].GroupCode like '" + code + "'";
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetByMember(int studentId)
        {
            con = new Connections();
            string queryStr = "SELECT GroupId FROM GroupMember " +
            " WHERE StudentId = " + studentId;
            return con.ExecuteReader(queryStr);
        }

    }
}
