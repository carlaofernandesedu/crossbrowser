using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;
using CUITFramework.Factories;
using CodedUITestCrossbrowser.Pages;
using CUITSeleniumProduct;
using CUITGenericProduct;
using System.IO;



namespace CodedUITestCrossbrowser
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        private IWebPage _pages;

        private CUITCommon.Abstracts.WebBrowser _driverBrowser;
        
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestIrparaHomePage()
        {
            HomePage page = _pages.Launch<HomePage>(_driverBrowser);
            Assert.IsTrue(page.IsAt());
            _pages.Unload(page);
        }

        [TestMethod]
        public void CodedUITestLogarNoSistema()
        {
            HomePage page = _pages.Launch<HomePage>(_driverBrowser);
            Assert.IsTrue(page.LogarNoSistema("xxxx","5555"));
            _pages.Unload(page);
        }

        

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {

            _driverBrowser = FactoryObjects<SeleniumWebFactory>.FactoryBrowser("phantomjs");
            _pages = FactoryObjects<SeleniumWebFactory>.FactoryPage();
            _pages.SetBaseURl("http://drhunet.edunet.sp.gov.br/portalnet");
            
        }

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
