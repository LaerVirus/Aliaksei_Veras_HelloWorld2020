using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    class Map
    {
        public static char[,] map = new char[12, 12];

        public static void MapGenerate()
        {
            for (byte i = 0; i <= 11; i++)
            {
                map[0, i] = '#';
                map[i, 0] = '#';
                map[11, i] = '#';
                map[i, 11] = '#';
            }

            for (byte i = 1; i <= 10; i++)
            {
                for (byte j = 1; j <= 10; j++)
                {
                    map[i, j] = ' ';
                }
            }

            map[1, 1] = 'K';
            map[10, 10] = 'P';
        }

        public static void MapPrint()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Console.Write($"{map[i, j],2}");
                }
                Console.WriteLine();
            }
        }
    }
}
