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
	public class Cara : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblHideSurtidor;
        protected System.Web.UI.WebControls.Label lblHideIsla;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.DropDownList cboControlador;
		protected System.Web.UI.WebControls.DropDownList cboEstado;
		protected System.Web.UI.WebControls.DropDownList cboModo;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
		protected WebApplication.FormMode _mode;

		protected Libreria.Configuracion.Cara _objCara = null;
		protected Libreria.Configuracion.Surtidor _objSurtidor = null;
		protected string _id = null;
		protected string _idSurtidor = null;

        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;

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
            if (Request.QueryString["IdCara"] == null && lblHide.Text == "")
            {
                this._mode = WebApplication.FormMode.New;
                if (lblHideSurtidor.Text == "")
                {
                    lblHideSurtidor.Text = DecryptText(Convert.ToString(Request.QueryString["IdSurtidor"].Replace(" ", "+")));
                    lblHideIsla.Text = DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ", "+")));
                }
            }
            else
                this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdCara"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                    lblHideSurtidor.Text = DecryptText(Convert.ToString(Request.QueryString["IdSurtidor"].Replace(" ", "+")));
                    lblHideIsla.Text = DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ", "+")));

                }
				this.InicializarForma();
                Traducir();
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
			const string opcion = "Caras";
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

		#region ObtenerObjetoCara
		private bool ObtenerObjetoCara()
		{
			try
			{
                this._id = lblHide.Text; // (Convert.ToString(Request.QueryString["IdCara"].Replace(" ", "+")));
				this._objCara = Libreria.Configuracion.Caras.ObtenerItem(Convert.ToInt16(this._id));
				if (this._objCara == null)
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

		#region ObtenerObjetoSurtidor
		private bool ObtenerObjetoSurtidor()
		{
			try
			{
                if (lblHideSurtidor.Text == "")
                {
                    this._idSurtidor = DecryptText(Convert.ToString(Request.QueryString["IdSurtidor"].Replace(" ", "+")));
                    lblHideIsla.Text = DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ", "+")));
                    lblHideSurtidor.Text = this._idSurtidor;
                }
                else
                {
                    this._idSurtidor = lblHideSurtidor.Text;
                }

				this._objSurtidor = Libreria.Configuracion.Surtidores.ObtenerItem(Convert.ToInt16(this._idSurtidor));
				if (this._objSurtidor == null)
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
					this.CargarControladores();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						if (this.ObtenerObjetoSurtidor())
						{
							this.lblFormTitle.Text = "<b>" +  Libreria.Configuracion.PalabrasIdioma.Traduccion(1723,Global.Idioma) + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
							//this._objSurtidor.IdSurtidor.ToString() 
							this.lblBack.NavigateUrl = "Caras.aspx?IdSurtidor=" + EncryptText(lblHideSurtidor.Text) + "&IdIsla=" + EncryptText(lblHideIsla.Text);
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma), false);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoCara())
						{
							//Visualización de Datos						
							this.txtId.Text = this._objCara.IdCara.ToString();
							this.cboControlador.SelectedValue = this._objCara.IdControlador.ToString();
							this.cboEstado.SelectedValue = this._objCara.Estado;
							this.cboModo.SelectedValue = this._objCara.Modo;

							this.txtId.Enabled = false;
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
							this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma) + ":<b>" + this._objCara.IdIsla.ToString() + "</b>," + Libreria.Configuracion.PalabrasIdioma.Traduccion(75, Global.Idioma) + ": <b>" + this._objCara.IdSurtidor.ToString() + "</b>" + ", " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1725, Global.Idioma) + ": <b>" + this._objCara.IdCara.ToString() + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
							this.lblBack.NavigateUrl = "Caras.aspx?IdSurtidor=" + Request.QueryString["IdSurtidor"]+ "&IdIsla=" + Request.QueryString["IdIsla"];
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma), false);
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
						if (this.ObtenerObjetoSurtidor())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,95, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objCara = new Libreria.Configuracion.Cara();
							this._objCara.IdCara = Convert.ToInt16(this.txtId.Text);
							this._objCara.IdIsla = this._objSurtidor.IdIsla;
							this._objCara.IdSurtidor = this._objSurtidor.IdSurtidor;
							this._objCara.IdControlador = Convert.ToInt16(this.cboControlador.SelectedValue);
							this._objCara.Estado = this.cboEstado.SelectedValue;
							this._objCara.Modo = this.cboModo.SelectedValue;
							Libreria.Configuracion.Caras.Adicionar(this._objCara);							
						}
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoCara())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,96, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objCara.IdControlador = Convert.ToInt16(this.cboControlador.SelectedValue);
							this._objCara.Estado = this.cboEstado.SelectedValue;
							this._objCara.Modo = this.cboModo.SelectedValue;
							this._objCara.Modificar();
						}
						#endregion
					}	
					Response.Redirect("Caras.aspx?IdSurtidor=" + EncryptText(lblHideSurtidor.Text) 
						+ "&IdIsla=" + EncryptText(lblHideIsla.Text));
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
					this._objCara = null;
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
			//Número de la cara
			if (this.txtId.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtId.Text.Trim()))
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

		#region CargarControladores
		private void CargarControladores()
		{
			Libreria.Configuracion.Controladores objControladores = new Libreria.Configuracion.Controladores();
			
			foreach (Libreria.Configuracion.Controlador objControlador in objControladores)
			{
				this.cboControlador.Items.Add(new ListItem(objControlador.ToString(), objControlador.IdControlador.ToString()));
			}
			if (this.cboControlador.Items.Count == 0)
			{
				this.cboControlador.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1858, Global.Idioma));
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

        private void Traducir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1372, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(692, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1375, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
        }
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  cboEstado
            this.cboEstado.Items.Clear();
            this.cboEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "A"));
            this.cboEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "I"));
            this.cboEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1854, Global.Idioma), "B"));
            this.cboEstado.SelectedValue = "A";
            #endregion
            #region poblar RadioButton  cboModo
            this.cboModo.Items.Clear();
            this.cboModo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1855, Global.Idioma), "A"));
            this.cboModo.Items.Insert(0, new ListItem("Self Service", "P"));
            this.cboModo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1856, Global.Idioma), "S"));
            this.cboModo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1857, Global.Idioma), "C"));
            this.cboModo.SelectedValue = "A";
            #endregion            
        }
        #endregion
    }
}
