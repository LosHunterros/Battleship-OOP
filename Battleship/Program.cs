namespace Battleship
{
    internal class Program
    {
        private static Player Player1 = new Player(Config.Player1Name);
        private static Player Player2 = new Player(Config.Player2Name);
        private static Player PlayerActive;
        static void Main(string[] args)
        {
            Player1.Opponent = Player2;
            Player2.Opponent = Player1;
            PlayerActive = Player1;

            Display.Player1 = Player1;
            Display.Player2 = Player2;

            Display.Messages[0] = "Welcome to Battleships";
            Display.Write(PlayerActive);
        }
    }

    enum TextAlign
    {
        Left,
        Center,
        Right,
    }
    enum ShipState
    {
        Temporary,
        Collision,
        Ok,
        Hit,
        Sunk,
    }
    enum Orientation
    {
        Horizontal,
        Vertical,
    }
}