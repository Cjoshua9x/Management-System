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
    public partial class Form6 : Form
    {
        String cs = @"server=localhost;user id=root;database=StudentInfo";
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = default(MySqlConnection);
                connection = new MySqlConnection(cs);

                MySqlCommand cmd = default(MySqlCommand);

                cmd = new MySqlCommand("SELECT Admin FROM admin WHERE Admin=@Admin", connection);
                cmd = new MySqlCommand("SELECT Pass FROM admin WHERE Pass=@Pass", connection);
                MySqlParameter admin = new MySqlParameter("@Admin", MySqlDbType.VarChar);
                MySqlParameter pass = new MySqlParameter("@Pass", MySqlDbType.VarChar);
                admin.Value = textBox1.Text;
                pass.Value = textBox2.Text;
                cmd.Parameters.Add(admin);
                cmd.Parameters.Add(pass);
                cmd.Connection.Open();


                MySqlDataReader myreader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (myreader.Read() == true)
                {

                    this.Hide();
                    Form7 frm = new Form7();
                    frm.Show();
                    this.Hide();
                }




                else
                {
                    MessageBox.Show("Incorrect User or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        
    
    }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
