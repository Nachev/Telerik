namespace XTankWarsLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class RandomGenerator
    {
        private static Random rng = new Random();

        public static int Next(int maxRange)
        {
            return rng.Next(maxRange);
        }

        public static int Next(int minRange, int maxRange)
        {
            return rng.Next(minRange, maxRange);
        }
    }
}
