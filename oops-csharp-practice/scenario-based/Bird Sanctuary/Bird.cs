using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird_Sanctuary
{
    class Bird
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public Bird(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Bird: {Name}, Color: {Color}");
        }
    }
}
