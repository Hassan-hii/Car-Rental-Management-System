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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            string query = "SELECT * FROM RentalTbl";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand md = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(md);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter complete data");
            }
            else
            {
                int Rid = int.Parse(textBox1.Text);
                string CarReg = textBox2.Text;
                string Cusid = textBox6.Text;
                string delay = textBox4.Text;


                string returndat = dateTimePicker1.Text;

                string Fine = textBox5.Text;




                SqlConnection con = new SqlConnection(connectionString);
                string Query = "Insert into ReturnTbl(Returnid,CarReg,ReturnDate,Fine,CustId) values('" + Rid + "', '" + CarReg + "','" + dateTimePicker1.Text + "','" + Fine + "','" + Cusid + "')";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("data inserted");

                }
                else if (i == 0)
                {
                    MessageBox.Show("Insertion failed");
                }
            }

            SqlConnection conn = new SqlConnection(connectionString);

            string query = "SELECT * FROM ReturnTbl";
            SqlCommand md = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(md);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            SqlConnection conn = new SqlConnection(connectionString);

            string query = "SELECT * FROM ReturnTbl";
            SqlCommand md = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(md);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Enter Id");
            }
            else
            {
                int Rid = int.Parse(textBox1.Text);
                string custid = textBox5.Text;
                string CarReg = textBox2.Text;
                string Cusname = textBox4.Text;
                string delay = textBox4.Text;


                string returndat = dateTimePicker1.Text;

                string Fine = textBox6.Text;
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "update ReturnTbl set CarReg='" + CarReg + "',CustId='" + custid + "'',Fine='" + Fine + "',Delay='" + delay + "',Rentdate='" + returndat + "'  where ReturnId='" + Rid + "'";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Data Updated");

                }
                else if (i == 0)
                {
                    MessageBox.Show("Update Unsuccessfull ");
                }

                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter complete data");
            }
            else
            {
                int Renturnid = int.Parse(textBox1.Text);





                SqlConnection con = new SqlConnection(connectionString);
                string Query = "Delete from ReturnTbl where Returnid='" + Renturnid+ "'";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("data deleted");


                }
                else if (i == 0)
                {
                    MessageBox.Show("deleion failed");
                }
            }
        }
    }
}