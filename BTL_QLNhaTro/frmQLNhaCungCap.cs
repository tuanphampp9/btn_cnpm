using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BTL_QLNhaTro
{
    public partial class frmQLNhaCungCap : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db_BanTrangSuc"].ConnectionString;
        clXuLyData clXuLy = new clXuLyData();
        public frmQLNhaCungCap()
        {
            InitializeComponent();
        }

        private void reset()
        {
            errorProvider1.SetError(txtMaNCC, "");
            errorProvider1.SetError(txtTenNCC, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");

            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtMaNCC.Enabled = true;
            dgr_load();
            dgrNCC.ClearSelection();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgr_load();
            dgrNCC.ClearSelection();
        }

        private void dgr_load()
        {
            string sqlText = "SELECT sMaNCC, sTenNCC, sSDT, sDiaChi FROM tblNCC WHERE bttXoa = 0";
            DataTable dt = clXuLy.Lay_DataTable(sqlText, "tblNhaCC");
            dgrNCC.DataSource = dt;

            dgrNCC.Columns["sMaNCC"].HeaderText = "Mã nhà cung cấp";
            dgrNCC.Columns["sTenNCC"].HeaderText = "Tên nhà cung cấp";
            dgrNCC.Columns["sSDT"].HeaderText = "Số điện thoại";
            dgrNCC.Columns["sDiaChi"].HeaderText = "Địa chỉ";

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        

        private void dgrNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrNCC.Rows[e.RowIndex];

                txtMaNCC.Text = row.Cells["sMaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["sTenNCC"].Value.ToString();
                txtSDT.Text = row.Cells["sSDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["sDiaChi"].Value.ToString();
            }

            errorProvider1.SetError(txtMaNCC, "");
            errorProvider1.SetError(txtTenNCC, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");

            txtMaNCC.Enabled = false;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
           
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Xử lý
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            string sDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;

            if(maNCC=="" || tenNCC=="" || sDT=="" || diaChi =="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (clXuLy.ktDuLieu_VarCharTonTai("tblNCC","sMaNCC",maNCC))
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại, vui lòng nhập mã mới", "Thông báo");
                
            }
            else if (clXuLy.ktDuLieu_NVarCharTonTai("tblNCC", "sTenNCC", tenNCC))
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại, vui lòng nhập tên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else
            {
                ThemDuLieuVaoDB(maNCC, tenNCC, sDT, diaChi);
                reset();
                MessageBox.Show("Bạn vừa thêm thành công 1 nhà cung cấp", "Thông báo");
            }

        }
        private void ThemDuLieuVaoDB(string maNCC, string tenNCC, string sDT, string diaChi)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblNCC (sMaNCC, sTenNCC, sSDT, sDiaChi) VALUES (@MaNCC, @TenNCC, @SDT, @DiaChi)", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@SDT", sDT);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void txtMaNCC_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                errorProvider1.SetError(txtMaNCC, "Vui lòng nhập mã nhà cung cấp");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMaNCC, "");
            }
        }

        private void txtTenNCC_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenNCC.Text == "")
            {
                errorProvider1.SetError(txtTenNCC, "Vui lòng nhập tên nhà cung cấp");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenNCC, "");
            }
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            if (txtSDT.Text == "")
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }
        }

        private void txtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                errorProvider1.SetError(txtDiaChi, "Vui lòng nhập địa chỉ");
                return;
            }
            else
            {
                errorProvider1.SetError(txtDiaChi, "");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Xử lý
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            string sDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;

            if (maNCC == "" || tenNCC == "" || sDT == "" || diaChi == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (clXuLy.ktDuLieu_NVarCharTonTai("tblNCC", "sTenNCC", tenNCC))
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại, vui lòng nhập tên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                suaDuLieuTrongDB(maNCC, tenNCC, sDT, diaChi);
                reset();
                MessageBox.Show("Sửa thành công 1 nhà cung cấp", "Thông báo");
            }
        }

        
        private void suaDuLieuTrongDB(string maNCC, string tenNCC, string sDT, string diaChi)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblNCC SET sTenNCC = @TenNCC, sSDT = @SDT, sDiaChi = @DiaChi WHERE sMaNCC = @MaNCC", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@SDT", sDT);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblNCC SET bttXoa = 1 WHERE sMaNCC = @MaNCC", cnn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sqlText = $"SELECT sMaNCC, sTenNCC, sSDT, sDiaChi FROM tblNCC WHERE bttXoa = 0 AND sTenNCC LIKE N'%{txtTenNCC.Text.Trim()}%' AND sSDT LIKE '%{txtSDT.Text.Trim()}%' AND sDiaChi LIKE N'%{txtDiaChi.Text.Trim()}%' AND sMaNCC LIKE '%{txtMaNCC.Text.Trim()}%'";
            DataTable dt = clXuLy.Lay_DataTable(sqlText, "tblNCC");
            dgrNCC.DataSource = dt;
            // Hiển thị thông báo với số lượng kết quả tìm kiếm
            MessageBox.Show("Tìm thấy " + dt.Rows.Count + " nhà cung cấp " , "Thông báo");
            reset();
        }
    }
}
