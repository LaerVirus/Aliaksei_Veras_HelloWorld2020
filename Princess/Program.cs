using System;

namespace Princess
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameField gameField = new GameField();

            bool GameStatus = true;

            while (GameStatus)
            {
                Game.RestartGame();

                while ((Knight.Vertical != 10 || Knight.Horizontal != 10) && Knight.HealthPoints > 0)
                {
                    Game.MoveKnight();
                }

                GameStatus = (Knight.HealthPoints == 0) ? (Game.RequestRestart(false)) : (Game.RequestRestart(true));
            }
        }
    }
}
