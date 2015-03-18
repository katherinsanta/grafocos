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
	/// Descripción breve de Ciudad.
	/// </summary>
	public class Ciudad : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.TextBox txtNombre;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Button btnCrear;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected WebApplication.FormMode _mode;
		protected Servipunto.Estacion.Libreria.Configuracion.Departamento _objDepartamento = null;
		protected Servipunto.Estacion.Libreria.Configuracion.Ciudad _objCiudad = null;
		protected string _id = null;
		protected string _idDpto = null;

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
			if (Request.QueryString["Id"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                    this.lblHide.Text = this._id;
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
						//if (this._mode == WebApplication.FormMode.Edit)
							this.lblBack.NavigateUrl = "Ciudades.aspx?IdDpto=" + Request.QueryString["IdDpto"].ToString()  +"&IdPais=" + Request.QueryString["IdPais"].ToString();
						//else				
						//	this.lblBack.NavigateUrl = "Ciudades.aspx";
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

			string idDpto = DecryptText(Convert.ToString(Request.QueryString["IdDpto"].Replace(" ","+") ));
			if (Convert.ToInt32(idDpto) <= 99)
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
			if (this.ObtenerDepartamento())
			{
				this.lblFormTitle.Text =  Libreria.Configuracion.PalabrasIdioma.Traduccion(1145, Global.Idioma) + "<b>" + this._objDepartamento.Nombre + "</b>";
                this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);//"Crear";
                btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);//"Crear";
			}
		}
		#endregion

		#region Método Inicializar Modo de Edición
		private void InicializarModoEdicion()
		{
			if (this.ObtenerDepartamento())
			{
				if (this.ObtenerElemento())
				{
					this.lblFormTitle.Text =  Libreria.Configuracion.PalabrasIdioma.Traduccion(1145, Global.Idioma) + "<b>" + this._objDepartamento.Nombre +  "</b>";
					this.lblBack.NavigateUrl = "Ciudades.aspx?IdDpto=" + Request.QueryString["IdDpto"]+"&IdPais=" + Request.QueryString["IdPais"].ToString();;
                    this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                    btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
					this.txtNombre.Text = this._objCiudad.Nombre;
				}
			}
		}
		#endregion

		#region Método para Obtener una Ciudad
		private bool ObtenerElemento()
		{
			try
			{
                this._id = lblHide.Text; // (Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
				this._objCiudad = Libreria.Configuracion.Ciudades.Obtener(this._id);
				if (this._objCiudad == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objCiudad + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objCiudad + "]", true);
                return false;
			}
		}
		#endregion

		#region Método para Obtener un Departamento
		private bool ObtenerDepartamento()
		{
			try
			{
				this._idDpto = DecryptText(Convert.ToString(Request.QueryString["IdDpto"].Replace(" ","+") ));
				this._objDepartamento = Libreria.Configuracion.Departamentos.Obtener(Convert.ToInt32(this._idDpto));
				if (this._objDepartamento == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objDepartamento + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objDepartamento + "]", true);
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
					{	Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,169, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this.Insertar();
					}
					else
					{
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,170, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this.Modificar();
					}

					Response.Redirect("Ciudades.aspx?IdDpto=" + Request.QueryString["IdDpto"].ToString()  +"&IdPais=" + Request.QueryString["IdPais"].ToString());
				}
				catch (Exception ex)
				{
					this.SetError(ex.Message, false);
					return;
				}
				finally 
				{
					this._objCiudad = null;
				}
			}
		}
		#endregion

		#region Método Insertar
		private void Insertar()
		{	
			this._objCiudad = new Servipunto.Estacion.Libreria.Configuracion.Ciudad();
			this._idDpto = DecryptText(Convert.ToString(Request.QueryString["IdDpto"].Replace(" ","+") ));
			this._objCiudad.IdDepartamento = Convert.ToInt32(this._idDpto);
			this._objCiudad.Nombre = this.txtNombre.Text.Trim();

			Libreria.Configuracion.Ciudades.Adicionar(this._objCiudad);
		}
		#endregion

		#region Método Modificar
		private void Modificar()
		{
			if (this.ObtenerElemento())
			{
				this._objCiudad.Nombre = this.txtNombre.Text.Trim();
				this._objCiudad.Modificar();
			}
		}
		#endregion

		#region Método Validar
		private bool Validar()
		{
			this.lblError.Text = "";
			if (this.txtNombre.Text.Trim().Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
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
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1726, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
        }
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion
    }
}
