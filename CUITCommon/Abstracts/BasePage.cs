using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace CUITCommon.Abstracts
{

    public abstract class BasePage
    {
        
        /// Representa a URL Base da pagina
        public string BaseURL = "http://localhost/";
        /// Representa o titulo da pagina
        public abstract string Title{get;}
        /// Representa o conjunto de objetos para realizar o depara entre objetos do html e objetos da pagina
        protected List<ParameterProp> _parametros;
        /// Metodo responsavel por carrega os controles aplicando o depara parametrizado no lista Parametros
        public abstract List<ParameterProp> ConfigureParameters();

        /// Objeto que representar o Browser. Por essa variavel podera acessar os metodos comuns de uso do browser
        public WebBrowser CurrentBrowser { get; set; }

        /// <summary>
        /// Construtor padrao
        /// </summary>
        public BasePage()
        {
            this.ConstructUrl();
            this.ConfigureParameters();
        }
        /// <summary>
        /// Construtor informar a url base
        /// </summary>
        /// <param name="baseurl">url base</param>
        public BasePage(string baseurl)
        {
            this.BaseURL = baseurl;
            this.ConstructUrl();
            this.ConfigureParameters();
        }

        /// <summary>
        /// Constroi a URL Derivada da Base
        /// </summary>
        /// <returns></returns>
        public abstract Uri ConstructUrl();
        /// <summary>
        /// Carrega dinamicamente cada um dos controles da lista da variavel _parametros a partir do depara
        /// </summary>
        /// <returns></returns>
        public virtual bool IsValidPageDisplayed()
        {
            foreach (var parametro in _parametros)
            {
                var control = this.CurrentBrowser.FindFirstById(parametro.ControlType, parametro.ControlId);
                FieldInfo fieldInfo = this.GetType().GetField(parametro.PropName);
                fieldInfo.SetValue(this, control);
            }
            return true;
        }
        /// <summary>
        /// Navigate to the specyfic URL by using current browser window.
        /// </summary>
        /// <typeparam name="T">Type of the page.</typeparam>
        /// <returns>Created page object.</returns>
        public bool IsAt()
        {
            return this.CurrentBrowser.Title().Contains(Title);
        }
     }
}
