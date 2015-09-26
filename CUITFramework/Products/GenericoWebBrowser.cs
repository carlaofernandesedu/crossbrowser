using System;
using CUITCommon.Abstracts;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CUITFramework.Products
{
    public class GenericoWebBrowser : WebBrowser
    {

        private BrowserWindow window;

        private string pathbrowser;

        public GenericoWebBrowser(string nome = "ie",string filename = "")
        {
            pathbrowser = filename;
            BrowserWindow.CurrentBrowser = nome;
        }
        
        public override string Title()
        {
            
            throw new NotImplementedException();
        }


        public override void NavigateToUrl(Uri url)
        {
            window.NavigateToUrl(url);
        }

        public override void WaitForControlReady()
        {
            window.WaitForControlReady();
        }

        public override WebBrowser Launch(Uri url)
        {
            this.window = BrowserWindow.Launch(url);
            if (window == null)
            {
                var errorMessage = string.Format("Unable to run browser under the path: {0}", pathbrowser);
                throw new InvalidOperationException(errorMessage);
            }
            return this;
        }

        public override HtmlControl Body()
        {
            return (window.CurrentDocumentWindow.GetChildren()[0] as UITestControl) as HtmlControl;
        }
        
        public override void Maximized( bool isOk = true)
        {
            window.Maximized = isOk;
        }

        public override void ClearCookies()
        {
            BrowserWindow.ClearCookies();
        }

        public override T FindElementsById<T>(string id) 
        {
           var body = (window.CurrentDocumentWindow.GetChildren()[0] as UITestControl);
           return body.FindById<T>(id);
        }

        public override T FindFirstByCssClass<T>(string id) 
        {
            var body = (window.CurrentDocumentWindow.GetChildren()[0] as UITestControl);
            return body.FindFirstByCssClass<T>(id);
        }

        
            
    }
}
