using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_Mon
    {
        private static DAO_Mon instance;

        public static DAO_Mon Instance 
        {
            get { if (instance == null) instance = new DAO_Mon(); return DAO_Mon.instance; }
            private set { DAO_Mon.instance = value; }
        }

        private DAO_Mon() { }

        public List<DTO_Mon> GetListMonBan()
        {
            List<DTO_Mon> list = new List<DTO_Mon> ();

            string query = "select * from Mon where TinhTrang = N'Đang bán'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            
            foreach (DataRow item in data.Rows)
            {
                DTO_Mon mon = new DTO_Mon(item);
                list.Add(mon);
            }

            return list;
        }
        public List<DTO_Mon> GetListMonQuanLy()
        {
            List<DTO_Mon> list = new List<DTO_Mon>();

            string query = "select * from Mon";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Mon mon = new DTO_Mon(item);
                list.Add(mon);
            }

            return list;
        }
        public bool InsertMon(string tenMon, float donGia, string tinhTrang)
        {   
            string query = string.Format("exec spInsertMon N'{0}', {1}, N'{2}'", tenMon, donGia, tinhTrang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateMon( string tenMon, float donGia, int maMon, string tinhTrang)
        {
            string query = string.Format("update Mon set TenMon = N'{0}', DonGia = {1}, TinhTrang = N'{2}' where MaMon = {3}", tenMon, donGia, tinhTrang, maMon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteMon(int maMon)
        {
            DAO_BillInfo.Instance.DeleteBillInfoByMaMon(maMon);

            string query = string.Format("delete Mon where MaMon = {0}", maMon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<DTO_Mon> SearchMon(string str)
        {
            List<DTO_Mon> list = new List<DTO_Mon>();

            string query = string.Format("exec spTimKiemMon N'{0}'", str);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Mon mon = new DTO_Mon(item);
                list.Add(mon);
            }

            return list;
        }
        public bool CheckHDByMaMon(int maMon)
        {
            int dem = (int)DataProvider.Instance.ExecuteScalar("select COUNT(*) from XuatHDChiTiet where MaMon = " + maMon);
            return dem <= 0;

        }
    }
}
