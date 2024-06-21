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
    public partial class Form3 : Form
    {
        string name;
        double money;
        public Form3()
        {
            InitializeComponent();
        }

       
        private void txtNhap_TextChanged(object sender, EventArgs e)
        {
           if (!txtNhap.Text.Trim().All(char.IsLetter))
            {
                // Kiểm tra xem tên khách hàng có chứa ký tự khác chữ hay không (trừ khoảng trắng)
                MessageBox.Show("Tên khách hàng chỉ được phép chứa chữ !");
            }

        }
        private void txtNhap_Leave(object sender, EventArgs e)
        {
            if(txtNhap.Text == "")
            {
                MessageBox.Show("Tên khách không được để trống");
                txtNhap.Focus();
            } 

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {

            if (!cboxVoi.Checked && !cboxTay.Checked && !cboxChup.Checked && !cboxLay.Checked && Convert.ToInt32(numSlg.Value) == 0)
            {
                MessageBox.Show("Vui lòng chọn hình thức khám!");
            }
            else
            {
                money = 0;
                if (cboxVoi.Checked)
                {
                    money += 100000;
                }
                if (cboxTay.Checked)
                {
                    money += 1200000;
                }
               if (cboxChup.Checked)
                {
                    money += 150000;
                }
                if (cboxLay.Checked)
                {
                    money += 100000;
                }
                if (Convert.ToInt32(numSlg.Value) > 0)
                {
                    money += Convert.ToInt32(numSlg.Value) * 90000;
                }
                txtTien.Text = Convert.ToString(money) + "VNĐ";
            }
        }


    }
}
