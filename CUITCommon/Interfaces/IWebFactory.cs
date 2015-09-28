using CUITCommon.Abstracts;

namespace CUITCommon.Interfaces
{
    public interface IWebFactory
    {
        WebBrowser getObjectBrowser(string browser);
        IWebPage getObjectPages();
       
    }
}
