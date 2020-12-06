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

        private static void CheckTrap(byte Vertical, byte Horizontal)
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

        private static bool CheckWall(int VerticalCheck, int HorizontalCheck)
        {
            bool CheckWall = (GameField.field[VerticalCheck, HorizontalCheck] == '#') ? (false) : (true);
            return CheckWall;
        }

        public static void MoveKnight()
        {
            Console.SetCursorPosition(2 * GameField.FieldSize, 2 * GameField.FieldSize);

            byte BuferVertical = Knight.Vertical;
            byte BuferHorizontal = Knight.Horizontal;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.RightArrow:
                    if (CheckWall(Knight.Vertical, Knight.Horizontal + 1))
                    {
                        Knight.Horizontal++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (CheckWall(Knight.Vertical, Knight.Horizontal - 1))
                    {
                        Knight.Horizontal--;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (CheckWall(Knight.Vertical - 1, Knight.Horizontal))
                    {
                        Knight.Vertical--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CheckWall(Knight.Vertical + 1, Knight.Horizontal))
                    {
                        Knight.Vertical++;
                    }
                    break;
                default:
                    Console.SetCursorPosition(2 * GameField.FieldSize, 2 * GameField.FieldSize);
                    Console.Write(' ');
                    break;
            }

            CheckTrap(Knight.Vertical, Knight.Horizontal);

            Console.SetCursorPosition(BuferHorizontal * 2 + GameField.WallSize, BuferVertical);
            Console.Write(' ');
            Console.SetCursorPosition(Knight.Horizontal * 2 + GameField.WallSize, Knight.Vertical);
            Console.Write('K');

            PrintKnightHealthPoints();
        }

        private static void PrintKnightHealthPoints()
        {
            Console.SetCursorPosition(2 * (GameField.FieldSize + 2 * GameField.WallSize) + 2, (GameField.FieldSize + 2 * GameField.WallSize) / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"HP {Knight.HealthPoints,2}");
            Console.ResetColor();
            Console.SetCursorPosition(2 * GameField.FieldSize, 2 * GameField.FieldSize);
        }

        public static void RestartGame()
        {
            Knight.HealthPoints = Knight.MaxHealthPoints;
            Knight.Vertical = GameField.WallSize;
            Knight.Horizontal = GameField.WallSize;

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            GameField.PrintField();
            PrintKnightHealthPoints();
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
