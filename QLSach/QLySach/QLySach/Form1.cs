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

namespace QLySach
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapDl;
        SqlDataReader dr;
        DataTable dtDl;
        //dgv1
        DataTable dtDldgv1;
        SqlDataAdapter adapDldgv1;
        //dgv2
        DataTable dtDldgv2;
        SqlDataAdapter adapDldgv2;
        int dongHt1 = -1;
        int dongHt2 = -1;
        public Form1()
        {
            InitializeComponent();

        }
        string sql = "Data Source=DESKTOP-TJ5SUOH\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True";
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sql);
            //Mở chuỗi
            con.Open();
            //Khai báo lệnh sql cho dtg 1
            dtDldgv1 = new DataTable();
            adapDldgv1 = new SqlDataAdapter("select MASACH AS 'Mã Sách',TENSACH AS 'Tên Sách' from QLS", con);
            adapDldgv1.Fill(dtDldgv1);
            dataGridView1.DataSource = dtDldgv1;

            //khai báo dgv2
            dtDldgv2 = new DataTable();
            adapDldgv2 = new SqlDataAdapter("select row_number() over (order by STT) as N'STT',TENSV as N'Họ Tên Sinh Viên',TENSACH as N'Tên sách',MUON as N'Ngày Mượn',TRA as N'Ngày Trả',THANHTIEN as N'Thành Tiền' from MTS", con);
            adapDldgv2.Fill(dtDldgv2);
            dataGridView2.DataSource = dtDldgv2;

            //load combobox
            SqlDataAdapter daSach = new SqlDataAdapter("select distinct TENSACH from QLS", con);
            DataTable dtSach = new DataTable();
            daSach.Fill(dtSach);
            cbTenSach.DataSource = dtSach;
            cbTenSach.ValueMember = "TENSACH";

            cmd = new SqlCommand();
            cmd.Connection = con;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ms = txtMaSach.Text;
            string ten = txtTenSach.Text;
            string sql = "insert into QLS values(N'" + ms + "',N'" + ten + "')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            dtDldgv1.Rows.Clear();
            adapDldgv1.Fill(dtDldgv1);
        }
        private void btnMuon_Click(object sender, EventArgs e)
        {   
            string tensv = cbTenSV.Text;
            string ts = cbTenSach.Text;
            string muon = dateMuon.Value.ToString("yyyy-MM-dd");
            string tra = dateMuon.Value.AddDays(40).ToString("yyyy-MM-dd");
          
            float tt = 0;

           DateTime ngayMuon = dateMuon.Value;
            DateTime ngayTra =  ngayMuon.AddDays(40);
           double soNgayMuon = (ngayTra - ngayMuon).TotalDays;
            labelSoNgay.Text = soNgayMuon.ToString();

            string sql = "insert into MTS values(N'" + tensv + "',N'" + ts + "',N'" + muon + "',N'" + tra + "',N'" + tt + "')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            dtDldgv2.Rows.Clear();
            adapDldgv2.Fill(dtDldgv2);

        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // this.dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt1 = e.RowIndex;
            if (dongHt1 >= 0 && dongHt1 < dataGridView1.Rows.Count)
            {
                txtMaSach.Text = dataGridView1.Rows[dongHt1].Cells[0].Value.ToString();
                txtTenSach.Text = dataGridView1.Rows[dongHt1].Cells[1].Value.ToString();

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt2 = e.RowIndex;
            if (dongHt2 >= 0 && dongHt2 < dataGridView2.Rows.Count)
            {

                string stt = dataGridView2.Rows[dongHt2].Cells[0].Value.ToString();
                string tenSV = dataGridView2.Rows[dongHt2].Cells[1].Value.ToString();
                string tenSach = dataGridView2.Rows[dongHt2].Cells[2].Value.ToString();
                string ngayMuon = dataGridView2.Rows[dongHt2].Cells[3].Value.ToString();
                string ngayTra = dataGridView2.Rows[dongHt2].Cells[4].Value.ToString();
                string thanhTien = dataGridView2.Rows[dongHt2].Cells[5].Value.ToString();

                cbTenSV.Text =tenSV;
                cbTenSach.Text = tenSach;
                dateMuon.Text = ngayMuon;
                dateTra.Text = ngayTra;
            }
        }
    }
}
