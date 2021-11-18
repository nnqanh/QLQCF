using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_TinhTrangBan
    {
        public DTO_TinhTrangBan(string tinhTrang)
        {
            this.tinhTrang = tinhTrang;
        }

        public DTO_TinhTrangBan(DataRow row)
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
