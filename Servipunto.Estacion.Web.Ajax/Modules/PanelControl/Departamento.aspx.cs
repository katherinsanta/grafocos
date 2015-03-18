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
	/// Descripción breve de Departamento.
	/// </summary>
	public class Departamento : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
		protected WebApplication.FormMode _mode;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected Servipunto.Estacion.Libreria.Configuracion.Departamento _objDepartamento = null;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton LinkButton2;
		protected Servipunto.Estacion.Libreria.Configuracion.Pais _objPais = null;
		protected string _id = null;
		
		#region * Event Page_Load
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
			if (Request.QueryString["IdDpto"] == null)
				this._mode = WebApplication.FormMode.New;
			else            
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit && lblHide.Text == "")
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdDpto"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                }
				this.InicializarForma();
                Traduccir();
			}
			else
				this.Guardar();
		}
		#endregion

		#region * Método de Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
				try
				{
					if (Request.UrlReferrer != null)
						this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
					else
					{
						if (this._mode == WebApplication.FormMode.Edit)
							this.lblBack.NavigateUrl = "Departamentos.aspx?IdPais=" + Request.QueryString["IdPais"].ToString();
						else
							this.lblBack.NavigateUrl = "Departamentos.aspx";
					}

					if (this._mode == WebApplication.FormMode.New)
						this.InicializarModoInsercion();
					else
						this.InicializarModoEdicion();
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
		}
		#endregion

		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Lugares";
			bool permiso;

			//string idPais = DecryptText(Convert.ToString(Request.QueryString["IdPais"].Replace(" ","+") ));
			if (Request.QueryString["IdPais"] == "1")
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}
			
			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}

			return true;
		}
		#endregion

		#region Método Inicializar Modo de Inserción
		private void InicializarModoInsercion()
		{
			if (this.ObtenerPais())
			{
				this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1144,Global.Idioma) + ": <b>" + this._objPais.Nombre + "</b>";
                this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
			}
		}
		#endregion

		#region Método Inicializar Modo de Edición
		private void InicializarModoEdicion()
		{
			if (this.ObtenerPais())
			{
				if (this.ObtenerDepartamento())
				{
					this.lblFormTitle.Text =  Libreria.Configuracion.PalabrasIdioma.Traduccion(1144,Global.Idioma)+ ":<b>" + this._objPais.Nombre +  "</b>";
					this.lblBack.NavigateUrl = "Departamentos.aspx?IdPais=" + this._objPais.IdPais.ToString();
                    this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
					this.txtNombre.Text = this._objDepartamento.Nombre;				
				}
			}
		}
		#endregion

		#region Método para Obtener un Pais
		private bool ObtenerPais()
		{
			try
			{
				
				//this._idPais = DecryptText(Convert.ToString(Request.QueryString["IdPais"].Replace(" ","+") ));
				this._objPais = Libreria.Configuracion.Paises.Obtener(Convert.ToInt32(Request.QueryString["IdPais"]));
				if (this._objPais == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._id + "]", true);
                return false;
			}
		}
		#endregion

		#region Método para Obtener un Departamento
		private bool ObtenerDepartamento()
		{
			try
			{
                this._id = lblHide.Text; // (Convert.ToString(Request.QueryString["IdDpto"].Replace(" ", "+")));
				this._objDepartamento = Libreria.Configuracion.Departamentos.Obtener(Convert.ToInt32(this._id));
				if (this._objDepartamento == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._id + "]", true);
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,165, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this.Insertar();
						Response.Redirect("Departamentos.aspx");
					}
					else
					{
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,166, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this.Modificar();
						Response.Redirect("Departamentos.aspx?IdPais=" + this._objDepartamento.IdPais);
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
					this._objDepartamento = null;
				}
			}
		}
		#endregion

		#region Método Insertar
		private void Insertar()
		{	
			this._objDepartamento = new Servipunto.Estacion.Libreria.Configuracion.Departamento();
			this._objDepartamento.IdPais = Convert.ToInt32(Request.QueryString["IdPais"]);
			this._objDepartamento.Nombre = this.txtNombre.Text.Trim();

			Libreria.Configuracion.Departamentos.Adicionar(this._objDepartamento);
		}
		#endregion

		#region Método Modificar
		private void Modificar()
		{
			if (this.ObtenerDepartamento())
			{
				this._objDepartamento.Nombre = this.txtNombre.Text.Trim();
				this._objDepartamento.Modificar();
			}
		}
		#endregion

		#region Método Validar
		private bool Validar()
		{
			this.lblError.Text = "";
			if (this.txtNombre.Text.Trim().Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
				return false;
			}
			return true;
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

		#region Método DecryptText
		/// <summary>
		/// Desencripta el query string 
		/// </summary>
		/// <param name="strText">texto a desencriptar</param>
		/// <returns>texto desencriptado</returns>
		private string DecryptText(string strText)
		{	
			return Servipunto.Libreria.Cryptography.DecryptQueryString(strText, "!#$a892q");
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
			return Servipunto.Libreria.Cryptography.EncryptQueryString(strText, "!#$a892q");
		}
		#endregion

        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1538, Global.Idioma);
        }
	}
}
