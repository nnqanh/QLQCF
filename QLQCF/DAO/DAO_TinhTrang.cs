using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_TinhTrang
    {
        private static DAO_TinhTrang instance;

        public static DAO_TinhTrang Instance
        {
            get { if (instance == null) instance = new DAO_TinhTrang(); return DAO_TinhTrang.instance; }
            private set { DAO_TinhTrang.instance = value; }
        }
        public List<DTO_TinhTrang> LoadTinhTrangBan()
        {
            List<DTO_TinhTrang> tableList = new List<DTO_TinhTrang>();

            string query = "select DISTINCT TinhTrang from Ban";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_TinhTrang table = new DTO_TinhTrang(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public List<DTO_TinhTrang> LoadTinhTrangMon()
        {
            List<DTO_TinhTrang> tableList = new List<DTO_TinhTrang>();

            string query = "select DISTINCT TinhTrang from Mon";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_TinhTrang table = new DTO_TinhTrang(item);
                tableList.Add(table);
            }
            return tableList;
        }
    }
}
