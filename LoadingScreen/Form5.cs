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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {




            String username, user_passowrd;
            SqlConnection conn = new SqlConnection(@"Data Source=ATHARVA-PC;Initial Catalog=Login;Integrated Security=True");

            username = usertxt.Text;
            user_passowrd = passtxt.Text;


            try
            {
                String querry = "SELECT * FROM Login WHERE username = '" + usertxt.Text + "' AND password = '" + passtxt.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = usertxt.Text;
                    user_passowrd = passtxt.Text;


                    //next screen

                    Form6 fr6 =  new Form6();
                    fr6.Show();
                    this.Hide();
                    button2.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid details", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passtxt.Clear();
                    usertxt.Clear();
                }

            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
