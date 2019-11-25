using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.DAL.Entity;

namespace WindowsFormsApp2
{
    public partial class frmThemNhom : Form
    {
        public frmThemNhom()
        {
            InitializeComponent();
        }

        private void BtnDongY_Click(object sender, EventArgs e)
        {
            String tenNhom = txtTenNhom.Text;
            if (tenNhom == null|| tenNhom=="")
            {
                errorProvider.SetError(txtTenNhom, "Vui lòng nhập tên nhóm");
                txtTenNhom.Focus();
                return; 
            }
            else
            {
                Nhom nhom = Nhom.TimKiem(tenNhom);
                if (nhom != null)
                {
                    MessageBox.Show("Tên nhóm đã tồn tại", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    Nhom.Add(tenNhom);
                    //MessageBox.Show("Đã thêm nhóm thành công", "Thông báo", MessageBoxButtons.OK,
                    //MessageBoxIcon.Information);
                    ThongBaoNhom f = new ThongBaoNhom();
                    f.ShowDialog();
                    this.Close();
                }
            }
        }

        private void BtnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
