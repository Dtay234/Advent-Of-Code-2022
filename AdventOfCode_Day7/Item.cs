using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day7
{
    internal class Item
    {
        public string name;
        public long size;

        public virtual long Size
        {
            get 
            { 
                return size; 
            }
            
            set { size = value; }
        }

        public Item(string name)
        {
            this.name = name;
        }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
