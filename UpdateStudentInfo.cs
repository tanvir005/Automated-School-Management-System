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
    public partial class UpdateStudentInfo : Form
    {
        public UpdateStudentInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("Fillup Properly!");
            }
            else
            {
                try
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
                    String sql = "UPDATE `student_bio` SET `Frist_Name`='" + textBox1.Text + "',`Lasat_Name`= '" + textBox2.Text + "',`Fathers_Name`='" + textBox3.Text + "',`Motherst_Name`='" + textBox4.Text + "',`Email`='" + textBox5.Text + "',`Phone`='" + textBox6.Text + "',`DOB`='" + dateTimePicker1.Text + "',`DOR`='" + dateTimePicker2.Text + "',`Adress`='" + richTextBox1.Text + "',`Gender`='" + gender + "',`Division`='" + textBox7.Text + "',`city`='" + textBox8.Text + "',`country`='" + textBox9.Text + "' WHERE `Student_Id`='" + textBox11.Text + "' and `Class`='" + textBox10.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    String sql1 = "Select max(student_id) from student_bio";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Your Data updated Successfully.. ");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        richTextBox1.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Please enter Valid Class And Roll to Update data!");
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Visible = false;
            //HomeforAdmin obj2 = new HomeforAdmin();
            //obj2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
