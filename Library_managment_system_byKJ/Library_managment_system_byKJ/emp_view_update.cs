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
    public partial class emp_view_update : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public emp_view_update(string i)
        {
            InitializeComponent();
            lbl_show.Text = i;
        }
        DALS o = new DALS();

        void loaddates(string i)
        {
            try
            {
                // string str = "SELECT * FROM Student_info_new WHERE libry_id = '" + i+"'";
                string str = "SELECT * FROM employ_info_new WHERE id = " + i;
                SqlCommand cmd = new SqlCommand(str, o.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lbl_auto_id.Text = dr["emp_id"].ToString();
                    std_name_tb.Text = dr["emp_name"].ToString();
                    comboBox1.Text = dr["emp_gender"].ToString();
                    deg_tb.Text = dr["emp_deg_id"].ToString();
                    deprtr_tb.Text = dr["emp_depart"].ToString();
                    
                    tb_cell_no.Text = dr["cell"].ToString();
                    tb_email.Text = dr["email"].ToString();
                    passtb.Text = dr["e_password"].ToString();
                    byte[] img = (byte[])dt.Rows[0][9];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox3.Image = Image.FromStream(ms);

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                if (o.con.State == ConnectionState.Open)
                {
                    o.con.Close();
                }

            }

        }

        private void emp_view_update_Load(object sender, EventArgs e)
        {
            loaddates(lbl_show.Text);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void emp_view_update_FormClosing(object sender, FormClosingEventArgs e)
        {
            update_student_info o = new update_student_info();
            o.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            emp_update_info o = new emp_update_info();
            o.Show();
        }
        string img_file = null;
        private void update_button_Click(object sender, EventArgs e)
        {
            if (std_name_tb.Text != "" && deg_tb.Text != "" && comboBox1.SelectedIndex != -1 && deprtr_tb.Text != ""  && tb_cell_no.Text != "" && tb_email.Text != "" && passtb.Text != "")
            {

                if (passtb.Text == con_passtb.Text)
                {
                    try
                    {

                   o.con.Open();
                    if (img_file != null)
                    {
                        FileStream fs1 = new FileStream(img_file, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] image = new byte[fs1.Length];
                        fs1.Read(image, 0, Convert.ToInt32(fs1.Length));
                        fs1.Close();

                        string sql = "UPDATE employ_info_new SET emp_id= '" + lbl_auto_id.Text + "',emp_name ='" + std_name_tb.Text + "', emp_gender ='" + comboBox1.Text + "', emp_deg_id = '"+deg_tb.Text+"' ,emp_depart ='" + deprtr_tb.Text + "',  Cell ='" + tb_cell_no.Text + "', email ='" + tb_email.Text + "', e_password ='" + passtb.Text + "', images = @pic WHERE id=" + lbl_show.Text + "";
                        SqlCommand cmd = new SqlCommand(sql, o.con);
                        SqlParameter prm = new SqlParameter("@pic", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                        cmd.Parameters.Add(prm);
                        cmd.ExecuteNonQuery();


                    }
                    else
                    {
                        // string sql = "UPDATE Student_info_new SET libry_id= '"+lbl_auto_id.Text+"' ,std_name ='" + std_name_tb.Text + "', std_rollno ='" + std_rollTb.Text + "', gender ='" + comboBox1.Text + "', std_department ='" + deprtr_tb.Text + "', std_sem ='" + sem_tb.Text + "', CellNo ='" + tb_cell_no.Text + "', email ='" + tb_email.Text + "', s_password ='" + passtb.Text + "' WHERE id = " + lbl_show.Text + "";
                        string sql = "UPDATE employ_info_new SET emp_id= '" + lbl_auto_id.Text + "',emp_name ='" + std_name_tb.Text + "', emp_gender ='" + comboBox1.Text + "', emp_deg_id = '"+deg_tb.Text+"',emp_depart='" + deprtr_tb.Text + "',  Cell ='" + tb_cell_no.Text + "', email ='" + tb_email.Text + "', e_password ='" + passtb.Text + "' WHERE id=" + lbl_show.Text + "";
                        SqlCommand cmd = new SqlCommand(sql, o.con);
                        cmd.ExecuteNonQuery();
                    }
                    lbl_show.ForeColor = Color.SeaGreen;
                    lbl_show.Text = "Data Stored";
                }

                   catch (Exception x)
                   {
                       MessageBox.Show(x.Message);
                   }
                   finally
                   {
                       if (o.con.State == ConnectionState.Open)
                       {
                           o.con.Close();
                       }

                   }
                }

                else
                {
                    lbl_show.ForeColor = Color.Red;
                    lbl_show.Text = "Please Provide Same Password";
                }
            }
            else
            {
                lbl_show.ForeColor = Color.Red;
                lbl_show.Text = "Please Fill All the Feilds ";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "JPEG|*.jpg|PNG|*.png";
            if (o.ShowDialog() != DialogResult.Cancel)
            {
                img_file = o.FileName;
                pictureBox3.Image = Image.FromFile(o.FileName);
            }
        }
    }
}
