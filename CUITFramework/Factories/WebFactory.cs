using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;

namespace CUITFramework.Factories
{
    public abstract class WebFactory
    {
        public abstract WebBrowser getObjectBrowser(string browser);
        public abstract IWebPage getObjectPages();
       
    }
}
