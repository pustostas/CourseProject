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
            if(sqlConnection.State == ConnectionState.Open)
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
            }else if(comboBox1.SelectedIndex == 1)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Staff", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Articles", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
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
            }else if (comboBox1.SelectedIndex == 1)
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
                isEdit = true;
                updateID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var edit = new EditCitizensForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 1;
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
            }else if(comboBox1.SelectedIndex == 1)
            {
                isEdit = false;
                var edit = new EditCriminalsForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Criminals", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 1;
                dataGridView1.DataSource = ds.Tables[0];
            }else if(comboBox1.SelectedIndex == 2)
            {
                isEdit = false;
                var edit = new EditCitizensForm();
                edit.ShowDialog();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Citizens", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                comboBox1.SelectedIndex = 1;
                dataGridView1.DataSource = ds.Tables[0];
            }
            
        }
    }
}
