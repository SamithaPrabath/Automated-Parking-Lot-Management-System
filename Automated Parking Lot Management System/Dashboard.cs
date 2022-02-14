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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicketGenration tk  = new TicketGenration(); 
            tk.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateBill generateBill = new GenerateBill();
            generateBill.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_LogIn admin_LogIn = new Admin_LogIn();
            admin_LogIn.Show();
        }
    }
}
