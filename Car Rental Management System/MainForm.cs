using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Management_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Return re = new Return();
            re.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rental r = new Rental();
            r.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashboardd db = new Dashboardd();
            db.Show();
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
