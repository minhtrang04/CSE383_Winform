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

namespace QuanLyBH
{
    
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        //SqlDataAdapter adapDl;
        //DataTable dt;
        SqlDataAdapter adapDgv1;
        DataTable dtDgv1;
        string sql = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=QUANLYBH;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sql);
            con.Open();

            adapDgv1 = new SqlDataAdapter("select row_number() over (order by stt) as 'STT' ,tenHang as 'Tên Hàng',donGia as 'Đơn Giá' from BH1", con);
            dtDgv1 = new DataTable();
            dtDgv1.Rows.Clear();
            adapDgv1.Fill(dtDgv1);
            dataGridView1.DataSource = dtDgv1;

            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from DH", con);
            cmd.ExecuteNonQuery();
            dtDgv1.Rows.Clear();
            adapDgv1.Fill(dtDgv1);
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string num = numericUpDown1.Value.ToString();

            cmd = new SqlCommand("insert into values()", con);
            cmd.ExecuteNonQuery();
            dtDgv1.Rows.Clear();
            adapDgv1.Fill(dtDgv1);
        }
        private void InsertIntoDH(string tenHang, int soLuong, float donGia, float thanhTien)
        {
           string num = numericUpDown1.Value.ToString();
            int numb = int.Parse(numericUpDown1.Value.ToString());
           

            string query = "INSERT INTO DH VALUES(soLuong = '" + num + "',thanhTien = '" + txtTen.Text + "'))";
            
        }

        private void cbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            adapDgv1 = new SqlDataAdapter("select row_number() over (order by stt) as 'STT', tenHang as 'Tên Hàng',donGia as 'Đơn Giá' from BH1 where theLoai = N'" + cbTheLoai.Text + "' group by stt,tenHAng,donGia,theLoai", con);
            dtDgv1.Clear();
            adapDgv1.Fill(dtDgv1);
            dataGridView1.DataSource = dtDgv1;
            switch (cbTheLoai.SelectedIndex)
            {
                case 0:
                    {
                        labelTheLoai.Text = "Đồ uống";
                        
                        
                       
                        break;
                    }
                case 1:
                    {
                        labelTheLoai.Text = "Bột mì";
                        break; 
                    }
                case 2:
                    {
                        labelTheLoai.Text = "Gia vị";
                        break;
                    }
                case 3:
                    {
                        labelTheLoai.Text = "Sữa";
                        break;
                    }
                case 4:
                    {
                        labelTheLoai.Text = "Đường";
                        break;
                    }
                case 5:
                    {
                        labelTheLoai.Text = "Rau củ";
                        break;
                    }
                case 6:
                    {
                        labelTheLoai.Text = "Thịt";
                        break;
                    }
                    
            }
        }

        private void cbTheLoai_SelectionChangeCommitted(object sender, EventArgs e)
        {
           // CategoryAttribute obj = cbTheLoai.SelectedItem as CategoryAttribute;
           
        }
    }
}
