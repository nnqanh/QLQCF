using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_TinhTrangBan
    {
        private static DAO_TinhTrangBan instance;

        public static DAO_TinhTrangBan Instance
        {
            get { if (instance == null) instance = new DAO_TinhTrangBan(); return DAO_TinhTrangBan.instance; }
            private set { DAO_TinhTrangBan.instance = value; }
        }
        public List<DTO_TinhTrangBan> LoadTinhTrangBan()
        {
            List<DTO_TinhTrangBan> tableList = new List<DTO_TinhTrangBan>();

            string query = "select DISTINCT TinhTrang from Ban";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_TinhTrangBan table = new DTO_TinhTrangBan(item);
                tableList.Add(table);
            }
            return tableList;
        }
    }
}
