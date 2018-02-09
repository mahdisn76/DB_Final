using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDB
{
    public partial class frm_main_admin : Form
    {
        public frm_main_admin()
        {
            InitializeComponent();
        }

        private void frm_main_admin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_add_hotel frm = new frm_add_hotel();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void vehicle_Click(object sender, EventArgs e)
        {
            frm_add_vehicle frm = new frm_add_vehicle();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void travel_Click(object sender, EventArgs e)
        {
            frm_add_travel frm = new frm_add_travel();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }
    }
}
