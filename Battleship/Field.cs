using System;
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
    }
}
