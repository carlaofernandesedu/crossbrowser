using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Interfaces;
using CUITCommon.Abstracts;
using CUITFramework.Products;
using CUITFramework.Factories;

namespace CUITFramework
{
    public class Class1
    {
        public void Teste()
        {
            WebBrowser b = FactoryObjects<GenericWebFactory>.FactoryBrowser("ie");
            IWebPage x = FactoryObjects<GenericWebFactory>.FactoryPage();
        }
    }
}
