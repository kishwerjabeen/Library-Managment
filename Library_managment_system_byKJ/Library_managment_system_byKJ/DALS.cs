using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Library_managment_system_byKJ
{
    class DALS
    {
        public SqlConnection con;
        public string str;

        public DALS()
        {
            try
            {
                str = @"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();
               // MessageBox.Show("database connected");
                          
            }
            catch (SqlException x)
            {
                MessageBox.Show(x.Message);
            }

        }

        public void loadgrid(string qry, DataGridView grid)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(qry, con);
            da.SelectCommand = cmd;
            da.Fill(ds);
            grid.DataSource = ds.Tables[0];
            da.Dispose();
            cmd.Dispose();

        }
    }
}
