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
    public partial class Form7 : Form
    {

        MySqlConnection sc = new MySqlConnection("server=localhost;user id=root;database=StudentInfo");
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=StudentInfo");
        MySqlCommand cmd;
        DataTable tbl;
        MySqlCommand command;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            sc.Open();
            MySqlDataAdapter sd = new MySqlDataAdapter("select * from student", sc);
            DataSet ds = new DataSet();
            sd.Fill(ds, "student");
            dataGridView1.DataSource = ds.Tables[0];

            sc.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sc.Open();
            MySqlDataAdapter sd = new MySqlDataAdapter("select * from clinic", sc);
            DataSet ds = new DataSet();
            sd.Fill(ds, "clinic");
            dataGridView1.DataSource = ds.Tables[0];

            sc.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sc.Open();
            MySqlDataAdapter sd = new MySqlDataAdapter("select * from library", sc);
            DataSet ds = new DataSet();
            sd.Fill(ds, "library");
            dataGridView1.DataSource = ds.Tables[0];

            sc.Close();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("MM-dd-yyyy");
            label9.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
