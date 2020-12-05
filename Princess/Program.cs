using System;

namespace Princess
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameField.GenerateField();

            bool GameStatus = true;

            while (GameStatus)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                GameOperations.GenerateTrap();
                GameField.PrintField();
                GameOperations.RestartKnight();

                Knight.PrintHealthPoints();
                while ((Knight.Vertical != 10 || Knight.Horizontal != 10) && Knight.HealthPoints > 0)
                {
                    Knight.MoveKnight();
                    Knight.PrintHealthPoints();
                }

                GameStatus = (Knight.HealthPoints == 0) ? (GameOperations.RequestRestart(false)) : (GameOperations.RequestRestart(true));
            }
        }
    }
}
