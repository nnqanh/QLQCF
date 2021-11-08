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

        public List<DTO_Mon> GetListMon()
        {
            List<DTO_Mon> list = new List<DTO_Mon> ();

            string query = "select * from Mon";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            
            foreach (DataRow item in data.Rows)
            {
                DTO_Mon mon = new DTO_Mon(item);
                list.Add(mon);
            }

            return list;
        }
    }
}
