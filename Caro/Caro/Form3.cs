using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public partial class Form3 : Form
    {
        BanCo Banco1;
        Form2 Form2 = new Form2();

        public Form3()
        {
            InitializeComponent();

/*            Banco1 = new BanCo(BanCoXO, txbTenPlay, pbPlay);*/
            Banco1.viTriChanged += Banco1_viTriChanged;
            Banco1.ketThucGame += Banco1_ketThucGame;



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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thoat();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát GAME", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Undo();
        }


        public long[] TC1 = { 0, 2, 3, 8, 100, 12288, 98304 };
        public long[] PN1 = { 0, 1, 9, 12, 210, 600, 59999 };
        public long[] TC2 = { 0, 3, 5, 81, 2810, 12200, 90304 };
        public long[] PN2 = { 0, 1, 9, 200, 729, 6561, 59999 };

        int BoardSizeM = Cons.BanCo_Y;
        int BoardSizeN = Cons.BanCo_X;
        //List<[,]> stack;

        
        long DiemTC(int x, int y, int[,] a, long[] TC, long[] PN, int u, int v, int player)
        {
            long diemTong = 0;
            int ta = 0, dich = 0;
            if (u == -1 && v == 1)
            {
                for (int i = 1; i < 6 && y + i < BoardSizeN && x - i >= 0; i++)
                    if (a[x - i, y + i] == player)
                    {
                        ta++;
                    }
                    else if (a[x - i, y + i] == -player)
                    {
                        dich++;
                        break;
                    }
                    else break;

                for (int i = 1; i < 6 && x + i < BoardSizeM && y - i >= 0; i++)
                    if (a[x + i, y - i] == player)
                    {
                        ta++;
                    }
                    else if (a[x + i, y - i] == -player)
                    {
                        dich++;
                        break;
                    }
                    else break;
            }
            else
            {
                for (int i = 1; i < 6 && y + v * i < BoardSizeN && x + u * i < BoardSizeM; i++)
                    if (a[x + u * i, y + v * i] == player)
                    {
                        ta++;
                    }
                    else if (a[x + u * i, y + v * i] == -player)
                    {
                        dich++;
                        break;
                    }
                    else break;

                for (int i = 1; i < 6 && y - v * i >= 0 && x - u * i >= 0; i++)
                    if (a[x - u * i, y - v * i] == 1)
                    {
                        ta++;
                    }
                    else if (a[x - u * i, y - v * i] == -1)
                    {
                        dich++;
                        break;
                    }
                    else break;
            }
            if (dich == 2) return 0;
            diemTong -= PN[dich + 1];
            diemTong += TC[ta];
            return diemTong;
        }
        long DiemPN(int x, int y, int[,] a, long[] TC, long[] PN, int u, int v, int player)
        {
            long diemTong = 0;
            int ta = 0, dich = 0;
            if (u == -1 && v == 1)
            {
                for (int i = 1; i < 6 && y + i < BoardSizeN && x - i >= 0; i++)
                    if (a[x - i, y + i] == player)
                    {
                        ta++;
                        break;
                    }
                    else if (a[x - i, y + i] == -player)
                    {
                        dich++;
                    }
                    else break;

                for (int i = 1; i < 6 && y - i >= 0 && x + i < BoardSizeM; i++)
                    if (a[x + i, y - i] == player)
                    {
                        ta++;
                        break;
                    }
                    else if (a[x + i, y - i] == -player)
                    {
                        dich++;
                    }
                    else break;
            }
            else
            {
                for (int i = 1; i < 6 && y + v * i < BoardSizeN && x + u * i < BoardSizeM; i++)
                    if (a[x + u * i, y + v * i] == player)
                    {
                        ta++;
                        break;
                    }
                    else if (a[x + u * i, y + v * i] == -player)
                    {
                        dich++;
                    }
                    else break;

                for (int i = 1; i < 6 && y - v * i >= 0 && x - u * i >= 0; i++)
                    if (a[x - u * i, y - v * i] == player)
                    {
                        ta++;
                        break;
                    }
                    else if (a[x - u * i, y - v * i] == -player)
                    {
                        dich++;
                    }
                    else break;
            }
            if (ta == 2) return 0;
            diemTong += PN[dich];
            return diemTong;
        }

        public void Bot(int[,] a, ref int x, ref int y, long[] TC, long[] PN, int player)
        {
            long max = 0;
            for (int i = 0; i < BoardSizeM; i++)
                for (int j = 0; j < BoardSizeN; j++)
                    if (a[i, j] == 0)
                    {
                        long AT = DiemTC(i, j, a, TC, PN, 0, 1, player) + DiemTC(i, j, a, TC, PN, 1, 0, player) + DiemTC(i, j, a, TC, PN, 1, 1, player) + DiemTC(i, j, a, TC, PN, -1, 1, player);
                        long DF = DiemPN(i, j, a, TC, PN, 0, 1, player) + DiemPN(i, j, a, TC, PN, 1, 0, player) + DiemPN(i, j, a, TC, PN, 1, 1, player) + DiemPN(i, j, a, TC, PN, -1, 1, player);
                        long diem = AT > DF ? AT : DF;
                        if (max < diem)
                        {
                            max = diem;
                            x = i;
                            y = j;
                        }
                    }
        }
    }

}
