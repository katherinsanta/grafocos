using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Servipunto.Estacion.Web
{
    public class Global : System.Web.HttpApplication
    {
        public static int  Idioma;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Global()
        {
            InitializeComponent();
        }

        protected void Application_Start(Object sender, EventArgs e)
        {

        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Session.Add("Usuario", null);
            Session.Add("LastReport", null);
            Servipunto.Estacion.Libreria.Aplicacion.Refresh();
            string conexion = ConfigurationSettings.AppSettings["Administ"];
            Libreria.Aplicacion.Conexion.ConnectionString = Servipunto.Libreria.Cryptography.Decrypt(conexion);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {
            Session.Add("Usuario", null);
            Session.Add("LastReport", null);
        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }

        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Idioma = int.Parse(ConfigurationSettings.AppSettings["Idioma"].ToString());
        }
        #endregion
    }
}