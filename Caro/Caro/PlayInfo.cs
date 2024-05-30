using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caro
{
    public class PlayInfo
    {
        private Point point1;
        public Point Point { get => point1; set => point1 = value; }

        private int CurrentPlay;
        public int CurrentPlay1 { get => CurrentPlay; set => CurrentPlay = value; }

        public PlayInfo(Point point, int CurrentPlay)
        {
            this.Point = point;
            this.CurrentPlay = CurrentPlay;
        }
    }
}
