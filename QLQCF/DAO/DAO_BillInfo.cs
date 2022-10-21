using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void GetBillInfoBySoHDX(int soHDX)
        {
            DataProvider.Instance.ExecuteQuery("select * from XuatHDChiTiet where SoHDX = " + soHDX);
        }

        public void DeleteBillInfoByMaMon(int maMon)
        {
            DataProvider.Instance.ExecuteQuery("delete XuatHDChiTiet where MaMon = " + maMon);
        }
        public List<DTO_BillInfo> LoadListBillInfo()
        {
            List<DTO_BillInfo> ListBillInfo = new List<DTO_BillInfo>();

            string query = "select * from XuatHDChiTiet";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_BillInfo table = new DTO_BillInfo(item);
                ListBillInfo.Add(table);
            }
            return ListBillInfo;
        }

        public void InsertXuatHDChiTiet(int soHDX, int soBan, int soLuong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec spInsertXuatHDChiTiet @soHDX , @maMon , @soLuong", new object[] { soHDX, soBan, soLuong });
        }
    }
}
