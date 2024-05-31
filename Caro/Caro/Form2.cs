using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public partial class Form2 : Form
    {
        SocketManager socketManager = new SocketManager();
        public Form2()
        {
            InitializeComponent();

            this.f2cbbCheDo.Items.Add("1 vs 1");
            this.f2cbbCheDo.Items.Add("Chơi với LAN");
            this.f2cbbCheDo.Items.Add("Chơi với BOT");
            this.f2cbbCheDo.SelectedIndex = 0;
            txtPlayer1.Visible = true;
            txtPlayer2.Visible = true;
            txtIP.Visible = false;

        }
        private void f2cbbCheDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gameMode = f2cbbCheDo.SelectedItem.ToString();
            switch (gameMode)
            {
                case "1 vs 1":
                    txtPlayer1.Visible = true;
                    txtPlayer2.Visible = true;
                    txtIP.Visible = false;
                    label3.Visible = false;
                    txtPlayer1.PlaceholderText = "Tên người chơi 1";
                    txtPlayer2.PlaceholderText = "Tên người chơi 2";
                    break;
                case "Chơi với LAN":
                    txtPlayer1.Visible = true;
                    txtPlayer2.Visible = false;
                    txtIP.Visible = true;
                    label3.Visible = true;
                    txtIP.Text = socketManager.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Ethernet);
                    txtPlayer1.PlaceholderText = "Tên người chơi";
                    txtIP.PlaceholderText = "Địa chỉ IP";
                    break;
                case "Chơi với BOT":
                    txtPlayer1.Visible = true;
                    txtPlayer2.Visible = false;
                    txtIP.Visible = false;
                    label3.Visible = false;
                    txtPlayer1.PlaceholderText = "Tên người chơi";
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string player1 = txtPlayer1.Text;
            string player2 = txtPlayer2.Text;
            string IP = txtIP.Text;
            string gameMode = f2cbbCheDo.SelectedItem.ToString();

            switch (gameMode)
            {
                case "1 vs 1":
                    if (string.IsNullOrEmpty(player1) || string.IsNullOrEmpty(player2))
                    {
                        MessageBox.Show("Vui lòng nhập tên người chơi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Chơi với LAN":
                    if (string.IsNullOrEmpty(player1))
                    {
                        MessageBox.Show("Vui lòng nhập tên người chơi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if(string.IsNullOrEmpty(IP))
                    {
                        MessageBox.Show("Vui lòng nhập địa chỉ IP", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Chơi với BOT":
                    if (string.IsNullOrEmpty(player1))
                    {
                        MessageBox.Show("Vui lòng nhập tên người chơi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }

            Form1 x = new Form1(gameMode, txtPlayer1.Text, txtPlayer2.Text, txtIP.Text);
            this.Hide();
            // kiểm tra nếu người dùng chọn mạng LAN hiển thị thông báo nhập IP
            x.ShowDialog();
            this.Close();

        }
    }
}
