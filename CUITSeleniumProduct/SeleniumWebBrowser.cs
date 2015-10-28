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
using System.Diagnostics; 


namespace CUITSeleniumProduct
{
    public class SeleniumWebBrowser : WebBrowser
    {

        private IWebDriver window;

        private string pathbrowser;

        private string browserName;

        private IEnumerable<int> newPids;

        public SeleniumWebBrowser() : this("firefox","","")
        {
        }

        public SeleniumWebBrowser(string name, string _pathBrowser, string homeurl)
        {
            Elements = new SeleniumWebElement();
            browserName = name;
            pathbrowser = _pathBrowser;
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
            window.Navigate().GoToUrl(url);
        }

        public override void WaitForControlReady(int milliseconds)
        {
            throw new NotImplementedException();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            // Test the autocomplete response - Explicit Wait
            //IWebElement autocomplete = wait.Until(x => x.FindElement(By.ClassName("ac-row-110457")))
        }

        public override WebBrowser Launch(Uri url)
        {
            string nomedriver = "firefoxdriver";
            IEnumerable<int> pidsBefore = null; 

            try
            {
                switch (browserName.ToLower())
                {
                    case "chrome":
                        nomedriver = "chromedriver";
                        break;
                    case "firefox":
                        nomedriver = "firefoxdriver";
                        break;
                    case "ie":
                        nomedriver = "internetexplorerdriver";
                        break;
                }
                pidsBefore = Process.GetProcessesByName(nomedriver).Select(p => p.Id);
            }
            catch { }

            
            switch (browserName.ToLower())
            {
                case "chrome":
                    window = new ChromeDriver(pathbrowser);
                    break;
                case "firefox":
                    window = new FirefoxDriver();
                    break;
                case "ie":
                    
                    var options = new InternetExplorerOptions()
                    {
                        InitialBrowserUrl = url.AbsoluteUri,
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true
                    };
                    window = new InternetExplorerDriver(pathbrowser, options);
                    break;
            }
            this.window.Url = url.AbsoluteUri;

            try
            {
                IEnumerable<int> pidsAfter = Process.GetProcessesByName(nomedriver).Select(p => p.Id);
                newPids = pidsAfter.Except(pidsBefore);
            }
            catch { }

            return this;
        }

        public override void Close(bool finalizeResource = true)
        {
            if (finalizeResource)
            {
                window.Quit();
                try
                {
                    foreach (int pid in newPids) 
                    {
                        Process.GetProcessById(pid).Kill();
                    }
                }
                catch(Exception ex)
                {
                }
            }
            else
            {
                window.Close();
            }
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

        public override dynamic FindFirstById(string typeObject, string id)
        {
            return window.FindElement(By.Id(id));
        }

        public override dynamic FindFirstByCssClass(string typeObject, string cssclass)
        {
            return window.FindElement(By.ClassName(cssclass));
        }

        public override dynamic FindFirstByName(string typeObject, string name)
        {
            return window.FindElement(By.Name(name));
        }


        public override void SendKeys(dynamic control, string value)
        {
            control.SendKeys(value);
        }
    }
}
