using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_NDHang
    {
        public DTO_NDHang (int maNDH, string tenNDH, string diaChi)
        {
            this.MaNDH = maNDH;
            this.TenNDH = tenNDH;
            this.DiaChi = diaChi;
        }

        public DTO_NDHang(DataRow row)
        {
            this.MaNDH = (int)row["maNDH"];
            this.TenNDH = row["tenNDH"].ToString();
            this.DiaChi = row["diaChi"].ToString();
        }

        private string diaChi;
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        private string tenNDH;
        public string TenNDH
        {
            get { return tenNDH; }
            set { tenNDH = value; }
        }

        private int maNDH;
        public int MaNDH
        {
            get { return maNDH; }
            set { maNDH = value; }
        }
    }
}
