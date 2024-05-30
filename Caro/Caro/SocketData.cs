using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caro
{
    public class SocketData
    {
        private int command;
        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string Mess { get => mess; set => mess = value; }

        private Point point;

        private string mess;

        public SocketData(int command, string mess, Point point) 
        {
            this.command = command;
            this.point = point;
            this.mess = mess;
        }
    }

    public enum SkCommand
    {
        SEND_POINT,
        NOTIFY,
        NEWGAME,
        UNDO,
        QUIT
    }
}
