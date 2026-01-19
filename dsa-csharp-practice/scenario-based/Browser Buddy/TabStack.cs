using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser_Buddy
{
    class TabStack
    {
        private Tab top;
        public void Push(Tab tab) //push function to push current tab into stack
        {
            tab.next = top;
            top = tab;
        }
        public Tab Pop() //pop function to pop current tab from stack
        {
            if (top == null)
            {
                Console.WriteLine("no tabs to restore.");
                return null;
            }
            Tab temp = top;
            top = top.next;
            temp.next = null;
            return temp;
        }
    }
}
