using System.Data;
using System.Data.SqlClient;

namespace LoadingScreen
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_KeyDown(object sender, KeyEventArgs e)
        {
            usertxt.Focus();
        }

        private void usertxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passtxt.Focus();
            }
        }

        private void passtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username, user_passowrd;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-4I2HF4V;Initial Catalog=SBJITMR;Persist Security Info=True;User ID = admin;Password = 1234");

            username = usertxt.Text;
            user_passowrd = passtxt.Text;


            try
            {

                String querry = "SELECT * FROM AdminLogin WHERE username = '" + usertxt.Text + "' AND password = '" + passtxt.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = usertxt.Text;
                    user_passowrd = passtxt.Text;


                    //next screen

                    AdDashboard fr6 =  new AdDashboard();
                    fr6.Show();
                    this.Hide();
                    button2.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passtxt.Clear();
                    usertxt.Clear();
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Text = "Admin Login";
        }


        private void AdminLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }


    }
}
