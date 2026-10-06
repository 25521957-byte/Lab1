using System;
using System.Windows.Forms;

namespace Lab01_CsharpBasic
{
    public partial class FormBai1 : Form
    {
        // Minimal control declarations to satisfy references from event handlers
        private TextBox txtSo1;
        private TextBox txtSo2;
        private TextBox txtSo3;
        private TextBox txtMax;
        private TextBox txtMin;
        private Button btnTim;
        private Button btnXoa;
        private Button btnThoat;

        private void InitializeComponent()
        {
            this.txtSo1 = new TextBox();
            this.txtSo2 = new TextBox();
            this.txtSo3 = new TextBox();
            this.txtMax = new TextBox();
            this.txtMin = new TextBox();
            this.btnTim = new Button();
            this.btnXoa = new Button();
            this.btnThoat = new Button();

            var lblSo1 = new Label { AutoSize = true, Location = new System.Drawing.Point(35, 38), Text = "Số thứ nhất:" };
            var lblSo2 = new Label { AutoSize = true, Location = new System.Drawing.Point(35, 83), Text = "Số thứ hai:" };
            var lblSo3 = new Label { AutoSize = true, Location = new System.Drawing.Point(35, 128), Text = "Số thứ ba:" };
            var lblMax = new Label { AutoSize = true, Location = new System.Drawing.Point(35, 198), Text = "Số lớn nhất:" };
            var lblMin = new Label { AutoSize = true, Location = new System.Drawing.Point(35, 243), Text = "Số nhỏ nhất:" };

            this.txtSo1.Location = new System.Drawing.Point(145, 35);
            this.txtSo2.Location = new System.Drawing.Point(145, 80);
            this.txtSo3.Location = new System.Drawing.Point(145, 125);
            this.txtMax.Location = new System.Drawing.Point(145, 195);
            this.txtMin.Location = new System.Drawing.Point(145, 240);
            this.txtSo1.Size = new System.Drawing.Size(240, 23);
            this.txtSo2.Size = new System.Drawing.Size(240, 23);
            this.txtSo3.Size = new System.Drawing.Size(240, 23);
            this.txtMax.Size = new System.Drawing.Size(240, 23);
            this.txtMin.Size = new System.Drawing.Size(240, 23);
            this.txtMax.ReadOnly = true;
            this.txtMin.ReadOnly = true;

            this.btnTim.Location = new System.Drawing.Point(35, 295);
            this.btnTim.Size = new System.Drawing.Size(110, 34);
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += btnTim_Click;
            this.btnXoa.Location = new System.Drawing.Point(160, 295);
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += btnXoa_Click;
            this.btnThoat.Location = new System.Drawing.Point(285, 295);
            this.btnThoat.Size = new System.Drawing.Size(100, 34);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += btnThoat_Click;

            this.ClientSize = new System.Drawing.Size(430, 360);
            this.Controls.AddRange(new Control[]
            {
                lblSo1, lblSo2, lblSo3, lblMax, lblMin,
                this.txtSo1, this.txtSo2, this.txtSo3, this.txtMax, this.txtMin,
                this.btnTim, this.btnXoa, this.btnThoat
            });
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Bài 1 - Tìm số lớn nhất và nhỏ nhất";
        }

        public FormBai1()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Kiểm tra ràng buộc dữ liệu đầu vào
            if (!double.TryParse(txtSo1.Text, out double num1) ||
                !double.TryParse(txtSo2.Text, out double num2) ||
                !double.TryParse(txtSo3.Text, out double num3))
            {
                MessageBox.Show("Vui lòng nhập vào các số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tìm số lớn nhất
            double max = num1;
            if (num2 > max) max = num2;
            if (num3 > max) max = num3;

            // Tìm số nhỏ nhất
            double min = num1;
            if (num2 < min) min = num2;
            if (num3 < min) min = num3;

            // Hiển thị kết quả
            txtMax.Text = max.ToString();
            txtMin.Text = min.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtSo1.Clear();
            txtSo2.Clear();
            txtSo3.Clear();
            txtMax.Clear();
            txtMin.Clear();
            txtSo1.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}