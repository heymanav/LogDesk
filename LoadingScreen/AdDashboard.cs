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

        
        private void Form6_Load(object sender, EventArgs e)
        {
            this.Text = "Dashboard";
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4I2HF4V;Initial Catalog=SBJITMR;Persist Security Info=True;User ID = admin;Password = 1234");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from EntryLog", con);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string curdhead = "EntryLog";
            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            e.Graphics.DrawString(curdhead, new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 500, 30);
            e.Graphics.DrawString(strDate, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 425, 70);

            string l1 = "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l1, new System.Drawing.Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, 0, 120);

            string g1 = "Id ";
            e.Graphics.DrawString(g1, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 10, 140);

            string g2 = "Email";
            e.Graphics.DrawString(g2, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 65, 140);

            string g3 = "PC_Name";
            e.Graphics.DrawString(g3, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 190, 140);

            string g4 = "Date";
            e.Graphics.DrawString(g4, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 305, 140);

            string g5 = "EntryTime";
            e.Graphics.DrawString(g5, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 400, 140);

            string g6 = "ExitTime";
            e.Graphics.DrawString(g6, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 500, 140);

            string g7 = "MAC_Adress";
            e.Graphics.DrawString(g7, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 600, 140);

            string g8 = "Roll_no";
            e.Graphics.DrawString(g8, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 725, 140);

            string g9 = "Name";
            e.Graphics.DrawString(g9, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 830, 140);

            string g10 = "Subject";
            e.Graphics.DrawString(g10, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 920, 140);

            string g11 = "Purpose";
            e.Graphics.DrawString(g11, new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 1015, 140);

            string l2 = "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
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
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[1].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(65, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[2].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(190, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[3].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(297, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[4].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(400, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[5].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(497, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[6].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(600, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[7].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(730, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[8].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(835, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[9].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(925, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[10].FormattedValue.ToString(), dataGridView1.Font = new Font("Times New Roman", 9), Brushes.Black, new RectangleF(1020, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
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

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime Date1 = dateTimePicker1.Value.Date;
            DateTime Date2 = dateTimePicker2.Value.Date;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4I2HF4V;Initial Catalog=SBJITMR;Persist Security Info=True;User ID = admin;Password = 1234");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from EntryLog where PC_Name like '" + textBox1.Text + "%' AND Date Between '"+Date1+"' AND '"+Date2+"'", con);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
