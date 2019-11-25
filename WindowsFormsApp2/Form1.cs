using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.DAL.Entity;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            LoadForm1();          
        }
        private void DgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvContacts.Rows.Clear();
                    string tenNhom = dgvGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
                    if (tenNhom != null)
                    {
                        List<LienHe> dslh = LienHe.GetList(tenNhom);
                        foreach (var i in dslh)
                        {
                            dgvContacts.Rows.Add(i.TenGoi, i.Email, i.SDT);
                        }
                        LienHe lh = LienHe.GetLienHe(dgvContacts.Rows[0].Cells[0].FormattedValue.ToString());
                        if (lh != null)
                        {
                            label1.Text = "Địa chỉ:";
                            label2.Text = "Email:";
                            label3.Text = "Số điện thoại:";
                            lblTenGoi.Text = lh.TenGoi;
                            lblDiaChi.Text = lh.DiaChi;
                            lblEmail.Text = lh.Email;
                            lblSDT.Text = lh.SDT;
                        }
                        else
                        {
                            lblTenGoi.Text = "";
                            lblDiaChi.Text = "";
                            lblEmail.Text = "";
                            lblSDT.Text = "";
                            label1.Text = "";
                            label2.Text = "";
                            label3.Text = "";
                        }
                    }
                }
            }catch (Exception ex){ }
        }

        private void DgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvContacts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string tenGoi = dgvContacts.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    if (tenGoi != null)
                    {
                        LienHe lh = LienHe.GetLienHe(tenGoi);
                        label1.Text = "Địa chỉ:";
                        label2.Text = "Email:";
                        label3.Text = "Số điện thoại:";
                        lblTenGoi.Text = lh.TenGoi;
                        lblDiaChi.Text = lh.DiaChi;
                        lblEmail.Text = lh.Email;
                        lblSDT.Text = lh.SDT;
                    }
                    else
                    {
                        lblTenGoi.Text = "";
                        lblDiaChi.Text = "";
                        lblEmail.Text = "";
                        lblSDT.Text = "";
                        label1.Text = "";
                        label2.Text = "";
                        label3.Text = "";
                    }

                }
            }catch(Exception ex){}
        }

        private void TsbXoaLienLac_Click(object sender, EventArgs e)
        {
            try
            {
                int hanghientai = dgvContacts.CurrentCell.RowIndex;
                String tenGoi = dgvContacts.Rows[hanghientai].Cells[0].Value.ToString();
                if (tenGoi != null)
                {
                    if (MessageBox.Show("Bạn có thực sự muốn xóa liên hệ này không?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                    {
                        dgvContacts.Rows.RemoveAt(dgvContacts.CurrentCell.RowIndex);
                        bdsContacts.DataSource = dgvContacts.DataSource;
                        LienHe.Remove(tenGoi);
                        List<LienHe> dslh = LienHe.GetList(dgvGroup.CurrentCell.Value.ToString());
                        if (dslh.Count >= 1)
                        {
                            String tenGoiMoi = dgvContacts.Rows[0].Cells[0].Value.ToString();
                            if (tenGoiMoi != null)
                            {
                                LienHe lh = LienHe.GetLienHe(tenGoiMoi);
                                label1.Text = "Địa chỉ:";
                                label2.Text = "Email:";
                                label3.Text = "Số điện thoại:";
                                lblTenGoi.Text = lh.TenGoi;
                                lblDiaChi.Text = lh.DiaChi;
                                lblEmail.Text = lh.Email;
                                lblSDT.Text = lh.SDT;
                            }
                            else
                            {
                                lblTenGoi.Text = "";
                                lblDiaChi.Text = "";
                                lblEmail.Text = "";
                                lblSDT.Text = "";
                                label1.Text = "";
                                label2.Text = "";
                                label3.Text = "";
                            }
                        }
                        else
                        {
                            lblTenGoi.Text = "";
                            lblDiaChi.Text = "";
                            lblEmail.Text = "";
                            lblSDT.Text = "";
                            label1.Text = "";
                            label2.Text = "";
                            label3.Text = "";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn liên hệ muốn xóa","Thông báo",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
                      
        }
        private void TsbXoaNhom_Click(object sender, EventArgs e)
        {
            try
            {
                int hanghientai = dgvGroup.CurrentCell.RowIndex;
                String tenNhom = dgvGroup.Rows[hanghientai].Cells[0].Value.ToString();
                if (tenNhom != null)
                {
                    if (MessageBox.Show("Bạn có thực sự muốn xóa nhóm này không?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                    {
                        dgvGroup.Rows.RemoveAt(dgvGroup.CurrentCell.RowIndex);
                        bdsGroups.DataSource = dgvGroup.DataSource;
                        LienHe.RemoveListContact(tenNhom);
                        Nhom.Remove(tenNhom);
                        dgvContacts.Rows.Clear();
                        List<LienHe> dslh = LienHe.GetList(dgvGroup.Rows[0].Cells[0].FormattedValue.ToString());
                        if (dslh != null)
                        {
                            foreach (var i in dslh)
                            {
                                dgvContacts.Rows.Add(i.TenGoi, i.Email, i.SDT);
                            }

                            LienHe lh = LienHe.GetLienHe(dgvContacts.Rows[0].Cells[0].FormattedValue.ToString());
                            if (lh != null)
                            {
                                label1.Text = "Địa chỉ:";
                                label2.Text = "Email:";
                                label3.Text = "Số điện thoại:";
                                lblTenGoi.Text = lh.TenGoi;
                                lblDiaChi.Text = lh.DiaChi;
                                lblEmail.Text = lh.Email;
                                lblSDT.Text = lh.SDT;
                            }
                            else
                            {
                                lblTenGoi.Text = "";
                                lblDiaChi.Text = "";
                                lblEmail.Text = "";
                                lblSDT.Text = "";
                                label1.Text = "";
                                label2.Text = "";
                                label3.Text = "";

                            }
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn nhóm muốn xóa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void TsbThemNhom_Click(object sender, EventArgs e)
        {
            frmThemNhom f = new frmThemNhom();
            f.ShowDialog();
            LoadForm1();
        }
        private void TsbThemLienLac_Click(object sender, EventArgs e)
        {
            try
            {
                int hanghientai = dgvGroup.CurrentCell.RowIndex;
                String tenNhom = dgvGroup.Rows[hanghientai].Cells[0].Value.ToString();
                if (tenNhom == "" || tenNhom == null)
                {
                    MessageBox.Show("Vui lòng chọn nhóm cần thêm liên hệ", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                frmThemLienHe f = new frmThemLienHe(tenNhom);
                f.ShowDialog();
                dgvContacts.Rows.Clear();
                List<Nhom> dsn = Nhom.GetList();
                if (dsn != null)
                {
                    
                    List<LienHe> dslh = LienHe.GetList(tenNhom);
                    foreach (var i in dslh)
                    {
                        dgvContacts.Rows.Add(i.TenGoi, i.Email, i.SDT);
                    }

                    LienHe lh = LienHe.GetLienHe(dgvContacts.Rows[0].Cells[0].FormattedValue.ToString());
                    if (lh != null)
                    {
                        label1.Text = "Địa chỉ:";
                        label2.Text = "Email:";
                        label3.Text = "Số điện thoại:";
                        lblTenGoi.Text = lh.TenGoi;
                        lblDiaChi.Text = lh.DiaChi;
                        lblEmail.Text = lh.Email;
                        lblSDT.Text = lh.SDT;
                    }
                    else
                    {
                        lblTenGoi.Text = "";
                        lblDiaChi.Text = "";
                        lblEmail.Text = "";
                        lblSDT.Text = "";
                        label1.Text = "";
                        label2.Text = "";
                        label3.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn nhóm muốn thêm liên hệ", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
        private void LoadForm1()
        {
            dgvContacts.Rows.Clear();
            dgvGroup.Rows.Clear();
            List<Nhom> dsn = Nhom.GetList();
            if (dsn != null)
            {
                foreach (var i in dsn)
                {
                    dgvGroup.Rows.Add(i.TenNhom);
                }

                List<LienHe> dslh = LienHe.GetList(dgvGroup.Rows[0].Cells[0].FormattedValue.ToString());
                foreach (var i in dslh)
                {
                    dgvContacts.Rows.Add(i.TenGoi, i.Email, i.SDT);
                }

                LienHe lh = LienHe.GetLienHe(dgvContacts.Rows[0].Cells[0].FormattedValue.ToString());
                if (lh != null)
                {
                    label1.Text = "Địa chỉ:";
                    label2.Text = "Email:";
                    label3.Text = "Số điện thoại:";
                    lblTenGoi.Text = lh.TenGoi;
                    lblDiaChi.Text = lh.DiaChi;
                    lblEmail.Text = lh.Email;
                    lblSDT.Text = lh.SDT;
                }
                else
                {
                    lblTenGoi.Text = "";
                    lblDiaChi.Text = "";
                    lblEmail.Text = "";
                    lblSDT.Text = "";
                    label1.Text = "";
                    label2.Text = "";
                    label3.Text = "";
                }
            }
        }
        private void ToolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int hanghientai = dgvGroup.CurrentCell.RowIndex;
                String tenNhom = dgvGroup.Rows[hanghientai].Cells[0].Value.ToString();
                String key = toolStripTextBox1.Text;
                var dstk = LienHe.TimKiem(tenNhom, key);
                dgvContacts.Rows.Clear();
                foreach (var i in dstk)
                {
                    dgvContacts.Rows.Add(i.TenGoi, i.Email, i.SDT);

                }
            }
            catch (Exception ex)
            {
                dgvContacts.Rows.Clear();
            }
        }
    }
}
