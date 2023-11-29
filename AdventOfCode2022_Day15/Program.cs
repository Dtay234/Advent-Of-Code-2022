namespace AdventOfCode2022_Day15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(
                "C:\\Users\\dante\\Advent-Of-Code-2022\\" +
                "AdventOfCode2022_Day15\\text.txt");

            /*Testing

            Sensor sensor = new Sensor(0, 0, new int[] { 1, 1 });

            Console.WriteLine(sensor.GetDistance(sensor.closestBeaconLocation));

            foreach (int[] position in sensor.noBeaconLocations)
            {
                foreach (int i in position)
                {
                    Console.Write(i + ", ");
                }
                Console.WriteLine();
            }
            */

            Sensor[] sensors = new Sensor[lines.Length];
            int count = 0;

            foreach (string line in lines)
            {
                List<int> equalsIndices = new List<int>();

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '=')
                    {
                        equalsIndices.Add(i);
                    }
                }

                int tempNumber;
                bool makingNumber = false;
                string numberString = "";
                bool parse = false;
                int x1 = 0;
                int y1 = 0;
                int x2 = 0;
                int y2 = 0;

                foreach (char c in line)
                {
                    string s = c.ToString();
                    if (s == "-")
                    {
                        makingNumber = true;
                        numberString = s;
                    }
                    else if (int.TryParse(s, out tempNumber) && makingNumber)
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
                        if (x1 == 0)
                        {
                            x1 = int.Parse(numberString);
                        }
                        else if (y1 == 0)
                        {
                            y1 = int.Parse(numberString);
                        }
                        else if (x2 == 0)
                        {
                            x2 = int.Parse(numberString);
                        }

                        parse = false;
                    }
                    if (numberString != "" && numberString != "-")
                    {
                        y2 = int.Parse(numberString);
                    }
                }

                int[] closestBeacon = new int[] { x2, y2 };

                Sensor sensor = new Sensor(x1, y1, closestBeacon);
                sensors[count] = sensor;
                count++;
            }

            List<int[]> noSensorSpots = new List<int[]>();

            foreach (Sensor sensor in sensors)
            {
                foreach (int[] position in sensor.noBeaconLocations)
                {
                    if (!noSensorSpots.Contains(position) 
                        && position != sensor.closestBeaconLocation
                        && position != new int[] { sensor.xPos, sensor.yPos})
                    {
                        noSensorSpots.Add(position);
                    }
                }
            }

            List <int[]> solutions = new List<int[]>();

            foreach (int[] position in noSensorSpots)
            {
                if (position[1] == 10)
                {
                    solutions.Add(position);
                }
            }

            Console.WriteLine(solutions.Count);
        }
    }
}