using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caro
{
    public class BanCo
    {
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

        private event EventHandler ViTriChanged;
        public event EventHandler viTriChanged 
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


        public BanCo(Panel panel, TextBox TenPlay, PictureBox Mark)
        {
            this.panel = panel;
            this.TenPlay = TenPlay;
            this.Mark = Mark;
            this.players = new List<Player>()
            {
                new Player("X play", Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\X.jpg")),
                new Player("O play", Image.FromFile("D:\\Code\\C#\\LTUD_Caro\\Caro\\Caro\\Resources\\O.jpg")),
            };
        }

        public void VeBanCo()
        {
            panel.Enabled = true;
            panel.Controls.Clear();

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
            ChonNguoiBatDau();

            if (ViTriChanged != null)
            {
                ViTriChanged(this, new EventArgs());
            }

            if (ketThuc(btn))
            {
                Win();
            }
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

            demPlayer = demPlayer == 1 ? 0 : 1;
        }

        private void ChonNguoiBatDau()
        {
            TenPlay.Text = players[demPlayer].Name;

            Mark.Image = players[demPlayer].Mark;
        }


    }
}
