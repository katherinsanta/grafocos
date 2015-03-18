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
	public class Identificador : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblHideEmp;
        protected System.Web.UI.WebControls.Label lblHideNombre;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.HtmlControls.HtmlTableRow filaPlaca;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtIdIdentificador;
		protected System.Web.UI.WebControls.TextBox txtCodigoROM;
		protected System.Web.UI.WebControls.DropDownList ddlTipoIdentificador;
		protected System.Web.UI.WebControls.TextBox txtPlaca;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton EstadoActivo;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton EstadoInactivo;
		protected System.Web.UI.WebControls.Label lblCodigoEmpleado;
		protected Libreria.Configuracion.Identificador _objIdentificador = null;

        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
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
			if (Request.QueryString["IdIdentificador"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdIdentificador"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                }
				this.InicializarForma();
                Traduccir();
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
			const string opcion = "Identificadores";
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

		#region ObtenerObjetoIdentificador
		private bool ObtenerObjetoIdentificador()
		{
			try
			{
                this._id = lblHide.Text;  //(Convert.ToString(Request.QueryString["IdIdentificador"].Replace(" ", "+")));
				this._objIdentificador = Libreria.Configuracion.Identificadores.ObtenerItem(int.Parse(this._id));
				if (this._objIdentificador == null)
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
			try
			{
                RadioButtonTraduccion();
				if(Request.QueryString["IdEmpleado"] == null || Request.QueryString["IdEmpleado"].Trim() == "")
				{
					this.lblBack.NavigateUrl = "Default.aspx";
					this.filaPlaca.Visible = true;
				}
				else
				{
                    lblHideEmp.Text = Request.QueryString["IdEmpleado"];
                    lblHideNombre.Text = Request.QueryString["Nombre"];
					this.lblBack.NavigateUrl = "Identificadores.aspx?IdEmpleado="  + Request.QueryString["IdEmpleado"]+ "&Nombre=" + Request.QueryString["Nombre"];
					this.filaPlaca.Visible = false;
				}

				if (this.VerificarPermisos())
				{
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
                        this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1738, Global.Idioma) + " " + Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Global.Idioma) + "</b>";
						this.EstadoActivo.Disabled = this.EstadoInactivo.Disabled = true;
						this.txtIdIdentificador.Enabled = true;
						string idEmpleado = DecryptText(Convert.ToString(Request.QueryString["IdEmpleado"].Replace(" ","+") ));
						this.lblCodigoEmpleado.Text = idEmpleado;
                        this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoIdentificador())
						{
							//Visualización de Datos
							this.lblCodigoEmpleado.Text = this._objIdentificador.CodigoEmpleado.ToString();
							this.txtIdIdentificador.Text =this._objIdentificador.NumeroIdentificador.ToString();

                            if (_objIdentificador.IdentificadorActivo == Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma))
							{
								EstadoActivo.Checked = true;
								EstadoInactivo.Checked = false;
							}
							else
							{
								EstadoActivo.Checked = false;
								EstadoInactivo.Checked = true;
							}
						
							this.txtCodigoROM.Text = this._objIdentificador.IdRom;
							this.ddlTipoIdentificador.SelectedValue = this._objIdentificador.TipoIdentificador;
							this.txtPlaca.Text = this._objIdentificador.Placa;
                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Global.Idioma) + ": <b>" + this._objIdentificador.NumeroIdentificador.ToString() + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
						}
						#endregion
					}
				}
			}
			catch(Exception ex)
			{
				SetError(ex.Message, false);
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
		}
		#endregion

		#region Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
					this._objIdentificador = new Libreria.Configuracion.Identificador();
					this._objIdentificador.CodigoEmpleado = this.lblCodigoEmpleado.Text;
					this._objIdentificador.NumeroIdentificador = int.Parse(txtIdIdentificador.Text);
					if(EstadoActivo.Checked)
                        this._objIdentificador.IdentificadorActivo = "Activo";
					else
                        this._objIdentificador.IdentificadorActivo = "Inactivo";
					this._objIdentificador.IdRom = this.txtCodigoROM.Text;
					this._objIdentificador.TipoIdentificador = this.ddlTipoIdentificador.SelectedValue;
					this._objIdentificador.Placa = this.txtPlaca.Text;

					if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,121, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();	
						Libreria.Configuracion.Identificadores.Adicionar(this._objIdentificador);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,122, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objIdentificador.Modificar();
						#endregion
					}
					//if(Request.QueryString["IdEmpleado"] != null || Request.QueryString["IdEmpleado"].Trim() != "")
                    if (lblHideEmp.Text != "")
						Response.Redirect("Identificadores.aspx?IdEmpleado="+ lblHideEmp.Text + "&Nombre=" + lblHideNombre.Text);
				}
				catch (Exception ex)
				{
					SetError(ex.Message, false);

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
					this._objIdentificador = null;
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
			if (this.txtIdIdentificador.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtIdIdentificador.Text.Trim()))
				{
					this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1773, Global.Idioma), false);
					return false;
				}
			}
			else
			{
				this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1774, Global.Idioma), false);
				return false;
			}
			if (this.ddlTipoIdentificador.SelectedIndex != 0 && this.txtCodigoROM.Text.Trim().Length != 16)
			{
				this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2019, Global.Idioma), false);
				return false;
			}
			return true;
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

        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma) + " " + Libreria.Configuracion.PalabrasIdioma.Traduccion(274, Global.Idioma) + ":";
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(336, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma) + " ROM:";
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(342, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
            
        }
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlTipoIdentificador
            this.ddlTipoIdentificador.Items.Clear();
            this.ddlTipoIdentificador.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2369, Global.Idioma), "Magnetica"));
            this.ddlTipoIdentificador.Items.Insert(1, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2370, Global.Idioma), "Boton"));
            this.ddlTipoIdentificador.SelectedValue = "Magnetica";
            #endregion           
        }
        #endregion
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }
	}
}
