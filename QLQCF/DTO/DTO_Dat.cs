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
        public DTO_Dat (int maDDH, int maNDH, int maNCC, DateTime? thoiGian, float tongTien)
        {
            this.MaDDH = maDDH;
            this.MaNDH = maNDH;
            this.MaNCC = maNCC;
            this.ThoiGian = thoiGian;
            this.TongTien = tongTien;
        }

        public DTO_Dat (DataRow row)
        {
            this.MaDDH = (int)row["maDDH"];
            this.MaNDH = (int)row["maNDH"];
            this.MaNCC = (int)row["maNCC"];
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

        private int maNCC;
        public int MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }

        private int maNDH;
        public int MaNDH
        {
            get { return maNDH; }
            set { maNDH = value; }
        }

        private int maDDH;
        public int MaDDH
        {
            get { return maDDH; }
            set { maDDH = value; }
        }
    }
}
