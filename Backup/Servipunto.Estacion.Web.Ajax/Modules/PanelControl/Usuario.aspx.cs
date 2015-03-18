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
	public class Usuario : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
		protected System.Web.UI.HtmlControls.HtmlTableCell SeccionInicializar;
		protected System.Web.UI.WebControls.TextBox txtIdUsuario;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.DropDownList cboRol;
		protected System.Web.UI.WebControls.RadioButtonList optEstado;
		protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Button btnCrear;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.LinkButton lnkInicializar;
		
		protected Libreria.Usuario _objUsuario = null;
		protected System.Web.UI.WebControls.DropDownList cboEmpleado;
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
			try
			{

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
					if (Request.Form["AcceptButton"] != null)
					this.Guardar();			
			}
			catch(Exception ex)
			{
				lblError.Text = "Error cargando el formulario: " + ex.Message;
				

				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, Convert.ToInt64(Session["IdSuceso"].ToString()),   	
						ex.Message + " !ERROR APP! " + ex.StackTrace, "Error cargando el formulario de usuarios");
				}
				catch(Exception exx)
				{
					lblError.Text= "El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
				}
				#endregion

			}

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
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1071, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1072, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1073, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1070, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1074, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1772, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1772, Global.Idioma);
            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion        
		#region * Método de Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
                
				if (Request.UrlReferrer != null)
					this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
				else
					this.lblBack.NavigateUrl = "Usuarios.aspx";

				if (this._mode == WebApplication.FormMode.New)
					this.InicializarModoInsercion();
				else
					this.InicializarModoEdicion();
			}
		}
		#endregion

		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Usuarios";
			bool permiso;

			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma);
				this.lblError.Visible = true;
				this.MyForm.Visible = false;
				return false;
			}
			
			return true;
		}
		#endregion

		#region Método Inicializar Modo de Inserción
		private void InicializarModoInsercion()
		{
            this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1064, Global.Idioma) +"</b>";
            this.AcceptButton.Value = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma); ;
            this.btnCrear.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma); ;
			this.optEstado.Enabled = false;
			this.SeccionInicializar.Visible = false;

			this.CargarRoles();
			this.CargarEmpleados();
		}
		#endregion

		#region Método Inicializar Modo de Edición
		private void InicializarModoEdicion()
		{
			if (this.ObtenerElemento())
			{
				this.CargarRoles();
				this.CargarEmpleados();

				//Visualización de Datos
				this.txtIdUsuario.Text = this._objUsuario.IdUsuario;
				this.txtNombre.Text = this._objUsuario.Nombre;
				if(this._objUsuario.IdRol == 0)
					Response.Redirect("Usuarios.aspx");
				this.cboRol.SelectedValue = this._objUsuario.IdRol.ToString();
				this.cboEmpleado.SelectedValue = this._objUsuario.CodigoEmpleado;
				this.optEstado.SelectedValue = (this._objUsuario.Estado == Libreria.EstadoUsuario.Activo?"1":"0");

				//Activación ó Desactivación de Controles
				this.txtIdUsuario.Enabled = false;
				this.SeccionInicializar.Visible = true;

                this.lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(750, Global.Idioma) +": <b>" + this._objUsuario.Nombre + " (" + this._objUsuario.IdUsuario + ")</b>";
                this.AcceptButton.Value = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma); ;
                this.btnCrear.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma); ;
			}
		}
		#endregion

		#region Método para Obtener una Referencia al Objeto
		private bool ObtenerElemento()
		{
            this._id = lblHide.Text; // (Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
			this._objUsuario = Libreria.Usuarios.Obtener(this._id);
			if (this._objUsuario == null)
			{
				this.lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma)+"[" + this._id + "]";
				this.lblError.Visible = true;
				this.AcceptButton.Disabled = true;
                this.btnCrear.Enabled = false;

				return false;
			}
			else
				return true;
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
						this.Insertar();
					else
						this.Modificar();

					Response.Redirect("Usuarios.aspx");
				}
				catch (Exception ex)
				{
					this.lblError.Visible = true;
					this.lblError.Text = ex.Message;

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
					this._objUsuario = null;
				}
			}
			else
			{
				this.lblError.Visible = true;
			}
		}
		#endregion

		#region Método Insertar
		private void Insertar()
		{
			Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,19, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
			this._objUsuario = new Servipunto.Estacion.Libreria.Usuario();
			this._objUsuario.IdUsuario = this.txtIdUsuario.Text.Trim();
			this._objUsuario.IdRol = Convert.ToByte(this.cboRol.SelectedValue);
			this._objUsuario.Nombre = this.txtNombre.Text.Trim();
			this._objUsuario.Estado = Libreria.EstadoUsuario.Activo;
			this._objUsuario.CodigoEmpleado = this.cboEmpleado.SelectedValue;
			Libreria.Usuarios.Adicionar(this._objUsuario);
		}
		#endregion

		#region Método Modificar
		private void Modificar()
		{
			Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,20, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
			if (this.ObtenerElemento())
			{
				this._objUsuario.IdRol = Convert.ToByte(this.cboRol.SelectedValue);
				this._objUsuario.Nombre = this.txtNombre.Text.Trim();
				this._objUsuario.Estado = (this.optEstado.SelectedValue == "1"?Libreria.EstadoUsuario.Activo:Libreria.EstadoUsuario.Inactivo);
				this._objUsuario.CodigoEmpleado = this.cboEmpleado.SelectedValue;
				this._objUsuario.Modificar();
			}
		}
		#endregion

		#region Método Validar
		private bool Validar()
		{
			this.lblError.Text = "";
			if (this.txtIdUsuario.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtIdUsuario.Text.Trim()))
				{
                    this.lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1773, Global.Idioma);
					return false;
				}
			}
			else
			{
                this.lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1774, Global.Idioma);
				return false;
			}
			if (this.txtIdUsuario.Text.Trim().Length < 4)
			{
                this.lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1775, Global.Idioma);
				return false;
			}
			if (this.txtNombre.Text.Trim().Length == 0)
			{
                this.lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1776, Global.Idioma);
				return false;
			}
			return true;
		}
		#endregion

		#region Método CargarRoles
		private void CargarRoles()
		{
			Libreria.Roles objRoles = new Servipunto.Estacion.Libreria.Roles();

			this.cboRol.DataSource = objRoles;
			this.cboRol.DataTextField = "Nombre";
			this.cboRol.DataValueField = "IdRol";
			this.cboRol.DataBind();
			objRoles = null;

			if (this.cboRol.Items.Count == 0)
			{
				this.cboRol.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1777, Global.Idioma));
				this.AcceptButton.Disabled = true;
                this.btnCrear.Enabled = false;
			}
            
		}
		#endregion

		#region Cargar Empleados
		private void CargarEmpleados()
		{
            #region poblar RadioButton
            this.optEstado.Items.Clear();
            this.optEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "1"));
            this.optEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "0"));
            this.optEstado.SelectedValue = "1";
            #endregion
			Libreria.Configuracion.Empleados objEmpleados = new Servipunto.Estacion.Libreria.Configuracion.Empleados();
			this.cboEmpleado.DataSource = objEmpleados;			
			this.cboEmpleado.DataTextField = "NombreEmpleado";
			this.cboEmpleado.DataValueField = "CodigoEmpleado";			
			this.cboEmpleado.DataBind();			
			this.cboEmpleado.Items.Add("");
			this.cboEmpleado.SelectedValue = "";
			objEmpleados = null;

			if (cboEmpleado.Items.Count == 0)
			{
                this.cboEmpleado.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1778, Global.Idioma));
			//this.AcceptButton.Disabled = true;
			}

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
			this.lnkInicializar.Click += new System.EventHandler(this.lnkInicializar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Evento para invocar el método InicializarContrasena
		private void lnkInicializar_Click(object sender, System.EventArgs e)
		{
			if (this.ObtenerElemento())
			{
				this._objUsuario.InicializarContrasena();
                this.lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1779, Global.Idioma);
				this.lblError.Visible = true;
			}
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

        #region Crear
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }
        #endregion
    }
}
