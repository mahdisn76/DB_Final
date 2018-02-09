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
    public partial class frm_add_travel : Form
    {
        public frm_add_travel()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int v_id;
            float price;
            if (!int.TryParse(cmb_v_id.SelectedItem.ToString().Split('-')[0].Trim(), out v_id)) //sample: "123 - Bus - 30" -> 30 is capacity
            {
                MessageBox.Show("enter a number for v_id");
                return;
            }
            if (!float.TryParse(txt_price.Text, out price))
            {
                MessageBox.Show("enter a number for price");
                return;
            }

            string connectionString = null;
            string Query = null;


            connectionString = "Server=localhost;" +
                               "DataBase=hotel;" +
                               "Trusted_Connection=Yes;" +
                               "MultipleActiveResultSets=true";

            string sqldataformat = dtp_date.Value.ToString("yyyy/MM/dd");
            //MessageBox.Show(sqldataformat);
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                try
                {
                    string capacity = "";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlDataReader reader;

                        cmd.CommandText = "SELECT capacity \n" +
                                "FROM Vehicles \n" +
                                "WHERE id = " + v_id + ";";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cnn;
                        //MessageBox.Show(cmd.CommandText);
                        reader = cmd.ExecuteReader();

                        IDataRecord result = ((IDataRecord)reader);

                        while (reader.Read())
                            capacity = reader[0].ToString();

                    }


                    Query = "insert into travels values (" +
                                   v_id + ", " +
                                  +price + ", " +
                            "\'" + txt_startPoint.Text + "\', " +
                            "\'" + txt_destination.Text + "\', " +
                            "\'" + sqldataformat + "\', " +
                            "\'" + txt_time.Text + "\'," +
                            "\'" + capacity + "\')";
                    using (SqlCommand cmd = new SqlCommand(Query, cnn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New Travel added");
                        foreach (var ctrl in Controls)
                        {
                            if (ctrl is TextBox)
                                ((TextBox)ctrl).Clear();
                        }
                        cmb_v_id.Text = "";
                    }

                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }

        }

        private void frm_add_travel_Load(object sender, EventArgs e)
        {
            string connetionString = "Server=localhost;" +
                              "DataBase=hotel;" +
                              "Trusted_Connection=Yes;";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT id, v_type, capacity \n" +
                                  "FROM Vehicles \n" +
                                  "ORDER BY v_type";

                //MessageBox.Show(cmd.CommandText);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cnn.Open();

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    cmb_v_id.Items.Add(reader[0] +" - "+ reader[1] +" - "+ reader[2]);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
