namespace AdventOfCode2022_Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> chars = new List<char>();
            string[] lines = File.ReadAllLines("text.txt");
            List<char> sharedItems = new List<char>();
            

            chars.Add('$');

            for (int i = 0; i < 26; i++)
            {
                chars.Add((char)(i + 97));
            }

            for (int i = 0; i < 26; i++) 
            {
                chars.Add((char)(i + 65));
            }

            foreach (string line in lines)
            {
                int half = line.Length / 2;
                List<char> items = sharedItems;
                string section1 = line.Substring(0, half);
                string section2 = line.Substring(half);
                //Console.WriteLine(section1);
                //Console.WriteLine(section2);

                bool added = false;

                foreach (char c in section1)
                {
                    foreach (char c2 in section2)
                    {
                        if (c == c2 && added == false)
                        {
                            added = true;
                            sharedItems.Add(c);
                        }
                    }
                }

                
            }

            int sum = 0;

            foreach (char c in sharedItems)
            {
                sum += chars.IndexOf(c);
            }

            Console.WriteLine(sum);

            //PART 2

            int sum2 = 0;

            for (int i = 0; i < lines.Length; i += 3)
            {
                List<string> group = new List<string>();

                for (int j = 0; j < 3; j++)
                {
                    group.Add(lines[i + j]);
                }

                List<char> badges = new List<char>();

                foreach (char c in chars)
                {
                    int counter = 0;

                    foreach (string rucksack in group)
                    {
                        if (rucksack.Contains(c))
                        {
                            counter++;
                        }
                    }

                    if (counter == 3)
                    {
                        badges.Add(c);
                    }
                }

                

                foreach (char c in badges)
                {
                    sum2 += chars.IndexOf(c);
                }

                

            }
            Console.WriteLine("sum: " + sum2);
        }
    }
}