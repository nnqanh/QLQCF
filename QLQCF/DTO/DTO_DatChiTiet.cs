using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_DatChiTiet
    {
        public DTO_DatChiTiet(int maDDH, string tenHang, int soLuong, float thanhTien)
        {
            this.MaDDH = maDDH;
            this.TenHang = tenHang;
            this.SoLuong = soLuong;
            this.ThanhTien = thanhTien;
        }

        public DTO_DatChiTiet(DataRow row)
        {
            this.MaDDH = (int)row["maDDH"];
            this.TenHang = row["tenHang"].ToString();
            this.SoLuong = (int)row["soLuong"];
            this.ThanhTien = (float)Convert.ToDouble(row["thanhTien"].ToString());
        }

        private float thanhTien;
        public float ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }

        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private string tenHang;
        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }
        private int maDDH;
        public int MaDDH
        {
            get { return maDDH; }
            set { maDDH = value; }
        }
    }
}
