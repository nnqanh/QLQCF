﻿namespace QLQCF
{
    partial class FChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FChinh));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvHoadon = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxGopBan = new System.Windows.Forms.ComboBox();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txbTongTien = new System.Windows.Forms.TextBox();
            this.btnChuyenban = new System.Windows.Forms.Button();
            this.cbxChuyenban = new System.Windows.Forms.ComboBox();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnThemmon = new System.Windows.Forms.Button();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lbSL = new System.Windows.Forms.Label();
            this.lbMon = new System.Windows.Forms.Label();
            this.cbMon = new System.Windows.Forms.ComboBox();
            this.fLPBan = new System.Windows.Forms.FlowLayoutPanel();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongtinTKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangxuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quanlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbExit = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvHoadon);
            this.panel2.Location = new System.Drawing.Point(419, 97);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 366);
            this.panel2.TabIndex = 2;
            // 
            // lsvHoadon
            // 
            this.lsvHoadon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lsvHoadon.BackgroundImage")));
            this.lsvHoadon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvHoadon.GridLines = true;
            this.lsvHoadon.HideSelection = false;
            this.lsvHoadon.Location = new System.Drawing.Point(2, 2);
            this.lsvHoadon.Margin = new System.Windows.Forms.Padding(2);
            this.lsvHoadon.Name = "lsvHoadon";
            this.lsvHoadon.Size = new System.Drawing.Size(428, 362);
            this.lsvHoadon.TabIndex = 0;
            this.lsvHoadon.UseCompatibleStateImageBehavior = false;
            this.lsvHoadon.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 145;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 87;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 97;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.cbxGopBan);
            this.panel3.Controls.Add(this.btnGopBan);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.txbTongTien);
            this.panel3.Controls.Add(this.btnChuyenban);
            this.panel3.Controls.Add(this.cbxChuyenban);
            this.panel3.Controls.Add(this.btnThanhtoan);
            this.panel3.Location = new System.Drawing.Point(419, 467);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(430, 90);
            this.panel3.TabIndex = 3;
            // 
            // cbxGopBan
            // 
            this.cbxGopBan.BackColor = System.Drawing.Color.LavenderBlush;
            this.cbxGopBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGopBan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxGopBan.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGopBan.FormattingEnabled = true;
            this.cbxGopBan.Location = new System.Drawing.Point(120, 50);
            this.cbxGopBan.Margin = new System.Windows.Forms.Padding(2);
            this.cbxGopBan.Name = "cbxGopBan";
            this.cbxGopBan.Size = new System.Drawing.Size(102, 26);
            this.cbxGopBan.TabIndex = 10;
            // 
            // btnGopBan
            // 
            this.btnGopBan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGopBan.BackgroundImage")));
            this.btnGopBan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGopBan.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGopBan.ForeColor = System.Drawing.Color.White;
            this.btnGopBan.Location = new System.Drawing.Point(120, 9);
            this.btnGopBan.Margin = new System.Windows.Forms.Padding(2);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(101, 30);
            this.btnGopBan.TabIndex = 9;
            this.btnGopBan.Text = "Gộp bàn";
            this.btnGopBan.UseVisualStyleBackColor = true;
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(236, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Tổng tiền";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txbTongTien
            // 
            this.txbTongTien.BackColor = System.Drawing.SystemColors.Window;
            this.txbTongTien.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTongTien.ForeColor = System.Drawing.Color.HotPink;
            this.txbTongTien.Location = new System.Drawing.Point(236, 50);
            this.txbTongTien.Name = "txbTongTien";
            this.txbTongTien.ReadOnly = true;
            this.txbTongTien.Size = new System.Drawing.Size(102, 25);
            this.txbTongTien.TabIndex = 7;
            this.txbTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnChuyenban
            // 
            this.btnChuyenban.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChuyenban.BackgroundImage")));
            this.btnChuyenban.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChuyenban.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenban.ForeColor = System.Drawing.Color.White;
            this.btnChuyenban.Location = new System.Drawing.Point(7, 9);
            this.btnChuyenban.Margin = new System.Windows.Forms.Padding(2);
            this.btnChuyenban.Name = "btnChuyenban";
            this.btnChuyenban.Size = new System.Drawing.Size(101, 30);
            this.btnChuyenban.TabIndex = 5;
            this.btnChuyenban.Text = "Chuyển bàn";
            this.btnChuyenban.UseVisualStyleBackColor = true;
            this.btnChuyenban.Click += new System.EventHandler(this.btnChuyenban_Click);
            // 
            // cbxChuyenban
            // 
            this.cbxChuyenban.BackColor = System.Drawing.Color.LavenderBlush;
            this.cbxChuyenban.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChuyenban.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxChuyenban.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxChuyenban.FormattingEnabled = true;
            this.cbxChuyenban.Location = new System.Drawing.Point(7, 49);
            this.cbxChuyenban.Margin = new System.Windows.Forms.Padding(2);
            this.cbxChuyenban.Name = "cbxChuyenban";
            this.cbxChuyenban.Size = new System.Drawing.Size(102, 26);
            this.cbxChuyenban.TabIndex = 5;
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThanhtoan.BackgroundImage")));
            this.btnThanhtoan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThanhtoan.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhtoan.ForeColor = System.Drawing.Color.White;
            this.btnThanhtoan.Location = new System.Drawing.Point(348, 9);
            this.btnThanhtoan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(80, 66);
            this.btnThanhtoan.TabIndex = 5;
            this.btnThanhtoan.Text = "Thanh toán";
            this.btnThanhtoan.UseVisualStyleBackColor = true;
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhtoan_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.btnThemmon);
            this.panel4.Controls.Add(this.nmSoLuong);
            this.panel4.Controls.Add(this.lbSL);
            this.panel4.Controls.Add(this.lbMon);
            this.panel4.Controls.Add(this.cbMon);
            this.panel4.Location = new System.Drawing.Point(419, 37);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(430, 52);
            this.panel4.TabIndex = 4;
            // 
            // btnThemmon
            // 
            this.btnThemmon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThemmon.BackgroundImage")));
            this.btnThemmon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThemmon.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemmon.ForeColor = System.Drawing.Color.White;
            this.btnThemmon.Location = new System.Drawing.Point(326, 6);
            this.btnThemmon.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemmon.Name = "btnThemmon";
            this.btnThemmon.Size = new System.Drawing.Size(101, 37);
            this.btnThemmon.TabIndex = 4;
            this.btnThemmon.Text = "Thêm món";
            this.btnThemmon.UseVisualStyleBackColor = true;
            this.btnThemmon.Click += new System.EventHandler(this.btnThemmon_Click);
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.BackColor = System.Drawing.Color.LavenderBlush;
            this.nmSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nmSoLuong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmSoLuong.Location = new System.Drawing.Point(79, 27);
            this.nmSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.nmSoLuong.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(153, 21);
            this.nmSoLuong.TabIndex = 3;
            this.nmSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbSL
            // 
            this.lbSL.AutoSize = true;
            this.lbSL.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSL.Location = new System.Drawing.Point(4, 28);
            this.lbSL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSL.Name = "lbSL";
            this.lbSL.Size = new System.Drawing.Size(61, 15);
            this.lbSL.TabIndex = 2;
            this.lbSL.Text = "Số lượng:";
            // 
            // lbMon
            // 
            this.lbMon.AutoSize = true;
            this.lbMon.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMon.Location = new System.Drawing.Point(4, 5);
            this.lbMon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMon.Name = "lbMon";
            this.lbMon.Size = new System.Drawing.Size(33, 15);
            this.lbMon.TabIndex = 1;
            this.lbMon.Text = "Món:";
            // 
            // cbMon
            // 
            this.cbMon.BackColor = System.Drawing.Color.LavenderBlush;
            this.cbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbMon.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMon.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbMon.FormattingEnabled = true;
            this.cbMon.Location = new System.Drawing.Point(79, 2);
            this.cbMon.Margin = new System.Windows.Forms.Padding(2);
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(154, 23);
            this.cbMon.TabIndex = 0;
            this.cbMon.SelectedIndexChanged += new System.EventHandler(this.cbMon_SelectedIndexChanged);
            // 
            // fLPBan
            // 
            this.fLPBan.AutoScroll = true;
            this.fLPBan.BackColor = System.Drawing.Color.Transparent;
            this.fLPBan.Location = new System.Drawing.Point(10, 99);
            this.fLPBan.Margin = new System.Windows.Forms.Padding(2);
            this.fLPBan.Name = "fLPBan";
            this.fLPBan.Size = new System.Drawing.Size(405, 457);
            this.fLPBan.TabIndex = 5;
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thongtinTKToolStripMenuItem,
            this.DangxuatToolStripMenuItem});
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.adminToolStripMenuItem.Text = "Tài khoản";
            // 
            // thongtinTKToolStripMenuItem
            // 
            this.thongtinTKToolStripMenuItem.Name = "thongtinTKToolStripMenuItem";
            this.thongtinTKToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.thongtinTKToolStripMenuItem.Text = "Thông tin tài khoản";
            this.thongtinTKToolStripMenuItem.Click += new System.EventHandler(this.thongtinTKToolStripMenuItem_Click);
            // 
            // DangxuatToolStripMenuItem
            // 
            this.DangxuatToolStripMenuItem.Name = "DangxuatToolStripMenuItem";
            this.DangxuatToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.DangxuatToolStripMenuItem.Text = "Đăng xuất";
            this.DangxuatToolStripMenuItem.Click += new System.EventHandler(this.DangxuatToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.quanlyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(10, 7);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(139, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quanlyToolStripMenuItem
            // 
            this.quanlyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muaToolStripMenuItem,
            this.banToolStripMenuItem});
            this.quanlyToolStripMenuItem.Name = "quanlyToolStripMenuItem";
            this.quanlyToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.quanlyToolStripMenuItem.Text = "Quản lý";
            this.quanlyToolStripMenuItem.Click += new System.EventHandler(this.quanlyToolStripMenuItem_Click);
            // 
            // muaToolStripMenuItem
            // 
            this.muaToolStripMenuItem.Name = "muaToolStripMenuItem";
            this.muaToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.muaToolStripMenuItem.Text = "Mua";
            this.muaToolStripMenuItem.Click += new System.EventHandler(this.muaToolStripMenuItem_Click);
            // 
            // banToolStripMenuItem
            // 
            this.banToolStripMenuItem.Name = "banToolStripMenuItem";
            this.banToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.banToolStripMenuItem.Text = "Bán";
            this.banToolStripMenuItem.Click += new System.EventHandler(this.banToolStripMenuItem_Click);
            // 
            // lbExit
            // 
            this.lbExit.AutoSize = true;
            this.lbExit.BackColor = System.Drawing.Color.Transparent;
            this.lbExit.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExit.ForeColor = System.Drawing.Color.DimGray;
            this.lbExit.Location = new System.Drawing.Point(834, -5);
            this.lbExit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(27, 31);
            this.lbExit.TabIndex = 6;
            this.lbExit.Text = "x";
            this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
            // 
            // FChinh
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(860, 567);
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.fLPBan);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvHoadon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnChuyenban;
        private System.Windows.Forms.ComboBox cbxChuyenban;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnThemmon;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.Label lbSL;
        private System.Windows.Forms.Label lbMon;
        private System.Windows.Forms.ComboBox cbMon;
        private System.Windows.Forms.FlowLayoutPanel fLPBan;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongtinTKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DangxuatToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quanlyToolStripMenuItem;
        private System.Windows.Forms.Label lbExit;
        private System.Windows.Forms.ToolStripMenuItem muaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbTongTien;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxGopBan;
        private System.Windows.Forms.Button btnGopBan;
    }
}