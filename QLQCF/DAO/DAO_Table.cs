using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void SwitchTable(int soBan1, int soBan2)
        {
            if (soBan1 == soBan2)
            {
                MessageBox.Show("Không thể chuyển bàn trùng nhau");
                return;
            }
            if (soBan2 == 0)
            {
                MessageBox.Show("Không thể chuyển sang bàn Bán mang về");
                return;
            }
            DataProvider.Instance.ExecuteQuery("spSwitchTable @soBan1 , @soBan2", new object[] {soBan1, soBan2});
        }
        public void GopBan(int soBan1, int soBan2)
        {
            if (soBan1 == soBan2)
            {
                MessageBox.Show("Không thể gộp bàn trùng nhau");
                return;
            }
            if (soBan2 == 0)
            {
                MessageBox.Show("Không thể gộp sang bàn Bán mang về");
                return;
            }
            DataProvider.Instance.ExecuteQuery("spGopBan @soBan1 , @soBan2", new object[] { soBan1, soBan2 });
        }

        public List<DTO_Table> LoadTableList()
        {
            List<DTO_Table> tableList = new List<DTO_Table>();

            string query = "select * from Ban";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Table table = new DTO_Table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public DTO_Table LayTinhTrangBySoBan(int soBan)
        {
            DTO_Table tt = null;
            string query = "select TinhTrang from Ban where SoBan = " + soBan;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                tt = new DTO_Table(item);
                return tt;
            }
            return tt;
        }

        public bool InsertBan(int soBan, string tinhTrang)
        {
            string query = string.Format("exec spInsertBan {0}, N'{1}'", soBan, tinhTrang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateBan(int soBan, string tinhTrang)
        {
            string query = string.Format("update Ban set TinhTrang = N'{0}' where SoBan = {1}", tinhTrang, soBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteBan(int soBan)
        {
            string query = string.Format("delete Ban where SoBan = {0}", soBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool CheckHDXbySoBan(int soBan)
        {
            int dem = (int)DataProvider.Instance.ExecuteScalar("select COUNT(*) from XuatHD where SoBan = " + soBan);
            return dem <= 0;

        }
        public bool CheckSoBan(int soBan)
        {
            int dem = (int)DataProvider.Instance.ExecuteScalar("select COUNT(*) from Ban where SoBan = " + soBan);
            return dem <= 0;

        }
    }
}
