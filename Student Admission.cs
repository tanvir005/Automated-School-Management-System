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
    public partial class Student_Admission : Form
    {
        public Student_Admission()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stu_info obj = new stu_info();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;
            Student_Admission obj2 = new Student_Admission();
            obj2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("Please Fillup Properly!");
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
                    String sql = "INSERT INTO `student_bio`(`Student_Id`, `Class`, `Academic_year`,`Frist_Name`, `Lasat_Name`, `Fathers_Name`, `Motherst_Name`, `Email`, `Phone`, `DOB`, `DOR`, `Adress`, `Gender`, `Division`, `city`, `country`) VALUES ('" + textBox11.Text + "','" + textBox10.Text + "','" + textBox12.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + richTextBox1.Text + "','" + gender + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox9.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    String sql1 = "Select max(student_id) from student_bio";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Dear Student, Your Data Inserted Successfully.. ");
                    }
                    //this.Close();
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                /*MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info");
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
                String sql = "INSERT INTO `student_bio`(`Student_Id`, `Class`, `Frist_Name`, `Lasat_Name`, `Fathers_Name`, `Motherst_Name`, `Email`, `Phone`, `DOB`, `DOR`, `Adress`, `Gender`, `Division`, `city`, `country`) VALUES ('" + textBox11.Text + "','" + textBox10.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + richTextBox1.Text + "','" + gender + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox9.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                String sql1 = "Select max(student_id) from student_bio";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                MySqlDataReader dr = cmd1.ExecuteReader();

                MessageBox.Show("Dear Student, Your Data Inserted Successfully.. ");

                //this.Close();

    */
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           this.Visible = false;
           deletStudent obj2 = new deletStudent();
           obj2.ShowDialog();

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
