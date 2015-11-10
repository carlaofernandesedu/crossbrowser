using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUITCommon;
using CUITCommon.Abstracts;
using CUITCommon.Interfaces;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUITestCrossbrowser.Pages
{
    /// <summary>
    /// Classe que Representa a pagina Inicial do Site
    /// </summary>
    public class HomePage : BasePage 
    {

        
        /// <summary>
        /// Deve informar o titulo da pagina que será testado
        /// </summary>
        public override string Title
        {
            get { return "Secretaria de Estado da Educação"; }
        }

        /// <summary>
        /// Informar a lista de parametros com o depara de objetos html com as variaveis declaradas na classe
        /// </summary>
        /// <returns></returns>
        public override List<ParameterProp> ConfigureParameters() 
        {
                _parametros = new List<ParameterProp>();
                _parametros.Add(new ParameterProp("Usuario", "ctl00_ContentPlaceHolder1_txtUsuario"));
                _parametros.Add(new ParameterProp("Password", "ctl00_ContentPlaceHolder1_txtSenha"));
                _parametros.Add(new ParameterProp("btnLogar", "ctl00_ContentPlaceHolder1_btnEntrar"));
                return _parametros;
        }

        /// <summary>
        /// Deve informar a combinacao da BaseURL + url complementar. 
        /// Se a pagina for inicial informar url complementar = "".
        /// </summary>
        /// <returns></returns>
        public override Uri ConstructUrl()
        {
            string urlComplementar = "";
            return new Uri(BaseURL + urlComplementar);
        }

        #region "Controles"
        /// <summary>
        /// Deve obrigatoriamente informar para cada item adicionado na lista _parametros uma variavel publica do Tipo Dynamic com o Mesma nomenclatura
        /// Exemplo: Usuario tem o primeiro parametro Informado Usuario em
        /// _parametros.Add(new ParameterProp("Usuario", "ctl00_ContentPlaceHolder1_txtUsuario"));
        /// </summary>
        public dynamic Usuario;
        public dynamic Password;
        public dynamic btnLogar; 
        #endregion

        public bool LogarNoSistema(string usuario,string senha)
        {
            CurrentBrowser.SendKeys(Usuario, usuario);
            CurrentBrowser.SendKeys(Password, senha);
            CurrentBrowser.Elements.Click(btnLogar);
            return true;
        }

        //public override bool IsValidPageDisplayed()
        //{
        //    var usuario = _parametros.Find(x => x.PropName == "Usuario");
        //    var password = _parametros.Find(x => x.PropName == "Password");
        //    var btnlogar = _parametros.Find(x => x.PropName == "btnLogar");
        //    Usuario = this.CurrentBrowser.FindFirstById(usuario.ControlType, usuario.ControlId);
        //    Password = this.CurrentBrowser.FindFirstById(password.ControlType, password.ControlId);
        //    btnLogar = this.CurrentBrowser.FindFirstById(btnlogar.ControlType, btnlogar.ControlId);
        //    return true;
        //}
    }
}
