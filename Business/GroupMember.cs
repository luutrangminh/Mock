using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailProvider;

namespace Business
{
    public class propGroupMember
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string college { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string subject { get; set; }
        public int age { get; set; }
        public DateTime birthday { get; set; }
        public string birthdayStr { get; set; }
        public bool assigned { get; set; }
        public DateTime joinAt { get; set; }
        public string joinAtStr { get; set; }
    }

    public class GroupMember
    {
        public static List<propGroupMember> Get(int groupId)
        {
            var listGroup = new List<propGroupMember>();
            var data = DataAccess.GroupMember.Get(groupId);
            if (data == null)
                return null;
            while (data.Read())
            {
                var groupMember = new propGroupMember();
                groupMember.id = int.Parse(data["Id"].ToString());
                groupMember.fullName = data["FullName"].ToString();
                groupMember.email = data["Email"].ToString();
                groupMember.college = data["College"].ToString();
                groupMember.username = data["Username"].ToString();
                groupMember.password = data["Password"].ToString();
                groupMember.subject = data["Subject"].ToString();
                groupMember.birthday = DateTime.Parse(data["Birthday"].ToString());
                groupMember.birthdayStr = groupMember.birthday.ToString("dd/MM/yyyy");
                groupMember.age = int.Parse(data["Age"].ToString());
                groupMember.assigned = bool.Parse(data["Assigned"].ToString());
                groupMember.joinAt = DateTime.Parse(data["JoinAt"].ToString());
                groupMember.joinAtStr = groupMember.joinAt.ToString("dd/MM/yyyy");
                listGroup.Add(groupMember);
            }
            data.Close();
            return listGroup;
        }

        public static List<propGroupMember> Get(string code)
        {
            var listGroup = new List<propGroupMember>();
            var data = DataAccess.GroupMember.Get(code);
            if (data == null)
                return null;
            while (data.Read())
            {
                var groupMember = new propGroupMember();
                groupMember.id = int.Parse(data["Id"].ToString());
                groupMember.fullName = data["FullName"].ToString();
                groupMember.email = data["Email"].ToString();
                groupMember.college = data["College"].ToString();
                groupMember.username = data["Username"].ToString();
                groupMember.password = data["Password"].ToString();
                groupMember.subject = data["Subject"].ToString();
                groupMember.birthday = DateTime.Parse(data["Birthday"].ToString());
                groupMember.birthdayStr = groupMember.birthday.ToString("dd/MM/yyyy");
                groupMember.age = int.Parse(data["Age"].ToString());
                groupMember.assigned = bool.Parse(data["Assigned"].ToString());
                groupMember.joinAt = DateTime.Parse(data["JoinAt"].ToString());
                groupMember.joinAtStr = groupMember.joinAt.ToString("dd/MM/yyyy");
                listGroup.Add(groupMember);
            }
            data.Close();
            return listGroup;
        }

        public static int GetByMember(int studentId)
        {
            var data = DataAccess.GroupMember.GetByMember(studentId);
            var groupId = 0;
            if (data == null) return 0;
            while (data.Read())
            {
                groupId = int.Parse(data["GroupId"].ToString());
            }
            return groupId;
        }

        public static void Update(List<propGroupMember> listMember, string projectCode, string url)
        {
            listMember.ForEach(member => 
            {
                Student.Update(member.id);
                if (EmailSender.isEmail(member.email))
                {
                    string msg = "Bạn vừa được mời tham gia vào dự án mới<br>Project Code: " + projectCode +
                        "<br>Hoặc nhấn bên dưới đây để tham gia vào dự án:<br><a href='" + url + "'>Tham Gia</a>";
                    EmailSender.Send(member.email, "Bạn có dự án mới", msg);
                }
            });
        }

    }
}
