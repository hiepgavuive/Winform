namespace Caro
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            f2cbbCheDo = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            txtPlayer1 = new TextBox();
            txtPlayer2 = new TextBox();
            txtIP = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(242, 258);
            label1.Name = "label1";
            label1.Size = new Size(200, 38);
            label1.TabIndex = 0;
            label1.Text = "Chọn chế độ";
            // 
            // f2cbbCheDo
            // 
            f2cbbCheDo.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            f2cbbCheDo.FormattingEnabled = true;
            f2cbbCheDo.Location = new Point(242, 320);
            f2cbbCheDo.Name = "f2cbbCheDo";
            f2cbbCheDo.Size = new Size(200, 30);
            f2cbbCheDo.TabIndex = 1;
            f2cbbCheDo.SelectedIndexChanged += f2cbbCheDo_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label2.Location = new Point(149, 380);
            label2.Name = "label2";
            label2.Size = new Size(161, 25);
            label2.TabIndex = 2;
            label2.Text = "Tên người chơi";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(242, 490);
            button1.Name = "button1";
            button1.Size = new Size(200, 55);
            button1.TabIndex = 4;
            button1.Text = "Bắt đầu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtPlayer1
            // 
            txtPlayer1.Font = new Font("Times New Roman", 10.2F);
            txtPlayer1.Location = new Point(149, 419);
            txtPlayer1.Name = "txtPlayer1";
            txtPlayer1.Size = new Size(164, 27);
            txtPlayer1.TabIndex = 5;
            // 
            // txtPlayer2
            // 
            txtPlayer2.Font = new Font("Times New Roman", 10.2F);
            txtPlayer2.Location = new Point(385, 420);
            txtPlayer2.Name = "txtPlayer2";
            txtPlayer2.Size = new Size(161, 27);
            txtPlayer2.TabIndex = 6;
            // 
            // txtIP
            // 
            txtIP.Font = new Font("Times New Roman", 10.2F);
            txtIP.Location = new Point(385, 420);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(161, 27);
            txtIP.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label3.Location = new Point(407, 380);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 8;
            label3.Text = "Địa chỉ IP";
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(669, 202);
            panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(670, 202);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 601);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(txtIP);
            Controls.Add(txtPlayer2);
            Controls.Add(txtPlayer1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(f2cbbCheDo);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Caro";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox f2cbbCheDo;
        private Label label2;
        private Button button1;
        private TextBox txtPlayer1;
        private TextBox txtPlayer2;
        private TextBox txtIP;
        private Label label3;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}