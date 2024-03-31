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
    public partial class frmQLSanPham : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db_BanTrangSuc"].ConnectionString;
        private bool allowEmptyTenSP = false;
        clXuLyData clXuLy = new clXuLyData();
        public frmQLSanPham()
        {
            InitializeComponent();
        }
        private void reset()
        {
            errorProvider1.SetError(txtMaSP, "");
            errorProvider1.SetError(txtTenSP, "");
            errorProvider1.SetError(txtSoLuong, "");
            errorProvider1.SetError(txtMauSac, "");
            errorProvider1.SetError(txtNguyenLieuChinh, "");
            errorProvider1.SetError(txtChatLieu, "");
            errorProvider1.SetError(txtDoDai, "");

            txtMaSP.Text = "";
            txtMaSP.Enabled = true;
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtMauSac.Text = "";
            txtNguyenLieuChinh.Text = "";
            txtChatLieu.Text = "";
            txtDoDai.Text = "";
            cboLoaiSP.Text = "";
            cboNCC.Text = "";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgr_load();
            dgrSanPham.ClearSelection();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgr_load();
            dgrSanPham.ClearSelection();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            clXuLy.loadCbb(clXuLy.Lay_DataTable("SELECT * FROM tblLoaiSanPham WHERE bttXoa = 0", "tblLoaiSP"), cboLoaiSP);
            cboLoaiSP.Text = "";
            clXuLy.loadCbb(clXuLy.Lay_DataTable("SELECT * FROM tblNCC WHERE bttXoa = 0", "tblNCC"), cboNCC);
            cboNCC.Text = "";
        }

        private void dgr_load()
        {
            string sqlText = "SELECT sMaSP, sTenSP, sTenLoai, iSoLuong, sMauSac, sChatLieu, sNguyenLieuChinh, fDoDai, sTenNCC FROM vv_SanPham2";
            DataTable dt = clXuLy.Lay_DataTable(sqlText, "tblSanPham");
            dgrSanPham.DataSource = dt;
            dgrSanPham.Columns["sMaSP"].HeaderText = "Mã sản phẩm";
            dgrSanPham.Columns["sTenSP"].HeaderText = "Tên sản phẩm";
            dgrSanPham.Columns["sTenLoai"].HeaderText = "Tên loại sản phẩm";
            dgrSanPham.Columns["iSoLuong"].HeaderText = "Số lượng";
            dgrSanPham.Columns["sMauSac"].HeaderText = "Màu sắc";
            dgrSanPham.Columns["sChatLieu"].HeaderText = "Chất liệu";
            dgrSanPham.Columns["sNguyenLieuChinh"].HeaderText = "Nguyên liệu chính";
            dgrSanPham.Columns["fDoDai"].HeaderText = "Độ dài";
            dgrSanPham.Columns["sTenNCC"].HeaderText = "Tên nhà cung cấp";
        }
        private void dgrSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrSanPham.Rows[e.RowIndex];

                txtMaSP.Text = row.Cells["sMaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["sTenSP"].Value.ToString();
                cboLoaiSP.Text = row.Cells["sTenLoai"].Value.ToString();
                txtSoLuong.Text = row.Cells["iSoLuong"].Value.ToString();
                txtMauSac.Text = row.Cells["sMauSac"].Value.ToString();
                txtNguyenLieuChinh.Text = row.Cells["sNguyenLieuChinh"].Value.ToString();
                txtChatLieu.Text = row.Cells["sChatLieu"].Value.ToString();
                txtDoDai.Text = row.Cells["fDoDai"].Value.ToString();
                cboNCC.Text = row.Cells["sTenNCC"].Value.ToString();
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaSP.Enabled = false;

            errorProvider1.SetError(txtMaSP, "");
            errorProvider1.SetError(txtTenSP, "");
            errorProvider1.SetError(txtSoLuong, "");
            errorProvider1.SetError(txtMauSac, "");
            errorProvider1.SetError(txtNguyenLieuChinh, "");
            errorProvider1.SetError(txtChatLieu, "");
            errorProvider1.SetError(txtDoDai, "");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Xử lý
            string maSP = txtMaSP.Text;
            string maLoaiSP = cboLoaiSP.SelectedValue.ToString();
            string tenSP = txtTenSP.Text;
            string soLuong = txtSoLuong.Text;
            string mauSac = txtMauSac.Text;
            string chatLieu = txtChatLieu.Text;
            string nguyenLieuChinh = txtNguyenLieuChinh.Text;
            string doDai = txtDoDai.Text;
            string maNCC = cboNCC.SelectedValue.ToString();

            if (maLoaiSP=="" || tenSP == "" || soLuong == "" || mauSac == "" || chatLieu == "" || nguyenLieuChinh == "" || doDai == "" || maNCC == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (clXuLy.ktDuLieu_VarCharTonTai("tblSanPham","sMaSP",maSP))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại, vui lòng nhập mã mới", "Thông báo");
            }
            else if (clXuLy.ktDuLieu_NVarCharTonTai("tblSanPham", "sTenSP", tenSP))
            {
                MessageBox.Show("Tên sản phẩm đã tồn tại, vui lòng nhập tên mới", "Thông báo");
            }
            else
            {
                ThemDuLieuVaoDB(maSP, tenSP, maLoaiSP, int.Parse(soLuong), mauSac, chatLieu, nguyenLieuChinh, doDai, maNCC);

                reset();
                MessageBox.Show("Bạn vừa thêm thành công 1 sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void txtMaSP_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                errorProvider1.SetError(txtMaSP, "Vui lòng nhập mã sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMaSP, "");
            }
        }

        private void txtTenSP_Validating(object sender, CancelEventArgs e)
        {
            if (!allowEmptyTenSP && txtTenSP.Text == "")
            {
                errorProvider1.SetError(txtTenSP, "Vui lòng nhập tên sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenSP, "");
            }
        }

        private void txtSoLuong_Validating(object sender, CancelEventArgs e)
        {
            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong))
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng sản phẩm.");
            }
            else
            {
                errorProvider1.SetError(txtSoLuong, "");
            }
        }

        private void txtMauSac_Validating(object sender, CancelEventArgs e)
        {
            if (txtMauSac.Text == "")
            {
                errorProvider1.SetError(txtMauSac, "Vui lòng nhập màu sắc");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMauSac, "");
            }
        }

        private void txtNguyenLieuChinh_Validating(object sender, CancelEventArgs e)
        {
            if (txtNguyenLieuChinh.Text == "")
            {
                errorProvider1.SetError(txtNguyenLieuChinh, "Vui lòng nhập nguyên liệu chính");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNguyenLieuChinh, "");
            }
        }

        private void txtChatLieu_Validating(object sender, CancelEventArgs e)
        {
            if (txtChatLieu.Text == "")
            {
                errorProvider1.SetError(txtChatLieu, "Vui lòng nhập chất liệu");
                return;
            }
            else
            {
                errorProvider1.SetError(txtChatLieu, "");
            }
        }

        private void txtDoDai_Validating(object sender, CancelEventArgs e)
        {
            if (txtDoDai.Text == "")
            {
                errorProvider1.SetError(txtDoDai, "Vui lòng nhập độ dài");
                return;
            }
            else
            {
                errorProvider1.SetError(txtDoDai, "");
            }
        }

        private void ThemDuLieuVaoDB(string maSP, string tenSP, string maLoaiSP, int soLuong, string mauSac, string chatLieu, string nguyenLieuChinh, string doDai, string maNCC)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblSanPham (sMaSP, sMaLoaiSP, sTenSP, iSoLuong, sMauSac, sChatLieu, sNguyenLieuChinh, fDoDai, sMaNCC) " +
                    "VALUES (@MaSP, @MaLoaiSP, @TenSP, @SoLuong, @MauSac, @ChatLieu, @NguyenLieuChinh, @DoDai, @MaNCC)", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@MauSac", mauSac);
                    cmd.Parameters.AddWithValue("@ChatLieu", chatLieu);
                    cmd.Parameters.AddWithValue("@NguyenLieuChinh", nguyenLieuChinh);
                    cmd.Parameters.AddWithValue("@DoDai", doDai);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            string maSP = txtMaSP.Text;
            string maLoaiSP = cboLoaiSP.SelectedValue.ToString();
            string tenSP = txtTenSP.Text;
            string soLuong = txtSoLuong.Text;
            string mauSac = txtMauSac.Text;
            string chatLieu = txtChatLieu.Text;
            string nguyenLieuChinh = txtNguyenLieuChinh.Text;
            string doDai = txtDoDai.Text;
            string maNCC = cboNCC.SelectedValue.ToString();

            if (maLoaiSP == "" || tenSP == "" || soLuong == "" || mauSac == "" || chatLieu == "" || nguyenLieuChinh == "" || doDai == "" || maNCC == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (KiemTraTonTaiTenSP2(maSP,tenSP))
            {
                MessageBox.Show("Tên sản phẩm đã tồn tại, vui lòng nhập tên mới", "Thông báo");
            }
            else
            {
                suaDuLieuTrongDB(maSP, tenSP, maLoaiSP,int.Parse( soLuong), mauSac, chatLieu, nguyenLieuChinh, doDai, maNCC);
                reset();
                
            }
        }

        private bool KiemTraTonTaiTenSP2(string maSP, string tenSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblSanPham WHERE sMaSP != @MaSP AND sTenSP = @TenSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void suaDuLieuTrongDB(string maSP, string tenSP, string maLoaiSP, int soLuong, string mauSac, string chatLieu, string nguyenLieuChinh, string doDai, string maNCC)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblSanPham SET sTenSP = @TenSP, sMaLoaiSP = @MaLoaiSP, iSoLuong = @SoLuong, sMauSac = @MauSac, sChatLieu = @ChatLieu, sNguyenLieuChinh = @NguyenLieuChinh, fDoDai = @DoDai, sMaNCC = @MaNCC WHERE sMaSP = @MaSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cmd.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@MauSac", mauSac);
                    cmd.Parameters.AddWithValue("@ChatLieu", chatLieu);
                    cmd.Parameters.AddWithValue("@NguyenLieuChinh", nguyenLieuChinh);
                    cmd.Parameters.AddWithValue("@DoDai", doDai);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblSanPham SET bttXoa = 1 WHERE sMaSP = @MaSP", cnn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", maSP);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reset();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //Xử lý
            
            String sqlText = "SELECT sMaSP, sTenSP, sTenLoai, iSoLuong, sMauSac, sChatLieu, sNguyenLieuChinh, fDoDai, sTenNCC FROM vv_SanPham2 " +
                              $"WHERE sMaSP LIKE '%{txtMaSP.Text.Trim()}%' AND  sTenLoai LIKE N'%{cboLoaiSP.Text.Trim()}%'  AND  sTenSP LIKE N'%{txtTenSP.Text.Trim()}%'  AND  sTenNCC LIKE N'%{cboNCC.Text.Trim()}%'";
            
            DataTable dt = clXuLy.Lay_DataTable(sqlText, "SanPham");
            dgrSanPham.DataSource = dt;

            MessageBox.Show("Tìm thấy " + dt.Rows.Count + " sản phẩm", "Thông báo");
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
             try
            {
                int.Parse(txtSoLuong.Text);
            }
            catch
            {
                errorProvider1.SetError(txtSoLuong, "Vui Lòng nhập số trong ô này");

                return;
            }
        
        }

        private void dgrSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
