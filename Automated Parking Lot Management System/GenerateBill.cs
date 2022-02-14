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
    public partial class GenerateBill : Form
    {
        public GenerateBill()
        {
            InitializeComponent();
        }
        public static string spendTime;
        public static string in_time;
        public static string out_time;
        public static string slotNo;
        public static string charge;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBarCode.Text == "")
            {
                MessageBox.Show("Enter The Barcode First");
            }
            else
            {
                try
                {
                    DbConnector db = new DbConnector();
                    SqlConnection con = new SqlConnection(db.strCon);
                    con.Open();
                    string query = "update Park_Details set out_time='"+DateTime.Now.ToString("h: mm: ss tt")+ "',out_date=cast(getdate() as date) where barcodeNo=" + txtBarCode.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    query = @"select *,
case
	when DATEDIFF(MINUTE, in_time,out_time)>0 then  
		case
			when DATEDIFF(day,date,out_date)>0 then concat(DATEDIFF(day,date,out_date),' day ',DATEDIFF(MINUTE, in_time,out_time)/60,' hour ',DATEDIFF(MINUTE, in_time,out_time)%60,' minitue ')
			else concat('0 day ',DATEDIFF(MINUTE, in_time,out_time)/60,' hour ',DATEDIFF(MINUTE, in_time,out_time)%60,' minitue ')
		end
	when DATEDIFF(MINUTE, in_time,out_time)<0 then  
		case
			when DATEDIFF(day,date,out_date)>0 then concat(DATEDIFF(day,date,out_date),' day ',DATEDIFF(MINUTE, in_time,out_time)/60*-1,' hour ',DATEDIFF(MINUTE, in_time,out_time)%60*-1,' minitue ')
			else concat('0 day ',DATEDIFF(MINUTE, in_time,out_time)/60*-1,' hour ',DATEDIFF(MINUTE, in_time,out_time)%60*-1,' minitue ')
		end
	else NULL
end AS Spend_Time,
case
	when DATEDIFF(MINUTE, in_time,out_time)>0 then 
		(case 
			when DATEDIFF(MINUTE, in_time,out_time)%60>15 then DATEDIFF(day,date,out_date)*24*50+DATEDIFF(MINUTE, out_time,in_time)/60*50+50 
			else DATEDIFF(day,date,out_date)*50+DATEDIFF(MINUTE, in_time,out_time)/60*50
		end)
	else
		(case 
			when DATEDIFF(MINUTE, in_time,out_time)*-1%60>15 then DATEDIFF(day,date,out_date)*24*50+DATEDIFF(MINUTE, out_time,in_time)/60*50+50 
			else DATEDIFF(day,date,out_date)*24*50+DATEDIFF(MINUTE, in_time,out_time)*-1/60*50
		end)
end AS 'Charged(Rs.)' from Park_Details where barcodeNo=" + txtBarCode.Text + "; ";
                    
                    cmd = new SqlCommand(query, con);
                    SqlDataReader reader= cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        spendTime = reader["Spend_Time"].ToString();
                        charge = reader["Charged(Rs.)"].ToString();
                        in_time = reader["in_time"].ToString();
                        out_time = DateTime.Now.ToString("h: mm: ss tt");
                        slotNo = reader["slotNo"].ToString();
                        Bill bill = new Bill();
                        bill.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Barcode No");
                    }
                    
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message);
                }
                
            }
        }
    }
}
