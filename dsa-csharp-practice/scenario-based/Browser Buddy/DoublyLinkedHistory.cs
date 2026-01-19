using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser_Buddy
{
    class DoublyLinkedHistory //making a doubly linked list class
    {
        private HistoryNode head; //using Node class 
        private HistoryNode current; //current tab variable
        public void Visit(string url)
        {
            HistoryNode newNode = new HistoryNode(url);
            if (head == null)
            {
                head = newNode;
                current = newNode;
                return;
            }
            current.next = null; //clear forward history
            newNode.prev = current;
            current.next = newNode;
            current = newNode;
        }
        public void Back()
        {
            if (current != null && current.prev != null)
            {
                current = current.prev;
            }
            else
                Console.WriteLine("no prev page.");
        }
        public void Forward()
        {
            if (current != null && current.next != null)
                current = current.next;
            else
                Console.WriteLine("no forward page.");
        }
        public string GetCurrentPage()
        {
            return current != null ? current.url : "no page";
        }
    }
}
