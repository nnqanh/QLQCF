using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_TinhTrang
    {
        public DTO_TinhTrang(string tinhTrang)
        {
            this.tinhTrang = tinhTrang;
        }

        public DTO_TinhTrang(DataRow row)
        {
            this.TinhTrang = row["tinhTrang"].ToString();
        }

        private string tinhTrang;

        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
