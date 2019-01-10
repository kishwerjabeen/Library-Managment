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
    public partial class Add_Books : Form
    {
        public Add_Books()
        {
            InitializeComponent();
        }
        DALS o = new DALS();
        private void Save_but_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "INSERT INTO Books(book_id,isbn,book_name,author_name,edition,no_of_copies,sub) VALUES(" + Book_id_tb.Text + "," + ISBN_NO_tb.Text + " ,'" + Book_name_tb.Text + "','" + author_tb.Text + "','" + edition_tb + "', ,'')";
            }
            catch(Exception x)
            {
                lblmes.Text = x.Message;
            }
       }
    }
}
