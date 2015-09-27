﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon.Abstracts;
using CUITFramework.Products;
using CUITCommon.Interfaces;

namespace CUITFramework.Factories
{
    public class GenericWebFactory : WebFactory 
    {
        public override  WebBrowser getObjectBrowser(string browser)
        {
            var path = GetBrowserExePath(browser);
            return new GenericWebBrowser(browser,path);
        }

        public override IWebPage getObjectPages()
        {
             return  new GenericPage();
        }

        private static string GetBrowserExePath(string browser)
        {
            var path = string.Empty;
            //var settings = Properties.Settings.Default;

            //switch (browser)
            //{
            //    case Browser.IE:
            //        path = settings.IeExePath;
            //        break;
            //    case Browser.Chrome:
            //        path = settings.ChromeExePath;
            //        break;
            //    case Browser.Firefox:
            //        path = settings.FirefoxExePath;
            //        break;
            //    case Browser.Opera:
            //        path = settings.OperaExePath;
            //        break;
            //    default:
            //        path = settings.IeExePath;
            //        break;
            //}

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new InvalidOperationException(string.Format("Path to the browser exe for {0} can not be empty.", browser.ToString()));
            }

            return path;
        }
    }
}