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
    public partial class update_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");
      
        public update_student_info()
        {
            InitializeComponent();
        }
        DALS o = new DALS();
        void loadgrid(string qry)
        {
        


          /*  SqlCommand cmd = new SqlCommand(qry, o.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            } */

            //DataGridViewImageColumn image = new DataGridViewImageColumn();
            //image =(DataGridViewImageColumn)dataGridView1.Columns[8];
            //image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //da.Dispose();

        }

        private void update_student_info_Load(object sender, EventArgs e)
        {
           // loadgrid("Select * from Student_info");   ya tmail ka ha 
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();

          //  int i = 0;

          SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Student_info_new";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 20;
            }
            
            


        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          //  string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
          //  MessageBox.Show(id);


            //this.Hide();
            //view_Update_Usser_ o = new view_Update_Usser_(id);
            //o.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // string i = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           string i = dataGridView1.SelectedCells[0].Value.ToString();
           // int i;
           // i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
      //   MessageBox.Show(i);

           this.Hide();
           view_Update_Usser_ o = new view_Update_Usser_(i);
           o.Show();
          
          /*  SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Student_info WHERE libry_id = '" + i+"'"  ;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            
            foreach(DataRow dr in dt.Rows)
            {
                std_name_tb.Text = dr["std_name"].ToString();
                std_rollTb.Text = dr["std_rollno"].ToString();
                comboBox1.Text = dr["gender"].ToString();
                deprtr_tb.Text = dr["std_department"].ToString();
                sem_tb.Text = dr["std_sem"].ToString();
               tb_cell_no.Text = dr["cellNo"].ToString();
               tb_email.Text = dr["email"].ToString();
               passtb.Text = dr["s_password"].ToString();
               byte[] img = (byte[])dt.Rows[0][9];
               MemoryStream ms = new MemoryStream(img);
               pictureBox1.Image = Image.FromStream(ms);

            }
        
           * */
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Student_info_new WHERE std_name LIKE ('%" + textBox1.Text + "%')";
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
            catch(Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
          
        }
      //  string img_file = null;
        private void SelectButton_Click(object sender, EventArgs e)
        {
           // OpenFileDialog o = new OpenFileDialog();
            
        }

        private void update_button_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_home_main o = new admin_home_main();
            o.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
