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
    public partial class frm_add_vehicle : Form
    {
        public frm_add_vehicle()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            int id, capacity;
            if(!int.TryParse(txt_id.Text, out id))
            {
                MessageBox.Show("enter number in id field");
                return;
            }

            if (!int.TryParse(txt_capacity.Text, out capacity))
            {
                MessageBox.Show("enter number in capacity field");
                return;
            }


            string connectionString = null;
            string Query = null;

            connectionString = "Server=localhost;" +
                              "DataBase=hotel;" +
                              "Trusted_Connection=Yes;";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                try
                {
                    Query = "insert into vehicles ([id], [v_type], [capacity]) values(@i,@t,@c)";
                    using (SqlCommand cmd = new SqlCommand(Query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@i", id);
                        cmd.Parameters.AddWithValue("@t", cmb_type.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@c", capacity);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Vehicle added!");
                        txt_id.Clear();
                        txt_capacity.Clear();
                        cmb_type.Text = "";
                    }
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message);
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
