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
            string board = @$"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
█                                                                                                                                                     █
█       █▀▌  █  ▀█▀ ▀█▀ █  █▀▀ ▐▀█ █ █ █ ██▄ ▐▀█                      Player 1 - Człowiek                            Player 2 - Człowiek              █
█       █▄█ ▐ ▌  █   █  █  █   █▄  █▄█ █ █ █ █▄                                                                                                       █
█       █ █ █▄█  █   █  █  █▀   ▀█ █▀█ █ █▀▀  ▀█               1   2   3   4   5   6   7   8   9  10          1   2   3   4   5   6   7   8   9  10   █
█       █▄▌ █ █  █   █  ██ █▄▄ █▄▌ █ █ █ █   █▄▌            ┌────────────────────────────────────────┐     ┌────────────────────────────────────────┐ █
█                                                         A │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   A │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[0], 52)          }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[1], 52)          }    B │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   B │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[2], 52)          }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[3], 52)          }    C │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   C │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[4], 52)          }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[5], 52)          }    D │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   D │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[6], 52)          }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[7], 52)          }    E │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   E │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[8], 52)          }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[9], 52)          }    F │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   F │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[10], 52)         }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[11], 52)         }    G │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   G │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[12], 52)         }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[13], 52)         }    H │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   H │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[14], 52)         }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[15], 52)         }    I │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   I │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█ {MessagePrepareToDisplay(Messages[16], 52)         }      │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█ {MessagePrepareToDisplay(Messages[17], 52)         }    J │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   J │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                                                           │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█            Wpisz 'Quit' aby zakończyć grę                 └────────────────────────────────────────┘     └────────────────────────────────────────┘ █
█                                                                                                                                                     █
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
";
            ConsoleColor[] colors = Enumerable.Repeat(ConsoleColor.White, board.Length).ToArray();
            colors[0 + 2 + (153 * (6 + (Crosshair_y * 2))) + (63 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (6 + (Crosshair_y * 2))) + (64 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (7 + (Crosshair_y * 2))) + (63 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (7 + (Crosshair_y * 2))) + (64 - 1) + (Crosshair_x * 4)] = ConsoleColor.Red;
            for (int i = 0; i < board.Length; i++)
            {
                if (i > 0 && colors[i] != colors[i - 1]) Console.ForegroundColor = colors[i];
                Console.Write(board[i]);
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
                for (int i = 0; i < board.Length; i++)
                {
                    if (i > 0 && colors[i] != colors[i - 1])
                    {
                        j++;
                        displayPart.Add("");
                        displayPartColor.Add(colors[i]);
                    }
                    displayPart[j] += board[i];
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
    }
}
