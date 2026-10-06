using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab01_CsharpBasic
{
    public partial class FormBai3 : Form
    {
        // Minimal control declarations to satisfy references from event handlers
        private ComboBox cboTienGoc;
        private ComboBox cboTienDoi;
        private TextBox txtSoTien;
        private TextBox txtKetQua;
        private Label lblTyGia;
        private Button btnChuyenDoi;
        private Button btnThoat;

        private void InitializeComponent()
        {
            this.cboTienGoc = new ComboBox();
            this.cboTienDoi = new ComboBox();
            this.txtSoTien = new TextBox();
            this.txtKetQua = new TextBox();
            this.lblTyGia = new Label();
            this.btnChuyenDoi = new Button();
            this.btnThoat = new Button();

            var lblTienGoc = new Label { AutoSize = true, Location = new System.Drawing.Point(30, 35), Text = "Tiền gốc:" };
            var lblTienDoi = new Label { AutoSize = true, Location = new System.Drawing.Point(30, 80), Text = "Tiền cần đổi:" };
            var lblSoTien = new Label { AutoSize = true, Location = new System.Drawing.Point(30, 125), Text = "Số tiền:" };
            var lblKetQua = new Label { AutoSize = true, Location = new System.Drawing.Point(30, 170), Text = "Kết quả:" };

            this.cboTienGoc.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTienGoc.Location = new System.Drawing.Point(150, 32);
            this.cboTienGoc.Size = new System.Drawing.Size(400, 23);
            this.cboTienDoi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTienDoi.Location = new System.Drawing.Point(150, 77);
            this.cboTienDoi.Size = new System.Drawing.Size(400, 23);
            this.txtSoTien.Location = new System.Drawing.Point(150, 122);
            this.txtSoTien.Size = new System.Drawing.Size(400, 23);
            this.txtKetQua.Location = new System.Drawing.Point(150, 167);
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.Size = new System.Drawing.Size(400, 23);

            this.lblTyGia.AutoSize = false;
            this.lblTyGia.Location = new System.Drawing.Point(30, 215);
            this.lblTyGia.Size = new System.Drawing.Size(520, 40);

            this.btnChuyenDoi.Location = new System.Drawing.Point(330, 275);
            this.btnChuyenDoi.Size = new System.Drawing.Size(105, 34);
            this.btnChuyenDoi.Text = "Chuyển đổi";
            this.btnChuyenDoi.Click += btnChuyenDoi_Click;
            this.btnThoat.Location = new System.Drawing.Point(445, 275);
            this.btnThoat.Size = new System.Drawing.Size(105, 34);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += btnThoat_Click;

            this.ClientSize = new System.Drawing.Size(590, 335);
            this.Controls.AddRange(new Control[]
            {
                lblTienGoc, lblTienDoi, lblSoTien, lblKetQua,
                this.cboTienGoc, this.cboTienDoi, this.txtSoTien, this.txtKetQua,
                this.lblTyGia, this.btnChuyenDoi, this.btnThoat
            });
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Bài 3 - Chuyển đổi tiền tệ";
        }

        // Khai báo tỉ giá so với VND[cite: 4]
        private Dictionary<string, double> exchangeRates = new Dictionary<string, double>()
        {
            { "USD (Đô-la Mỹ)", 22772 },
            { "EUR (Euro)", 28132 },
            { "GBP (Bảng Anh)", 31538 },
            { "SGD (Đô-la Singapore)", 17286 },
            { "JPY (Yên Nhật)", 214 },
            { "VND (Việt Nam Đồng)", 1 }
        };

        public FormBai3()
        {
            InitializeComponent();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            foreach (var key in exchangeRates.Keys)
            {
                cboTienGoc.Items.Add(key);
                cboTienDoi.Items.Add(key);
            }
            cboTienGoc.SelectedIndex = 0; // USD
            cboTienDoi.SelectedIndex = 5; // VND
        }

        private void btnChuyenDoi_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtSoTien.Text, out double amount) || amount < 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sourceCurrency = cboTienGoc.SelectedItem.ToString();
            string targetCurrency = cboTienDoi.SelectedItem.ToString();

            double rateSource = exchangeRates[sourceCurrency];
            double rateTarget = exchangeRates[targetCurrency];

            // Quy đổi sang VND rồi quy đổi sang tiền mục tiêu
            double amountInVND = amount * rateSource;
            double result = amountInVND / rateTarget;

            txtKetQua.Text = result.ToString("N2"); // Định dạng số phân cách hàng nghìn
            lblTyGia.Text = $"Tỷ giá quy đổi: 1 {sourceCurrency.Split(' ')[0]} = {(rateSource / rateTarget):N2} {targetCurrency.Split(' ')[0]}";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}