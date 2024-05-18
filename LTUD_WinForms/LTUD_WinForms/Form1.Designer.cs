namespace LTUD_WinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.solveButton = new System.Windows.Forms.Button();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Set background image for the form
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "D:\\Code\\C#\\LTUD_WinForms\\LTUD_WinForms\\2.jpg");
            this.BackgroundImage = Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Set transparent background for textboxes and labels
            this.textBoxA.BackColor = System.Drawing.Color.Transparent;
            this.textBoxA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxB.BackColor = System.Drawing.Color.Transparent;
            this.textBoxB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxC.BackColor = System.Drawing.Color.Transparent;
            this.textBoxC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.resultLabel.BackColor = System.Drawing.Color.Transparent;

            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxC);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.solveButton);
            this.Name = "MainForm";
            this.Text = "Giải Phương Trình Bậc 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label resultLabel;
    }
}
