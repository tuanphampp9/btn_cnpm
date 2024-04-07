using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_QLNhaTro
{
    public partial class frmChiTietPhong : Form
    {
        clXuLyData xuLyData =new clXuLyData();
        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;
        private int maPhong ;
        private string tinhTrang;
        public frmChiTietPhong(int maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;
        }
        private void frmCTHB_Ban_Load(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT sTenTaiSan,iSoLuong,sTinhTrang,sViTri FROM tblTaiSan WHERE FK_MaPhong = '" + maPhong + "'";
            dgvTaiSanPhong.DataSource = xuLyData.Lay_DataTable(sqlCommand,"tblTaiSan");

            sqlCommand = "SELECT * FROM tblPhong WHERE PK_MaPhong = '" + maPhong + "'";
            DataTable dataTable = xuLyData.Lay_DataTable(sqlCommand,"tblPhong");
            DataRow dataRow = dataTable.Rows[0];

            txtPhong.Text = dataRow["sTenPhong"].ToString();
            txtTang.Text = dataRow["iTang"].ToString();
            txtTienThue.Text = dataRow["fTienThu"].ToString();
            txtDienTich.Text = dataRow["fDienTich"].ToString();
            txtSoNguoi.Text = dataRow["iSoNguoiToiDa"].ToString();
            txtTinhTrang.Text = dataRow["sTinhTrang"].ToString();

            this.tinhTrang = dataRow["sTinhTrang"].ToString().Trim();
            btnThemKH.Text = this.tinhTrang == "Đã thuê" ? "Xóa khách hàng" : "Thêm khách hàng";
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if(this.tinhTrang == "Đã thuê")
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                      
                        cmd.Parameters.AddWithValue("@maPhong", this.maPhong);
                        cmd.CommandText = "prc_xoaKH_Phong";
                        DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng khỏi phòng trọ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();
                            cnn.Close();

                            if (i > 0)
                            {
                                MessageBox.Show("Xóa thành công");

                                frmChiTietPhong formCT = new frmChiTietPhong(this.maPhong);
                                this.Visible = false;
                                formCT.Show();
                            }
                            else
                            {
                                MessageBox.Show("Xóa không thành công. Vui lòng thử lại hoặc kiểm tra lại dữ liệu.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hủy bỏ xóa.");
                        }

                    }
                }

            }
            else
            {
                frmThemKH formThemKH = new frmThemKH(this.maPhong);
                this.Visible = false;
                formThemKH.Show();

            }
            
        }
    }
}
