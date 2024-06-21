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

namespace QlyThueTruyen
{
    public partial class Form1 : Form
    {
        int dongHt = -1;
        Control controlHt = null;
        DataGridView dgvMau = null;
        // sql
        SqlConnection con;
        SqlDataAdapter adapDL;
        DataTable dtDl;
        SqlCommand cmd;
        SqlDataReader dr;

        string khachHt = "";
        int stt = 1;
        public Form1()
        {
            InitializeComponent();
            dtDl = new DataTable();
            LuuTru();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            
        }
     
        private void loadData()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dtDl.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(stt, dtDl.Rows[i][1].ToString(),
                    dtDl.Rows[i][2].ToString(),
                     dtDl.Rows[i][3].ToString(),
                      dtDl.Rows[i][4].ToString(),
                       dtDl.Rows[i][5].ToString(),
                        dtDl.Rows[i][6].ToString(),
                         dtDl.Rows[i][7].ToString());
            stt++;
            }
        }  /**/

        private void cbTentruyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTentruyen.SelectedIndex)
            {
                case 0:
                    {
                        txtDG.Text = "12000";
                        break;
                    }
                case 1:
                    {
                        txtDG.Text = "16000";
                        break;
                    }
                case 2:
                    {
                        txtDG.Text = "12000";
                        break;
                    }
                case 3:
                    {
                        txtDG.Text = "12000";
                        break;
                    }
                case 4:
                    {
                        txtDG.Text = "15000";
                        break;
                    }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt = e.RowIndex;//lấy vị trí dòng đang chọn gán cho biến vitrichon
            if (dongHt >= 0)
            {
                string khach = dataGridView1.Rows[dongHt].Cells[1].Value.ToString();
                string sdt = dataGridView1.Rows[dongHt].Cells[2].Value.ToString();
                string truyen = dataGridView1.Rows[dongHt].Cells[3].Value.ToString();
                string muon = dataGridView1.Rows[dongHt].Cells[4].Value.ToString();
                //string tra = dataGridView1.Rows[dongHt].Cells[5].Value.ToString();
                // lay m
                txtKhach.Text = khach;
                txtSdt.Text = sdt;
                cbTentruyen.Text = truyen;
                dtMuon.Text = muon;
                //dtTra.Text = tra;

            }
        }
        private void btnMuon_Click(object sender, EventArgs e)
        {
            string ten = txtKhach.Text;
            string sdt = txtSdt.Text;
            string truyen = cbTentruyen.Text;
            string muon = dtMuon.Value.ToString("yyyy-MM-dd");
            string tra = " ";
            string tt = " ";
            string note = "Chưa trả";
            
           // txtTra.Text = tt.ToString();
            // Cập nhật DataGridView
            dataGridView1.Rows.Add(stt, ten, sdt, truyen, muon, tra, tt, note);
            stt++;
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (dongHt >= 0 && dongHt < dataGridView1.Rows.Count)
            {
                DateTime ngayMuon = DateTime.Parse(dataGridView1.Rows[dongHt].Cells[4].Value.ToString());
                DateTime ngayTra = dtTra.Value;
                double donGia = Convert.ToDouble(txtDG.Text);

                int soNgayMuon = (ngayTra - ngayMuon).Days;
                double thanhTien = soNgayMuon * donGia;

                dataGridView1.Rows[dongHt].Cells[5].Value = ngayTra.ToString("yyyy-MM-dd");
                dataGridView1.Rows[dongHt].Cells[6].Value = thanhTien.ToString();
                dataGridView1.Rows[dongHt].Cells[7].Value = "Đã trả";
                
            }
                

        }

        private void LuuTru()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("Tên Khách");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Tên Truyện");
            dt.Columns.Add("Ngày Mượn");
            dt.Columns.Add("Ngày Trả");
            dt.Columns.Add("Thành Tiền");
            dt.Columns.Add("Ghi chú");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dt.Rows.Add(dataGridView1.Rows[i].Cells[0].Value,
                                dataGridView1.Rows[i].Cells[1].Value,
                                dataGridView1.Rows[i].Cells[2].Value,
                                dataGridView1.Rows[i].Cells[3].Value,
                                dataGridView1.Rows[i].Cells[4].Value,
                                dataGridView1.Rows[i].Cells[5].Value,
                                dataGridView1.Rows[i].Cells[6].Value,
                                dataGridView1.Rows[i].Cells[7].Value);
            }
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            if (!txtSdt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ bao gồm chữ số!");
            }
        }
    }
}
