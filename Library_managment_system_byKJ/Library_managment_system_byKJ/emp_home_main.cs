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
    public partial class emp_home_main : Form
    {
        public emp_home_main()
        {
            InitializeComponent();
        }

        private void emp_home_main_Load(object sender, EventArgs e)
        {

        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            s_add_books a = new s_add_books();
            //  a.MdiParent = this;
            a.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            //  admin_view_book v = new admin_view_book();
            s_search_books v = new s_search_books();
            v.Show();
        }

        private void updateBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            s_update_books u = new s_update_books();
            u.Show();
        }

        private void deleteBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            s_del_books d = new s_del_books ();
            d.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            s_add_studnet uadd = new s_add_studnet();
            uadd.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            s_view_studnets dis = new s_view_studnets();
            dis.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
           s_update_std_Info ups = new s_update_std_Info();
            ups.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            s_Std_del del = new s_Std_del();
            del.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
           s_book_issue bs = new s_book_issue();
            bs.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            s_return_book re = new s_return_book();
            re.Show();
        }

        private void bookStockSendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
           s_stock_book_reco_email stock = new s_stock_book_reco_email();
            stock.Show();
        }

        private void emp_home_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }
    }
}
