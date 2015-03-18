using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Servipunto.Estacion.Web;

namespace Servipunto.Estacion.Reportes
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Label lblConductor;
        protected System.Web.UI.WebControls.Panel pnlForm;
	
		#region Evento que Carga La Pagina
		private void Page_Load(object sender, System.EventArgs e)
		{
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(8,Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1023,Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(10,Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(256,Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(307,Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(239,Global.Idioma);
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(384,Global.Idioma);
            Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(419,Global.Idioma);
            Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(16,Global.Idioma);
            Label10.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1711, Global.Idioma);
            lblConductor.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(23725, Global.Idioma);
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
			// Put user code to initialize the page here
		}

		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Default";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Default");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);                
				return false;
			}
			
			return true;
		}
		#endregion

        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.pnlForm.Visible = false;

        }

        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
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
