using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servipunto.Estacion.Web;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Reportes
{
    /// <summary>
    /// Summary description for _Default.
    /// </summary>
    public class ReportesGenerales : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.Label Label12;
        protected System.Web.UI.WebControls.Label Label13;
        protected System.Web.UI.WebControls.Label Label14;
        protected System.Web.UI.WebControls.Label Label15;
        protected System.Web.UI.WebControls.Label Label16;
        protected System.Web.UI.WebControls.Label Label17;
        protected System.Web.UI.WebControls.Label Label18;
        protected System.Web.UI.WebControls.Label Label19;
        protected System.Web.UI.WebControls.Label Label20;
        protected System.Web.UI.WebControls.Label Label21;
        protected System.Web.UI.WebControls.Label Label1;

        private void Page_Load(object sender, System.EventArgs e)
        {
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
            try
            {
                if (!IsPostBack)
                    Traducir();
                // Put user code to initialize the page here
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 318, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                
            }
            catch (Exception) { }

        }
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2312, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(18, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2313, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2314, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(19, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2315, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(24, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2316, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(20, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2317, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(25, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2318, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(21, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2319, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(26, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2320, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(22, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2321, Global.Idioma);
            Label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(143, Global.Idioma);
            Label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2322, Global.Idioma);

        }
        #endregion
        #region SetError
        private void SetError(string message)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
