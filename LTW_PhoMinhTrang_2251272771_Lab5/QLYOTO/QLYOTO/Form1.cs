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

namespace QLYOTO
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adap;
        DataTable dtDl;
        int dongHt = -1;
    
        public Form1()
        {
            InitializeComponent();
        }

        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLYOTO;Integrated Security=True";
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvHangXe.DataSource = GetAllHangXe().Tables[0];
            dgvOto.DataSource = GetAllOto().Tables[0];
            dgvKhachHang.DataSource = GetAllKhach().Tables[0];
            dgvKhachHangXe.DataSource = GetAllKhachHangXe().Tables[0];
            //load combo box
            loadCombobox();
            loadMaKhach();
            loadMaXe();
        }
        private void loadCombobox()
        {
            //load combo box
            con = new SqlConnection(sqlCon);
            con.Open();
            SqlDataAdapter daHangXe = new SqlDataAdapter("select distinct TenHang from HangXe", con);
                DataTable dtHangXe = new DataTable();
                daHangXe.Fill(dtHangXe);
                cbHang.DataSource = dtHangXe;
                cbHang.ValueMember = "TenHang";
        }
        private void loadMaKhach()
        {
            con = new SqlConnection(sqlCon);
            con.Open();
            SqlDataAdapter daKhach = new SqlDataAdapter("select distinct Id from KhachHang", con);
            DataTable dtKhach = new DataTable();
            daKhach.Fill(dtKhach);
            cbMaK.DataSource = dtKhach;
            cbMaK.ValueMember = "Id";
        }
        private void loadMaXe()
        {
            con = new SqlConnection(sqlCon);
            con.Open();
            SqlDataAdapter daXe = new SqlDataAdapter("select distinct MaXe from OTO", con);
            DataTable dtXe = new DataTable();
            daXe.Fill(dtXe);
            cbMaX.DataSource = dtXe;
            cbMaX.ValueMember = "MaXe";
        }
        DataSet GetAllKhachHangXe()
        {
            con = new SqlConnection(sqlCon);
            con.Open();
            DataSet data = new DataSet();
            adap = new SqlDataAdapter("select * from KhachHangXe ", con);
            adap.Fill(data);
            return data;
        }
        DataSet GetAllHangXe()
        {
            con = new SqlConnection(sqlCon);
                con.Open();
                DataSet data = new DataSet();
                adap = new SqlDataAdapter("select * from HangXe ", con);
                adap.Fill(data);
                return data;
        }
        DataSet GetAllOto()
        {
            con = new SqlConnection(sqlCon);
                con.Open();
                DataSet data = new DataSet();
                adap = new SqlDataAdapter("select * from OTO", con);
                adap.Fill(data);
               return data;
            
        }
        DataSet GetAllKhach()
        {
            con = new SqlConnection(sqlCon);
                con.Open();
                DataSet data = new DataSet();
                adap = new SqlDataAdapter("select * from KhachHang", con);
                adap.Fill(data);
                return data;
        }
        private void btnThemHang_Click(object sender, EventArgs e)
        {
            try { 
            cmd = new SqlCommand("insert into HangXe values (N'" + txtMaHang.Text + "',N'" + txtTenHangXe.Text + "',N'" + txtDatNuoc.Text + "') " , con);
            cmd.ExecuteNonQuery();
            dgvHangXe.DataSource = GetAllHangXe().Tables[0];
            loadCombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            try { 
            cmd = new SqlCommand("delete from HangXe where Id = '"+txtMaHang.Text+"'", con);
            cmd.ExecuteNonQuery();
            dgvHangXe.DataSource = GetAllHangXe().Tables[0];
            loadCombobox();
            }
             catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void btnSuaHang_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update HangXe set TenHang=N'"+txtTenHangXe.Text+ "',DatNuoc=N'" + txtDatNuoc.Text + "' where Id = '" + txtMaHang.Text + "'", con);
                cmd.ExecuteNonQuery();
                dgvHangXe.DataSource = GetAllHangXe().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void dgvHangXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHangXe.Rows[e.RowIndex];
                txtMaHang.Text = row.Cells["Id"].Value.ToString();
                txtTenHangXe.Text = row.Cells["TenHang"].Value.ToString();
                txtDatNuoc.Text = row.Cells["DatNuoc"].Value.ToString();
            }
        }

        private void btnThemOto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text == "" || txtTen.Text == "" || txtGia.Text == "")
                {
                    MessageBox.Show("Các trường không được để trống");
                }
                else
                {
                    string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    cmd = new SqlCommand("insert into OTO values (N'" + txtMa.Text + "',N'" + txtTen.Text + "',N'" + cbHang.Text + "','" + txtGia.Text + "','" + date + "')", con);
                    cmd.ExecuteNonQuery();
                    dgvOto.DataSource = GetAllOto().Tables[0];
                    loadCombobox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void btnSuaOto_Click(object sender, EventArgs e)
        {
            try
            {
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd = new SqlCommand("update OTO set TenXe = N'" + txtTen.Text + "',HangXe = N'" + cbHang.Text + "',GiaXe = '" + txtGia.Text + "',NamSX = N'" + date + "' where MaXe ='" + txtMa.Text + "'", con);
                cmd.ExecuteNonQuery();
                dgvOto.DataSource = GetAllOto().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void btnXoaOto_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("delete from OTO where MaXe = '" + txtMa.Text + "'", con);
                cmd.ExecuteNonQuery();
                dgvOto.DataSource = GetAllOto().Tables[0];
                loadCombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void dgvOto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOto.Rows[e.RowIndex];
                txtMa.Text = row.Cells[0].Value.ToString();
                txtTen.Text = row.Cells[1].Value.ToString();
                cbHang.Text = row.Cells[2].Value.ToString();
                txtGia.Text = row.Cells[3].Value.ToString();
                dateTimePicker1.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKhach.Text == "" || txtTenKhach.Text == "" || txtCMT.Text == "")
                {
                    MessageBox.Show("Các trường không được để trống");
                }
                else
                {
                    cmd = new SqlCommand("insert into KhachHang values (N'" + txtMaKhach.Text + "',N'" + txtTenKhach.Text + "','" + txtCMT.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    dgvKhachHang.DataSource = GetAllKhach().Tables[0];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSuaKhach_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update KhachHang set TenKhach =N'"+txtTenKhach.Text+ "',CMT ='" + txtCMT.Text + "' ", con);
                cmd.ExecuteNonQuery();
                dgvKhachHang.DataSource = GetAllKhach().Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaKhach_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("delete from KhachHang where Id=N'"+txtMaKhach.Text+"' ", con);
                cmd.ExecuteNonQuery();
                dgvKhachHang.DataSource = GetAllKhach().Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKhach.Text = row.Cells[0].Value.ToString();
                txtTenKhach.Text = row.Cells[1].Value.ToString();
                txtCMT.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnThemMaKHX_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("insert into KhachHangXe values (N'" + txtMaKHX.Text + "','" + cbMaK.Text + "','" + cbMaX.Text + "') ", con);
                cmd.ExecuteNonQuery();
                dgvKhachHangXe.DataSource = GetAllKhachHangXe().Tables[0];
                loadMaKhach();
                loadMaXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }
    }
}
