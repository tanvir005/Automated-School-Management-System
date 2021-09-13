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
    public partial class marksUpdate : Form
    {
        public marksUpdate(string  a)
        {
            InitializeComponent();
            label8.Text = a;

            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            comboBox2.Items.Add("6");
            comboBox2.Items.Add("7");
            comboBox2.Items.Add("8");
            comboBox2.Items.Add("9");
            comboBox2.Items.Add("10");
        }

        private void marksUpdate_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server=localhost;user id = root; database=student_info;allowuservariables=True");
            con.Open();
            
             

                string str = "SELECT Subject  FROM course_teacher where ct_id = '"+label8.Text + "' ";
                MySqlCommand cmd = new MySqlCommand(str, con);
                MySqlDataReader da ;
                //DataTable dt = new DataTable();
                da=cmd.ExecuteReader();
            if (da.Read())
            {
                label9.Text = da.GetValue(0).ToString();
            }
            con.Close();
            try
            {
                MySqlConnection con1 = new MySqlConnection(@"server=localhost;user id = root; database=student_info;allowuservariables=True");
                con1.Open();

                string str1 = "SELECT Student_Id  FROM student_bio where Class = '" + comboBox2.Text + "' ";
                MySqlCommand cmd1 = new MySqlCommand(str1, con1);
                MySqlDataReader da1;
                //DataTable dt = new DataTable();
                da1 = cmd1.ExecuteReader();
                if (da1.Read())
                {
                    comboBox3.Items.Add(da1.GetString(0));
                    //label9.Text = da.GetValue(0).ToString();
                }
            }
            catch (MySqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
            con1.Open();


            if (comboBox3.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Fillup First!");
            }

            else
            {
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                con.Open();
                
                try
                {
                    string str = " INSERT INTO   marks (Student_id,Class,Semester," + label9.Text + ") VALUES('" + comboBox3.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "'); ";

                    MySqlCommand cmd = new MySqlCommand(str, con);
                    //int x = 0;
                    cmd.ExecuteNonQuery();

                    
                       // Console.WriteLine(cmd.ExecuteNonQuery());
                        MessageBox.Show("Dear Teacher, Updated marks Successfully ");
                        comboBox3.Text = "";
                        textBox2.Text = "";
                   
                    
                    //this.Close();
                }
                catch (MySqlException excep)
                {
                    //MessageBox.Show(excep.Message);
                }
                finally
                {
                    string str1 = " UPDATE `marks` SET " + label9.Text + " = '" + textBox2.Text + "' WHERE `marks`.`Student_Id` = '" + comboBox3.Text + "' AND `marks`.`Class` = '" + comboBox2.Text + "' AND `marks`.`Semester` = '" + comboBox1.Text + "'";

                    MySqlCommand cmd1 = new MySqlCommand(str1, con);
                    cmd1.ExecuteNonQuery();



                    MessageBox.Show("Dear Teacher, Updated marks Successfully ");
                    comboBox3.Text = "";
                    textBox2.Text = "";
                }
                con.Close();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
