namespace Battleship
{
    internal class Program
    {
        private static Player Player1 = new Player();
        private static Player Player2 = new Player();
        private static Player PlayerActive;
        static void Main(string[] args)
        {
            Player1.Opponent = Player2;
            Player2.Opponent = Player1;
            PlayerActive = Player1;

            Display.Player1 = Player1;
            Display.Player2 = Player2;

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
        Ok,
        Hit,
        Sunk,
    }
}