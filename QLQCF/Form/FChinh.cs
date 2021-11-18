using QLQCF.DAO;
using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQCF
{
    public partial class FChinh : Form
    {
        private DTO_Account loginAccount;
        public DTO_Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Loai); }
        }
        void ChangeAccount(int loai)
        {
            banToolStripMenuItem.Enabled = loai == 1;
            thongtinTKToolStripMenuItem.Text += " (" + LoginAccount.TenHienThi + ")";

        }
        public ComboBox cbbTinhTrang;

        public FChinh(DTO_Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadMon();
            LoadComboboxTable(cbxChuyenban);
            LoadComboboxTable(cbxGopBan);
        }

        #region Method

        void LoadTable()
        {
            fLPBan.Controls.Clear();

            List<DTO_Table> tableList = DAO_Table.Instance.LoadTableList();

            foreach (DTO_Table item in tableList)
            {
                Button btn = new Button() { Width = DAO_Table.TableWidth, Height = DAO_Table.TableHeight };
                btn.Text = "Bàn " + item.SoBan + Environment.NewLine + item.TinhTrang;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.TinhTrang)
                {
                    case "Trống":
                        btn.BackColor = Color.Pink;
                        break;
                    case "Bán mang về":
                        btn.BackColor = Color.FloralWhite;
                        break;
                    default:
                        btn.BackColor = Color.White;
                        break;
                }

                fLPBan.Controls.Add(btn);
            }
        }

        void ShowBill(int soBan)
        {
            lsvHoadon.Items.Clear();
            List<DTO_Menu> listBillInfo = DAO_Menu.Instance.GetListMenuByTable(DAO_Bill.Instance.GetUncheckBillIDByTableID(soBan));
            float tongTien = 0;
            foreach (DTO_Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenMon.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                tongTien += item.ThanhTien;
                lsvHoadon.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            txbTongTien.Text = tongTien.ToString("c", culture);
        }
        
        void LoadMon()
        {
            List<DTO_Mon> listMon = DAO_Mon.Instance.GetListMon();
            cbMon.DataSource = listMon;
            cbMon.DisplayMember = "TenMon";
        }               

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = DAO_Table.Instance.LoadTableList();
            cb.DisplayMember = "SoBan";
        }
        #endregion

        #region Events

        void btn_Click(object sender, EventArgs e)
        {
            int soBan = ((sender as Button).Tag as DTO_Table).SoBan;
            lsvHoadon.Tag = (sender as Button).Tag;
            ShowBill(soBan);
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
            f.loginAccount = LoginAccount;
            f.ShowDialog();
            this.Show();
        }

        private void banToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQuanlyBan f = new FQuanlyBan();
            this.Hide();
            f.loginAccount = LoginAccount;
            f.InsertMon += f_InsertMon;
            f.DeleteMon += f_DeleteMon;
            f.UpdateMon += f_UpdateMon;
            f.InsertBan += f_InsertBan;
            f.DeleteBan += f_DeleteBan;
            f.UpdateBan += f_UpdateBan;
            f.ShowDialog();
            this.Show();
        }

        void f_UpdateBan(object sender, EventArgs e)
        {
            LoadTable();
        }

        void f_DeleteBan(object sender, EventArgs e)
        {
            LoadTable();
        }

        void f_InsertBan(object sender, EventArgs e)
        {
            LoadTable();
        }

        void f_InsertMon(object sender, EventArgs e)
        {
            LoadMon();
            if (lsvHoadon.Tag != null)
                ShowBill((lsvHoadon.Tag as DTO_Table).SoBan);
            LoadTable();
        }
        void f_DeleteMon(object sender, EventArgs e)
        {
            LoadMon();
            if (lsvHoadon.Tag != null)
                ShowBill((lsvHoadon.Tag as DTO_Table).SoBan);
            LoadTable();
        }
        void f_UpdateMon(object sender, EventArgs e)
        {
            LoadMon();
            if (lsvHoadon.Tag != null)
                ShowBill((lsvHoadon.Tag as DTO_Table).SoBan);
            LoadTable();
        }

        private void DangxuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDangNhap f = new FDangNhap();
            this.Hide();
            f.ShowDialog();
        }

        private void cbMon_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            DTO_Mon selected = cb.SelectedItem as DTO_Mon;
        }

        private void btnThemmon_Click(object sender, EventArgs e)
        { 
            DTO_Table table = lsvHoadon.Tag as DTO_Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int soHDX = DAO_Bill.Instance.GetUncheckBillIDByTableID(table.SoBan);
            int maMon = (cbMon.SelectedItem as DTO_Mon).MaMon;
            int soLuong = (int)nmSoLuong.Value;

            if (soHDX == -1)
            {
                DAO_Bill.Instance.InsertXuatHD(table.SoBan);
                DAO_BillInfo.Instance.InsertXuatHDChiTiet( DAO_Bill.Instance.GetMaxSoHDX() ,maMon, soLuong);
            }
            else
            {
                DAO_BillInfo.Instance.InsertXuatHDChiTiet(soHDX, maMon, soLuong);
            }

            ShowBill(table.SoBan);
            LoadTable();
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            DTO_Table table = lsvHoadon.Tag as DTO_Table;
            
            int soHDX = DAO_Bill.Instance.GetUncheckBillIDByTableID(table.SoBan);

            if (soHDX != -1)
            {
                if (MessageBox.Show("Bạn có chắc chắn thanh toán hóa đơn cho bàn " + (table.SoBan), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    DAO_Bill.Instance.CheckOut(soHDX);
                    ShowBill(table.SoBan);
                    LoadTable();
                }
            }
        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            int soBan1 = (lsvHoadon.Tag as DTO_Table).SoBan;

            int soBan2 = (cbxChuyenban.SelectedItem as DTO_Table).SoBan;

            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} sang bàn {1} không?", soBan1, soBan2), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                DAO_Table.Instance.SwitchTable(soBan1, soBan2);

                LoadTable();
                ShowBill(soBan2);
            } 
        }
        private void btnGopBan_Click(object sender, EventArgs e)
        {
            int soBan1 = (lsvHoadon.Tag as DTO_Table).SoBan;

            int soBan2 = (cbxGopBan.SelectedItem as DTO_Table).SoBan;

            if (MessageBox.Show(string.Format("Bạn có thật sự muốn gộp bàn {0} sang bàn {1} không?", soBan1, soBan2), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                DAO_Table.Instance.GopBan(soBan1, soBan2);

                LoadTable();
                ShowBill(soBan2);
            }
        }

        #endregion

        private void thongtinTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAccountProfile f = new FAccountProfile(LoginAccount);
            this.Hide();
            f.UpdateAccount += f_UpdateAcc;
            f.ShowDialog();
            this.Show();
        }

        void f_UpdateAcc(object sender, AccountEvent e)
        {
            thongtinTKToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.TenHienThi + ")";
        }

        private void quanlyToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}


