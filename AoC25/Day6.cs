using System;
using System.Collections.Generic;
using System.Text;

namespace AoC25
{
    internal class Day6
    {
        public static long PartOne(string filePath)
        {
            string[][] words = ParseTokens(File.ReadAllText(filePath));
            long total = 0;
            for (int j = 0; j < words[0].Length; j++)
            {
                char op = words[^1][j][0];
                long toAdd = long.Parse(words[0][j]);
                if (op == '*')
                {
                    for (int i = 1; i < words.Length - 1; i++)
                    {
                        toAdd *= long.Parse(words[i][j]);
                    }
                }
                if (op == '+')
                {
                    for (int i = 1; i < words.Length - 1; i++)
                    {
                        toAdd += long.Parse(words[i][j]);
                    }
                }
                total += toAdd;
            }

            return 0;
        }

        public static string[][] ParseTokens(string text)
        {
            StringSplitOptions options = StringSplitOptions.TrimEntries;
            options |= StringSplitOptions.RemoveEmptyEntries;
            string[] lines = text
                .Split('\n', options );

            string[][] rows = new string[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                rows[i] = lines[i]
                    .Split(' ', options);
            }

            return rows;
        }
    }
}
