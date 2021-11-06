using QLQCF.DAO;
using QLQCF.DTO;
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
            LoadTable();
        }

        #region Method

        void LoadTable()
        {
            List<DTO_Table> tableList = DAO_Table.Instance.LoadTableList();

            foreach (DTO_Table item in tableList)
            {
                Button btn = new Button() { Width = DAO_Table.TableWidth, Height = DAO_Table.TableHeight };
                btn.Text = "Bàn " + (item.SoBan +1) + Environment.NewLine + item.TinhTrang;

                switch (item.TinhTrang)
                {
                    case "Trống":
                        btn.BackColor = Color.Pink;
                        break;
                    default:
                        btn.BackColor = Color.White;
                        break;
                }

                fLPBan.Controls.Add(btn);
            }
        }
        #endregion

        #region Events
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
        #endregion
    }
}
