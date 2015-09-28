using System;
using CUITCommon.Abstracts;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CUITFramework.Products
{
    public class GenericWebBrowser : WebBrowser
    {

        private BrowserWindow window;

        private string pathbrowser;

        public GenericWebBrowser() : this("ie","")
        {
           
        }
        
        public GenericWebBrowser(string nome,string filename)
        {
            pathbrowser = filename;
            BrowserWindow.CurrentBrowser = nome;
        }
        
        public override string Title()
        {

            return window.Title;
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
           T retorno = null; 
           foreach(var item in window.CurrentDocumentWindow.GetChildren())
           {
              retorno = item.FindById<T>(id);
              if (retorno!=null)
              {
                  break;
              }
           }
           return retorno;
        }

        public override T FindFirstByCssClass<T>(string id) 
        {
            T retorno = null;
            foreach (var item in window.CurrentDocumentWindow.GetChildren())
            {
                retorno = item.FindFirstByCssClass<T>(id);
                if (retorno != null)
                {
                    break;
                }
            }
            return retorno;
            
        }

        
            
    }
}
