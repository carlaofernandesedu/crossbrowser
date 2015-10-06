using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Interfaces;
using CUITCommon.Abstracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge; 
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


namespace CUITSeleniumProduct
{
    public class SeleniumWebBrowser : WebBrowser
    {

        private IWebDriver window;

        private string pathbrowser;

        public SeleniumWebBrowser() : this("ie","")
        {
        }

        public SeleniumWebBrowser(string nome, string filename)
        {
            switch (nome.ToLower())
            {
                case "chrome" : 
                  window = new ChromeDriver();
                  break;
                case "firefox":
                  window = new FirefoxDriver();
                  break;
                case "ie":
                  window = new InternetExplorerDriver();
                  break;
            }
        }
        
        public override string Title()
        {

            return window.Title;
        }


        public override void NavigateToUrl(Uri url)
        {
            window.Navigate().GoToUrl(url);
        }

        public override void WaitForControlReady()
        {
            throw new NotImplementedException();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            // Test the autocomplete response - Explicit Wait
            //IWebElement autocomplete = wait.Until(x => x.FindElement(By.ClassName("ac-row-110457")))
        }

        public override WebBrowser Launch(Uri url)
        {
            window.Url = url.AbsoluteUri;
            return this;
        }

        public override HtmlControl Body()
        {
            throw new NotImplementedException();
        }
        
        public override void Maximized( bool isOk = true)
        {
            if (isOk)
                window.Manage().Window.Maximize();
        }

        public override void ClearCookies()
        {
            window.Manage().Cookies.DeleteAllCookies();
        }

        public override dynamic FindElementsById(dynamic objeto, string id)
        {
            return window.FindElement(By.Id(id));
        }

        public override dynamic FindFirstByCssClass(dynamic objeto, string cssclass)
        {
            return window.FindElement(By.ClassName(cssclass));
        }

        public override dynamic FindFirstByName(dynamic objeto, string name)
        {
            return window.FindElement(By.Name(name));
        }

        public override T FindElementsById<T>(string id)
        {
            throw new NotImplementedException();
        }

        public override T FindFirstByCssClass<T>(string id)
        {
            throw new NotImplementedException();

        }
    }
}
