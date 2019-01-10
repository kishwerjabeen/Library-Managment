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
    public partial class emp_home : Form
    {
        public emp_home(string a)
        {
            InitializeComponent();
            label1.Text = "WELCOME  " + a;
        }

        private void emp_home_Load(object sender, EventArgs e)
        {

        }
        public static int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 10)
            {
                this.Dispose(false);
                emp_home_main a = new emp_home_main();
                a.Show();
            }
        }
    }
}
