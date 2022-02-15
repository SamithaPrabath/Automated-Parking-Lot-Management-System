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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            DbConnector db = new DbConnector();
            SqlConnection conn = new SqlConnection(db.strCon);
            conn.Open();
			string query = @"select *,
case
	when DATEDIFF(MINUTE, in_time, out_time)> 0 then
		case
			when DATEDIFF(day, date, out_date)> 0 then concat(DATEDIFF(day, date, out_date),' day ',DATEDIFF(MINUTE, in_time, out_time) / 60,' hour ',DATEDIFF(MINUTE, in_time, out_time) % 60,' minitue ')
			else concat('0 day ', DATEDIFF(MINUTE, in_time, out_time) / 60, ' hour ', DATEDIFF(MINUTE, in_time, out_time) % 60, ' minitue ')
		end
	when DATEDIFF(MINUTE, in_time, out_time) < 0 then
		case
			when DATEDIFF(day, date, out_date)> 0 then concat(DATEDIFF(day, date, out_date),' day ',DATEDIFF(MINUTE, in_time, out_time) / 60 * -1,' hour ',DATEDIFF(MINUTE, in_time, out_time) % 60 * -1,' minitue ')
			else concat('0 day ', DATEDIFF(MINUTE, in_time, out_time) / 60 * -1, ' hour ', DATEDIFF(MINUTE, in_time, out_time) % 60 * -1, ' minitue ')
		end
	else NULL
end AS Spend_Time,
case
	when DATEDIFF(MINUTE, in_time, out_time)> 0 then
		  (case 
			when DATEDIFF(MINUTE, in_time, out_time) % 60 > 15 then DATEDIFF(day, date, out_date) * 24 * 50 + DATEDIFF(MINUTE, out_time, in_time) / 60 * 50 + 50
			else DATEDIFF(day, date, out_date) * 50 + DATEDIFF(MINUTE, in_time, out_time) / 60 * 50
		end)
	else
				(case 
			when DATEDIFF(MINUTE, in_time, out_time)*-1 % 60 > 15 then DATEDIFF(day, date, out_date)*24 * 50 + DATEDIFF(MINUTE, out_time, in_time) / 60 * 50 + 50
			else DATEDIFF(day, date, out_date) * 24 * 50 + DATEDIFF(MINUTE, in_time, out_time) * -1 / 60 * 50
		end)
end AS 'Charged(Rs.)' from Park_Details; ";
            SqlCommand comd=new SqlCommand(query, conn);
            SqlDataAdapter da=new SqlDataAdapter(comd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            table.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
			dateTo.Value.ToString("yyyy-MM-dd");
			DbConnector db = new DbConnector();
			SqlConnection conn = new SqlConnection(db.strCon);
			conn.Open();
			string query = @"select *,
case
	when DATEDIFF(MINUTE, in_time, out_time)> 0 then
		case
			when DATEDIFF(day, date, out_date)> 0 then concat(DATEDIFF(day, date, out_date),' day ',DATEDIFF(MINUTE, in_time, out_time) / 60,' hour ',DATEDIFF(MINUTE, in_time, out_time) % 60,' minitue ')
			else concat('0 day ', DATEDIFF(MINUTE, in_time, out_time) / 60, ' hour ', DATEDIFF(MINUTE, in_time, out_time) % 60, ' minitue ')
		end
	when DATEDIFF(MINUTE, in_time, out_time) < 0 then
		case
			when DATEDIFF(day, date, out_date)> 0 then concat(DATEDIFF(day, date, out_date),' day ',DATEDIFF(MINUTE, in_time, out_time) / 60 * -1,' hour ',DATEDIFF(MINUTE, in_time, out_time) % 60 * -1,' minitue ')
			else concat('0 day ', DATEDIFF(MINUTE, in_time, out_time) / 60 * -1, ' hour ', DATEDIFF(MINUTE, in_time, out_time) % 60 * -1, ' minitue ')
		end
	else NULL
end AS Spend_Time,
case
	when DATEDIFF(MINUTE, in_time, out_time)> 0 then
		  (case 
			when DATEDIFF(MINUTE, in_time, out_time) % 60 > 15 then DATEDIFF(day, date, out_date) * 24 * 50 + DATEDIFF(MINUTE, out_time, in_time) / 60 * 50 + 50
			else DATEDIFF(day, date, out_date) * 50 + DATEDIFF(MINUTE, in_time, out_time) / 60 * 50
		end)
	else
				(case 
			when DATEDIFF(MINUTE, in_time, out_time)*-1 % 60 > 15 then DATEDIFF(day, date, out_date)*24 * 50 + DATEDIFF(MINUTE, out_time, in_time) / 60 * 50 + 50
			else DATEDIFF(day, date, out_date) * 24 * 50 + DATEDIFF(MINUTE, in_time, out_time) * -1 / 60 * 50
		end)
end AS 'Charged(Rs.)' from Park_Details where date between '"+dateFrom.Value.ToString("yyyy-MM-dd")+ "' and '" + dateTo.Value.ToString("yyyy-MM-dd") + "'; ";
			SqlCommand comd = new SqlCommand(query, conn);
			SqlDataAdapter da = new SqlDataAdapter(comd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			table.DataSource = dt;

		}
    }
}
