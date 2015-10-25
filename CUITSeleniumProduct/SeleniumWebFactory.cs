using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;
using System.IO;


namespace CUITSeleniumProduct
{
    public class SeleniumWebFactory : IWebFactory
    {
        public WebBrowser getObjectBrowser(string browser)
        {
            var path = GetBrowserExePath(browser);

            return new SeleniumWebBrowser(browser,path, String.Empty);
        }

        public WebBrowser getObjectBrowser(string browser, string homeurl)
        {
            var path = GetBrowserExePath(browser);

            return new SeleniumWebBrowser(browser, path,homeurl);
        }
        public IWebPage getObjectPages()
        {
            return new SeleniumPage();
        }

        private static string GetBrowserExePath(string browser)
        {
            var path = @"c:\exebrowsers";
            return path;
        }
    }
}
