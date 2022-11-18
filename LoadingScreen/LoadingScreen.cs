using LogDesk;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LoadingScreen
{
    public partial class LoadingScreen : Form
    {
        EnableDisableKeys ed = new EnableDisableKeys();
        public LoadingScreen()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("LogDesk", Application.ExecutablePath);
            InitializeComponent();
            //RegistryKey objregistrykey = Registry.CurrentUser.CreateSubKey(
            //  @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            //if (objregistrykey.GetValue("DisableTaskMgr") == null)
            //    objregistrykey.SetValue("DisableTaskMgr", "1");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;

            if(panel2.Width >= 1420)
            {
                timer1.Stop();
                WelScreen FM2 = new WelScreen();
                FM2.Show();
                this.Hide();
            }
        }

        private void LoadingScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            ed.KeyHook();
        }
    }
}