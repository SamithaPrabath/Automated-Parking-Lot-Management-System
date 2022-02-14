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
    public partial class Current_Status : Form
    {
        public Current_Status()
        {
            InitializeComponent();
        }

        private void Current_Status_Load(object sender, EventArgs e)
        {
            DbConnector db=new DbConnector();
            SqlConnection con = new SqlConnection(db.strCon);
            con.Open();
            string query = "select slotNo from Slot_Details where availability='UnAvailable';";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int no = Convert.ToInt32(reader["slotNo"].ToString());
                switch (no)
                {
                    case 1:
                        slot1.BackColor = System.Drawing.Color.Red;
                        break;
                    case 2:
                        slot2.BackColor = System.Drawing.Color.Red;
                        break;
                    case 3:
                        slot3.BackColor = System.Drawing.Color.Red;
                        break;
                    case 4:
                        slot4.BackColor = System.Drawing.Color.Red;
                        break;
                    case 5:
                        slot5.BackColor = System.Drawing.Color.Red;
                        break;
                    case 6:
                        slot6.BackColor = System.Drawing.Color.Red;
                        break;
                    case 7:
                        slot7.BackColor = System.Drawing.Color.Red;
                        break;
                    case 8:
                        slot8.BackColor = System.Drawing.Color.Red;
                        break;
                    case 9:
                        slot9.BackColor = System.Drawing.Color.Red;
                        break;
                    case 10:
                        slot10.BackColor = System.Drawing.Color.Red;
                        break;
                    case 11:
                        slot11.BackColor = System.Drawing.Color.Red;
                        break;
                    case 12:
                        slot12.BackColor = System.Drawing.Color.Red;
                        break;
                    case 13:
                        slot13.BackColor = System.Drawing.Color.Red;
                        break;
                    case 14:
                        slot14.BackColor = System.Drawing.Color.Red;
                        break;
                    case 15:
                        slot15.BackColor = System.Drawing.Color.Red;
                        break;
                    case 16:
                        slot16.BackColor = System.Drawing.Color.Red;
                        break;
                    case 17:
                        slot17.BackColor = System.Drawing.Color.Red;
                        break;
                    case 18:
                        slot18.BackColor = System.Drawing.Color.Red;
                        break;
                    default:
                        break;


                }
                
            }
            reader.Close();
            query = "select slotNo from Slot_Details where availability='Available';";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int no = Convert.ToInt32(reader["slotNo"].ToString());
                string panelName = "slot" + no;
                switch (no)
                {
                    case 1:
                        slot1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 2:
                        slot2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 3:
                        slot3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 4:
                        slot4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 5:
                        slot5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 6:
                        slot6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 7:
                        slot7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 8:
                        slot8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 9:
                        slot9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 10:
                        slot10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 11:
                        slot11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 12:
                        slot12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 13:
                        slot13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 14:
                        slot14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 15:
                        slot15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 16:
                        slot16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 17:
                        slot17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    case 18:
                        slot18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        break;
                    default:
                        break;


                }

            }
            reader.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Current_Status current_Status = new Current_Status();
            this.Close();
            current_Status.Show();
        }
    }
}
