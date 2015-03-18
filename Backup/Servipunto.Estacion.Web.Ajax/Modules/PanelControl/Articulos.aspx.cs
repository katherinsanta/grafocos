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
	public class Articulos : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;        
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
		#endregion
	
		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
                #region verificar session
                //if (Session["Usuario"] == null)
                //{
                //    if (Session["Usuario"] == null)
                //    {
                //        Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                //    }

                //}
                #endregion
				if (!this.Page.IsPostBack) 
				{
					if (this.VerificarPermisos())
					{
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,22, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();                       
                        this.Visualizar();
                        Traduccion();
					}
				}
				else
				{
					this.Eliminar();
				}
			}
			catch(Exception ex)
			{
				SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma)+" " + ex.Message,false);

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

		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Artículos";
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
				this.AgregarAccion(ref htmlAcciones, "Articulo.aspx", Libreria.Configuracion.PalabrasIdioma.Traduccion(1248,Global.Idioma));
			if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Libreria.Configuracion.PalabrasIdioma.Traduccion(1259, Global.Idioma));

            this.AgregarAccion(ref htmlAcciones, "Default.aspx", Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma));
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
				Libreria.Configuracion.Articulos objArticulos = new Libreria.Configuracion.Articulos();
				Results.DataSource = objArticulos;
				Results.DataBind();
				objArticulos = null;
			}
			catch(Exception ex)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1781, Global.Idioma) + ": " + ex.Message, true);
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

		#region Método Eliminar
		private void Eliminar()
		{
			if (Request.Form["chkID"] != null)
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,25, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				int i;
				string [] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());

				this.lblError.Visible = true;
				this.lblError.Text = "";
				for (i = 0; i <= aSelectedItems.Length-1; i++) 
				{
					try
					{
						Libreria.Configuracion.Articulos.Eliminar(Convert.ToInt16(aSelectedItems[i]));
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
		
		#region Método EncryptText
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

		#region Método DecryptText
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

        private void Traduccion()
        {
            /*this.Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(46, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1241, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1244, Global.Idioma);
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1245, Global.Idioma);
            Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1246, Global.Idioma);
            Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1247, Global.Idioma);*/

        }

        protected void Results_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Servipunto.Estacion.Libreria.Configuracion.Articulo dbr = (Servipunto.Estacion.Libreria.Configuracion.Articulo)e.Item.DataItem;
                if (Convert.ToString(DataBinder.Eval(dbr, "Tipo")) == "Canastilla")
                    ((Label)e.Item.FindControl("Label10")).Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(96, Global.Idioma);
                else
                    ((Label)e.Item.FindControl("Label10")).Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(526, Global.Idioma);
                if (Convert.ToString(DataBinder.Eval(dbr, "NumCuenta")) == "(sin definir)")
                    ((Label)e.Item.FindControl("Label11")).Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma);
            }


        }
	}
}
