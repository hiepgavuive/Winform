using Microsoft.VisualBasic;
using System;
using System.Net;
using System.Net.Sockets;

namespace Caro
{
    public partial class Form1 : Form
    {

        BanCo Banco1;
        SocketManager SocketManager;
        public string GameMode { get; set; }
        public string Play1 { get; set; }
        public string Play2 { get; set; }
        public string IP { get; set; }

        private bool isser = true;

        public Form1()
        {
            InitializeComponent();

        }

        public Form1(string gameMode, string play1, string play2, string ip)
        {
            InitializeComponent();

            GameMode = gameMode;
            Play1 = play1;
            Play2 = play2;
            IP = ip;

            Banco1 = new BanCo(BanCoXO, txbTenPlay, pbPlay, GameMode, Play1, Play2);
            Banco1.viTriChanged += Banco1_viTriChanged;
            Banco1.ketThucGame += Banco1_ketThucGame;

            SocketManager = new SocketManager();

            batDauGame();
        }

        void ketThucGame()
        {
            timer.Stop();
            BanCoXO.Enabled = false;
            undoToolStripMenuItem1.Enabled = false;
            MessageBox.Show("Ket thuc");
        }

        void batDauGame()
        {
            prbThoiGian.Value = 0;
            timer.Stop();
            undoToolStripMenuItem1.Enabled = true;
            Banco1.VeBanCo();
        }

        void thoat()
        {
            Application.Exit();
        }

        void Undo()
        {
            Banco1.Undo();
            prbThoiGian.Value = 0;
        }

        private void Banco1_ketThucGame(object sender, EventArgs e)
        {
            ketThucGame();
        }

        private void Banco1_viTriChanged(object sender, ButtonClick e)
        {
            timer.Start();
            if (GameMode == "Chơi với LAN")
            {
                BanCoXO.Enabled = false;
                undoToolStripMenuItem1.Enabled = false;
                SocketManager.Send<SocketData>(new SocketData((int)SkCommand.SEND_POINT, null, e.Clicks1));
                listen();
            }

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
            SocketManager.Send<SocketData>(new SocketData((int)SkCommand.NEWGAME, null, new Point()));
            BanCoXO.Enabled = true;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thoat();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát GAME", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    SocketManager.Send<SocketData>(new SocketData((int)SkCommand.QUIT, null, new Point()));
                }
                catch { }
            }
        }

        void listen()
        {

            Thread listenthread = new Thread(() =>
            {
                try
                {
                    SocketData data = SocketManager.Receive<SocketData>();
                    ProcessData(data);
                }
                catch { }
            });
            listenthread.IsBackground = true;
            listenthread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SkCommand.NOTIFY:
                    MessageBox.Show(data.Mess);
                    break;
                case (int)SkCommand.NEWGAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        batDauGame();
                        BanCoXO.Enabled = false;
                    }));
                    break;
                case (int)SkCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Banco1.btn_1C(data.Point);
                        prbThoiGian.Value = 0;
                        BanCoXO.Enabled = true;
                        timer.Start();

                        undoToolStripMenuItem1.Enabled = true;
                    }));

                    break;
                case (int)SkCommand.UNDO:
                    Undo();
                    prbThoiGian.Value = 0;
                    break;
                case (int)SkCommand.QUIT:
                    timer.Stop();
                    MessageBox.Show("Người chơi đã thoát");
                    break;

                default:
                    break;
            }

            listen();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Undo();
            SocketManager.Send(new SocketData((int)SkCommand.UNDO, "", new Point()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (GameMode == "Chơi với LAN")
            {
                SocketManager.IP = IP;

                if (!SocketManager.IsConnected())
                {
                    SocketManager.isSever = true;
                    BanCoXO.Enabled = true;
                    SocketManager.createSever();
                }
                else
                {
                    SocketManager.isSever = false;
                    BanCoXO.Enabled = false;
                    listen();
                }

            }
        }
    }
}
