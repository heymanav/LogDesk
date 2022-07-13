using System.Data;
using System.Data.SqlClient;

namespace LoadingScreen
{
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = "Attendance";
            getAttendanceData();
        }
        private void getAttendanceData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=den1.mssql7.gear.host;Initial Catalog=manavpandey157;User ID=manavpandey157;Password=Ko2bC40Ov_0-");
            SqlCommand cmd = new SqlCommand("Select * from attendence", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=den1.mssql7.gear.host;Initial Catalog=manavpandey157;User ID=manavpandey157;Password=Ko2bC40Ov_0-");
            SqlCommand cmd = new SqlCommand("INSERT INTO attendence values (@id,@Name,@Subject)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Subject", textBox3.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Your Attendance has been Successfully Marked!");
            getAttendanceData();
            button1.Hide();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
