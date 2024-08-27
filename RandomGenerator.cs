using System;

namespace PolygonTriangulation
{
    public sealed class RandomGenerator
    {
        private static readonly RandomGenerator instance = new RandomGenerator();
        private Random random = null!;

        private RandomGenerator() { }

        public static RandomGenerator Instance => instance;

        public void SetSeed(int seed)
        {
            random = new Random(seed);
        }

        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
    }
}
