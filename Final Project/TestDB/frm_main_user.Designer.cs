namespace TestDB
{
    partial class frm_main_user
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
            this.btn_reserve = new System.Windows.Forms.Button();
            this.btn_buy_ticket = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_reserve
            // 
            this.btn_reserve.Location = new System.Drawing.Point(79, 101);
            this.btn_reserve.Name = "btn_reserve";
            this.btn_reserve.Size = new System.Drawing.Size(139, 65);
            this.btn_reserve.TabIndex = 0;
            this.btn_reserve.Text = "Reserve Hotel";
            this.btn_reserve.UseVisualStyleBackColor = true;
            this.btn_reserve.Click += new System.EventHandler(this.btn_reserve_Click);
            // 
            // btn_buy_ticket
            // 
            this.btn_buy_ticket.Location = new System.Drawing.Point(224, 101);
            this.btn_buy_ticket.Name = "btn_buy_ticket";
            this.btn_buy_ticket.Size = new System.Drawing.Size(148, 65);
            this.btn_buy_ticket.TabIndex = 1;
            this.btn_buy_ticket.Text = "Buy Ticket";
            this.btn_buy_ticket.UseVisualStyleBackColor = true;
            this.btn_buy_ticket.Click += new System.EventHandler(this.btn_buy_ticket_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(164, 172);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(98, 29);
            this.btn_logout.TabIndex = 2;
            this.btn_logout.Text = "Log Out";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // tlp
            // 
            this.tlp.AutoSize = true;
            this.tlp.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tlp.ColumnCount = 3;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp.ForeColor = System.Drawing.Color.Red;
            this.tlp.Location = new System.Drawing.Point(12, 12);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 1;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Size = new System.Drawing.Size(399, 47);
            this.tlp.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "@All Rights Reserved for {NiloOfar + Mahdi + Alireza}";
            // 
            // frm_main_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 288);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tlp);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_buy_ticket);
            this.Controls.Add(this.btn_reserve);
            this.Name = "frm_main_user";
            this.Text = "frm_main_user";
            this.Load += new System.EventHandler(this.frm_main_user_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_reserve;
        private System.Windows.Forms.Button btn_buy_ticket;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Label label1;
    }
}