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
        DataAccess.Professor professorDAO = new DataAccess.Professor();

        public List<propProfessor> Get()
        {
            var listProfessor = new List<propProfessor>();
            var data = professorDAO.Get();
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
            }
            return listProfessor;
        }

        public propProfessor Get(string username)
        {
            propProfessor professor = new propProfessor();
            var data = professorDAO.Get(username);
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

        public propProfessor Add(int createdBy, DateTime createdAt, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            var professor = new propProfessor();
            var data = professorDAO.Add(createdBy, createdAt, fullName, email, username, password, phoneNumber, address);
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

        public void Update(int id, string fullName)
        {
            professorDAO.Update(id, fullName);
        }

        public void Update(int id, string fullName, string email)
        {
            professorDAO.Update(id, fullName, email);
        }

        public void Update(int id, string fullName, string email, string username)
        {
            professorDAO.Update(id, fullName, email, username);
        }

        public void Updat(int id, string fullName, string email, string username,
            string password)
        {
            professorDAO.Update(id, fullName, email, username, password);
        }

        public void Update(int id, string fullName, string email, string username,
            string password, string phoneNumber)
        {
            professorDAO.Update(id, fullName, email, username, password, phoneNumber);
        }

        public void Update(int id, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            professorDAO.Update(id, fullName, email, username, password, phoneNumber, address);
        }

        public void Delete(int id)
        {
            professorDAO.Delete(id);
        }

        public void Delete(string username)
        {
            professorDAO.Delete(username);
        }
    }
}
