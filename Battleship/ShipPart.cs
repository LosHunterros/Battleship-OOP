using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class ShipPart
    {
        public Ship Ship { get; private set; }
        public ShipState State = ShipState.Temporary;
        public int CoordinatesY { get; private set; }
        public int CoordinatesX { get; private set; }

        public ShipPart(Ship ship, int coordinatesY, int coordinatesX)
        {
            Ship = ship;
            CoordinatesY = coordinatesY;
            CoordinatesX = coordinatesX;
        }

        public void Hit()
        {
            State = ShipState.Hit;
            Ship.Hit();
        }
    }
}
