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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            getEntryLogData();
           
        }

        private void getEntryLogData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ATHARVA-PC;Initial Catalog=EntryLog;Integrated Security=True");
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
