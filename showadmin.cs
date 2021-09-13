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
    public partial class showadmin : Form
    {
        public showadmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
            con1.Open();

           

            if (textBox1.Text == "" || textBox3.Text == "" || textBox6.Text == ""  || comboBox1.Text == "")
            {
                MessageBox.Show("Required Informations are Mendayory!");
            }

            
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
                    string str = " INSERT INTO   adminstrator (username,full_name,password,gender,email,mobile,Security_A,security_q) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + gender + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "'); ";

                    MySqlCommand cmd = new MySqlCommand(str, con);
                    cmd.ExecuteNonQuery();



                    string str2 = "select max(admin_id) from adminstrator;";

                    MySqlCommand cmd2 = new MySqlCommand(str2, con);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        MessageBox.Show("Dear Admin, Your Id is '" + dr2.GetInt32(0) + "'\n. Your are Registered Successfully .. ");
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

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True"))
            {

                string str = "SELECT admin_id as 'Admin Id',full_name as 'Name',gender,mobile as'Mobile' ,email FROM adminstrator";
                MySqlCommand cmd = new MySqlCommand(str, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Deletadmin obj = new Deletadmin();
            obj.Show();
        }
    }
}
