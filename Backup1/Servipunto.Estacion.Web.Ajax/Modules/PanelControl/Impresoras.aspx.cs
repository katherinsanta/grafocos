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
	public class Impresoras : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
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
				{
                    lblHide.Text = Request.QueryString["IdPos"];
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,112, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					this.Visualizar();
				}
			}
			else
			{
				this.Eliminar();
			}
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Impresoras";
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
				this.AgregarAccion(ref htmlAcciones, "Impresora.aspx?IdPos=" + Request["IdPos"] +
                    "&IdCapturador=" + Request["IdCapturador"] + "&Edit=0", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1395, Global.Idioma));
			if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1359, Global.Idioma));
			if(Request.QueryString["IdCapturador"] != null)
                this.AgregarAccion(ref htmlAcciones, "Poss.aspx?IdPos=" + Request["IdPos"] + "&IdCapturador=" + Request["IdCapturador"], Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
			else
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
			currentHtml += "<a  href='" + hRef + "'>" + title + "</a>";
		}
		#endregion

		#region Visualizar
		private void Visualizar()
		{
			Libreria.Configuracion.Impresoras objImpresoras;
			try
			{
                if (lblHide.Text == "" && Request.QueryString["IdPos"] != null && Request.QueryString["IdPos"] != "")
                    lblHide.Text = Request.QueryString["IdPos"];

                if (lblHide.Text != "")                    
                    objImpresoras = new Servipunto.Estacion.Libreria.Configuracion.Impresoras(int.Parse(lblHide.Text));

                else
                    objImpresoras = new Servipunto.Estacion.Libreria.Configuracion.Impresoras();
                

				Results.DataSource = objImpresoras;
				Results.DataBind();
			}				
			catch(Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);
                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1757, Global.Idioma) + ex.StackTrace, Libreria.Configuracion.PalabrasIdioma.Traduccion(1758, Global.Idioma));
                }
                catch (Exception exx)
                {
                    lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1760, Global.Idioma) + ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1759, Global.Idioma) + exx.Message;
                }
                #endregion   
			}

		}
		#endregion

		#region Eliminar
		private void Eliminar()
		{
			if (Request.Form["chkID"] != null)
			{
				int i;
				string [] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,115, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this.lblError.Visible = true;
				this.lblError.Text = "";
				for (i = 0; i <= aSelectedItems.Length-1; i++) 
				{
					try
					{
						Libreria.Configuracion.Impresoras.Eliminar( Convert.ToInt16(aSelectedItems[i]));
					}
					catch (Exception ex)
					{
						this.lblError.Text = this.lblError.Text + ex.Message + " <br>";

                        #region registro del log de errores
                        try
                        {
                            Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                                2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                                ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1757, Global.Idioma) + ex.StackTrace, Libreria.Configuracion.PalabrasIdioma.Traduccion(1758, Global.Idioma));
                        }
                        catch (Exception exx)
                        {
                            lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1760, Global.Idioma) + ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1759, Global.Idioma) + exx.Message;
                        }
                        #endregion   
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
