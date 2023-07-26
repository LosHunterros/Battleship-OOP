using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Player
    {
        public string Name { get; set; }
        public Field[,] Board = new Field[Config.BoardSize, Config.BoardSize];
        public int CrosshairY { get; private set; } = (Config.BoardSize + 1) / 2;
        public int CrosshairX { get; private set; } = (Config.BoardSize + 1) / 2;
        public Orientation Orientation { get; private set; } = Orientation.Horizontal;
        public Player Opponent { get; set; }

        public bool IsAlive => ships.Count > 0;

        private char[,] ownBoard = new char[Config.BoardSize, Config.BoardSize];
        private char[,] opponentBoard = new char[Config.BoardSize, Config.BoardSize];
        private List<Ship> ships = new List<Ship>();

        public Player(string name)
        {
            Name = name;
            for (int i = 0; Config.BoardSize > i; i++)
            {
                for (int j = 0; Config.BoardSize > j; j++)
                {
                    Board[i, j] = new Field();
                }
            }
        }

        public void setShips()
        {
            for (int i = 0; Config.Ships.Length < i; i++)
            {

            }
        }

        public void PlaceShips()
        {
            Console.WriteLine("Player, place your ships.");
            for (int shipNumber = 1; shipNumber <= 4; shipNumber++)
            {
                Console.Write($"Placing ship {shipNumber}: ");
                PlaceShip();
                Console.WriteLine();
                PrintOwnBoard();
            }
        }

        private void PlaceShip()
        {
            int x, y;
            do
            {
                Console.Write("Enter X coordinate (0-9): ");
            } while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= Config.BoardSize);

            do
            {
                Console.Write("Enter Y coordinate (0-9): ");
            } while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= Config.BoardSize);

            
            if (ownBoard[x, y] != '\0')
            {
                Console.WriteLine("Invalid location. Try again.");
                PlaceShip();
                return;
            }

            
            ownBoard[x, y] = 'S';
            ships.Add(new Ship(x, y));
        }

        public void Play()
        {
            Console.WriteLine("Player, it's your turn.");
            int x, y;
            do
            {
                Console.Write("Enter X coordinate to fire at (0-9): ");
            } while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= Config.BoardSize);

            do
            {
                Console.Write("Enter Y coordinate to fire at (0-9): ");
            } while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= Config.BoardSize);

            
            if (opponentBoard[x, y] != '\0')
            {
                Console.WriteLine("You've already fired at this location. Try again.");
                Play();
                return;
            }

            
            if (Opponent.ownBoard[x, y] == 'S')
            {
                Console.WriteLine("Hit!");
                opponentBoard[x, y] = 'X';
                Opponent.ownBoard[x, y] = 'X';
                HandleHit(x, y);
            }
            else
            {
                Console.WriteLine("Miss!");
                opponentBoard[x, y] = 'O';
            }

            Opponent.PrintOwnBoard();

            if (!Opponent.IsAlive)
            {
                Console.WriteLine("Congratulations! You've won!");
                Environment.Exit(0);
            }
        }

        private void HandleHit(int x, int y)
        {
            
            foreach (var ship in Opponent.ships)
            {
                if (ship.Hit(x, y))
                {
                    Console.WriteLine("You've hit an enemy ship!");
                    if (!ship.IsAlive)
                    {
                        Console.WriteLine("You've sunk an enemy ship!");
                        Opponent.ships.Remove(ship);
                    }
                    return;
                }
            }
        }

        public class Ship
        {
            private int x;
            private int y;
            private bool isAlive = true;

            public Ship(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public bool Hit(int x, int y)
            {
                if (this.x == x && this.y == y && isAlive)
                {
                    isAlive = false;
                    return true;
                }
                return false;
            }

            public bool IsAlive => isAlive;
        }


        public void PrintOwnBoard()
        {
            Console.WriteLine("Player's own board:");
            for (int i = 0; i < Config.BoardSize; i++)
            {
                for (int j = 0; j < Config.BoardSize; j++)
                {
                    Console.Write(ownBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
