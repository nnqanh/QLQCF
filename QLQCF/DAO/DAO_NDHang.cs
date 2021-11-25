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
        public List<DTO_NDHang> SearchNDH(string str)
        {
            List<DTO_NDHang> list = new List<DTO_NDHang>();

            string query = string.Format("exec spTimKiemNDH N'{0}'", str);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_NDHang ngDH = new DTO_NDHang(item);
                list.Add(ngDH);
            }

            return list;
        }
        public bool CheckDatByMaNDH(int maNDH)
        {
            int dem = (int)DataProvider.Instance.ExecuteScalar("select COUNT(*) from DAT where MaNDH = " + maNDH);
            return dem <= 0;
        }
        public bool CheckTenNDH(string tenNDH)
        {
            string query = string.Format("select COUNT(*) from NgDatHang where TenNDH = N'{0}'", tenNDH);
            int dem = (int)DataProvider.Instance.ExecuteScalar(query);
            return dem <= 0;
        }
    }
}
