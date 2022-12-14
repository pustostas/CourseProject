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
    public partial class EditCriminalsForm : Form
    {
        private SqlConnection sqlConnection = null;
        public EditCriminalsForm()
        {
            InitializeComponent();
        }

        private void EditCriminalsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courseProjectDataSet.staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.courseProjectDataSet.staff);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseProject.Properties.Settings.CourseProjectConnectionString"].ConnectionString);
            sqlConnection.Open();
            if (MainForm.isEdit)
            {
                SqlCommand selectLastNameCommand = new SqlCommand($"SELECT last_name FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                textBox1.Text = (string)selectLastNameCommand.ExecuteScalar();
                SqlCommand selectFirstNameCommand = new SqlCommand($"SELECT first_name FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                textBox2.Text = (string)selectFirstNameCommand.ExecuteScalar();
                SqlCommand selectSurnameCommand = new SqlCommand($"SELECT surname FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                textBox3.Text = (string)selectSurnameCommand.ExecuteScalar();
                try
                {
                    SqlCommand selectDescriptionCommand = new SqlCommand($"SELECT description FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                    richTextBox1.Text = (string)selectDescriptionCommand.ExecuteScalar();
                }
                catch
                {

                }
                SqlCommand selectAdressCommand = new SqlCommand($"SELECT adress FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                textBox4.Text = (string)selectAdressCommand.ExecuteScalar();
                SqlCommand selectPassportCommand = new SqlCommand($"SELECT passport_number FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                textBox5.Text = (string)selectPassportCommand.ExecuteScalar();
                SqlCommand selectPhoneCommand = new SqlCommand($"SELECT phone_number FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                textBox6.Text = (string)selectPhoneCommand.ExecuteScalar();
                SqlCommand selectEmailCommand = new SqlCommand($"SELECT email FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                textBox7.Text = (string)selectEmailCommand.ExecuteScalar();
                SqlCommand selectBirthCommand = new SqlCommand($"SELECT birth FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                dateTimePicker1.Value = (DateTime)selectBirthCommand.ExecuteScalar();
                SqlCommand selectSearchCommand = new SqlCommand($"SELECT in_search FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                checkBox1.Checked = (bool)selectSearchCommand.ExecuteScalar();
                try
                {
                    SqlCommand selectStaffCommand = new SqlCommand($"SELECT staff_id FROM criminals WHERE id = {MainForm.updateID}", sqlConnection);
                    comboBox1.SelectedValue = (int)selectStaffCommand.ExecuteScalar();
                }
                catch
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.isEdit)
            {
                SqlCommand insertCommand = new SqlCommand($"UPDATE Criminals SET last_name = @last_name, first_name = @first_name, surname = @surname, description = @description, adress = @adress, passport_number = @passport_number, phone_number = @phone_number, email = @email, birth = @birth, in_search = @in_search, staff_id = @staff_id WHERE id = {MainForm.updateID}", sqlConnection);
                insertCommand.Parameters.AddWithValue("last_name", textBox1.Text);
                insertCommand.Parameters.AddWithValue("first_name", textBox2.Text);
                insertCommand.Parameters.AddWithValue("surname", textBox3.Text);
                insertCommand.Parameters.AddWithValue("description", richTextBox1.Text);
                insertCommand.Parameters.AddWithValue("adress", textBox4.Text);
                insertCommand.Parameters.AddWithValue("passport_number", textBox5.Text);
                insertCommand.Parameters.AddWithValue("phone_number", textBox6.Text);
                insertCommand.Parameters.AddWithValue("email", textBox7.Text);
                insertCommand.Parameters.AddWithValue("birth", dateTimePicker1.Value);
                insertCommand.Parameters.AddWithValue("in_search", checkBox1.Checked);
                insertCommand.Parameters.AddWithValue("staff_id", Convert.ToInt32(comboBox1.SelectedValue));
                insertCommand.ExecuteNonQuery();
                Close();
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand($"INSERT INTO Criminals (last_name, first_name, surname, description, adress, passport_number, phone_number, email, birth, in_search, staff_id) VALUES(@last_name, @first_name, @surname, @description, @adress, @passport_number, @phone_number, @email, @birth, @in_search, @staff_id)", sqlConnection);
                insertCommand.Parameters.AddWithValue("last_name", textBox1.Text);
                insertCommand.Parameters.AddWithValue("first_name", textBox2.Text);
                insertCommand.Parameters.AddWithValue("surname", textBox3.Text);
                insertCommand.Parameters.AddWithValue("description", richTextBox1.Text);
                insertCommand.Parameters.AddWithValue("adress", textBox4.Text);
                insertCommand.Parameters.AddWithValue("passport_number", textBox5.Text);
                insertCommand.Parameters.AddWithValue("phone_number", textBox6.Text);
                insertCommand.Parameters.AddWithValue("email", textBox7.Text);
                insertCommand.Parameters.AddWithValue("birth", dateTimePicker1.Value);
                insertCommand.Parameters.AddWithValue("in_search", checkBox1.Checked);
                insertCommand.Parameters.AddWithValue("staff_id", Convert.ToInt32(comboBox1.SelectedValue));
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
