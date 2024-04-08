
namespace BTL_QLNhaTro
{
    partial class frmQLPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTinhTrang = new System.Windows.Forms.ComboBox();
            this.cbxToaNha = new System.Windows.Forms.ComboBox();
            this.txtTienThue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoNguoi = new System.Windows.Forms.TextBox();
            this.txtDienTich = new System.Windows.Forms.TextBox();
            this.txtTang = new System.Windows.Forms.TextBox();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clMaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clToaNha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTienThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDienTich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoNguoiToiDa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clChiTiet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clMaChuToa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eprQLPhong = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eprQLPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(652, 199);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 29);
            this.btnTim.TabIndex = 82;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(470, 199);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 29);
            this.btnLamMoi.TabIndex = 81;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(105, 199);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(81, 29);
            this.btnSua.TabIndex = 79;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(293, 199);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(70, 29);
            this.btnThem.TabIndex = 78;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 24);
            this.label1.TabIndex = 77;
            this.label1.Text = "Quản lý phòng trọ";
            // 
            // cbxTinhTrang
            // 
            this.cbxTinhTrang.FormattingEnabled = true;
            this.cbxTinhTrang.Items.AddRange(new object[] {
            "Đã thuê",
            "Còn trống"});
            this.cbxTinhTrang.Location = new System.Drawing.Point(533, 89);
            this.cbxTinhTrang.Name = "cbxTinhTrang";
            this.cbxTinhTrang.Size = new System.Drawing.Size(121, 21);
            this.cbxTinhTrang.TabIndex = 76;
            // 
            // cbxToaNha
            // 
            this.cbxToaNha.FormattingEnabled = true;
            this.cbxToaNha.Location = new System.Drawing.Point(533, 62);
            this.cbxToaNha.Name = "cbxToaNha";
            this.cbxToaNha.Size = new System.Drawing.Size(121, 21);
            this.cbxToaNha.TabIndex = 75;
            // 
            // txtTienThue
            // 
            this.txtTienThue.Location = new System.Drawing.Point(216, 156);
            this.txtTienThue.Name = "txtTienThue";
            this.txtTienThue.Size = new System.Drawing.Size(100, 20);
            this.txtTienThue.TabIndex = 74;
            this.txtTienThue.TextChanged += new System.EventHandler(this.txtTienThue_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Tiên thuê: ";
            // 
            // txtSoNguoi
            // 
            this.txtSoNguoi.Location = new System.Drawing.Point(533, 151);
            this.txtSoNguoi.Name = "txtSoNguoi";
            this.txtSoNguoi.Size = new System.Drawing.Size(100, 20);
            this.txtSoNguoi.TabIndex = 72;
            this.txtSoNguoi.TextChanged += new System.EventHandler(this.txtSoNguoi_TextChanged);
            // 
            // txtDienTich
            // 
            this.txtDienTich.Location = new System.Drawing.Point(533, 120);
            this.txtDienTich.Name = "txtDienTich";
            this.txtDienTich.Size = new System.Drawing.Size(100, 20);
            this.txtDienTich.TabIndex = 71;
            this.txtDienTich.TextChanged += new System.EventHandler(this.txtDienTich_TextChanged);
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(216, 126);
            this.txtTang.Name = "txtTang";
            this.txtTang.Size = new System.Drawing.Size(100, 20);
            this.txtTang.TabIndex = 70;
            this.txtTang.TextChanged += new System.EventHandler(this.txtTang_TextChanged);
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(216, 97);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(100, 20);
            this.txtPhong.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Tình trạng: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Số người tối đa: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Diện tích: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Tầng: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(142, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "Phòng: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(434, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Tào nhà: ";
            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaPhong,
            this.clTenPhong,
            this.clToaNha,
            this.clTang,
            this.clTienThu,
            this.clDienTich,
            this.clSoNguoiToiDa,
            this.clTinhTrang,
            this.clChiTiet,
            this.clMaChuToa});
            this.dgvPhong.GridColor = System.Drawing.SystemColors.Control;
            this.dgvPhong.Location = new System.Drawing.Point(12, 251);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.Size = new System.Drawing.Size(776, 175);
            this.dgvPhong.TabIndex = 62;
            this.dgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellClick);
            this.dgvPhong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellContentClick);
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(216, 65);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.ReadOnly = true;
            this.txtMaPhong.Size = new System.Drawing.Size(100, 20);
            this.txtMaPhong.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Mã phòng: ";
            // 
            // clMaPhong
            // 
            this.clMaPhong.DataPropertyName = "PK_MaPhong";
            this.clMaPhong.FillWeight = 80F;
            this.clMaPhong.HeaderText = "Mã Phòng";
            this.clMaPhong.Name = "clMaPhong";
            this.clMaPhong.ReadOnly = true;
            // 
            // clTenPhong
            // 
            this.clTenPhong.DataPropertyName = "sTenPhong";
            this.clTenPhong.HeaderText = "Tên phòng";
            this.clTenPhong.Name = "clTenPhong";
            this.clTenPhong.ReadOnly = true;
            // 
            // clToaNha
            // 
            this.clToaNha.DataPropertyName = "sTenToa";
            this.clToaNha.HeaderText = "Toà nhà";
            this.clToaNha.Name = "clToaNha";
            this.clToaNha.ReadOnly = true;
            // 
            // clTang
            // 
            this.clTang.DataPropertyName = "iTang";
            this.clTang.FillWeight = 60F;
            this.clTang.HeaderText = "Tầng";
            this.clTang.Name = "clTang";
            this.clTang.ReadOnly = true;
            // 
            // clTienThu
            // 
            this.clTienThu.DataPropertyName = "fTienThu";
            this.clTienThu.HeaderText = "Tiên thu";
            this.clTienThu.Name = "clTienThu";
            this.clTienThu.ReadOnly = true;
            // 
            // clDienTich
            // 
            this.clDienTich.DataPropertyName = "fDienTich";
            this.clDienTich.FillWeight = 70F;
            this.clDienTich.HeaderText = "Diện tích";
            this.clDienTich.Name = "clDienTich";
            this.clDienTich.ReadOnly = true;
            // 
            // clSoNguoiToiDa
            // 
            this.clSoNguoiToiDa.DataPropertyName = "iSoNguoiToiDa";
            this.clSoNguoiToiDa.HeaderText = "Số người tối đa";
            this.clSoNguoiToiDa.Name = "clSoNguoiToiDa";
            this.clSoNguoiToiDa.ReadOnly = true;
            // 
            // clTinhTrang
            // 
            this.clTinhTrang.DataPropertyName = "sTinhTrang";
            this.clTinhTrang.HeaderText = "Tình trạng";
            this.clTinhTrang.Name = "clTinhTrang";
            this.clTinhTrang.ReadOnly = true;
            // 
            // clChiTiet
            // 
            this.clChiTiet.FillWeight = 60F;
            this.clChiTiet.HeaderText = "Chi tiết";
            this.clChiTiet.Name = "clChiTiet";
            this.clChiTiet.ReadOnly = true;
            this.clChiTiet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clChiTiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clChiTiet.Text = "Xem";
            // 
            // clMaChuToa
            // 
            this.clMaChuToa.DataPropertyName = "FK_User_id";
            this.clMaChuToa.HeaderText = "MaChuToa";
            this.clMaChuToa.Name = "clMaChuToa";
            this.clMaChuToa.ReadOnly = true;
            this.clMaChuToa.Visible = false;
            // 
            // eprQLPhong
            // 
            this.eprQLPhong.ContainerControl = this;
            // 
            // frmQLPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTinhTrang);
            this.Controls.Add(this.cbxToaNha);
            this.Controls.Add(this.txtTienThue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSoNguoi);
            this.Controls.Add(this.txtDienTich);
            this.Controls.Add(this.txtTang);
            this.Controls.Add(this.txtPhong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvPhong);
            this.Name = "frmQLPhong";
            this.Text = "frmQLPhong";
            this.Load += new System.EventHandler(this.frmQLPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eprQLPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTinhTrang;
        private System.Windows.Forms.ComboBox cbxToaNha;
        private System.Windows.Forms.TextBox txtTienThue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoNguoi;
        private System.Windows.Forms.TextBox txtDienTich;
        private System.Windows.Forms.TextBox txtTang;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clToaNha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTienThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDienTich;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSoNguoiToiDa;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTinhTrang;
        private System.Windows.Forms.DataGridViewButtonColumn clChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaChuToa;
        private System.Windows.Forms.ErrorProvider eprQLPhong;
    }
}