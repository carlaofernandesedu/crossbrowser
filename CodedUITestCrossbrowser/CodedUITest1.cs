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
    /// A classe teste ira chamar metodos da classe que representa a Pagina Web (HomePage)
    /// Basicamente deve testar 
    /// IsAt - Se o titulo da pagina que o browser carregou é o mesmo informado no metodo Title
    /// 
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        
        /// Variavel obrigatoria para poder manipular as classes que herdam do BasePage
        private IWebPage _pages;
        /// Variavel obrigatoria para poder representar os browser que será utilizado nos métodos
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

        /// <summary>
        /// Obrigatoriamente carregar o objeto _driverBrowser (representa o browser) a partir do nome do browser informado
        /// Obrigatoriamente carregar o objeto reponsavel por manipular classes que herdam do BasePage
        /// Obrigatoriamente setar a pagina inicial do projeto que está sendo testado
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
             var path = @"c:\browsers2";
            _driverBrowser = FactoryObjects<SeleniumWebFactory>.FactoryBrowser("chrome",String.Empty,path);
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
