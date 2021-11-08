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
        public FChinh()
        {
            InitializeComponent();
            LoadTable();
            LoadMon();
        }

        #region Method

        void LoadTable()
        {
            fLPBan.Controls.Clear();

            List<DTO_Table> tableList = DAO_Table.Instance.LoadTableList();

            foreach (DTO_Table item in tableList)
            {
                Button btn = new Button() { Width = DAO_Table.TableWidth, Height = DAO_Table.TableHeight };
                btn.Text = "Bàn " + (item.SoBan +1) + Environment.NewLine + item.TinhTrang;
                btn.Click += btn_Click;
                btn.Tag = item;

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

        void ShowBill(int soBan)
        {
            lsvHoadon.Items.Clear();
            List<DTO_Menu> listBillInfo = DAO_Menu.Instance.GetListMenuByTable(DAO_Bill.Instance.GetUncheckBillIDByTableID(soBan));
            int tongTien = 0;
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
                if (MessageBox.Show("Bạn có chắc chắn thanh toán hóa đơn cho bàn " + (table.SoBan +1), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    DAO_Bill.Instance.CheckOut(soHDX);
                    ShowBill(table.SoBan);
                    LoadTable();
                }
            }
        }

        #endregion
    }
}


