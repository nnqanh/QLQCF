﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQCF.DTO
{
    public class DTO_Account
    {
        public DTO_Account(string tenDN, string tenHienThi, int Loai, string matKhau = null)
        {
            this.TenDN = tenDN;
            this.TenHienThi = tenHienThi;
            this.Loai = Loai;
            this.MatKhau = matKhau;
        }

        public DTO_Account(DataRow row)
        {
            this.TenDN = row["tenDN"].ToString();
            this.TenHienThi = row["tenHienThi"].ToString();
            this.Loai = (int)row["loai"];
            this.MatKhau = row["matKhau"].ToString();
        }

        private int loai;
        public int Loai
        {
            get { return loai; }
            set { loai = value; }
        }

        private string matKhau;
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        private string tenHienThi;
        public string TenHienThi
        {
            get { return tenHienThi; }
            set { tenHienThi = value; }
        }

        private string tenDN;
        public string TenDN
        {
            get { return tenDN; }
            set { tenDN = value; }
        }
    }
}
