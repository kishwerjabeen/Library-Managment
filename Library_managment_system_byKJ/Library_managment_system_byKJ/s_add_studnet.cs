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
    public partial class s_add_studnet : Form
    {
        public s_add_studnet()
        {
            InitializeComponent();
        }
        SqlConnection con;
        string str;
        private void s_add_studnet_Load(object sender, EventArgs e)
        {
            str = @"Data Source=.;Initial Catalog=library_Managment_system_by_kj;Integrated Security=True";
            con = new SqlConnection(str);
            con.Open();
            Library_id_auto.Text = getroll();
        }
        string getroll()
        {
            string qry = "SELECT COUNT (*) FROM Student_info_new";
            SqlCommand cmd = new SqlCommand(qry, con);
            int a = 101 + (Int32)cmd.ExecuteScalar();
            string reg = "A" + a.ToString();
            //  Library_id_auto.Text = reg;
            return (reg);
        }
        public void clearall()
        {
            Library_id_auto.Text = getroll();
            std_name_tb.Clear();
            std_rollTb.Clear();
            comboBox1.SelectedIndex = -1;
            deprtr_tb.Clear();
            sem_tb.Clear();
            passtb.Clear();
            tb_cell_no.Clear();
            tb_email.Clear();
            con_passtb.Clear();
            lbl_show.Text = "";

            pictureBox3.Image = Image.FromFile(@"E:\proj\library_managment_system_byKJ\Library_managment_system_byKJ\images\if_holiday-no-camera_3211425.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearall();
        }
        string img_file = null;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "JPEG|*.jpg|PNG|*.png";
            if (o.ShowDialog() != DialogResult.Cancel)
            {
                img_file = o.FileName;
                pictureBox3.Image = Image.FromFile(o.FileName);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (std_name_tb.Text != "" && std_rollTb.Text != "" && comboBox1.SelectedIndex != -1 && deprtr_tb.Text != "" && sem_tb.Text != "" && tb_cell_no.Text != "" && tb_email.Text != "" && passtb.Text != "")
            {
                if (img_file != null)
                {
                    if (passtb.Text == con_passtb.Text)
                    {
                        FileStream fs1 = new FileStream(img_file, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] image = new byte[fs1.Length];
                        fs1.Read(image, 0, Convert.ToInt32(fs1.Length));
                        fs1.Close();

                        SqlCommand cmd = new SqlCommand("INSERT INTO Student_info_new(libry_id, std_name, std_rollno, gender, std_department, std_sem, CellNo, email, s_password, std_images)VALUES('" + Library_id_auto.Text + "','" + std_name_tb.Text + "','" + std_rollTb.Text + "','" + comboBox1.Text + "','" + deprtr_tb.Text + "','" + sem_tb.Text + "','" + tb_cell_no.Text + "','" + tb_email.Text + "','" + passtb.Text + "',@pic)", con);
                        SqlParameter prm = new SqlParameter("@pic", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                        cmd.Parameters.Add(prm);
                        cmd.ExecuteNonQuery();
                        //  con.Close();
                        lbl_show.ForeColor = Color.Red;
                        lbl_show.Text = "Data Stored";
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
                    lbl_show.Text = "Please Upload Image";
                }
            }
            else
            {
                lbl_show.ForeColor = Color.Red;
                lbl_show.Text = "Please Fill All the Feilds ";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
           emp_home_main a = new emp_home_main();
            a.Show();
        }
    }
}
