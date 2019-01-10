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
    public partial class s_update_books_view : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public s_update_books_view(string i)
        {
            InitializeComponent();
            lbl_show.Text = i;
        }
        DALS o = new DALS();
        void loaddates(string i)
        {
            try
            {
                con.Open();
                // string str = "SELECT * FROM Student_info_new WHERE id = '" + i+"'";
                string str = "SELECT * FROM Books WHERE id = " + i;
                SqlCommand cmd = new SqlCommand(str, o.con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    //lbl_auto_id.Text = dr["emp_id"].ToString();
                    book_nametb.Text = dr["book_name"].ToString();
                    isbntb.Text = dr["isbn"].ToString();
                    anuthor_tb.Text = dr["author_name"].ToString();
                    edition_tb.Text = dr["edition"].ToString();
                    comboBox1.Text = dr["sub"].ToString();
                    no_copiestb.Text = dr["no_of_copies"].ToString();


                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                if (o.con.State == ConnectionState.Open)
                {
                    o.con.Close();
                }

            }
        }
        private void s_update_books_view_Load(object sender, EventArgs e)
        {
            loaddates(lbl_show.Text);
        }
        public void clearall()
        {

            isbntb.Clear();
            book_nametb.Clear();
            anuthor_tb.Clear();
            edition_tb.Clear();
            no_copiestb.Clear();
            lbl_show.Text = " ";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                o.con.Open();
                if (book_nametb.Text != "" && isbntb.Text != "" && comboBox1.SelectedIndex != -1 && anuthor_tb.Text != "" && edition_tb.Text != "" && no_copiestb.Text != "")
                {
                    string sql = "UPDATE Books SET book_name= '" + book_nametb.Text + "', isbn ='" + isbntb.Text + "', author_name ='" + anuthor_tb.Text + "', edition = '" + edition_tb.Text + "', sub='" + comboBox1.Text + "',  no_of_copies =" + no_copiestb.Text + " WHERE id=" + lbl_show.Text + "";
                    SqlCommand cmd = new SqlCommand(sql, o.con);
                    cmd.ExecuteNonQuery();
                    lbl_show.ForeColor = Color.SeaGreen;
                    lbl_show.Text = "Data Stored";
                }
                else
                {
                    lbl_show.ForeColor = Color.Red;
                    lbl_show.Text = "Please Fill All the Feilds ";
                }
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                if (o.con.State == ConnectionState.Open)
                {
                    o.con.Close();
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            emp_home_main a = new emp_home_main();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearall();
        }
    }
}
