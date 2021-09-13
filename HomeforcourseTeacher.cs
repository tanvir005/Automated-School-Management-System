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
    public partial class HomeforcourseTeacher : Form
    {
        public HomeforcourseTeacher(int a)
        {
            InitializeComponent();
            label5.Text = a.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;
            LoginPage obj3 = new LoginPage();
            obj3.Show();
        }

        private void student_regi_Click(object sender, EventArgs e)
        {
            marksUpdate obj = new marksUpdate(label5.Text);
            obj.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showresultforteacher obj = new showresultforteacher(label8.Text);
            obj.Show();
        }

        private void HomeforcourseTeacher_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server=localhost;user id = root; database=student_info;allowuservariables=True");
            con.Open();

            /*SqlCommand cmd = new SqlCommand(getCust, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label15.Text = dr.GetValue(0).ToString();*/

            string str = "SELECT Subject  FROM course_teacher where ct_id = '" + label5.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(str, con);
            MySqlDataReader da;
            //DataTable dt = new DataTable();
            da = cmd.ExecuteReader();
            if (da.Read())
            {

                label8.Text = da.GetValue(0).ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            editmarks obj = new editmarks(label5.Text);
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stu_info obj = new stu_info();
            obj.Show();
        }
    }
}
