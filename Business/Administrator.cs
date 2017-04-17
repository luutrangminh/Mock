using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public class Administrator
    {
        DataAccess.Administrator adminDAOs = new DataAccess.Administrator();
        public List<String> Test()
        {
            var value = adminDAOs.TestSelect();
            var listName = new List<String>();
            while (value.Read())
            {
                listName.Add(value[1].ToString());
            }
            return listName;
        }
    }
}
