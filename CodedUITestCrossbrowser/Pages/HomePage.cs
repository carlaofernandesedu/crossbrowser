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
    public class HomePage : BasePage 
    {

        

        public override string Title
        {
            get { return "Secretaria de Estado da Educação"; }
        }

        public override List<ParameterProp> ConfigureParameters() 
        {
                _parametros = new List<ParameterProp>();
                _parametros.Add(new ParameterProp("Usuario", "ctl00_ContentPlaceHolder1_txtUsuario", false, "HtmlEdit"));
                _parametros.Add(new ParameterProp("Password", "ctl00_ContentPlaceHolder1_txtSenha", false, "HtmlEdit"));
                _parametros.Add(new ParameterProp("btnLogar", "ctl00_ContentPlaceHolder1_btnEntrar", false, "HtmlButton"));
                return _parametros;
        }

        public override Uri ConstructUrl()
        {
            return new Uri(BaseURL);
        }

        #region "Controles"
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
