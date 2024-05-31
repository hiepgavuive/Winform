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

        private string Game;
        public BanCo(Panel panel, TextBox TenPlay, PictureBox Mark, string gameMode, string play1, string play2)
        {
            this.panel = panel;
            this.TenPlay = TenPlay;
            this.Mark = Mark;
            Game = gameMode;
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
                        new Player("Server", Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\X.png")),
                        new Player("Client", Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\O.png")),
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
                return; // Không cho phép BOT thực hiện nước đi
            }
            if (players[demPlayer].Name == "BOT play") // Kiểm tra nếu là lượt của BOT
            {
                ComChess(); // Gọi hàm ComChess để BOT thực hiện nước đi của mình
            }
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
            if (Game == "1 vs 1")
            {
                bool isUndo1 = UndoAStep();
                return isUndo1;
            }
            else
            {
                bool isUndo1 = UndoAStep();
                bool isUndo2 = UndoAStep();
                PlayInfo old = ViTriDanh.Peek();
                demPlayer = old.CurrentPlay1 == 1 ? 0 : 1;
                return isUndo1 && isUndo2;
            }
            
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
            if (Game == "1 vs 1")
            {
                old = ViTriDanh.Peek();
                demPlayer = old.CurrentPlay1 == 1 ? 0 : 1;
            }
            old = ViTriDanh.Peek();
            demPlayer = old.CurrentPlay1 == 1 ? 0 : 1;
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

        private long[] arrAttackPoint = { 0, 3, 24, 192, 1536, 12288, 98304 };
        private long[] arrDefendPoint = { 0, 1, 9, 81, 729, 6561, 59049 };

        private void ComChess()
        {
            if (ViTriDanh.Count == 0)
            {
                btn_Click(ViTri1[Cons.BanCo_Y / 2][Cons.BanCo_X / 2], new EventArgs());
            }
            else
            {
                Button shouldChess = SearchForChess();
                if (shouldChess != null)
                {
                    btn_Click(shouldChess, new EventArgs());
                }
            }
        }

        // Tìm nước đi tốt nhất cho BOT
        private Button SearchForChess()
        {
            Button bestMove = null;
            long maxScore = 0;

            for (int i = 0; i < Cons.BanCo_X; i++)
            {
                for (int j = 0; j < Cons.BanCo_Y; j++)
                {
                    if (ViTri1[j][i].BackgroundImage == null)
                    {
                        long attackScore = CalculateAttackScore(i, j);
                        long defendScore = CalculateDefendScore(i, j);
                        long currentScore = Math.Max(attackScore, defendScore);

                        if (currentScore > maxScore)
                        {
                            bestMove = ViTri1[j][i];
                            maxScore = currentScore;
                        }
                    }
                }
            }

            return bestMove;
        }

        // Tính điểm tấn công cho một ô
        private long CalculateAttackScore(int r, int c)
        {
            return CalculateScore(r, c, arrAttackPoint, players[1].Mark, players[0].Mark);
        }

        // Tính điểm phòng thủ cho một ô
        private long CalculateDefendScore(int r, int c)
        {
            return CalculateScore(r, c, arrDefendPoint, players[0].Mark, players[1].Mark);
        }

        // Tính tổng điểm cho một ô
        private long CalculateScore(int r, int c, long[] pointArray, Image allyMark, Image enemyMark)
        {
            return CalculateDirectionScore(r, c, pointArray, allyMark, enemyMark, 0, 1) + // Ngang
                   CalculateDirectionScore(r, c, pointArray, allyMark, enemyMark, 1, 0) + // Dọc
                   CalculateDirectionScore(r, c, pointArray, allyMark, enemyMark, 1, 1) + // Chéo chính
                   CalculateDirectionScore(r, c, pointArray, allyMark, enemyMark, 1, -1); // Chéo phụ
        }

        // Tính điểm theo một hướng cụ thể
        private long CalculateDirectionScore(int r, int c, long[] pointArray, Image allyMark, Image enemyMark, int deltaRow, int deltaCol)
        {
            long sum = 0;
            int allyCount = 0;
            int enemyCount = 0;

            // Kiểm tra hướng đi tiến
            for (int count = 1; count < 6; count++)
            {
                int newRow = r + (count * deltaRow);
                int newCol = c + (count * deltaCol);
                if (newRow < 0 || newRow >= Cons.BanCo_X || newCol < 0 || newCol >= Cons.BanCo_Y) break;

                if (ViTri1[newCol][newRow].BackgroundImage == allyMark)
                {
                    allyCount++;
                }
                else if (ViTri1[newCol][newRow].BackgroundImage == enemyMark)
                {
                    enemyCount++;
                    break;
                }
                else
                    break;
            }

            // Kiểm tra hướng đi lùi
            for (int count = 1; count < 6; count++)
            {
                int newRow = r - count * deltaRow;
                int newCol = c - count * deltaCol;
                if (newRow < 0 || newRow >= Cons.BanCo_X || newCol < 0 || newCol >= Cons.BanCo_Y) break;

                if (ViTri1[newCol][newRow].BackgroundImage == allyMark)
                    allyCount++;
                else if (ViTri1[newCol][newRow].BackgroundImage == enemyMark)
                {
                    enemyCount++;
                    break;
                }
                else
                    break;
            }

            if (enemyCount == 2) return 0; // Bị chặn bởi hai kẻ địch, không có điểm
            sum += pointArray[allyCount];
            if (enemyCount == 1) sum -= pointArray[enemyCount + 1]; // Phạt nhẹ khi bị chặn bởi một kẻ địch

            return sum;
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
