using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    public class GameField
    {
        public const byte FieldSize = 10;
        public const byte WallSize = 1;

        public static char[,] field { get; } = new char[FieldSize + 2 * WallSize, FieldSize + 2 * WallSize];

        private const char Wall = '#';

        public GameField()
        {
            for (byte i = 0; i < FieldSize + 2 * WallSize; i++)
            {
                field[0, i] = Wall;
                field[i, 0] = Wall;
                field[FieldSize + WallSize, i] = Wall;
                field[i, FieldSize + WallSize] = Wall;
            }

            for (byte i = 1; i < FieldSize + WallSize; i++)
            {
                for (byte j = 1; j < FieldSize + WallSize; j++)
                {
                    field[i, j] = ' ';
                }
            }

            field[WallSize, WallSize] = 'K';
            field[FieldSize, FieldSize] = 'P';
        }

        public static void PrintField()
        {
            for (byte i = 0; i < FieldSize + 2 * WallSize; i++)
            {
                for (byte j = 0; j < FieldSize + 2 * WallSize; j++)
                {
                    Console.Write($"{field[i, j],2}");
                }
                Console.WriteLine();
            }
        }
    }
}
