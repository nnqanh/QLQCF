using System;
using QLQCF.DAO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLQCF
{
    public partial class FQuanlyBan : Form
    {
        public FQuanlyBan()
        {
            InitializeComponent();

            //LoadAccountList();

            //LoadMonList();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            FChinh f = new FChinh();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        /*void LoadMonList()
        {
            string query = "select * from Mon";

            dtgvMon.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadAccountList()
        {
            string query = "Exec dbo.spGetAccountByUserName @userName";

            dtgvTK.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[]{"PTTHa2201"});
        }*/
    }
}
