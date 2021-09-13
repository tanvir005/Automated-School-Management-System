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
    public partial class TeacherRege : Form
    {
        public TeacherRege()

        {
            InitializeComponent();
            comboBox1.Items.Add("First Phone Number");
            comboBox1.Items.Add("Favorite Person");
            comboBox1.Items.Add("Favorite Digits");
            comboBox1.Items.Add("First Girl Friend or BoyFriend");
            comboBox2.Items.Add("Bangla");
            comboBox2.Items.Add("English");
            comboBox2.Items.Add("Mathematics");
            comboBox2.Items.Add("Physics");
            comboBox2.Items.Add("Chemistry");
            comboBox2.Items.Add("Biology");
            comboBox2.Items.Add("ICT");
            comboBox2.Items.Add("Higher_mathematics");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection con1 = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
            con1.Open();


            if (textBox1.Text == "" || textBox3.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Required Informations are Mendayory!");
            }

            else
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
                    string str = " INSERT INTO   course_teacher (username,full_name,password,gender,email,mobile,Security_A,security_q,Subject) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + gender + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "'); ";

                    MySqlCommand cmd = new MySqlCommand(str, con);
                    cmd.ExecuteNonQuery();


                    MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                    conn.Open();
                    string str2 = "select max(ct_id) from course_teacher ;";

                    MySqlCommand cmd2 = new MySqlCommand(str2, conn);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        MessageBox.Show("Dear Teacher, Your Id is '" + dr2.GetInt32(0) + "'\n. Your are Registered Successfully .. ");
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
           // HomeforAdmin obj = new HomeforAdmin();
           // obj.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TeacherRege_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True"))
            {

                string str = "SELECT ct_id as 'Teacher Id',full_name as 'Name',Subject,mobile as'Mobile'  FROM course_teacher ";
                MySqlCommand cmd = new MySqlCommand(str, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deletteacher obj = new deletteacher();
            obj.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

