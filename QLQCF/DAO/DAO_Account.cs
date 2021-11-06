using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DAO
{
    public class DAO_Account
    {
        private static DAO_Account instance;

        public static DAO_Account Instance 
        {
            get { if (instance == null) instance = new DAO_Account(); return instance; }
            private set { instance = value; }
        }

        private DAO_Account() { }

        public bool Login(string tenDN, string matKhau)
        {
            string query = "spLogin @tenDN , @matKhau";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {tenDN,matKhau});

            return result.Rows.Count > 0;
        }
    }
}
