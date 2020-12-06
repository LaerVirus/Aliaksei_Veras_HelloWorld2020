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
    }
}
