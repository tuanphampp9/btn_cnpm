using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLNhaTro
{
    public partial class frmThemKH : Form
    {

        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;
        private int maPhong;
        private string Password;

        public frmThemKH(int maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;
            this.Password = "MaPhong" + maPhong;
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

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (!IsValidEmail(txtUsername.Text) && !IsValidPhoneNumber(txtUsername.Text))
            {
                MessageBox.Show("Email/SĐT không hợp lệ");
                return;
            }
            else if (IsValidEmail(txtUsername.Text) && checkEmailExist())
            {
                MessageBox.Show("Email này đã được đăng kí rồi!");
                return;
            }
            else if (IsValidPhoneNumber(txtUsername.Text) && checkNumberPhoneExist())
            {
                MessageBox.Show("Số điện thoại này đã được đăng kí rồi!");
                return;
            }

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prc_themKH";
                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@gender", rdoMale.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@dob", dtpDOB.Value);
                    cmd.Parameters.AddWithValue("@email", IsValidEmail(txtUsername.Text) ? txtUsername.Text : "");
                    cmd.Parameters.AddWithValue("@sdt", IsValidPhoneNumber(txtUsername.Text) ? txtUsername.Text : "");
                    cmd.Parameters.AddWithValue("@password", this.Password);

                    SqlParameter userIdParam = new SqlParameter("@userId", SqlDbType.Int);
                    userIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(userIdParam);

                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();

                    int userId = Convert.ToInt32(userIdParam.Value);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@maPhong", this.maPhong);
                    cmd.CommandText = "prc_themKH_Phong";
                    cmd.CommandType = CommandType.StoredProcedure;
                    i = cmd.ExecuteNonQuery();

                    cnn.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        frmChiTietPhong formCT = new frmChiTietPhong(this.maPhong);
                        this.Visible = false;
                        formCT.Show();
                    }
                }
            }
        }
    }
}
