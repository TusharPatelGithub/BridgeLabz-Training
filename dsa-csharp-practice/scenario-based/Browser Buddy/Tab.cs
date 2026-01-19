using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser_Buddy
{
    class Tab
    {
        public DoublyLinkedHistory history;
        public Tab next; //used for stack linking
        public Tab()
        {
            history = new DoublyLinkedHistory();  //creating a doubly linked list
            next = null;
        }
    }
}
