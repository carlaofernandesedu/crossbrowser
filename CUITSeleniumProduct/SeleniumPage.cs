using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;

namespace CUITSeleniumProduct
{
    public class SeleniumPage : IWebPage
    {

        /// Indica a Base URL do site 
        private string _baseURL = String.Empty;
       /// <summary>
       /// Carrega a pagina web 
       /// </summary>
       /// <typeparam name="T">Informar o tipo da classe no qual será gerado o objeto representando a classe</typeparam>
       /// <param name="browser">Informar o browser a ser utilizado</param>
       /// <param name="clearCookies">Informar se deve excluir os cookies</param>
       /// <param name="maximized">Informar se browser deve abrir maximizado</param>
       /// <returns></returns>
        public T Launch<T>(
            WebBrowser browser,
            bool clearCookies = true,
            bool maximized = true)
            where T : BasePage, new()
        {
            T page = new T();
            page.BaseURL = this._baseURL;
            if (page.ConstructUrl() == null)
            {
                throw new InvalidOperationException("Unable to find URL for requested page.");
            }
            var window = browser.Launch(page.ConstructUrl());
            page.CurrentBrowser = window;

            if (clearCookies)
            {
                page.CurrentBrowser.ClearCookies();
            }

            window.Maximized(maximized);

            if (!page.IsValidPageDisplayed())
            {
                throw new InvalidOperationException("Invalid page is displayed.");
            }

            return page;
        }

        public T InitializePage<T>(BasePage pageroot) where T : BasePage, new()
        {
            if (pageroot.CurrentBrowser == null)
            {
                throw new InvalidOperationException("CurrentBrowser is null. Use Launch to initialize browser.");
            }
            T page = new T();
            page.CurrentBrowser = pageroot.CurrentBrowser;
            return page;
        }
        /// <summary>
        /// Redireciona a pagina origem para uma pagina destino
        /// </summary>
        /// <typeparam name="T">Informe o tipo que representa a pagina destino</typeparam>
        /// <param name="pageroot">Informe o objeto que representa a pagina origem</param>
        /// <returns></returns>
        public T NavigateTo<T>(BasePage pageroot) where T : BasePage, new()
        {
            if (pageroot.CurrentBrowser == null)
            {
                throw new InvalidOperationException("CurrentBrowser is null. Use Launch to initialize browser.");
            }
            T page = new T();
            var url = page.ConstructUrl();
            pageroot.CurrentBrowser.NavigateToUrl(url);
            //pageroot.CurrentBrowser.WaitForControlReady();
            page.CurrentBrowser = pageroot.CurrentBrowser;
            return page;
        }

        /// <summary>
        /// Seta a URLBASE da pagina
        /// </summary>
        /// <param name="baseURL"></param>
        public void SetBaseURl(string baseURL)
        {
            _baseURL = baseURL;
        }

        /// <summary>
        /// Descarrega pagina web ativa e se outros recursos se necessario
        /// </summary>
        /// <param name="pageroot">Objeto que representa a pagina web</param>
        /// <param name="clearCookies">excluir os cookies</param>
        /// <param name="finalizeResourceBrowser">fechar o browser e outros recursos</param>
        public void Unload(BasePage pageroot, bool clearCookies = true, bool finalizeResourceBrowser = true)
        {
            if (clearCookies)
                pageroot.CurrentBrowser.ClearCookies();

            pageroot.CurrentBrowser.Close(finalizeResourceBrowser);
        }
    }
}
