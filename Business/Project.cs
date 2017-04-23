using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class propProject
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public DateTime startAt { get; set; }
        public int time { get; set; }
    }

    public class Project
    {
        public static propProject Get(int id)
        {
            var project = new propProject();
            var data = DataAccess.Project.Get(id);
            while (data.Read())
            {
                project.id = int.Parse(data["Id"].ToString());
                project.code = data["ProjectCode"].ToString();
                project.name = data["Name"].ToString();
                project.startAt = DateTime.Parse(data["StartAt"].ToString());
                project.time = int.Parse(data["Time"].ToString());
                project.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                project.createdBy = int.Parse(data["CreatedBy"].ToString());
            }
            return project;
        }

        public static propProject Get(string projectCode)
        {
            var project = new propProject();
            var data = DataAccess.Project.Get(projectCode);
            while (data.Read())
            {
                project.id = int.Parse(data["Id"].ToString());
                project.code = data["ProjectCode"].ToString();
                project.name = data["Name"].ToString();
                project.startAt = DateTime.Parse(data["StartAt"].ToString());
                project.time = int.Parse(data["Time"].ToString());
                project.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                project.createdBy = int.Parse(data["CreatedBy"].ToString());
            }
            return project;
        }

        public static propProject Add(string projectCode, string name, DateTime createdAt, int createdBy, DateTime startAt, int time)
        {
            var project = new propProject();
            var data = DataAccess.Project.Add(projectCode, name, createdAt, createdBy, startAt, time);
            while (data.Read())
            {
                project.id = int.Parse(data["Id"].ToString());
                project.code = data["ProjectCode"].ToString();
                project.name = data["Name"].ToString();
                project.startAt = DateTime.Parse(data["StartAt"].ToString());
                project.time = int.Parse(data["Time"].ToString());
                project.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                project.createdBy = int.Parse(data["CreatedBy"].ToString());
            }
            return project;
        }

        public static void Update(int id, string name)
        {
            DataAccess.Project.Update(id, name);
        }

        public static void Update(int id, DateTime startAt)
        {
            DataAccess.Project.Update(id, startAt);
        }

        public static void Update(int id, int time)
        {
            DataAccess.Project.Update(id, time);
        }

        public static void Delete(int id)
        {
            DataAccess.Project.Delete(id);
        }

    }
}
