﻿using System;
using CUITCommon.Abstracts;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace CUITGenericProduct
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
            var genericMethod = method.MakeGenericMethod(new Type[] { tipo }); //generic metodo
            return genericMethod.Invoke(this, new object[] { value }); //objetos 
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