using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Interfaces;
using CUITCommon.Abstracts;

namespace CUITFramework.Factories
{
    public static class FactoryObjects<T> where T : WebFactory, new()
    {
        public static WebBrowser FactoryBrowser(string browser)
        {
            WebFactory fabrica = new T();
            return fabrica.getObjectBrowser(browser);
        }
        public static IWebPage FactoryPage()
        {
            WebFactory fabrica = new T();
            return fabrica.getObjectPages();
        }
    }
}
