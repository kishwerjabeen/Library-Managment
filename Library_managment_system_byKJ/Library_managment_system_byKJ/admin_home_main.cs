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
    public partial class admin_home_main : Form
    {
        public admin_home_main()
        {
            InitializeComponent();
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
          add_Books_admin a = new add_Books_admin();
         //  a.MdiParent = this;
          a.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  admin_view_book v = new admin_view_book();
            admin_search_books v = new admin_search_books();
            v.Show();
        }

        private void admin_home_main_Load(object sender, EventArgs e)
        {

        }

        private void updateBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_book u = new update_book();
            u.Show();
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_usser_by_admin uadd = new add_usser_by_admin();
            uadd.Show();
        }

        private void displayStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_student_info dis = new view_student_info();
            dis.Show();
        }

        private void deleteStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            usser_del_by_Admin del = new usser_del_by_Admin();
            del.Show();

        }

        private void brrowBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_book_issue bs = new admin_book_issue();
            bs.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_return_form re = new admin_return_form();
            re.Show();
        }

        private void bookStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            stock_book_record stock = new stock_book_record();
            stock.Show();
        }

        private void checkStockSendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_student_info ups = new update_student_info();
            ups.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emp_add_by_Admin es = new emp_add_by_Admin();
            es.Show();
        }

        private void searchDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emp_view_info v = new emp_view_info();
            v.Show();
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            emp_update_info u = new emp_update_info();
            u.Show();
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            emp_del d = new emp_del();
            d.Show();
        }

        private void admin_home_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
            
        }

        private void admin_home_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }

        private void deleteBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
               
         
           
        }

        private void validityExpiryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            report_book_remain_retain a = new report_book_remain_retain();
            a.Show();
        }
    }
}
