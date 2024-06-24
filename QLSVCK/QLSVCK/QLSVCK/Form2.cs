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

namespace QLSVCK
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlDataAdapter daDgv1;
        DataTable dtDgv1;
        SqlDataAdapter daDgv2;
        DataTable dtDgv2;
        SqlCommand cmd;
        string sqlCon = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=SV;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlCon);
            con.Open();
           // dtDgv1 = new DataTable();

          /*  SqlDataAdapter daLop = new SqlDataAdapter("select distinct Lop from SV1 ", con);
            DataTable dtLop = new DataTable();
            daLop.Fill(dtLop);
            comboBox2.DataSource = dtLop;
            comboBox2.ValueMember = "Lop";*/
            dtDgv1 = new DataTable();
            dtDgv2 = new DataTable();

            dataGridView3.DataSource = dtDgv1;
            dataGridView2.DataSource = dtDgv2;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            daDgv1 = new SqlDataAdapter("select * from SV1 where Lop = '"+comboBox2.Text+"' group by MaSV,Ten,Lop,Mon,hs1,hs2,thi,thilai", con);
            dtDgv1.Clear();
            daDgv1.Fill(dtDgv1);
            label22.Text = dtDgv1.Rows.Count.ToString();
        }
        int dongHt = -1;
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongHt = e.RowIndex;
            if(dongHt >= 0 && dtDgv1.Rows.Count > dongHt)
            {
                textBox1.Text = dtDgv1.Rows[dongHt][0].ToString();
                textBox2.Text = dtDgv1.Rows[dongHt][1].ToString();
                comboBox2.Text = dtDgv1.Rows[dongHt][2].ToString();
                textBox3.Text = dtDgv1.Rows[dongHt][3].ToString();
                textBox4.Text = dtDgv1.Rows[dongHt][4].ToString();
                textBox5.Text = dtDgv1.Rows[dongHt][5].ToString();
                textBox6.Text = dtDgv1.Rows[dongHt][6].ToString();
                textBox7.Text = dtDgv1.Rows[dongHt][7].ToString();
                
                daDgv2 = new SqlDataAdapter("select MaSV,Mon,hs1,hs2,thi,thilai from SV1 where MaSV = '"+textBox1.Text+ "' group by MaSV,Mon,hs1,hs2,thi,thilai", con);
                dtDgv2.Clear();
                daDgv2.Fill(dtDgv2);
                label16.Text = dtDgv2.Rows.Count.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hs1 = "",thi="";
            string hs2 = "",thilai="";

            cmd = new SqlCommand("update SV1 set hs1='"+hs1+ "',hs2='" + hs2 + "',thi='" + thi + "',thilai='" + thilai + "' where MaSV='"+textBox1.Text+"'  ", con);
            cmd.ExecuteNonQuery();
            dtDgv2.Clear();
            daDgv2.Fill(dtDgv2);
            dataGridView2.DataSource = dtDgv2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*cmd = new SqlCommand("insert into SV1 values( '" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + comboBox2.Text + "',N'" + textBox3.Text + "','" + textBox4.Text + "'" +
                "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "') ", con);
            cmd.ExecuteNonQuery();
            dtDgv1.Clear();
            daDgv1.Fill(dtDgv1);*/
            dtDgv1.Rows.Add(textBox1.Text, textBox2.Text, comboBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
            //dataGridView2.DataSource = dtDgv2;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update SV1 set MaSV = '" + textBox1.Text + "',Ten =N'" + textBox2.Text + "',Lop= N'" + comboBox2.Text + "',Mon=N'" + textBox3.Text + "',hs1='" + textBox4.Text + "'," +
                "hs2 ='" + textBox5.Text + "',thi='" + textBox6.Text + "',thilai='" + textBox7.Text + "' ", con);
            cmd.ExecuteNonQuery();
            dtDgv1.Clear();
            daDgv1.Fill(dtDgv1);
        }
    }
}
