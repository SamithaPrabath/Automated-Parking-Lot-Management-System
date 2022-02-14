using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Automated_Parking_Lot_Management_System
{
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            GenerateBill gb = new GenerateBill();
            lblTime.Text = GenerateBill.out_time;
            lblDate.Text = DateTime.Now.ToString("yyyy-MMM-dd");

            
            lblSpendTime.Text = GenerateBill.spendTime;
            txtAmount.Text = "Rs. "+GenerateBill.charge;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DbConnector db = new DbConnector();
                SqlConnection con = new SqlConnection(db.strCon);
                con.Open();
                MessageBox.Show("Your Bill is printing......");
                string query = "update Slot_Details set availability='Available' where slotNo="+GenerateBill.slotNo+";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
