namespace Caro
{
    public partial class Form1 : Form
    {

        BanCo Banco1;

        public Form1()
        {
            InitializeComponent();

            Banco1 = new BanCo(BanCoXO, txbTenPlay, pbPlay);
            Banco1.viTriChanged += Banco1_viTriChanged;
            Banco1.ketThucGame += Banco1_ketThucGame;

            batDauGame();
        }

        void ketThucGame()
        {
            timer.Stop();
            BanCoXO.Enabled = false;
            MessageBox.Show("Ket thuc");
        }

        void batDauGame()
        {
            prbThoiGian.Value = 0;
            timer.Stop();

            Banco1.VeBanCo();
        }

        void hoanTac()
        {

        }

        void thoat()
        {    
            Application.Exit();

        }

        private void Banco1_ketThucGame(object? sender, EventArgs e)
        {
            ketThucGame();
        }

        private void Banco1_viTriChanged(object? sender, EventArgs e)
        {
            timer.Start();
            prbThoiGian.Value = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            prbThoiGian.PerformStep();

            if (prbThoiGian.Value >= prbThoiGian.Maximum)
            {
                ketThucGame();
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            batDauGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hoanTac();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thoat();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban co chac muon thoat game", "Thong bao", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
