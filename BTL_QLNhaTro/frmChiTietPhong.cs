using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLNhaTro
{
    public partial class frmChiTietPhong : Form
    {
        clXuLyData xuLyData;
        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;
        private string maPhong="1";
        public frmChiTietPhong(string maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;
        }
        private void frmCTHB_Ban_Load(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT sTenTaiSan,iSoLuong,sTinhTrang,sViTri FROM tblTaiSan WHERE FK_MaPhong = '" + maPhong + "'";
            dgvTaiSanPhong.DataSource = xuLyData.Lay_DataTable(sqlCommand);

            sqlCommand = "SELECT * FROM tblPhong WHERE FK_MaPhong = '" + maPhong + "'";
            DataTable dataTable = xuLyData.Lay_DataTable(sqlCommand);
            DataRow dataRow = dataTable.Rows[0];
            
            txtPhong.Text = dataRow["sTenPhong"].ToString();
            txtTang.Text = dataRow["iTang"].ToString();
            txtTienThue.Text = dataRow["fTienThu"].ToString();
            txtDienTich.Text = dataRow["fDienTich"].ToString();
            txtSoNguoi.Text = dataRow["iSoNguoiToiDa"].ToString();
            txtTinhTrang.Text = dataRow["sTinhTrang"].ToString();

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
