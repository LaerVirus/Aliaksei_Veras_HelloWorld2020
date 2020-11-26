using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    class Knight
    {
        public static sbyte HealthPoints = 10;
        public static byte Vertical = 1;
        public static byte Horizontal = 1;

        public static Trap[] trap = new Trap[10];

        public static void TrapGenerate()
        {
            Random random = new Random();

            for (byte i = 0; i < 10; i++)
            {
                trap[i] = new Trap();
                bool TrapGenerateStatus = true;
                while (TrapGenerateStatus)
                {
                    trap[i].TrapHorizontal = (byte) random.Next(1, 10);
                    trap[i].TrapVertical = (byte) random.Next(1, 10);

                    byte j;

                    for (j = 0; j < i; j++)
                    {
                        if (trap[i].TrapHorizontal == trap[j].TrapHorizontal && trap[i].TrapVertical == trap[j].TrapVertical)
                        {
                            break;
                        }                        
                    }

                    if (j == i && ((trap[i].TrapHorizontal != 1 && trap[i].TrapVertical != 1) || (trap[i].TrapHorizontal != 10 && trap[i].TrapVertical != 10)))
                    {
                        TrapGenerateStatus = false;
                    }
                }
            }
        }

        public static void TrapCheck(byte Vertical, byte Horizontal)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Horizontal == trap[i].TrapHorizontal && Vertical == trap[i].TrapVertical && trap[i].ActivateStatus)
                {
                    Random random = new Random();
                    HealthPoints -= (sbyte) random.Next(1, 10);
                    if (HealthPoints < 0)
                    {
                        HealthPoints = 0;
                    }
                    trap[i].ActivateStatus = false;
                }
            }
        }

        public static void KnightRestart()
        {
            HealthPoints = 10;
            Vertical = 1;
            Horizontal = 1;
        }
                
        static bool WallCheck(int VerticalCheck, int HorizontalCheck)
        {
            if (Map.map[VerticalCheck, HorizontalCheck] == '#')
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void KnightMove()
        {
            Console.SetCursorPosition(25, 15);

            byte BuferVertical = Vertical;
            byte BuferHorizontal = Horizontal;

            switch (Console.ReadKey().Key)
            {                
                case ConsoleKey.RightArrow: 
                    if (WallCheck(Vertical, Horizontal + 1))
                    {
                        Horizontal++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (WallCheck(Vertical, Horizontal - 1))
                    {
                        Horizontal--;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (WallCheck(Vertical - 1, Horizontal))
                    {
                        Vertical--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (WallCheck(Vertical + 1, Horizontal))
                    {
                        Vertical++;
                    }
                    break;
                default:
                    Console.SetCursorPosition(25, 15);
                    Console.Write(' ');
                    break;
            }

            TrapCheck(Vertical, Horizontal);

            Console.SetCursorPosition(BuferHorizontal * 2  + 1, BuferVertical);
            Console.Write(' ');
            Console.SetCursorPosition(Horizontal * 2 + 1, Vertical);
            Console.Write('K');
        }

        public static void HealthPointsPrint()
        {
            Console.SetCursorPosition(27, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"HP {HealthPoints,2}");
            Console.ResetColor();
            Console.SetCursorPosition(25, 15);
        }
    }
}
