using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_NCC
    {
        public DTO_NCC(int maNCC, string tenNCC, string diaChi, string sDT)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
            this.DiaChi = diaChi;
            this.SDT = sDT;
        }

        public DTO_NCC(DataRow row)
        {
            this.MaNCC = (int)row["maNCC"];
            this.TenNCC = row["tenNCC"].ToString();
            this.DiaChi = row["diaChi"].ToString();
            this.SDT = row["sDT"].ToString();
        }

        private string sDT;
        public string SDT
        {
            get { return sDT; }
            set { sDT = value; }
        }

        private string diaChi;
        public string DiaChi
        {
            get { return diaChi;}
            set { diaChi = value; }
        }

        private string tenNCC;
        public string TenNCC
        {
            get { return tenNCC; }
            set { tenNCC = value; }
        }

        private int maNCC;
        public int MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }
    }
}
