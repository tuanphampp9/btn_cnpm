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
using System.Text.RegularExpressions;
namespace BTL_QLNhaTro
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
            rdoMale.Checked = true;
        }
        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtUsername.Text) && !IsValidPhoneNumber(txtUsername.Text))
            {
                MessageBox.Show("Email/SĐT không hợp lệ");
                return;
            }
            else if (IsValidEmail(txtUsername.Text)&& checkEmailExist())
            {
                MessageBox.Show("Email này đã được đăng kí rồi!");
                return;
            }
            else if (IsValidPhoneNumber(txtUsername.Text)&& checkNumberPhoneExist())
            {
                MessageBox.Show("Số điện thoại này đã được đăng kí rồi!");
                return;
            }
            
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prc_signUp";
                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@gender", rdoMale.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@dob",dtpDOB.Value);
                    cmd.Parameters.AddWithValue("@email", IsValidEmail(txtUsername.Text)?txtUsername.Text:"");
                    cmd.Parameters.AddWithValue("@sdt", IsValidPhoneNumber(txtUsername.Text)?txtUsername.Text:"");
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text); 
                    cmd.Parameters.AddWithValue("@role", "Chu tro");
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Đăng ký thành công");
                        frmDangNhap formLogin = new frmDangNhap();
                        this.Visible = false;
                        formLogin.Show();
                    }
                }
            }

        }
        private bool IsValidEmail(string input)
        {
            // Regular expression for email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(input, pattern);
        }
        private bool IsValidPhoneNumber(string input)
        {
            // Regular expression for phone number validation
            string pattern = @"^\d{10}$"; // Assuming 10 digits for a phone number
            return Regex.IsMatch(input, pattern);
        }
        private bool checkEmailExist()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter($"select * from tblChuToa where sEmail = '{txtUsername.Text}'", cnn);
                DataTable tblChuToa = new DataTable();
                da.Fill(tblChuToa);
                if (tblChuToa.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }
        private bool checkNumberPhoneExist()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter($"select * from tblChuToa where sSdt = '{txtUsername.Text}'", cnn);
                DataTable tblChuToa = new DataTable();
                da.Fill(tblChuToa);
                if (tblChuToa.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }
        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangNhap formLogin = new frmDangNhap();
            this.Visible = false;
            formLogin.ShowDialog();
            this.Close();
        }

        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                e.Cancel = true;
                errorProviderSignUp.SetError(txtFullName, "Họ và tên không được để trống!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSignUp.SetError(txtFullName, null);
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                errorProviderSignUp.SetError(txtUsername, "Tên đăng nhập không được để trống!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSignUp.SetError(txtUsername, null);
            }
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProviderSignUp.SetError(txtPassword, "Bạn chưa nhập mật khẩu!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSignUp.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProviderSignUp.SetError(txtConfirmPassword, "Xác nhận mật khẩu chưa được nhập!");
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProviderSignUp.SetError(txtConfirmPassword, "Mật khẩu xác nhận không khớp");
            }
            else
            {
                e.Cancel = false;
                errorProviderSignUp.SetError(txtConfirmPassword, null);
            }
        }
    }
}
