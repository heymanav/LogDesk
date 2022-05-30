using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;


namespace LoadingScreen
{
    public partial class LoginScreen : Form
    {

        
        public LoginScreen()
        {
            InitializeComponent();
        }

        
        SqlConnection conn = new SqlConnection(@"Data Source=den1.mssql7.gear.host;Initial Catalog=manavpandey157;User ID=manavpandey157;Password=Ko2bC40Ov_0-");

       
       
        private void button1_Click_1(object sender, EventArgs e)
        {

            
        }


        
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Login";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            


            String username, user_passowrd;

            username = usertxt.Text;
            user_passowrd = passtxt.Text;
           

            try
            {
                String querry = "SELECT * FROM Login WHERE username = '" + usertxt.Text + "' AND password = '" + passtxt.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = usertxt.Text;
                    user_passowrd = passtxt.Text;


                    //next screen

                    Entry formn = new Entry();
                    formn.Show();
                    this.Hide();
                    button2.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid details", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passtxt.Clear();
                    usertxt.Clear();
                }

            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                conn.Close();
            }
            SqlConnection con = new SqlConnection(@"Data Source=den1.mssql7.gear.host;Initial Catalog=manavpandey157;User ID=manavpandey157;Password=Ko2bC40Ov_0-");
            SqlCommand cmd = new SqlCommand("INSERT INTO EntryLog(EntryTime,Name) values (@EntryTime,@Name)", con);

            cmd.CommandType = CommandType.Text;
            String entryTime = DateTime.Now.ToLongTimeString();
            cmd.Parameters.AddWithValue("@EntryTime", entryTime);
            cmd.Parameters.AddWithValue("@Name", username);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void usertxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            AdminLogin fr5 = new AdminLogin();
            fr5.Show();
            this.Hide();
        }
    }
}
