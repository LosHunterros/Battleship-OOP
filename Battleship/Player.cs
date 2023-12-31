﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Player
    {
        public string Name { get; set; }
        public Field[,] Board = new Field[Config.BoardSize, Config.BoardSize];
        public Field[,] BoardToDisplay = new Field[Config.BoardSize, Config.BoardSize];
        public int CrosshairY { get; private set; } = (Config.BoardSize - 1) / 2;
        public int CrosshairX { get; private set; } = (Config.BoardSize - 1) / 2;
        public Orientation Orientation { get; private set; } = Orientation.Horizontal;
        public Player Opponent { get; set; }
        private List<Ship> Ships = new List<Ship>();

        public int MarginLeft { get; private set; }
        public int OffsetLeft { get; private set; }

        public bool ShowShips = true;
        public bool ShowCrosshair = false;

        public Player(string name, int marginLeft)
        {
            Name = name;
            Board = GetEmptyBoard();
            BoardToDisplay = GetEmptyBoard();
            MarginLeft = marginLeft;
            OffsetLeft = marginLeft + Config.paddingLeft();
        }

        public void SetShips()
        {
            bool isShipAdded;
            Ship shipToAdd;
            ConsoleKey userKey;

            Display.ClearMessages();
            Display.Messages[4] = $"{Name} set up Your ships".ToUpper();
            Display.Messages[8] = "↑↓←→: Move ship";
            Display.Messages[10] = "Tab: Switch ship orientation (horizontal/vertical)";
            Display.Messages[12] = "Enter: Confirm ship location";

            for (int i = 0; Config.Ships.Length > i; i++)
            {
                isShipAdded = false;
                CenterCrosshair();

                do
                {
                    ValidateCrosshair(Config.Ships[i]);
                    shipToAdd = GetNewShip(Config.Ships[i]);
                    CheckCollision(shipToAdd);
                    BoardToDisplay = CloneBoard(Board);
                    BoardToDisplay = AddShipToBoard(BoardToDisplay, shipToAdd);

                    Display.Write();

                    userKey = Console.ReadKey().Key;

                    UserKeyPressHandle(userKey);

                    if( userKey == ConsoleKey.Enter )
                    {
                        isShipAdded = AddShipToPlayer(shipToAdd);
                    }

                }
                while (!isShipAdded);
            }
            ShowShips = false;
            ShowCrosshair = true;
            CenterCrosshair();
        }

        public void MakeMove()
        {
            bool isMoveDone = false;
            ConsoleKey userKey;

            Display.ClearMessages();
            Display.Messages[4] = $"{Name} make a shot".ToUpper();
            Display.Messages[8] = "↑↓←→: Move crosshair";
            Display.Messages[10] = "Enter: shoot!";

            do
            {
                Display.Write();

                userKey = Console.ReadKey().Key;

                UserKeyPressHandle(userKey);

                if (userKey == ConsoleKey.Enter)
                {
                    isMoveDone = MakeShot();
                }

            }
            while (!isMoveDone);
        }

        private Ship GetNewShip(int shipLength)
        {
            Ship ship = new Ship();
            int coordinatesY = CrosshairY;
            int coordinatesX = CrosshairX;
            for (var i = 0; i < shipLength; i++)
            {
                ship.AddShipPart(coordinatesY, coordinatesX);
                if (Orientation == Orientation.Horizontal) coordinatesX++;
                else coordinatesY++;
            }
            return ship;
        }

        private Field[,] GetEmptyBoard()
        {
            Field[,] board = new Field[Config.BoardSize, Config.BoardSize];
            for (int i = 0; Config.BoardSize > i; i++)
            {
                for (int j = 0; Config.BoardSize > j; j++)
                {
                    board[i, j] = new Field(this);
                }
            }
            return board;
        }

        private Field[,] CloneBoard(Field[,] board)
        {
            Field[,] boardNew = new Field[Config.BoardSize, Config.BoardSize];
            boardNew = GetEmptyBoard();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    boardNew[i,j] = board[i,j].Clone();
                }
            }
            return boardNew;
        }

        private Field[,] AddShipToBoard(Field[,] board, Ship ship)
        {
            for (int i = 0; i < ship.Parts.Count; i++)
            {
                board[ship.Parts[i].CoordinatesY, ship.Parts[i].CoordinatesX].ShipPart = ship.Parts[i];
            }
            return board;
        }

        private bool AddShipToPlayer(Ship ship)
        {
            if (ship.State != ShipState.Collision)
            {
                ship.State = ShipState.Ok;
                Ships.Add(ship);
                for (int i = 0; i < ship.Parts.Count; i++)
                {
                    Board[ship.Parts[i].CoordinatesY, ship.Parts[i].CoordinatesX].ShipPart = ship.Parts[i];
                    ship.Parts[i].State = ShipState.Ok;
                }
                return true;
            }

            return false;
        }

        private bool MakeShot()
        {
            if (Opponent.BoardToDisplay[CrosshairY, CrosshairX].IsHited) return false;
            else
            {
                Opponent.BoardToDisplay[CrosshairY, CrosshairX].Hit();
                return true;
            }
        }

        public bool IsAlive()
        {
            foreach (var ship in Ships)
            {
                if (ship.State != ShipState.Sunk) return true;
            }
            return false;
        }

        private void UserKeyPressHandle(ConsoleKey userKey)
        {
            switch (userKey)
            {
                case ConsoleKey.LeftArrow:
                    if (CrosshairX - 1 >= 0 ) CrosshairX -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    if (CrosshairX + 1 < Config.BoardSize) CrosshairX += 1;
                    break;
                case ConsoleKey.UpArrow:
                    if (CrosshairY - 1 >= 0) CrosshairY -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (CrosshairY + 1 < Config.BoardSize) CrosshairY += 1;
                    break;
                case ConsoleKey.Tab:
                    if (Orientation == Orientation.Horizontal) Orientation = Orientation.Vertical;
                    else Orientation = Orientation.Horizontal;
                    break;
            }
        }
        private void CenterCrosshair()
        {
        CrosshairY = (Config.BoardSize - 1) / 2;
        CrosshairX = (Config.BoardSize - 1) / 2;
        }

        private void ValidateCrosshair(int shipLength = 0)
        {
            if (Orientation == Orientation.Horizontal && CrosshairX + shipLength > Config.BoardSize) CrosshairX = Config.BoardSize - shipLength;
            if (Orientation == Orientation.Vertical && CrosshairY + shipLength > Config.BoardSize) CrosshairY = Config.BoardSize - shipLength;
        }

        private void CheckCollision(Ship ship)
        {
            for (int i = 0; i < ship.Parts.Count; i++)
            {
                if (Board[ship.Parts[i].CoordinatesY, ship.Parts[i].CoordinatesX].ShipPart != null)
                {
                    ship.State = ShipState.Collision;
                    ship.Parts[i].State = ShipState.Collision;
                }
                else if (
                    ship.Parts[i].CoordinatesY + 1 < Config.BoardSize
                    &&
                    Board[ship.Parts[i].CoordinatesY + 1, ship.Parts[i].CoordinatesX].ShipPart != null
                    )
                {
                    ship.State = ShipState.Collision;
                    ship.Parts[i].State = ShipState.Collision;
                }
                else if (
                    ship.Parts[i].CoordinatesY - 1 >= 0
                    &&
                    Board[ship.Parts[i].CoordinatesY - 1, ship.Parts[i].CoordinatesX].ShipPart != null
                    )
                {
                    ship.State = ShipState.Collision;
                    ship.Parts[i].State = ShipState.Collision;
                }
                else if (
                    ship.Parts[i].CoordinatesX + 1 < Config.BoardSize
                    &&
                    Board[ship.Parts[i].CoordinatesY, ship.Parts[i].CoordinatesX + 1].ShipPart != null
                    )
                {
                    ship.State = ShipState.Collision;
                    ship.Parts[i].State = ShipState.Collision;
                }
                else if (
                    ship.Parts[i].CoordinatesX - 1 >= 0
                    &&
                    Board[ship.Parts[i].CoordinatesY, ship.Parts[i].CoordinatesX - 1].ShipPart != null
                    )
                {
                    ship.State = ShipState.Collision;
                    ship.Parts[i].State = ShipState.Collision;
                }
            }
        }
    }
}
