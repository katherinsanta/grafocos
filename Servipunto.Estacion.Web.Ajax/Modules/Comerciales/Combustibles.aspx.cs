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

namespace Servipunto.Estacion.Web.Modules.Comerciales
{
	public class Combustibles : System.Web.UI.Page
	{
		#region Secci�n de Declaraciones
		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label Display;
		protected System.Web.UI.WebControls.Label lblTitle;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblHideNombre;
        protected System.Web.UI.WebControls.Label lblHideIdCliente;		
        protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected string _id = null;
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
                    if (lblHide.Text == "")
                    {
                        lblHide.Text = Request.QueryString["Placa"];
                        //lblHideIdCliente.Text = Request.QueryString["IdCliente"];
                        //lblHideNombre.Text = Request.QueryString["NombreCliente"];

                    }
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,298, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
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
			const string modulo = "Comerciales";
			const string opcion = "Combustibles";
			bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
			bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
			bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			//Revisi�n de permiso de consulta
			if (!consultar)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}

			//Configuraci�n de Acciones
			string htmlAcciones = "";
			if (nuevo)
                this.AgregarAccion(ref htmlAcciones, "Combustible.aspx?Placa=" + Request.QueryString["Placa"], Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma));
			if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(775, Global.Idioma));

            this.AgregarAccion(ref htmlAcciones, "Automotores.aspx?IdCliente=" + EncryptText(Session["IdCliente"].ToString()) + "&IdNombreCliente=" + EncryptText(Session["NombreCliente"].ToString()), Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
			this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

			//Configuraci�n del permiso de modificaci�n
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

		#region Visualizar
		private void Visualizar()
		{
			try
			{
				this._id = DecryptText(Convert.ToString(lblHide.Text.Replace(" ","+")));
				Display.Text= "<b>Placa del Vehiculo: " + this._id + "</b>";
				Results.DataSource = new Servipunto.Estacion.Libreria.Comercial.AutoCombustibles(this._id);
				Results.DataBind();
			}
			catch(Exception ex)
			{
				SetError(ex.Message /*+ "<br><br>" + ex.StackTrace*/, false);
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
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,301, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this.lblError.Visible = true;
				this.lblError.Text = "";
				for (i = 0 ; i < aSelectedItems.Length ; i++) 
				{
					try
					{
						Libreria.Comercial.AutoCombustibles.Eliminar(
							aSelectedItems[i].Split("|".ToCharArray())[0],
							int.Parse(aSelectedItems[i].Split("|".ToCharArray())[1]));
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

		#region M�todo EncryptText
		/// <summary>
		/// encripta el dato del querystring
		/// </summary>
		/// <param name="strText">texto a encriptar</param>
		/// <returns>texto encriptado</returns>
		public string EncryptText(string strText)
		{
			return Servipunto.Libreria.Cryptography.EncryptQueryString(strText, "!#$a54?3");
		}
		#endregion

		#region M�todo DecryptText
		/// <summary>
		/// Desencripta el query string 
		/// </summary>
		/// <param name="strText">texto a desencriptar</param>
		/// <returns>texto desencriptado</returns>
		private string DecryptText(string strText)
		{	
			return Servipunto.Libreria.Cryptography.DecryptQueryString(strText, "!#$a54?3");
		}
		#endregion
	}
}
