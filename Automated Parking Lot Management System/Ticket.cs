using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using System.Data.SqlClient;

namespace Automated_Parking_Lot_Management_System
{
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            string barcodeNo="";
            lblTime.Text = DateTime.Now.ToString("h:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DbConnector db = new DbConnector();
            SqlConnection con = new SqlConnection(db.strCon);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string slotNo="";
                string query = "select slotNo from Slot_Details where availability='Available' order by slotNo OFFSET 0 ROWS FETCH FIRST 1 ROWS ONLY;";
                SqlCommand cmd=new SqlCommand(query, con);
                SqlDataReader reader=cmd.ExecuteReader();
                while (reader.Read())
                {
                    slotNo = reader["slotNo"].ToString();
                    lblSlotNo.Text = slotNo;
                }
                reader.Close();
                try
                {
                    query = "insert into Park_Details(slotNo,date,in_time) values('" + lblSlotNo.Text + "','" + lblDate.Text + "','" + lblTime.Text + "');";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    query = "update Slot_Details set availability='UnAvailable' where slotNo="+slotNo+";";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    query = "select barcodeNo from Park_Details order by barcodeNo desc OFFSET 0 ROWS FETCH FIRST 1 ROWS ONLY;";
                    cmd = new SqlCommand(query, con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        barcodeNo = reader["barcodeNo"].ToString();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
                reader.Close();
                con.Close();


            }

            BarcodeWriter writer = new BarcodeWriter() { Format=BarcodeFormat.CODE_128};
            try
            {
                picBarCode.Image = writer.Write(barcodeNo);
            }
            catch(Exception ex)
            {
                picBarCode.Image = writer.Write("12345678");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing..........");
            TicketGenration tg = new TicketGenration();
            this.Close();
            tg.Visible = true;
           
        }
    }
}
