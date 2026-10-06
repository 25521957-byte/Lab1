using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab01_CsharpBasic
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var menu = new FlowLayoutPanel();
            this.SuspendLayout();

            menu.AutoScroll = true;
            menu.Dock = DockStyle.Fill;
            menu.FlowDirection = FlowDirection.TopDown;
            menu.Padding = new Padding(24);
            menu.WrapContents = false;
            menu.Controls.Add(CreateMenuButton("Bài 1 - Tìm số lớn nhất và nhỏ nhất", btnBai01_Click));
            menu.Controls.Add(CreateMenuButton("Bài 2 - Đọc số", btnBai02_Click));
            menu.Controls.Add(CreateMenuButton("Bài 3 - Chuyển đổi tiền tệ", btnBai03_Click));
            menu.Controls.Add(CreateMenuButton("Bài 4 - Tính toán", btnBai04_Click));
            menu.Controls.Add(CreateMenuButton("Bài 5 - Máy tính", btnBai05_Click));

            this.ClientSize = new Size(800, 450);
            this.Name = "FormMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lab 1 - C# cơ bản";
            this.Controls.Add(menu);
            this.ResumeLayout(false);
        }

        private Button CreateMenuButton(string text, EventHandler clickHandler)
        {
            var button = new Button();
            button.Text = text;
            button.Width = 720;
            button.Height = 56;
            button.Margin = new Padding(0, 0, 0, 12);
            button.Click += clickHandler;
            return button;
        }

        private void btnBai01_Click(object sender, EventArgs e)
        {
            FormBai1 f1 = new FormBai1();
            f1.ShowDialog();
        }

        private void btnBai02_Click(object sender, EventArgs e)
        {
            FormBai2 f2 = new FormBai2();
            f2.ShowDialog();
        }

        private void btnBai03_Click(object sender, EventArgs e)
        {
            FormBai3 f3 = new FormBai3();
            f3.ShowDialog();
        }

        private void btnBai04_Click(object sender, EventArgs e)
        {
            FormBai4 f4 = new FormBai4();
            f4.ShowDialog();
        }

        private void btnBai05_Click(object sender, EventArgs e)
        {
            FormBai5 f5 = new FormBai5();
            f5.ShowDialog();
        }
    }
}