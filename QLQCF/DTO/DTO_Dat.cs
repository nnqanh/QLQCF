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
        public DTO_Dat( int maDDH, string tenNDH, string tenNCC,DateTime thoiGian, float tongTien)
        {
            this.MaDDH = maDDH;
            this.TenNDH = tenNDH;
            this.TenNCC = tenNCC;
            this.ThoiGian = thoiGian;
            this.TongTien = tongTien;
        }

        public DTO_Dat(DataRow row)
        {
            this.MaDDH = (int)row["maDDH"];
            this.TenNDH = row["tenNDH"].ToString();
            this.TenNCC = row["tenNCC"].ToString();

            var thoiGianTemp = row["thoiGian"];
            if (thoiGianTemp.ToString() != "")
                this.ThoiGian = (DateTime?)thoiGianTemp;

            this.TongTien = (float)Convert.ToDouble(row["tongTien"].ToString());
        }

        private float tongTien;
        public float TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        private DateTime? thoiGian;
        public DateTime? ThoiGian
        {
            get { return thoiGian; }
            set { thoiGian = value; }
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

        private int maDDH;
        public int MaDDH
        {
            get { return maDDH; }
            set { maDDH = value; }
        }
    }
}
