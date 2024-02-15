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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            if (textBox1.Text == "") {
                MessageBox.Show("Enter complete data");
            }
            else {
                int Cussid = int.Parse(textBox1.Text);
                string Cussname = textBox2.Text;
                string Cussadd = textBox3.Text;
                string Phone = textBox4.Text;

                
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "Insert into CustomerTbl(Cusid,Cusname,Cusadd,Phone)values('" + Cussid + "', '" + Cussname + "','" + Cussadd + "','" + Phone + "')";
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

            string query = "SELECT * FROM CustomerTbl";
            SqlCommand md = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(md);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == ""||textBox2.Text==""||textBox3.Text==""||textBox4.Text=="")
            {
                MessageBox.Show("Enter Id");
            }
            else
            {
                int ID = int.Parse(textBox1.Text);
                string NAME = textBox2.Text;
                string PASSWORD = textBox3.Text;
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "update CustomerTbl set Cusname='" + NAME + "',Cusadd='" + PASSWORD + "' where Cusid='" + ID + "';";
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

                string query = "SELECT * FROM CustomerTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Id");
            }
            else
            {
                int Cussid = int.Parse(textBox1.Text);
                string NAME = textBox2.Text;
                string PASSWORD = textBox3.Text;
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "delete from CustomerTbl where Cusid='" + Cussid + "';";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("data deleted");

                }
                else if (i == 0)
                {
                    MessageBox.Show("Deletion Failed ");
                }

                string query = "SELECT * FROM CustomerTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}