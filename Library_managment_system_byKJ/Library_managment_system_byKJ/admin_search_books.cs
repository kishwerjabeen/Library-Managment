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
    public partial class admin_search_books : Form
    {
        public admin_search_books()
        {
            InitializeComponent();
        }
        DALS o = new DALS();

        void loadgrid(string qry)
        {

            SqlCommand cmd = new SqlCommand(qry, o.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            }

            
        }
        private void admin_search_books_Load(object sender, EventArgs e)
        {
            o.loadgrid("Select * from Books", dataGridView1); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                o.loadgrid("Select * From Books WHERE book_name LIKE'%" + textBox1.Text + "%' OR id LIKE'%" + textBox1.Text + "%'  OR isbn LIKE'%" + textBox1.Text + "%' OR author_name LIKE'%" + textBox1.Text + "%' OR sub LIKE'%" + textBox1.Text + "%'", dataGridView1);
            }
            else
            {
                o.loadgrid("Select * From Books", dataGridView1);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_home_main a = new admin_home_main();

            a.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
