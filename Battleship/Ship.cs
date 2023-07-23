using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Ship
    {
        private List<Square> squares = new List<Square>();

        public Ship(int x, int y)
        {
            squares.Add(new Square(x, y));
        }

        public List<Square> Squares => squares;

        public bool IsAlive
        {
            get
            {
                foreach (var square in squares)
                {
                    if (!square.IsHit)
                        return true;
                }
                return false;
            }
        }

        public bool Hit(int x, int y)
        {
            foreach (var square in squares)
            {
                if (square.X == x && square.Y == y)
                {
                    square.IsHit = true;
                    return true;
                }
            }
            return false;
        }
    }

    internal class Square
    {
        public int X { get; }
        public int Y { get; }
        public bool IsHit { get; set; }

        public Square(int x, int y)
        {
            X = x;
            Y = y;
            IsHit = false;
        }
    }
}
