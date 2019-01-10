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
    public partial class admin_home : Form
    {
        public admin_home(string a)
        {
            InitializeComponent();
            label1.Text = "WELCOME  " + a;
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Add_books a = new Add_books();
            //a.MdiParent = this;
            //a.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        public static int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 12)
            {
                this.Dispose(false);
                admin_home_main a = new admin_home_main();
                a.Show();
            }
        }

        private void admin_home_Load(object sender, EventArgs e)
        {

        }
    }
}
