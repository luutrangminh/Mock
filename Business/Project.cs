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
        DataAccess.Project projectDAO = new DataAccess.Project();

        public propProject Get(int id)
        {
            var project = new propProject();
            var data = projectDAO.Get(id);
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

        public propProject Get(string projectCode)
        {
            var project = new propProject();
            var data = projectDAO.Get(projectCode);
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

        public propProject Add(string projectCode, string name, DateTime createdAt, int createdBy, DateTime startAt, int time)
        {
            var project = new propProject();
            var data = projectDAO.Add(projectCode, name, createdAt, createdBy, startAt, time);
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

        public void Update(int id, string name)
        {
            projectDAO.Update(id, name);
        }

        public void Update(int id, DateTime startAt)
        {
            projectDAO.Update(id, startAt);
        }

        public void Update(int id, int time)
        {
            projectDAO.Update(id, time);
        }

        public void Delete(int id)
        {
            projectDAO.Delete(id);
        }

    }
}
