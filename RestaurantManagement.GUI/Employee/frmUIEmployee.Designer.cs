﻿namespace RestaurantManagement.GUI.Employee
{
    partial class frmUIEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUIEmployee));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetTable = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnSeats = new Guna.UI2.WinForms.Guna2Button();
            this.btnTableStatus = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.logo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLoginUser = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPageChange = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlChangePage = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSetTable);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSeats);
            this.panel1.Controls.Add(this.btnTableStatus);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Location = new System.Drawing.Point(12, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 563);
            this.panel1.TabIndex = 0;
            // 
            // btnSetTable
            // 
            this.btnSetTable.BorderRadius = 30;
            this.btnSetTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSetTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSetTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSetTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSetTable.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSetTable.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSetTable.ForeColor = System.Drawing.Color.White;
            this.btnSetTable.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSetTable.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSetTable.Location = new System.Drawing.Point(6, 290);
            this.btnSetTable.Name = "btnSetTable";
            this.btnSetTable.Size = new System.Drawing.Size(201, 59);
            this.btnSetTable.TabIndex = 5;
            this.btnSetTable.Text = "Đặt Bàn";
            this.btnSetTable.Click += new System.EventHandler(this.btnSetTable_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(126, 496);
            this.btnExit.Name = "btnExit";
            this.btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnExit.Size = new System.Drawing.Size(78, 64);
            this.btnExit.TabIndex = 4;
            this.btnExit.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // btnSeats
            // 
            this.btnSeats.BorderRadius = 30;
            this.btnSeats.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSeats.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSeats.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSeats.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSeats.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSeats.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSeats.ForeColor = System.Drawing.Color.White;
            this.btnSeats.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSeats.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSeats.Location = new System.Drawing.Point(3, 202);
            this.btnSeats.Name = "btnSeats";
            this.btnSeats.Size = new System.Drawing.Size(201, 59);
            this.btnSeats.TabIndex = 2;
            this.btnSeats.Text = "Xếp Chỗ";
            this.btnSeats.Click += new System.EventHandler(this.btnSeats_Click);
            // 
            // btnTableStatus
            // 
            this.btnTableStatus.BorderRadius = 30;
            this.btnTableStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTableStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTableStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTableStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTableStatus.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTableStatus.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTableStatus.ForeColor = System.Drawing.Color.White;
            this.btnTableStatus.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTableStatus.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnTableStatus.Location = new System.Drawing.Point(6, 114);
            this.btnTableStatus.Name = "btnTableStatus";
            this.btnTableStatus.Size = new System.Drawing.Size(198, 59);
            this.btnTableStatus.TabIndex = 1;
            this.btnTableStatus.Text = "Tình Trạng Bàn";
            this.btnTableStatus.Click += new System.EventHandler(this.btnTableStatus_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BorderRadius = 30;
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnHome.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnHome.Location = new System.Drawing.Point(3, 23);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(201, 59);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Trang Chủ";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // logo
            // 
            this.logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logo.BackgroundImage")));
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.ForeColor = System.Drawing.Color.Black;
            this.logo.Location = new System.Drawing.Point(12, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(207, 115);
            this.logo.TabIndex = 1;
            this.logo.Click += new System.EventHandler(this.logo_Click);
            this.logo.Paint += new System.Windows.Forms.PaintEventHandler(this.logo_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.guna2Panel1);
            this.panel3.Controls.Add(this.lblLoginUser);
            this.panel3.Controls.Add(this.lblPageChange);
            this.panel3.Controls.Add(this.lblUsername);
            this.panel3.Controls.Add(this.lblPage);
            this.panel3.Location = new System.Drawing.Point(247, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1223, 79);
            this.panel3.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel1.BackgroundImage")));
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.ForeColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(947, 24);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(45, 38);
            this.guna2Panel1.TabIndex = 4;
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblLoginUser.ForeColor = System.Drawing.Color.White;
            this.lblLoginUser.Location = new System.Drawing.Point(998, 32);
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(161, 30);
            this.lblLoginUser.TabIndex = 3;
            this.lblLoginUser.Text = "guna2HtmlLabel1";
            // 
            // lblPageChange
            // 
            this.lblPageChange.BackColor = System.Drawing.Color.Transparent;
            this.lblPageChange.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPageChange.ForeColor = System.Drawing.Color.White;
            this.lblPageChange.Location = new System.Drawing.Point(95, 24);
            this.lblPageChange.Name = "lblPageChange";
            this.lblPageChange.Size = new System.Drawing.Size(195, 33);
            this.lblPageChange.TabIndex = 2;
            this.lblPageChange.Text = "guna2HtmlLabel1";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblUsername.Location = new System.Drawing.Point(970, 41);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 38);
            this.lblUsername.TabIndex = 1;
            // 
            // lblPage
            // 
            this.lblPage.BackColor = System.Drawing.Color.Transparent;
            this.lblPage.Font = new System.Drawing.Font("Papyrus", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(142, 51);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(3, 2);
            this.lblPage.TabIndex = 0;
            this.lblPage.Text = null;
            // 
            // pnlChangePage
            // 
            this.pnlChangePage.BackColor = System.Drawing.Color.Transparent;
            this.pnlChangePage.ForeColor = System.Drawing.Color.Transparent;
            this.pnlChangePage.Location = new System.Drawing.Point(247, 94);
            this.pnlChangePage.Name = "pnlChangePage";
            this.pnlChangePage.Size = new System.Drawing.Size(1220, 597);
            this.pnlChangePage.TabIndex = 8;
            // 
            // frmUIEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::RestaurantManagement.GUI.Properties.Resources.anhchinh;
            this.ClientSize = new System.Drawing.Size(1482, 703);
            this.Controls.Add(this.pnlChangePage);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.panel1);
            this.Name = "frmUIEmployee";
            this.Text = "UIEmployee";
            this.Load += new System.EventHandler(this.frmUIEmployee_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel logo;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Button btnSeats;
        private Guna.UI2.WinForms.Guna2Button btnTableStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPage;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
        private System.Windows.Forms.Panel pnlChangePage;
        private System.Windows.Forms.Label lblUsername;
        private Guna.UI2.WinForms.Guna2Button btnSetTable;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageChange;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLoginUser;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}