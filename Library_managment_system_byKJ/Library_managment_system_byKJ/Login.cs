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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }
                DALS o = new DALS();
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (Usertb.Text != "" && passTb.Text != "" && comboBox1.SelectedIndex != -1)
            {
               string qry = "";
               SqlCommand cmd;
                if (comboBox1.Text == "Employees")
                {
                    qry = "SELECT emp_name,e_Password FROM employ_info_new WHERE emp_name='" + Usertb.Text + "' AND e_password = '" + passTb.Text + "'";
                    cmd = new SqlCommand(qry, o.con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        this.Dispose(false);
                        emp_home a = new emp_home(Usertb.Text);
                        a.Show();
                    }
                    else
                    {
                        lblmes.ForeColor = Color.Red;
                        lblmes.Text = "Invalid Usser Name & Password ";
                        dr.Close();
                    }
                }
                else if (comboBox1.Text == "Librarian")
                {
                    qry = "SELECT admin_name,Password FROM admin WHERE admin_name='" + Usertb.Text + "' AND password = '" + passTb.Text + "'";
                    cmd = new SqlCommand(qry, o.con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        this.Dispose(false);
                        admin_home a = new admin_home(Usertb.Text);
                        a.Show();
                    }
                    else
                    {
                        lblmes.ForeColor = Color.Red;
                        lblmes.Text = "Invalid Usser Name & Password ";
                        dr.Close();
                    }
                }
            }
            else
            {
                lblmes.ForeColor = Color.Red;
                lblmes.Text = "Please Fill all the Data";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
