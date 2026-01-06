using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird_Sanctuary
{
    class Sparrow : Bird, IFlyable
    {
        public Sparrow(string name, string color) : base(name, color) { }

        public void Fly()
        {
            Console.WriteLine("Sparrow is flying swiftly.");
        }
    }
}
