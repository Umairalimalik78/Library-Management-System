using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class Form2 : Form
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "sameer" && password == "soomro")
            {
                this.Hide();              
                new Form1().ShowDialog(); 
                this.Close();            
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
