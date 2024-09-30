using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Dungeon
{
    internal class Dice
    {
        private static Random random = new Random();

        private static int OneDice(int side)
        {
            return random.Next(1, side + 1);
        }

        public static int Roll(int dicenum, int sides)
        {
            int total = 0;
            for (int i = 0; i < dicenum; i++)
            {
                total += OneDice(sides);
            }
            return total;
        }
    }
}
