using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022_Day15
{
    internal class Sensor
    {
        public int xPos;
        public int yPos;
        public List<int[]> noBeaconLocations;
        public int[] closestBeaconLocation;

        public Sensor(int x, int y, int[] closestBeaconLocation)
        {
            xPos = x;
            yPos = y;
            this.closestBeaconLocation = closestBeaconLocation;

            int manhattanDistance = GetDistance(closestBeaconLocation);

            noBeaconLocations = new List<int[]>();

            for (int i = 0; i <= manhattanDistance; i++)
            {
                for (int j = 0; j <= manhattanDistance; j++)
                {
                    if (GetDistance(new int [] { xPos + i, yPos + j }) <= manhattanDistance)
                    {
                        
                        noBeaconLocations.Add( new int[] { xPos + i, yPos + j });
                        if (i != 0 && j != 0)
                        noBeaconLocations.Add( new int[] { xPos - i, yPos - j });
                        if (j != 0)
                        noBeaconLocations.Add( new int[] { xPos + i, yPos - j });
                        if (i != 0)
                        noBeaconLocations.Add( new int[] { xPos - i, yPos + j });

                    }
                }
            }

            
        }

        public int GetDistance(int[] position)
        {
            int manhattanDistance =
                Math.Abs(xPos - position[0]) +
                Math.Abs(yPos - position[1]);

            return manhattanDistance;
        }

        public override string ToString()
        {
            return $"({xPos}, {yPos})";
        }

    }
}
