using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_Dat
    {
        public DTO_Dat(string tinhTrang, string tenNDH, string tenNCC, float tongTien, DateTime thoiGian, int maDDH)
        {
            this.TinhTrang = tinhTrang;            
            this.TenNDH = tenNDH;
            this.TenNCC = tenNCC;
            this.TongTien = tongTien;
            this.ThoiGian = thoiGian;
            this.MaDDH = maDDH;
        }

        public DTO_Dat(DataRow row)
        {
            this.TinhTrang = row["tinhTrang"].ToString();            
            this.TenNDH = row["tenNDH"].ToString();
            this.TenNCC = row["tenNCC"].ToString();
            this.TongTien = (float)Convert.ToDouble(row["tongTien"].ToString());

            var thoiGianTemp = row["thoiGian"];
            if (thoiGianTemp.ToString() != "")
                this.ThoiGian = (DateTime?)thoiGianTemp;
            this.MaDDH = (int)row["maDDH"];
        }

        private int maDDH;
        public int MaDDH
        {
            get { return maDDH; }
            set { maDDH = value; }
        }

        private DateTime? thoiGian;
        public DateTime? ThoiGian
        {
            get { return thoiGian; }
            set { thoiGian = value; }
        }

        private float tongTien;
        public float TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }

        private string tenNCC;
        public string TenNCC
        {
            get { return tenNCC; }
            set { tenNCC = value; }
        }

        private string tenNDH;
        public string TenNDH
        {
            get { return tenNDH; }
            set { tenNDH = value; }
        }

        private string tinhTrang;
        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
