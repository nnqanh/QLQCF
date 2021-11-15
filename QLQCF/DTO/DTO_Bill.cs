using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLQCF.DTO
{
    public class DTO_Bill
    {
        public DTO_Bill(int soHDX, int soBan, TimeSpan? gioVao, TimeSpan? gioRa, DateTime? ngayXuat, float tongCong, int tinhTrang)
        {
            this.SoHDX = soHDX;
            this.SoBan = soBan;
            this.GioVao = gioVao;
            this.GioRa = gioRa;
            this.NgayXuat = ngayXuat;
            this.TongCong = tongCong;
            this.TinhTrang = tinhTrang;
        }
        public DTO_Bill(DataRow row)
        {
            this.SoHDX = (int)row["SoHDX"];
            this.SoBan = (int)row["soBan"];

            var gioVaoTemp = row["gioVao"];
            if (gioVaoTemp.ToString() != "")
                this.GioVao = (TimeSpan?)gioVaoTemp;

            var gioRaTemp = row["gioRa"];
            if (gioRaTemp.ToString() != "")
                this.GioRa = (TimeSpan?)gioRaTemp;

            var ngayXuatTemp = row["ngayXuat"];
            if (ngayXuatTemp.ToString() != "")
                this.NgayXuat = (DateTime?)ngayXuatTemp;

            this.TongCong = (float)Convert.ToDouble(row["tongCong"].ToString());
            this.TinhTrang = (int)row["tinhTrang"];
        }

        private float tongCong;
        public float TongCong
        {
            get { return tongCong; }
            set { tongCong = value; }
        }

        private DateTime? ngayXuat;
        public DateTime? NgayXuat
        {
            get { return ngayXuat; }
            set { ngayXuat = value;}
        }

        private int soBan;
        public int SoBan
        {
            get { return soBan; }
            set { soBan = value; }
        }

        private int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
        private TimeSpan? gioRa;
        
        public TimeSpan? GioRa
        {
            get { return gioRa; }
            set { gioRa = value; }
        }
        private TimeSpan? gioVao;

        public TimeSpan? GioVao
        {
            get { return gioVao; }
            set { gioVao = value; }
        }

        private int soHDX;
        public int SoHDX
        {
            get { return soHDX; }
            set { soHDX = value; }  
        }
    }
}
