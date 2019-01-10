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
    public partial class emp_update_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public emp_update_info()
        {
            InitializeComponent();
        }
        DALS o = new DALS();


        private void emp_update_info_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM employ_info_new";
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
            MessageBox.Show(i);
            this.Hide();
            emp_view_update u = new emp_view_update(i);
            u.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM employ_info_new WHERE emp_name LIKE ('%" + textBox1.Text + "%')";
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
            admin_home_main o = new admin_home_main();
            o.Show();
        }
    }
}
