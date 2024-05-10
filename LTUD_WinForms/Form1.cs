using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LTUD_WinForms  
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            // Lấy các hệ số từ các TextBox
            double a, b, c;
            if (!double.TryParse(textBoxA.Text, out a) ||
                !double.TryParse(textBoxB.Text, out b) ||
                !double.TryParse(textBoxC.Text, out c))
            {
                MessageBox.Show("Vui lòng nhập các hệ số là số thực.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra hệ số a
            if (a == 0)
            {
                MessageBox.Show("Hệ số a phải khác 0.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính delta
            double delta = b * b - 4 * a * c;

            // Tính nghiệm
            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                resultLabel.Text = $"Nghiệm 1: {x1}, Nghiệm 2: {x2}";
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                resultLabel.Text = $"Nghiệm kép: {x}";
            }
            else
            {
                resultLabel.Text = "Phương trình không có nghiệm thực.";
            }
        }
    }
}
