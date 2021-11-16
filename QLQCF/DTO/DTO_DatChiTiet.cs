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
        public DTO_DatChiTiet(int maDDH, int maHang, int soLuong, float thanhTien)
        {
            this.MaDDH = maDDH;
            this.MaHang = maHang;
            this.SoLuong = soLuong;
            this.ThanhTien = thanhTien;
        }
        public DTO_DatChiTiet(DataRow row)
        {
            this.MaDDH = (int)row["maDDH"];
            this.MaHang = (int)row["maHang"];
            this.SoLuong = (int)row["soLuong"];
            this.ThanhTien = (float)Convert.ToDouble(row["thanhTien"].ToString());
        }

        private float thanhTien;
        public float ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value;}
        }

        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private int maHang;
        public int MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }

        private int maDDH;
        public int MaDDH
        {
            get { return maDDH; }
            set { maDDH = value; }
        }
    }
}
