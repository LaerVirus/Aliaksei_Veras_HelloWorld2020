using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    public class Knight
    {
        private const sbyte MaxHealthPoints = 10;

        public static sbyte HealthPoints { get; set; } = MaxHealthPoints;
        public static byte Vertical { get; set; } = GameField.WallSize;
        public static byte Horizontal { get; set; } = GameField.WallSize;

        private const byte TrapNumber = 10;
        private const sbyte MinDamage = 1;
        private const sbyte MaxDamage = 10;

        private static Trap[] trap = new Trap[TrapNumber];

        public static void TrapGenerate()
        {
            Random random = new Random();

            for (byte i = 0; i < TrapNumber; i++)
            {
                trap[i] = new Trap();
                bool TrapGenerateStatus = true;
                while (TrapGenerateStatus)
                {
                    trap[i].Horizontal = (byte) random.Next(GameField.WallSize, GameField.FieldSize);
                    trap[i].Vertical = (byte) random.Next(GameField.WallSize, GameField.FieldSize);

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
                    HealthPoints -= (sbyte) random.Next(MinDamage, MaxDamage);
                    if (HealthPoints < 0)
                    {
                        HealthPoints = 0;
                    }
                    trap[i].ActivateStatus = false;
                }
            }
        }

        public static void RestartKnight()
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

            CheckTrap(Vertical, Horizontal);

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
