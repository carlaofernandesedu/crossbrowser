using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


namespace CUITCommon.Abstracts
{
    public abstract class WebBrowser
    {
        public abstract string Title();

        public abstract void NavigateToUrl(Uri url);

        public abstract void WaitForControlReady();

        public abstract WebBrowser Launch(Uri url);

        public abstract HtmlControl Body();

        public abstract void ClearCookies();
        public abstract void Maximized(bool isOk = true);

        public abstract T FindElementsById<T>(string id) where T : HtmlControl, new();

        public abstract T FindFirstByCssClass<T>(string id) where T : HtmlControl, new();

        public abstract dynamic FindElementsById(dynamic objeto, string id);

        public abstract dynamic FindFirstByCssClass(dynamic objeto, string cssclass);

        public abstract dynamic FindFirstByName(dynamic objeto, string name);

        public WebElement Elements;


    }
}
