using System;

namespace Princess
{
    class Program
    {
        static void Main(string[] args)
        {
            Map.MapGenerate();

            bool GameStatus = true;

            while (GameStatus)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Knight.TrapGenerate();
                Map.MapPrint();
                Knight.KnightRestart();

                Knight.HealthPointsPrint();
                while ((Knight.Vertical != 10 || Knight.Horizontal != 10) && Knight.HealthPoints > 0)
                {
                    Knight.KnightMove();
                    Knight.HealthPointsPrint();
                }

                Console.SetCursorPosition(1, 13);
                Console.WriteLine("Do you want to play again?");
                Console.SetCursorPosition(4, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Yes ");
                Console.ResetColor();
                Console.Write("K");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" No");
                Console.ResetColor();

                bool QuestionStatus = true;
                while (QuestionStatus)
                {
                    Console.SetCursorPosition(8, 15);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow: 
                            GameStatus = true;
                            QuestionStatus = false;
                            break;
                        case ConsoleKey.RightArrow:
                            GameStatus = false;
                            QuestionStatus = false;
                            break;
                    }
                }
            }
        }
    }
}
