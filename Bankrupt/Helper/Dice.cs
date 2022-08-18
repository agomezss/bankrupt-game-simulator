using System;

namespace Alessandro.Bankrupt
{
    public static class Dice
    {
        public static int Roll()
        {
            // .NET Random.Next() is From-Inclusive and To-Non-exclusive, so I had to go ultil 7 to Reach 1-6 Included Range
            return new Random().Next(1, 7);
        }
    }
}
