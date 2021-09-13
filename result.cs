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
    public partial class result : Form
    {
        public result()
        {
            InitializeComponent();
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            comboBox1.Items.Add("6");
            comboBox1.Items.Add("7");
            comboBox1.Items.Add("8");
            comboBox1.Items.Add("9");
            comboBox1.Items.Add("10");
        }

        private void result_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection(@"server=localhost;user id = root; database=student_info;allowuservariables=True");
                con1.Open();

                string str1 = "SELECT Student_Id  FROM student_bio where Class = '" + comboBox1.Text + "' ";
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True"))
                {

                    string str = "SELECT `Student_Id`, `Class`,ROUND(SUM(Bangla) / 3, 2) as 'Bangla',ROUND(SUM(English) / 3, 2) as 'English',ROUND(SUM(Mathematics) / 3, 2) as 'Mathematics',ROUND(SUM(Physics) / 3, 2) as 'Physics',ROUND(SUM(Chemistry) / 3, 2) as 'Chemistry',ROUND(SUM(Biology) / 3, 2) as 'Biology',ROUND(SUM(ICT) / 3, 2) as 'Ict',ROUND(SUM(Higher_mathematics) / 3, 2) as 'Higher Mathematics' FROM `marks`  where  class='" + comboBox1.Text + "' GROUP BY Student_Id";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
            }
            else
            {
                using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True"))
                {

                    string str = "SELECT `Student_Id`, `Class`,ROUND( SUM(Bangla)/3,2) as 'Bangla',ROUND( SUM(English)/3,2) as 'English',ROUND( SUM(Mathematics)/3,2) as 'Mathematics',ROUND( SUM(Physics)/3,2) as 'Physics',ROUND( SUM(Chemistry)/3,2) as 'Chemistry',ROUND( SUM(Biology)/3,2) as 'Biology',ROUND( SUM(ICT)/3,2) as 'Ict',ROUND( SUM(Higher_mathematics)/3,2) as 'Higher Mathematics' FROM `marks`  where Student_Id='" + comboBox3.Text + "' and class='" + comboBox1.Text + "' GROUP BY Student_Id";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
