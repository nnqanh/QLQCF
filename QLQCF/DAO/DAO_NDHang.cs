using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_NDHang
    {
        private static DAO_NDHang instance;

        public static DAO_NDHang Instance
        {
            get { if (instance == null) instance = new DAO_NDHang(); return instance; }
            private set { instance = value; }
        }

        private DAO_NDHang() { }

        public List<DTO_NDHang> GetNDHangList()
        {
            List<DTO_NDHang> list = new List<DTO_NDHang>();

            string query = "select * from NgDatHang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_NDHang NDHang = new DTO_NDHang(item);
                list.Add(NDHang);
            }

            return list;
        }
        public bool InsertNDHang(string tenNDHang)
        {
            string query = string.Format("exec spInsertNDHang N'{0}'", tenNDHang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateNDHang(string tenNDHang, int maNDHang)
        {
            string query = string.Format("update NgDatHang set TenNDH = N'{0}', DiaChi = N'182 Sóng Hồng, Thừa Thiên Huế' where MaNDH = {1}", tenNDHang, maNDHang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteNDHang(int maNDHang)
        {
            string query = string.Format("delete NgDatHang where MaNDH = {0}", maNDHang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<DTO_NDHang> SearchNDHByTenNDH(string tenNDH)
        {
            List<DTO_NDHang> list = new List<DTO_NDHang>();

            string query = string.Format("select * from NgDatHang where dbo.fuConvertToUnsign1(TenNDH) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + N'%'", tenNDH);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_NDHang ngDH = new DTO_NDHang(item);
                list.Add(ngDH);
            }

            return list;
        }
    }
}
