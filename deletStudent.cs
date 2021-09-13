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
    public partial class deletStudent : Form
    {
        public deletStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(@"server=localhost;user id=root;database=student_info;allowuservariables=True");
            con1.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Valid Teacher Id !");
            }
            else
            {
                String sql1 = "Select max(Student_Id) from student_bio";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
                MySqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    using (MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=student_info"))
                    {

                        string str = "DELETE FROM student_bio WHERE Student_Id = '" + textBox1.Text + "' and Class='"+textBox2.Text+"'";
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
                    MessageBox.Show("Invalid Teacher Id!");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}


