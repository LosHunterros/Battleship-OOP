using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Config
    {
        public static int BoardSize { get; private set; } = 10;
        public static int MaxBoardSize { get; private set; } = 10;
        public static int[] Ships { get; private set; } = { 4, 3, 3, 3, 2, 2, 2, 1, 1, 1 };
        public static string Player1Name { get; private set; } = "Player 1";
        public static string Player2Name { get; private set; } = "Player 2";
        public static int marginTop { get; private set; } = 6;
        public static int paddingTop() { return MaxBoardSize - BoardSize; }
        public static int offsetTop() { return marginTop + paddingTop(); }
    }
}
