using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    internal class ShipPart
    {
        public int X { get; }
        public int Y { get; }
        public bool IsHit { get; set; }

        public ShipPart(int x, int y)
        {
            X = x;
            Y = y;
            IsHit = false;
        }

        public bool Hit(int x, int y)
        {
            if (X == x && Y == y && !IsHit)
            {
                IsHit = true;
                return true;
            }
            return false;
        }

        public bool IsAlive()
        {
            return !IsHit;
        }
    }
}

