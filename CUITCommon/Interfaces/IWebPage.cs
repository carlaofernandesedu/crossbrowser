using CUITCommon.Abstracts;

namespace CUITCommon.Interfaces
{
    public interface IWebPage
    {
        /// <summary>
        /// Navigate to the specyfic URL by using current browser window.
        /// </summary>
        /// <typeparam name="T">Type of the page.</typeparam>
        /// <returns>Created page object.</returns>
        T Launch<T>(
            WebBrowser browser,
            bool clearCookies = true,
            bool maximized = true)
            where T : BasePage, new();

        T InitializePage<T>(BasePage pageroot) where T : BasePage, new();

        T NavigateTo<T>(BasePage pageroot) where T : BasePage, new();

        void SetBaseURl(string baseURL); 

        void Unload(BasePage pageroot,
            bool clearCookies=true,
            bool finalizeResourceBrowser = true);
    }
}
