using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_Dat
    {
        private static DAO_Dat instance;
        public static DAO_Dat Instance
        {
            get { if (instance == null) instance = new DAO_Dat(); return DAO_Dat.instance; }
            private set { DAO_Dat.instance = value; }
        }
        private DAO_Dat() { }
        public List<DTO_Dat> LayDATtuThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            List<DTO_Dat> list = new List<DTO_Dat>();

            string query = String.Format("exec spLayDATtuThoiGian '{0}' , '{1}'", tuNgay, denNgay);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Dat dat = new DTO_Dat(item);
                list.Add(dat);
            }

            return list;
        }
        public bool InsertDAT(string tenNDH, string tenNCC, DateTime thoiGian)
        {
            string query = string.Format(" exec spInsertDat N'{0}', N'{1}', '{2}'", tenNDH, tenNCC, thoiGian);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateDAT(int maDDH, string tenNDH, string tenNCC, DateTime thoiGian)
        {
            string query = string.Format("exec spUpdateDat {0}, N'{1}', N'{2}', '{3}'", maDDH, tenNDH, tenNCC, thoiGian);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteDAT(int maDDH)
        {
            DAO_DatChiTiet.Instance.DeleteDatCTByMaDDH(maDDH);

            string query = string.Format("delete DAT where MaDDH = {0}", maDDH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool ThanhToanDAT(int maDDH)
        {
            string query = string.Format("Update DAT set TinhTrang = N'Đã thanh toán' where MaDDH = {0}", maDDH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool CheckDatByMaNCC(int maNCC)
        {
            int dem = (int)DataProvider.Instance.ExecuteScalar("select COUNT(*) from DAT where MaNCC = " + maNCC);
            return dem <= 0;
        }
        public bool CheckDat(int maDDH)
        {
            string query = string.Format("Select COUNT(*) from DAT where MaDDH = {0} and TinhTrang = N'Đã thanh toán'", maDDH);
            int dem = (int)DataProvider.Instance.ExecuteScalar(query);
            return dem <= 0;
        }
    }
}
