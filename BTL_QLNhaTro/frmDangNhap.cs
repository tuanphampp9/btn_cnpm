using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace BTL_QLNhaTro
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy formSingUp = new frmDangKy();
            this.Visible = false;
            formSingUp.ShowDialog();
        }
        private bool checkNullInput()
        {
            if (txtUserName.Text == "")
            {
                errorProviderCheckLogin.SetError(txtUserName, "Bạn chưa nhập tên đăng nhập");
                txtUserName.Focus();
                return false;
            }
            errorProviderCheckLogin.SetError(txtUserName, null);
            if (txtPassword.Text == "")
            {
                errorProviderCheckLogin.SetError(txtPassword, "Bạn chưa nhập mật khẩu");
                txtPassword.Focus();
                return false;
            }
            errorProviderCheckLogin.SetError(txtPassword, null);
            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (checkNullInput())
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    SqlDataAdapter da = new SqlDataAdapter($"select * from tblNguoiDung inner join tblChuToa on tblNguoiDung.FK_ChuToa_id = tblChuToa.PK_Id where sTenDangNhap='{txtUserName.Text}' and sMatKhau='{txtPassword.Text}'", cnn);
                    DataTable tblNguoiDung = new DataTable();
                    da.Fill(tblNguoiDung);
                    if (tblNguoiDung.Rows.Count > 0)
                    {
                        frmHome formHome = new frmHome(tblNguoiDung.Rows[0].Field<string>("sHoTen"), tblNguoiDung.Rows[0].Field<int>("PK_Id"), tblNguoiDung.Rows[0]["sVaiTro"].ToString());
                        this.Visible = false;
                        formHome.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
                    }
                }
            }           
        }
    }
}
