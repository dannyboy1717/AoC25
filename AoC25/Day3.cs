using System;
using System.Collections.Generic;
using System.Text;

namespace AoC25
{
    internal class Day3
    {
        public static long PartOne(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            long total = 0;
            foreach (string line in lines)
            {
                total += GetMaxJoltage(line);
            }
            return total;
        }

        public static long GetMaxJoltage(string bank)
        {
            char[] bankChars = bank.ToCharArray();
            int[] joltages = bankChars.Select(c => int.Parse(c.ToString())).ToArray();
            int max = joltages.Max();
            if (joltages.IndexOf(max) == joltages.Length - 1)
            {
                max = joltages.Take(joltages.Length - 1).Max();
            }
            joltages = joltages.Skip(bank.IndexOf(max.ToString()) + 1).ToArray();
            int secondMax = joltages.Max();
            return long.Parse(max.ToString() + secondMax.ToString());
        }

        public static long PartTwo(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            long total = 0;
            foreach (string line in lines)
            {
                total += GetMaxJoltagePartTwo(line);
            }
            return total;
        }

        public static long GetMaxJoltagePartTwo(string bank)
        {
            char[] bankChars = bank.ToCharArray();
            int[] joltages = bankChars.Select(c => int.Parse(c.ToString())).ToArray();

            string maxJoltage = string.Empty;

            int remaining = 12;

            int start = 0;
            for (int picked = 0; picked < remaining; picked++)
            {
                int end = joltages.Length - (remaining - picked);
                int idx = GetMaxIndexBetweenBounds(joltages, start, end);
                maxJoltage += joltages[idx].ToString();
                start = idx + 1;
            }

            return long.Parse(maxJoltage);
        }

        public static int GetMaxIndexBetweenBounds(int[] joltages, int startIndex, int endIndex)
        {
            int maxVal = int.MinValue;
            int maxIdx = -1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (joltages[i] > maxVal)
                {
                    maxVal = joltages[i];
                    maxIdx = i;
                }
            }
            return maxIdx;
        }
    }
}
