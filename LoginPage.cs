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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            comboBox1.Items.Add("Administrator");
            comboBox1.Items.Add("Office Assistent");
            comboBox1.Items.Add("Course Teacher");
            comboBox1.Items.Add("Accountent");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please choose an option");
            }
            //LOIN FOR ADMIN
            else if (comboBox1.SelectedItem.Equals("Administrator"))
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show(" Please Enter Your User Id and Password.");
                }
                else 
                {
                    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                    con.Open();

                    string str = "Select admin_id from adminstrator where username='" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataReader dr = cmd.ExecuteReader(); 

                    if (dr.Read())
                    {
                        //MessageBox.Show(" Successfully Login. ");
                        this.Close();
                        HomeforAdmin obj2 = new HomeforAdmin();
                        obj2.Show();
                    }

                    else
                    {
                        MessageBox.Show("Invalid username and Password.");
                        // textBox1.Text = "";
                        // textBox2.Text = "";
                    }
                    con.Close();
                }


            }

            //LOGIN FOR OFFICE ASSISTENT

            else if (comboBox1.SelectedItem.Equals("Office Assistent"))
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show(" Please Enter Your User Id and Password.");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                    con.Open();

                    string str = "Select emp_id from employe where username='" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataReader dr = cmd.ExecuteReader(); ;

                    if (dr.Read())
                    {

                        //MessageBox.Show(" Successfully Login. ");

                        this.Hide();
                        HomeforofficeAssistent obj2 = new HomeforofficeAssistent();
                        obj2.Show();
                    }

                    else
                    {
                        MessageBox.Show("Invalid username and Password.");
                        // textBox1.Text = "";
                        // textBox2.Text = "";
                    }
                    con.Close();
                }


            }
            //LOGIN FOR COURSE TEACHER

            else if (comboBox1.SelectedItem.Equals("Course Teacher"))
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show(" Please Enter Your User Id and Password.");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                    con.Open();

                    string str = "Select ct_id from course_teacher where username='" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataReader dr = cmd.ExecuteReader(); 

                    if (dr.Read())
                    {
                      
                            this.Hide();
                            HomeforcourseTeacher obj2 = new HomeforcourseTeacher(dr.GetInt32(0));
                            obj2.Show();
                        
                        
                        
                    }

                    else
                    {
                        MessageBox.Show("Invalid username and Password.");
                        // textBox1.Text = "";
                        // textBox2.Text = "";
                    }
                    con.Close();
                }


            }

            //LOGIN FOR ACCOUNTENT
            else if (comboBox1.SelectedItem.Equals("Accountent"))
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show(" Please Enter Your User Id and Password.");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                    con.Open();

                    string str = "Select ac_id from accountent  where username='" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataReader dr = cmd.ExecuteReader(); ;

                    if (dr.Read())
                    {

                        //MessageBox.Show(" Successfully Login. ");

                        this.Hide();
                        Homeforaccountent obj2 = new Homeforaccountent();
                        obj2.Show();
                    }

                    else
                    {
                        MessageBox.Show("Invalid username and Password.");
                        // textBox1.Text = "";
                        // textBox2.Text = "";
                    }
                    con.Close();
                }


            }
            else
            {
                MessageBox.Show("Invalid User Id or Password!");
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AsminReg obj2 = new AsminReg();
            obj2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeacherRege obj5 = new TeacherRege();
            obj5.ShowDialog();
            

           
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = textBox2;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

       


