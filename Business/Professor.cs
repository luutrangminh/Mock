using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class propProfessor
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public int createdBy { get; set; }
        public DateTime createdAt { get; set; }
    }

    public class Professor
    {
        public static List<propProfessor> Get()
        {
            var listProfessor = new List<propProfessor>();
            var data = DataAccess.Professor.Get();
            if (data == null)
                return null;
            while (data.Read())
            {
                propProfessor professor = new propProfessor();
                professor.id = int.Parse(data["Id"].ToString());
                professor.fullName = data["FullName"].ToString();
                professor.email = data["Email"].ToString();
                professor.username = data["Username"].ToString();
                professor.phoneNumber = data["PhoneNumber"].ToString();
                professor.address = data["Address"].ToString();
                professor.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                professor.createdBy = int.Parse(data["CreatedBy"].ToString());
                listProfessor.Add(professor);
            }
            DataAccess.Professor.Close();
            return listProfessor;
        }

        public static propProfessor Get(string username)
        {
            propProfessor professor = new propProfessor();
            var data = DataAccess.Professor.Get(username);
            if (data == null)
                return null;
            while (data.Read())
            {
                professor.id = int.Parse(data["Id"].ToString());
                professor.fullName = data["FullName"].ToString();
                professor.email = data["Email"].ToString();
                professor.username = data["Username"].ToString();
                professor.phoneNumber = data["PhoneNumber"].ToString();
                professor.address = data["Address"].ToString();
                professor.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                professor.createdBy = int.Parse(data["CreatedBy"].ToString());
            }
            return professor;
        }

        public static propProfessor Get(int id)
        {
            propProfessor professor = new propProfessor();
            var data = DataAccess.Professor.Get(id);
            if (data == null)
                return null;
            while (data.Read())
            {
                professor.id = int.Parse(data["Id"].ToString());
                professor.fullName = data["FullName"].ToString();
                professor.email = data["Email"].ToString();
                professor.username = data["Username"].ToString();
                professor.phoneNumber = data["PhoneNumber"].ToString();
                professor.address = data["Address"].ToString();
                professor.createdAt = DateTime.Parse(data["CreatedAt"].ToString());
                professor.createdBy = int.Parse(data["CreatedBy"].ToString());
            }
            return professor;
        }


        public static void Add(int createdBy, DateTime createdAt, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            DataAccess.Professor.Add(createdBy, createdAt, fullName, email, username, password, phoneNumber, address);
        }

        public static void Update(int id, string fullName)
        {
            DataAccess.Professor.Update(id, fullName);
        }

        public static void Update(int id, string fullName, string email)
        {
            DataAccess.Professor.Update(id, fullName, email);
        }

        public static void Update(int id, string fullName, string email, string username)
        {
            DataAccess.Professor.Update(id, fullName, email, username);
        }

        public static void Updat(int id, string fullName, string email, string username,
            string password)
        {
            DataAccess.Professor.Update(id, fullName, email, username, password);
        }

        public static void Update(int id, string fullName, string email, string username,
            string password, string phoneNumber)
        {
            DataAccess.Professor.Update(id, fullName, email, username, password, phoneNumber);
        }

        public static void Update(int id, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            DataAccess.Professor.Update(id, fullName, email, username, password, phoneNumber, address);
        }

        public static void Delete(int id)
        {
            DataAccess.Professor.Delete(id);
        }

        public static void Delete(string username)
        {
            DataAccess.Professor.Delete(username);
        }
    }
}
