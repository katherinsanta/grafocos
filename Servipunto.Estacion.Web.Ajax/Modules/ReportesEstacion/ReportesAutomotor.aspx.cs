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
	public class ReportesAutomotor : System.Web.UI.Page
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
        protected System.Web.UI.WebControls.Label Label11;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
			// Put user code to initialize the page here
                Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(308, Global.Idioma);
                Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1705, Global.Idioma);
                Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1706, Global.Idioma);
                Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(311, Global.Idioma);
                Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1707, Global.Idioma);
                Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1499, Global.Idioma);
                Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(258, Global.Idioma);
                Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(622, Global.Idioma);
                Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(310, Global.Idioma);
                Label10.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1709, Global.Idioma);
                Label11.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1710, Global.Idioma);
                #region verificar session
                if (Session["Usuario"] == null)
                {
                    if (Session["Usuario"] == null)
                    {
                        Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                    }

                }
                #endregion
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,344, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
			}
			catch(Exception){}

		}

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
