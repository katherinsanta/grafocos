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
	public class Tanque : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.HtmlControls.HtmlTableRow filaCodigo;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;		
		protected System.Web.UI.WebControls.TextBox txtId;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtCapacidad;
		protected Libreria.Configuracion.Tanques.Tanque _objTanque = null;
		protected System.Web.UI.WebControls.DropDownList cboArticulo;
		protected System.Web.UI.WebControls.CheckBox chkLitrosAGalones;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButtonList rblGasOLiquido;
		protected string _id = null;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;        
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
        protected System.Web.UI.WebControls.TextBox txtPorcMinimoDisponible;
		

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
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
        }
        #endregion

		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.QueryString["IdTanque"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdTanque"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                }
				this.InicializarForma();
			}
			else
				if (Request.Form["AcceptButton"] != null)
					this.Guardar();			
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
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1438, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(46, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1459, Global.Idioma);
            chkLitrosAGalones.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1936, Global.Idioma);            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion 

        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  rblGasOLiquido
            this.rblGasOLiquido.Items.Clear();
            this.rblGasOLiquido.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1186, Global.Idioma), "1"));
            this.rblGasOLiquido.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1460, Global.Idioma), "0"));
            this.rblGasOLiquido.SelectedValue = "0";
            #endregion            
        }
        #endregion

        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.MyForm.Visible = false;
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
			const string opcion = "Tanques";
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

		#region ObtenerObjetoTanque
		private bool ObtenerObjetoTanque()
		{
			try
			{

                this._id = lblHide.Text; // (Convert.ToString(Request.QueryString["IdTanque"].Replace(" ", "+")));
				this._objTanque = Libreria.Configuracion.Tanques.Tanques.ObtenerItem(int.Parse(this._id));
				if (this._objTanque == null)
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
					this.CargarArticulos();

					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						this.filaCodigo.Visible = false;
						this.lblFormTitle.Text = "<b>Creación de un Nuevo Tanque</b>";
						this.AcceptButton.Value = "Crear";
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoTanque())
						{
							//Visualización de Datos						
							this.txtId.Text = this._objTanque.CodigoTanque.ToString();
							this.txtCapacidad.Text = this._objTanque.CapacidadTanque.ToString();
							this.chkLitrosAGalones.Checked = this._objTanque.ConvierteLitrosAGalones==1?true:false;
							this.rblGasOLiquido.SelectedValue = this._objTanque.GasOLiquido?"1":"0";
							if(_objTanque.CodigoArticulo != -1)
								this.cboArticulo.SelectedValue = this._objTanque.CodigoArticulo.ToString();
							this.txtId.Enabled = false;
                            this.txtPorcMinimoDisponible.Text = this._objTanque.PorcMinimoDisponible.ToString();
                           
						
							this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(619, Global.Idioma)+" <b>" + this._objTanque.CodigoTanque.ToString() + "</b>";
							this.AcceptButton.Value = "Guardar";
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
						}
						else
							this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) , false);
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
                        #endregion   <
				}

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
				this.cboArticulo.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma));
				this.AcceptButton.Disabled = true;
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,131, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objTanque = new Servipunto.Estacion.Libreria.Configuracion.Tanques.Tanque();
							this._objTanque.CapacidadTanque = Decimal.Parse(this.txtCapacidad.Text);
							this._objTanque.CodigoArticulo = int.Parse(cboArticulo.SelectedValue);
							this._objTanque.ConvierteLitrosAGalones = (byte)(this.chkLitrosAGalones.Checked?1:0);
							this._objTanque.GasOLiquido = rblGasOLiquido.SelectedValue == "1"?true:false;
                            this._objTanque.PorcMinimoDisponible = int.Parse(this.txtPorcMinimoDisponible.Text);
							Libreria.Configuracion.Tanques.Tanques.Adicionar(this._objTanque);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoTanque())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,132, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objTanque.CodigoTanque = int.Parse(this.txtId.Text);
							this._objTanque.CapacidadTanque = Decimal.Parse(this.txtCapacidad.Text);
							this._objTanque.CodigoArticulo = int.Parse(cboArticulo.SelectedValue);
							this._objTanque.ConvierteLitrosAGalones = (byte)(this.chkLitrosAGalones.Checked?1:0);
							this._objTanque.GasOLiquido = rblGasOLiquido.SelectedValue == "1"?true:false;
                            this._objTanque.PorcMinimoDisponible = int.Parse(txtPorcMinimoDisponible.Text);
						
							this._objTanque.Modificar();
						}
						#endregion
					}
					Response.Redirect("Tanques.aspx");
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
			if (this.txtCapacidad.Text.Trim().Length != 0)
			{
				try
				{
					Decimal.Parse(txtCapacidad.Text);
				}
				catch
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

			try
			{
				int articulo = int.Parse(cboArticulo.SelectedValue);
			}
			catch(Exception)
			{
				this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1937, Global.Idioma), false);
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
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion
    }
}
