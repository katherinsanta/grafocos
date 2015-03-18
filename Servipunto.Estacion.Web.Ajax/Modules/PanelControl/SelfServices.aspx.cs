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
	/// Descripción breve de SelfServices.
	/// </summary>
	public class SelfServices : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;

		#endregion
	
		#region Page Load Event
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
			if (!this.Page.IsPostBack) 
			{
				if (this.VerificarPermisos())
					this.Visualizar();
			}
			else
			{
				this.Eliminar();
			}
		}
		#endregion

		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Selfservice";
			bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
			bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
			bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			//Revisión de permiso de consulta
			if (!consultar)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}

			//Configuración de Acciones
			string htmlAcciones = "";
			if (nuevo)
                this.AgregarAccion(ref htmlAcciones, "Selfservice.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1490, Global.Idioma));
			if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1122, Global.Idioma));

            this.AgregarAccion(ref htmlAcciones, "Default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
			this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

			//Configuración del permiso de modificación
			if (modificar)
				this.HiddenUpdate.Value = "Allow";
			else
				this.HiddenUpdate.Value = "Deny";

			return true;
		}

		private void AgregarAccion(ref string currentHtml, string hRef, string title)
		{
			currentHtml += currentHtml.Length==0?"":"&nbsp;|&nbsp;";
			currentHtml += "<a href='" + hRef + "'>" + title + "</a>";
		}
		#endregion

		#region Método Visualizar
		private void Visualizar()
		{
			try
			{
				Libreria.Configuracion.Selfservices objSelfservices = new Libreria.Configuracion.Selfservices();
				Results.DataSource = objSelfservices;
				Results.DataBind();
				objSelfservices = null;
			}
			catch(Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, true);
                
			}
		}
		#endregion

		#region Método Eliminar
		private void Eliminar()
		{
			if (Request.Form["chkID"] != null)
			{
				int i;
				string [] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());

				this.lblError.Visible = true;
				this.lblError.Text = "";
				for (i = 0; i <= aSelectedItems.Length-1; i++) 
				{
					try
					{
						Libreria.Configuracion.Selfservices.Eliminar(Convert.ToInt16(aSelectedItems[i]));
					}
					catch (Exception ex)
					{
						this.lblError.Text = this.lblError.Text + ex.Message + " <br>";
					}
				}
				this.Visualizar();
			}
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

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
