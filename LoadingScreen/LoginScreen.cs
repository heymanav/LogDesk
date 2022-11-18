using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using LogDesk;

namespace LoadingScreen
{
    public partial class LoginScreen : Form
    {

        public int id { get; set; }
        
        public LoginScreen()
        {
            InitializeComponent();
        }


        //SqlConnection conn = new SqlConnection(@"Data Source=den1.mssql7.gear.host;Initial Catalog=manavpandey157;User ID=manavpandey157;Password=Ko2bC40Ov_0-");
        // SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-MBJ4P5UH;Initial Catalog=LogDesk;User ID = user;Password = 1234");
       // SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8MPI8O0;Initial Catalog=LogDesk;Persist Security Info=True;User ID=user;Password=1234");
       SqlConnection conn = new SqlConnection(@"Data Source=tcp:192.168.2.253,1433;Initial Catalog=LogDesk;User ID=user;Password=1234;");

        private void LoginScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                usertxt.Focus();
            }
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

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Login";
        }

        private void usertxt_Leave(object sender, EventArgs e)
        {
            string pattern = @"^[a-z0-9._-]+@sbjit\.edu\.in$";
            if (Regex.IsMatch(usertxt.Text, pattern) == false)
            {
                usertxt.Focus();
                errorProvider1.SetError(this.usertxt, "Please Provide Valid Email Address");

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String email, user_passowrd;

            email = usertxt.Text;
            user_passowrd = passtxt.Text;

            SqlConnection cn = new SqlConnection(@"Data Source=tcp:192.168.2.253,1433;Initial Catalog=LogDesk;User ID=user;Password=1234;");
            cn.Open();
            SqlCommand cm = new SqlCommand("select * from EntryLog where Email='" + usertxt.Text + "' AND ExitTime IS NULL ", cn);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                MessageBox.Show("Your Account is already Logged in somewhere Kindly LogOut of that PC First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Close();
            }
            else
            {
                try
                {
                    String querry = "SELECT * FROM Login WHERE Email = '" + email + "' AND Password = '" + user_passowrd + "' ";
                    SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);

                    if (dtable.Rows.Count > 0)
                    {
                        email = usertxt.Text;
                        user_passowrd = passtxt.Text;

                        //insert information into database
                        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8MPI8O0;Initial Catalog=LogDesk;Persist Security Info=True;User ID=user;Password=1234");
                        SqlConnection con = new SqlConnection(@"Data Source=tcp:192.168.2.253,1433;Initial Catalog=LogDesk;User ID=user;Password=1234;");
                        SqlCommand cmd = new SqlCommand("INSERT INTO EntryLog(Email,PC_Name,Date,EntryTime,MAC_Address) values (@Email,@PC_Name,@Date,@EntryTime,@MAC_Address)", con);
                        SqlCommand cmd1 = new SqlCommand("select id from EntryLog where Email=@email AND PC_Name=@pcname AND EntryTime=@entrytime", con);

                        String entryTime = DateTime.Now.ToLongTimeString();
                        String PC_Name = System.Environment.MachineName;
                        var macAddr =
                                (from nic in NetworkInterface.GetAllNetworkInterfaces()
                                 where nic.OperationalStatus == OperationalStatus.Up
                                 select nic.GetPhysicalAddress().ToString()
                                ).FirstOrDefault();
                        var date = DateTime.UtcNow.ToShortDateString();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Parameters.AddWithValue("@email", email);
                        cmd1.Parameters.AddWithValue("@pcname", PC_Name);
                        cmd1.Parameters.AddWithValue("@entrytime", entryTime);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PC_Name", PC_Name);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@EntryTime", entryTime);
                        cmd.Parameters.AddWithValue("@MAC_Address", macAddr);


                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader sqlDataReader = cmd1.ExecuteReader();
                        sqlDataReader.Read();
                        id = (int)sqlDataReader["Id"];
                        con.Close();


                        //next screen

                        Entry formn = new Entry(id);
                        Attendence fr = new Attendence(id);
                        formn.Show();
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

        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup form = new Signup();
            form.Show();
            this.Hide();
        }
    }
}
