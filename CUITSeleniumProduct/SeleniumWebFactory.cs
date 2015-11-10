using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;
using System.IO;


namespace CUITSeleniumProduct
{
    /// <summary>
    /// Classe que fabrica os objetos Browser e Pages
    /// </summary>
    public class SeleniumWebFactory : IWebFactory
    {
        /// <summary>
        /// Metodo que retorna o browser informando o nome
        /// </summary>
        /// <param name="browser">nome do browser ie, firefox , google ou phantomjs</param>
        /// <returns>WebBrowser</returns>
        public WebBrowser getObjectBrowser(string browser)
        {
            var path = GetBrowserExePath(browser);

            return new SeleniumWebBrowser(browser,path, String.Empty);
        }

        /// <summary>
        /// Metodo que retorna o browser e setar a url inicial
        /// </summary>
        /// <param name="browser">nome do browser ie, firefox , google ou phantomjs</param>
        /// <param name="homeurl">informar a url inicial do site</param>
        /// <returns>WebBrowser</returns>
        public WebBrowser getObjectBrowser(string browser, string homeurl)
        {
            var path = GetBrowserExePath(browser);

            return new SeleniumWebBrowser(browser, path,homeurl);
        }
        /// <summary>
        /// Metodo que retorna o objeto Page responsavel por manipular as Classes que representam as paginas 
        /// </summary>
        /// <returns>IwebPage</returns>
        public IWebPage getObjectPages()
        {
            return new SeleniumPage();
        }

        private static string GetBrowserExePath(string browser)
        {
            var path = @"c:\exebrowsers";
            return path;
        }
    }
}
