using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public class propAdmin
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }


    public class Administrator
    {
        public List<String> Test()
        {
            var value = DataAccess.Administrator.TestSelect();
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[1].ToString());
            }
            return listName;
        }

        public static propAdmin Get(string username)
        {
            var data = DataAccess.Administrator.Get(username);
            propAdmin admin = new propAdmin();
            while (data.Read())
            {
                admin.Id = int.Parse(data["Id"].ToString());
                admin.Username = data["Username"].ToString();
                admin.Password = data["Password"].ToString();
                admin.FullName = data["FullName"].ToString();
            }
            DataAccess.Administrator.Close();
            return admin;
        }
        
        public static propAdmin Get(int id)
        {
            var data = DataAccess.Administrator.Get(id);
            propAdmin admin = new propAdmin();
            while (data.Read())
            {
                admin.Id = int.Parse(data["Id"].ToString());
                admin.Username = data["Username"].ToString();
                admin.Password = data["Password"].ToString();
                admin.FullName = data["FullName"].ToString();
            }
            DataAccess.Administrator.Close();
            return admin;
        }
    }
}
