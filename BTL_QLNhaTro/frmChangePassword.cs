using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLNhaTro
{
    public partial class frmChangePassword : Form
    {
        public int userId;
        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;
        public frmChangePassword(int userId)
        {
            this.userId = userId;
            InitializeComponent();
        }

        private void txtOldPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                e.Cancel = true;
                errorProviderChangePassword.SetError(txtOldPassword, "Bạn chưa nhập mật khẩu cũ!");
            }
            else
            {
                e.Cancel = false;
                errorProviderChangePassword.SetError(txtOldPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProviderChangePassword.SetError(txtNewPassword, "Bạn chưa nhập mật khẩu mới!");
            }
            else
            {
                e.Cancel = false;
                errorProviderChangePassword.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProviderChangePassword.SetError(txtConfirmPassword, "Bạn chưa nhập mật khẩu xác nhận mật khẩu mới!");
            }
            else
            {
                e.Cancel = false;
                errorProviderChangePassword.SetError(txtConfirmPassword, null);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }
            string sqlSelect = $"select * from tblNguoiDung where PK_User_Id = {this.userId} and tblNguoiDung.sMatKhau = '{txtOldPassword.Text}'";
            if (checkOldPassword(sqlSelect))
            {
                string sqlUpdate = $"UPDATE tblNguoiDung SET sMatKhau = '{txtNewPassword.Text}' WHERE PK_User_Id = {this.userId}";
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sqlUpdate;
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (i > 0)
                        {
                            MessageBox.Show("Cập nhật mật khẩu thành công!");
                        }
                    }
                }
            }
        }
        private bool checkOldPassword(string query)
        {
            bool result = true;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, cnn);
                DataTable tblNguoiDung = new DataTable();
                da.Fill(tblNguoiDung);
                if (tblNguoiDung.Rows.Count == 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                    result = false;
                }
            }
            return result;
        }
    }
}
