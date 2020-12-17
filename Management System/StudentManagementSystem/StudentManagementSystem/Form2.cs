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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //Connection para mo connect sya sa mysql gamit ang wampserver pero kinahanglang japun mag add kag reffences para mo connect sya ug mag import kag library sa babaw which is kanang mysql nga akong gebutang draa
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=StudentInfo");
        MySqlCommand command;
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
                    MessageBox.Show(" You are registered now !");
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Already use");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Student ID already use");

            }
            finally
            {
                closeConnection();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Mao na ang process sa pag insert sa imong ge input para ma save sya sa atong database
            string insertQuery = " INSERT INTO student(`StudentNo` ,`Surname` ,`Mname` ,`Lname` ,`Course` ,`Bloodtype` ,`Contact` ,`Address` ,`BMI` ,`Guardian` ,`GContact` ,`GAddress`) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            executeMyQuery(insertQuery);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //return to main menu ni sya didto sa Form1
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
