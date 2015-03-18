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
	public class Rol : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
        protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.WebControls.TextBox txtNombre;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;

		protected WebApplication.FormMode _mode;
		protected Libreria.Rol _objRol = null;
		protected string _id = null;

		#region * Page Load Event
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
			if (Request.QueryString["Id"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                }
				this.InicializarForma();
			}
			else
				this.Guardar();
		}
		#endregion
        #region Page_PreLoad Event
        /// <summary>
        /// Adaptacion de traduccion al formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PreLoad(object sender, System.EventArgs e)
        {
            Traducir();
        }
        #endregion
		#region * Método de Inicialización del Formulario
		private void InicializarForma()
		{
			try
			{
				if (this.VerificarPermisos())
				{
					//				if (Request.UrlReferrer != null)
					//					this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
					//				else
					this.lblBack.NavigateUrl = "Roles.aspx";

                    if (this._mode == WebApplication.FormMode.New)
                        this.InicializarModoInsercion();
                    else
                    {
                        
                        this.InicializarModoEdicion();
                    }

				}
			}
			catch(Exception ex)
			{
                lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message;
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
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {            
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1040, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion        
		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Roles";
			bool permiso;

			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}

			string HTMLAcciones = "";
			bool permisos = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Permisos");
			if (permisos)
			{
                this.AgregarAccion(ref HTMLAcciones, "Permisos.aspx?Id=" + Request.QueryString["Id"], Libreria.Configuracion.PalabrasIdioma.Traduccion(1044, Global.Idioma));				
			}
            this.Acciones.InnerHtml = HTMLAcciones + "<br><br>";

			return true;
		}
        #region Ajustar Permisos
        /// <summary>
        /// ajusta los permisos para la traduccion
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        /// <param name="currentHtml"></param>
        /// <param name="hRef"></param>
        /// <param name="title"></param>
        private void AgregarAccion(ref string currentHtml, string hRef, string title)
        {
            currentHtml += currentHtml.Length == 0 ? "" : "&nbsp;|&nbsp;";
            currentHtml += "<a style='color: blue' href='" + hRef + "'>" + title + "</a>";
        }
        #endregion
		#endregion

		#region Método Inicializar Modo de Inserción
		private void InicializarModoInsercion()
		{
            this.lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1039, Global.Idioma);
            this.AcceptButton.Value = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
			this.Acciones.Visible = false;
		}
		#endregion

		#region Método Inicializar Modo de Edición
		private void InicializarModoEdicion()
		{
			if (this.ObtenerElemento())
			{
				this.txtNombre.Text = this._objRol.Nombre;

				this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1073, Global.Idioma)+": <b>" + this._objRol.Nombre;;
                this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
			}
		}
		#endregion

		#region Método para Obtener una Referencia al Objeto
		private bool ObtenerElemento()
		{
			try
			{
                this._id = lblHide.Text; //DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ","+") ));
				this._objRol = Libreria.Roles.Obtener(Convert.ToByte(this._id));
				if (this._objRol == null)
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
					return false;
				}
				else
					return true;
			}
			catch (FormatException)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + " [" + this._id + "]", true);
				return false;
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

		#region Método Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
					if (this._mode == WebApplication.FormMode.New)
					{
						this.Insertar();
						Response.Redirect("Roles.aspx");
						
					}
					else
					{
						this.Modificar();
						Response.Redirect("Roles.aspx");
					}					
				}
				catch (Exception ex)
				{
					this.SetError(ex.Message, false);
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
					return;
				}
				finally 
				{
					this._objRol = null;
				}
			}
		}
		#endregion

		#region Método Insertar
		private void Insertar()
		{
			Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,11,((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
			this._objRol = new Servipunto.Estacion.Libreria.Rol();
			this._objRol.Nombre = this.txtNombre.Text.Trim();

			Libreria.Roles.Adicionar(this._objRol);
		}
		#endregion

		#region Método Modificar
		private void Modificar()
		{
			Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,12,((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
			if (this.ObtenerElemento())
			{
				this._objRol.Nombre = this.txtNombre.Text.Trim();
				this._objRol.Modificar();
			}
		}
		#endregion

		#region Método Validar
		private bool Validar()
		{
			this.lblError.Text = "";
			if (this.txtNombre.Text.Trim().Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1763, Global.Idioma), false);
				return false;
			}
			return true;
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
	}
}
