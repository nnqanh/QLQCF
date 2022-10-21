using System;
using QLQCF.DAO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLQCF.DTO;

namespace QLQCF
{
    public partial class FQuanlyBan : Form
    {
        BindingSource MonList = new BindingSource();
        BindingSource BanList = new BindingSource();
        BindingSource AccountList = new BindingSource();

        public DTO_Account loginAccount;

        public FQuanlyBan()
        {
            InitializeComponent();
            dtgvMon.DataSource = MonList;
            dtGvBan.DataSource = BanList;
            dtgvTK.DataSource = AccountList;
            LoadMonList();
            LoadBanList();
            LoadAccount();
            LoadCbBan();
            LoadCbTinhTrangMon();
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkTuNgay.Value, dtpkDenNgay.Value);
            AddBanBinding();
            AddMonBinding();
            AddAccountBinding();
        }
        #region methods
        
        void LoadAccount()
        {
            AccountList.DataSource = DAO_Account.Instance.GetListAcc();
        }
        void LoadMonList()
        {
            MonList.DataSource = DAO_Mon.Instance.GetListMonQuanLy();
        }
        void LoadBanList()
        {
            BanList.DataSource = DAO_Table.Instance.LoadTableList();
        }
        void LoadCbBan()
        {
            List<DTO_TinhTrang> listTTBan = DAO_TinhTrang.Instance.LoadTinhTrangBan();
            cbTinhTrangBan.DataSource = listTTBan;
            cbTinhTrangBan.DisplayMember = "TinhTrang";
        }
        void LoadCbTinhTrangMon()
        {
            List<DTO_TinhTrang> listTTMon = DAO_TinhTrang.Instance.LoadTinhTrangMon();
            cbbTinhTrangMon.DataSource = listTTMon;
            cbbTinhTrangMon.DisplayMember = "TinhTrang";
        }
        void LoadListBillByDate(DateTime tuNgay, DateTime denNgay)
        {
            dtgvHoaDon.DataSource = DAO_Bill.Instance.GetBillListByDate(tuNgay, denNgay);
        }

