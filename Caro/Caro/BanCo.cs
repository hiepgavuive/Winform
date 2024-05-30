using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Caro
{
    public class BanCo
    {
        public string GameMode { get; set; }
        public string Play1 { get; set; }
        public string Play2 { get; set; }

        private Panel panel;
        public Panel Panel { get => panel; set => panel = value; }

        private List<Player> players;

        private int demPlayer;


        private TextBox TenPlay;
        public TextBox TenPlay1 { get => TenPlay; set => TenPlay = value; }


        private PictureBox Mark;
        public PictureBox Mark1 { get => Mark; set => Mark = value; }


        private List<List<Button>> ViTri;
        public List<List<Button>> ViTri1 { get => ViTri; set => ViTri = value; }

        private event EventHandler<ButtonClick> ViTriChanged;
        public event EventHandler<ButtonClick> viTriChanged
        {
            add
            {
                ViTriChanged += value;
            }
            remove
            {
                ViTriChanged -= value;
            }
        }

        private event EventHandler KetThucGame;
        public event EventHandler ketThucGame
        {
            add
            {
                KetThucGame += value;
            }
            remove
            {
                KetThucGame -= value;
            }
        }

        private Stack<PlayInfo> ViTriDanh;
        public BanCo(Panel panel, TextBox TenPlay, PictureBox Mark, string gameMode, string play1, string play2)
        {
            this.panel = panel;
            this.TenPlay = TenPlay;
            this.Mark = Mark;
            switch (gameMode)
            {
                case "1 vs 1":
                    this.players = new List<Player>()
                    {
                        new Player(play1, Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\X.png")),
                        new Player(play2, Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\O.png")),
                    };
                    break;
                case "Chơi với LAN":
                    this.players = new List<Player>()
                    {
                        new Player(play1, Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\X.png")),
                        new Player(play2, Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\O.png")),
                    };
                    break;
                case "Chơi với BOT":
                    this.players = new List<Player>()
                    {
                        new Player(play1, Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\X.png")),
                        new Player("BOT play", Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\O.png")),
                    };
                    break;
            }
           

        }

        public void VeBanCo()
        {
            panel.Enabled = true;
            panel.Controls.Clear();

            ViTriDanh = new Stack<PlayInfo>();

            demPlayer = 0;
            ChonNguoiBatDau();

            ViTri1 = new List<List<Button>>();

            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.BanCo_Y; i++)
            {
                ViTri1.Add(new List<Button>());
                for (int j = 0; j < Cons.BanCo_X; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.X,
                        Height = Cons.Y,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString(),
                    };
                    btn.Click += btn_Click;

                    panel.Controls.Add(btn);

                    ViTri1[i].Add(btn);

                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.Y);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackgroundImage != null)
            {
                return;
            }

            Anh(btn);

            PlayInfo PI = new PlayInfo(Diem(btn), demPlayer);

            ViTriDanh.Push(PI);
            
            demPlayer = demPlayer == 1 ? 0 : 1;
            ChonNguoiBatDau();

            if (ViTriChanged != null)
            {
                ViTriChanged(this, new ButtonClick(Diem(btn)));
            }

            if (ketThuc(btn))
            {
                Win();
            }
       /*     BotDanh();*/
        }
        
        public void btn_1C(Point point)
        {
            Button btn = ViTri1[point.Y][point.X];

            if (btn.BackgroundImage != null)
            {
                return;
            }

            Anh(btn);

            PlayInfo PI = new PlayInfo(Diem(btn), demPlayer);

            ViTriDanh.Push(PI);

            demPlayer = demPlayer == 1 ? 0 : 1;
            ChonNguoiBatDau();

            if (ketThuc(btn))
            {
                Win();
            }
        }

        public bool Undo()
        {
            if (ViTriDanh.Count <= 0)
            {
                return false;
            }

            bool isUndo1 = UndoAStep();
            bool isUndo2 = UndoAStep();

            PlayInfo old = ViTriDanh.Peek();
            demPlayer = old.CurrentPlay1 == 1 ? 0 : 1;
            return isUndo1 && isUndo2;
        }
        private bool UndoAStep()
        {
            if (ViTriDanh.Count <= 0)
            {
                return false;
            }
            PlayInfo old = ViTriDanh.Pop(); // Lay ve Remove
            Button btn = ViTri1[old.Point.Y][old.Point.X];

            btn.BackgroundImage = null;


            if (ViTriDanh.Count <= 0)
            {
                demPlayer = 0;
            }
            else
            {
                old = ViTriDanh.Peek(); // Chi xem du lieu ko Remove
            }

            ChonNguoiBatDau();

            return true;
        }

        private void Win()
        {
            if (KetThucGame != null)
            {
                KetThucGame(this, new EventArgs());
            }
        }

        public bool ketThuc(Button btn)
        {
            return Ngang(btn) || Doc(btn) || CheoChinh(btn) || CheoPhu(btn);
        }

        private Point Diem(Button btn)
        {
            int doc = Convert.ToInt32(btn.Tag);
            int ngang = ViTri1[doc].IndexOf(btn);

            Point point = new Point(ngang, doc);
            return point;
        }

        private bool Ngang(Button btn)
        {
            Point point = Diem(btn);

            int trai = 0;
            for(int i = point.X; i >= 0; i--)
            {
                if (ViTri1[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    trai++;
                }
                else
                {
                    break;
                }
            }

            int phai = 0;
            for (int i = point.X + 1; i < Cons.BanCo_X; i++)
            {
                if (ViTri1[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    phai++;
                }
                else
                {
                    break;
                }
            }

            return trai + phai == 5;
        }

        private bool Doc(Button btn)
        {
            Point point = Diem(btn);

            int tren = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (ViTri1[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    tren++;
                }
                else
                {
                    break;
                }
            }

            int duoi = 0;
            for (int i = point.Y + 1; i < Cons.BanCo_Y; i++)
            {
                if (ViTri1[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    duoi++;
                }
                else
                {
                    break;
                }
            }

            return tren + duoi == 5;
        }

        private bool CheoChinh(Button btn)
        {
            Point point = Diem(btn);

            int tren = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;

                if (ViTri1[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    tren++;
                }
                else
                {
                    break;
                }
            }

            int duoi = 0;
            for (int i = 1; i <= Cons.BanCo_X - point.X; i++)
            {
                if(point.X + i >= Cons.BanCo_X || point.Y + i >= Cons.BanCo_Y)
                {
                    break;
                }

                if (ViTri1[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    duoi++;
                }
                else
                {
                    break;
                }
            }

            return tren + duoi == 5;
        }

        private bool CheoPhu(Button btn)
        {
            Point point = Diem(btn);

            int tren = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >= Cons.BanCo_X || point.Y - i < 0)
                    break;

                if (ViTri1[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    tren++;
                }
                else
                {
                    break;
                }
            }

            int duoi = 0;
            for (int i = 1; i <= Cons.BanCo_X - point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= Cons.BanCo_Y)
                {
                    break;
                }

                if (ViTri1[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    duoi++;
                }
                else
                {
                    break;
                }
            }

            return tren + duoi == 5;
        }

        private void Anh(Button btn)
        {
            btn.BackgroundImage = players[demPlayer].Mark;
        }

        private void ChonNguoiBatDau()
        {
            TenPlay.Text = players[demPlayer].Name;
            Mark.Image = players[demPlayer].Mark;
        }
        private void BotDanh()
        {
            for (int y = 0; y < Cons.BanCo_Y; y++)
            {
                for (int x = 0; x < Cons.BanCo_X; x++)
                {
                    if (ViTri1[y][x].BackgroundImage == null)
                    {
                        // Giả sử bot đánh vào ô này
                        ViTri1[y][x].BackgroundImage = Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\O.jpg"); // BanCoChess.Bot là hình ảnh của bot

                        // Kiểm tra nếu đánh vào ô này có thắng không
                        if (Ngang(ViTri1[y][x]) || Doc(ViTri1[y][x]) || CheoChinh(ViTri1[y][x]) || CheoPhu(ViTri1[y][x]))
                        {
                            // Nếu thắng thì bỏ nước đi này và thử ô khác
                            ViTri1[y][x].BackgroundImage = null;
                        }
                        else
                        {
                            // Nếu không thắng thì đây là nước đi của bot
                            return;
                        }
                    }
                }
            }
        }

    }

    public class ButtonClick : EventArgs
    {
        private Point Clicks;
        public Point Clicks1 { get => Clicks; set => Clicks = value; }

        public ButtonClick(Point point) 
        {
            this.Clicks = point;
        }
    }
}
