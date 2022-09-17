using System.Data;
using System.Data.SqlClient;

namespace LoadingScreen
{
    public partial class Attendence : Form
    {
        public int id { get; set; }

        public Attendence(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = "Attendance";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4I2HF4V;Initial Catalog=SBJITMR;Persist Security Info=True;User ID = admin;Password = 1234");
                SqlCommand cmd = new SqlCommand("INSERT INTO attendence values (@Roll_no,@Name,@Subject,@Purpose)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Roll_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Subject", textBox3.Text);
                cmd.Parameters.AddWithValue("@Purpose", textBox4.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("Update EntryLog SET Roll_no = @Roll_no,Name = @Name,Subject = @Subject,Purpose = @Purpose where id = @id", con);
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@Roll_no", textBox1.Text);
                query.Parameters.AddWithValue("@Name", textBox2.Text);
                query.Parameters.AddWithValue("@Subject", textBox3.Text);
                query.Parameters.AddWithValue("@Purpose", textBox4.Text);
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Your Attendance has been Successfully Marked!");
                button1.Hide();
            }
            else
            {
                MessageBox.Show("Please Fill all Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            }
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
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
