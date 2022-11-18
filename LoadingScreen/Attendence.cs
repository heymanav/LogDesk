using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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
            this.Text = "Details";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != string.Empty && textBox2.Text != string.Empty && comboBox2.Text != string.Empty && textBox4.Text != string.Empty && this.ValidateChildren())
            {
                // SqlConnection con = new SqlConnection(@"Data Source=den1.mssql7.gear.host;Initial Catalog=manavpandey157;User ID=manavpandey157;Password=Ko2bC40Ov_0-");
                SqlConnection con = new SqlConnection(@"Data Source=tcp:192.168.2.253,1433;Initial Catalog=LogDesk;User ID=user;Password=1234;");
                //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4I2HF4V;Initial Catalog=SBJITMR;Persist Security Info=True;User ID = admin;Password = 1234");
                SqlCommand cmd = new SqlCommand("INSERT INTO attendence values (@Category,@Name,@Purpose,@Purpose_Details)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Category", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Purpose", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Purpose_Details", textBox4.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("Update EntryLog SET Category = @Category,Name = @Name,Purpose = @Purpose,Purpose_Details = @Purpose_Details where id = @id", con);
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@Category", comboBox1.Text);
                query.Parameters.AddWithValue("@Name", textBox2.Text);
                query.Parameters.AddWithValue("@Purpose", comboBox2.Text);
                query.Parameters.AddWithValue("@Purpose_Details", textBox4.Text);
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Your Details has been Successfully Registered!","Success", MessageBoxButtons.OK);
                button1.Hide(); this.Hide();
            }
            else
            {
                MessageBox.Show("Please Fill all Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 textBox2.Clear(); textBox4.Clear();
            }
        }


        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }


        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex regex1 = new Regex(@"[A-Z][a-zA-Z\s\'-]*");
            if (!regex1.IsMatch(textBox2.Text))
            {
                //To set validation error
                errorProvider1.SetError(textBox2, "Please Provide Valid Name (eg. Manav Pandey)!");
                //To say the state of control in invalid
                e.Cancel = true;
            }
            else
            {
                //To clear the validation error
                this.errorProvider1.SetError(this.textBox2, "");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
