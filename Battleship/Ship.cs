using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Ship
    {
        public ShipState State = ShipState.Temporary;
        public List<ShipPart> Parts = new List<ShipPart>();

        public void AddShipPart(int coordinatesY, int coordinatesX)
        {
            Parts.Add(new ShipPart(this, coordinatesY, coordinatesX));
        }

        public void Hit()
        {
            State = ShipState.Hit;
            bool isSunk = true;
            foreach (var part in Parts)
            {
                if (part.State == ShipState.Ok) isSunk = false;
            }
            if (isSunk)
            {
                State = ShipState.Sunk;
                foreach (var part in Parts) part.State = ShipState.Sunk;
            }
        }

    }
}
