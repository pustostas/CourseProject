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
using System.Configuration;

namespace CourseProject
{
    public partial class EditArticlesForm : Form
    {
        private SqlConnection sqlConnection = null;

        public EditArticlesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.isEdit)
            {
                SqlCommand insertCommand = new SqlCommand($"UPDATE articles SET name = @name, text = @text WHERE id = {MainForm.updateID}", sqlConnection);
                insertCommand.Parameters.AddWithValue("name", textBox1.Text);
                insertCommand.Parameters.AddWithValue("text", richTextBox1.Text);
                insertCommand.ExecuteNonQuery();
                Close();
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand($"INSERT INTO articles (name, text) VALUES(@name, @text)", sqlConnection);
                insertCommand.Parameters.AddWithValue("name", textBox1.Text);
                insertCommand.Parameters.AddWithValue("text", richTextBox1.Text);
                insertCommand.ExecuteNonQuery();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditArticlesForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseProject.Properties.Settings.CourseProjectConnectionString"].ConnectionString);
            sqlConnection.Open();
            if (MainForm.isEdit)
            {
                SqlCommand selectNameCommand = new SqlCommand($"SELECT name FROM articles WHERE id = {MainForm.updateID}", sqlConnection);
                textBox1.Text = (string)selectNameCommand.ExecuteScalar();
                SqlCommand selectDescriptionCommand = new SqlCommand($"SELECT text FROM articles WHERE id = {MainForm.updateID}", sqlConnection);
                richTextBox1.Text = (string)selectDescriptionCommand.ExecuteScalar();

            }
        }
    }
}
