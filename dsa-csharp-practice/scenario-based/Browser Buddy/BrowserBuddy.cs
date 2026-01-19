using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Browser_Buddy
{
    class BrowserBuddy
    {
        private Tab currentTab;
        private TabStack closedTabs;
        public BrowserBuddy()
        {
            currentTab = new Tab();
            closedTabs = new TabStack();
        }
        public void VisitPage(string url)
        {
            currentTab.history.Visit(url);
            Console.WriteLine("Visited: " + url);
        }
        public void Back()
        {
            currentTab.history.Back();
            Console.WriteLine("Current pAge: " + currentTab.history.GetCurrentPage());
        }
        public void Forward()
        {
            currentTab.history.Forward();
            Console.WriteLine("Current Page: " + currentTab.history.GetCurrentPage());
        }
        public void CloseTab()
        {
            closedTabs.Push(currentTab);
            currentTab = new Tab();
            Console.WriteLine("Tab closed. new tab opened");
        }
        public void RestoreTab()
        {
            Tab restoredTab = closedTabs.Pop();
            if (restoredTab != null)
            {
                currentTab = restoredTab;
                Console.WriteLine("TAb restored.");
                Console.WriteLine("Current Page: " + currentTab.history.GetCurrentPage());
            }
        }
    }
}
