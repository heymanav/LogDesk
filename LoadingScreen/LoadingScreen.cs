using LogDesk;

namespace LoadingScreen
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;

            if(panel2.Width >= 780)
            {
                timer1.Stop();
                WelScreen FM2 = new WelScreen();
                FM2.Show();
                this.Hide();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}