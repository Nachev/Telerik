namespace QA.Framework.Core.Helpers
{
    using System;

    public static class RandomDataGenerator
    {
        private const string Letters = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
        private static readonly Random RandomGenerator = new Random();
        private static DateTime startDate = new DateTime(1990, 1, 1);
        private static Guid guid = Guid.NewGuid();

        public static string GenerateRandomString(int minNumberOfChars, int maxNumberOfChars)
        {
            int stringLength = RandomGenerator.Next(minNumberOfChars, maxNumberOfChars + 1);
            int lettersLength = Letters.Length;

            var result = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                result[i] = Letters[RandomGenerator.Next(0, lettersLength)];
            }

            return new string(result);
        }

        public static char GenerateRandomChar()
        {
            int lettersLength = Letters.Length;
            var result = new char();
            result = Letters[RandomGenerator.Next(0, lettersLength)];
            return result;
        }

        public static DateTime GenerateRandomDate()
        {
            int randomDays = RandomGenerator.Next(1, 365 * 50);

            return startDate.AddDays(randomDays);
        }

        public static DateTime GenerateRandomFutureDate()
        {
            int randomDays = RandomGenerator.Next(1, 365 * 50);

            return DateTime.Now.AddDays(randomDays);
        }

        public static DateTime GenerateRandomPastDate()
        {
            int randomDays = RandomGenerator.Next(1, 365 * 50) * (-1);

            return DateTime.Now.AddDays(randomDays);
        }

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return RandomGenerator.Next(minValue, maxValue + 1);
        }

        public static string GenerateUniqueRandomString()
        {
            var uniqueString = Convert.ToBase64String(guid.ToByteArray());

            uniqueString = uniqueString.Replace("=", string.Empty);
            uniqueString = uniqueString.Replace("+", string.Empty);

            return uniqueString;
        }

        public static string GenerateUniqueRandomUsername(int length)
        {
            var uniqueString = Guid.NewGuid().ToString("N").Substring(0, length);
            char firstLetter = GenerateRandomChar();
            uniqueString = string.Concat(firstLetter, uniqueString);

            return uniqueString;
        }
    }
}