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
    public partial class update_book : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public update_book()
        {
            InitializeComponent();
        }
        DALS o = new DALS();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void update_book_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Books";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i = dataGridView1.SelectedCells[0].Value.ToString();
            //MessageBox.Show(i);

            this.Hide();
           update_book_view o = new update_book_view(i);
            o.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Books WHERE Book_name LIKE ('%" + textBox1.Text + "%') OR isbn LIKE ('%" + textBox1.Text + "%') OR author_name LIKE ('%" + textBox1.Text + "%') OR sub LIKE('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = 100;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_home_main m = new admin_home_main();
            m.Show();
        }
    }
}
