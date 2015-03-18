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

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
	/// <summary>
	/// Summary description for InterfazContable
	/// </summary>
	public class InterfazContable : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lblPruebaPagos;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Image img1;
        protected System.Web.UI.WebControls.Image img2;
        
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1974, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1546, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1704, Global.Idioma);
            //img1.AlternateText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1974, Global.Idioma);
            //img2.AlternateText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1975, Global.Idioma);

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
            Response.Redirect("ConfInterfazContableNew.aspx");
        }

        protected void img2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("EstructuraPlano.aspx");
        }
	}
}
