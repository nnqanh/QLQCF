using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_Menu
    {
        public DTO_Menu(string tenMon, int soLuong, int donGia, int thanhTien)
        {
            this.TenMon = tenMon;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public DTO_Menu(DataRow row)
        {
            this.TenMon = row["tenMon"].ToString();
            this.SoLuong = (int)row["soLuong"];
            this.DonGia = (int)row["donGia"];
            this.ThanhTien = (int)row["thanhTien"];
        }

        private int thanhTien;
        public int ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }

        private int donGia;
        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private string tenMon;
        public string TenMon
        {
            get { return tenMon; }
            set { tenMon = value; }
        }
    }
}
