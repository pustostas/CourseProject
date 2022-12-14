using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace CourseProject
{
    public partial class EditCasesForm : Form
    {
        private SqlConnection sqlConnection = null;
        public EditCasesForm()
        {
            InitializeComponent();
            staffTableAdapter.Fill(courseProjectDataSet.staff);
            citizensTableAdapter.Fill(courseProjectDataSet.citizens);
            criminalsTableAdapter.Fill(courseProjectDataSet.criminals);
            articlesTableAdapter.Fill(courseProjectDataSet.articles);
        }

        private void EditCasesForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseProject.Properties.Settings.CourseProjectConnectionString"].ConnectionString);
            sqlConnection.Open();
            if (MainForm.isEdit)
            {
                
                SqlCommand selectCreationCommand = new SqlCommand($"SELECT creation FROM cases WHERE id = {MainForm.updateID}",sqlConnection);
                dateTimePicker1.Value = (DateTime)selectCreationCommand.ExecuteScalar();
                SqlCommand selectDescriptionCommand = new SqlCommand($"SELECT description FROM cases WHERE id = {MainForm.updateID}", sqlConnection);
                richTextBox1.Text = (string)selectDescriptionCommand.ExecuteScalar();
                SqlCommand selectCitizenCommand = new SqlCommand($"SELECT citizen_id FROM cases WHERE id = {MainForm.updateID}", sqlConnection);
                comboBox1.SelectedValue = (int)selectCitizenCommand.ExecuteScalar();
                SqlCommand selectStaffCommand = new SqlCommand($"SELECT staff_id FROM cases WHERE id = {MainForm.updateID}", sqlConnection);
                comboBox2.SelectedValue = (int)selectStaffCommand.ExecuteScalar();
                SqlCommand selectCriminalCommand = new SqlCommand($"SELECT criminals_id FROM cases WHERE id = {MainForm.updateID}", sqlConnection);
                comboBox3.SelectedValue = (int)selectCriminalCommand.ExecuteScalar();
                SqlCommand selectArticleCommand = new SqlCommand($"SELECT articles_id FROM cases WHERE id = {MainForm.updateID}", sqlConnection);
                comboBox4.SelectedValue = (int)selectArticleCommand.ExecuteScalar();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.isEdit)
            {
                SqlCommand insertCommand = new SqlCommand($"UPDATE Cases SET creation = @creation, description = @description, citizen_id = @citizen_id, staff_id = @staff_id, criminals_id = @criminals_id, articles_id = @articles_id WHERE id = {MainForm.updateID}", sqlConnection);
                insertCommand.Parameters.AddWithValue("creation", dateTimePicker1.Value);
                insertCommand.Parameters.AddWithValue("description", richTextBox1.Text);
                insertCommand.Parameters.AddWithValue("citizen_id", Convert.ToInt32(comboBox1.SelectedValue));
                insertCommand.Parameters.AddWithValue("staff_id", Convert.ToInt32(comboBox2.SelectedValue));
                insertCommand.Parameters.AddWithValue("criminals_id", Convert.ToInt32(comboBox3.SelectedValue));
                insertCommand.Parameters.AddWithValue("articles_id", Convert.ToInt32(comboBox4.SelectedValue));
                insertCommand.ExecuteNonQuery();
                Close();
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand($"INSERT INTO Cases (creation, description, citizen_id, staff_id, criminals_id, articles_id) VALUES(@creation, @description, @citizen_id, @staff_id, @criminals_id, @articles_id)", sqlConnection);
                insertCommand.Parameters.AddWithValue("creation", dateTimePicker1.Value);
                insertCommand.Parameters.AddWithValue("description", richTextBox1.Text);
                insertCommand.Parameters.AddWithValue("citizen_id", Convert.ToInt32(comboBox1.SelectedValue));
                insertCommand.Parameters.AddWithValue("staff_id", Convert.ToInt32(comboBox2.SelectedValue));
                insertCommand.Parameters.AddWithValue("criminals_id", Convert.ToInt32(comboBox3.SelectedValue));
                insertCommand.Parameters.AddWithValue("articles_id", Convert.ToInt32(comboBox4.SelectedValue));
                insertCommand.ExecuteNonQuery();
                Close(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
