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
    public partial class Form4 : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=StudentInfo");
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=StudentInfo");
        MySqlCommand cmd;
        DataTable tbl;

        MySqlDataAdapter adp;
        MySqlCommandBuilder scb;
        public Form4()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("MM-dd-yyyy");
            label9.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form3.passingText;
            textBox2.Text = Form3.passingText1;
            textBox3.Text = Form3.passingText2;
            textBox4.Text = Form3.passingText3;
            textBox5.Text = Form3.passingText4;
            textBox8.Text = Form3.passingText5;
            textBox9.Text = Form3.passingText6;
            textBox10.Text = Form3.passingText7;
        }
        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM clinic WHERE CONCAT(`FName`) like ('" + textBox1.Text + "')";
            cmd = new MySqlCommand(query, con);
            adp = new MySqlDataAdapter(cmd);
            tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string insert = " INSERT INTO clinic(Date,Time,FName, MName, LName, BMI, Bloodtype, Address, Contact,Course,illness) VALUES('" + label4.Text + "','" + label9.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox7.Text + "')";
            adp = new MySqlDataAdapter(insert, con);
            adp.SelectCommand.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Save Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchData("");
            string valueToSearch = textBox1.Text.ToString();
            searchData(valueToSearch);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(adp);
                adp.Update(tbl);
                MessageBox.Show("Information Updated");
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }
    }
}
