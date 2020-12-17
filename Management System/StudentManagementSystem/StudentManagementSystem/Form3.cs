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
    public partial class Form3 : Form
    {
        public static string passingText;
        public static string passingText1;
        public static string passingText2;
        public static string passingText3;
        public static string passingText4;
        public static string passingText5;
        public static string passingText6;
        public static string passingText7;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.passingText;
            bool temp = false;
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=StudentInfo");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from student where StudentNo='" + label1.Text.Trim() + "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label2.Text = dr.GetString(1);
                label3.Text = dr.GetString(2);
                label4.Text = dr.GetString(3);
                label22.Text = dr.GetString(4);
                label23.Text = dr.GetString(5);
                label24.Text = dr.GetString(6);
                label17.Text = dr.GetString(7);
                label6.Text = dr.GetString(8);
                label13.Text = dr.GetString(9);
                label5.Text = dr.GetString(10);
                label18.Text = dr.GetString(11);
                temp = true;
            }
            if (temp == false)
                MessageBox.Show("not found");
            con.Close();
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            passingText = label2.Text;
            passingText1 = label3.Text;
            passingText2 = label4.Text;
            passingText3 = label17.Text;
            passingText4 = label6.Text;
            passingText5 = label22.Text;
            passingText6 = label23.Text;
            passingText7 = label24.Text;

            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            passingText = label2.Text;
            passingText1 = label3.Text;
            passingText2 = label4.Text;
            passingText3 = label5.Text;
            passingText4 = label6.Text;
            passingText7 = label23.Text;
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
