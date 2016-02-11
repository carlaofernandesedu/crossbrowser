using CUITCommon.Interfaces;
using CUITCommon.Abstracts;

namespace CUITFramework.Factories
{
    public static class FactoryObjects<T> where T : IWebFactory, new()
    {
        public static WebBrowser FactoryBrowser(string browser)
        {
            IWebFactory fabrica = new T();
            return fabrica.getObjectBrowser(browser);
        }

        public static WebBrowser FactoryBrowser(string browser, string homeurl)
        {
            IWebFactory fabrica = new T();
            return fabrica.getObjectBrowser(browser,homeurl);
        }

        public static WebBrowser FactoryBrowser(string browser, string homeurl, string path)
        {
            IWebFactory fabrica = new T();
            return fabrica.getObjectBrowser(browser, homeurl,path);
        }

        public static IWebPage FactoryPage()
        {
            IWebFactory fabrica = new T();
            return fabrica.getObjectPages();
        }
    }
}
