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
    public partial class frmThemLienHe : Form
    {
        String tenNhom;
        public frmThemLienHe(String tenNhom)
        {
            InitializeComponent();
            this.tenNhom = tenNhom;
        }
        private void BtnDongY_Click(object sender, EventArgs e)
        {
            String tenGoi = txtTenGoi.Text;
            String email = txtEmail.Text;
            String soDienThoai = txtSDT.Text;
            String diaChi = txtDiaChi.Text;
            if (tenGoi == "")
            {
                errorProvider.SetError(txtTenGoi, "Vui lòng nhập tên liên hệ");
                txtTenGoi.Focus();
                return;
            }
            else if(soDienThoai == "")
            {
                errorProvider.SetError(txtSDT, "Vui lòng nhập số điện thoại");
                txtSDT.Focus();
                return;
            }
            else if (email == "")
            {
                errorProvider.SetError(txtEmail, "Vui lòng nhập email");
                txtEmail.Focus();
                return;
            }
            else if (diaChi == "")
            {
                errorProvider.SetError(txtDiaChi, "Vui lòng nhập địa chỉ");
                txtDiaChi.Focus();
                return;
            }
            else if (!LienHe.IsValidEmail(email))
            {
                errorProvider.SetError(txtEmail, "Email không đúng định dạng");
                txtEmail.Focus();
                return;
            }
            else if (!LienHe.IsValidPhone(soDienThoai))
            {
                errorProvider.SetError(txtSDT, "Số điện thoại không đúng định dạng");
                txtSDT.Focus();
                return;
            }
            else
            {
                LienHe lh = LienHe.GetLienHe(tenGoi);
                if (lh != null)
                {
                    //sua
                    //MessageBox.Show("Tên liên hệ đã tồn tại", "Thông báo", MessageBoxButtons.OK,
                    //MessageBoxIcon.Information);
                    if (MessageBox.Show("Liên hệ này đã tồn tại. Bạn có muốn sửa liên hệ này không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        LienHe.Edit(new LienHe
                        {
                            TenGoi = tenGoi,
                            Email = email,
                            SDT = soDienThoai,
                            DiaChi = diaChi,
                            TenNhom = tenNhom
                        });
                        this.Close();
                    }
                }
                else
                {
                    LienHe.Add(new LienHe
                    {
                        TenGoi=tenGoi,
                        Email=email,
                        SDT=soDienThoai,
                        DiaChi=diaChi,
                        TenNhom=tenNhom
                    });
                    //MessageBox.Show("Đã thêm nhóm thành công", "Thông báo", MessageBoxButtons.OK,
                    //MessageBoxIcon.Information);
                    ThongBaoLienHe f = new ThongBaoLienHe();
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