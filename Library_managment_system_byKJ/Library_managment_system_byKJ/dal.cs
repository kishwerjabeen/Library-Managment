using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library_managment_system_byKJ
{
    class dal
    {
        public static SqlConnection DBcon()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");
            con.Open();
            return con;
        }
    }
}
