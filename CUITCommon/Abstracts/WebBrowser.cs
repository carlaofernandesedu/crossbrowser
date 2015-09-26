using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    }
}
