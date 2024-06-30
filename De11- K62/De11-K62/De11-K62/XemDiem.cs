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
    public partial class XemDiem : Form
    {
        public XemDiem()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter daDl;
        DataTable dtDl;
        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLHT;Integrated Security=True";

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void XemDiem_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();
            dtDl = new DataTable();
            dataGridView2.DataSource = dtDl;
            loadMaSo();
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

        private void button1_Click(object sender, EventArgs e)
        {
            daDl = new SqlDataAdapter("SELECT Mon.TenMH, KetQua.Diem FROM KetQua JOIN Mon ON KetQua.MaMH = Mon.MaMH " +
                "WHERE KetQua.MaSo = '"+comboBox1.Text+"'", con);
            dtDl = new DataTable();
            daDl.Fill(dtDl);
            dataGridView2.DataSource = dtDl;
        }
    }
}
