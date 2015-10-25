using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace CUITCommon.Abstracts
{

    public abstract class BasePage
    {
        public string BaseURL = "http://localhost/";
        public abstract string Title{get;}

        protected List<ParameterProp> _parametros;

        public abstract List<ParameterProp> ConfigureParameters();

        /// <summary>
        /// Gets URL address of the current page.
        /// </summary>
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
            this.ConfigureParameters();
        }

        public BasePage(string baseurl)
        {
            this.BaseURL = baseurl;
            this.ConstructUrl();
            this.ConfigureParameters();
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
        public virtual bool IsValidPageDisplayed()
        {
            foreach (var parametro in _parametros)
            {
                var control = this.CurrentBrowser.FindFirstById(parametro.ControlType, parametro.ControlId);
                FieldInfo fieldInfo = this.GetType().GetField(parametro.PropName);
                fieldInfo.SetValue(this, control);
            }
            return true;
        }
        /// <summary>
        /// Navigate to the specyfic URL by using current browser window.
        /// </summary>
        /// <typeparam name="T">Type of the page.</typeparam>
        /// <returns>Created page object.</returns>
        public bool IsAt()
        {
            return this.CurrentBrowser.Title().Contains(Title);
        }
     }
}
