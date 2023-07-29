using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Field
    {
        public Player Player { get; private set; }
        public bool IsHited { get; set; } = false;
        public ShipPart ShipPart { get; set; }
        private int Counter = 0;

        public Field(Player player)
        {
            Player = player;
        }

        public override string ToString()
        {
            string fieldLine;

            if (ShipPart == null)
            {
                if (!IsHited)
                {
                    if (Counter % 2 == 0) fieldLine = " ┌┐ ";
                    else fieldLine = " └┘ ";
                }
                else
                {
                    if (Counter % 2 == 0) fieldLine = " ▄▄ ";
                    else fieldLine = " ▀▀ ";
                }
            }
            else
            {
                if (ShipPart.State == ShipState.Ok && !Player.ShowShips)
                {
                    if (Counter % 2 == 0) fieldLine = " ┌┐ ";
                    else fieldLine = " └┘ ";
                }
                else if (ShipPart.State == ShipState.Ok || ShipPart.State == ShipState.Temporary || ShipPart.State == ShipState.Collision)
                {
                    if (Counter % 2 == 0) fieldLine = "████";
                    else fieldLine = "████";
                }
                else
                {
                    if (Counter % 2 == 0) fieldLine = "█▀▀█";
                    else fieldLine = "█▄▄█";
                }
            }

            Counter++;
            return fieldLine;
        }

        public Field Clone()
        {
            Field field = new Field(this.Player);
            field.IsHited = this.IsHited;
            field.ShipPart = this.ShipPart;
            return field;
        }

        public void Hit()
        {
            IsHited = true;
            if (ShipPart != null) ShipPart.Hit();
        }
    }
}
