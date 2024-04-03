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
    public partial class frmInfoUser : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;
        clXuLyData commonFunction = new clXuLyData();
        public int userId;
        public string sVaiTro;
        public frmInfoUser(int userId, string sVaiTro)
        {
            this.userId = userId;
            this.sVaiTro = sVaiTro;
            InitializeComponent();
        }

        private void frmInfoUser_Load(object sender, EventArgs e)
        {
            if(sVaiTro=="Chu tro")
            {
                string sqlQuery = $"select tblChuToa.* from tblNguoiDung inner join tblChuToa on tblNguoiDung.FK_ChuToa_id = tblChuToa.PK_Id where PK_Id = {this.userId}";
                handleGetInfo(sqlQuery);
            }else if(sVaiTro=="Khách thuê")
            {
                string sqlQuery = $"select tblKhachHang.* from tblNguoiDung inner join tblKhachHang on tblNguoiDung.FK_KhachHang_id = tblKhachHang.PK_Id where PK_Id = {this.userId}";
                handleGetInfo(sqlQuery);
            }
            
        }
        public void handleGetInfo(string sqlQuery)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    DataTable dt = commonFunction.Lay_DataTable(sqlQuery, "tblInfoUser");
                    DataRow row = dt.Rows[0];
                    txtEmail.Text = row[1].ToString().Trim();
                    txtFullName.Text = row[3].ToString().Trim();
                    txtPhoneNumber.Text = row[2].ToString().Trim();
                    dtpDOB.Value = DateTime.Parse(row[4].ToString().Trim());
                    string gender = row[5].ToString().Trim();
                    if (gender == "True")
                    {
                        rdoMale.Checked = true;
                        rdoFemale.Checked = false;
                    }
                    else
                    {
                        rdoFemale.Checked = true;
                        rdoMale.Checked = false;
                    }
                }
            }
        }
    }
}
