using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    public class Messeges
    {
        public static bool RequestRestart(bool GameResult)
        {
            Console.Clear();

            if (GameResult)
            {
                Console.WriteLine("Oh, you win. My congratulations.");
            }
            else
            {
                Console.WriteLine("You lose.");
            }

            Console.WriteLine();

            do
            {
                Console.WriteLine("Do you want to play again?");
                string Answer = Console.ReadLine();
                switch (Answer)
                {
                    case "YES":
                    case "Yes":
                    case "yes":
                        return true;
                    case "NO":
                    case "No":
                    case "no":
                        return false;
                }
            }
            while (true);
        }
    }
}
