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
    public partial class s_stock_book_reco_email : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public s_stock_book_reco_email()
        {
            InitializeComponent();
        }

        private void s_stock_book_reco_email_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();
            fill_book_info();
        }
        public void fill_book_info()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT book_name,author_name,no_of_copies,available_copies FROM Books ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string i;
                i = dataGridView1.SelectedCells[0].Value.ToString();
                // MessageBox.Show(i.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM  Book_Issue_New WHERE  book_name='" + i.ToString() + "' AND book_return_date=''";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void tb_Stock_FirstBox_KeyUp(object sender, KeyEventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT book_name,author_name,no_of_copies,available_copies FROM Books WHERE book_name LIKE('%" + tb_Stock_FirstBox.Text + "%') ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt; 
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //panel1.Visible = true;
            string i;
            i = dataGridView2.SelectedCells[6].Value.ToString();
            tb_email.Text = i.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;


                //ussername , Password Yours (company)
                smtp.Credentials = new NetworkCredential("kishwerjabeen90@gmail.com", "kish#123*123");

                //from, to subject,body
                MailMessage mail = new MailMessage("kishwerjabeen90@gmail.com", tb_email.Text, "This is for book return notice ", tb_content.Text);
                mail.Priority = MailPriority.High;
                smtp.Send(mail);
                MessageBox.Show("mail send");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            emp_home_main a = new emp_home_main();
            a.Show();
        }

    }
}
