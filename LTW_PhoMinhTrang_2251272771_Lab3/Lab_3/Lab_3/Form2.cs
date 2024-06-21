using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form2 : Form
    {
        int n;
        public Form2()
        {
            InitializeComponent();
        }

        private void txtNhap_TextChanged(object sender, EventArgs e)
        {//
            if (!txtNhap.Text.All(char.IsDigit))
            {
                 // Xử lý trường hợp nhập ký tự khác
                MessageBox.Show("Vui lòng chỉ nhập kí tự chữ số vào TextBox.");
            }
               
        }

        private void txtNhap_Leave(object sender, EventArgs e)
        {
            if(!int.TryParse(txtNhap.Text, out n))
            {
                MessageBox.Show("Dữ liệu nhập vào phải là số nguyên !", "Lỗi !");
                txtNhap.Text = "";
                txtNhap.Focus();
            }
            else if(n<=0 || n >= 1000)
            {
                MessageBox.Show("Dữ liệu n nhập vào phải > 0 và < 1000 !", "Lỗi !");
                txtNhap.Text = "";
                txtNhap.Focus();
            }
        }

        private bool KT_SNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private bool KT_SCP(int n)
        {
            int sqr = Convert.ToInt32(Math.Sqrt(n));
            if (sqr * sqr == n) { return true; }
            return false;
        }

        private bool KT_SHH(int n)
        {
            if (n < 6) { return false; }
            int s = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    s += i;
                }
            }
            if (s == n) {
                return true;
            }
             return false;
        }
        private void btnHien_Click(object sender, EventArgs e)
        {
            labelSNT.Text = "";
            labelSCP.Text = "";
            labelSHH.Text = "";
            for (int i = 0; i < n; i++)
            {
                if (this.KT_SNT(i))
                {
                    labelSNT.Text += i + "  ";
                }

                if (this.KT_SCP(i))
                {
                    labelSCP.Text += i + "  ";
                }

                if (this.KT_SHH(i))
                {
                    labelSHH.Text += i + "  ";
                }
            }
        }
    }
}
