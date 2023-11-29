using System;
using System.Text;
using System.IO;
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode2022_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rounds = File.ReadAllLines("text.txt");

            int score = 0;

            foreach (string round in rounds) 
            {
                score += CheckScore(round);
            }

            Console.WriteLine(score);
        }

        public static int CheckScore(string round)
        {
            int score = 0;  

            switch (round.Substring(2))
            {
                case "X":
                    

                    if (round.Substring(0, 1) == "A")
                    {
                        score += 3;
                    }
                    else if (round.Substring(0, 1) == "C")
                    {
                        score += 2;
                    }
                    else
                    {
                        score += 1;
                    }
                    break;
                case "Y":
                    score += 3;

                    if (round.Substring(0, 1) == "B")
                    {
                        score += 2;
                    }
                    else if (round.Substring(0, 1) == "A")
                    {
                        score += 1;
                    }
                    else
                    {
                        score += 3;
                    }
                    break;
                case "Z":
                    score += 6;

                    if (round.Substring(0, 1) == "C")
                    {
                        score += 1;
                    }
                    else if (round.Substring(0, 1) == "B")
                    {
                        score += 3;
                    }
                    else
                    {
                        score += 2;
                    }
                    break;
            }

            return score;
            
        }
    }
}