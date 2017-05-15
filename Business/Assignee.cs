using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Assignee
    {
        public static List<propScoreBoard> Get(int groupId)
        {
            var listScoreBoard = new List<propScoreBoard>();
            var listGroupMember = GroupMember.Get(groupId);
            if (listGroupMember == null)
                return null;
            listGroupMember.ForEach(student =>
            {
                var onlineTest = OnlineTest.Get(student.id);
                var scoreboard = new propScoreBoard(student, onlineTest);
                listScoreBoard.Add(scoreboard);
            });

            return listScoreBoard;
        }

        public static void Assign(int professorId, int studentId, int projectId, string projectCode, string url)
        {
            var groupId = GroupMember.GetByMember(studentId);
            var listMember = GroupMember.Get(groupId);
            GroupMember.Update(listMember, projectCode, url);
            Group.Update(groupId, professorId, projectId);
        }
    }
}
