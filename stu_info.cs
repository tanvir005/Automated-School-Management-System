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
    public partial class stu_info : Form
    {
        public stu_info()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdataforindivisual obj = new showdataforindivisual();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showdataforclasswaise obj = new showdataforclasswaise();
            obj.Show();
            this.Hide();
        }
    }
}
