namespace AdventOfCode2022_Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            List<List<char>> towers = new List<List<char>>();

            List<char> charList = new List<char>();

            for (int i = 0; i < 26; i++)
            {
                charList.Add((char)(i + 97));
            }
            for (int i = 0; i < 26; i++)
            {
                charList.Add((char)(i + 65));
            }

            for (int i = 0; i < 9; i++)
            {
                towers.Add(new List<char>());
            }

            for (int i = 0; i < 8; i++)
            {
                
                string columns = lines[8];

                string line = lines[7 - i];

                for (int j = 0; j < line.Length; j++)
                {
                    if (charList.Contains(line[j]))
                    {
                        int index = int.Parse(columns.Substring(j,1));

                        towers[index - 1].Add(line[j]);
                        
                        
                    }
                }
            }

            foreach (string line in lines)
            {
                if (line.Length != 0 && line[0] == 'm')
                {
                    string numberString = "";
                    int tempNumber;
                    int moveNumber = 0;
                    int moveFrom = 0;
                    int moveTo = 0;
                    bool makingNumber = false;
                    bool parse = false;


                    foreach (char c in line)
                    {
                        string s = c.ToString();

                        if (int.TryParse(s, out tempNumber) && makingNumber)
                        {
                            numberString += tempNumber.ToString();
                            
                        }
                        else if (int.TryParse(s, out tempNumber) && !makingNumber)
                        {
                            
                            numberString = tempNumber.ToString();
                            makingNumber = true;
                        }
                        else if (!int.TryParse(s, out tempNumber) && makingNumber)
                        {
                            parse = true;
                            makingNumber = false;
                        }
                        if (parse)
                        {
                            if (moveNumber == 0)
                            {
                                moveNumber = int.Parse(numberString);
                            }
                            else if (moveFrom == 0)
                            {
                                moveFrom = int.Parse(numberString);
                            }
                            else if (moveTo == 0)
                            {
                                
                            }

                            
                            parse = false;
                        }

                        if (numberString != "")
                        {
                            moveTo = int.Parse(numberString);
                        }


                    }

                    List<char> moveFromTower = towers[moveFrom - 1];
                    List<char> moveToTower = towers[moveTo - 1];

                    //for (int i = 0; i < moveNumber; i++)
                    {
                        

                        //MOVE ONE AT A TIME
                        //towers[moveTo - 1].Add(towers[moveFrom - 1].Last());
                        //towers[moveFrom - 1].RemoveAt(towers[moveFrom - 1].Count - 1);

                        
                    }
                    //MOVE MULTIPLE AT A TIME
                    int startIndex = moveFromTower.Count - moveNumber;

                    for (int i = 0; i < moveNumber; i++)
                    {
                        moveToTower.Add(moveFromTower[startIndex]);
                        moveFromTower.RemoveAt(startIndex);
                    }

                }
            }

            foreach (List<char> list in towers)
            {
                Console.Write(list.Last());
            }
        }
    }
}