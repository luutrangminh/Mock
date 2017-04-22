using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class student
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string college { get; set; }
        public string subject { get; set; }
        public int AssignBy { get; set; }
        public DateTime birthday { get; set; }
    }
    class StudentManagement
    {
        DataAccess.StudentManagement studentDAOs = new DataAccess.StudentManagement();
        public List<String> Test()
        {
            var value = studentDAOs.TestSelect();
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[1].ToString());
            }
            return listName;
        }
        public List<String> LayTkMk()
        {
            var value = studentDAOs.TestSelect();
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[1].ToString());
                listName.Add(value[2].ToString());
            }
            return listName;
        }
        public List<String> kiemtratkmk(string user, string pass)
        {
            var value = studentDAOs.KTtkmk(user, pass);
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[1].ToString().Trim());
                listName.Add(value[2].ToString().Trim());
            }

            return listName;
        }
        public List<String> laydsgs()
        {
            var value = studentDAOs.DsGs();
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[1].ToString());
            }
            return listName;
        }
        public string layidgs(string ten)
        {
            var value = studentDAOs.DsGs();
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[0].ToString());
                listName.Add(value[1].ToString());
            }
            for (int i = 0; i < listName.Count; i++)
            {
                if (listName[i] == ten)
                {
                    return listName[i - 1];
                }
            }
            return "khongco";
        }
        public string kiemtratk(string tk)
        {
            var value = studentDAOs.TestSelect();
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[1].ToString().Trim());
            }
            foreach (var item in listName)
            {
                if (item == tk)
                {
                    return "co";
                }
            }
            return "khong";
        }
        public string kiemtraemail(string email)
        {
            var value = studentDAOs.TestSelect();
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[3].ToString().Trim());
            }
            foreach (var item in listName)
            {
                if (item == email)
                {
                    return "co";
                }
            }
            return "khong";
        }
        public void dangkysv(string tk, string mk, string email, string ten, string truong, string mon, int tuoi, int id, DateTime ngaysinh)
        {
            studentDAOs.ThemSV(tk, mk, email, ten, truong, mon, tuoi, id, ngaysinh);
        }
        public List<String> LayTTSV(string user)
        {
            var value = studentDAOs.LayTTSV(user);
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[0].ToString());
                listName.Add(value[1].ToString());
                listName.Add(value[2].ToString());
                listName.Add(value[3].ToString());
                listName.Add(value[4].ToString());
                listName.Add(value[5].ToString());
                listName.Add(value[6].ToString());
                listName.Add(value[7].ToString());
                listName.Add(value[8].ToString());
                listName.Add(value[9].ToString());
            }
            return listName;
        }
    }
}
