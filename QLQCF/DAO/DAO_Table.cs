using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_Table
    {
        private static DAO_Table instance;

        public static DAO_Table Instance 
        {
            get { if (instance == null) instance = new DAO_Table(); return DAO_Table.instance; }
            private set { DAO_Table.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private DAO_Table() { }

        public List<DTO_Table> LoadTableList()
        {
            List<DTO_Table> tableList = new List<DTO_Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("exec spGetTableList");

            foreach (DataRow item in data.Rows)
            {
                DTO_Table table = new DTO_Table(item);
                tableList.Add(table);

            }

            return tableList;
        }
    }
}
