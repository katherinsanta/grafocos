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
	public class Empleado : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;
        protected System.Web.UI.WebControls.Label lblHide;
        
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.DropDownList ddlEstado;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.TextBox txtCedula;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.DropDownList ddlTipoEmpleado;
		protected Libreria.Configuracion.Empleado _objEmpleado = null;
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
			if (Request.QueryString["IdEmpleado"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdEmpleado"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                }
				this.InicializarForma();
                Traduccion();
			}
			else
				if (Request.Form["AcceptButton"] != null)
				this.Guardar();			
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

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Empleados";
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
			return true;
		}
		#endregion

		#region ObtenerObjetoEmpleado
		private bool ObtenerObjetoEmpleado()
		{
			try
			{
                this._id = lblHide.Text;//DecryptText(Convert.ToString(Request.QueryString["IdEmpleado"].Replace(" ","+") ));
				this._objEmpleado = Libreria.Configuracion.Empleados.ObtenerItem(this._id);
				if (this._objEmpleado == null)
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

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
				try
				{
                    RadioButtonTraduccion();
					this.lblBack.NavigateUrl = "Empleados.aspx";
					this.CargarTipoEmpleados();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
                        this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1728, Global.Idioma) + " " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1074, Global.Idioma) + "</b>";
                        this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoEmpleado())
						{
							//Visualización de Datos
							this.txtCodigo.Enabled = false;
							this.txtCodigo.Text = this._objEmpleado.CodigoEmpleado;
							this.txtCedula.Text = this._objEmpleado.CedulaEmpleado;
							this.ddlEstado.SelectedValue = this._objEmpleado.EstadoEmpleado;
							this.txtNombre.Text = this._objEmpleado.NombreEmpleado;
							this.ddlTipoEmpleado.SelectedValue = this._objEmpleado.TipoEmpleado;
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);

                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1074, Global.Idioma) + ": <b>" + this._objEmpleado.NombreEmpleado + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
						}
						#endregion
					}
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
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlEstado
            this.ddlEstado.Items.Clear();
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "A"));
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "I"));
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1854, Global.Idioma), "B"));
            this.ddlEstado.SelectedValue = "A";
            #endregion
        }
        #endregion

		#region Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,117, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objEmpleado = new Libreria.Configuracion.Empleado();
						this._objEmpleado.CodigoEmpleado = this.txtCodigo.Text;
						this._objEmpleado.CedulaEmpleado = this.txtCedula.Text;
						this._objEmpleado.EstadoEmpleado = this.ddlEstado.SelectedValue;
						this._objEmpleado.NombreEmpleado = this.txtNombre.Text;
						this._objEmpleado.TipoEmpleado = this.ddlTipoEmpleado.SelectedValue;
						
						Libreria.Configuracion.Empleados.Adicionar(this._objEmpleado);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoEmpleado())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,118, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objEmpleado.CodigoEmpleado = this.txtCodigo.Text;
							this._objEmpleado.CedulaEmpleado = this.txtCedula.Text;
							this._objEmpleado.EstadoEmpleado = this.ddlEstado.SelectedValue;
							this._objEmpleado.NombreEmpleado = this.txtNombre.Text;
							this._objEmpleado.TipoEmpleado = this.ddlTipoEmpleado.SelectedValue;
							this._objEmpleado.Modificar();
						}
						#endregion
					}
					Response.Redirect("Empleados.aspx");
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
					this._objEmpleado = null;
				}
			}
			else
			{
				this.lblError.Visible = true;
			}
		}
		#endregion

		#region Validar
		private bool Validar()
		{
			this.ClearError();
			if (this.txtCodigo.Text.Trim().Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1810, Global.Idioma), false);
				return false;
			}
			return true;
		}
		#endregion

		#region Cargar TipoEmpleado
		private void CargarTipoEmpleados()
		{
			Servipunto.Estacion.Libreria.TiposDeEmpleado objTipo = new Servipunto.Estacion.Libreria.TiposDeEmpleado();

			this.ddlTipoEmpleado.DataSource = objTipo.Tipos();
			this.ddlTipoEmpleado.DataBind();

			if (this.ddlTipoEmpleado.Items.Count == 0)
			{
                this.ddlTipoEmpleado.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1863, Global.Idioma));
				this.AcceptButton.Disabled = true;
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

        private void Traduccion()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1124, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1127, Global.Idioma);
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
