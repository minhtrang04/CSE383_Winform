using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class FormCapNhatDSSV : Form
    {
        public FormCapNhatDSSV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog
                {
                    Filter = "Excel Sheet (*.xlsx)|*.xlsx|All Files(*.*)|*.*"
                };
                if (op.ShowDialog() == DialogResult.OK)
                {
                    string filepath = op.FileName;

                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Open(filepath);
                    Excel._Worksheet worksheet = workbook.Sheets[1];
                    Excel.Range range = worksheet.UsedRange;

                    DataTable dt = new DataTable();

                    // Add columns to DataTable
                    for (int col = 1; col <= range.Columns.Count; col++)
                    {
                        dt.Columns.Add(range.Cells[1, col].Value2.ToString().Trim());
                    }

                    // Add rows to DataTable
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int col = 1; col <= range.Columns.Count; col++)
                        {
                            dr[col - 1] = range.Cells[row, col].Value2?.ToString().Trim() ?? "";
                        }
                        dt.Rows.Add(dr);
                    }

                    dataGridView1.DataSource = dt;

                    // Cleanup
                    workbook.Close(false);
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    // Debugging: Print column names
                    string columns = string.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                    MessageBox.Show("Columns in DataTable: " + columns);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.DataSource is DataTable dt)
                {
                    string connectionString = "Data Source=LAPTOP-GIDOGASR\\SQLEXPRESS;Initial Catalog=SQL_LibraryManagement;Integrated Security=True";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        foreach (DataRow row in dt.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO SinhVien (STT,MaSV, TenSV, GioiTinh, NgaySinh, DiaChi, SDT, Lop) VALUES (@STT,@MaSV, @TenSV, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Lop)", conn))
                            {
                                cmd.Parameters.AddWithValue("@STT", row["STT"].ToString());
                                cmd.Parameters.AddWithValue("@MaSV", row["MaSV"].ToString());
                                cmd.Parameters.AddWithValue("@TenSV", row["TenSV"].ToString());
                                cmd.Parameters.AddWithValue("@GioiTinh", row["GioiTinh"].ToString());
                                cmd.Parameters.AddWithValue("@NgaySinh", row["NgaySinh"].ToString());
                                cmd.Parameters.AddWithValue("@DiaChi", row["DiaChi"].ToString());
                                cmd.Parameters.AddWithValue("@SDT", Convert.ToInt32(row["SDT"]));
                                cmd.Parameters.AddWithValue("@Lop", row["Lop"].ToString());

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Dữ liệu đã được lưu thành công vào cơ sở dữ liệu.");
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để lưu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu vào cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void FormCapNhatDSSV_Load(object sender, EventArgs e)
        {

        }
    }
}
