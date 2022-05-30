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

namespace LoadingScreen
{
    public partial class AdDashboard : Form
    {
        public AdDashboard()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            getEntryLogData();
            this.Text = "Dashboard";

        }

        private void getEntryLogData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=den1.mssql7.gear.host;Initial Catalog=manavpandey157;User ID=manavpandey157;Password=Ko2bC40Ov_0-");
            SqlCommand cmd = new SqlCommand("Select * from EntryLog", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }
    }
}
