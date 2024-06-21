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
    public partial class SearchForm : Form
    {
        DataTable dtDl;
        public SearchForm()
        {
            InitializeComponent();
        }

        string sql = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLSV3;Integrated Security=True";
        private void btnLoc_Click(object sender, EventArgs e)
        {
            //dt.Rows.Clear();
             
            SqlConnection con = new SqlConnection(sql);
            con.Open();
            string msv = txtMaSV.Text;
            dtDl = new DataTable();
            if (dtDl.Rows.Count == 0)
            {
                MessageBox.Show("Không có sinh viên");
            }
           
            SqlDataAdapter adap = new SqlDataAdapter("Select maSv as 'Mã Sinh Viên',tenSv as 'Họ và tên',gioiTinh as 'Giới Tính',ngaySinh as 'Ngày Sinh',diaChi as 'Địa chỉ',nienkhoa as 'Niên khóa',khoa as 'Khoa',lop as 'Lớp',gpa as 'Điểm GPA' from SV where maSv = '" + msv+"' ",con);
            adap.Fill(dtDl);
            dataGridView1.DataSource = dtDl;
            
            
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
