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
    public partial class Form2 : Form
    {

        
        public Form2()
        {
            InitializeComponent();
        }

        
        SqlConnection conn = new SqlConnection(@"Data Source=ATHARVA-PC;Initial Catalog=Login;Integrated Security=True");

       
       
        private void button1_Click_1(object sender, EventArgs e)
        {

            
        }


        
        private void Form2_Load(object sender, EventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            String username, user_passowrd;

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

                    Form3 formn = new Form3();
                    formn.Show();
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

        private void usertxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
