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
    public partial class FQuanly : Form
    {
        BindingSource NVLieuList = new BindingSource();
        BindingSource NCCapList = new BindingSource();
        BindingSource NDHangList = new BindingSource();
        BindingSource HDNhapList = new BindingSource();
        public int ma;

        public DTO_Account loginAccount;
        public FQuanly()
        {
            InitializeComponent();
            LoadMua();
        }

        void LoadMua()
        {
            dtGvNVL.DataSource = NVLieuList;
            dtGvNDH.DataSource = NDHangList;
            dtGvNCC.DataSource = NCCapList;
            dtgvHoaDonNhap.DataSource = HDNhapList;
            LoadHangList();
            LoadNDHList();
            LoadNCCList();
            LoadNVL();
            LoadTenNDH();
            LoadTenNCC();
            LoadDateTimePickerBill();
            LoadListDATByDate(dtpkTuNgay.Value, dtpkDenNgay.Value);
            AddHangBinding();
            AddNDHangBinding();
            AddNCCBinding();
            AddHDNhapBinding();
        }

        void LoadNCCList()
        {
            NCCapList.DataSource = DAO_NCC.Instance.GetNCCList();
        }
        void LoadNDHList()
        {
            NDHangList.DataSource = DAO_NDHang.Instance.GetNDHangList();
        }
        void LoadHangList()
        {
            NVLieuList.DataSource = DAO_Hang.Instance.GetListHang();
        }
        void LoadNVL()
        {
            List<DTO_Hang> listMon = DAO_Hang.Instance.GetListHang();
            cbNVL.DataSource = listMon;
            cbNVL.DisplayMember = "TenHang";
        }
        void LoadTenNDH()
        {
            List<DTO_NDHang> listMon = DAO_NDHang.Instance.GetNDHangList();
            cbTenNDH.DataSource = listMon;
            cbTenNDH.DisplayMember = "TenNDH";
        }
        void LoadTenNCC()
        {
            List<DTO_NCC> listMon = DAO_NCC.Instance.GetNCCList();
            cbTenNCC.DataSource = listMon;
            cbTenNCC.DisplayMember = "TenNCC";
        }

        void AddNDHangBinding()
        {
            txbMaNDH.DataBindings.Add(new Binding("Text", dtGvNDH.DataSource, "MaNDH", true, DataSourceUpdateMode.Never));
            txbTenNDH.DataBindings.Add(new Binding("Text", dtGvNDH.DataSource, "TenNDH", true, DataSourceUpdateMode.Never));
            txbDiaChiNDH.DataBindings.Add(new Binding("Text", dtGvNDH.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
        }
        void AddNCCBinding()
        {
            txbMaNCC.DataBindings.Add(new Binding("Text", dtGvNCC.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            txbTenNCC.DataBindings.Add(new Binding("Text", dtGvNCC.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));
            txbDiachiNCC.DataBindings.Add(new Binding("Text", dtGvNCC.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txbSDT.DataBindings.Add(new Binding("Text", dtGvNCC.DataSource, "SDT", true, DataSourceUpdateMode.Never));
        }

        void AddHangBinding()
        {
            txbMahang.DataBindings.Add(new Binding("Text", dtGvNVL.DataSource, "MaHang", true, DataSourceUpdateMode.Never));
            txbTenHang.DataBindings.Add(new Binding("Text", dtGvNVL.DataSource, "TenHang", true, DataSourceUpdateMode.Never));
            txbDonVi.DataBindings.Add(new Binding("Text", dtGvNVL.DataSource, "DonVi", true, DataSourceUpdateMode.Never));
            nUDDongia.DataBindings.Add(new Binding("Value", dtGvNVL.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
        }
        void AddHDNhapBinding()
        {
            cbTenNDH.DataBindings.Add(new Binding("Text", dtgvHoaDonNhap.DataSource, "TenNDH", true, DataSourceUpdateMode.Never));
            cbTenNCC.DataBindings.Add(new Binding("Text", dtgvHoaDonNhap.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));
            dtpkThoiGian.DataBindings.Add(new Binding("Text", dtgvHoaDonNhap.DataSource, "ThoiGian", true, DataSourceUpdateMode.Never));
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            FChinh f = new FChinh(loginAccount);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #region Hang

        List<DTO_Hang> SearchNVLByTenHang(string ten)
        {
            List<DTO_Hang> listAcc = DAO_Hang.Instance.SearchNVLByTenHang(ten);
            return listAcc;
        }
        private void btnTimkiemNVL_Click(object sender, EventArgs e)
        {
            NVLieuList.DataSource = SearchNVLByTenHang(txbTimkiemNVL.Text);
        }
        private void btnXemNVL_Click(object sender, EventArgs e)
        {
            LoadHangList();
        }

        private void btnThemNVL_Click(object sender, EventArgs e)
        {
            string tenHang = txbTenHang.Text;
            string donVi = txbDiaChiNDH.Text;
            float donGia = (float)nUDDongia.Value;

            if (DAO_Hang.Instance.InsertHang(tenHang, donVi, donGia))
            {
                MessageBox.Show("Thêm nguyên vật liệu thành công");
                LoadHangList();
                if (insertHang != null)
                    insertHang(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nguyên vật liệu");
            }
        }

        private void btnSuaNVL_Click(object sender, EventArgs e)
        {
            string tenHang = txbTenHang.Text;
            string donVi = txbDonVi.Text;
            float donGia = (float)nUDDongia.Value;
            int maHang = Convert.ToInt32(txbMahang.Text);

            if (DAO_Hang.Instance.UpdateHang(tenHang, donVi, donGia, maHang))
            {
                MessageBox.Show("Sửa nguyên vật liệu thành công");
                LoadHangList();
                if (updateHang != null)
                    updateHang(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa nguyên vật liệu");
            }
        }

        private void btnXoaNVL_Click(object sender, EventArgs e)
        {
            int maHang = Convert.ToInt32(txbMahang.Text);

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (DAO_Hang.Instance.CheckDatCTByMaHang(maHang))
                {
                    if (DAO_Hang.Instance.DeleteHang(maHang))
                    {
                        MessageBox.Show("Xóa nguyên vật liệu thành công");
                        LoadHangList();
                        if (deleteHang != null)
                            deleteHang(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa nguyên vật liệu");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không thể xóa hàng hóa đã có đơn đặt hàng");
                    return;
                } 
                    
            }
        }
        private event EventHandler insertHang;
        public event EventHandler InsertHang
        {
            add { insertHang += value; }
            remove { insertHang -= value; }
        }
        private event EventHandler deleteHang;
        public event EventHandler DeleteHang
        {
            add { deleteHang += value; }
            remove { deleteHang -= value; }
        }
        private event EventHandler updateHang;
        public event EventHandler UpdateHang
        {
            add { updateHang += value; }
            remove { updateHang -= value; }
        }
        #endregion

        #region NgDatHang
        List<DTO_NDHang> SearchNDHByTenNDH(string ten)
        {
            List<DTO_NDHang> listNDH = DAO_NDHang.Instance.SearchNDHByTenNDH(ten);
            return listNDH;
        }
        private void btnTKNDH_Click(object sender, EventArgs e)
        {
            NDHangList.DataSource = SearchNDHByTenNDH(txbTKNDH.Text);
        }
        private void btnXemNDH_Click(object sender, EventArgs e)
        {
            LoadNDHList();
        }

        private void btnThemNDH_Click(object sender, EventArgs e)
        {
            string tenNDH = txbTenNDH.Text;

            if (DAO_NDHang.Instance.InsertNDHang(tenNDH))
            {
                MessageBox.Show("Thêm người đặt hàng thành công");
                LoadNDHList();
                if (insertNDH != null)
                    insertNDH(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm người đặt hàng");
            }
        }

        private void btnSuaNDH_Click(object sender, EventArgs e)
        {
            string tenNDH = txbTenNDH.Text;
            int maNDHang = Convert.ToInt32(txbMaNDH.Text);

            if (DAO_NDHang.Instance.UpdateNDHang(tenNDH, maNDHang))
            {
                MessageBox.Show("Sửa người đặt hàng thành công");
                LoadNDHList();
                if (updateNDH != null)
                    updateNDH(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa người đặt hàng");
            }
        }

        private void btnXoaNDH_Click(object sender, EventArgs e)
        {
            int maNDHang = Convert.ToInt32(txbMaNDH.Text);
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa người đặt hàng này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (DAO_NDHang.Instance.CheckDatByMaNDH(maNDHang))
                {
                    if (DAO_NDHang.Instance.DeleteNDHang(maNDHang))
                    {
                        MessageBox.Show("Xóa người đặt hàng thành công");
                        LoadNDHList();
                        if (deleteNDH != null)
                            deleteNDH(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa người đặt hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không thể xóa người đặt hàng đã có đơn đặt hàng");
                    return;
                }
            }
        }
        private event EventHandler insertNDH;
        public event EventHandler InsertNDH
        {
            add { insertNDH += value; }
            remove { insertNDH -= value; }
        }
        private event EventHandler deleteNDH;
        public event EventHandler DeleteNDH
        {
            add { deleteNDH += value; }
            remove { deleteNDH -= value; }
        }
        private event EventHandler updateNDH;
        public event EventHandler UpdateNDH
        {
            add { updateNDH += value; }
            remove { updateNDH -= value; }
        }
        #endregion

        #region NhaCC
        List<DTO_NCC> SearchNCCByTenNCC(string ten)
        {
            List<DTO_NCC> listNCC = DAO_NCC.Instance.SearchNCCByTenNCC(ten);
            return listNCC;
        }
        private void btnTKNCC_Click(object sender, EventArgs e)
        {
            NCCapList.DataSource = SearchNCCByTenNCC(txbNCC.Text);
        }
        private void btnXemNCC_Click(object sender, EventArgs e)
        {
            LoadNCCList();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            string tenNCC = txbTenNCC.Text;
            string diaChi = txbDiachiNCC.Text;
            string soDT = txbSDT.Text;

            if (DAO_NCC.Instance.InsertNCC(tenNCC, diaChi, soDT))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công");
                LoadNCCList();
                if (insertNCC != null)
                    insertNCC(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhà cung cấp");
            }
        }
        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            string tenNCC = txbTenNCC.Text;
            string diaChi = txbDiachiNCC.Text;
            string soDT = txbSDT.Text;
            int maNCC = Convert.ToInt32(txbMaNCC.Text);  

            if (DAO_NCC.Instance.CheckSDT(soDT))
            {
                if (DAO_NCC.Instance.UpdateNCC(tenNCC, diaChi, soDT, maNCC))
                {
                    MessageBox.Show("Sửa nhà cung cấp thành công");
                    LoadNCCList();
                    if (updateNCC != null)
                        updateNCC(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa nhà cung cấp");
                }
            }
            else
            {
                MessageBox.Show("Số điện thoại không phù hợp");
                return;
            }
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            int maNCC = Convert.ToInt32(txbMaNCC.Text);
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (DAO_Dat.Instance.CheckDatByMaNCC(maNCC))
                {
                    if (DAO_NCC.Instance.DeleteNCC(maNCC))
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công");
                        LoadNCCList();
                        if (deleteNCC != null)
                            deleteNCC(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa nhà cung cấp");
                    }
                }    
                else
                {
                    MessageBox.Show("Bạn không thể xóa nhà cung cấp đã có đơn đặt hàng");
                    return;
                }    
            }
        }
        private event EventHandler insertNCC;
        public event EventHandler InsertNCC
        {
            add { insertNCC += value; }
            remove { insertNCC -= value; }
        }
        private event EventHandler deleteNCC;
        public event EventHandler DeleteNCC
        {
            add { deleteNCC += value; }
            remove { deleteNCC -= value; }
        }
        private event EventHandler updateNCC;
        public event EventHandler UpdateNCC
        {
            add { updateNCC += value; }
            remove { updateNCC -= value; }
        }

        #endregion

        #region HoaDonNhap
        void LoadListDATByDate(DateTime tuNgay, DateTime denNgay)
        {
            HDNhapList.DataSource = DAO_Dat.Instance.LayDATtuThoiGian(tuNgay, denNgay);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpkDenNgay.Value = dtpkTuNgay.Value.AddMonths(1).AddDays(-1);
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            LoadListDATByDate(dtpkTuNgay.Value, dtpkDenNgay.Value);
        }
        void ShowDATInfo(int maDDH)
        {
            lsvDATinfo.Items.Clear();
            List<DTO_DatChiTiet> listThongTinDAT = DAO_DatChiTiet.Instance.LayThongTinDat(maDDH);

            foreach (DTO_DatChiTiet item in listThongTinDAT)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaDDH.ToString());
                lsvItem.SubItems.Add(item.TenHang.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                lsvDATinfo.Items.Add(lsvItem);
            }
        }

        void dtgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                int maDDH = (int)dtgvHoaDonNhap.Rows[numrow].Cells[4].Value;
                ma = maDDH;
                ShowDATInfo(maDDH);
            } 
        }
        private void btnThemNgVL_Click(object sender, EventArgs e)
        {
            int maHang = (cbNVL.SelectedItem as DTO_Hang).MaHang;
            int soLuong = (int)nmSoLuong.Value;
            DAO_DatChiTiet.Instance.InsertDatChiTiet(ma, maHang, soLuong);
            ShowDATInfo(ma);
            LoadListDATByDate(dtpkTuNgay.Value, dtpkDenNgay.Value);
        }

        private void btnThemHDN_Click(object sender, EventArgs e)
        {
            string tenNDH = cbTenNDH.Text;
            string tenNCC = cbTenNCC.Text;
            DateTime thoiGian = dtpkThoiGian.Value;

            if (DAO_Dat.Instance.InsertDAT(tenNDH, tenNCC, thoiGian))
            {
                MessageBox.Show("Thêm hóa đơn nhập hàng thành công");
                LoadListDATByDate(dtpkTuNgay.Value, dtpkDenNgay.Value);
                if (insertDAT != null)
                    insertDAT(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm hóa đơn nhập hàng");
            }
        }

        private void btnSuaHDN_Click(object sender, EventArgs e)
        {
            int maDDH = ma;
            string tenNDH = cbTenNDH.Text;
            string tenNCC = cbTenNCC.Text;
            DateTime thoiGian = dtpkThoiGian.Value;

            if (DAO_Dat.Instance.UpdateDAT(maDDH, tenNDH, tenNCC, thoiGian))
            {
                MessageBox.Show("Sửa hóa đơn nhập hàng thành công");
                LoadListDATByDate(dtpkTuNgay.Value, dtpkDenNgay.Value);
                if (updateDAT != null)
                    updateDAT(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa hóa đơn nhập hàng");
            }
        }

        private void btnXoaHDN_Click(object sender, EventArgs e)
        {
            int maDDH = ma;

            if (DAO_Dat.Instance.DeleteDAT(maDDH))
            {
                MessageBox.Show("Xóa hóa đơn nhập hàng thành công");
                LoadListDATByDate(dtpkTuNgay.Value, dtpkDenNgay.Value);
                if (deleteDAT != null)
                    deleteDAT(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa hóa đơn nhập hàng");
            }
        }
        private event EventHandler insertDAT;
        public event EventHandler InsertDAT
        {
            add { insertDAT += value; }
            remove { insertDAT -= value; }
        }
        private event EventHandler deleteDAT;
        public event EventHandler DeleteDAT
        {
            add { deleteDAT += value; }
            remove { deleteDAT -= value; }
        }
        private event EventHandler updateDAT;
        public event EventHandler UpdateDAT
        {
            add { updateDAT += value; }
            remove { updateDAT -= value; }
        }
        #endregion
    }
}
