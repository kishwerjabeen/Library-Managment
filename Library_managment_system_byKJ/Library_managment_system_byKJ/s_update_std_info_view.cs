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
    public partial class s_update_std_info_view : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True");

        public s_update_std_info_view(string i)
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
                string str = "SELECT * FROM Student_info_new WHERE id = " + i;
                SqlCommand cmd = new SqlCommand(str, o.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lbl_auto_id.Text = dr["libry_id"].ToString();
                    std_name_tb.Text = dr["std_name"].ToString();
                    std_rollTb.Text = dr["std_rollno"].ToString();
                    comboBox1.Text = dr["gender"].ToString();
                    deprtr_tb.Text = dr["std_department"].ToString();
                    sem_tb.Text = dr["std_sem"].ToString();
                    tb_cell_no.Text = dr["cellNo"].ToString();
                    tb_email.Text = dr["email"].ToString();
                    passtb.Text = dr["s_password"].ToString();
                    byte[] img = (byte[])dt.Rows[0][10];
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
        private void s_update_std_info_view_Load(object sender, EventArgs e)
        {
            loaddates(lbl_show.Text);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void s_update_std_info_view_FormClosing(object sender, FormClosingEventArgs e)
        {
            s_update_std_Info o = new s_update_std_Info();
            o.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            s_update_std_Info o = new s_update_std_Info();
            o.Show();
        }
        string img_file = null;
        private void update_button_Click(object sender, EventArgs e)
        {
            if (std_name_tb.Text != "" && std_rollTb.Text != "" && comboBox1.SelectedIndex != -1 && deprtr_tb.Text != "" && sem_tb.Text != "" && tb_cell_no.Text != "" && tb_email.Text != "" && passtb.Text != "")
            {

                if (passtb.Text == con_passtb.Text)
                {
                    //try
                    //{

                        o.con.Open();
                        if (img_file != null)
                        {
                            FileStream fs1 = new FileStream(img_file, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] image = new byte[fs1.Length];
                            fs1.Read(image, 0, Convert.ToInt32(fs1.Length));
                            fs1.Close();

                            string sql = "UPDATE Student_info_new SET libry_id= '" + lbl_auto_id.Text + "',std_name ='" + std_name_tb.Text + "', std_rollno ='" + std_rollTb.Text + "', gender ='" + comboBox1.Text + "', std_department ='" + deprtr_tb.Text + "', std_sem ='" + sem_tb.Text + "', CellNo ='" + tb_cell_no.Text + "', email ='" + tb_email.Text + "', s_password ='" + passtb.Text + "', std_images = @pic WHERE id=" + lbl_show.Text + "";
                            SqlCommand cmd = new SqlCommand(sql, o.con);
                            SqlParameter prm = new SqlParameter("@pic", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                            cmd.Parameters.Add(prm);
                            cmd.ExecuteNonQuery();


                        }
                        else
                        {
                            // string sql = "UPDATE Student_info_new SET libry_id= '"+lbl_auto_id.Text+"' ,std_name ='" + std_name_tb.Text + "', std_rollno ='" + std_rollTb.Text + "', gender ='" + comboBox1.Text + "', std_department ='" + deprtr_tb.Text + "', std_sem ='" + sem_tb.Text + "', CellNo ='" + tb_cell_no.Text + "', email ='" + tb_email.Text + "', s_password ='" + passtb.Text + "' WHERE id = " + lbl_show.Text + "";
                         //   string sql = "UPDATE Student_info_new SET libry_id= '" + lbl_auto_id.Text + "',std_name ='" + std_name_tb.Text + "', std_rollno ='" + std_rollTb.Text + "', gender ='" + comboBox1.Text + "', std_department ='" + deprtr_tb.Text + "', std_sem ='" + sem_tb.Text + "', CellNo ='" + tb_cell_no.Text + "', email ='" + tb_email.Text + "', s_password ='" + passtb.Text + "' WHERE id = " + lbl_show.Text + "";

                            string sql = "UPDATE Student_info_new SET libry_id= '" + lbl_auto_id.Text + "',std_name ='" + std_name_tb.Text + "', std_rollno ='" + std_rollTb.Text + "', gender ='" + comboBox1.Text + "', std_department ='" + deprtr_tb.Text + "', std_sem ='" + sem_tb.Text + "', CellNo ='" + tb_cell_no.Text + "', email ='" + tb_email.Text + "', s_password ='" + passtb.Text + "' WHERE id = " + lbl_show.Text + "";
                            SqlCommand cmd = new SqlCommand(sql, o.con);
                            cmd.ExecuteNonQuery();
                        }
                        lbl_show.ForeColor = Color.Red;
                        lbl_show.Text = "Data Stored";
                    //}

                    //catch (Exception x)
                    //{
                    //    MessageBox.Show(x.Message);
                    //}
                    //finally
                    //{
                    //    if (o.con.State == ConnectionState.Open)
                    //    {
                    //        o.con.Close();
                    //    }

                    //}
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
