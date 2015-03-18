using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
//using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
	public class Manguera : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblHideSurtidor;
        protected System.Web.UI.WebControls.Label lblHideCara;
        protected System.Web.UI.WebControls.Label lblHideIsla;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.DropDownList cboArticulo;
		protected System.Web.UI.WebControls.DropDownList cboGrado;
		protected System.Web.UI.WebControls.DropDownList cboEstado;
		protected System.Web.UI.WebControls.DropDownList cboLector;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
		protected WebApplication.FormMode _mode;

		protected Libreria.Configuracion.Manguera _objManguera = null;
		protected System.Web.UI.WebControls.DropDownList ddlTanque;
		protected Libreria.Configuracion.Cara _objCara = null;
		protected string _id = null;
		protected string _idCara = null;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;

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
			Session["refresh"] = "";
            if (Request.QueryString["IdManguera"] == null && lblHide.Text == "")
            {
                this._mode = WebApplication.FormMode.New;
                if (lblHideCara.Text == "")
                {
                    lblHideCara.Text = DecryptText(Convert.ToString(Request.QueryString["IdCara"].Replace(" ", "+")));
                    lblHideSurtidor.Text = DecryptText(Convert.ToString(Request.QueryString["IdSurtidor"].Replace(" ", "+")));
                    lblHideIsla.Text = DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ", "+")));
                }
            }
            else
            {
                this._mode = WebApplication.FormMode.Edit;
            }

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdManguera"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                    lblHideCara.Text = DecryptText(Convert.ToString(Request.QueryString["IdCara"].Replace(" ", "+")));
                    lblHideSurtidor.Text = DecryptText(Convert.ToString(Request.QueryString["IdSurtidor"].Replace(" ", "+")));
                    lblHideIsla.Text = DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ", "+")));
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
			const string opcion = "Mangueras";
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

		#region ObtenerObjetoManguera
		private bool ObtenerObjetoManguera()
		{
			try
			{
                this._id = lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["IdManguera"].Replace(" ", "+")));
				this._objManguera = Libreria.Configuracion.Mangueras.ObtenerItem(Convert.ToInt16(this._id));
				if (this._objManguera == null)
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

		#region ObtenerObjetoCara
		private bool ObtenerObjetoCara()
		{
			try
			{
                this._idCara = lblHideCara.Text; // DecryptText(Convert.ToString(Request.QueryString["IdCara"].Replace(" ", "+")));
				this._objCara = Libreria.Configuracion.Caras.ObtenerItem(Convert.ToInt16(this._idCara));
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

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
				try
				{
					this.lblBack.NavigateUrl = "Mangueras.aspx?IdCara=" + Request.QueryString["IdCara"] 
						+ "&IdSurtidor=" + Request.QueryString["IdSurtidor"] 
						+ "&IdIsla=" + Request.QueryString["IdIsla"];
                    RadioButtonTraduccion();
					this.CargarArticulos();
					this.CargarLectores();
					CargarTanques();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						if (this.ObtenerObjetoCara())
						{
							this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1737,Global.Idioma) + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) , false);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoManguera())
						{
							//Visualización de Datos						
							this.txtId.Text = this._objManguera.IdManguera.ToString();
							this.cboArticulo.SelectedValue = this._objManguera.IdArticulo.ToString();
							this.cboGrado.SelectedValue = this._objManguera.Grado.ToString();
							this.cboLector.SelectedValue = this._objManguera.IdLector;
							this.cboEstado.SelectedValue = this._objManguera.Estado;
							this.ddlTanque.SelectedValue = this._objManguera.IdTanque.ToString();
							this.txtId.Enabled = false;
                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma) + ": <b>" + this._objManguera.IdIsla.ToString() + "</b>," + Libreria.Configuracion.PalabrasIdioma.Traduccion(1361, Global.Idioma) + ":<b>" + this._objManguera.IdSurtidor.ToString() + "</b>" + ", " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1725, Global.Idioma) + ": <b>" + this._objManguera.IdCara.ToString() + "</b>" + ", " + Libreria.Configuracion.PalabrasIdioma.Traduccion(60, Global.Idioma) + ": <b>" + this._objManguera.IdManguera.ToString() + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) , false);
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
            #region poblar RadioButton  cboEstado
            this.cboEstado.Items.Clear();
            this.cboEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "A"));
            this.cboEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "I"));
            this.cboEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1854, Global.Idioma), "B"));
            this.cboEstado.SelectedValue = "A";
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
						if (this.ObtenerObjetoCara())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,99, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objManguera = new Libreria.Configuracion.Manguera();
							this._objManguera.IdManguera = Convert.ToInt16(this.txtId.Text);
							this._objManguera.IdIsla = this._objCara.IdIsla;
							this._objManguera.IdSurtidor = this._objCara.IdSurtidor;
							this._objManguera.IdCara = this._objCara.IdCara;
							this._objManguera.IdTanque = 0;
							this._objManguera.IdArticulo = Convert.ToInt16(this.cboArticulo.SelectedValue);
							this._objManguera.Grado = Convert.ToInt16(this.cboGrado.SelectedValue);
							this._objManguera.LectorConfigurado = true;
							this._objManguera.IdLector = this.cboLector.SelectedValue;
							this._objManguera.Estado = this.cboEstado.SelectedValue;
							this._objManguera.IdTanque = short.Parse(this.ddlTanque.SelectedValue);

							Libreria.Configuracion.Mangueras.Adicionar(this._objManguera);
						}
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoManguera())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,100, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objManguera.IdTanque = 0;
							this._objManguera.IdArticulo = Convert.ToInt16(this.cboArticulo.SelectedValue);
							this._objManguera.Grado = Convert.ToInt16(this.cboGrado.SelectedValue);
							this._objManguera.LectorConfigurado = true;
							this._objManguera.IdLector = this.cboLector.SelectedValue;
							this._objManguera.Estado = this.cboEstado.SelectedValue;
							this._objManguera.IdTanque = short.Parse(this.ddlTanque.SelectedValue);
							this._objManguera.Modificar();
						}
						#endregion
					}
					Response.Redirect("Mangueras.aspx?IdCara=" +  EncryptText(lblHideCara.Text)  + 
					"&IdSurtidor=" + EncryptText(lblHideSurtidor.Text)
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
					this._objManguera = null;
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

		#region CargarLectores
		private void CargarLectores()
		{
			Libreria.Configuracion.Lectores objLectores = new Libreria.Configuracion.Lectores();

			this.cboLector.DataSource = objLectores;
			this.cboLector.DataTextField = "IdLector";
			this.cboLector.DataValueField = "IdLector";
			this.cboLector.DataBind();

			if (this.cboLector.Items.Count == 0)
			{
				this.cboLector.Items.Add( Libreria.Configuracion.PalabrasIdioma.Traduccion(1859, Global.Idioma));
				this.AcceptButton.Disabled = true;
			}
		}
		#endregion

		#region CargarTanques
		private void CargarTanques()
		{
			Libreria.Configuracion.Tanques.Tanques objTanques = new Libreria.Configuracion.Tanques.Tanques();
			this.ddlTanque.DataSource = objTanques;
			this.ddlTanque.DataTextField = this.cboLector.DataValueField = "CodigoTanque";
			this.ddlTanque.DataBind();

			if (this.cboLector.Items.Count == 0)
			{
                this.cboLector.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1860, Global.Idioma));
				this.AcceptButton.Disabled = true;
			}
		}
		#endregion

		#region CargarArticulos
		private void CargarArticulos()
		{
			Libreria.Configuracion.Articulos objArticulos = new Libreria.Configuracion.Articulos(Libreria.TipoArticulo.Combustible);

			this.cboArticulo.DataSource = objArticulos;
			this.cboArticulo.DataTextField = "Descripcion";
			this.cboArticulo.DataValueField = "IdArticulo";
			this.cboArticulo.DataBind();

			if (this.cboArticulo.Items.Count == 0)
			{
                this.cboArticulo.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1861, Global.Idioma));
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
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1381, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(46, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1378, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1299, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(996, Global.Idioma);
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
