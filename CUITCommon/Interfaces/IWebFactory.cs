using CUITCommon.Abstracts;

namespace CUITCommon.Interfaces
{
    public interface IWebFactory
    {
        WebBrowser getObjectBrowser(string browser);

        WebBrowser getObjectBrowser(string browser, string homeurl,string path);

        WebBrowser getObjectBrowser(string browser,string homeurl);
        IWebPage getObjectPages();
       
    }
}
