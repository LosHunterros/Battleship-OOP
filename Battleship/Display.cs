using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Display
    {
        public static Player Player1 { get; set; }
        public static Player Player2 { get; set; }
        public static Player PlayerActive { get; set; }
        public static string[] Messages = new string[18];
        public static void Write()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            string[] player1Board = getPlayersBoard(Player1);
            string[] player2Board = getPlayersBoard(Player2);

            string program = @$"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
█                                                                                                                                                     █
█       █▀▌  █  ▀█▀ ▀█▀ █  █▀▀ ▐▀█ █ █ █ ██▄ ▐▀█            {MessagePrepToDisplay(Player1.Name, 42)  }     {MessagePrepToDisplay(Player2.Name, 42)  } █
█       █▄█ ▐ ▌  █   █  █  █   █▄  █▄█ █ █ █ █▄                                                                                                       █
█       █ █ █▄█  █   █  █  █▀   ▀█ █▀█ █ █▀▀  ▀█                                                                                                      █
█       █▄▌ █ █  █   █  ██ █▄▄ █▄▌ █ █ █ █   █▄▌            {player1Board[0]                         }     {player2Board[0]                         } █
█                                                           {player1Board[1]                         }     {player2Board[1]                         } █
█ {MessagePrepToDisplay(Messages[0], 52)             }      {player1Board[2]                         }     {player2Board[2]                         } █
█ {MessagePrepToDisplay(Messages[1], 52)             }      {player1Board[3]                         }     {player2Board[3]                         } █
█ {MessagePrepToDisplay(Messages[2], 52)             }      {player1Board[4]                         }     {player2Board[4]                         } █
█ {MessagePrepToDisplay(Messages[3], 52)             }      {player1Board[5]                         }     {player2Board[5]                         } █
█ {MessagePrepToDisplay(Messages[4], 52)             }      {player1Board[6]                         }     {player2Board[6]                         } █
█ {MessagePrepToDisplay(Messages[5], 52)             }      {player1Board[7]                         }     {player2Board[7]                         } █
█ {MessagePrepToDisplay(Messages[6], 52)             }      {player1Board[8]                         }     {player2Board[8]                         } █
█ {MessagePrepToDisplay(Messages[7], 52)             }      {player1Board[9]                         }     {player2Board[9]                         } █
█ {MessagePrepToDisplay(Messages[8], 52)             }      {player1Board[10]                        }     {player2Board[10]                        } █
█ {MessagePrepToDisplay(Messages[9], 52)             }      {player1Board[11]                        }     {player2Board[11]                        } █
█ {MessagePrepToDisplay(Messages[10], 52)            }      {player1Board[12]                        }     {player2Board[12]                        } █
█ {MessagePrepToDisplay(Messages[11], 52)            }      {player1Board[13]                        }     {player2Board[13]                        } █
█ {MessagePrepToDisplay(Messages[12], 52)            }      {player1Board[14]                        }     {player2Board[14]                        } █
█ {MessagePrepToDisplay(Messages[13], 52)            }      {player1Board[15]                        }     {player2Board[15]                        } █
█ {MessagePrepToDisplay(Messages[14], 52)            }      {player1Board[16]                        }     {player2Board[16]                        } █
█ {MessagePrepToDisplay(Messages[15], 52)            }      {player1Board[17]                        }     {player2Board[17]                        } █
█ {MessagePrepToDisplay(Messages[16], 52)            }      {player1Board[18]                        }     {player2Board[18]                        } █
█ {MessagePrepToDisplay(Messages[17], 52)            }      {player1Board[19]                        }     {player2Board[19]                        } █
█                                                           {player1Board[20]                        }     {player2Board[20]                        } █
█                Press 'Q' to quit game                     {player1Board[21]                        }     {player2Board[21]                        } █
█                                                                                                                                                     █
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
";
            ConsoleColor[] colors = Enumerable.Repeat(ConsoleColor.White, program.Length).ToArray();

            colors = AddColorToShipState(colors, PlayerActive, ShipState.Temporary, ConsoleColor.DarkGray);
            colors = AddColorToShipState(colors, PlayerActive, ShipState.Collision, ConsoleColor.Red);
            colors = AddColorToShipState(colors, Player1, ShipState.Sunk, ConsoleColor.DarkBlue);
            colors = AddColorToShipState(colors, Player2, ShipState.Sunk, ConsoleColor.DarkBlue);

            if (PlayerActive.ShowCrosshair) colors = AddColorToField(colors, PlayerActive.CrosshairY, PlayerActive.CrosshairX, ConsoleColor.Red, PlayerActive.Opponent);

            List<string> displayPart = new List<string>();
            List<ConsoleColor> displayPartColor = new List<ConsoleColor>();

            displayPart.Add("");
            displayPartColor.Add(colors[0]);

            int j = 0;
            for (int i = 0; i < program.Length; i++)
            {
                if (i > 0 && colors[i] != colors[i - 1])
                {
                    j++;
                    displayPart.Add("");
                    displayPartColor.Add(colors[i]);
                }
                displayPart[j] += program[i];
            }

            for (int i = 0; i < displayPart.Count; i++)
            {
                Console.ForegroundColor = displayPartColor[i];
                Console.Write(displayPart[i]);
            }
        }
        private static string MessagePrepToDisplay(string message, int length, TextAlign align = TextAlign.Center)
        {
            if (message == null) message = "";
            switch (align)
            {
                case TextAlign.Left: return message.PadRight(length);
                case TextAlign.Right: return message.PadLeft(length);
                case TextAlign.Center:
                    int PadLeft = ((length - message.Length) / 2) + message.Length;
                    return message.PadLeft(PadLeft).PadRight(length);
            }
            return message;
        }
        private static string[] getPlayersBoard(Player player)
        {
            int linesAmount = Config.MaxBoardSize * 2 + 2;
            int lineWidth = Config.MaxBoardSize * 4 + 2;
            string[] playersBoard = new string[linesAmount];

            for (int i = 0; i < Config.BoardSize; i++)
            {
                playersBoard[i * 2 + Config.paddingTop() + 1] = "│";
                playersBoard[i * 2 + Config.paddingTop() + 2] = "│";

                for (int j = 0; j < Config.BoardSize; j++)
                {
                    playersBoard[i * 2 + Config.paddingTop() + 1] += player.BoardToDisplay[i, j];
                    playersBoard[i * 2 + Config.paddingTop() + 2] += player.BoardToDisplay[i, j];
                }

                playersBoard[i * 2 + Config.paddingTop() + 1] += "│";
                playersBoard[i * 2 + Config.paddingTop() + 2] += "│";

                playersBoard[i * 2 + Config.paddingTop() + 1] = MessagePrepToDisplay(playersBoard[i * 2 + Config.paddingTop() + 1], lineWidth);
                playersBoard[i * 2 + Config.paddingTop() + 2] = MessagePrepToDisplay(playersBoard[i * 2 + Config.paddingTop() + 2], lineWidth);
            }

            playersBoard[Config.paddingTop()] = "┌" + String.Concat(Enumerable.Repeat("─", Config.BoardSize * 4)) + "┐";

            playersBoard[Config.paddingTop() + Config.BoardSize * 2 + 1] = "└" + String.Concat(Enumerable.Repeat("─", Config.BoardSize * 4)) + "┘";

            for (int i = 0; i < playersBoard.Length; i++) playersBoard[i] = MessagePrepToDisplay(playersBoard[i], lineWidth);

            return playersBoard;
        }

        public static void ClearMessages()
        {
            Messages = new string[18];
        }

        private static ConsoleColor[] AddColorToField(ConsoleColor[] colors, int coordinatesY, int coordinatesX, ConsoleColor color, Player player)
        {
            int firstChar = 2 + ((Config.lineWidth + 2) * (6 + (coordinatesY * 2))) + player.OffsetLeft + (coordinatesX * 4);
            colors[firstChar] = color;
            colors[firstChar + 1] = color;
            colors[firstChar + 2] = color;
            colors[firstChar + 3] = color;
            colors[firstChar + Config.lineWidth + 2] = color;
            colors[firstChar + Config.lineWidth + 2 + 1] = color;
            colors[firstChar + Config.lineWidth + 2 + 2] = color;
            colors[firstChar + Config.lineWidth + 2 + 3] = color;
            return colors;
        }

        private static ConsoleColor[] AddColorToShipState(ConsoleColor[] colors, Player player, ShipState shipState, ConsoleColor color)
        {
            for (int i = 0; i < player.BoardToDisplay.GetLength(0); i++)
            {
                for (int j = 0; j < player.BoardToDisplay.GetLength(1); j++)
                {
                    if (player.BoardToDisplay[i, j].ShipPart != null && player.BoardToDisplay[i, j].ShipPart.State == shipState)
                        AddColorToField(colors, i, j, color, player);
                }
            }
            return colors;
        }
    }
}
