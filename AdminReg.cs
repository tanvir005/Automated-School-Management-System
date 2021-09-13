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
namespace Stu_ManagementSystem
{
    public partial class AsminReg : Form
    {
        public AsminReg()
        {
            
            InitializeComponent();
            comboBox1.Items.Add("First Phone Number");
            comboBox1.Items.Add("Favorite Person");
            comboBox1.Items.Add("Favorite Digits");
            comboBox1.Items.Add("First Girl Friend or BoyFriend");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
            con1.Open();

            string str1 = "Select * from admin where inbuildsecurity='"+textBox7.Text+"'";
            MySqlCommand cmd1 = new MySqlCommand(str1, con1);
            MySqlDataReader dr1 = cmd1.ExecuteReader();

            if (textBox1.Text==""|| textBox3.Text == "" || textBox6.Text == "" || textBox7.Text == ""||comboBox1.Text=="")
            {
                MessageBox.Show("Required Informations are Mendayory!");
            }
            
            else if(dr1.Read())
            {
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                con.Open();
                string gender = string.Empty;
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked)
                {
                    gender = "Female";
                }
                try
                {
                    string str = " INSERT INTO   adminstrator (username,full_name,password,gender,email,mobile,Security_A,security_q) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + gender + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','"+comboBox1.Text+"'); ";

                    MySqlCommand cmd = new MySqlCommand(str, con);
                    cmd.ExecuteNonQuery();



                    string str2 = "select max(emp_id) from employe ;";

                    MySqlCommand cmd2 = new MySqlCommand(str2, con);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        MessageBox.Show("Dear Employee, Your Id is '" + dr2.GetInt32(0) + "'\n. Your are Registered Successfully .. ");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                    }
                    //this.Close();
                }
                catch (MySqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter Valid Inbuild Security Code");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
