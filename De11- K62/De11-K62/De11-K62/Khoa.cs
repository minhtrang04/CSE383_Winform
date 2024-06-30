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
    public partial class Khoa : Form
    {
        public Khoa()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter daDl;
        DataTable dtDl;
        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLHT;Integrated Security=True";
        private void Khoa_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();

            daDl = new SqlDataAdapter("select * from Khoa", con);
            dtDl = new DataTable();
            daDl.Fill(dtDl);
            dataGridView2.DataSource = dtDl;
            BindingSource bind = new BindingSource();
            bind.DataSource = dtDl;
            bindingNavigator1.BindingSource = bind;
            dataGridView2.DataSource = bind;
        }
        private void hienthi()
        {

            BindingSource bind = new BindingSource();
            bind.DataSource = dtDl;
            bindingNavigator1.BindingSource = bind;
            dataGridView2.DataSource = bind;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Khoa values('"+textBox1.Text+ "',N'" + textBox5.Text + "')", con);
            cmd.ExecuteNonQuery();
            dtDl.Clear();
            daDl.Fill(dtDl);
            hienthi();
        }
        int dongHt = -1;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt = e.RowIndex;
            if(dongHt >= 0 && dongHt < dtDl.Rows.Count)
            {
                textBox1.Text = dtDl.Rows[dongHt][0].ToString();
                textBox5.Text = dtDl.Rows[dongHt][1].ToString();
            }
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from Khoa where MaKhoa ='" + textBox1.Text + "' ", con);
            cmd.ExecuteNonQuery();
            dtDl.Clear();
            daDl.Fill(dtDl);
            hienthi();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update Khoa set MaKhoa='" + textBox1.Text + "', TenKhoa=N'" + textBox5.Text + "' where MaKhoa='" + textBox1.Text + "' ", con);
            cmd.ExecuteNonQuery();
            dtDl.Clear();
            daDl.Fill(dtDl);
            hienthi();
        }
    }
}
