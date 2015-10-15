using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Interfaces;
using CUITCommon.Abstracts;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;





namespace CUITGenericProduct
{
    public class GenericWebElement : WebElement
    {

        public override void Submit(ref dynamic objeto)
        {
            objeto.Submit();
        }

        public override void Clear(ref dynamic objeto)
        {
            objeto.Clear();
        }

        public override void Click(ref dynamic objeto)
        {
            objeto.Click();
        }
    }
}
