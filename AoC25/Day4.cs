using System;
using System.Collections.Generic;
using System.Text;

namespace AoC25
{
    internal class Day4
    {
        public static long PartOne(string filePath)
        {
            string[] map = File.ReadAllLines(filePath);
            long count = 0;
            ScanMap(ref map, ref count);
            return count;
        }

        public static bool ScanMap(ref string[] map, ref long count)
        {
            List<int[]> coordsToReplace = new List<int[]>();
            count = 0;
            for (int i = 0; i < map.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(map[i])) continue;
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '@' && CountAdjacentRolls(map, i, j, '@') < 4)
                    {
                        count++;
                        coordsToReplace.Add([i, j]);
                    }
                }
            }

            foreach (int[] coords in coordsToReplace)
            {
                char[] lineChars = map[coords[0]].ToCharArray();
                lineChars[coords[1]] = 'x';
                map[coords[0]] = new string(lineChars);
            }
            return true;
        }

        static int CountAdjacentRolls(string[] grid, int r, int c, char target)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int count = 0;

            int[,] dirs =
            {
                { -1, -1 }, { -1, 0 }, { -1, 1 },
                {  0, -1 },           {  0, 1 },
                {  1, -1 }, {  1, 0 }, {  1, 1 }
            };

            for (int i = 0; i < dirs.GetLength(0); i++)
            {
                int nr = r + dirs[i, 0];
                int nc = c + dirs[i, 1];

                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                {
                    if (grid[nr][nc] == target) count++;
                }
            }

            return count;
        }


        public static long PartTwo(string filePath)
        {
            string[] map = File.ReadAllLines(filePath);
            long count = -1;
            long rtn = 0;
            while (ScanMap(ref map, ref count) && count != 0)
            {
                rtn += count;
            }
            return rtn;
        }
    }
}
