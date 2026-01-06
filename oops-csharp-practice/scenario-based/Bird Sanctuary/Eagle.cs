using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird_Sanctuary
{
    class Eagle : Bird, IFlyable
    {
        public Eagle(string name, string color) : base(name, color) { }

        public void Fly()
        {
            Console.WriteLine("Eagle is flying high in the sky.");
        }
    }
}
