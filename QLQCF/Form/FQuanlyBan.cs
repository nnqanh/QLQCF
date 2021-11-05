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

            LoadAccountList();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            FChinh f = new FChinh();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        void LoadAccountList()
        {
            string query = "Select * from Account";

            DataProvider provider = new DataProvider();

            dtgvTK.DataSource = provider.ExecuteQuery(query);
        }
    }
}
