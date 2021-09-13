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
    public partial class recieveFees : Form
    {
        public recieveFees()
        {
            InitializeComponent();

            comboBox1.Items.Add("January");
            comboBox1.Items.Add("February");
            comboBox1.Items.Add("March");
            comboBox1.Items.Add("April");
            comboBox1.Items.Add("June");
            comboBox1.Items.Add("July");
            comboBox1.Items.Add("August");
            comboBox1.Items.Add("September");
            comboBox1.Items.Add("Octobor");
            comboBox1.Items.Add("November");
            comboBox1.Items.Add("December");
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
            comboBox7.Items.Add("3000");
            comboBox7.Items.Add("5000");
            comboBox7.Items.Add("7000");
            comboBox4.Items.Add("1000");
            comboBox4.Items.Add("2000");
            comboBox4.Items.Add("3000");
            comboBox6.Items.Add("firstXm");
            comboBox6.Items.Add("secondxm");
            comboBox6.Items.Add("thirdxm");
            comboBox6.Items.Add("Others");
            comboBox8.Items.Add("1");
            comboBox8.Items.Add("2");
            comboBox8.Items.Add("3");
            comboBox8.Items.Add("4");
            comboBox8.Items.Add("5");
            comboBox8.Items.Add("6");
            comboBox8.Items.Add("7");
            comboBox8.Items.Add("8");
            comboBox8.Items.Add("9");
            comboBox8.Items.Add("10");

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Fillup First!");
            }

            else
            {
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                con.Open();

                try
                {
                    string str = " INSERT INTO   accademicfees (Student_id,Class," + comboBox1.Text + ") VALUES('" + comboBox3.Text + "','" + comboBox2.Text + "','" + comboBox7.Text + "'); ";

                    MySqlCommand cmd = new MySqlCommand(str, con);
                    //int x = 0;
                    cmd.ExecuteNonQuery();


                    // Console.WriteLine(cmd.ExecuteNonQuery());
                    MessageBox.Show("Save data Successfully ");
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    comboBox6.Text = "";
                    comboBox7.Text = "";


                    //this.Close();
                }
                catch (MySqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                finally
                {
                    string str1 = " UPDATE `accademicfees` SET " + comboBox1.Text + " = '" + comboBox7.Text + "' WHERE `accademicfees`.`Student_Id` = '" + comboBox3.Text + "' AND `accademicfees`.`Class` = '" + comboBox2.Text + "' ";

                    MySqlCommand cmd1 = new MySqlCommand(str1, con);
                    cmd1.ExecuteNonQuery();



                    MessageBox.Show(" Updated  Successfully ");
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    comboBox6.Text = "";
                    comboBox7.Text = "";
                }
                con.Close();
            }
        }

        private void recieveFees_Load(object sender, EventArgs e)
        {
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
                   // comboBox5.Items.Add(da1.GetString(0));
                    //label9.Text = da.GetValue(0).ToString();
                }
            }
            catch (MySqlException excep)
            {
               // MessageBox.Show(excep.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox8.Text == "" )
            {
                MessageBox.Show("Fillup First!");
            }
            else
            {
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
                con.Open();

                string str1 = " UPDATE `accademicfees` SET " + comboBox6.Text + " = '" + comboBox4.Text + "' WHERE `accademicfees`.`Student_Id` = '" + comboBox8.Text + "' AND `accademicfees`.`Class` = '" + comboBox5.Text + "' ";

                MySqlCommand cmd1 = new MySqlCommand(str1, con);
                cmd1.ExecuteNonQuery();



                MessageBox.Show("Dear Teacher, Updated marks Successfully ");
                comboBox5.Text = "";
                comboBox4.Text = "";
                comboBox6.Text = "";
                

                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            comboBox7.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox5.Text = "";
            comboBox4.Text = "";
            comboBox6.Text = "";
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
