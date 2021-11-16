using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_Bill
    {
        private static DAO_Bill instance;

        public static DAO_Bill Instance 
        {
            get { if (instance == null) instance = new DAO_Bill(); return DAO_Bill.instance; }
            private set { DAO_Bill.instance = value; }
        }

        private DAO_Bill() { }

        /// <summary>
        /// Thành công thì trả về soHDX
        /// Thất bại: -1
        /// </summary>
        /// <param name="soBan"></param>
        /// <returns></returns>
        public int GetUncheckBillIDByTableID(int soBan)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from XuatHD where SoBan = " + soBan + " and TinhTrang = 0");
            
            if (data.Rows.Count > 0)
            {
                DTO_Bill bill = new DTO_Bill(data.Rows[0]);
                return bill.SoHDX;
            }

            return -1;
        }
        public void InsertXuatHD(int soBan)
        {
            DataProvider.Instance.ExecuteNonQuery("exec spInsertXuatHD @soBan", new object[] { soBan });
        }

        public int GetMaxSoHDX()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select MAX(SoHDX) from XuatHD");
            }
            catch
            {
                return 1;
            }
        }

        public void CheckOut(int soHDX)
        {
            string query = "exec spThanhToan " + soHDX;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
 