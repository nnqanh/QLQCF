namespace QLQCF
{
    partial class FDangNhap
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
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.txbDangnhap = new System.Windows.Forms.TextBox();
            this.lbDangnhap = new System.Windows.Forms.Label();
            this.lbMatkhau = new System.Windows.Forms.Label();
            this.txbMatkhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.Location = new System.Drawing.Point(146, 264);
            this.btnDangnhap.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(82, 35);
            this.btnDangnhap.TabIndex = 0;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = true;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // txbDangnhap
            // 
            this.txbDangnhap.Location = new System.Drawing.Point(116, 159);
            this.txbDangnhap.Margin = new System.Windows.Forms.Padding(2);
            this.txbDangnhap.Name = "txbDangnhap";
            this.txbDangnhap.Size = new System.Drawing.Size(224, 20);
            this.txbDangnhap.TabIndex = 1;
            this.txbDangnhap.TextChanged += new System.EventHandler(this.txbDangnhap_TextChanged);
            // 
            // lbDangnhap
            // 
            this.lbDangnhap.AutoSize = true;
            this.lbDangnhap.Location = new System.Drawing.Point(23, 162);
            this.lbDangnhap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDangnhap.Name = "lbDangnhap";
            this.lbDangnhap.Size = new System.Drawing.Size(84, 13);
            this.lbDangnhap.TabIndex = 2;
            this.lbDangnhap.Text = "Tên đăng nhập:";
            // 
            // lbMatkhau
            // 
            this.lbMatkhau.AutoSize = true;
            this.lbMatkhau.Location = new System.Drawing.Point(23, 213);
            this.lbMatkhau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMatkhau.Name = "lbMatkhau";
            this.lbMatkhau.Size = new System.Drawing.Size(55, 13);
            this.lbMatkhau.TabIndex = 3;
            this.lbMatkhau.Text = "Mật khẩu:";
            // 
            // txbMatkhau
            // 
            this.txbMatkhau.Location = new System.Drawing.Point(116, 207);
            this.txbMatkhau.Margin = new System.Windows.Forms.Padding(2);
            this.txbMatkhau.Name = "txbMatkhau";
            this.txbMatkhau.Size = new System.Drawing.Size(224, 20);
            this.txbMatkhau.TabIndex = 4;
            // 
            // FDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 363);
            this.ControlBox = false;
            this.Controls.Add(this.txbMatkhau);
            this.Controls.Add(this.lbMatkhau);
            this.Controls.Add(this.lbDangnhap);
            this.Controls.Add(this.txbDangnhap);
            this.Controls.Add(this.btnDangnhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FDangNhap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FDangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.TextBox txbDangnhap;
        private System.Windows.Forms.Label lbDangnhap;
        private System.Windows.Forms.Label lbMatkhau;
        private System.Windows.Forms.TextBox txbMatkhau;
    }
}

