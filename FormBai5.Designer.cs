using System;
using System.Windows.Forms;

namespace Lab01_CsharpBasic
{
    public partial class FormBai5 : Form
    {
        private TextBox txtDisplay;
        private Button btnEqual;
        private Label lblExpression;

        private void InitializeComponent()
        {
            this.txtDisplay = new TextBox();
            this.lblExpression = new Label();

            string[,] keys =
            {
                { "7", "8", "9", "/" },
                { "4", "5", "6", "*" },
                { "1", "2", "3", "-" },
                { "0", ".", "C", "+" },
                { "CE", "=", "", "" }
            };

            this.lblExpression.Location = new System.Drawing.Point(20, 15);
            this.lblExpression.Size = new System.Drawing.Size(280, 22);
            this.lblExpression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtDisplay.Location = new System.Drawing.Point(20, 40);
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(280, 42);
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = HorizontalAlignment.Right;
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.Controls.Add(this.lblExpression);
            this.Controls.Add(this.txtDisplay);

            for (int row = 0; row < keys.GetLength(0); row++)
            {
                for (int column = 0; column < keys.GetLength(1); column++)
                {
                    string key = keys[row, column];
                    if (key.Length == 0)
                        continue;

                    var button = new Button();
                    button.Text = key;
                    button.Location = new System.Drawing.Point(20 + column * 72, 100 + row * 62);
                    button.Size = new System.Drawing.Size(64, 54);

                    if (key == "C")
                        button.Click += btnC_Click;
                    else if (key == "CE")
                        button.Click += btnCE_Click;
                    else if (key == "=")
                    {
                        this.btnEqual = button;
                        button.Click += btnEqual_Click;
                    }
                    else if (key == "." || char.IsDigit(key[0]))
                        button.Click += ButtonNum_Click;
                    else
                        button.Click += Operator_Click;

                    this.Controls.Add(button);
                }
            }

            this.AcceptButton = this.btnEqual;
            this.ClientSize = new System.Drawing.Size(320, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Bài 5 - Máy tính";
        }

        private double resultValue = 0;
        private string operationPerformed = "";
        private bool isOperationPerformed = false;

        public FormBai5()
        {
            InitializeComponent();
        }

        // Sự kiện click dùng chung cho các nút số (0-9) và dấu chấm '.'
        private void ButtonNum_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text += button.Text;
            }
            else
            {
                txtDisplay.Text += button.Text;
            }
        }

        // Sự kiện click cho các phép toán (+, -, *, /)
        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnEqual.PerformClick();
                operationPerformed = button.Text;
                lblExpression.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                double.TryParse(txtDisplay.Text, out resultValue);
                lblExpression.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        // Nút C (Clear All)
        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            lblExpression.Text = "";
        }

        // Nút CE (Clear Entry)
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        // Nút Bằng (=)
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtDisplay.Text, out double secondOperand))
                return;

            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + secondOperand).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - secondOperand).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * secondOperand).ToString();
                    break;
                case "/":
                    if (secondOperand != 0)
                        txtDisplay.Text = (resultValue / secondOperand).ToString();
                    else
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi chia 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }

            double.TryParse(txtDisplay.Text, out resultValue);
            operationPerformed = "";
            lblExpression.Text = "";
        }
    }
}