using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_BillInfo
    {
        public DTO_BillInfo(int soHDX, int maMon, int soLuongMon, int thanhTien)
        {
            this.SoHDX = soHDX;
            this.MaMon = maMon;
            this.SoLuongMon = soLuongMon;
            this.ThanhTien = thanhTien;
        }

        public DTO_BillInfo(DataRow row)
        {
            this.SoHDX = (int)row["soHDX"];
            this.MaMon = (int)row["maMon"];
            this.SoLuongMon = (int)row["soLuong"];
            this.ThanhTien = (int)row["thanhTien"];
        }

        private int thanhTien;
        public int ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value;}
        }

        private int soLuongMon;
        public int SoLuongMon
        {
            get { return soLuongMon; }
            set { soLuongMon = value;}
        }

        private int maMon;
        public int MaMon
        {
            get { return maMon; }
            set { maMon = value; }
        }

        private int soHDX;
        public int SoHDX
        {
            get { return soHDX; }
            set { soHDX = value; }
        }
    }
}
