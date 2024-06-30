using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De11_K62
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            SinhVien a = new SinhVien();
            a.MdiParent = this;
            a.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
           NhapDiem a = new NhapDiem();
            a.MdiParent = this;
            a.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            foreach(var item in this.MdiChildren)
            {
                item.Close();
            }
            Khoa a = new Khoa();
            a.MdiParent = this;
            a.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            foreach(var item in this.MdiChildren)
            {
                item.Close();
            }
            XemDiem a = new XemDiem();
            a.MdiParent = this;
            a.Show();
        }
    }
}
