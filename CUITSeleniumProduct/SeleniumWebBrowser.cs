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
using OpenQA.Selenium.PhantomJS;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Diagnostics; 


namespace CUITSeleniumProduct
{
    /// <summary>
    /// Classse que representa o browser. Tipos de browser suportados: Google, IE, Firefox , PhantomJS
    /// </summary>
    public class SeleniumWebBrowser : WebBrowser
    {
        /// <summary>
        /// engine do browser objeto. Por essa variavel consegue acessar o metodos do browser
        /// </summary>
        private IWebDriver window;

        /// <summary>
        /// Caminho onde deve ser está hospedado o arquivo executavel usado para simular o browser escolhido
        /// Camino padrao:  
        /// </summary>
        private string pathbrowser;

        /// <summary>
        /// nome do browser: ie, google, firefox ou phantomjs
        /// </summary>
        private string browserName;

        /// <summary>
        /// Lista do numero de processos do windows associados. 
        /// Há determinados browser que abrem um processo (command)  para poder funcionar
        /// </summary>
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
        
        /// <summary>
        /// Retorna o titulo da pagina 
        /// </summary>
        /// <returns></returns>
        public override string Title()
        {

            return window.Title;
        }

        /// <summary>
        /// Redireciona a pagina 
        /// </summary>
        /// <param name="url">url para onde deve ser direcionada a pagina</param>
        public override void NavigateToUrl(Uri url)
        {
            window.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Indica que o browser será suspenso até o processo terminar para poder continuar
        /// </summary>
        /// <param name="milliseconds">milisegundos</param>
        public override void WaitForControlReady(int milliseconds)
        {
            throw new NotImplementedException();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            // Test the autocomplete response - Explicit Wait
            //IWebElement autocomplete = wait.Until(x => x.FindElement(By.ClassName("ac-row-110457")))
        }

        /// <summary>
        /// Retorna um objeto browser de acordo com o nome do browser(browsername) 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public override WebBrowser Launch(Uri url)
        {
            string nomedriver = String.Empty;
            IEnumerable<int> pidsBefore = null; 

            
            if (browserName.ToLower() != "phantomjs")
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
                case "phantomjs":
                    var service = PhantomJSDriverService.CreateDefaultService(pathbrowser);
                    window = new PhantomJSDriver(service);
                    break;
            }
            this.window.Url = url.AbsoluteUri;

            if (browserName.ToLower() != "phantomjs")
            {
                IEnumerable<int> pidsAfter = Process.GetProcessesByName(nomedriver).Select(p => p.Id);
                newPids = pidsAfter.Except(pidsBefore);
            }
            

            return this;
        }

        /// <summary>
        /// Encerrra o browser e os processos relacionados a pagina ou somente fecha a pagina
        /// </summary>
        /// <param name="finalizeResource"></param>
        public override void Close(bool finalizeResource = true)
        {
            if (finalizeResource)
            {
                window.Quit();
                try
                {
                    if (newPids != null)
                    {
                        foreach (int pid in newPids)
                        {
                            Process.GetProcessById(pid).Kill();
                        }
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
        
        /// <summary>
        /// Maximiza a pagina
        /// </summary>
        /// <param name="isOk">isOK</param>
        public override void Maximized( bool isOk = true)
        {
            if (isOk)
                window.Manage().Window.Maximize();
        }

        /// <summary>
        /// Limpar cookies do navegador
        /// </summary>
        public override void ClearCookies()
        {
            window.Manage().Cookies.DeleteAllCookies();
        }

        /// <summary>
        /// Retornar controle baseado na tag ID
        /// </summary>
        /// <param name="typeObject"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override dynamic FindFirstById(string typeObject, string id)
        {
            return window.FindElement(By.Id(id));
        }

        /// <summary>
        /// Retornar controle pesquisando pela tag cssClass
        /// </summary>
        /// <param name="typeObject"></param>
        /// <param name="cssclass"></param>
        /// <returns></returns>
        public override dynamic FindFirstByCssClass(string typeObject, string cssclass)
        {
            return window.FindElement(By.ClassName(cssclass));
        }

        /// <summary>
        /// Retornar controle pesquisando pela tag Name
        /// </summary>
        /// <param name="typeObject"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public override dynamic FindFirstByName(string typeObject, string name)
        {
            return window.FindElement(By.Name(name));
        }


        /// <summary>
        /// Preenche o controle com determinado texto 
        /// </summary>
        /// <param name="control">objeto que representa o controle</param>
        /// <param name="value">texto</param>
        public override void SendKeys(dynamic control, string value)
        {
            control.SendKeys(value);
        }
    }
}
