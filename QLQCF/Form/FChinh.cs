using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQCF
{
    public partial class FChinh : Form
    {
        public FChinh()
        {
            InitializeComponent();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void muaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQuanly f = new FQuanly();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void banToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQuanlyBan f = new FQuanlyBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void DangxuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDangNhap f = new FDangNhap();
            this.Hide();
            f.ShowDialog();
        }
    }
}
