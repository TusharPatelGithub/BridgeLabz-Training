using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser_Buddy
{
    class BrowserBudddyMain
    {
        public static void Main(String[] args)
        {
            BrowserBuddy browser = new BrowserBuddy();
            browser.VisitPage("google.com");
            browser.VisitPage("hackerrank.com");
            browser.VisitPage("w3schools.com");
            browser.Back(); //backing from w3schools.com page to hackerrank.com page
            browser.Back(); //backing from hacckerrank.com page to google.com page
            browser.Forward(); //going forward from google.com page to hackerrank.com page
            browser.CloseTab();//closing hackerrank page
            browser.RestoreTab();//restore hackerrank page
        }
    }
}
