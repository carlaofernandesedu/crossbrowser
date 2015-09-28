﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;

namespace CodedUITestCrossbrowser.Pages
{
    public class HomePage : BasePage 
    {

        public override string Title
        {
            get { return ""; }
        }

        public override Uri ConstructUrl()
        {
            return new Uri(BaseURL);
        }

        public override bool IsValidPageDisplayed()
        {
            return true;
        }
    }
}
