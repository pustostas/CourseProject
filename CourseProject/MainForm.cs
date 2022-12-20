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
using ClosedXML;
using DocumentFormat.OpenXml;
using ExcelNumberFormat;
using System.Xml;
using ClosedXML.Excel;

namespace CourseProject
{

    public partial class MainForm : Form
    {
        public static bool isEdit;
        public static bool isStaff;
        public static int updateID;
        public static int docID;
        private SqlConnection sqlConnection = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseProject.Properties.Settings.CourseProjectConnectionString"].ConnectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Connection Open");
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                var dataSource = new List<SortList>();
                dataSource.Add(new SortList() { Name = "Немає", Value = "0" });
                dataSource.Add(new SortList() { Name = "Дата створення", Value = "1" });
                dataSource.Add(new SortList() { Name = "Громадянин", Value = "2" });
                this.comboBox2.DataSource = dataSource;
                this.comboBox2.DisplayMember = "Name";
                this.comboBox2.ValueMember = "Value";
                this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                label2.Text = "Прізвище";
                label3.Text = "Опис";
                checkBox2.Text = "Без злочинця";
                checkBox3.Show();
                checkBox2.Show();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                var dataSource = new List<SortList>();
                dataSource.Add(new SortList() { Name = "Немає", Value = "0" });
                dataSource.Add(new SortList() { Name = "Прізвище", Value = "1" });
                dataSource.Add(new SortList() { Name = "Кількість злочинів", Value = "2" });
                this.comboBox2.DataSource = dataSource;
                this.comboBox2.DisplayMember = "Name";
                this.comboBox2.ValueMember = "Value";
                this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                label2.Text = "Прізвище";
                label3.Text = "Номер паспорту";
                checkBox2.Text = "Більше трьох справ";
                checkBox3.Hide();
                checkBox2.Show();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                var dataSource = new List<SortList>();
                dataSource.Add(new SortList() { Name = "Немає", Value = "0" });
                dataSource.Add(new SortList() { Name = "Прізвище", Value = "1" });
                dataSource.Add(new SortList() { Name = "Кількість заяв", Value = "2" });
                this.comboBox2.DataSource = dataSource;
                this.comboBox2.DisplayMember = "Name";
                this.comboBox2.ValueMember = "Value";
                this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                label2.Text = "Прізвище";
                label3.Text = "Номер паспорту";
                checkBox2.Text = "Більше трьох справ";
                checkBox3.Hide();
                checkBox2.Show();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Staff", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                var dataSource = new List<SortList>();
                dataSource.Add(new SortList() { Name = "Немає", Value = "0" });
                dataSource.Add(new SortList() { Name = "Прізвище", Value = "1" });
                dataSource.Add(new SortList() { Name = "Кількість заяв", Value = "2" });
                this.comboBox2.DataSource = dataSource;
                this.comboBox2.DisplayMember = "Name";
                this.comboBox2.ValueMember = "Value";
                this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                label2.Text = "Прізвище";
                label3.Text = "Номер паспорту";
                checkBox2.Text = "Більше трьох справ";
                checkBox3.Hide();
                checkBox2.Show();

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Articles", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                var dataSource = new List<SortList>();
                dataSource.Add(new SortList() { Name = "Немає", Value = "0" });
                dataSource.Add(new SortList() { Name = "Назва", Value = "1" });
                dataSource.Add(new SortList() { Name = "Номер", Value = "2" });
                this.comboBox2.DataSource = dataSource;
                this.comboBox2.DisplayMember = "Name";
                this.comboBox2.ValueMember = "Value";
                this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                label2.Text = "Назва";
                label3.Text = "Текст";
                checkBox3.Hide();
                checkBox2.Hide();

            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases ORDER BY Creation", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases ORDER BY citizen_name", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM criminals", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals ORDER BY last_name", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals ORDER BY number_of_cases", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM citizens", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens ORDER BY last_name", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens ORDER BY number_of_cases", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff ORDER BY last_name", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff ORDER BY number_of_cases", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles ORDER BY name", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles ORDER BY id", sqlConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                int deletion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                SqlCommand delete = new SqlCommand($"DELETE FROM Cases WHERE id = {deletion}", sqlConnection);
                delete.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                int deletion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                SqlCommand delete = new SqlCommand($"DELETE FROM Criminals WHERE id = {deletion}", sqlConnection);
                delete.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                int deletion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                SqlCommand delete = new SqlCommand($"DELETE FROM Citizens WHERE id = {deletion}", sqlConnection);
                delete.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                int deletion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                SqlCommand delete = new SqlCommand($"DELETE FROM Staff WHERE id = {deletion}", sqlConnection);
                delete.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Staff", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                int deletion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                SqlCommand delete = new SqlCommand($"DELETE FROM Articles WHERE id = {deletion}", sqlConnection);
                delete.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Articles", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                isEdit = true;
                updateID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var edit = new EditCasesForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 0;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                isEdit = true;
                updateID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var edit = new EditCriminalsForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 1;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                isStaff = false;
                isEdit = true;
                updateID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var edit = new EditCitizensForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 2;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                isStaff = true;
                isEdit = true;
                updateID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var edit = new EditCitizensForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Staff", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 3;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                isEdit = true;
                updateID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var edit = new EditArticlesForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 4;
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                isEdit = false;
                var edit = new EditCasesForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 0;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                isEdit = false;
                var edit = new EditCriminalsForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 1;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                isStaff = false;
                isEdit = false;
                var edit = new EditCitizensForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 2;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                isStaff = true;
                isEdit = false;
                var edit = new EditCitizensForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Staff", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 3;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                isEdit = false;
                updateID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var edit = new EditArticlesForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 4;
                dataGridView1.DataSource = ds.Tables[0];
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases ORDER BY Creation", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases ORDER BY Creation DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }

                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases ORDER BY Citizen_name", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases ORDER BY Citizen_name DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals ORDER BY Last_name", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals ORDER BY Last_name DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }

                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals ORDER BY number_of_cases", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals ORDER BY number_of_cases DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens ORDER BY Last_name", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens ORDER BY Last_name DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }

                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens ORDER BY number_of_cases", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens ORDER BY number_of_cases DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            
                }
            else if (comboBox1.SelectedIndex == 3)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff ORDER BY Last_name", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff ORDER BY Last_name DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }

                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff ORDER BY number_of_cases", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM staff ORDER BY number_of_cases DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles ORDER BY name", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles ORDER BY name DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }

                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    if (checkBox1.Checked == false)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles ORDER BY id", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (checkBox1.Checked == true)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM articles ORDER BY id DESC", sqlConnection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }

            }
        }
        public class SortList
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex) {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"citizen_name LIKE '%{textBox1.Text}%'";
                    break;
                case 1:
                case 2:
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"last_name LIKE '%{textBox1.Text}%'";
                    break;
                case 4:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"name LIKE '%{textBox1.Text}%'";
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"description LIKE '%{textBox2.Text}%'";
                    break;
                case 1:
                case 2:    
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"passport_number LIKE '%{textBox2.Text}%'";
                    break;
                case 4:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"text LIKE '%{textBox2.Text}%'";
                    break;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (checkBox3.Checked)
                    {
                        if (checkBox2.Checked)
                        {
                            DateTime dt1 = DateTime.Now;
                            dt1 = dt1.AddYears(-1);
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"criminals_id IS NULL AND creation >= '{dt1}'";
                        }
                        else
                        {
                            DateTime dt1 = DateTime.Now;
                            dt1 = dt1.AddYears(-1);
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"creation >= '{dt1}'";
                        }
                    }
                    else
                    {
                        if (checkBox2.Checked)
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"criminals_id IS NULL";
                        }
                        else
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Empty;
                        }
                    }
                    break;
                     case 1:
                     case 2:
                     case 3:
                    if (checkBox2.Checked)
                    {
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"number_of_cases >= 3";
                    }
                    else
                    {
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Empty;
                    }
                         break;
            }
        }

  

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

             switch (comboBox1.SelectedIndex)
             {
                 case 0:
                    if (checkBox2.Checked)
                    {
                        if (checkBox3.Checked)
                        {
                            DateTime dt1 = DateTime.Now;
                            dt1 = dt1.AddYears(-1);
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"criminals_id IS NULL AND creation >= '{dt1}'";
                        }
                        else
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"criminals_id IS NULL";
                        }
                    }
                    else
                    {
                        if (checkBox3.Checked)
                        {
                            DateTime dt1 = DateTime.Now;
                            dt1 = dt1.AddYears(-1);
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"creation >= '{dt1}'";
                        }
                        else
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Empty;
                        }
                    }
                        break;
             } 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    comboBox1.SelectedIndex = 0;
                    break;
                case 1:
                    SqlDataAdapter cases = new  SqlDataAdapter("SELECT cases.id,cases.description,staff.last_name as поліцейський,citizens.last_name as громадянин,criminals.last_name as злочинець FROM CASES,Staff,citizens, criminals WHERE cases.citizen_id = citizens.id AND cases.criminals_id = criminals.id AND cases.staff_id = staff.id", sqlConnection);
                    DataSet casesDs = new DataSet();
                    cases.Fill(casesDs);
                    dataGridView1.DataSource = casesDs.Tables[0];
                    break;
                case 2:
                    SqlDataAdapter articles = new SqlDataAdapter("SELECT articles.name,COUNT(cases.id) as Заяв FROM CASES,articles WHERE cases.articles_id = articles.id GROUP BY articles.name", sqlConnection);
                    DataSet articlesDs = new DataSet();
                    articles.Fill(articlesDs);
                    dataGridView1.DataSource = articlesDs.Tables[0];
                    break;
                case 3:
                    SqlDataAdapter account = new SqlDataAdapter("SELECT staff.last_name as поліцейський ,COUNT(criminals.id) as Злочинців FROM staff,criminals WHERE criminals.staff_id = staff_id GROUP BY staff.last_name", sqlConnection);
                    DataSet accountDs = new DataSet();
                    account.Fill(accountDs);
                    dataGridView1.DataSource = accountDs.Tables[0];
                    break;
                case 4:
                    SqlDataAdapter mails = new SqlDataAdapter("SELECT staff.last_name as поліцейський,staff.email, criminals.last_name as злочинець, criminals.email FROM staff,criminals WHERE criminals.staff_id = staff.id", sqlConnection);
                    DataSet mailsDs = new DataSet();
                    mails.Fill(mailsDs);
                    dataGridView1.DataSource = mailsDs.Tables[0];
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    docID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    SqlCommand selectLAST_NAMECommand = new SqlCommand($"SELECT last_name FROM citizens WHERE id = (SELECT citizen_id FROM cases WHERE id = {MainForm.docID})", sqlConnection);
                    SqlCommand selectFIRST_NAMECommand = new SqlCommand($"SELECT first_name FROM citizens WHERE id = (SELECT citizen_id FROM cases WHERE id = {MainForm.docID})", sqlConnection);
                    SqlCommand selectSURNAMECommand = new SqlCommand($"SELECT surname FROM citizens WHERE id = (SELECT citizen_id FROM cases WHERE id = {MainForm.docID})", sqlConnection);
                    SqlCommand selectADRESSCommand = new SqlCommand($"SELECT adress FROM citizens WHERE id = (SELECT citizen_id FROM cases WHERE id = {MainForm.docID})", sqlConnection);
                    SqlCommand selectEMAILCommand = new SqlCommand($"SELECT email FROM citizens WHERE id = (SELECT citizen_id FROM cases WHERE id = {MainForm.docID})", sqlConnection);
                    SqlCommand selectPHONE_NUMBERCommand = new SqlCommand($"SELECT phone_number FROM citizens WHERE id = (SELECT citizen_id FROM cases WHERE id = {MainForm.docID})", sqlConnection);
                    SqlCommand selectCreationCommand = new SqlCommand($"SELECT creation FROM cases WHERE id = {MainForm.docID}", sqlConnection);
                    SqlCommand selectArticleCommand = new SqlCommand($"SELECT name FROM articles WHERE id = (SELECT articles_id FROM cases WHERE id = {MainForm.docID})", sqlConnection);
                    var creation = (DateTime)selectCreationCommand.ExecuteScalar();


                    var helper = new WordHelper("caseDoc.docx");

                    var items = new Dictionary<string, string>
                    {
                        { "<LAST_NAME>", (string)selectLAST_NAMECommand.ExecuteScalar()},
                        { "<FIRST_NAME>", (string)selectFIRST_NAMECommand.ExecuteScalar()},
                        { "<SURNAME>", (string)selectSURNAMECommand.ExecuteScalar()},
                        { "<ADRESS>", (string)selectADRESSCommand.ExecuteScalar()},
                        { "<EMAIL>", (string)selectEMAILCommand.ExecuteScalar()},
                        { "<PHONE_NUMBER>", (string)selectPHONE_NUMBERCommand.ExecuteScalar()},
                        { "<CREATION>", creation.ToLongDateString()},
                        { "<ARTICLE_NAME>", (string)selectArticleCommand.ExecuteScalar()}
                    };
                    helper.Process(items);
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable appData = (DataTable)dataGridView1.DataSource;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using(XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(appData.Copy());
                            workbook.SaveAs(sfd.FileName);

                        }
                        MessageBox.Show("Ви зберегли дані в Excel файл.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
