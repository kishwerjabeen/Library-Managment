using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_managment_system_byKJ
{
    public partial class Usser_home : Form
    {
        public Usser_home(string a)
        {
            InitializeComponent();
            label1.Text = "WELCOME " + a;
        }
        public static int i = 0;
        private void Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 12)
            {
                this.Dispose(false);
               // usser_home_main a = new usser_home_main();
              //  a.Show();
            }
        }

        private void Usser_home_Load(object sender, EventArgs e)
        {

        }
    }
}
