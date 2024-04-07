using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace BTL_QLNhaTro
{
    public partial class frmChiTietPhong : Form
    {
        clXuLyData xuLyData =new clXuLyData();
        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;
        private int maPhong ;
        private string maNguoiT;
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
            maNguoiT= dataRow["FK_User_id"].ToString();

        }

        private void btnTaiSan_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            string sqlCommand = "SELECT sTenTaiSan,iSoLuong,sTinhTrang,sViTri FROM tblTaiSan WHERE FK_MaPhong = '" + maPhong + "'";
            dgvTaiSanPhong.DataSource = xuLyData.Lay_DataTable(sqlCommand, "tblTaiSan");

        }

        private void btnNguoiThue_Click(object sender, EventArgs e)
        {
            if(maNguoiT != "")
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                string sqlCommand = "SELECT * FROM tblKhachHang WHERE PK_Id = " + maNguoiT ;
                dgvNguoiThue.DataSource = xuLyData.Lay_DataTable(sqlCommand, "tblKhachHang");
            }
            else
            {
                MessageBox.Show("Phong chưa có ai thuê");
            }
        }
    }
}
