using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;

namespace CUITFramework.Factories
{
    public abstract class WebFactory
    {
        public abstract WebBrowser  createBrowser(string browser);
        public abstract T createPage<T>() where T: BasePage,new();
       
    }
}
