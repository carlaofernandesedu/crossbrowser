using System;
using CUITCommon.Abstracts;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace CUITGenericProduct
{
    public class GenericWebBrowser : WebBrowser
    {

        private BrowserWindow window;
        private string browserName;

        private string pathbrowser;

        public GenericWebBrowser() : this("ie","",String.Empty)
        {
           
        }
        
        public GenericWebBrowser(string name,string filename,String homeurl)
        {
            Elements = new GenericWebElement();
            pathbrowser = filename;
            browserName = name;
            if (!String.IsNullOrEmpty(homeurl))
            {
                this.Launch(new Uri(homeurl));
            }
            
        }
        
        public override string Title()
        {

            return window.Title;
        }


        public override void NavigateToUrl(Uri url)
        {
            window.NavigateToUrl(url);
        }

        public override void WaitForControlReady(int milliseconds)
        {
            window.WaitForControlReady();
        }

        public override WebBrowser Launch(Uri url)
        {
            BrowserWindow.CurrentBrowser = browserName;
            this.window = BrowserWindow.Launch(url);
            if (window == null)
            {
                var errorMessage = string.Format("Unable to run browser under the path: {0}", pathbrowser);
                throw new InvalidOperationException(errorMessage);
            }
            return this;
        }

        public override void Close(bool finalizeResource = true)
        {
            if (finalizeResource)
            {
                window.Dispose();
            }
            else
            {
                window.Close();
            }
        } 


        public HtmlControl Body()
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

        public override dynamic FindFirstById(string typeObject, string id)
        {
            return FindControl(typeObject, "FindById", id);
        }

        public override dynamic FindFirstByCssClass(string typeObject, string cssclass)
        {
            return FindControl(typeObject, "FindByCssClass", cssclass);
        }

        private dynamic FindControl(string typeObject,  string methodName,string value)
        {
            Type tipo = Type.GetType("Microsoft.VisualStudio.TestTools.UITesting.HtmlControls." + typeObject + ",Microsoft.VisualStudio.TestTools.UITesting,version=12.0.0.0");
            var typeOfContext = typeof(GenericWebBrowser);
            var method = typeOfContext.GetMethod(methodName);
            var genericMethod = method.MakeGenericMethod(new Type[] { tipo }); 
            return genericMethod.Invoke(this, new object[] { value }); 
        }

        public override dynamic FindFirstByName(string typeObject, string name)
        {
          throw new NotImplementedException();
        }

        public override void SendKeys(dynamic control, string value)
        {
            Keyboard.SendKeys(control, value);
        }

        public T FindById<T>(string id) where T : HtmlControl, new()
        {
            T retorno = null;
            foreach (var item in window.CurrentDocumentWindow.GetChildren())
            {
                retorno = item.FindById<T>(id);
                if (retorno != null)
                {
                    break;
                }
            }
            return retorno;
        }

        public T FindByCssClass<T>(string id) where T : HtmlControl, new()
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
