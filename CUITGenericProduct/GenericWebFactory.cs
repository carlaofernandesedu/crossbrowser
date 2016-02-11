using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;

namespace CUITGenericProduct
{
    public class GenericWebFactory : IWebFactory 
    {

        /// <summary>
        /// Metodo que retorna o browser informando o nome e o caminho do executavel
        /// </summary>
        /// <param name="browser">nome do browser ie, firefox , google ou phantomjs</param>
        /// <param name="path">caminho do browser</param>
        /// <returns>WebBrowser</returns>
        public WebBrowser getObjectBrowser(string browser, string homeurl, string path)
        {
            if (String.IsNullOrEmpty(homeurl))
                return getObjectBrowser(browser);
            else 
                return getObjectBrowser(browser,homeurl);
        }

        public WebBrowser getObjectBrowser(string browser)
        {
            var path = GetBrowserExePath(browser);
            return new GenericWebBrowser(browser,path,string.Empty);
        }

        public WebBrowser getObjectBrowser(string browser, string homeurl)
        {
            var path = GetBrowserExePath(browser);
            return new GenericWebBrowser(browser, path, homeurl);
        }

        public IWebPage getObjectPages()
        {
             return  new GenericPage();
        }

        private static string GetBrowserExePath(string browser)
        {
            var path = browser;
            //var settings = Properties.Settings.Default;

            //switch (browser)
            //{
            //    case Browser.IE:
            //        path = settings.IeExePath;
            //        break;
            //    case Browser.Chrome:
            //        path = settings.ChromeExePath;
            //        break;
            //    case Browser.Firefox:
            //        path = settings.FirefoxExePath;
            //        break;
            //    case Browser.Opera:
            //        path = settings.OperaExePath;
            //        break;
            //    default:
            //        path = settings.IeExePath;
            //        break;
            //}

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new InvalidOperationException(string.Format("Path to the browser exe for {0} can not be empty.", browser.ToString()));
            }

            return path;
        }
    }
}
