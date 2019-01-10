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
    public partial class add_Books_admin : Form
    {
        public add_Books_admin()
        {
            InitializeComponent();
        
        }

        DALS o = new DALS();


        private void saveButton_Click(object sender, EventArgs e)
       
        {
            try
            {

                string qry = "INSERT INTO Books(isbn,book_name,author_name,edition,sub,no_of_copies,available_copies) VALUES(" + isbntb.Text + " ,'" + book_nametb.Text + "','" + anuthor_tb.Text + "','" + edition_tb + "','" + comboBox1.Text + "'," + no_copiestb.Text + " ," + no_copiestb.Text + ")";
                SqlCommand cmd = new SqlCommand(qry, o.con);
                cmd.ExecuteNonQuery();
                lbl_addBook.ForeColor = Color.DarkSeaGreen;
                lbl_addBook.Text = "Data Stored";
            }
            catch(Exception x)
            {
                lbl_addBook.ForeColor = Color.Red;
                lbl_addBook.Text = x.Message;
            }
        }
        public void clearall()
        {
          
            isbntb.Clear();
            book_nametb.Clear();
            anuthor_tb.Clear();
            edition_tb.Clear();
            no_copiestb.Clear();
            lbl_addBook.Text = " ";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void add_Books_admin_Load(object sender, EventArgs e)
        {
          //  o.loadgrid("Select * From Books", dataGridView1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_home_main a = new admin_home_main();
            a.Show();
          
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            admin_home_main a = new admin_home_main();
            a.Show();
        }

        
    }
}
