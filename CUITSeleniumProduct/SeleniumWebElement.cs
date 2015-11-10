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
    /// <summary>
    /// Classe que implementa os eventos associados ao controle
    /// </summary>
    public class SeleniumWebElement : WebElement
    {
        /// <summary>
        /// Dispara o acao de submit na pagina
        /// </summary>
        /// <param name="objeto">objeto que representa  o controle</param>
        public override void Submit(dynamic objeto)
        {
            objeto.Submit();
        }
        /// <summary>
        /// Dispara a acao de Limpar o Controle
        /// </summary>
        /// <param name="objeto">objeto que representa o controle</param>
        public override void Clear(dynamic objeto)
        {
            objeto.Clear();
        }

        /// <summary>
        /// Dispara a acao de Clicar o Controle
        /// </summary>
        /// <param name="objeto">objeto que representa o controle</param>
        public override void Click(dynamic objeto)
        {
            objeto.Click();
        }
    }
}
