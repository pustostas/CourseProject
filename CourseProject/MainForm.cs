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
        private SqlConnection sqlConnection = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courseProjectDataSet.cases' table. You can move, or remove it, as needed.
            this.casesTableAdapter.Fill(this.courseProjectDataSet.cases);

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseProject.Properties.Settings.CourseProjectConnectionString"].ConnectionString);
            sqlConnection.Open();
            if(sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Connection Open");
            }
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cases", sqlConnection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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
    }
}
