namespace RestaurantManagement.GUI
{
    partial class UC_Home
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Home));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddFood = new Guna.UI2.WinForms.Guna2Button();
            this.btnRemoteFood = new Guna.UI2.WinForms.Guna2Button();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtFullnameFood = new System.Windows.Forms.TextBox();
            this.txtFoodID = new System.Windows.Forms.TextBox();
            this.cmbTypeFood = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpLoad = new System.Windows.Forms.Button();
            this.picHinhMA = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhMA)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 68);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(725, 529);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // cmbLoai
            // 
            this.cmbLoai.BackColor = System.Drawing.Color.Transparent;
            this.cmbLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLoai.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbLoai.ItemHeight = 30;
            this.cmbLoai.Items.AddRange(new object[] {
            "Tất cả",
            "Món Chính",
            "Món Bánh",
            "Món Nước"});
            this.cmbLoai.Location = new System.Drawing.Point(553, 17);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(174, 36);
            this.cmbLoai.StartIndex = 0;
            this.cmbLoai.TabIndex = 12;
            this.cmbLoai.SelectedIndexChanged += new System.EventHandler(this.cmbLoai_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.BorderColor = System.Drawing.Color.Gray;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.FocusedColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(290, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 32);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderThickness = 0;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(15, 21);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(325, 32);
            this.txtSearch.TabIndex = 10;
            // 
            // btnAddFood
            // 
            this.btnAddFood.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddFood.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddFood.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddFood.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddFood.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddFood.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.ForeColor = System.Drawing.Color.White;
            this.btnAddFood.Location = new System.Drawing.Point(790, 528);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(176, 48);
            this.btnAddFood.TabIndex = 16;
            this.btnAddFood.Text = "Thêm/Sửa Món";
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnRemoteFood
            // 
            this.btnRemoteFood.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoteFood.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoteFood.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoteFood.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoteFood.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemoteFood.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoteFood.ForeColor = System.Drawing.Color.White;
            this.btnRemoteFood.Location = new System.Drawing.Point(1040, 528);
            this.btnRemoteFood.Name = "btnRemoteFood";
            this.btnRemoteFood.Size = new System.Drawing.Size(133, 48);
            this.btnRemoteFood.TabIndex = 17;
            this.btnRemoteFood.Text = "Xóa Món";
            this.btnRemoteFood.Click += new System.EventHandler(this.btnRemoteFood_Click);
            // 
            // txtMoney
            // 
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.Location = new System.Drawing.Point(929, 383);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(225, 32);
            this.txtMoney.TabIndex = 27;
            // 
            // txtFullnameFood
            // 
            this.txtFullnameFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullnameFood.Location = new System.Drawing.Point(929, 311);
            this.txtFullnameFood.Name = "txtFullnameFood";
            this.txtFullnameFood.Size = new System.Drawing.Size(225, 32);
            this.txtFullnameFood.TabIndex = 26;
            // 
            // txtFoodID
            // 
            this.txtFoodID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoodID.Location = new System.Drawing.Point(929, 244);
            this.txtFoodID.Name = "txtFoodID";
            this.txtFoodID.Size = new System.Drawing.Size(225, 32);
            this.txtFoodID.TabIndex = 25;
            // 
            // cmbTypeFood
            // 
            this.cmbTypeFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeFood.FormattingEnabled = true;
            this.cmbTypeFood.Items.AddRange(new object[] {
            "Món Chính",
            "Món Bánh",
            "Món Nước"});
            this.cmbTypeFood.Location = new System.Drawing.Point(929, 451);
            this.cmbTypeFood.Name = "cmbTypeFood";
            this.cmbTypeFood.Size = new System.Drawing.Size(225, 34);
            this.cmbTypeFood.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(785, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 26);
            this.label4.TabIndex = 23;
            this.label4.Text = "Loại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(785, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "Giá Tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(785, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên Món";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(785, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 26);
            this.label1.TabIndex = 20;
            this.label1.Text = "Mã Món";
            // 
            // btnUpLoad
            // 
            this.btnUpLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpLoad.Location = new System.Drawing.Point(1103, 156);
            this.btnUpLoad.Name = "btnUpLoad";
            this.btnUpLoad.Size = new System.Drawing.Size(30, 23);
            this.btnUpLoad.TabIndex = 19;
            this.btnUpLoad.Text = "...";
            this.btnUpLoad.UseVisualStyleBackColor = true;
            this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
            // 
            // picHinhMA
            // 
            this.picHinhMA.Location = new System.Drawing.Point(860, 21);
            this.picHinhMA.Name = "picHinhMA";
            this.picHinhMA.Size = new System.Drawing.Size(237, 158);
            this.picHinhMA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHinhMA.TabIndex = 18;
            this.picHinhMA.TabStop = false;
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.txtFullnameFood);
            this.Controls.Add(this.txtFoodID);
            this.Controls.Add(this.cmbTypeFood);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpLoad);
            this.Controls.Add(this.picHinhMA);
            this.Controls.Add(this.btnRemoteFood);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cmbLoai);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1242, 597);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHinhMA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLoai;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnAddFood;
        private Guna.UI2.WinForms.Guna2Button btnRemoteFood;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.TextBox txtFullnameFood;
        private System.Windows.Forms.TextBox txtFoodID;
        private System.Windows.Forms.ComboBox cmbTypeFood;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpLoad;
        private System.Windows.Forms.PictureBox picHinhMA;
    }
}
