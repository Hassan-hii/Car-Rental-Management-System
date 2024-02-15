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
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter full data");

            }
            else
            {
                int Regno = int.Parse(textBox1.Text);
                string Brand = textBox2.Text;
                string Model = textBox3.Text;
                string Price = textBox4.Text;
                string Availble = comboBox1.Text;
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "Insert into CarTbl(RegNo,Brand,Model,Available,Price)values('" + Regno + "', '" + Brand + "','" + Model + "','" + Availble + "','"+Price+"')";
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

                string query = "SELECT * FROM CarTbl";
                SqlCommand md = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(md);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Enter Id");
            }
            else
            {

                int Regno = int.Parse(textBox1.Text);
                string Brand = textBox2.Text;
                string Model = textBox3.Text;
                string Price = textBox4.Text;
                string Availble = comboBox1.Text;


                
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "update CarTbl set Brand='" + Brand + "',Model='" + Model+ "',Price='" + Price+ "',Available='" + Availble + "'  where RegNo='" + Regno + "'";
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

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Id");
            }
            else
            {
                int Regno= int.Parse(textBox1.Text);
                string NAME = textBox2.Text;
                string PASSWORD = textBox3.Text;
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "delete from CarTbl where RegNo='" +Regno  + "';";
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

                string query = "SELECT * FROM CarTbl";
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
            string query = "SELECT * FROM CarTbl";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}