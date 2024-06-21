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

        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLOTO;Integrated Security=True";
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();

            dtDl = new DataTable();
            adap = new SqlDataAdapter("select MaXe as 'Mã Xe',TenXe as 'Tên Xe',HangXe as'Hãng Xe',GiaXe as'Giá Xe',NamSX as'Năm Sản Xuất' from OTO", con);
            adap.Fill(dtDl);
            dataGridView1.DataSource = dtDl;

            //load combobox
            SqlDataAdapter adapXe = new SqlDataAdapter("select distinct HangXe from OTO", con);
            DataTable dtXe = new DataTable();
            adapXe.Fill(dtXe);
            cbHang.DataSource = dtXe;
            cbHang.ValueMember = "HangXe";
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try { 
                if(txtMaXe.Text=="" || txtTen.Text=="" || txtGia.Text == "")
                {
                    MessageBox.Show("Các trường không được để trống");
                }
                else { 
            string date = dtpNam.Value.ToString("yyyy-MM-dd");
            cmd = new SqlCommand("insert into OTO values (N'"+txtMaXe.Text+ "',N'" + txtTen.Text + "',N'" + cbHang.Text + "','" + txtGia.Text + "','" + date + "') ", con);
            cmd.ExecuteNonQuery();//thực hiện câu lệnh Insert
             //lấy lại dữ liệu vừa thêm vào lên datagridview nhà xuất bản
            dtDl.Rows.Clear();
            adap.Fill(dtDl);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi : "+ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dongHt>=0 && dongHt < dataGridView1.Rows.Count)
            {
                string mxe = dtDl.Rows[dongHt][0].ToString();
                string date = dtpNam.Value.ToString("yyyy-MM-dd");
            cmd = new SqlCommand("update OTO set MaXe = N'" + txtMaXe.Text + "',TenXe = N'" + txtTen.Text + "',HangXe = N'" + cbHang.Text + "',GiaXe = '" + txtGia.Text + "',NamSX = N'" + date + "' where MaXe ='" + mxe + "'", con);
            cmd.ExecuteNonQuery();
           // dtDl.Rows.Clear();
            adap.Fill(dtDl);}

        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt = e.RowIndex;
            if(dongHt >=0 && dongHt < dataGridView1.Rows.Count)
            {
                //lấy dữ liệu từ dòng đang chọn chuyển lên khung nhập liệu
                txtMaXe.Text = dtDl.Rows[dongHt][0].ToString();
                txtTen.Text = dtDl.Rows[dongHt][1].ToString();
                cbHang.Text = dtDl.Rows[dongHt][2].ToString();
                txtGia.Text = dtDl.Rows[dongHt][3].ToString();
                dtpNam.Text = dtDl.Rows[dongHt][4].ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dongHt>=0 && dataGridView1.Rows.Count > dongHt)
            {
                string mxe = dtDl.Rows[dongHt][0].ToString();
                cmd = new SqlCommand("delete OTO where MaXe=N'" + mxe + "' ", con);
                cmd.ExecuteNonQuery();
                dtDl.Rows.Clear();
                adap.Fill(dtDl);
                txtMaXe.ResetText();
                txtTen.ResetText();
                cbHang.ResetText();
                txtGia.ResetText();
            }
        }
    }
}
