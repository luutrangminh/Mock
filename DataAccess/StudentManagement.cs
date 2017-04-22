using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StudentManagement
    {
        Connections con = new Connections();
        public IDataReader TestSelect()
        {
            return con.ExecuteReader("Select * From Student");
        }
        public IDataReader KTtkmk(string user, string pass)
        {
            string queryStr = "Select * From Student where Username like '" + user + "' and Password like '" + pass + "'";
            return con.ExecuteReader(queryStr);
        }
        public IDataReader DsGs()
        {
            return con.ExecuteReader("Select * From Professors");
        }
        public void ThemSV(string tk, string mk, string email, string ten, string truong, string mon, int tuoi, int id, DateTime ngaysinh)
        {
            con.ExecuteNonQuery("Insert into Student (Username,Password,Email,FullName,College,Subject,Age,AssignBy,Birthday) values ('" + tk + "','" + mk + "','" + email + "','" + ten + "','" + truong + "','" + mon + "'," + tuoi + "," + id + ",'" + ngaysinh + "')");
        }
        public IDataReader LayTTSV(string user)
        {
            return con.ExecuteReader("Select * from Student where Username like '" + user + "'");
        }
    }
}
