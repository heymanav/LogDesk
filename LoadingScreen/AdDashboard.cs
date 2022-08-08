using System.Data;
using System.Data.SqlClient;

namespace LoadingScreen
{
    public partial class AdDashboard : Form
    {
        private int numberOfItemsPrintedSoFar = 0;
        private int numberOfItemsPerPage = 0;

        public AdDashboard()
        {
            InitializeComponent();
        }

        DataView dv;
        DataTable dt;
        private void Form6_Load(object sender, EventArgs e)
        {
            getEntryLogData();
            this.Text = "Dashboard";

        }

        private void getEntryLogData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=den1.mssql7.gear.host;Initial Catalog=manavpandey157;User ID=manavpandey157;Password=Ko2bC40Ov_0-");
            SqlCommand cmd = new SqlCommand("Select * from EntryLog", con);
            dt = new DataTable();
           
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            dv = new DataView(dt);
            con.Close();

            dataGridView1.DataSource = dv;
        }

        private void button_Click(object sender, EventArgs e)
        {
            PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.AllowSomePages = true;
            PrintDialog1.ShowHelp = true;
            PrintDialog1.Document = printDocument1;
            DialogResult result = PrintDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string curdhead = "EntryLog";
            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            e.Graphics.DrawString(curdhead, new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 370, 30);
            e.Graphics.DrawString(strDate, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 314, 70);

            string l1 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l1, new System.Drawing.Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, 0, 120);

            string g1 = "Id ";
            e.Graphics.DrawString(g1, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 10, 140);

            string g2 = "Name";
            e.Graphics.DrawString(g2, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 100, 140);

            string g3 = "PC_Name";
            e.Graphics.DrawString(g3, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 220, 140);

            string g4 = "Date";
            e.Graphics.DrawString(g4, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 350, 140);

            string g5 = "EntryTime";
            e.Graphics.DrawString(g5, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 450, 140);

            string g6 = "ExitTime";
            e.Graphics.DrawString(g6, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 580, 140);

            string g7 = "MAC_Adress";
            e.Graphics.DrawString(g7, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 720, 140);

            string l2 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l2, new System.Drawing.Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, 0, 160);

            int height = 165;
            for (int l = numberOfItemsPrintedSoFar; l < dataGridView1.Rows.Count; l++)
            {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 50)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= dataGridView1.Rows.Count)
                    {

                        height += dataGridView1.Rows[0].Height;
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[0].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(10, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[1].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(100, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[2].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(220, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[3].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(350, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[4].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(450, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[5].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(580, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[6].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(720, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }

                }
                else
                {
                    numberOfItemsPerPage = 0;
                    e.HasMorePages = true;
                    return;

                }


            }
            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime Date1 = dateTimePicker1.Value.Date;
            
            DateTime Date2 = dateTimePicker2.Value.Date;
           

            dv.RowFilter = String.Format("Date >= #{0:MM/dd/yyyy}# AND Date <= #{1:MM/dd/yyyy}#", Date1, Date2);

            dataGridView1.DataSource = dv;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DateTime Date1 = dateTimePicker1.Value.Date;

            DateTime Date2 = dateTimePicker2.Value.Date;


            dv.RowFilter = String.Format("Date >= #{0:MM/dd/yyyy}# AND Date <= #{1:MM/dd/yyyy}#", Date1, Date2);

            dataGridView1.DataSource = dv;

        }
    }
}
