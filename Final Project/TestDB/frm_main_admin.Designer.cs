namespace TestDB
{
    partial class frm_main_admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.hotel = new System.Windows.Forms.Button();
            this.travel = new System.Windows.Forms.Button();
            this.vehicle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "hello dear admin,";
            // 
            // hotel
            // 
            this.hotel.Location = new System.Drawing.Point(132, 72);
            this.hotel.Name = "hotel";
            this.hotel.Size = new System.Drawing.Size(106, 36);
            this.hotel.TabIndex = 1;
            this.hotel.Text = "Add hotel";
            this.hotel.UseVisualStyleBackColor = true;
            this.hotel.Click += new System.EventHandler(this.button1_Click);
            // 
            // travel
            // 
            this.travel.Location = new System.Drawing.Point(132, 156);
            this.travel.Name = "travel";
            this.travel.Size = new System.Drawing.Size(106, 36);
            this.travel.TabIndex = 4;
            this.travel.Text = "Add travel";
            this.travel.UseVisualStyleBackColor = true;
            this.travel.Click += new System.EventHandler(this.travel_Click);
            // 
            // vehicle
            // 
            this.vehicle.Location = new System.Drawing.Point(132, 114);
            this.vehicle.Name = "vehicle";
            this.vehicle.Size = new System.Drawing.Size(106, 36);
            this.vehicle.TabIndex = 5;
            this.vehicle.Text = "Add vehicle";
            this.vehicle.UseVisualStyleBackColor = true;
            this.vehicle.Click += new System.EventHandler(this.vehicle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "@All Rights Reserved for {NiloOfar + Mahdi + Alireza}";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_main_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 332);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vehicle);
            this.Controls.Add(this.travel);
            this.Controls.Add(this.hotel);
            this.Controls.Add(this.label1);
            this.Name = "frm_main_admin";
            this.Text = "frm_main_admin";
            this.Load += new System.EventHandler(this.frm_main_admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button hotel;
        private System.Windows.Forms.Button travel;
        private System.Windows.Forms.Button vehicle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}