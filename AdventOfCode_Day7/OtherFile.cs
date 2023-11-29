using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day7
{
    internal class OtherFile : Item
    {
        public OtherFile(int size, string name) : base(name)
        {
            this.size = size;
        }

        public override string ToString()
        {
            return base.ToString() + size;
        }
    }
}
