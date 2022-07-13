using LoadingScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogDesk
{
    public partial class WelScreen : Form
    {
        public WelScreen()
        {
            InitializeComponent();
        }

        private void WelScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginScreen fr = new LoginScreen();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminLogin fr1 = new AdminLogin();
            fr1.Show();
            this.Hide();
        }
    }
}
