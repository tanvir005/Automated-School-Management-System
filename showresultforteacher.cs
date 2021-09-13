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
    public partial class showresultforteacher : Form
    {
        public showresultforteacher(string str)
        {
            InitializeComponent();
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
            label8.Text = str;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id = root; database=student_info;allowuservariables=True"))
                {
                    // string str = "SELECT Student_Id as ID,Semester,Class," + label8.Text + " FROM marks where Class='" + comboBox2.Text + "' and Semester ='" + comboBox1.Text + "'";
                    string str = "SELECT Student_Id as 'Student Id' , sum(" + label8.Text + ") as 'Total of Physics' FROM marks where Class='" + comboBox2.Text + "'group by  Student_Id";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);

                }

            }
            else
            {

                using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id = root; database=student_info;allowuservariables=True"))
                {
                    string str = "SELECT Student_Id as ID,Semester,Class," + label8.Text + " FROM marks where Class='" + comboBox2.Text + "' and Semester ='" + comboBox1.Text + "'";
                    //string str = "SELECT sum(" + label8.Text + ") FROM marks where Class='" + comboBox2.Text + "' and Student_Id ='" + comboBox1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);

                }
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
        }
    }
}
