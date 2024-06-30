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
    public partial class NhapDiem : Form
    {
        public NhapDiem()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter daDl;
        DataTable dtDl;
        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLHT;Integrated Security=True";
        private void NhapDiem_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();
            dtDl = new DataTable();
            loadMaSo();
            loadMon();
        }
        private void loadMaSo()
        {
            SqlDataAdapter daM = new SqlDataAdapter("select distinct MaSo,HoTen from SV", con);
            DataTable dtM = new DataTable();
            daM.Fill(dtM);
            comboBox1.DataSource = dtM;
            comboBox1.ValueMember = "MaSo";
            comboBox2.DataSource = dtM;
            comboBox2.ValueMember = "HoTen";
        }
        private void loadMon()
        {
            SqlDataAdapter daH = new SqlDataAdapter("select distinct MaMH,TenMH from Mon", con);
            DataTable dtH = new DataTable();
            daH.Fill(dtH);
            comboBox3.DataSource = dtH;
            comboBox3.ValueMember = "MaMH";
            comboBox4.DataSource = dtH;
            comboBox4.ValueMember = "TenMH";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            cmd = new SqlCommand("insert into KetQua(MaSo,MaMH,Diem) values ('"+comboBox1.Text+ "','" + comboBox3.Text + "','" + textBox5.Text + "')", con);
            cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu thành công! ");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
    }
}
