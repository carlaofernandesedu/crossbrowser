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
        public static IWebPage FactoryPage()
        {
            IWebFactory fabrica = new T();
            return fabrica.getObjectPages();
        }
    }
}
