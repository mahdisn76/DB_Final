using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDB
{
    public partial class frm_buy_ticket : Form
    {
        public frm_buy_ticket()
        {
            InitializeComponent();
        }

        private void frm_buy_ticket_Load(object sender, EventArgs e)
        {
            string connetionString = "Server=localhost;" +
                              "DataBase=hotel;" +
                              "Trusted_Connection=Yes;";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT distinct start_point \n" +
                                  "FROM Travels \n";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cnn.Open();

                reader = cmd.ExecuteReader();

                cmb_start.Items.Clear();
                while (reader.Read())
                {
                    cmb_start.Items.Add(reader[0]);
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();

            string connetionString = "Server=localhost;" +
                              "DataBase=hotel;" +
                              "Trusted_Connection=Yes;";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT v_id, v_type, t_time, price, r_capacity \n" +
                                  "FROM Travels join Vehicles on (Travels.v_id = Vehicles.id) \n" +
                                  "WHERE start_point=\'" + cmb_start.SelectedItem.ToString() + "\' and " +
                                  "destination=\'" + cmb_dest.SelectedItem.ToString() + "\' and " +
                                  "t_date=\'" + dtp_date.Value.ToString("yyyy-MM-dd") + "\'";
                //MessageBox.Show(cmd.CommandText);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cnn.Open();

                reader = cmd.ExecuteReader();

                //IDataRecord result = ((IDataRecord)reader);

                while (reader.Read())
                {
                    if(int.Parse(reader[4].ToString()) > 0 )
                        dgv.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], "Buy");
                }
            }


        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0 && e.RowIndex<dgv.Rows.Count-1)
            {
                int v_id = int.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                string date, time;
                date = dtp_date.Value.ToString("yyyy-MM-dd");
                time = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();


                string connectionString = null;
                string Query = null;

                connectionString = "Server=localhost;" +
                                  "DataBase=hotel;" +
                                  "Trusted_Connection=Yes;";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();


                    Query = "insert into tickets values("
                        + GlobalVariables.id + " , "
                        + v_id + " , "
                        + "\'" + date + "\' , "
                        + "\'" + time + "\'"
                        + ")";
                    //MessageBox.Show(Query);
                    using (SqlCommand cmd = new SqlCommand(Query, cnn))
                    {
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("You have bought the Ticket successfully.");
                    }

                    Query = "update travels set r_capacity -= 1 where v_id = " + v_id + " and t_date=\'" + date + "\' and t_time=\'"+time+"\'";
                    using (SqlCommand cmd = new SqlCommand(Query, cnn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You have bought the Ticket successfully.");

                        dgv.Rows.Clear();
                        cmb_dest.Text = "";
                        cmb_start.Text = "";
                    }


                }
                

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void cmb_start_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_dest.Text = "";

            string connetionString = "Server=localhost;" +
                              "DataBase=hotel;" +
                              "Trusted_Connection=Yes;";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT distinct destination \n" +
                                  "FROM Travels \n" +
                                  "WHERE start_point=\'" + cmb_start.SelectedItem.ToString() + "\'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cnn.Open();

                reader = cmd.ExecuteReader();

                cmb_dest.Items.Clear();
                while (reader.Read())
                {
                    cmb_dest.Items.Add(reader[0]);
                }
            }
        }
    }
}
