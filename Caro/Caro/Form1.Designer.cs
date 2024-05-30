namespace Caro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            BanCoXO = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            pbPlay = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            prbThoiGian = new ProgressBar();
            txbTenPlay = new TextBox();
            timer = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem1 = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPlay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(909, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(388, 332);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(3, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(382, 320);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // BanCoXO
            // 
            BanCoXO.BackColor = SystemColors.ControlLightLight;
            BanCoXO.Location = new Point(12, 31);
            BanCoXO.Name = "BanCoXO";
            BanCoXO.Size = new Size(874, 603);
            BanCoXO.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(pbPlay);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(prbThoiGian);
            panel3.Controls.Add(txbTenPlay);
            panel3.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel3.Location = new Point(909, 369);
            panel3.Name = "panel3";
            panel3.Size = new Size(388, 265);
            panel3.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F);
            label2.Location = new Point(32, 186);
            label2.Name = "label2";
            label2.Size = new Size(334, 48);
            label2.TabIndex = 9;
            label2.Text = "Bên nào có 5 con thẳng hàng ngang, thẳng, \r\nchéo, trước thì thắng\r\n";
            label2.UseMnemonic = false;
            // 
            // pbPlay
            // 
            pbPlay.Location = new Point(199, 15);
            pbPlay.Name = "pbPlay";
            pbPlay.Size = new Size(167, 124);
            pbPlay.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPlay.TabIndex = 8;
            pbPlay.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(17, 151);
            label1.Name = "label1";
            label1.Size = new Size(154, 35);
            label1.TabIndex = 7;
            label1.Text = "Hướng Dẫn";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(199, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(167, 124);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // prbThoiGian
            // 
            prbThoiGian.Location = new Point(17, 79);
            prbThoiGian.Maximum = 10000;
            prbThoiGian.Name = "prbThoiGian";
            prbThoiGian.Size = new Size(172, 29);
            prbThoiGian.Step = 100;
            prbThoiGian.TabIndex = 6;
            // 
            // txbTenPlay
            // 
            txbTenPlay.Location = new Point(17, 46);
            txbTenPlay.Name = "txbTenPlay";
            txbTenPlay.ReadOnly = true;
            txbTenPlay.Size = new Size(172, 27);
            txbTenPlay.TabIndex = 0;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1309, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, undoToolStripMenuItem1, quitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(218, 26);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem1
            // 
            undoToolStripMenuItem1.Name = "undoToolStripMenuItem1";
            undoToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem1.Size = new Size(218, 26);
            undoToolStripMenuItem1.Text = "Undo";
            undoToolStripMenuItem1.Click += undoToolStripMenuItem1_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem.Size = new Size(218, 26);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(32, 19);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 644);
            Controls.Add(panel3);
            Controls.Add(BanCoXO);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Game Caro LAN";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPlay).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel BanCoXO;
        private Panel panel3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ProgressBar prbThoiGian;
        private TextBox txbTenPlay;
        private Label label1;
        private PictureBox pbPlay;
        private System.Windows.Forms.Timer timer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem1;
        private Label label2;
    }
}
