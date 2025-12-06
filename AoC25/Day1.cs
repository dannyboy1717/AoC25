namespace AoC25
{
    internal class Day1
    {
        public static int PartOne(string filePath)
        {
            string[] lines = Utils.ReadInputLines(filePath).ToArray();

            int position = 50;
            int finalSum = 0;
            foreach (string line in lines)
            {
                position = Rotate(line, position, out int _);
                if (position == 0)
                {
                    finalSum++;
                }
            }
            return finalSum;
        }

        public static int PartTwo(string filePath)
        {
            string[] lines = Utils.ReadInputLines(filePath).ToArray();
            int position = 50;
            int finalSum = 0;
            foreach (string line in lines)
            {
                position = Rotate(line, position, out int passes);
                finalSum += passes;
            }
            return finalSum;
        }

        public static int Mod(int a, int n) => (a % n + n) % n;

        public static int Rotate(string instruction, int position, out int passes)
        {
            bool shouldIncrement = !(position == 0);
            bool right = instruction[0] == 'R';
            Func<int, int, int> rotate = right ? (position, instr) => position + instr : (position, instr) => position - instr;
            int instrValue = int.Parse(instruction[1..]);
            if (right && position + instrValue >= 100)
            {
                passes = (position + instrValue) / 100;
            }
            else if (!right && position - instrValue <= 0)
            {
                passes = Math.Abs((position - instrValue) / 100) + (shouldIncrement ? 1 : 0);
            }
            else
            {
                passes = 0;
            }
            int rtn = Mod(rotate(position, instrValue), 100);
            return rtn;
        }
    }
}
