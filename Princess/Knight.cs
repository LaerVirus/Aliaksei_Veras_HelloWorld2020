using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    public class Knight
    {
        public const sbyte MaxHealthPoints = 10;

        public static sbyte HealthPoints { get; set; }
        public static byte Vertical { get; set; }
        public static byte Horizontal { get; set; }

        public Knight()
        {
            HealthPoints = MaxHealthPoints;
            Vertical = GameField.WallSize;
            Horizontal = GameField.WallSize;
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

            Game.CheckTrap(Knight.Vertical, Knight.Horizontal);

            Console.SetCursorPosition(BuferHorizontal * 2 + GameField.WallSize, BuferVertical);
            Console.Write(' ');
            Console.SetCursorPosition(Knight.Horizontal * 2 + GameField.WallSize, Knight.Vertical);
            Console.Write('K');

            PrintKnightHealthPoints();
        }

        public static void PrintKnightHealthPoints()
        {
            Console.SetCursorPosition(2 * (GameField.FieldSize + 2 * GameField.WallSize) + 2, (GameField.FieldSize + 2 * GameField.WallSize) / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"HP {Knight.HealthPoints,2}");
            Console.ResetColor();
            Console.SetCursorPosition(2 * GameField.FieldSize, 2 * GameField.FieldSize);
        }
    }
}
