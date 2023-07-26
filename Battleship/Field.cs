﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Field
    {
        public bool IsHited { get; set; } = false;
        public ShipPart ShipPart { get; set; }
        private int Counter = 0;

        public override string ToString()
        {
            string fieldLine;

            if (ShipPart == null)
            {
                if (Counter % 2 == 0) fieldLine = " ┌┐ ";
                else fieldLine = " └┘ ";
            }
            else
            {
                if (Counter % 2 == 0) fieldLine = "█▀▀█";
                else fieldLine = "█▄▄█";
            }
            Counter++;
            return fieldLine;
        }
    }
}
