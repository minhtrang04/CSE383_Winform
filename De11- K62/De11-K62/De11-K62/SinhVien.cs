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

namespace De11_K62
{
    public partial class SinhVien : Form
    {
        int dongHt = -1;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter daDl;
        DataTable dtDl;
        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLHT;Integrated Security=True";
        public SinhVien()
        {
            InitializeComponent();
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();

            //load dl lên dtg
            daDl = new SqlDataAdapter("select * from SV", con);
            dtDl = new DataTable();
            daDl.Fill(dtDl);
            dataGridView1.DataSource = dtDl;

            //binding source
            BindingSource bind = new BindingSource();
            bind.DataSource = dtDl;
            bindingNavigator1.BindingSource = bind;
            dataGridView1.DataSource = bind;
        }
        
        void hienthi()
        {
            BindingSource bind = new BindingSource();
            bind.DataSource = dtDl;
            bindingNavigator1.BindingSource = bind;
            dataGridView1.DataSource = bind;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            int gt=0;
            if (checkBox1.Checked) { gt = 1; }
            else if (!checkBox1.Checked) { gt = 0; }
            string insertQuery = "INSERT INTO SV (MaSo, HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai, MaKhoa) " +
                                    "VALUES ('" + textBox1.Text + "', N'" + textBox2.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', " +
                                    gt + ", '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";

            cmd = new SqlCommand(insertQuery, con);
            cmd.ExecuteNonQuery();

            dtDl.Clear();
            daDl.Fill(dtDl);
            hienthi();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from SV where MaSo ='"+textBox1.Text+"'", con);
            cmd.ExecuteNonQuery();

            dtDl.Clear();
            daDl.Fill(dtDl);
            hienthi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt = e.RowIndex;
            if(dongHt>0 && dtDl.Rows.Count > dongHt)
            {
                textBox1.Text = dtDl.Rows[dongHt][0].ToString();
                textBox2.Text = dtDl.Rows[dongHt][1].ToString();
                dateTimePicker1.Text = dtDl.Rows[dongHt][2].ToString();
                checkBox1.Checked = Convert.ToBoolean(dtDl.Rows[dongHt][3].ToString());
                textBox3.Text= dtDl.Rows[dongHt][4].ToString();
                textBox4.Text = dtDl.Rows[dongHt][5].ToString();
                textBox5.Text = dtDl.Rows[dongHt][6].ToString();
            }

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            int gt = 0;
            if (checkBox1.Checked) { gt = 1; }
            else if (!checkBox1.Checked) { gt = 0; }
            cmd = new SqlCommand("update SV set MaSo ='"+ textBox1.Text + "',HoTen =N'" + textBox2.Text + "',NgaySinh ='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'," +
                "GioiTinh ='" + gt + "',DiaChi ='" + textBox3.Text + "',DienThoai ='" + textBox4.Text + "',MaKhoa ='" + textBox5.Text + "' where MaSo ='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();

            dtDl.Clear();
            daDl.Fill(dtDl);
            hienthi();
        }
    }
}
