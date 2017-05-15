using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class propGroup
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int projectId { get; set; }
        public DateTime createAt { get; set; }
        public int createdBy { get; set; }
        public string createdByStr { get; set; }
        public int AssignBy { get; set; }
    }

    public class Group
    {
        public static List<propGroup> Get()
        {
            var listGroup = new List<propGroup>();
            var data = DataAccess.Group.Get();
            if (data == null)
                return null;
            while (data.Read())
            {
                propGroup group = new propGroup();
                group.id = int.Parse(data["Id"].ToString());
                group.projectId = int.Parse(data["ProjectId"].ToString());
                group.code = data["GroupCode"].ToString();
                group.name = data["GroupName"].ToString();
                group.createAt = DateTime.Parse(data["CreatedAt"].ToString());
                group.createdBy = int.Parse(data["CreatedBy"].ToString());
                group.createdByStr = data["CreatedByStr"].ToString();
                group.AssignBy = int.Parse(data["AssignBy"].ToString());
                listGroup.Add(group);
            }
            data.Close();
            return listGroup;
        }

        public static List<propGroup> Get(int professorId)
        {
            var listGroup = new List<propGroup>();
            var data = DataAccess.Group.Get(professorId);
            if (data == null)
                return null;
            while (data.Read())
            {
                propGroup group = new propGroup();
                group.id = int.Parse(data["Id"].ToString());
                group.projectId = int.Parse(data["ProjectId"].ToString());
                group.code = data["GroupCode"].ToString();
                group.name = data["GroupName"].ToString();
                group.createAt = DateTime.Parse(data["CreatedAt"].ToString());
                group.createdBy = int.Parse(data["CreatedBy"].ToString());
                group.createdByStr = data["CreatedByStr"].ToString();
                group.AssignBy = int.Parse(data["AssignBy"].ToString());
                listGroup.Add(group);
            }
            data.Close();
            return listGroup;
        }

        public static propGroup GetById(int id)
        {
            var group = new propGroup();
            var data = DataAccess.Group.GetById(id);
            if (data == null)
                return null;
            while (data.Read())
            {
                group.id = int.Parse(data["Id"].ToString());
                group.projectId = int.Parse(data["ProjectId"].ToString());
                group.code = data["GroupCode"].ToString();
                group.name = data["GroupName"].ToString();
                group.createAt = DateTime.Parse(data["CreatedAt"].ToString());
                group.createdBy = int.Parse(data["CreatedBy"].ToString());
                group.createdByStr = data["CreatedByStr"].ToString();
                group.AssignBy = int.Parse(data["AssignBy"].ToString());
            }
            data.Close();
            return group;
        }

        public static void Update(int id, int professorId, int projectId)
        {
            DataAccess.Group.Update(id, professorId, projectId);
        }

    }
}
