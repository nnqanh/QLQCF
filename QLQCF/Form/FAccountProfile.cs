using QLQCF.DAO;
using QLQCF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQCF
{
    public partial class FAccountProfile : Form
    {
        private DTO_Account loginAccount;
        public DTO_Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public FAccountProfile(DTO_Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;            
        }
        void ChangeAccount(DTO_Account acc)
        {
            txbTDN.Text = LoginAccount.TenDN;
            txbTHT.Text = LoginAccount.TenHienThi;
        }
        void UpdateAccountInfo()
        {
            string tenHT = txbTHT.Text;
            string matKhau = txtMatKhau.Text;
            string matKhauMoi = txtMKmoi.Text;
            string nhapLaiMK = txtNhapLai.Text;
            string tenDN = txbTDN.Text;

            if (!matKhauMoi.Equals(nhapLaiMK))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (DAO_Account.Instance.UpdateAccount(tenDN,tenHT,matKhau,matKhauMoi))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(DAO_Account.Instance.GetAccountByUserName(tenDN)));
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu");
                }
            }    
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class AccountEvent:EventArgs
    {
        private DTO_Account acc;
        public DTO_Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }
        public AccountEvent(DTO_Account acc)
        {
            this.Acc = acc;
        }
    }
}
