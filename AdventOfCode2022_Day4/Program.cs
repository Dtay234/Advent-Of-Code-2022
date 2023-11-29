namespace AdventOfCode2022_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            int containedPairs = 0;
            int overlapPairs = 0;

            foreach (string line in lines)
            {
                int seperator = line.IndexOf(',');
                string elf1 = line.Substring(0, seperator);
                string elf2 = line.Substring(seperator + 1);

                int lower1 = int.Parse(elf1.Substring(0, elf1.IndexOf('-')));
                int upper1 = int.Parse(elf1.Substring(elf1.IndexOf('-') + 1));
                int lower2 = int.Parse(elf2.Substring(0, elf2.IndexOf('-')));
                int upper2 = int.Parse(elf2.Substring(elf2.IndexOf('-') + 1));

                int range1 = upper1 - lower1;
                int range2 = upper2 - lower2;

                if (range1 > range2)
                {
                    //if (upper1 > upper2 && lower1 < lower2)
                    //{
                    //    containedPairs++;
                    //}

                    if (lower1 <= lower2 && upper1 >= upper2)
                    {
                        containedPairs++;
                    }
                }
                if (range1 <= range2)
                {
                    if (upper1 <= upper2 && lower1 >= lower2)
                    {
                        containedPairs++;
                    }
                }

                if ((lower1 >= lower2 && lower1 <= upper2)
                    || (upper1 <= upper2 && upper1 >= lower2)
                    || (lower2 <= upper1 && lower2 >= lower1) 
                    || (upper2 <= upper1 && upper2 >= lower1)
                    )
                {
                    overlapPairs++;
                }

            }

            Console.WriteLine(containedPairs);

            //Part 2

            Console.WriteLine(overlapPairs);
        }
    }
}