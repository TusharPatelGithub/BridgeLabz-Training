using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird_Sanctuary
{
    class Duck : Bird, ISwimmable
    {
        public Duck(string name, string color) : base(name, color) { }

        public void Swim()
        {
            Console.WriteLine("Duck is swimming in the pond.");
        }
    }

}
