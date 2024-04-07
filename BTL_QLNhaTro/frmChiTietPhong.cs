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
        private string maPhong = "1";
        public frmChiTietPhong(string maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;
        }
        private void frmCTHB_Ban_Load(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT sTenTaiSan,iSoLuong,sTinhTrang,sViTri FROM tblTaiSan WHERE FK_MaPhong = '" + maPhong + "'";
            dgvTaiSanPhong.DataSource = xuLyData.Lay_DataTable(sqlCommand);

            sqlCommand = "SELECT * FROM tblPhong WHERE PK_MaPhong = '" + maPhong + "'";
            DataTable dataTable = xuLyData.Lay_DataTable(sqlCommand);
            DataRow dataRow = dataTable.Rows[0];

            if (!dataRow.IsNull(1))
            {
                txtPhong.Text = "Rỗng";
                txtTang.Text = "Rỗng";
                txtTienThue.Text = "Rỗng";
                txtDienTich.Text = "Rỗng";
                txtSoNguoi.Text = "Rỗng";
                txtTinhTrang.Text = "Rỗng";
            }
            txtPhong.Text = dataRow["sTenPhong"].ToString();
            txtTang.Text = dataRow["iTang"].ToString();
            txtTienThue.Text = dataRow["fTienThu"].ToString();
            txtDienTich.Text = dataRow["fDienTich"].ToString();
            txtSoNguoi.Text = dataRow["iSoNguoiToiDa"].ToString();
            txtTinhTrang.Text = dataRow["sTinhTrang"].ToString();

        }
    }
}
