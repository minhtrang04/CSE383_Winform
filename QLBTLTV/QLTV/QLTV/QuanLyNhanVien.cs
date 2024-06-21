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
using System.IO;
namespace QLTV
{
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        DataTable dtDl;
        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=SQL_LibraryManagement;Integrated Security=True";
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();
            dtDl = new DataTable();
            adapter = new SqlDataAdapter("select MaNV as 'Mã NV', TenNV as 'Tên NV',GioiTinh as 'Giới tính', NgaySinh as 'Ngày sinh', DiaChi as 'Địa chỉ'," +
                "SDT as 'SĐT', CCCD as 'CCCD', ChucVu as 'Chức Vụ',userNV as 'Username', passNV as 'Password' from NhanVien", con);
            adapter.Fill(dtDl);
            dataGridView1.DataSource = dtDl;
            //
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        private void btnThemNv_Click_1(object sender, EventArgs e)
        {
            try
            {//
                string gt = "Nam";
                if (rbNu.Checked) { gt = "Nữ"; }
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd = new SqlCommand("INSERT INTO NhanVien(MaNV,TenNV, GioiTinh, NgaySinh, DiaChi, SDT, CCCD, ChucVu, userNV, passNV) " +
                     "VALUES (N'" + txtMaNV.Text + "',N'" + txtTenNv.Text + "', N'" + gt + "', '" + date + "', N'" + cbDiaChi.Text + "', '" + txtSDT.Text + "', '" + txtCCCD.Text + "', N'" + cbChucVu.Text + "', N'" + txtUsername.Text + "', N'" + txtPass.Text + "') ", con);
                cmd.ExecuteNonQuery();
                dtDl.Rows.Clear();
                adapter.Fill(dtDl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }
    }
}
