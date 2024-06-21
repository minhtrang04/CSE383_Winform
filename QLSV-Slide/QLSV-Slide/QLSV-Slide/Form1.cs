using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Slide
{
    public partial class Form1 : Form
    {
        int dongHt = -1;
        public Form1()
        {
            InitializeComponent();
        }

        
        private void tbMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string msv = tbMaSV.Text;
            string ten = tbTen.Text;
            string date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string gt = "Nữ";
            if (rbNam.Checked) { gt = "Nam"; }
            string que = cbQue.Text;
            string lop = cbLop.Text;
            string khoa = cbKhoa.Text;
            dataGridView1.Rows.Add(msv, ten, date, gt, que, lop, khoa);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt = e.RowIndex;
            if(dongHt >= 0 && dongHt < dataGridView1.Rows.Count)
            {

             tbMaSV.Text = dataGridView1.Rows[dongHt].Cells[0].Value.ToString();
             tbTen.Text = dataGridView1.Rows[dongHt].Cells[1].Value.ToString();
             dateTimePicker1.Text = dataGridView1.Rows[dongHt].Cells[2].Value.ToString();
             string gt = dataGridView1.Rows[dongHt].Cells[3].Value.ToString();
                if (gt == "Nữ") { rbNu.Checked=true; }
                else { rbNam.Checked = true; }
             cbQue.Text = dataGridView1.Rows[dongHt].Cells[4].Value.ToString();
             cbLop.Text = dataGridView1.Rows[dongHt].Cells[5].Value.ToString();
             cbKhoa.Text = dataGridView1.Rows[dongHt].Cells[6].Value.ToString();
            }
            
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dongHt>= 0 && dongHt <= dataGridView1.Rows.Count)
            {
                dataGridView1.Rows.RemoveAt(dongHt);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dongHt >= 0 && dongHt <= dataGridView1.Rows.Count)
            {
                string msv = tbMaSV.Text;
                string ten = tbTen.Text;
                string date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                string gt = "Nữ";
                if (rbNam.Checked) { gt = "Nam"; }
                string que = cbQue.Text;
                string lop = cbLop.Text;
                string khoa = cbKhoa.Text;

                dataGridView1.Rows[dongHt].Cells[0].Value = msv;
                dataGridView1.Rows[dongHt].Cells[1].Value = ten;
                dataGridView1.Rows[dongHt].Cells[2].Value = date;
                dataGridView1.Rows[dongHt].Cells[3].Value = gt;
                dataGridView1.Rows[dongHt].Cells[4].Value = que;
                dataGridView1.Rows[dongHt].Cells[5].Value = lop;
                dataGridView1.Rows[dongHt].Cells[6].Value = khoa;
            }
        }
    }
}
