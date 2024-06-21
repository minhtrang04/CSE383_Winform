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

namespace QLSV
{
    public partial class MainForm : Form
    {
        int dongHT = -1;
        Control controlHT = null;
        DataGridView dgvMau = null;

        SqlConnection con;
        SqlDataAdapter adapter;
        DataTable dtDl;
        SqlCommand cmd;
        SqlDataReader dr;

        string msvHt = "";
        public MainForm()
        {
            InitializeComponent();
        }
        string sql = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLSV3;Integrated Security=True";
        private void MainForm_Load(object sender, EventArgs e)
        {
            rbNam.Checked = true;


            con = new SqlConnection(sql);
            con.Open();

            dtDl = new DataTable();
            adapter = new SqlDataAdapter("SELECT maSv AS 'Mã Sinh Viên', tenSv AS 'Họ và tên', gioiTinh AS 'Giới Tính', ngaySinh AS 'Ngày Sinh', diaChi AS 'Địa chỉ',nienkhoa AS 'Niên khoá', khoa AS 'Khoa', lop AS 'Lớp', gpa AS 'Điểm GPA' FROM SV", con);

            adapter.Fill(dtDl);
            dataGridView1.DataSource = dtDl;

            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text == "" || txtTen.Text == "" || txtDiaChi.Text == "" || cbYear.Text == " " || cbKhoa.Text == "" || cbLop.Text == "" || txtGPA.Text == "")
            {
                MessageBox.Show("Các trường thông tin không được để trống !");
            }
            else
            {
                try
                {
                    string msv = txtMaSV.Text;
                    string ten = txtTen.Text;
                    string date = dtpNgay.Value.ToString("yyyy-MM-dd");
                    string gt = "Nam";
                    if (rbNu.Checked) gt = "Nữ";
                    string que = txtDiaChi.Text;
                    string nienkhoa = cbYear.Text;
                    string khoa = cbKhoa.Text;
                    string lop = cbLop.Text;
                    string GPA = txtGPA.Text;

                    string sql_Insert = "Insert into SV values(N'" + msv + "',N'" + ten + "',N'" + gt + "','" + date + "',N'" + que + "',N'" + nienkhoa + "',N'" + khoa + "',N'" + lop + "','" + GPA + "')";
                    cmd = new SqlCommand(sql_Insert, con);
                    cmd.ExecuteNonQuery();
                    dtDl.Clear();
                    adapter.Fill(dtDl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: "+ex.Message);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHT = e.RowIndex;
            if (dongHT >= 0 && dongHT < dataGridView1.RowCount)
            {
                txtMaSV.Text = dataGridView1.Rows[dongHT].Cells[0].Value.ToString();
                txtTen.Text = dataGridView1.Rows[dongHT].Cells[1].Value.ToString();
                string gt = dataGridView1.Rows[dongHT].Cells[2].Value.ToString();
                if (gt == "Nam") rbNam.Checked = true;
                else rbNu.Checked = true;
                dtpNgay.Text = dataGridView1.Rows[dongHT].Cells[3].Value.ToString();

                txtDiaChi.Text = dataGridView1.Rows[dongHT].Cells[4].Value.ToString();
                cbYear.Text = dataGridView1.Rows[dongHT].Cells[5].Value.ToString();
                cbKhoa.Text = dataGridView1.Rows[dongHT].Cells[6].Value.ToString();
                cbLop.Text = dataGridView1.Rows[dongHT].Cells[7].Value.ToString();
                txtGPA.Text = dataGridView1.Rows[dongHT].Cells[8].Value.ToString();

                // lay msv
                msvHt = dataGridView1.Rows[dongHT].Cells[0].Value.ToString();

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dongHT >= 0 && dongHT < dataGridView1.Rows.Count)
            {
                string msv = dataGridView1.Rows[dongHT].Cells[0].Value.ToString();
                cmd.CommandText = "delete from SV where maSv = N'" + msv + "'";
                cmd.ExecuteNonQuery();
                dtDl.Clear();
                adapter.Fill(dtDl);
                txtMaSV.ResetText();
                txtTen.ResetText();
                txtDiaChi.ResetText();
                txtGPA.ResetText();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dongHT >= 0 && dongHT < dataGridView1.Rows.Count)
            {

                string msv = txtMaSV.Text;
                string ten = txtTen.Text;
                string gt = "Nam";
                if (rbNu.Checked) gt = "Nữ";
                string date = dtpNgay.Value.ToString("yyyy-MM-dd");
                string que = txtDiaChi.Text;
                string nienkhoa = cbYear.Text;
                string khoa = cbKhoa.Text;
                string lop = cbLop.Text;
                string GPA = txtGPA.Text;

                cmd.CommandText = "update SV set maSv = N'" + msv + "',tenSv=N'" + ten + "',gioiTinh=N'" + gt + "',ngaySinh='" + date + "',diaChi=N'" + que + "',khoa=N'" + khoa + "',lop=N'" + lop + "',gpa='" + GPA + "' where maSv='" + msvHt + "' ";
                cmd.ExecuteNonQuery();
                dtDl.Clear();
                adapter.Fill(dtDl);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn đóng chương trình ?", "Hỏi người dùng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                this.Close();
                LoginForm back = new LoginForm();
                back.Show();
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dtDl != null && dtDl.Rows.Count > 0)
            {
                SearchForm f = new SearchForm();
                f.Show();
            }
            else
            {
                MessageBox.Show("Bảng dữ liệu trống!");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cbHocLuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hocluc = cbHocLuc.Text;
            string query = "";

            switch (hocluc)
            {
                case "Xuất sắc":
                    query = "SELECT maSv AS 'Mã Sinh Viên', tenSv AS 'Họ và tên',nienkhoa AS 'Niên khoá', khoa AS 'Khoa', lop AS 'Lớp', gpa AS 'Điểm GPA' FROM SV WHERE gpa >= 3.6";
                    break;
                case "Giỏi":
                    query = "SELECT maSv AS 'Mã Sinh Viên', tenSv AS 'Họ và tên',nienkhoa AS 'Niên khoá', khoa AS 'Khoa', lop AS 'Lớp', gpa AS 'Điểm GPA' FROM SV  WHERE gpa >= 3.2 AND gpa < 3.6";
                    break;
                case "Khá":
                    query = "SELECT maSv AS 'Mã Sinh Viên', tenSv AS 'Họ và tên',nienkhoa AS 'Niên khoá', khoa AS 'Khoa', lop AS 'Lớp', gpa AS 'Điểm GPA' FROM SV  WHERE gpa >= 2.5 AND gpa < 3.2";
                    break;
                case "Trung Bình":
                    query = "SELECT maSv AS 'Mã Sinh Viên', tenSv AS 'Họ và tên',nienkhoa AS 'Niên khoá', khoa AS 'Khoa', lop AS 'Lớp', gpa AS 'Điểm GPA' FROM SV  WHERE gpa >= 2.0 AND gpa < 2.5";
                    break;
                case "Yếu":
                    query = "SELECT maSv AS 'Mã Sinh Viên', tenSv AS 'Họ và tên',nienkhoa AS 'Niên khoá', khoa AS 'Khoa', lop AS 'Lớp', gpa AS 'Điểm GPA' FROM SV  WHERE gpa < 2";
                    break;
            }

            try
            {
                    cmd = new SqlCommand(query, con);
                    dr = cmd.ExecuteReader();

                    dtDl = new DataTable();
                    dtDl.Load(dr);
                    if (dtDl.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có sinh viên");
                    }
                    else
                    {
                        dataGridView2.DataSource = dtDl;
                        MessageBox.Show("Danh sách có "+ dtDl.Rows.Count + " sinh viên " +hocluc);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void dataGridView2_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }
    }
}
    

