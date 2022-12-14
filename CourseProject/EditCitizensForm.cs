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
    public partial class EditCitizensForm : Form
    {
        private SqlConnection sqlConnection = null;
        public EditCitizensForm()
        {
            InitializeComponent();
        }

        private void EditCitizensForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseProject.Properties.Settings.CourseProjectConnectionString"].ConnectionString);
            sqlConnection.Open();
            if (MainForm.isEdit)
            {
                SqlCommand selectLastNameCommand = new SqlCommand($"SELECT last_name FROM citizens WHERE id = {MainForm.updateID}", sqlConnection);
                textBox1.Text = (string)selectLastNameCommand.ExecuteScalar();
                SqlCommand selectFirstNameCommand = new SqlCommand($"SELECT first_name FROM citizens WHERE id = {MainForm.updateID}", sqlConnection);
                textBox2.Text = (string)selectFirstNameCommand.ExecuteScalar();
                SqlCommand selectSurnameCommand = new SqlCommand($"SELECT surname FROM citizens WHERE id = {MainForm.updateID}", sqlConnection);
                textBox3.Text = (string)selectSurnameCommand.ExecuteScalar();
                SqlCommand selectAdressCommand = new SqlCommand($"SELECT adress FROM citizens WHERE id = {MainForm.updateID}", sqlConnection);
                textBox4.Text = (string)selectAdressCommand.ExecuteScalar();
                SqlCommand selectPassportCommand = new SqlCommand($"SELECT passport_number FROM citizens WHERE id = {MainForm.updateID}", sqlConnection);
                textBox5.Text = (string)selectPassportCommand.ExecuteScalar();
                SqlCommand selectPhoneCommand = new SqlCommand($"SELECT phone_number FROM citizens WHERE id = {MainForm.updateID}", sqlConnection);
                textBox6.Text = (string)selectPhoneCommand.ExecuteScalar();
                SqlCommand selectEmailCommand = new SqlCommand($"SELECT email FROM citizens WHERE id = {MainForm.updateID}", sqlConnection);
                textBox7.Text = (string)selectEmailCommand.ExecuteScalar();
                SqlCommand selectBirthCommand = new SqlCommand($"SELECT birth FROM citizens WHERE id = {MainForm.updateID}", sqlConnection);
                dateTimePicker1.Value = (DateTime)selectBirthCommand.ExecuteScalar();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.isEdit)
            {
                SqlCommand insertCommand = new SqlCommand($"UPDATE Citizens SET last_name = @last_name, first_name = @first_name, surname = @surname, adress = @adress, passport_number = @passport_number, phone_number = @phone_number, email = @email, birth = @birth  WHERE id = {MainForm.updateID}", sqlConnection);
                insertCommand.Parameters.AddWithValue("last_name", textBox1.Text);
                insertCommand.Parameters.AddWithValue("first_name", textBox2.Text);
                insertCommand.Parameters.AddWithValue("surname", textBox3.Text);
                insertCommand.Parameters.AddWithValue("adress", textBox4.Text);
                insertCommand.Parameters.AddWithValue("passport_number", textBox5.Text);
                insertCommand.Parameters.AddWithValue("phone_number", textBox6.Text);
                insertCommand.Parameters.AddWithValue("email", textBox7.Text);
                insertCommand.Parameters.AddWithValue("birth", dateTimePicker1.Value);
                insertCommand.ExecuteNonQuery();
                Close();
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand($"INSERT INTO citizens (last_name, first_name, surname, adress, passport_number, phone_number, email, birth) VALUES(@last_name, @first_name, @surname, @adress, @passport_number, @phone_number, @email, @birth)", sqlConnection);
                insertCommand.Parameters.AddWithValue("last_name", textBox1.Text);
                insertCommand.Parameters.AddWithValue("first_name", textBox2.Text);
                insertCommand.Parameters.AddWithValue("surname", textBox3.Text);
                insertCommand.Parameters.AddWithValue("adress", textBox4.Text);
                insertCommand.Parameters.AddWithValue("passport_number", textBox5.Text);
                insertCommand.Parameters.AddWithValue("phone_number", textBox6.Text);
                insertCommand.Parameters.AddWithValue("email", textBox7.Text);
                insertCommand.Parameters.AddWithValue("birth", dateTimePicker1.Value);
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
