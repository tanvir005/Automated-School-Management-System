using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stu_ManagementSystem
{
    public partial class HomeforofficeAssistent : Form
    {
        public HomeforofficeAssistent()
        {
            InitializeComponent();
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
            Student_Admission obj = new Student_Admission();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateStudentInfo obj = new UpdateStudentInfo();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deletStudent obj = new deletStudent();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result obj = new result();
            obj.Show();
        }
    }
}
