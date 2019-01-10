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
    public partial class admin_return_form : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public admin_return_form()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void admin_return_form_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();

        }
        public void fill_grid(string rollNo)
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Book_Issue_New Where std_rollno = '" + rollNo.ToString() + "'AND book_return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            fill_grid(tb_std_roll.Text);
                
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        //for bookline selection and vissbal in pannel 
            panel3.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Book_Issue_New Where bis_id=" + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
               lbl_bookName.Text = dr["book_name"].ToString();
               lbl_issueDates.Text = Convert.ToString(dr["book_issue_date"].ToString());
            }



        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Book_Issue_New SET book_return_date='" + dateTimePicker1.Value.ToString() + "' WHERE bis_id=" + i + "";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "UPDATE Books SET available_copies = available_copies+1 WHERE book_name= '" + lbl_bookName.Text + "'";
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Book Return Succesfully...!!");



                panel3.Visible = true;
               fill_grid(tb_std_roll.Text);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_home_main a = new admin_home_main();
            a.Show();
        }

    }
}
