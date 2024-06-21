using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class FormNhanVienSach : Form
    {
        public FormNhanVienSach()
        {
            InitializeComponent();
        }

        bool sidebarExpand = true;
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand == true)
            {
                sidebar.Width -= 5;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
        private Form currenFormChild;
        private void OpenChildForm(Form chilForm)
        {
            if (currenFormChild != null)
            {
                currenFormChild.Close();
            }
            currenFormChild = chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle = FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(chilForm);
            panelForm.Tag = chilForm;
            chilForm.BringToFront();
            chilForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLySach());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCapNhatDSSV());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormChinhSuaTkNV());
        }
    }
}
