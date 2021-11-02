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
            this.btnDangnhap.Location = new System.Drawing.Point(194, 325);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(110, 43);
            this.btnDangnhap.TabIndex = 0;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = true;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // txbDangnhap
            // 
            this.txbDangnhap.Location = new System.Drawing.Point(154, 197);
            this.txbDangnhap.Name = "txbDangnhap";
            this.txbDangnhap.Size = new System.Drawing.Size(297, 22);
            this.txbDangnhap.TabIndex = 1;
            // 
            // lbDangnhap
            // 
            this.lbDangnhap.AutoSize = true;
            this.lbDangnhap.Location = new System.Drawing.Point(31, 200);
            this.lbDangnhap.Name = "lbDangnhap";
            this.lbDangnhap.Size = new System.Drawing.Size(101, 16);
            this.lbDangnhap.TabIndex = 2;
            this.lbDangnhap.Text = "Tên đăng nhập:";
            // 
            // lbMatkhau
            // 
            this.lbMatkhau.AutoSize = true;
            this.lbMatkhau.Location = new System.Drawing.Point(31, 262);
            this.lbMatkhau.Name = "lbMatkhau";
            this.lbMatkhau.Size = new System.Drawing.Size(64, 16);
            this.lbMatkhau.TabIndex = 3;
            this.lbMatkhau.Text = "Mật khẩu:";
            // 
            // txbMatkhau
            // 
            this.txbMatkhau.Location = new System.Drawing.Point(154, 255);
            this.txbMatkhau.Name = "txbMatkhau";
            this.txbMatkhau.Size = new System.Drawing.Size(297, 22);
            this.txbMatkhau.TabIndex = 4;
            // 
            // FDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(500, 447);
            this.ControlBox = false;
            this.Controls.Add(this.txbMatkhau);
            this.Controls.Add(this.lbMatkhau);
            this.Controls.Add(this.lbDangnhap);
            this.Controls.Add(this.txbDangnhap);
            this.Controls.Add(this.btnDangnhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

