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
        static int Crosshair_x = 0;
        static int Crosshair_y = 0;
        public static string[] Messages = new string[18];
        public static void Write(Player playerActive)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Player1.Board[2, 2].ShipPart = new ShipPart();
            Player1.Board[2, 3].ShipPart = new ShipPart();

            Player2.Board[4, 6].ShipPart = new ShipPart();
            Player2.Board[5, 6].ShipPart = new ShipPart();

            string[] player1Board = getPlayersBoard(Player1);
            string[] player2Board = getPlayersBoard(Player2);

            string program = @$"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
█                                                                                                                                                     █
█       █▀▌  █  ▀█▀ ▀█▀ █  █▀▀ ▐▀█ █ █ █ ██▄ ▐▀█                       Player 1 - Człowiek                            Player 2 - Człowiek             █
█       █▄█ ▐ ▌  █   █  █  █   █▄  █▄█ █ █ █ █▄                                                                                                       █
█       █ █ █▄█  █   █  █  █▀   ▀█ █▀█ █ █▀▀  ▀█                                                                                                      █
█       █▄▌ █ █  █   █  ██ █▄▄ █▄▌ █ █ █ █   █▄▌            {player1Board[0]                         }     {player2Board[0]                         } █
█                                                           {player1Board[1]                         }     {player2Board[1]                         } █
█ {MessagePrepareToDisplay(Messages[0], 52)          }      {player1Board[2]                         }     {player2Board[2]                         } █
█ {MessagePrepareToDisplay(Messages[1], 52)          }      {player1Board[3]                         }     {player2Board[3]                         } █
█ {MessagePrepareToDisplay(Messages[2], 52)          }      {player1Board[4]                         }     {player2Board[4]                         } █
█ {MessagePrepareToDisplay(Messages[3], 52)          }      {player1Board[5]                         }     {player2Board[5]                         } █
█ {MessagePrepareToDisplay(Messages[4], 52)          }      {player1Board[6]                         }     {player2Board[6]                         } █
█ {MessagePrepareToDisplay(Messages[5], 52)          }      {player1Board[7]                         }     {player2Board[7]                         } █
█ {MessagePrepareToDisplay(Messages[6], 52)          }      {player1Board[8]                         }     {player2Board[8]                         } █
█ {MessagePrepareToDisplay(Messages[7], 52)          }      {player1Board[9]                         }     {player2Board[9]                         } █
█ {MessagePrepareToDisplay(Messages[8], 52)          }      {player1Board[10]                        }     {player2Board[10]                        } █
█ {MessagePrepareToDisplay(Messages[9], 52)          }      {player1Board[11]                        }     {player2Board[11]                        } █
█ {MessagePrepareToDisplay(Messages[10], 52)         }      {player1Board[12]                        }     {player2Board[12]                        } █
█ {MessagePrepareToDisplay(Messages[11], 52)         }      {player1Board[13]                        }     {player2Board[13]                        } █
█ {MessagePrepareToDisplay(Messages[12], 52)         }      {player1Board[14]                        }     {player2Board[14]                        } █
█ {MessagePrepareToDisplay(Messages[13], 52)         }      {player1Board[15]                        }     {player2Board[15]                        } █
█ {MessagePrepareToDisplay(Messages[14], 52)         }      {player1Board[16]                        }     {player2Board[16]                        } █
█ {MessagePrepareToDisplay(Messages[15], 52)         }      {player1Board[17]                        }     {player2Board[17]                        } █
█ {MessagePrepareToDisplay(Messages[16], 52)         }      {player1Board[18]                        }     {player2Board[18]                        } █
█ {MessagePrepareToDisplay(Messages[17], 52)         }      {player1Board[19]                        }     {player2Board[19]                        } █
█                                                           {player1Board[20]                        }     {player2Board[20]                        } █
█                Press 'Q' to quit game                     {player1Board[21]                        }     {player2Board[21]                        } █
█                                                                                                                                                     █
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
";
            ConsoleColor[] colors = Enumerable.Repeat(ConsoleColor.White, program.Length).ToArray();
            colors[0 + 2 + (153 * (6 + (Crosshair_y * 2))) + (63 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (6 + (Crosshair_y * 2))) + (64 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (7 + (Crosshair_y * 2))) + (63 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (7 + (Crosshair_y * 2))) + (64 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
            for (int i = 0; i < program.Length; i++)
            {
                if (i > 0 && colors[i] != colors[i - 1]) Console.ForegroundColor = colors[i];
                Console.Write(program[i]);
            }

            ConsoleKey userKey;

            while (true)
            {
                userKey = Console.ReadKey().Key;

                switch (userKey)
                {
                    case ConsoleKey.LeftArrow:
                        Crosshair_x -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        Crosshair_x += 1;
                        break;
                    case ConsoleKey.UpArrow:
                        Crosshair_y -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Crosshair_y += 1;
                        break;
                }

                for (int i = 0; i < colors.Length; i++) colors[i] = ConsoleColor.White;

                colors[0 + 2 + (153 * (6 + (Crosshair_y * 2))) + (63 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
                colors[0 + 2 + (153 * (6 + (Crosshair_y * 2))) + (64 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
                colors[0 + 2 + (153 * (7 + (Crosshair_y * 2))) + (63 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
                colors[0 + 2 + (153 * (7 + (Crosshair_y * 2))) + (64 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
                    
                List<string> displayPart = new List<string>();
                List<ConsoleColor> displayPartColor = new List<ConsoleColor>();

                displayPart.Add("");
                displayPartColor.Add(colors[0]);

                Console.Clear();
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
        }
        private static string MessagePrepareToDisplay(string message, int length, TextAlign align = TextAlign.Center)
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
                    playersBoard[i * 2 + Config.paddingTop() + 1] += player.Board[i, j];
                    playersBoard[i * 2 + Config.paddingTop() + 2] += player.Board[i, j];
                }

                playersBoard[i * 2 + Config.paddingTop() + 1] += "│";
                playersBoard[i * 2 + Config.paddingTop() + 2] += "│";

                playersBoard[i * 2 + Config.paddingTop() + 1] = MessagePrepareToDisplay(playersBoard[i * 2 + Config.paddingTop() + 1], lineWidth);
                playersBoard[i * 2 + Config.paddingTop() + 2] = MessagePrepareToDisplay(playersBoard[i * 2 + Config.paddingTop() + 2], lineWidth);
            }

            playersBoard[Config.paddingTop()] = "┌" + String.Concat(Enumerable.Repeat("─", Config.BoardSize * 4)) + "┐";

            playersBoard[Config.paddingTop() + Config.BoardSize * 2 + 1] = "└" + String.Concat(Enumerable.Repeat("─", Config.BoardSize * 4)) + "┘";

            for (int i = 0; i < playersBoard.Length; i++) playersBoard[i] = MessagePrepareToDisplay(playersBoard[i], lineWidth);

            return playersBoard;
        }
    }
}
