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
    public partial class showdataforclasswaise : Form
    {
        public showdataforclasswaise()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True"))
            {

                string str = "SELECT * FROM student_bio where class='" + textBox2.Text + "'";
                MySqlCommand cmd = new MySqlCommand(str, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            stu_info home = new stu_info();
            home.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Text = "";
        }
    }
}
