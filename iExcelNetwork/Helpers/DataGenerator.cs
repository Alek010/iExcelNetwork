using System;
using System.Collections.Generic;

namespace iExcelNetwork.Helpers
{
    public static class DataGenerator
    {
        public static List<string[]> GenerateFromToListOfNumbers(int lengthOfList, int minValue, int maxValue)
        {
            string[] from = GenerateRandomNumbers(lengthOfList, new Random(0), minValue, maxValue);
            string[] to = GenerateRandomNumbers(lengthOfList, new Random(1), minValue, maxValue);

            List<string[]> FromToList = new List<string[]>();

            for (int i = 0; i < lengthOfList; i++)
            {
                FromToList.Add(new string[] { from[i], to[i] });
            }

            FromToList.Insert(0, new string[] { "From", "To" });

            return FromToList;
        }

        private static string[] GenerateRandomNumbers(int count, Random random, int minRandomValue, int maxRandomValue)
        {
            string[] randomNumbers = new string[count];

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                int randomNumber = random.Next(minRandomValue, maxRandomValue + 1);

                randomNumbers[i] = randomNumber.ToString();
            }

            return randomNumbers;
        }
    }
}
