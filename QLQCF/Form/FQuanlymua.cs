﻿using System;
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
    public partial class FQuanly : Form
    {
        public FQuanly()
        {
            InitializeComponent();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            FChinh f = new FChinh();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
