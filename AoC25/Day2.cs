using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AoC25
{
    internal class Day2
    {
        public static bool IsValid(string id)
        {
            if (id.Length % 2 != 0) return false;
            if (id.Take(id.Length / 2).SequenceEqual(id.Skip(id.Length / 2))) return true;
            return false;
        }

        public static long PartOne(string filePath)
        {
            string file = File.ReadAllText(filePath);
            string[] ids = file.Split(',');
            long validSum = 0;
            foreach (string id in ids)
            {
                string[] numbers = id.Split('-');
                for (long i = long.Parse(numbers[0]); i <= long.Parse(numbers[1]); i++)
                {
                    if (IsValid(i.ToString())) validSum += i;
                }
            }
            
            return validSum;
        }

        public static bool IsValidPartTwo(string id)
        {
            for (int len = 1; len <= id.Length / 2; len++)
            {
                if (CheckStringPart(id, id.Substring(0, len))) return true;
            }
            return false;
        }

        public static bool CheckStringPart(string id, string part)
        {
            for (int i = 0; i < id.Length; i += part.Length)
            {
                if (i + part.Length > id.Length) return false;
                if (id.Substring(i, part.Length) != part) return false;
            }
            return true;
        }

        public static long PartTwo(string filePath)
        {
            string file = File.ReadAllText(filePath);
            string[] ids = file.Split(',');
            long validSum = 0;
            foreach (string id in ids)
            {
                string[] numbers = id.Split('-');
                for (long i = long.Parse(numbers[0]); i <= long.Parse(numbers[1]); i++)
                {
                    if (IsValidPartTwo(i.ToString())) validSum += i;
                }
            }

            return validSum;
        }
    }
}
