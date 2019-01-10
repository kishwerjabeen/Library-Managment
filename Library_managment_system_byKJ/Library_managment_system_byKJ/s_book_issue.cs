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
    public partial class s_book_issue : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public s_book_issue()
        {
            InitializeComponent();
        }
        DALS o = new DALS();
        private void s_book_issue_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();

        }
        public void clearall()
        {
            tb_std_roll.Clear();
            tb_stdname.Clear();
            tb_std_book.Clear();
            tb_std_cell.Clear();
            tb_std_dep.Clear();
            tb_std_eamil.Clear();
            tb_std_sem.Clear();
            lbl_show.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearall();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void tb_std_book_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tb_std_book_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            emp_home_main a = new emp_home_main();
            a.Show();
        }

        private void tb_std_book_KeyUp_1(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Student_info_new Where std_rollno = '" + tb_std_roll.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("this Rollno not Found");
            }

            else
            {

                foreach (DataRow dr in dt.Rows)
                {
                    tb_stdname.Text = dr["std_name"].ToString();
                    tb_std_dep.Text = dr["std_department"].ToString();
                    tb_std_sem.Text = dr["std_sem"].ToString();
                    tb_std_cell.Text = dr["cellNo"].ToString();
                    tb_std_eamil.Text = dr["email"].ToString();
                }


            }
        }

        private void tb_std_book_KeyUp_2(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode != Keys.Enter)
            {
                listBox1.Items.Clear();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM  Books Where book_name LIKE ('%" + tb_std_book.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count > 0)
                {
                    listBox1.Visible = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["book_name"].ToString());
                    }
                }
            }
        }

        private void tb_std_book_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                //you mighr to need select one value by useing arrow key 
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_std_book.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }

        }

        private void listBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            tb_std_book.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            int books_qty = 0;
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Books WHERE book_name='" + tb_std_book.Text + "'";
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            foreach (DataRow dr2 in dt2.Rows)
            {
                // count = Convert.ToInt32(dt.Rows.Count.ToString());
                books_qty = Convert.ToInt32(dr2["available_copies"].ToString());

            }

            if (books_qty > 0)
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Book_Issue_New Values('" + tb_std_roll.Text + "','" + tb_stdname.Text + "','" + tb_std_dep.Text + "','" + tb_std_sem.Text + "','" + tb_std_cell.Text + "','" + tb_std_eamil.Text + "','" + tb_std_book.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','')";
                cmd.ExecuteNonQuery();



                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "UPDATE Books SET available_copies = available_copies-1 WHERE book_name='" + tb_std_book.Text + "'";
                cmd1.ExecuteNonQuery();
                lbl_show.Text = "Book Issue Susscessfull";
                //MessageBox.Show("Book Issue Susscessfull");

            }

            else
            {
                // MessageBox.Show("Book not available");
                lbl_show.Text = "Book Issue Susscessfull";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            clearall();
        }
    }
}