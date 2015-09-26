
namespace CUITCommon.Abstracts
{
    using Microsoft.VisualStudio.TestTools.UITesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
   
     
    public abstract class BasePage
    {
        protected const string BaseURL = "https://www.facebook.com/";

        /// <summary>
        /// Gets URL address of the current page.
        /// </summary>
        public Uri PageUrl
        {
            get;
            protected set;
        }
        /// <summary>
        /// Current broser window.
        /// </summary>
        public WebBrowser CurrentBrowser { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BasePage()
        {
            this.ConstructUrl();
        }

        /// <summary>
        /// Builds derived page URL based on the BaseURL and specyfic page URL.
        /// </summary>
        /// <returns></returns>
        public abstract Uri ConstructUrl();
        /// <summary>
        /// Veryfies derived page is displayed correctly.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValidPageDisplayed();
        /// <summary>
        /// Navigate to the specyfic URL by using current browser window.
        /// </summary>
        /// <typeparam name="T">Type of the page.</typeparam>
        /// <returns>Created page object.</returns>
     }
}
