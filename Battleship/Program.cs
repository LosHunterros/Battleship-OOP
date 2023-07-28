namespace Battleship
{
    internal class Program
    {
        private static Player Player1 = new Player(Config.Player1Name, Config.marginLeftPlayer1);
        private static Player Player2 = new Player(Config.Player2Name, Config.marginLeftPlayer2);
        private static Player PlayerActive;
        static void Main(string[] args)
        {
            Player1.Opponent = Player2;
            Player2.Opponent = Player1;
            PlayerActive = Player1;

            Display.Player1 = Player1;
            Display.Player2 = Player2;
            Display.PlayerActive = PlayerActive;

            PlayerActive.SetShips();
            SwitchPlayer();
            PlayerActive.SetShips();
            SwitchPlayer();
        }

        static void SwitchPlayer()
        {
            PlayerActive = PlayerActive.Opponent;
            Display.PlayerActive = PlayerActive;
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