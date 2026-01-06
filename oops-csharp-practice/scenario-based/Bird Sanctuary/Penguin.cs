using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird_Sanctuary
{
    class Penguin : Bird, ISwimmable
    {
        public Penguin(string name, string color) : base(name, color) { }

        public void Swim()
        {
            Console.WriteLine("Penguin is swimming in cold water.");
        }
    }

}
