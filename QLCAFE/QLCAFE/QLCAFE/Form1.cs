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

namespace QLCAFE
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapDl;
        SqlDataReader dr;
        DataTable dt;
        string sqlCon = "Data Source=DESKTOP-TJ5SUOH\\SQLEXPRESS;Initial Catalog=QLYCAFE;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();
            //load dl từ sql vào datagridview
            adapDl = new SqlDataAdapter("select SOBAN AS 'Số Bàn',DOUONG AS 'Tên Đồ Uống',SOLUONG AS 'Số Lượng',GIA AS 'Giá',NGAY AS 'Ngày' from DATHANG", con); 
            dt = new DataTable();
            adapDl.Fill(dt);
            dataGridView1.DataSource = dt;

            //load cb box
            SqlDataAdapter daDs = new SqlDataAdapter("select distinct DOUONG from DATHANG",con);
            DataTable dtDs = new DataTable();
            daDs.Fill(dtDs);
            cbDrink.DataSource = dtDs;
            cbDrink.ValueMember = "DOUONG";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(!cbDoUong.Checked && !cbDate.Checked)
            {
                MessageBox.Show("Bạn chưa chọn option Thống kê!");
            }
            else
            {
                if (cbDoUong.Checked == true && cbDate.Checked == false)
                {
                    string sql = "select SOBAN AS 'Số bàn', DOUONG AS 'Tên Đồ Uống', SUM(SOLUONG) AS 'Số Lượng', GIA AS 'Giá', NGAY AS 'Ngày' from DATHANG where DOUONG = N'" + cbDrink.Text + "' group by SOBAN, DOUONG, GIA, NGAY";
                    adapDl = new SqlDataAdapter(sql, con);
                    dt.Clear();
                    adapDl.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (cbDoUong.Checked == false && cbDate.Checked == true)
                {
                    string sql = "select SOBAN AS 'Số bàn', DOUONG AS 'Tên Đồ Uống', SUM(SOLUONG) AS 'Số Lượng', GIA AS 'Giá', NGAY AS 'Ngày' from DATHANG where NGAY >= '"+dateFrom.Value.ToString("yyyy-MM-dd")+ "' AND NGAY <= '" + dateEnd.Value.ToString("yyyy-MM-dd") + "' group by SOBAN, DOUONG, GIA, NGAY";
                    adapDl = new SqlDataAdapter(sql, con);
                    dt.Clear();
                    adapDl.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (cbDoUong.Checked == true && cbDate.Checked == true)
                {
                    string sql = "select SOBAN AS 'Số bàn', DOUONG AS 'Tên Đồ Uống', SUM(SOLUONG) AS 'Số Lượng', GIA AS 'Giá', NGAY AS 'Ngày' from DATHANG where NGAY >= '" + dateFrom.Value.ToString("yyyy-MM-dd") + "' AND NGAY <= '" + dateEnd.Value.ToString("yyyy-MM-dd") + "' AND DOUONG = '"+cbDrink.Text+"' group by SOBAN, DOUONG, GIA, NGAY";
                    adapDl = new SqlDataAdapter(sql, con);
                    dt.Clear();
                    adapDl.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                txtDoanhThu.Text = doanhThu() + " ";
            }
        }

        private int doanhThu()
        {
            int sum = 0;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                int sl = Convert.ToInt32(dt.Rows[i][2].ToString());
                int gia = Convert.ToInt32(dt.Rows[i][3].ToString());
                sum += (sl * gia);
            }
            return sum;
        }
    }
}
