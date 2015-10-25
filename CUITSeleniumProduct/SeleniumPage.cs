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
        private string _baseURL = String.Empty;
       
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


        public void SetBaseURl(string baseURL)
        {
            _baseURL = baseURL;
        }


        public void Unload(BasePage pageroot, bool clearCookies = true, bool finalizeResourceBrowser = true)
        {
            if (clearCookies)
                pageroot.CurrentBrowser.ClearCookies();

            pageroot.CurrentBrowser.Close(finalizeResourceBrowser);
        }
    }
}
