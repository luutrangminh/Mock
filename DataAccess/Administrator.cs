using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Administrator
    {
        Connections con = new Connections();

        public IDataReader TestSelect()
        {
            return con.ExecuteReader("Select * From Administrator");
        }
    }
}
