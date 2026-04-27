using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            search_member.Focus();
            membersTable.Clear();
            LoadData();
        }

        DataTable membersTable = new DataTable();

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt32(selectedRow.Cells["MID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string sql = "DELETE FROM Members WHERE MID = @id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (membersTable != null)
                    {
                        DataRow[] rows = membersTable.Select($"MID = {id}");
                        if (rows.Length > 0)
                            membersTable.Rows.Remove(rows[0]);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = search_member.Text.Replace("'", "''").ToLower();

            membersTable.DefaultView.RowFilter =
                $"MemberName LIKE '%{filter}%' OR PhoneNo LIKE '%{filter}%'";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        { 
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(namebox.Text) ||
                string.IsNullOrWhiteSpace(phonebox.Text) ||
                string.IsNullOrWhiteSpace(bookbox.Text) ||
                string.IsNullOrWhiteSpace(authorbox.Text) ||
                string.IsNullOrWhiteSpace(feebox.Text) ||
                string.IsNullOrWhiteSpace(statusbox.Text))
            {
                MessageBox.Show("Please fill all fields before adding.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imageBytes = null;
            if (pictureBox4.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox4.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
            }


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                const string sql = @"INSERT INTO Members
                (MemberName, PhoneNo, BookName, Author, IssueDate, ReturnDate, Fees, Status, Photo)
                OUTPUT INSERTED.MID
                VALUES (@name, @phone, @book, @auth, @issue, @ret, @fees, @status, @photo)";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", namebox.Text);
                    cmd.Parameters.AddWithValue("@phone", phonebox.Text);
                    cmd.Parameters.AddWithValue("@book", bookbox.Text);
                    cmd.Parameters.AddWithValue("@auth", authorbox.Text);
                    cmd.Parameters.AddWithValue("@issue", issuedatepicker.Value);
                    cmd.Parameters.AddWithValue("@ret", returndatepicker.Value);
                    cmd.Parameters.AddWithValue("@fees", feebox.Text);
                    cmd.Parameters.AddWithValue("@status", statusbox.Text);
                    cmd.Parameters.AddWithValue("@photo", imageBytes ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            reset_btn_Click(sender, e);
        }

        private void LoadData()
        {
            membersTable.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Members";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(membersTable);
                dataGridView1.DataSource = membersTable;
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridView1.ColumnHeadersDefaultCellStyle.BackColor;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                if (row.Cells["Photo"].Value != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])row.Cells["Photo"].Value;
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        pictureBox2.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
        }


        private void reset_btn_Click(object sender, EventArgs e)
        {
            namebox.Text = "";
            phonebox.Text = "";
            bookbox.Text = "";
            authorbox.Text = "";
            feebox.Text = "";
            statusbox.SelectedIndex = -1;
            issuedatepicker.Value = DateTime.Now;
            returndatepicker.Value = DateTime.Now;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        byte[] selectedImageBytes = null;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(dlg.FileName);

                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    selectedImageBytes = ms.ToArray();
                }
            }
        }
    }
}
