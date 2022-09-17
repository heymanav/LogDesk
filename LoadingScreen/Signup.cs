using LoadingScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogDesk
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4I2HF4V;Initial Catalog=SBJITMR;Persist Security Info=True;User ID = admin;Password = 1234");
                con.Open();
                SqlCommand cm = new SqlCommand("select * from Login where Email='" + textBox2.Text + "' ", con);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("Account Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
                }
                else
                {
                    dr.Close();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Login values (@Name,@Roll_no,@Year,@Semester,@Email,@password)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Roll_no", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Year", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Semester", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@password", textBox6.Text);


                    //con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Signed Up!");
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
                    button2.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginScreen fr = new LoginScreen();
            fr.Show();
            this.Hide();
        }

        private void Signup_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }
    }
}
