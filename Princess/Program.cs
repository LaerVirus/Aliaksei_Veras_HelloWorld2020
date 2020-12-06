using System;

namespace Princess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameField gameField = new GameField();

            bool gameStatus = true;

            while (gameStatus)
            {
                Game.RestartGame();

                while ((Knight.Vertical != GameField.FieldSize || Knight.Horizontal != GameField.FieldSize) && Knight.HealthPoints > 0)
                {
                    Knight.MoveKnight();
                }

                gameStatus = (Knight.HealthPoints == 0) ? (Game.RequestRestart(false)) : (Game.RequestRestart(true));
            }
        }
    }
}
