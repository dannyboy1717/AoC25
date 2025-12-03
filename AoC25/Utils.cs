using System;
using System.Collections.Generic;
using System.Text;

namespace AoC25
{
    public class Utils
    {
        public static IEnumerable<string> ReadInputLines(string filePath)
        {
            return File.ReadAllText(filePath).Split('\n');
        }
    }
}
