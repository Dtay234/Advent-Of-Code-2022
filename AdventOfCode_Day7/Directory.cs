using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day7
{
    internal class Directory : Item
    {
        public List<Item> items;
        public long size;
        //public int level;

        public Directory(string name /*int level*/) : base(name)
        { 
            items = new List<Item>();
            //this.level = level;
        }

        public override long Size 
        {
            get
            {
                long sum = 0;

                foreach (Item item in items)
                {
                    sum += item.Size;
                }

                return sum;
            }
        }


        public override string ToString()
        {
            return base.ToString() + " " + Size;
        }


    }
}
