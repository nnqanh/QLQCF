using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_Table
    {
        public DTO_Table(int soBan, string tinhTrang)
        {
            this.soBan = soBan;
            this.tinhTrang = tinhTrang;
        }

        public DTO_Table(DataRow row)
        {
            this.SoBan = (int)row["soBan"];
            this.TinhTrang = row["tinhTrang"].ToString();
        }

        private string tinhTrang;

        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }

        private int soBan;

        public int SoBan 
        {
            get { return soBan; }
            set { soBan = value; }
        }
    }
}
