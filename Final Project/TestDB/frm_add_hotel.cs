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
    public partial class frm_add_hotel : Form
    {
        public frm_add_hotel()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int id, plaq;
            if (!int.TryParse(txt_id.Text, out id))
            {
                MessageBox.Show("enter a number for id");
                return;
            }
            if (!int.TryParse(txt_plaq.Text, out plaq))
            {
                MessageBox.Show("enter a number for plaq");
                return;
            }


            String connectionString = null;
            String Query = null;

            connectionString = "Server=localhost;" +
                               "DataBase=hotel;" +
                               "Trusted_Connection=Yes;";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                Query = "insert into hotels values (" +
                               id              + ", " +
                        "\'" + txt_name.Text   + "\', " +
                        "\'" + txt_country.Text+ "\', " +
                        "\'" + txt_city.Text   + "\', " +
                        "\'" + txt_st.Text     + "\', " +
                        "\'" + txt_ave.Text    + "\', " +
                        plaq            + ")";
                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }

                Query = "INSERT INTO Rooms values ";
                for(int i=0;i<dgv_rooms.Rows.Count-1;i++)
                {
                    var row = dgv_rooms.Rows[i];                
                    Query += "(" + 
                        id                      + ", " + /*h_id"*/
                        row.Cells[0].Value      + ", " +
                        row.Cells[1].Value      + ", " +
                  "\'"+ row.Cells[2].Value+"\'" + ", " +
                        row.Cells[3].Value      +
                        "),";
                }
                Query = Query.Substring(0, Query.Length - 1);
                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Hotel added!");

                        //cleaning ------
                        foreach(var ctrl in Controls)
                        {
                            if (ctrl is TextBox)
                                ((TextBox)ctrl).Clear();
                        }
                        dgv_rooms.Rows.Clear();
                        //---------------
                    }
                    catch(Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
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

//Insert into Vehicles values (123, 'Bus', 20)