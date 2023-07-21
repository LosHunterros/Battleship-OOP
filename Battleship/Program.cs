namespace Battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string board = @"
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
█                                                                                                                                                     █
█       █▀▌  █  ▀█▀ ▀█▀ █  █▀▀ ▐▀█ █ █ █ ██▄ ▐▀█                      Player 1 - Człowiek                            Player 2 - Człowiek              █
█       █▄█ ▐ ▌  █   █  █  █   █▄  █▄█ █ █ █ █▄                                                                                                       █
█       █ █ █▄█  █   █  █  █▀   ▀█ █▀█ █ █▀▀  ▀█               1   2   3   4   5   6   7   8   9  10          1   2   3   4   5   6   7   8   9  10   █
█       █▄▌ █ █  █   █  ██ █▄▄ █▄▌ █ █ █ █   █▄▌            ┌────────────────────────────────────────┐     ┌────────────────────────────────────────┐ █
█                                                         A │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   A │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                                                           │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█                                                         B │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   B │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                 W grze uczestniczą:                       │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█                                                         C │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   C │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                Player 1 jako Człowiek                     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█                Player 2 jako Człowiek                   D │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   D │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                                                           │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█               Poziom trudności: Trudny                  E │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   E │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                                                           │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█                                                         F │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   F │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                        Menu:                              │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█                                                         G │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   G │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                       1. Graj                             │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█          2. Zmień ustawienia dla: Player 1              H │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   H │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█          3. Zmień ustawienia dla: Player 2                │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█              4. Zmień poziom trudności                  I │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   I │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                                                           │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█                                                         J │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │   J │ ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐  ┌┐ │ █
█                                                           │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │     │ └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘  └┘ │ █
█            Wpisz 'Quit' aby zakończyć grę                 └────────────────────────────────────────┘     └────────────────────────────────────────┘ █
█                                                                                                                                                     █
▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
";
            ConsoleColor[] colors = Enumerable.Repeat(ConsoleColor.White, board.Length).ToArray();
            int crosshair_x = 0;
            int crosshair_y = 0;
            colors[0 + 2 + (153 * (6 + (crosshair_y*2))) + (63 - 1) + (crosshair_x*4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (6 + (crosshair_y*2))) + (64 - 1) + (crosshair_x*4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (7 + (crosshair_y*2))) + (63 - 1) + (crosshair_x*4)] = ConsoleColor.Red;
            colors[0 + 2 + (153 * (7 + (crosshair_y*2))) + (64 - 1) + (crosshair_x*4)] = ConsoleColor.Red;
            for ( int i = 0; i < board.Length; i++)
            {
                if ( i > 0 && colors[i] != colors[i-1] ) Console.ForegroundColor = colors[i];
                Console.Write(board[i]);
            }

            ConsoleKey userKey;

            while (true)
            {
                userKey = Console.ReadKey().Key;

                switch (userKey)
                {
                    case ConsoleKey.LeftArrow:
                        crosshair_x -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        crosshair_x += 1;
                        break;
                    case ConsoleKey.UpArrow:
                        crosshair_y -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        crosshair_y += 1;
                        break;
                }

                for (int i = 0; i < colors.Length; i++) colors[i] = ConsoleColor.White;
                
                colors[0 + 2 + (153 * (6 + (crosshair_y * 2))) + (63 - 1) + (crosshair_x * 4)] = ConsoleColor.Red;
                colors[0 + 2 + (153 * (6 + (crosshair_y * 2))) + (64 - 1) + (crosshair_x * 4)] = ConsoleColor.Red;
                colors[0 + 2 + (153 * (7 + (crosshair_y * 2))) + (63 - 1) + (crosshair_x * 4)] = ConsoleColor.Red;
                colors[0 + 2 + (153 * (7 + (crosshair_y * 2))) + (64 - 1) + (crosshair_x * 4)] = ConsoleColor.Red;

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
    }
}