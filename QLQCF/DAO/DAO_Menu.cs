using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_Menu
    {
        private static DAO_Menu instance;
        public static DAO_Menu Instance
        {
            get { if (instance == null) instance = new DAO_Menu(); return DAO_Menu.instance; }
            private set { DAO_Menu.instance = value; }
        }
        private DAO_Menu() { }

        public List<DTO_Menu> GetListMenuByTable(int id)
        {
            List<DTO_Menu> listMenu = new List<DTO_Menu>();

            string query = "Select TenMon, SoLuong, DonGia, ThanhTien from XuatHDChiTiet join XuatHD on XuatHDChiTiet.SoHDX = XuatHD.SoHDX join Mon on XuatHDChiTiet.MaMon = Mon.MaMon where Mon.TinhTrang = 0 and XuatHD.SoHDX = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Menu menu = new DTO_Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
        public List<DTO_Menu> LayThongTinHDXtuSoHDX(int soHDX)
        {
            List<DTO_Menu> list = new List<DTO_Menu>();

            string query = "Select TenMon, SoLuong, DonGia, ThanhTien from XuatHDChiTiet join XuatHD on XuatHDChiTiet.SoHDX = XuatHD.SoHDX join Mon on XuatHDChiTiet.MaMon = Mon.MaMon where XuatHD.SoHDX = " + soHDX;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Menu menu = new DTO_Menu(item);
                list.Add(menu);
            }
            return list;
        }
        
    }
}
