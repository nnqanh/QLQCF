using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_DatChiTiet
    {
        private static DAO_DatChiTiet instance;

        public static DAO_DatChiTiet Instance
        {
            get { if (instance == null) instance = new DAO_DatChiTiet(); return DAO_DatChiTiet.instance; }
            private set { DAO_DatChiTiet.instance = value; }
        }

        private DAO_DatChiTiet() { }
        public void DeleteDatChiTietByMaHang(int maHang)
        {
            DataProvider.Instance.ExecuteQuery("delete DatChiTiet where MaHang = " + maHang);
        }
    }
}
