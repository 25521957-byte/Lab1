using System;
using System.Windows.Forms;

namespace Lab01_CsharpBasic
{
    public partial class FormBai2 : Form
    {
        // Minimal control declarations to satisfy references from event handlers
        private TextBox txtNhap;
        private TextBox txtKetQua;
        private Button btnDoc;
        private Button btnXoa;
        private Button btnThoat;

        private void InitializeComponent()
        {
            this.txtNhap = new TextBox();
            this.txtKetQua = new TextBox();
            this.btnDoc = new Button();
            this.btnXoa = new Button();
            this.btnThoat = new Button();

            var lblNhap = new Label { AutoSize = true, Location = new System.Drawing.Point(30, 32), Text = "Nhập số nguyên:" };
            var lblKetQua = new Label { AutoSize = true, Location = new System.Drawing.Point(30, 82), Text = "Kết quả:" };

            this.txtNhap.Location = new System.Drawing.Point(150, 29);
            this.txtNhap.Size = new System.Drawing.Size(340, 23);
            this.txtKetQua.Location = new System.Drawing.Point(150, 79);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.ScrollBars = ScrollBars.Vertical;
            this.txtKetQua.Size = new System.Drawing.Size(340, 80);

            this.btnDoc.Location = new System.Drawing.Point(150, 180);
            this.btnDoc.Size = new System.Drawing.Size(100, 34);
            this.btnDoc.Text = "Đọc số";
            this.btnDoc.Click += btnDoc_Click;
            this.btnXoa.Location = new System.Drawing.Point(270, 180);
            this.btnXoa.Size = new System.Drawing.Size(100, 34);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += btnXoa_Click;
            this.btnThoat.Location = new System.Drawing.Point(390, 180);
            this.btnThoat.Size = new System.Drawing.Size(100, 34);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += btnThoat_Click;

            this.AcceptButton = this.btnDoc;
            this.ClientSize = new System.Drawing.Size(530, 245);
            this.Controls.AddRange(new Control[]
            {
                lblNhap, lblKetQua, this.txtNhap, this.txtKetQua,
                this.btnDoc, this.btnXoa, this.btnThoat
            });
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Bài 2 - Đọc số";
        }

        public FormBai2()
        {
            InitializeComponent();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtNhap.Text, out long num))
            {
                MessageBox.Show("Vui lòng nhập vào số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu chỉ nhập từ 0 - 9 (yêu cầu cơ bản)[cite: 4]
            if (num >= 0 && num <= 9)
            {
                txtKetQua.Text = DocSoMotChuSo((int)num);
            }
            else // Nâng cao: Đọc số nhiều chữ số[cite: 4]
            {
                txtKetQua.Text = DocSoNhieuChuSo(num);
            }
        }

        // Hàm đọc 1 chữ số bằng switch-case[cite: 4]
        private string DocSoMotChuSo(int n)
        {
            switch (n)
            {
                case 0: return "Không";
                case 1: return "Một";
                case 2: return "Hai";
                case 3: return "Ba";
                case 4: return "Bốn";
                case 5: return "Năm";
                case 6: return "Sáu";
                case 7: return "Bảy";
                case 8: return "Tám";
                case 9: return "Chín";
                default: return "";
            }
        }

        // Thuật toán đọc số nguyên mở rộng (tối đa 12 chữ số)[cite: 4]
        private string DocSoNhieuChuSo(long number)
        {
            if (number == 0) return "Không";
            if (number < 0) return "Âm " + DocSoNhieuChuSo(Math.Abs(number));

            string[] units = { "", "nghìn", "triệu", "tỷ" };
            string result = "";
            int unitIndex = 0;

            while (number > 0)
            {
                int block = (int)(number % 1000);
                if (block > 0)
                {
                    string blockText = DocBlockBaChuSo(block, number >= 1000);
                    result = blockText + (units[unitIndex] != "" ? " " + units[unitIndex] : "") + " " + result;
                }
                number /= 1000;
                unitIndex++;
            }

            result = result.Trim();
            return char.ToUpper(result[0]) + result.Substring(1);
        }

        private string DocBlockBaChuSo(int number, bool hasHigherBlock)
        {
            int tram = number / 100;
            int chuc = (number % 100) / 10;
            int donVi = number % 10;
            string res = "";

            if (tram > 0 || hasHigherBlock)
                res += DocSoMotChuSo(tram) + " trăm ";

            if (chuc > 1)
            {
                res += DocSoMotChuSo(chuc) + " mươi ";
                if (donVi == 1) res += "mốt";
                else if (donVi == 5) res += "lăm";
                else if (donVi > 0) res += DocSoMotChuSo(donVi);
            }
            else if (chuc == 1)
            {
                res += "mười ";
                if (donVi == 5) res += "lăm";
                else if (donVi > 0) res += DocSoMotChuSo(donVi);
            }
            else
            {
                if (donVi > 0)
                {
                    if (tram > 0 || hasHigherBlock) res += "lẻ ";
                    res += DocSoMotChuSo(donVi);
                }
            }
            return res.Trim();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNhap.Clear();
            txtKetQua.Clear();
            txtNhap.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}