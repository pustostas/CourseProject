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

    public partial class MainForm : Form
    {
        public static bool isEdit;
        public static bool isStaff;
        public static int updateID;
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
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"last_name LIKE '%{textBox1.Text}%'";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"last_name LIKE '%{textBox1.Text}%'";
                    break;
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
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"passport_number LIKE '%{textBox2.Text}%'";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"passport_number LIKE '%{textBox2.Text}%'";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"passport_number LIKE '%{textBox2.Text}%'";
                    break;
                case 4:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"text LIKE '%{textBox2.Text}%'";
                    break;
            }
        }
    }
}
