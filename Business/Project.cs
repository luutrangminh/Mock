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
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class Project
    {
        public static bool VerifyByProfessor(int professorId, int projectId)
        {
            var data = DataAccess.Project.Get(projectId);
            while(data.Read()) 
            {
                if (int.Parse(data["CreatedBy"].ToString()) == professorId) return true;    
            }

            return false;
        }

        public static propProject Get(int id)
        {
            var project = new propProject();
            var data = DataAccess.Project.Get(id);
            while (data.Read())
            {
                project.id = int.Parse(data["Id"].ToString());
                project.code = data["ProjectCode"].ToString();
                project.name = data["Name"].ToString();
                project.startDate = DateTime.Parse(data["StartDate"].ToString());
                project.endDate = DateTime.Parse(data["EndDate"].ToString());
                project.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                project.createdBy = int.Parse(data["CreatedBy"].ToString());
            }
            data.Close();
            return project;
        }

        public static List<propProject> GetByProfessor(int id)
        {
            var projectList = new List<propProject>();
            var data = DataAccess.Project.GetByProfessor(id);
            while (data.Read())
            {
                var project = new propProject();
                project.id = int.Parse(data["Id"].ToString());
                project.code = data["ProjectCode"].ToString();
                project.name = data["Name"].ToString();
                project.startDate = DateTime.Parse(data["StartDate"].ToString());
                project.endDate = DateTime.Parse(data["EndDate"].ToString());
                project.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                project.createdBy = int.Parse(data["CreatedBy"].ToString());
                projectList.Add(project);
            }
            data.Close();
            return projectList;
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
                project.startDate = DateTime.Parse(data["StartDate"].ToString());
                project.endDate = DateTime.Parse(data["EndDate"].ToString());
                project.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                project.createdBy = int.Parse(data["CreatedBy"].ToString());
            }
            data.Close();
            return project;
        }

        public static string Add(string name, DateTime createdAt, int createdBy, DateTime startDate, DateTime endDate)
        {
            if (DateTime.Compare(startDate, endDate) == 0) return "Error 1002: Start date can't be the same as End date";
            else if (DateTime.Compare(startDate, endDate) > 0) return "Error 1003: Start date can't be later than End date";
            else DataAccess.Project.Add(name, createdAt, createdBy, startDate, endDate);
            return null;
        }

        public static void Update(int id, string name)
        {
            DataAccess.Project.Update(id, name);
        }

        public static string Update(int id, DateTime startDate, DateTime endDate)
        {
            if (DateTime.Compare(startDate, endDate) == 0) return "Error 1002: Start date can't be the same as End date";
            else if (DateTime.Compare(startDate, endDate) > 0) return "Error 1003: Start date can't be later than End date";
            else DataAccess.Project.Update(id, startDate, endDate);
            return null;
        }

        public static string Update(int id, string name, DateTime startDate, DateTime endDate)
        {
            if (DateTime.Compare(startDate, endDate) == 0) return "Error 1002: Start date can't be the same as End date";
            else if (DateTime.Compare(startDate, endDate) > 0) return "Error 1003: Start date can't be later than End date";
            else DataAccess.Project.Update(id, name, startDate, endDate);
            return null;
        }

        public static void Delete(int id)
        {
            DataAccess.Project.Delete(id);
        }

    }
}
