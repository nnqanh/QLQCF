using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_Hang
    {
        public DTO_Hang(int maHang, string tenHang, string donVi, float donGia)
        {
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.DonVi = donVi;
            this.DonGia = donGia;
        }
        public DTO_Hang (DataRow row)
        {
            this.MaHang = (int)row["maHang"];
            this.TenHang = row["tenHang"].ToString();
            this.DonVi = row["donVi"].ToString();
            this.DonGia = (float)Convert.ToDouble(row["donGia"].ToString());
        }

        private float donGia;
        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        private string donVi;
        public string DonVi
        {
            get { return donVi; }
            set { donVi = value; }
        }

        private string tenHang;
        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }

        private int maHang;
        public int MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }
    }
}
