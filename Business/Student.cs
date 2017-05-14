using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{

    public class propStudent
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string college { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string subject { get; set; }
        public int age { get; set; }
        public DateTime birthday { get; set; }
        public bool assigned { get; set; }
    }

    public class Student
    {

        public static List<propStudent> Get(int professorId)
        {
            var listStudent = new List<propStudent>();
            var data = Students.Get(professorId);
            if (data == null)
                return null;
            while (data.Read())
            {
                propStudent student = new propStudent();
                student.id = int.Parse(data["Id"].ToString());
                student.fullName = data["FullName"].ToString();
                student.college = data["College"].ToString();
                student.username = data["Username"].ToString();
                student.password = data["Password"].ToString();
                student.subject = data["Subject"].ToString();
                student.birthday = DateTime.Parse(data["Birthday"].ToString());
                student.age = int.Parse(data["Age"].ToString());
                student.assigned = bool.Parse(data["Assigned"].ToString());
                listStudent.Add(student);
            }
            data.Close();
            return listStudent;
        }

        public static propStudent Get(string username)
        {
            propStudent student = new propStudent();
            var data = Students.Get(username);
            if (data == null)
                return null;
            while (data.Read())
            {
                student.id = int.Parse(data["Id"].ToString());
                student.fullName = data["FullName"].ToString();
                student.college = data["College"].ToString();
                student.username = data["Username"].ToString();
                student.password = data["Password"].ToString();
                student.subject = data["Subject"].ToString();
                student.birthday = DateTime.Parse(data["Birthday"].ToString());
                student.age = int.Parse(data["Age"].ToString());
                student.assigned = bool.Parse(data["Assigned"].ToString());
            }
            data.Close();
            return student;
        }

        public static propStudent GetById(int id)
        {
            propStudent student = new propStudent();
            var data = Students.Get(id);
            if (data == null)
                return null;
            while (data.Read())
            {
                student.id = int.Parse(data["Id"].ToString());
                student.fullName = data["FullName"].ToString();
                student.college = data["College"].ToString();
                student.username = data["Username"].ToString();
                student.password = data["Password"].ToString();
                student.subject = data["Subject"].ToString();
                student.birthday = DateTime.Parse(data["Birthday"].ToString());
                student.age = int.Parse(data["Age"].ToString());
                student.assigned = bool.Parse(data["Assigned"].ToString());
            }
            return student;
        }

        public static void Add(string username, string password, string fullName, string college, string subject, int age, DateTime birthday)
        {
            Students.Add(username, password, fullName, college, subject, age, birthday);
        }

        public static void Update(int id)
        {
            Students.Update(id);
        }
    }
}
