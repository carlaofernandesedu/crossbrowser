using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Interfaces;
using CUITCommon.Abstracts;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;





namespace CUITSeleniumProduct
{
    public class GenericWebElement : WebElement
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
