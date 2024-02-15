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
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True");
        private void combofill()
        {

            con.Open();
            string query = "select  RegNo from CarTbl where Available='" + "YES" + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNo", typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "RegNo";
            comboBox1.DataSource = dt;
            con.Close();
        }
        private void comboofill()
        {

            con.Open();
            string query = "select  cusid from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("cusid", typeof(string));
            dt.Load(rdr);
            comboBox2.ValueMember = "cusid";
            comboBox2.DataSource = dt;
            con.Close();
        }
        public void fetchcustomer()
        {

            con.Open();
            string query = "select * from CustomerTbl where cusid='" + comboBox2.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox4.Text = dr["Cusname"].ToString();

            }
            con.Close();


        }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True");


            string query = "SELECT * FROM RentalTbl";
            SqlCommand md = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(md);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            combofill();
            comboofill();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchcustomer();

        }
        private void populate()
        {
            con.Open();
            string Query = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
        private void Updaterent()
        {

            int Regno = int.Parse(textBox1.Text);


            string Price = textBox4.Text;
            string Availble = comboBox1.Text;
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "update CarTbl set  Available='" + "No" + "' where RegNo='" + comboBox1.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        private void Updatedelrent()
        {

            int Regno = int.Parse(textBox1.Text);


            string Price = textBox4.Text;
            string Availble = comboBox1.Text;
            string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "update CarTbl set  Available='" + "YES" + "' where RegNo='" + comboBox1.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            cmd.ExecuteNonQuery();
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
                int Cussid = int.Parse(textBox1.Text);
                string CusReg = comboBox1.Text;
                string Cusid = comboBox2.Text;
                string cusname = textBox4.Text;
                string name = textBox4.Text;
                string rentaldat = dateTimePicker1.Text;
                string returndat = dateTimePicker2.Text;
                string Fee = textBox5.Text;




                SqlConnection con = new SqlConnection(connectionString);
                string Query = "Insert into RentalTbl(RentId,CarReg,Cusname,Rentdate,Returndate,Rentfee) values('" + Cussid + "', '" + CusReg + "','" + cusname + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + Fee + "')";
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

            string query = "SELECT * FROM RentalTbl";
            SqlCommand md = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(md);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            Updaterent();
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
                int Cussid = int.Parse(textBox1.Text);
                string CusReg = comboBox1.Text;
                string Cusid = comboBox2.Text;
                string cusname = textBox4.Text;
                string name = textBox4.Text;
                string rentaldat = dateTimePicker1.Text;
                string returndat = dateTimePicker2.Text;
                string Fee = textBox5.Text;




                SqlConnection con = new SqlConnection(connectionString);
                string Query = "Delete from RentalTbl where RentId='" + Cussid + "'";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("data deleted");
                    Updatedelrent();

                }
                else if (i == 0)
                {
                    MessageBox.Show("deleion failed");
                }
            }

            SqlConnection conn = new SqlConnection(connectionString);

            string query = "SELECT * FROM RentalTbl";
            SqlCommand md = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(md);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Enter Id");
            }
            else
            {
                int ID = int.Parse(textBox1.Text);
                string carreg = comboBox1.Text;
                string cusid = comboBox2.Text;
                string name = textBox4.Text;
                string fee = textBox5.Text;
                string rentdate = dateTimePicker1.Text;
                string returndate = dateTimePicker2.Text;
                string connectionString = @"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ";
                SqlConnection con = new SqlConnection(connectionString);
                string Query = "update RentalTbl set CarReg='" + carreg + "',Cusid='" + cusid + "',Cusname='" + name + "',Rentfee='" + fee + "',Rentdate='" + rentdate + "',Returndate='" + returndate + "'  where RentId='" + ID + "'";
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

}
