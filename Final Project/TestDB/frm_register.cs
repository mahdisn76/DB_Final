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

namespace TestDB
{
    public partial class frm_register : Form
    {
        public frm_register()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            int id, age;
            if (!int.TryParse(txt_id.Text, out id))
            {
                MessageBox.Show("enter a number for id");
                return;
            }
            if (!int.TryParse(txt_age.Text, out age))
            {
                MessageBox.Show("enter a number for age");
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

                Query = "insert into users ([name] , [family],[id] , [age] , [education] , [sex] , [city]) values(@a , @b , @c , @d , @e , @f , @g)";
                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    cmd.Parameters.AddWithValue("@a", txt_name.Text);
                    cmd.Parameters.AddWithValue("@b", txt_family.Text);
                    cmd.Parameters.AddWithValue("@c", id);
                    cmd.Parameters.AddWithValue("@d", age);
                    cmd.Parameters.AddWithValue("@e", txt_education.Text);
                    cmd.Parameters.AddWithValue("@f", cmb_sex.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@g", txt_city.Text);
                    //MessageBox.Show(Query);
                    cmd.ExecuteNonQuery();
                }

                Query = "insert into User_Phone ([id], [phone]) values ";
                foreach(string s in txt_phones.Text.Split('\n'))
                {
                    Query+="(" + id + ", " + s + "),";
                }

                Query = Query.Substring(0, Query.Length - 1);
                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("You have been registered.\nYou have to login now");
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
