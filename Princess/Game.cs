using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    public class Game
    {
        private const byte TrapNumber = 10;
        private const sbyte MinDamage = 1;
        private const sbyte MaxDamage = 10;

        private static Trap[] trap = new Trap[TrapNumber];

        private static void GenerateTrap()
        {
            Random random = new Random();

            for (byte i = 0; i < TrapNumber; i++)
            {
                trap[i] = new Trap();
                bool TrapGenerateStatus = true;
                while (TrapGenerateStatus)
                {
                    trap[i].Horizontal = (byte)random.Next(GameField.WallSize, GameField.FieldSize);
                    trap[i].Vertical = (byte)random.Next(GameField.WallSize, GameField.FieldSize);

                    byte j;

                    for (j = 0; j < i; j++)
                    {
                        if (trap[i].Horizontal == trap[j].Horizontal && trap[i].Vertical == trap[j].Vertical)
                        {
                            break;
                        }
                    }

                    if (j == i && ((trap[i].Horizontal != GameField.WallSize && trap[i].Vertical != GameField.WallSize) || (trap[i].Horizontal != GameField.FieldSize && trap[i].Vertical != GameField.FieldSize)))
                    {
                        TrapGenerateStatus = false;
                    }
                }
            }
        }

        public static void CheckTrap(byte Vertical, byte Horizontal)
        {
            for (int i = 0; i < TrapNumber; i++)
            {
                if (Horizontal == trap[i].Horizontal && Vertical == trap[i].Vertical && trap[i].ActivateStatus)
                {
                    Random random = new Random();
                    Knight.HealthPoints -= (sbyte)random.Next(MinDamage, MaxDamage);
                    if (Knight.HealthPoints < 0)
                    {
                        Knight.HealthPoints = 0;
                    }
                    trap[i].ActivateStatus = false;
                }
            }
        }

        public static void RestartGame()
        {
            Knight.HealthPoints = Knight.MaxHealthPoints;
            Knight.Vertical = GameField.WallSize;
            Knight.Horizontal = GameField.WallSize;

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            GameField.PrintField();
            Knight.PrintKnightHealthPoints();
            GenerateTrap();
        }

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
                string Answer = Console.ReadLine().ToLower();
                switch (Answer)
                {
                    case "yes":
                    case "+":
                    case "да":
                        return true;
                    case "no":
                    case "-":
                    case "нет":
                        return false;
                }
            }
            while (true);
        }
    }
}
