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
    public partial class User : Form
    {
        public object Rows { get; private set; }

        public User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter full data");

            }
            else
            {
                int ID = int.Parse(textBox1.Text);
                string NAME = textBox2.Text;
                string PASSWORD = textBox3.Text;
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "Insert into UserTbl(Id,Username,Userpass)values('" + ID + "','" + NAME + "','" + PASSWORD + "')";
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

                string query = "SELECT * FROM UserTbl";
                SqlCommand md = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(md);
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
                int ID = int.Parse(textBox1.Text);
                string NAME = textBox2.Text;
                string PASSWORD = textBox3.Text;
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "delete from UserTbl where Id='" + ID + "';";
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

                string query = "SELECT * FROM UserTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();


        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM UserTbl";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
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
                string Query = "update UserTbl set Username='" + NAME + "',Userpass='" + PASSWORD + "' where Id='" + ID + "';";
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

                string query = "SELECT * FROM UserTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}