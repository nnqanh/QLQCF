using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_Mon
    {
        public DTO_Mon(int maMon, string tenMon, float donGia)
        {
            this.MaMon = maMon;
            this.TenMon = tenMon;
            this.DonGia = donGia;
        }

        public DTO_Mon(DataRow row)
        {
            this.MaMon = (int)row["maMon"];
            this.TenMon = row["tenMon"].ToString();
            this.DonGia = (float)Convert.ToDouble(row["donGia"].ToString());
        }

        private float donGia;
        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        private string tenMon;
        public string TenMon
        {
            get { return tenMon; }
            set { tenMon = value; }
        }

        private int maMon;
        public int MaMon
        {
            get { return maMon; }
            set { maMon = value; }
        }
    }
}
