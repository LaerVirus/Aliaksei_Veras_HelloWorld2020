using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    public class Knight
    {
        public const sbyte MaxHealthPoints = 10;

        public static sbyte HealthPoints { get; set; } = MaxHealthPoints;
        public static byte Vertical { get; set; } = GameField.WallSize;
        public static byte Horizontal { get; set; } = GameField.WallSize;
                
        private static bool CheckWall(int VerticalCheck, int HorizontalCheck)
        {
            bool CheckWall = (GameField.field[VerticalCheck, HorizontalCheck] == '#') ? (false) : (true);
            return CheckWall;
        }

        public static void MoveKnight()
        {
            Console.SetCursorPosition(2 * GameField.FieldSize, 2 * GameField.FieldSize);

            byte BuferVertical = Vertical;
            byte BuferHorizontal = Horizontal;

            switch (Console.ReadKey().Key)
            {                
                case ConsoleKey.RightArrow: 
                    if (CheckWall(Vertical, Horizontal + 1))
                    {
                        Horizontal++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (CheckWall(Vertical, Horizontal - 1))
                    {
                        Horizontal--;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (CheckWall(Vertical - 1, Horizontal))
                    {
                        Vertical--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CheckWall(Vertical + 1, Horizontal))
                    {
                        Vertical++;
                    }
                    break;
                default:
                    Console.SetCursorPosition(2 * GameField.FieldSize, 2 * GameField.FieldSize);
                    Console.Write(' ');
                    break;
            }

            GameOperations.CheckTrap(Vertical, Horizontal);

            Console.SetCursorPosition(BuferHorizontal * 2  + GameField.WallSize, BuferVertical);
            Console.Write(' ');
            Console.SetCursorPosition(Horizontal * 2 + GameField.WallSize, Vertical);
            Console.Write('K');
        }

        public static void PrintHealthPoints()
        {
            Console.SetCursorPosition(2 * (GameField.FieldSize + 2 * GameField.WallSize) + 2, (GameField.FieldSize + 2 * GameField.WallSize) / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"HP {HealthPoints,2}");
            Console.ResetColor();
            Console.SetCursorPosition(2 * GameField.FieldSize, 2 * GameField.FieldSize);
        }
    }
}
