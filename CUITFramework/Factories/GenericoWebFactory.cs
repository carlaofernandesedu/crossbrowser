using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITFramework.Products;
using CUITCommon.Interfaces;

namespace CUITFramework.Factories
{
    public class GenericoWebFactory : WebFactory 
    {
        public override  WebBrowser createBrowser(string browser)
        {
            return new GenericoWebBrowser(browser);
        }

        public override T createPage<T>()
        {
            IWebPage page = new GenericoPage();
            WebBrowser browser = createBrowser("ie");
            return page.Launch<T>(browser);
        }
        
    }
}
