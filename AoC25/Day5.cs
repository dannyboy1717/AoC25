using System;
using System.Collections.Generic;
using System.Text;

namespace AoC25
{
    internal class Day5
    {
        public static long PartOne(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            string[] parts = fileText.Split("\r\n\r\n");
            string[] ranges = parts[0].Split('\n');
            string[] ingredients = parts[1].Split('\n');

            List<(long start, long end)> parsed = ParseRanges(ranges);

            long count = 0;
            foreach (string ingredient in ingredients)
            {
                long val = long.Parse(ingredient);
                if (IsInRanges(parsed, val))
                    count++;
            }

            return count;
        }

        public static List<(long start, long end)> ParseRanges(string[] ranges)
        {
            var list = new List<(long start, long end)>();

            foreach (string r in ranges)
            {
                string[] b = r.Split('-');
                long start = long.Parse(b[0]);
                long end = long.Parse(b[1]);
                list.Add((start, end));
            }

            return list;
        }

        public static bool IsInRanges(List<(long start, long end)> ranges, long value)
        {
            for (int i = 0; i < ranges.Count; i++)
            {
                var (start, end) = ranges[i];
                if (value >= start && value <= end)
                    return true;
            }

            return false;
        }

        public static long PartTwo(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            string[] parts = fileText.Split("\r\n\r\n");
            string[] ranges = parts[0].Split('\n');
            List<(long start, long end)> parsed = ParseRanges(ranges);
            parsed = MergeRanges(parsed);
            long count = 0;
            foreach ((long start, long end) in parsed)
            {
                count += (end - start + 1);
            }
            return count;
        }


        public static List<(long start, long end)> MergeRanges(
            List<(long start, long end)> ranges
        )
        {
            if (ranges.Count == 0) return new List<(long start, long end)>();

            ranges.Sort((a, b) =>
            {
                int cmp = a.start.CompareTo(b.start);
                if (cmp != 0) return cmp;
                return a.end.CompareTo(b.end);
            });

            List<(long start, long end)> merged = new List<(long start, long end)>();

            long currentStart = ranges[0].start;
            long currentEnd = ranges[0].end;

            for (int i = 1; i < ranges.Count; i++)
            {
                long start = ranges[i].start;
                long end = ranges[i].end;

                if (start <= currentEnd + 1 && end > currentEnd)
                {
                    currentEnd = end;
                }
                else
                {
                    merged.Add((currentStart, currentEnd));
                    currentStart = start;
                    currentEnd = end;
                }
            }

            merged.Add((currentStart, currentEnd));

            return merged;
        }
    }
}
