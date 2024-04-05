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
    public partial class frmToaNha : Form
    {
        clXuLyData commonFunction = new clXuLyData();
        int vitri = -1;
        public int userId;
        public int buildingId;
        public frmToaNha(int user_id)
        {
            this.userId = user_id;
            InitializeComponent();
        }
        string constr = ConfigurationManager.ConnectionStrings["db_QLNhaTro"].ConnectionString;
        private void loadDatagridview()
        {
            
            DataTable dt = commonFunction.Lay_DataTable($"select PK_MaToa, sTenToa, sDiaChi from tblToaNha where FK_User_id='{this.userId}'", "tblToaNha");
            dtgvToaNha.DataSource = dt;
            dtgvToaNha.Refresh();
        }
        public void r_form()
        {
            txtBuildingName.Text = "";
            txtAddress.Text = "";
        }
        public int addBuilding(string buildingName, string address, int userId)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string sqlInsert = $"insert into tblToaNha(sTenToa, sDiaChi, FK_User_id) values(N'{buildingName}',N'{address}', {userId})";
                    cmd.CommandText = sqlInsert;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text=="" || txtBuildingName.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tên toà nhà và địa chỉ để thêm");
            }    
            else
            {
                string buildingName = txtBuildingName.Text.ToString().Trim();
                string address = txtAddress.Text.ToString().Trim();
                int kq = addBuilding(buildingName, address, this.userId);
                if (kq > 0)
                {
                    dtgvToaNha.DataSource = commonFunction.Lay_DataTable($"select PK_MaToa, sTenToa, sDiaChi from tblToaNha where FK_User_id='{this.userId}'", "tblToaNha");
                    r_form();
                }
                else
                {
                    MessageBox.Show("Them khong thanh cong!");
                }
            }
                
        }

        public int editBuilding(int buildingId, string buildingName, string address)
        {

            string sqlUpdate = $"UPDATE tblToaNha SET sTenToa = N'{buildingName}', sDiaChi = N'{address}' WHERE PK_MaToa = {buildingId}";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlUpdate;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (vitri < 0)
            {
                MessageBox.Show("Bạn chưa chọn toà nhà cần sửa!");
                return;
            }
            string buildingName = txtBuildingName.Text.ToString().Trim();
            string address = txtAddress.Text.ToString().Trim();

            int kq = editBuilding(this.buildingId, buildingName, address);
            if (kq < 0)
            {
                MessageBox.Show("Sửa không thành công!");
                return;
            }
            dtgvToaNha.DataSource = commonFunction.Lay_DataTable($"select PK_MaToa, sTenToa, sDiaChi from tblToaNha where FK_User_id='{this.userId}'", "tblToaNha");
            r_form();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sqlCommand = "";
            if (txtBuildingName.Text.ToString().Trim().Length != 0)
            {
                sqlCommand = $"select PK_MaToa, sTenToa, sDiaChi from tblToaNha where FK_User_id='{this.userId}' and sTenToa LIKE N'%" + txtBuildingName.Text.ToString().Trim() + "%'";
            }
            dtgvToaNha.DataSource = commonFunction.Lay_DataTable(sqlCommand, "tblToaNha");
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            r_form();
            string sqlCommand = $"select PK_MaToa, sTenToa, sDiaChi from tblToaNha where FK_User_id='{this.userId}'";
            dtgvToaNha.DataSource = commonFunction.Lay_DataTable(sqlCommand, "tblToaNha");
        }

        private void frmToaNha_Load(object sender, EventArgs e)
        {
            loadDatagridview();
        }

        private void dtgvToaNha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            DataTable dt = commonFunction.Lay_DataTable($"select PK_MaToa, sTenToa, sDiaChi from tblToaNha where FK_User_id='{this.userId}'", "tblToaNha");
            DataRow row = dt.Rows[vitri];
            this.buildingId = int.Parse(row[0].ToString().Trim());
            txtBuildingName.Text = row[1].ToString().Trim();
            txtAddress.Text = row[2].ToString().Trim();
            errorProvider1.Clear();
        }
    }
}
