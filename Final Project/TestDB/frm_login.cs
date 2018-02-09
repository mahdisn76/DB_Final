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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frm_register frm = new frm_register();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(txt_user.Text=="admin" && txt_pass.Text=="admin")
            {
                frm_main_admin frm = new frm_main_admin();
                frm.Owner = this;
                txt_user.Clear();
                txt_pass.Clear();
                frm.Show();
                this.Hide();
                return;
            }




            int user;
            string entered_pass = txt_pass.Text;
            string correct_pass = null;

            if (!int.TryParse(txt_user.Text, out user))
            {
                MessageBox.Show("Invalid Username");
                txt_pass.Clear();
                txt_user.Clear();
                return;
            }


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

                    cmd.CommandText = "SELECT name , id \n" +
                                      "FROM Users \n" +
                                      "WHERE id = " + user + ";";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                        correct_pass = reader[0].ToString();

                    if (correct_pass == null)
                    {
                        MessageBox.Show("Invalid Username");
                        txt_pass.Clear();
                        txt_user.Clear();
                    }
                    else if (correct_pass != entered_pass)
                    {
                        MessageBox.Show("Password is wrong");
                        txt_pass.Clear();
                    }
                    else
                    {
                        frm_main_user frm = new frm_main_user();
                        frm.Owner = this;
                        GlobalVariables.id = user;
                        txt_user.Clear();
                        txt_pass.Clear();
                        frm.Show();
                        this.Hide();
                    }

                }
            }



        }

        private void frm_login_Load(object sender, EventArgs e)
        {
           
        }
    }
}
