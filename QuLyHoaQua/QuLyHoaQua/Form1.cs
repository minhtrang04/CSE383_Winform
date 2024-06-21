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

namespace QuLyHoaQua
{
    public partial class Form1 : Form
    {

        DataTable dt;
        int stt = 1;
        SqlDataAdapter adapDl;
        SqlCommand cmd;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TJ5SUOH\\SQLEXPRESS;Initial Catalog=QLWf04;Integrated Security=True");
        public Form1()
        {
            InitializeComponent(); 
            dt = new DataTable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(stt, dt.Rows[i][1].ToString(),
                    dt.Rows[i][2].ToString(),
                     dt.Rows[i][3].ToString(),
                      dt.Rows[i][4].ToString());
                       
                stt++;
            }
        }  /**/
        private void cbHoaqua_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbHoaqua.SelectedIndex)
            {
                case 0:
                    {
                        txtDongia.Text = "1500";
                        break;
                    }
                case 1:
                    {
                        txtDongia.Text = "2500";
                        break;
                    }
                case 2:
                    {
                        txtDongia.Text = "4000";
                        break;
                    }
                case 3:
                    {
                        txtDongia.Text = "5000";
                        break;
                    }
            }

        }

    private void btnThem_Click(object sender, EventArgs e)
    {

            string ten = cbHoaqua.Text;
            double gia = Convert.ToDouble(txtDongia.Text);
            int slg = (int)numSlg.Value;
            Double tt = gia * slg;
            dataGridView1.Rows.Add(stt, ten, gia, slg,tt);
            txtTra.Text = tt.ToString();
            stt++;
          
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
           
        }
        int dongHt = -1;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dongHt >= 0)
            {
                dataGridView1.Rows.RemoveAt(dongHt);
            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt = e.RowIndex;
            if (dongHt >= 0)
            {
                cbHoaqua.Text = dataGridView1.Rows[dongHt].Cells[1].Value.ToString();
                txtDongia.Text = dataGridView1.Rows[dongHt].Cells[2].Value.ToString();
                numSlg.Value = Convert.ToInt32(dataGridView1.Rows[dongHt].Cells[3].Value);
                txtTra.Text = dataGridView1.Rows[dongHt].Cells[4].Value.ToString();
            }
        }

        private void txtDua_TextChanged(object sender, EventArgs e)
        {

            try
            {
                double dua = double.Parse(txtDua.Text);
                double tong = double.Parse(txtTra.Text);
                txtTraLai.Text = (dua - tong).ToString();
            }
            catch
            {
                MessageBox.Show("Ô nhập chỉ bao gồm chữ số !");

            }
        }

        private void btnHoanThanh_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void đổiMàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                contextMenuStrip1.SourceControl.BackColor = dlg.Color;
            }
        }

        private void đổiFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                contextMenuStrip1.SourceControl.Font = font.Font;
            }
        }
    }
}

