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
    public partial class emp_view_info : Form
    {
        DALS o = new DALS();
        public emp_view_info()
        {
            InitializeComponent();
        }
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

            //DataGridViewImageColumn image = new DataGridViewImageColumn();
            //image =(DataGridViewImageColumn)dataGridView1.Columns[8];
            //image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //da.Dispose();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void emp_view_info_Load(object sender, EventArgs e)
        {
            o.loadgrid("Select * from employ_info_new", dataGridView1); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                o.loadgrid("Select * From employ_info_new WHERE emp_name LIKE'%" + textBox1.Text + "%' OR emp_deg_id LIKE'%" + textBox1.Text + "%'  OR emp_depart LIKE'%" + textBox1.Text + "%' OR emp_id LIKE'%" + textBox1.Text + "%'", dataGridView1);
            }
            else
            {
                o.loadgrid("Select * From employ_info_new ", dataGridView1);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_home_main a = new admin_home_main();
            a.Show();
        }
    }
}
