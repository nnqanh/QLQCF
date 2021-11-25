using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
            string matKhauMH = MaHoa(matKhau);

            string query = "spLogin @tenDN , @matKhau";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {tenDN,matKhauMH});

            return result.Rows.Count > 0;
        }
        public string MaHoa(string matKhau)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(matKhau);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            hasPass.Reverse();
            return hasPass;
        }
        public bool UpdateAccount(string userName, string displayName, string pass, string newpass)
        {
            string passMH = MaHoa(pass);
            string newpassMH = MaHoa(newpass);

            int result = DataProvider.Instance.ExecuteNonQuery("exec spUpdateAccount @tenDN , @tenHT , @matKhau , @newPass", new object[] {userName, displayName, passMH, newpassMH});
            return result > 0;
        }
        public List<DTO_Account> GetListAcc()
        {
            List<DTO_Account> list = new List<DTO_Account>();

            string query = "select TenDN, TenHienThi, Loai from Account";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Account tenDN = new DTO_Account(item);
                list.Add(tenDN);
            }

            return list;
        }
        public DTO_Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Account where TenDN = '" + userName + "'");
            foreach(DataRow item in data.Rows)
            {
                return new DTO_Account(item);
            }
            return null;
        }
        public bool InsertAccount(string tenDN, string tenHT, int loai)
        {
            string query = string.Format("insert Account (TenDN, TenHienThi, Loai) values ('{0}', N'{1}',{2})", tenDN, tenHT, loai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateAccount(string tenDN, string tenHT, int loai)
        {
            string query = string.Format("update Account set TenHienThi = N'{0}', Loai = {1} where TenDN = '{2}'", tenHT, loai, tenDN);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string tenDN)
        {
            string query = string.Format("delete Account where TenDN = '{0}'", tenDN);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool ResetAccount(string tenDN)
        {
            string mk = DAO_Account.Instance.MaHoa("12345");

            string query = string.Format("update Account set MatKhau = '{0}' where TenDN = '{1}'", mk, tenDN);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<DTO_Account> SearchAccByTenHT(string tenHT)
        {
            List<DTO_Account> list = new List<DTO_Account>();

            string query = string.Format("select * from Account where dbo.fuConvertToUnsign1(TenHienThi) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + N'%'", tenHT);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO_Account ten = new DTO_Account(item);
                list.Add(ten);
            }

            return list;
        }
    }
}
