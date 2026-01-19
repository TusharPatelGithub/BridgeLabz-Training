using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser_Buddy
{
    class HistoryNode //making a node class for the tabs
    {
        public string url;
        public HistoryNode prev;
        public HistoryNode next;
        public HistoryNode(string url) //constructor
        {
            this.url = url;
            prev = null;
            next = null;
        }
    }
}
