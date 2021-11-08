using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_BillInfo
    {
        private static DAO_BillInfo instance;

        public static DAO_BillInfo Instance
        {
            get { if (instance == null) instance = new DAO_BillInfo(); return DAO_BillInfo.instance; }
            private set { DAO_BillInfo.instance = value; }
        }

        private DAO_BillInfo() { }

        public void InsertXuatHDChiTiet(int soHDX, int soBan, int soLuong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec spInsertXuatHDChiTiet @soHDX , @maMon , @soLuong", new object[] { soHDX, soBan, soLuong });
        }
    }
}
