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
	public class Controlador : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;
        protected System.Web.UI.WebControls.Button btnCrear;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Panel pnlForm;

		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DropDownList cboPuerto;

		protected WebApplication.FormMode _mode;
		protected Libreria.Configuracion.Controlador _objControlador = null;
		protected System.Web.UI.WebControls.TextBox txtPuertoConcentrador;
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
			const string opcion = "Controladores";
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

		#region ObtenerObjetoControlador
		private bool ObtenerObjetoControlador()
		{
			try
			{
                this._id = lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
				this._objControlador = Libreria.Configuracion.Controladores.ObtenerItem(Convert.ToInt16(this._id));
				if (this._objControlador == null)
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
					this.lblBack.NavigateUrl = "Controladores.aspx";
					this.CargarPuertos();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						this.lblFormTitle.Text = "<b> " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1728,Global.Idioma) + " " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1096,Global.Idioma) + "</b>";
                        this.AcceptButton.Value = Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                        btnCrear.Text = Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoControlador())
						{
							//Visualización de Datos						
							this.txtDescripcion.Text = this._objControlador.Descripcion;
							this.cboPuerto.SelectedValue = this._objControlador.IdPuerto;
							this.txtPuertoConcentrador.Text = this._objControlador.PuertoConcentrador;

                            this.lblFormTitle.Text = Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1096, Global.Idioma) +": <b>" + this._objControlador.Descripcion + "</b>";
                            this.AcceptButton.Value = Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                            btnCrear.Text = Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,59, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objControlador = new Libreria.Configuracion.Controlador();

						this._objControlador.Descripcion = this.txtDescripcion.Text.Trim();
						this._objControlador.IdPuerto = this.cboPuerto.SelectedValue;
						this._objControlador.PuertoConcentrador = this.txtPuertoConcentrador.Text.Trim();
						
						Libreria.Configuracion.Controladores.Adicionar(this._objControlador);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoControlador())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,60, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objControlador.Descripcion = this.txtDescripcion.Text.Trim();
							this._objControlador.IdPuerto = this.cboPuerto.SelectedValue;
							this._objControlador.PuertoConcentrador = this.txtPuertoConcentrador.Text.Trim();

							this._objControlador.Modificar();
						}
						#endregion
					}
					Response.Redirect("Controladores.aspx");
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
					this._objControlador = null;
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
			if (this.txtDescripcion.Text.Trim().Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1788, Global.Idioma), false);
				return false;
			}			
			return true;
		}
		#endregion

		#region CargarPuertos
		private void CargarPuertos()
		{
			Libreria.Configuracion.Puertos objPuertos = new Libreria.Configuracion.Puertos();

			this.cboPuerto.DataSource = objPuertos;
			this.cboPuerto.DataTextField = "IdPuerto";
			this.cboPuerto.DataValueField = "IdPuerto";
			this.cboPuerto.DataBind();

			if (this.cboPuerto.Items.Count == 0)
			{
                this.cboPuerto.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1820, Global.Idioma));
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

        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(814, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1097, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1098, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);


        }
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion

    }
}
