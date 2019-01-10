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
using System.Net;
using System.Net.Mail;

namespace Library_managment_system_byKJ
{
    public partial class report_book_remain_retain : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public report_book_remain_retain()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet1 ds = new DataSet1();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Book_Issue_New WHERE book_return_date=''";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds.DataTable1);

                CrystalReport1 myreport = new CrystalReport1();
                myreport.SetDataSource(ds);
                crystalReportViewer1.ReportSource = myreport;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void report_book_remain_retain_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
    }
}
