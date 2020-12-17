using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class Form5 : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=StudentInfo");
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=StudentInfo");
        MySqlCommand cmd;
        DataTable tbl;
        MySqlCommand command;
        public Form5()
        {
            InitializeComponent();
        }
        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM library";
            cmd = new MySqlCommand(query, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
        }
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {

                connection.Open();
            }

        }

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {

                connection.Close();
            }

        }

        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, connection);



                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(" Time In ! ");
                    Form5 frm = new Form5();
                    frm.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Already use");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = " INSERT INTO library(Date,Time,Fname, Mname, Lname,Course,Purpose) VALUES('" + label6.Text + "','" + label9.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')";
            executeMyQuery(insertQuery);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form3.passingText;
            textBox2.Text = Form3.passingText1;
            textBox3.Text = Form3.passingText2;
            textBox4.Text = Form3.passingText7;
            searchData("");
            string valueToSearch = textBox1.Text.ToString();
            searchData(valueToSearch);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("MM-dd-yyyy");
            label9.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
