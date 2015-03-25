using System;
using System.Text;

namespace GA1
{
    public static class Helpers
    {
        static readonly Random Rnd = new Random();

        public static string Generate64BitBinaryString()
        {
            var binaryString = new StringBuilder();

            for (var i = 0; i < 64; i++)
            {
                binaryString.Append(Rnd.Next(2));
            }

            return binaryString.ToString();
        }

        public static int GenerateRandomBit()
        {
            return Rnd.Next(2);
        }

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return Rnd.Next(minValue, maxValue);
        }
    }
}
