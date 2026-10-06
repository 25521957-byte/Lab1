using System;
using System.Text;
using System.Windows.Forms;

namespace Lab01_CsharpBasic
{
    public partial class FormBai4 : Form
    {
        // Minimal control declarations to satisfy references from event handlers
        private TextBox txtA;
        private TextBox txtB;
        private RichTextBox rtbKetQua;
        private Button btnTinh;
        private Button btnXoa;
        private Button btnThoat;

        private void InitializeComponent()
        {
            this.txtA = new TextBox();
            this.txtB = new TextBox();
            this.rtbKetQua = new RichTextBox();
            this.btnTinh = new Button();
            this.btnXoa = new Button();
            this.btnThoat = new Button();

            var lblA = new Label { AutoSize = true, Location = new System.Drawing.Point(30, 32), Text = "Nhập A:" };
            var lblB = new Label { AutoSize = true, Location = new System.Drawing.Point(310, 32), Text = "Nhập B:" };
            var lblKetQua = new Label { AutoSize = true, Location = new System.Drawing.Point(30, 85), Text = "Kết quả:" };

            this.txtA.Location = new System.Drawing.Point(95, 29);
            this.txtA.Size = new System.Drawing.Size(180, 23);
            this.txtB.Location = new System.Drawing.Point(375, 29);
            this.txtB.Size = new System.Drawing.Size(180, 23);
            this.rtbKetQua.Location = new System.Drawing.Point(30, 110);
            this.rtbKetQua.ReadOnly = true;
            this.rtbKetQua.Size = new System.Drawing.Size(525, 245);

            this.btnTinh.Location = new System.Drawing.Point(255, 380);
            this.btnTinh.Size = new System.Drawing.Size(95, 34);
            this.btnTinh.Text = "Tính";
            this.btnTinh.Click += btnTinh_Click;
            this.btnXoa.Location = new System.Drawing.Point(360, 380);
            this.btnXoa.Size = new System.Drawing.Size(95, 34);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += btnXoa_Click;
            this.btnThoat.Location = new System.Drawing.Point(465, 380);
            this.btnThoat.Size = new System.Drawing.Size(90, 34);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += btnThoat_Click;

            this.AcceptButton = this.btnTinh;
            this.ClientSize = new System.Drawing.Size(590, 440);
            this.Controls.AddRange(new Control[]
            {
                lblA, lblB, lblKetQua, this.txtA, this.txtB, this.rtbKetQua,
                this.btnTinh, this.btnXoa, this.btnThoat
            });
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Bài 4 - Tính toán";
        }

        public FormBai4()
        {
            InitializeComponent();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtA.Text, out int A) || !int.TryParse(txtB.Text, out int B) || A < 0 || B < 0)
            {
                MessageBox.Show("Vui lòng nhập hai số nguyên không âm A và B!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính A! và B!
            long factA = TinhGiaiThua(A);
            long factB = TinhGiaiThua(B);

            // Tính S1 và S2
            long S1 = 0, S2 = 0;
            for (int i = 1; i <= A; i++) S1 += i;
            for (int i = 1; i <= B; i++) S2 += i;

            // Tính S3 = A^1 + A^2 + ... + A^B
            double S3 = 0;
            for (int i = 1; i <= B; i++)
            {
                S3 += Math.Pow(A, i);
            }

            // Hiển thị kết quả vào RichTextBox hoặc TextBox Multiline
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"A! = {factA:N0}");
            sb.AppendLine($"B! = {factB:N0}");
            sb.AppendLine($"S1 = 1 + 2 + ... + A = {S1:N0}");
            sb.AppendLine($"S2 = 1 + 2 + ... + B = {S2:N0}");
            sb.AppendLine($"S3 = A^1 + A^2 + ... + A^B = {S3:N0}");

            rtbKetQua.Text = sb.ToString();
        }

        private long TinhGiaiThua(int n)
        {
            long fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            rtbKetQua.Clear();
            txtA.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}