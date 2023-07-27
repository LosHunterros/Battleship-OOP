using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Player
    {
        private const int BoardSize = 10;
        private char[,] ownBoard = new char[BoardSize, BoardSize];
        private char[,] opponentBoard = new char[BoardSize, BoardSize];
        private List<Models.ShipPart> ships = new List<Models.ShipPart>();

        public required Player Opponent { get; set; }

        public bool IsAlive => ships.Count > 0;

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

        private void PrintOwnBoard()
        {
            throw new NotImplementedException();
        }

        private void PlaceShip()
        {
            int x, y;
            do
            {
                Console.Write("Enter X coordinate (0-9): ");
            } while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= BoardSize);

            do
            {
                Console.Write("Enter Y coordinate (0-9): ");
            } while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= BoardSize);


            if (ownBoard[x, y] != '\0')
            {
                Console.WriteLine("Invalid location. Try again.");
                PlaceShip();
                return;
            }

            ownBoard[x, y] = 'S';
            ships.Add(new Models.ShipPart(x, y)); // Użyj Models.ShipPart
        }

        public void Play()
        {
            Console.WriteLine("Player, it's your turn.");
            int x, y;
            do
            {
                Console.Write("Enter X coordinate to fire at (0-9): ");
            } while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= BoardSize);

            do
            {
                Console.Write("Enter Y coordinate to fire at (0-9): ");
            } while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= BoardSize);


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
            foreach (var shipPart in Opponent.ships)
            {
                if (shipPart.Hit(x, y))
                {
                    Console.WriteLine("You've hit an enemy ship part!");
                    if (!shipPart.IsAlive())
                    {
                        Console.WriteLine("You've sunk an enemy ship part!");
                        Opponent.ships.Remove(shipPart);
                    }
                    return;
                }
            }
        }
    }
}


