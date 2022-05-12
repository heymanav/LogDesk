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
using System.Timers;
namespace LoadingScreen

{
    public partial class Form3 : Form
    {

        System.Timers.Timer timer;

        int hour, minute, second;
        int count = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            Application.DoEvents();

            SqlConnection con = new SqlConnection(@"Data Source=ATHARVA-PC;Initial Catalog=EntryLog;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO EntryLog(exitT) values (@exitT)", con);

            cmd.CommandType = CommandType.Text;
            String exitTime = DateTime.Now.ToLongTimeString();
            cmd.Parameters.AddWithValue("@exitT", exitTime);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            count++;

            if (count > 1)
            {
                label1.Text = "Attendance already marked";

            }
            else
            {
                Form4 fe2 = new Form4();
                fe2.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/en-us/visualstudio/ide/how-to-configure-projects-to-target-platforms?view=vs-2022");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();

            timer.Interval = 1000;  //to make it tick every second
            timer.Elapsed += onTimeEvent;
            timer.Start();

            if (count > 1)
            {
                button1.Hide();
            }
          
        }

        private void onTimeEvent(object? sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                second += 1;

                if (second == 60)
                {
                    second = 0;
                    minute += 1;
                }
                if (minute == 60)
                {
                    minute = 0;
                    hour += 1;
                }

                textBox1.Text = string.Format("{0}:{1}:{2}", hour.ToString(), minute.ToString().PadLeft(2, '0'), second.ToString().PadLeft(2, '0'));
            }));
        }

        
    }
}
