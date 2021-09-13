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
    public partial class HomeforAdmin : Form
    {
        public HomeforAdmin()
        {
            InitializeComponent();
        }

        private void student_regi_Click(object sender, EventArgs e)
        {
            
            stu_info obj = new stu_info();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage obj2 = new LoginPage();
            obj2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            OfficeassistentRege obj = new OfficeassistentRege();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
            accountent obj4 = new accountent();
            obj4.Show();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TeacherRege obj5 = new TeacherRege();
            obj5.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deletteacher obj = new deletteacher();
            obj.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            showadmin obj = new showadmin();
            obj.Show();
        }
    }
}
