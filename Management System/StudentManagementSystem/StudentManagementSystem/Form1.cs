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
    public partial class Form1 : Form
    {
        //Para pag pasa sa string
        public static string passingText;
        String cs = @"server=localhost;user id=root;database=StudentInfo";
        public Form1()
        {
            InitializeComponent();
        }


        //Para ma open ang form2
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //para ma send ang imong ge type sa pikas while nag query kung mag match imong getype mo proceed sya 
            // sa Form 3 which is kadtong Information management nimu.
            passingText = textBox1.Text;
            try
            {
                MySqlConnection connection = default(MySqlConnection);
                connection = new MySqlConnection(cs);

                MySqlCommand cmd = default(MySqlCommand);

                cmd = new MySqlCommand("SELECT StudentNo FROM student WHERE StudentNo=@StudentNo", connection);
                MySqlParameter idno = new MySqlParameter("@StudentNo", MySqlDbType.VarChar);
                idno.Value = textBox1.Text;
                cmd.Parameters.Add(idno);
                cmd.Connection.Open();


                MySqlDataReader myreader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (myreader.Read() == true)
                {

                    this.Hide();
                    Form3 frm = new Form3();
                    frm.Show();
                    this.Hide();
                }




                else
                {
                    MessageBox.Show("Not yet register");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 frm = new Form6();
            frm.Show();
            this.Hide();
        }
    }
}
