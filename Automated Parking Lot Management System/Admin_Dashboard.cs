using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automated_Parking_Lot_Management_System
{
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Current_Status current_Status = new Current_Status();
            current_Status.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Current_Status current_Status = new Current_Status();
            current_Status.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }
    }
}
