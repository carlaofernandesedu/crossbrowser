using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUITestCrossbrowser.Pages
{
    public class HomePage : BasePage 
    {

        public override string Title
        {
            get { return "Secretaria de Estado da Educação"; }
        }

        public override Uri ConstructUrl()
        {
            return new Uri(BaseURL);
        }

        public override bool IsValidPageDisplayed()
        {
            var objeto = this.CurrentBrowser.FindElementsById(null,"ctl00_ContentPlaceHolder1_txtUsuario");
            return true;
        }
    }
}
