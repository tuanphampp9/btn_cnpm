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
    public partial class frmQLLoaiSanPham : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db_BanTrangSuc"].ConnectionString;
        clXuLyData clXuLy = new clXuLyData();
        public frmQLLoaiSanPham()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgr_load();
            dgrLoaiSP.ClearSelection();
            
        }

        private void reset()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtMaLoai.Enabled = true;
            errorProvider1.SetError(txtMaLoai, "");
            errorProvider1.SetError(txtTenLoai, "");
            dgr_load();
            dgrLoaiSP.ClearSelection();
        }

        private void dgr_load()
        {
            string sqlText = "SELECT sMaLoaiSP, sTenLoai FROM tblLoaiSanPham WHERE bttXoa = 0";
            DataTable tb = clXuLy.Lay_DataTable(sqlText,"tblLoaiSP");
            dgrLoaiSP.DataSource = tb;
            dgrLoaiSP.Columns["sMaLoaiSP"].HeaderText = "Mã loại SP";
            dgrLoaiSP.Columns["sTenLoai"].HeaderText = "Tên loại SP";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void dgrLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrLoaiSP.Rows[e.RowIndex];
                txtMaLoai.Text = row.Cells["sMaLoaiSP"].Value.ToString();
                txtTenLoai.Text = row.Cells["sTenLoai"].Value.ToString();
            }

            txtTenLoai.Enabled = true;
            txtMaLoai.Enabled = false;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void ThemDuLieuVaoDB(string maLoaiSP, string tenLoaiSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblLoaiSanPham (sMaLoaiSP, sTenLoai) VALUES (@MaLoaiSP, @TenLoaiSP)", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                    cmd.Parameters.AddWithValue("@TenLoaiSP", tenLoaiSP);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Xử lý
            string maLoaiSP = txtMaLoai.Text;
            string tenLoaiSP = txtTenLoai.Text;
            if(maLoaiSP=="" || tenLoaiSP == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (clXuLy.ktDuLieu_VarCharTonTai("tblLoaiSanPham","sMaLoaiSP",maLoaiSP))
            {
                MessageBox.Show("Mã loại sản phẩm đã tồn tại, vui lòng nhập mã mới", "Thông báo");
            }
            else if (clXuLy.ktDuLieu_NVarCharTonTai("tblLoaiSanPham", "sTenLoai", tenLoaiSP))
            {
                MessageBox.Show("Tên loại sản phẩm đã tồn tại, vui lòng nhập tên mới", "Thông báo");
            }
            else
            {
                ThemDuLieuVaoDB(maLoaiSP, tenLoaiSP);

                reset();
                MessageBox.Show("Thêm thành công 1 loại sản phẩm", "Thông báo");
            }
        }

        /*private bool KiemTraTonTaiMaLoaiSP(string maLoaiSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLoaiSanPham WHERE sMaLoaiSP = @MaLoaiSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }*/

        private void txtMaLoai_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaLoai.Text == "")
            {
                errorProvider1.SetError(txtMaLoai, "Vui lòng nhập mã loại sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMaLoai, "");
            }
        }

        private void txtTenLoai_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenLoai.Text == "")
            {
                errorProvider1.SetError(txtTenLoai, "Vui lòng nhập tên loại sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenLoai, "");
            }
        }

        private void suaDuLieuTrongDB(string maLoaiSP, string tenLoaiSp)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblLoaiSanPham SET sTenLoai = @tenLoaiSP WHERE sMaLoaiSP = @maLoaiSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@maLoaiSP", maLoaiSP);
                    cmd.Parameters.AddWithValue("@tenLoaiSP", tenLoaiSp);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Xử lý
            string maLoai = txtMaLoai.Text;
            string tenLoai = txtTenLoai.Text;

            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập tên loại bạn muốn sửa");
            }
            else if (clXuLy.ktDuLieu_NVarCharTonTai("tblLoaiSanPham", "sTenLoai", tenLoai))
            {
                MessageBox.Show("Tên loại sản phẩm đã tồn tại, vui lòng nhập tên mới", "Thông báo");
            }
            else
            {
                suaDuLieuTrongDB(maLoai, tenLoai);
                reset();
            }
        }

        

        private void btnTim_Click(object sender, EventArgs e)
        {
            //Xử lý
            string tenLoai = txtTenLoai.Text.Trim();
            string maLoai = txtMaLoai.Text.Trim();

            string sqlText = $"SELECT sMaLoaiSP, sTenLoai FROM tblLoaiSanPham WHERE bttXoa = 0 AND sTenLoai LIKE N'%{tenLoai}%' AND sMaLoaiSP LIKE '%{maLoai}%'";
            DataTable dt = clXuLy.Lay_DataTable(sqlText, "tblLoaiSP");
            dgrLoaiSP.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                
                // Hiển thị thông báo với số lượng kết quả tìm kiếm
                MessageBox.Show("Tìm thấy " + dt.Rows.Count + " loại sản phẩm ", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblLoaiSanPham SET bttXoa = 1 WHERE sMaLoaiSP = @MaLoaiSP", cnn))
                    {
                        cmd.Parameters.AddWithValue("@MaLoaiSP", maLoai);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                reset();
            }
        }
    }
}
