using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TO DO check login username and password
            SqlConnection con = new SqlConnection("Data Source=kacpg;Initial Catalog=stock;Integrated Security=True;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * 
                FROM[stock].[dbo].[Login] Where UserName = '" + textBox1.Text +"' and Password = '"+ textBox2.Text + "'", con);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                    this.Hide();
                    Magazyn main = new Magazyn();
                    main.Show(); 
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password","Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
        }
    }
}
