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
            LoadHangList();
            LoadNDHList();
            LoadNCCList();
            AddHangBinding();
            AddNDHangBinding();
            AddNCCBinding();
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
            string diaChi = txbDiaChiNDH.Text;

            if (DAO_NDHang.Instance.InsertNDHang(tenNDH, diaChi))
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
            string diaChi = txbDiaChiNDH.Text;
            int maNDHang = Convert.ToInt32(txbMaNDH.Text);

            if (DAO_NDHang.Instance.UpdateNDHang(tenNDH, diaChi, maNDHang))
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

        private void btnNCC_Click(object sender, EventArgs e)
        {
            int maNCC = Convert.ToInt32(txbMaNCC.Text);

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
    }
}
