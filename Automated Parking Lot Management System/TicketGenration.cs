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
    public partial class TicketGenration : Form
    {
        public TicketGenration()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            txtTime.Text = time;
            int availbleQty = 0;
            DbConnector db=new DbConnector();
            SqlConnection con = new SqlConnection(db.strCon);
            con.Open();
            try
            {
                string query = "select count(slotNo)as availbleQty from Slot_Details where availability='Available';";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    availbleQty = Convert.ToInt32(reader["availbleQty"].ToString());
                    
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if (availbleQty > 0)
            {
                lblAvailability.Text = "There are " +availbleQty.ToString()+" slots are availble";
                btnGenarate.Enabled = true;
            }
            else
            {
                lblAvailability.Text = "Sorry! Park is Full \nCome again for a while";
                btnGenarate.Enabled = false;
            }
        }

        private void btnGenarate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Ticket is genarating............");
            Ticket tkt = new Ticket();

            this.Visible = false;
            tkt.Visible = true;
        }

        
    }
}
