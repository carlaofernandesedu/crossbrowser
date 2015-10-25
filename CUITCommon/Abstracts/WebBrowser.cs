using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


namespace CUITCommon.Abstracts
{
    public abstract class WebBrowser
    {
        public abstract string Title();

        public abstract void NavigateToUrl(Uri url);

        public abstract void WaitForControlReady(int milliseconds);

        public abstract void Close(bool finalizeResource = true);
        
        public abstract WebBrowser Launch(Uri url);


        public abstract void ClearCookies();
        public abstract void Maximized(bool isOk = true);


        public abstract dynamic FindFirstById(string typeObject, string id);

        public abstract dynamic FindFirstByCssClass(string typeObject, string cssclass);

        public abstract dynamic FindFirstByName(string typeObject, string name);

        public abstract void SendKeys(dynamic control, string value);

        public WebElement Elements;


    }
}
