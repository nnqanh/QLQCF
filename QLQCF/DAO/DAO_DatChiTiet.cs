using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
        public List<DTO_DatChiTiet> LayThongTinDat(int maDDH)
        {
            List<DTO_DatChiTiet> list = new List<DTO_DatChiTiet>();

            string query = "Select MaDDH, TenHang, SoLuong, ThanhTien from DatChiTiet join Hang on DatChiTiet.MaHang = Hang.MaHang where MaDDH = " + maDDH;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_DatChiTiet menu = new DTO_DatChiTiet(item);
                list.Add(menu);
            }
            return list;
        }
        public void DeleteDatCTByMaHang(int maHang)
        {
            DataProvider.Instance.ExecuteQuery("delete DatChiTiet where MaHang = " + maHang);
        }
        public void DeleteDatCTByMaDDH(int maDDH)
        {
            DataProvider.Instance.ExecuteQuery("delete DatChiTiet where MaDDH = " + maDDH);
        }
        public void InsertDatChiTiet(int maDDH, int maHang, int soLuong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec spInsertDatChiTiet @maDDH , @maHang , @soLuong", new object[] { maDDH, maHang, soLuong });
        }
    }
}
