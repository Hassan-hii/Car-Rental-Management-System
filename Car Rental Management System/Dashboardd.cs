using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Management_System
{
    public partial class Dashboardd : Form
    {
        public Dashboardd()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Dashboardd_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) FROM CustomerTbl";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label4.Text = dt.Rows[0][0].ToString();
            con.Close();
           

            string Query = "SELECT COUNT(*) FROM UserTbl";
            con.Open();
            SqlDataAdapter sdaa = new SqlDataAdapter(Query, con);
            DataTable dtt = new DataTable();
            sdaa.Fill(dtt);
            label6.Text = dtt.Rows[0][0].ToString();
            con.Close();
           
            string Quuery = "SELECT COUNT(*) FROM CarTbl";
            con.Open();
            SqlDataAdapter sdaaa = new SqlDataAdapter(Quuery, con);
            DataTable dttt = new DataTable();
            sdaaa.Fill(dttt);
            label2.Text = dttt.Rows[0][0].ToString();
            con.Close();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }
    }
}
