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
    public partial class Login : Form
    {
       
        
      
        public Login()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-46DSQO6\SQLEXPRESS;Initial Catalog=Rental;Integrated Security=True ");
            
                
                string name = textBox1.Text;
                string pass = maskedTextBox1.Text;
                string showQuery = "SELECT COUNT(*) FROM UserTbl WHERE Username='"+name+"' AND Userpass= '"+pass+"' ";
            con.Open();
            
         

            SqlDataAdapter adapter = new SqlDataAdapter(showQuery,con);


            DataTable dt = new DataTable();
            adapter.Fill(dt);
           // int  rows = cmd.ExecuteNonQuery();
                        if (dt.Rows[0][0].ToString() == "1") { 
                MainForm mf = new MainForm();
            mf.Show();
                this.Hide();
            }


        
                        else {
                MessageBox.Show("wrong id or pass");
              
            }
            con.Close();







        }

        

        private void Login_Load(object sender, EventArgs e)
        {

        }

      
    }
}
