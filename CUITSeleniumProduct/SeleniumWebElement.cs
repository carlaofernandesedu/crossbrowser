using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Interfaces;
using CUITCommon.Abstracts;
using OpenQA.Selenium;

namespace CUITSeleniumProduct
{
    public class SeleniumWebElement : WebElement
    {

        public override void Submit(dynamic objeto)
        {
            objeto.Submit();
        }

        public override void Clear(dynamic objeto)
        {
            objeto.Clear();
        }

        public override void Click(dynamic objeto)
        {
            objeto.Click();
        }
    }
}
