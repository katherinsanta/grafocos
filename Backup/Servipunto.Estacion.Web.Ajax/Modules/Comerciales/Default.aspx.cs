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

namespace Servipunto.Estacion.Comerciales
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
        
	
		#region Evento que Carga La Pagina
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(256, Global.Idioma);
            Label2 .Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(579, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1712, Global.Idioma);
			Session["BuscarCliente"] = null;
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
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

        protected void img1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        protected void img2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ListaPreciosDiferenciales.aspx");
        }
	}
}
