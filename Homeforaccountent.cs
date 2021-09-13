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
    public partial class Homeforaccountent : Form
    {
        public Homeforaccountent()
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

        private void Homeforaccountent_Load(object sender, EventArgs e)
        {

        }

        private void student_regi_Click(object sender, EventArgs e)
        {
            recieveFees obj = new recieveFees();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkDues obj = new checkDues();
            obj.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
