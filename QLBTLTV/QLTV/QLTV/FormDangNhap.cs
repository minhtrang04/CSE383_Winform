using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class FormDangNhap : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=SQL_LibraryManagement;Integrated Security=True";

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();
            if (!string.IsNullOrWhiteSpace(tb_Username.Text) && !string.IsNullOrWhiteSpace(tb_Password.Text))
            {
                if (!TkQuanLy())
                {
                    if (!TkNhanVienSach())
                    {
                        TkSinhVien();
                    }
                }
            }
            else
            {
                MessageBox.Show("Trường thông tin không được để trống !");
            }
            con.Close();
        }

        private bool TkQuanLy()
        {
            string sql = "SELECT * FROM TKQuanLy WHERE TkQL = '" + tb_Username.Text + "' and MkQL = '" + tb_Password.Text + "'";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    this.Hide();
                    FormQuanLy main = new FormQuanLy();
                    main.Show();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                reader.Close();
            }
        }

        private bool TkNhanVienSach()
        {
            string sqlNV = "SELECT * FROM NhanVien WHERE userNV = '" + tb_Username.Text + "' and passNV = '" + tb_Password.Text + "'";
            SqlCommand cmdNV = new SqlCommand(sqlNV, con);
            SqlDataReader readerNV = cmdNV.ExecuteReader();

            try
            {
                if (readerNV.Read())
                {
                    this.Hide();
                    FormNhanVienSach main = new FormNhanVienSach();
                    main.Show();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                readerNV.Close();
            }
        }

        private void TkSinhVien()
        {
            string sqlSV = "SELECT * FROM SinhVien WHERE TenSV = '" + tb_Username.Text + "' and MaSV = '" + tb_Password.Text + "'";
            SqlCommand cmdSV = new SqlCommand(sqlSV, con);
            SqlDataReader readerSV = cmdSV.ExecuteReader();

            try
            {
                if (readerSV.Read())
                {
                    this.Hide();
                    FormSinhVien main = new FormSinhVien();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công !", "Lỗi !");
                    tb_Username.Text = "";
                    tb_Password.Text = "";
                    tb_Username.Focus();
                }
            }
            finally
            {
                readerSV.Close();
            }
        }
    }
}
