using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLNhaTro
{
    public partial class frmHome : Form
    {
        private string userName;
        private string role;
        private int userId;
        public frmHome(string user_name,string fk_ChuToa_id, string fk_KhachHang_id, string role)
        {
            this.userName = user_name;
            this.role = role;
            this.userId = fk_ChuToa_id=="" ? int.Parse(fk_KhachHang_id) : int.Parse(fk_ChuToa_id);
            this.role = role;
            InitializeComponent();
            datSubMenu();
            lbFullName.Text = "Tên: " + userName;
        }

        // Thiết lập menu
        private void datSubMenu()
        {
            if(this.role=="Khách thuê")
            {
                pnToaNha.Visible = false;
            }
        }

        private void anSubMenu()
        {
           
        }

        private void hienSubMenu(Panel sulPanel)
        {
            if(sulPanel.Visible == false)
            {
                anSubMenu();
                sulPanel.Visible = true;
            }
            else
                sulPanel.Visible= false;
        }

        private Form activeForm;
        private void moChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            pnChildFrom.Controls.Clear();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnChildFrom.Controls.Add(childForm);
            pnChildFrom.Tag = childForm;
            childForm.Show();
        }
        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }         
        }


        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap formLogin = new frmDangNhap();
            this.Visible = false;
            formLogin.ShowDialog();
            this.Close();
        }

        private void btnToaNha_Click(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 540;
            frmToaNha nhap = new frmToaNha(this.userId);
            moChildForm(nhap);
            anSubMenu();
        }

        private void btnDetailAccount_Click(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 540;
            frmInfoUser nhap = new frmInfoUser(this.userId, this.role);
            moChildForm(nhap);
            anSubMenu();
        }
    }
}
