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
    public partial class Admin_Book_del : Form
    {
        SqlConnection con;
        SqlCommandBuilder builder;
        SqlDataAdapter da;
        DataSet ds;
     
        public Admin_Book_del()
        {
            InitializeComponent();
            string str = @"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True";
            con = new SqlConnection(str);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Admin_Book_del_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            da = new SqlDataAdapter("SELECT  * FROM Books", con);
            builder = new SqlCommandBuilder(da);
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Delete";
            btn.Name = "Delete";
            btn.Text = "Delete";
            btn.UseColumnTextForButtonValue = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if ((MessageBox.Show("Confirm Delete ? ", "Delete", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(ds.Tables[0]);
                MessageBox.Show("Data Updated.....!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
