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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV
{
    public partial class LoginForm : Form
    {
        // sql
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnGui_Click(object sender, EventArgs e)
        {
           // Mở giao diện khác
             //Khai bao chuoi ket noi
              string sql = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QLSV3;Integrated Security=True";
             con = new SqlConnection(sql);
             //Mo ket noi
             con.Open();
             //Khai bao lenh SQL
             string sqlSelect = "select *from LOGIN where email = '" + txtUsername.Text + "'and pass = '" + txtPassword.Text + "'";
             //Thuc hien lenh truy van
             cmd = new SqlCommand(sqlSelect, con);
             reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                // Mở giao diện khác
                MainForm f = new MainForm();
                f.Show();
                this.Hide();
            }
            else
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Sai dữ liệu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Đóng kết nối và giải phóng tài nguyên
            con.Close();
            con.Dispose();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn đóng chương trình", "Hỏi người dùng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
            
        }

      
    }
}