        void AddBanBinding()
        {
            nmSoBan.DataBindings.Add(new Binding("Text", dtGvBan.DataSource, "SoBan", true, DataSourceUpdateMode.Never));
            cbTinhTrangBan.DataBindings.Add(new Binding("Text", dtGvBan.DataSource, "TinhTrang", true, DataSourceUpdateMode.Never));
        }
        void AddMonBinding()
        {
            txbTenmon.DataBindings.Add(new Binding("Text", dtgvMon.DataSource, "TenMon", true, DataSourceUpdateMode.Never));
            txbMamon.DataBindings.Add(new Binding("Text", dtgvMon.DataSource, "MaMon", true, DataSourceUpdateMode.Never));
            nUDDongia.DataBindings.Add(new Binding("Value", dtgvMon.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
            cbbTinhTrangMon.DataBindings.Add(new Binding("Text", dtgvMon.DataSource, "TinhTrang", true, DataSourceUpdateMode.Never));
        }
        void AddAccountBinding()
        {
            txbTDN.DataBindings.Add(new Binding("Text", dtgvTK.DataSource, "TenDN", true, DataSourceUpdateMode.Never));
            txbTHT.DataBindings.Add(new Binding("Text", dtgvTK.DataSource, "TenHienThi", true, DataSourceUpdateMode.Never));
            nUDLoaiTK.DataBindings.Add(new Binding("Value", dtgvTK.DataSource, "Loai", true, DataSourceUpdateMode.Never));
        }
        #endregion

        #region events
        private void lbExit_Click(object sender, EventArgs e)
        {
            FChinh f = new FChinh(loginAccount);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        #endregion

        #region Mon

        List<DTO_Mon> SearchMon(string tenMon)
        {
            List<DTO_Mon> listMon = DAO_Mon.Instance.SearchMon(tenMon);
            return listMon;
        }
        private void btnTKMon_Click(object sender, EventArgs e)
        {
            MonList.DataSource = SearchMon(txbTKMon.Text);
        }

        private void btnXemMon_Click(object sender, EventArgs e)
        {
            LoadMonList();
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (txbTenmon.TextLength == 0)
            {
                MessageBox.Show("Không thể thêm món");
            }
            else if ((float)nUDDongia.Value == null)
            {
                MessageBox.Show("Không thể thêm món");
            }
            else
            {
                string tenMon = txbTenmon.Text;
                string tinhTrang = cbbTinhTrangMon.Text;
                float donGia = (float)nUDDongia.Value;

                if (DAO_Mon.Instance.InsertMon(tenMon, donGia, tinhTrang))
                {
                    MessageBox.Show("Thêm món thành công");
                    LoadMonList();
                    if (insertMon != null)
                        insertMon(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Không thể thêm món");
                }
            }   
        }

        private void btnSuaMon_Click(object sender, EventArgs e)
        {
            if (txbTenmon.TextLength == 0)
            {
                MessageBox.Show("Không thể sửa món");
            }
            else if ((float)nUDDongia.Value == null)
            {
                MessageBox.Show("Không thể sửa món");
            }
            else
            {
                string tenMon = txbTenmon.Text;
                string tinhTrang = cbbTinhTrangMon.Text;
                float donGia = (float)nUDDongia.Value;
                int maMon = Convert.ToInt32(txbMamon.Text);

                if (DAO_Mon.Instance.UpdateMon(tenMon, donGia, maMon, tinhTrang))
                {
                    MessageBox.Show("Sửa món thành công");
                    LoadMonList();
                    if (updateMon != null)
                        updateMon(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Không thể sửa món");
                }
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            int maMon = Convert.ToInt32(txbMamon.Text);
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (DAO_Mon.Instance.CheckHDByMaMon(maMon))
                {
                    if (DAO_Mon.Instance.DeleteMon(maMon))
                    {
                        MessageBox.Show("Xóa món thành công");
                        LoadMonList();
                        if (deleteMon != null)
                            deleteMon(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa món");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không thể xóa món đã có trong hóa đơn đang bán, thay vào đó hãy cập nhật lại tình trạng của món");
                    return;
                }
            }
        }

        private event EventHandler insertMon;
        public event EventHandler InsertMon
        {
            add { insertMon += value; }
            remove { insertMon -= value; }
        }
        private event EventHandler deleteMon;
        public event EventHandler DeleteMon
        {
            add { deleteMon += value; }
            remove { deleteMon -= value; }
        }
        private event EventHandler updateMon;
        public event EventHandler UpdateMon
        {
            add { updateMon += value; }
            remove { updateMon -= value; }
        }

        #endregion

        #region Ban
        private void cbbTinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            DTO_Table selected = cb.SelectedItem as DTO_Table;
        }
        private void btnXemBan_Click(object sender, EventArgs e)
        {
            LoadBanList();
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            int soBan = Convert.ToInt32(nmSoBan.Text);
            string tinhTrang = cbTinhTrangBan.Text;

            if (DAO_Table.Instance.CheckSoBan(soBan))
            {
                if (DAO_Table.Instance.InsertBan(soBan, tinhTrang))
                {
                    MessageBox.Show("Thêm bàn thành công");
                    LoadBanList();
                    if (insertBan != null)
                        insertBan(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm bàn");
                }
            }   
            else
            {
                MessageBox.Show("Số bàn đã tồn tại");
                return;
            }
            
        }

        private void btnSuaban_Click(object sender, EventArgs e)
        {
            int soBan = Convert.ToInt32(nmSoBan.Text);
            string tinhTrang = cbTinhTrangBan.Text;

            if (DAO_Table.Instance.UpdateBan(soBan, tinhTrang))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadBanList();
                if (updateBan != null)
                    updateBan(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }
        }

        private void btnXoaban_Click(object sender, EventArgs e)
        {
            int soBan = Convert.ToInt32(nmSoBan.Text);
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn "+soBan, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (DAO_Table.Instance.CheckHDXbySoBan(soBan))
                {
                    if (DAO_Table.Instance.DeleteBan(soBan))
                    {
                        MessageBox.Show("Xóa bàn thành công");
                        LoadBanList();
                        if (deleteBan != null)
                            deleteBan(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa bàn");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không thể xóa bàn đã có hóa đơn");
                    return;
                }
            }
        }

        private event EventHandler insertBan;
        public event EventHandler InsertBan
        {
            add { insertBan += value; }
            remove { insertBan -= value; }
        }
        private event EventHandler deleteBan;
        public event EventHandler DeleteBan
        {
            add { deleteBan += value; }
            remove { deleteBan -= value; }
        }
        private event EventHandler updateBan;
        public event EventHandler UpdateBan
        {
            add { updateMon += value; }
            remove { updateMon -= value; }
        }
        #endregion

        #region Account
        List<DTO_Account> SearchAcc(string str)
        {
            List<DTO_Account> listAcc = DAO_Account.Instance.SearchAcc(str);
            return listAcc;
        }
        private void btnTKTK_Click(object sender, EventArgs e)
        {
            AccountList.DataSource = SearchAcc(txbTKTK.Text);
        }
        void AddAccount(string tenDN, string tenHT, int loai)
        {
            if (DAO_Account.Instance.InsertAccount(tenDN, tenHT, loai))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            LoadAccount();
        }
        void UpdateAccount(string tenDN, string tenHT, int loai)
        {
            if (DAO_Account.Instance.UpdateAccount(tenDN, tenHT, loai))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
            LoadAccount();
        }
        void DeleteAccount(string ten)
        {
            if (loginAccount.TenDN.Equals(ten))
            {
                MessageBox.Show("Vui lòng không xóa tài khoản đang đăng nhập");
                return;
            }    
            if (DAO_Account.Instance.DeleteAccount(ten))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            LoadAccount();
        }
        void ResetPass(string tenDN)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn reset lại mật khẩu không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {   
                if (DAO_Account.Instance.ResetAccount(tenDN))
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show("Đặt lại mật khẩu thất bại");
                }
            }
            
            LoadAccount();
        }
        private void btnXemTK_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void btnThemTK_Click(object sender, EventArgs e)
        {
            if (txbTDN.TextLength == 0)
            {
                MessageBox.Show("Không thể thêm tài khoản");
            }
            else if (txbTHT.TextLength == 0)
            {
                MessageBox.Show("Không thể thêm tài khoản");
            }
            else
            {
                string tenDN = txbTDN.Text;
                string tenHT = txbTHT.Text;
                int loai = (int)nUDLoaiTK.Value;
                AddAccount(tenDN, tenHT, loai);
            }
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            if (txbTDN.TextLength == 0)
            {
                MessageBox.Show("Không thể sửa tài khoản");
            }
            else if (txbTHT.TextLength == 0)
            {
                MessageBox.Show("Không thể sửa tài khoản");
            }
            else
            {
                string tenDN = txbTDN.Text;
                string tenHT = txbTHT.Text;
                int loai = (int)nUDLoaiTK.Value;

                UpdateAccount(tenDN, tenHT, loai);
            }
        }
        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            string tenDN = txbTDN.Text;

            DeleteAccount(tenDN);
        }
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            string tenDN = txbTDN.Text;
            ResetPass(tenDN);
        }
        #endregion

        #region HoaDon
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpkDenNgay.Value = dtpkTuNgay.Value.AddMonths(1).AddDays(-1);
        }
        
        private void btnXemNCC_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkTuNgay.Value, dtpkDenNgay.Value);
        }

        void ShowBillInfo(int soHDX)
        {
            lsvBillInfo.Items.Clear();
            List<DTO_Menu> listThongTinBill = DAO_Menu.Instance.LayThongTinHDXtuSoHDX(soHDX);

            foreach (DTO_Menu item in listThongTinBill)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenMon.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                lsvBillInfo.Items.Add(lsvItem);
            }
        }
        private void dtgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            int soHDX = (int)dtgvHoaDon.Rows[numrow].Cells[0].Value;
            lsvBillInfo.Tag = soHDX;
            ShowBillInfo(soHDX);
        }
        #endregion

        private void nmSoBan_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
