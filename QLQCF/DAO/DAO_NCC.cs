using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_NCC
    {
        private static DAO_NCC instance;

        public static DAO_NCC Instance
        {
            get { if (instance == null) instance = new DAO_NCC(); return instance; }
            private set { instance = value; }
        }

        private DAO_NCC() { }
        public List<DTO_NCC> GetNCCList()
        {
            List<DTO_NCC> list = new List<DTO_NCC>();

            string query = "select * from NhaCC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_NCC nhaCC = new DTO_NCC(item);
                list.Add(nhaCC);
            }
            return list;
        }
        public bool InsertNCC(string tenNCC, string diaChi, string soDT)
        {
            string query = string.Format("exec spInsertNCC N'{0}', N'{1}', '{2}'", tenNCC, diaChi, soDT);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateNCC(string tenNCC, string diaChi, string soDT, int maNCC)
        {
            string query = string.Format("update NhaCC set TenNCC = N'{0}', DiaChi = N'{1}', SDT = '{2}' where MaNCC = {3}", tenNCC, diaChi, soDT, maNCC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteNCC(int maNCC)
        {
            string query = string.Format("delete NhaCC where MaNCC = {0}", maNCC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool CheckSDT(string soDT)
        {
            string query = string.Format("select dbo.fCheckSDT('{0}')", soDT);
            int result = (int)DataProvider.Instance.ExecuteScalar(query);

            return result > 0;
        }

        public List<DTO_NCC> SearchNCCByTenNCC(string tenNCC)
        {
            List<DTO_NCC> list = new List<DTO_NCC>();

            string query = string.Format("select * from NhaCC where dbo.fuConvertToUnsign1(TenNCC) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + N'%'", tenNCC);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_NCC nhaCC = new DTO_NCC(item);
                list.Add(nhaCC);
            }

            return list;
        }
    }
}
