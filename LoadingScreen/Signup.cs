using LoadingScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
        ToolTip mytip = new ToolTip();
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty && txtConfirm.Text != string.Empty && txtConfirm.Text == vCode.ToString() && this.ValidateChildren())
            {
                //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8MPI8O0;Initial Catalog=LogDesk;Persist Security Info=True;User ID=user;Password=1234");
                SqlConnection con = new SqlConnection(@"Data Source=tcp:192.168.2.253,1433;Initial Catalog=LogDesk;User ID=user;Password=1234;");

                con.Open();
                SqlCommand cm = new SqlCommand("select * from Login where Email='" + textBox5.Text + "' ", con);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("Account Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear(); textBox6.Clear(); txtConfirm.Clear(); 
                    textBox5.Enabled = true;
                }
                else
                {
                    dr.Close();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Login values (@Name,@Roll_no,@Year,@Email,@password)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Roll_no", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Year", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@password", textBox6.Text);


                    //con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Signed Up!");
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear(); textBox6.Clear(); txtConfirm.Clear() ;
                    button2.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Enabled = true;
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear(); textBox6.Clear(); txtConfirm.Clear();
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

        int vCode=1000;
        private void timvcode_Tick(object sender, EventArgs e)
        {
            vCode += 10;
            if (vCode == 9999)
            {
                vCode = 1000;
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            timvcode.Stop();
            string to, from, pass, mail;
            to = textBox5.Text;
            from = "logdesk030@gmail.com";
            mail = vCode.ToString();
            pass = "fhaxotfwafyypkvf";
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = "LogDesk - Verification Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            textBox5.Enabled = false;
            try
            {
                smtp.Send(message);
                MessageBox.Show("Verification Code sent successfully to your given Mail!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirm.Enabled = true;
                button2.Enabled = true;
                btnSend.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {   
            Regex regex1 = new Regex(@"^[a-z0-9._-]+@sbjit\.edu\.in$");
            if (!regex1.IsMatch(textBox5.Text))
            {
                //To set validation error
                errorProvider1.SetError(textBox5, " ");
               
                mytip.Show("Please Provide Valid College Email Address!", textBox5,1500);
                //To say the state of control in invalid
                e.Cancel = true;
            }
            else
            {
                //To clear the validation error
                this.errorProvider1.SetError(this.textBox5, "");
                mytip.Hide(this);
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            Regex regex2 = new Regex(@"[A-Z][a-zA-Z\s\'-]*");
            if (!regex2.IsMatch(textBox1.Text))
            {
                //To set validation error
                errorProvider1.SetError(textBox1, " ");
                mytip.Show("Please Provide Valid Name (eg. Manav Pandey)!", textBox1,1500);
                //To say the state of control in invalid
                e.Cancel = true;
            }
            else
            {
                //To clear the validation error
                this.errorProvider1.SetError(this.textBox1, "");
                mytip.Hide(this);
            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Regex regex1 = new Regex(@"^[a-z0-9._-]+@sbjit\.edu\.in$");
            if (regex1.IsMatch(textBox5.Text))
            {
                btnSend.Enabled = true;
            }
            else
            {
                btnSend.Enabled=false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            Regex regex3 = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (!regex3.IsMatch(textBox6.Text))
            {
                //To set validation error
                errorProvider1.SetError(textBox6," ");
                mytip.Show("Please Provide Valid Password (Required - Minimum 8 Char, Atleast one uppercase ,lowecase ,digit and a special character)!", textBox6,1500);
                //To say the state of control in invalid
                e.Cancel = true;
            }
            else
            {
                //To clear the validation error
                this.errorProvider1.SetError(this.textBox6, "");
                mytip.Hide(this);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
