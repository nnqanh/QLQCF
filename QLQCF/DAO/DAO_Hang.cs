using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_Hang
    {
        private static DAO_Hang instance;

        public static DAO_Hang Instance
        {
            get { if (instance == null) instance = new DAO_Hang(); return DAO_Hang.instance; }
            private set { DAO_Hang.instance = value; }
        }

        private DAO_Hang() { }

        public List<DTO_Hang> GetListHang()
        {
            List<DTO_Hang> list = new List<DTO_Hang>();

            string query = "select * from Hang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Hang hang = new DTO_Hang(item);
                list.Add(hang);
            }

            return list;
        }

        public bool InsertHang(string tenHang, string donVi, float donGia)
        {
            string query = string.Format("exec spInsertHang N'{0}', '{1}', {2}", tenHang, donVi, donGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateHang(string tenHang, string donVi, float donGia, int maHang)
        {
            string query = string.Format("update Hang set TenHang = N'{0}', DonVi = N'{1}', DonGia = {2} where MaHang = {3}", tenHang, donVi, donGia, maHang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteHang(int maHang)
        {
            DAO_DatChiTiet.Instance.DeleteDatCTByMaHang(maHang);

            string query = string.Format("delete Hang where MaHang = {0}", maHang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<DTO_Hang> SearchNVLByTenHang(string tenHang)
        {
            List<DTO_Hang> list = new List<DTO_Hang>();

            string query = string.Format("select * from Hang where dbo.fuConvertToUnsign1(TenHang) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + N'%'", tenHang);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Hang hang = new DTO_Hang(item);
                list.Add(hang);
            }

            return list;
        }
        public bool CheckDatCTByMaHang(int maHang)
        {
            int dem = (int)DataProvider.Instance.ExecuteScalar("select COUNT(*) from DatChiTiet where MaHang = " + maHang);
            return dem <= 0;

        }
    }
}
