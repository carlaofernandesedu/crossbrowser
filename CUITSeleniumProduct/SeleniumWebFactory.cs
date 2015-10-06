using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;


namespace CUITSeleniumProduct
{
    public class SeleniumWebFactory : IWebFactory
    {
        public WebBrowser getObjectBrowser(string browser)
        {
            return new SeleniumWebBrowser(browser);
        }
        public IWebPage getObjectPages()
        {
            return new SeleniumPage();
        }
    }
}
