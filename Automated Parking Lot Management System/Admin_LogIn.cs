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
    public partial class Admin_LogIn : Form
    {
        public Admin_LogIn()
        {
            InitializeComponent();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            DbConnector db=new DbConnector();
            SqlConnection con=new SqlConnection(db.strCon);
            con.Open();
            string query = "select userName,password from users where userName='" + userName.Text + "' and password='" + password.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.Close();
                Admin_Dashboard admin_Dashboard = new Admin_Dashboard();
                admin_Dashboard.Show();
            }
            else
            {
                MessageBox.Show("Inavalid User Name Or Password!");
            }
        }

        
    }
}
