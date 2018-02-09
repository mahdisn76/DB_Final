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
    public partial class frm_main_user : Form
    {
        public frm_main_user()
        {
            InitializeComponent();

        }

        private void frm_main_user_Load(object sender, EventArgs e)
        {
            
            string connectionString = null;
            string Query = null;


            connectionString = "Server=localhost;" +
                               "DataBase=hotel;" +
                               "Trusted_Connection=Yes;" +
                               "MultipleActiveResultSets=true";


            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlDataReader reader;

                    cmd.CommandText = "SELECT name , family \n" +
                            "FROM users \n" +
                            "WHERE id = " + GlobalVariables.id + ";";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tlp.Controls.Add(new Label { Text = reader[0].ToString() }, 0, 0);
                        tlp.Controls.Add(new Label { Text = reader[1].ToString() }, 1 , 0);
                        tlp.Controls.Add(new Label { Text = GlobalVariables.id.ToString() }, 2 , 0);
                    }

                }

              

            }
        }

        private void btn_reserve_Click(object sender, EventArgs e)
        {
            frm_reserve_hotel frm = new frm_reserve_hotel();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void btn_buy_ticket_Click(object sender, EventArgs e)
        {
            frm_buy_ticket frm = new frm_buy_ticket();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Owner.Show();            
            this.Close();
        }
    }
}
