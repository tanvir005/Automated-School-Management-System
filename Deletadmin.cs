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
    public partial class Deletadmin : Form
    {
        public Deletadmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
            con1.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Valid Admin Id !");
            }
            else
            {
                String sql1 = "Select max(admin_id) from adminstrator";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
                MySqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info"))
                    {

                        string str = "DELETE FROM adminstrator WHERE admin_id = '" + textBox1.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(str, con);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        MessageBox.Show("Remove Successfully!");
                    }
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid Admin Id!");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
