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
	public class Pos : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;		
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.DropDownList cboPuerto;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtIdCapturador;
		protected System.Web.UI.WebControls.TextBox txtIdIsla;
		protected Libreria.Configuracion.POS _objPOS = null;
		protected string _id = null;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;

        protected System.Web.UI.WebControls.DropDownList ddlModeloPolyDisplay;
        protected System.Web.UI.WebControls.DropDownList ddlManejaPolyDisplay;
        protected System.Web.UI.WebControls.DropDownList ddlPuertos;

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
			if (Request.QueryString["IdPos"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdPos"].Replace(" ", "+")));
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
			const string opcion = "POS";
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

		#region ObtenerObjetoPos
		private bool ObtenerObjetoPos()
		{
			try
			{
                this._id = lblHide.Text; // (Convert.ToString(Request.QueryString["IdPos"].Replace(" ", "+")));
				this._objPOS = Libreria.Configuracion.POSs.ObtenerItem(Convert.ToInt16(this._id), 0);
				if (this._objPOS == null)
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
                    CargarPuertos();
					if(Request.QueryString["IdCapturador"] == null || Request.QueryString["IdCapturador"] == "")
						this.lblBack.NavigateUrl = "poss.aspx";
					else
						this.lblBack.NavigateUrl = "Poss.aspx?IdCapturador=" + Request.QueryString["IdCapturador"];

					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
                        this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1728, Global.Idioma) + " POS</b>";
                        this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma); 
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoPos())
						{
							//Visualización de Datos						
							this.txtId.Text = this._objPOS.IdPos.ToString();
							this.txtIdCapturador.Text = this._objPOS.IdCapturador.ToString();
							this.txtIdIsla.Text = this._objPOS.IdIsla.ToString();
							this.txtId.Enabled = false;
                            this.ddlManejaPolyDisplay.SelectedValue = this._objPOS.ManejaPolyDisplay ? "Si" : "No";
                            this.ddlPuertos.Enabled = this._objPOS.ManejaPolyDisplay;
                            this.ddlPuertos.SelectedValue = this._objPOS.PuertoPolyDisplay;
                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1027, Global.Idioma) +": <b>" + this._objPOS.IdCapturador.ToString() + "</b>";
                            this.AcceptButton.Value =  Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma) ;
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,105, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objPOS = new Libreria.Configuracion.POS();

						this._objPOS.IdCapturador = Convert.ToInt16(this.txtIdCapturador.Text);
						this._objPOS.IdIsla = Convert.ToInt16(this.txtIdIsla.Text);
						this._objPOS.IdPos = Convert.ToInt16(this.txtId.Text);
                        this._objPOS.ManejaPolyDisplay = ddlManejaPolyDisplay.SelectedValue == "Si" ? true : false;
                        this._objPOS.ProtocoloPolyDisplay = ddlModeloPolyDisplay.SelectedValue;
                        this._objPOS.PuertoPolyDisplay = ddlPuertos.SelectedValue; ;
						Libreria.Configuracion.POSs.Adicionar(this._objPOS);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoPos())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,106, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objPOS.IdCapturador = Convert.ToInt16(this.txtIdCapturador.Text);
							this._objPOS.IdIsla = Convert.ToInt16(this.txtIdIsla.Text);
							this._objPOS.IdPos = Convert.ToInt16(this.txtId.Text);
                            this._objPOS.ManejaPolyDisplay = ddlManejaPolyDisplay.SelectedValue == "Si" ? true : false;
                            this._objPOS.ProtocoloPolyDisplay = ddlModeloPolyDisplay.SelectedValue;
                            this._objPOS.PuertoPolyDisplay = ddlPuertos.SelectedValue; 
							this._objPOS.Modificar();
						}
						#endregion
					}
					if(Request.QueryString["IdCapturador"] != null && Request.QueryString["IdCapturador"] != "")
						Response.Redirect("Poss.aspx?IdCapturador=" + Request.QueryString["IdCapturador"]);
					else
						Response.Redirect("Poss.aspx");
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
					this._objPOS = null;
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
			if (this.txtId.Text.Trim().Length != 0 || this.txtIdCapturador.Text.Trim().Length != 0 || this.txtIdIsla.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtId.Text.Trim()) || !Libreria.Aplicacion.IsNumeric(this.txtIdCapturador.Text.Trim()) 
					|| !Libreria.Aplicacion.IsNumeric(this.txtIdIsla.Text.Trim()) )
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1809, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1810, Global.Idioma), false);
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
        #region Traduccir
        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1398, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1399, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1400, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);


        }
        #endregion
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion

        #region ManejaPolydisplay
        protected void ddlManejaPolyDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlManejaPolyDisplay.SelectedValue == "Si")
            {
                ddlModeloPolyDisplay.Enabled = true;
                ddlPuertos.Enabled = true;

            }
            else
            {
                ddlModeloPolyDisplay.Enabled = false;
                ddlPuertos.Enabled = false;
            }
        }
        #endregion

        #region CargarPuertos
        private void CargarPuertos()
        {
            Libreria.Configuracion.Puertos objPuertos = new Libreria.Configuracion.Puertos();
            this.ddlPuertos.DataSource = objPuertos;
            this.ddlPuertos.DataTextField = "IdPuerto";
            this.ddlPuertos.DataValueField = "IdPuerto";
            this.ddlPuertos.DataBind();

            if (this.ddlPuertos.Items.Count == 0)
            {
                this.ddlPuertos.Items.Add("(no hay puertos configurados)");
                this.AcceptButton.Disabled = true;
            }
        }
        #endregion
    }
}