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
    public partial class frm_reserve_hotel : Form
    {
        public frm_reserve_hotel()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            int nights, beds;
            if (!int.TryParse(txt_beds.Text, out beds))
            {
                MessageBox.Show("enter number in beds field");
                return;
            }

            if (!int.TryParse(txt_nights.Text, out nights))
            {
                MessageBox.Show("enter number in nights field");
                return;
            }

            string date = dtp.Value.ToString("yyyy-MM-dd");



            dgv.Rows.Clear();

            string connetionString = "Server=localhost;" +
                              "DataBase=hotel;" +
                              "Trusted_Connection=Yes;" +
                              "MultipleActiveResultSets=true";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;


                //CORRECT BEFORE TODO CHANGES *******************************************************************
                cmd.CommandText = "SELECT name, Hotels.id, Rooms.id, bed_type, price\n" +
                                  "FROM Rooms join Hotels on (Hotels.id=rooms.h_id) \n" +
                                  "WHERE country=\'" + cmb_country.SelectedItem.ToString() + "\' and " +
                                  "city=\'" + cmb_city.SelectedItem.ToString() + "\' and " +
                                  "bed_num=" + beds;
                //***********************************************************************************************


                //cmd.CommandText = "SELECT name, Hotels.id, Rooms.id, bed_type, price\n" +
                //  "FROM Rooms join Hotels on (Hotels.id=rooms.h_id) \n" +
                //  "WHERE country=\'" + cmb_country.SelectedItem.ToString() + "\' and " +
                //  "city=\'" + cmb_city.SelectedItem.ToString() + "\' and " +
                //  "bed_num=" + beds ;


                ////@TODO check if the room is availble for that period ...

                ////MessageBox.Show(cmd.CommandText);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cnn.Open();

                reader = cmd.ExecuteReader();

                //bool start_date_exist = false, end_date_exist = false;
                //DateTime start_date = new DateTime(), end_date = new DateTime();

                //while (reader.Read())
                //{
                //    int h_id = int.Parse(reader[1].ToString());
                //    int r_id = int.Parse(reader[2].ToString());

                //    using (SqlCommand Query = new SqlCommand()) // this query is for finding the biggest date less than user's reservation date
                //    {
                //        SqlDataReader reader2;
                //        Query.CommandText = "SELECT top 1 enterance_date, nights_count \n" +
                //                "FROM reservations \n" +
                //                "WHERE enterance_date <= \'" + date +"\' \n" + 
                //                "ORDER BY enterance_date desc";
                //        Query.CommandType = CommandType.Text;
                //        Query.Connection = cnn;
                //        reader2 = Query.ExecuteReader();
                //        if(reader2.Read())
                //        {
                //            start_date_exist = true;
                //            start_date = Convert.ToDateTime(reader2[0].ToString());
                //            start_date = start_date.AddDays(int.Parse(reader2[1].ToString()));
                //        }

                //    }

                //    using (SqlCommand Query = new SqlCommand())
                //    {
                //        SqlDataReader reader2;
                //        Query.CommandText = "SELECT min(enterance_date) \n" +
                //                            "FROM reservations \n" +
                //                            "WHERE enterance_date > \'" + date + "\'";
                //        Query.CommandType = CommandType.Text;
                //        Query.Connection = cnn;
                //        reader2 = Query.ExecuteReader();
                //        if (reader2.Read())
                //        {
                //            MessageBox.Show(reader2[0].ToString());
                //            end_date_exist = true;
                //            end_date = Convert.ToDateTime(reader2[0].ToString());
                //        }

                //        if (((start_date_exist) && start_date < dtp.Value) && ((end_date_exist) && end_date > dtp.Value.AddDays(nights)))

                while(reader.Read())
                    dgv.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], "Reserve");
                
                
                
                //    }
                //}
            }




        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0 && e.RowIndex < dgv.Rows.Count-1)
            { 
                int u_id = GlobalVariables.id;
                int r_id = int.Parse(dgv.Rows[e.RowIndex].Cells[2].Value.ToString());
                string date = dtp.Value.ToString("yyyy-MM-dd");
                int night_count;
                if (!int.TryParse(txt_nights.Text, out night_count))
                {
                    MessageBox.Show("enter number in #nights field");
                    return;
                }
                float price = float.Parse(dgv.Rows[e.RowIndex].Cells[4].Value.ToString());
                int h_id = int.Parse(dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                
                string connectionString = "Server=localhost;" +
                                          "DataBase=hotel;" +
                                          "Trusted_Connection=Yes;";

                string Query;

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();


                    Query = "insert into reservations values("
                        + h_id          + ", "
                        + u_id          + ", "
                        + r_id          + ", "
                 + "\'" + date          + "\', "
                        + night_count   + ", "
                        + price         + ")";
                    using (SqlCommand cmd = new SqlCommand(Query, cnn))
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("You have reserved the room successfully.");
                            
                            //clean the from
                            dgv.Rows.Clear();
                            foreach(var cntrl in this.Controls)
                            {
                                if (cntrl is TextBox)
                                    ((TextBox)cntrl).Text = "";
                            }
                            //-------
                        }
                        catch(Exception ee)
                        {
                            MessageBox.Show(ee.Message);
                        }
                    }

                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frm_reserve_hotel_Load(object sender, EventArgs e)
        {
            string connetionString = "Server=localhost;" +
                              "DataBase=hotel;" +
                              "Trusted_Connection=Yes;";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT distinct country \n" +
                                  "FROM Hotels \n";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cnn.Open();

                reader = cmd.ExecuteReader();

                cmb_country.Items.Clear();
                while (reader.Read())
                {
                    cmb_country.Items.Add(reader[0]);
                }
            }
        }

        private void cmb_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_city.Text = "";
            string connetionString = "Server=localhost;" +
                              "DataBase=hotel;" +
                              "Trusted_Connection=Yes;";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT distinct city \n" +
                                  "FROM Hotels \n" +
                                  "WHERE country = \'" + cmb_country.SelectedItem.ToString() + "\'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cnn.Open();

                reader = cmd.ExecuteReader();

                cmb_city.Items.Clear();
                while (reader.Read())
                {
                    cmb_city.Items.Add(reader[0]);
                }
            }
        }
    }
}
