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
    public partial class checkDues : Form
    {
        public checkDues()
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

        private void checkDues_Load(object sender, EventArgs e)
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
            using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True"))
            {

                string str = "SELECT * FROM accademicfees where student_id='" + comboBox3.Text + "' and class='" + comboBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(str, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
