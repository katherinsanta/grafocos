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
	public class Articulo : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.Label lblHide;
		
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtUnidadMedida;
		protected System.Web.UI.WebControls.TextBox txtPrecio;
		protected System.Web.UI.WebControls.TextBox txtIva;
		protected System.Web.UI.WebControls.TextBox txtCodigoAlterno;
		protected System.Web.UI.WebControls.DropDownList cboColor;

		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtCodArt;
		protected System.Web.UI.WebControls.TextBox txtNumCuenta;
		protected System.Web.UI.WebControls.RadioButtonList optNatCuenta;
		protected System.Web.UI.WebControls.Label txtAdvertenciaGas;
		protected System.Web.UI.WebControls.Label txtAdvertencia;
		protected Libreria.Configuracion.Articulo _objArticulo = null;
		protected System.Web.UI.WebControls.DropDownList cboUnidadMedida;
		protected string _manejaCapturadorVirtual;
		protected System.Web.UI.WebControls.RadioButtonList optCategoria;
		protected System.Web.UI.WebControls.TextBox txtManejaCapturadorVirtual;
		protected string _id = null;

        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Button btnCrear;

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
                        this.lblHide.Text = this._id;
                    }
					this.InicializarForma();
                    Traducir();
				}
				else
					if (Request.Form["AcceptButton"] != null)
					this.Guardar();			
			}
			catch(Exception ex)
			{

                lblError.Text += Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1781, Global.Idioma) +": " + ex.Message;
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
			this.optCategoria.SelectedIndexChanged += new System.EventHandler(this.optCategoria_SelectedIndexChanged);
			this.cboUnidadMedida.SelectedIndexChanged += new System.EventHandler(this.cboUnidadMedida_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Artículos";
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

		#region ObtenerObjetoArticulo
		private bool ObtenerObjetoArticulo()
		{
			try
			{
                this._id = lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
				this._objArticulo = Libreria.Configuracion.Articulos.ObtenerItem(Convert.ToInt16(this._id));
				if (this._objArticulo == null)
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
				Libreria.Configuracion.Dat_Gene _objDat_Gene = Libreria.Configuracion.Datos_Gene.ObtenerItem();
				if(_objDat_Gene == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1787, Global.Idioma), true);
					return;
				}
				_manejaCapturadorVirtual = _objDat_Gene.Mr_Socket_Activo;
				txtManejaCapturadorVirtual.Text = _manejaCapturadorVirtual;
				this.lblBack.NavigateUrl = "Articulos.aspx";
				this.CargarColores();
				if (this._mode == WebApplication.FormMode.New)
				{
					#region Modo de Inserción
					this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1715,Global.Idioma) + "</b> ";
					this.cboColor.Enabled=false;
					this.cboColor.SelectedValue = "#ffffff";
                    this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1086, Global.Idioma);
                    this.btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1086, Global.Idioma);
					#endregion
				}
				else
				{
					#region Modo de Edición
					if (this.ObtenerObjetoArticulo())
					{
						//Visualización de Datos	
						this.txtCodArt.Text = this._objArticulo.IdArticulo.ToString();
						this.txtCodArt.Enabled = false;

						this.txtDescripcion.Text = this._objArticulo.Descripcion;
						this.txtUnidadMedida.Text = this._objArticulo.UnidadMedida;
						this.txtPrecio.Text = this._objArticulo.Precio.ToString();
						this.txtIva.Text = this._objArticulo.Iva.ToString();
						this.cboColor.SelectedValue = this._objArticulo.Color;
						this.txtCodigoAlterno.Text = this._objArticulo.CodigoAlterno.Trim();

						if (this._objArticulo.Tipo == Libreria.TipoArticulo.Combustible)
						{
							this.optCategoria.SelectedValue = "1";
							try
							{
								cboUnidadMedida.SelectedValue =  txtUnidadMedida.Text.Trim();
							}
							catch(Exception)
							{
								cboUnidadMedida.Items.Add(txtUnidadMedida.Text.Trim());
								cboUnidadMedida.SelectedValue =  txtUnidadMedida.Text.Trim();
							}
							
						}
						else
						{
							this.optCategoria.SelectedValue = "0";
							this.cboColor.Enabled=false;
							this.cboColor.SelectedValue = "#ffffff";
							
						}
						
						//Interface Contable
						if ( this._objArticulo.NumCuenta.Equals("(sin definir)"))
							this.txtNumCuenta.Text = null;
						else
							this.txtNumCuenta.Text = this._objArticulo.NumCuenta;
						this.optNatCuenta.SelectedValue = this._objArticulo.NatCuenta?"1":"0";

						this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(46,Global.Idioma) + ": <b>" + this._objArticulo.IdArticulo.ToString() + " - " + this._objArticulo.Descripcion + "</b>";
                        this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                        this.btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
					}					
					#endregion
				}
				this.ControlesMedida();
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,23, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objArticulo = new Libreria.Configuracion.Articulo();

						if (this.txtCodArt.Text.Trim().Length != 0) 
						{
							_objArticulo.CodigoArticulo = int.Parse(txtCodArt.Text.Trim());
						}

						this._objArticulo.Descripcion = this.txtDescripcion.Text.Trim();
						if (this.optCategoria.SelectedValue == "1")
							this._objArticulo.Tipo = Libreria.TipoArticulo.Combustible;
						else
							this._objArticulo.Tipo = Libreria.TipoArticulo.Canastilla;
						this._objArticulo.UnidadMedida = this.txtUnidadMedida.Text.Trim();
						this._objArticulo.Precio = Decimal.Parse(this.txtPrecio.Text);
						this._objArticulo.Precio2 = this._objArticulo.Precio;
						this._objArticulo.Precio3 = this._objArticulo.Precio;
						this._objArticulo.Iva = Convert.ToInt16(this.txtIva.Text);
						this._objArticulo.Color = Convert.ToInt32(this.cboColor.SelectedValue.Replace("#",""), 16).ToString();
						this._objArticulo.CodigoAlterno = this.txtCodigoAlterno.Text.Trim();
						//Interface Contable
						if (this.txtNumCuenta.Text.Equals(""))
							this._objArticulo.NumCuenta = null;
						else
							this._objArticulo.NumCuenta = this.txtNumCuenta.Text.Trim();
						this._objArticulo.NatCuenta = this.optNatCuenta.SelectedValue=="1"?true:false;
						
						Libreria.Configuracion.Articulos.Adicionar(this._objArticulo);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,24, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();

						if (this.ObtenerObjetoArticulo())
						{
							this._objArticulo.Descripcion = this.txtDescripcion.Text.Trim();
							if (this.optCategoria.SelectedValue == "1")
								this._objArticulo.Tipo = Libreria.TipoArticulo.Combustible;
							else
								this._objArticulo.Tipo = Libreria.TipoArticulo.Canastilla;
							this._objArticulo.UnidadMedida = this.txtUnidadMedida.Text.Trim();
							this._objArticulo.Precio = Decimal.Parse(this.txtPrecio.Text);
							this._objArticulo.Precio2 = this._objArticulo.Precio;
							this._objArticulo.Precio3 = this._objArticulo.Precio;
							this._objArticulo.Iva = Convert.ToInt16(this.txtIva.Text);
							this._objArticulo.Color = Convert.ToInt32(this.cboColor.SelectedValue.Replace("#",""), 16).ToString();
							this._objArticulo.CodigoAlterno = this.txtCodigoAlterno.Text.Trim();
							//Interface Contable
							if (this.txtNumCuenta.Text.Equals(""))
								this._objArticulo.NumCuenta = null;
							else
								this._objArticulo.NumCuenta = this.txtNumCuenta.Text.Trim();
							this._objArticulo.NatCuenta = this.optNatCuenta.SelectedValue=="1"?true:false;

							this._objArticulo.Modificar();
						}
						#endregion
					}
					Response.Redirect("Articulos.aspx");
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
					this._objArticulo = null;
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
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1788, Global.Idioma) + "!", false);
				return false;
			}
			if (this.txtUnidadMedida.Text.Trim().Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1789, Global.Idioma) + "!", false);
				return false;
			}

			if (this.txtCodArt.Text.Trim().Length != 0 ) {
				try
				{
					if( int.Parse(this.txtCodArt.Text.Trim()) < 1){
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1790, Global.Idioma) + "!", false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1791, Global.Idioma) + "!", false);
					return false;
				}
			}
			
			if (this.txtPrecio.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtPrecio.Text))
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1792, Global.Idioma) + "!", false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1793, Global.Idioma) + "!", false);
				return false;
			}

			if (this.txtIva.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtIva.Text))
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1794, Global.Idioma) + "!", false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1795, Global.Idioma) + "!", false);
				return false;
			}

			if (this.txtNumCuenta.Text != "") 
			{
				try
				{
                    //int a = Convert.ToInt64this.txtNumCuenta.Text.ToString());
					if( Convert.ToInt64(this.txtNumCuenta.Text) < 1)
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1796, Global.Idioma) + "!", false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1797, Global.Idioma) + "!", false);
					return false;
				}
			}

			return true;
		}
		#endregion

		#region CargarColores
		private void CargarColores()
		{
			
			this.cboColor.Items.Add(new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1798, Global.Idioma), "#ffff00"));
			this.cboColor.Items.Add(new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1799, Global.Idioma), "#0000ff"));
			this.cboColor.Items.Add(new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1800, Global.Idioma), "#808080"));
			this.cboColor.Items.Add(new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1801, Global.Idioma), "#ff9933"));
			this.cboColor.Items.Add(new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1802, Global.Idioma), "#000000"));
			this.cboColor.Items.Add(new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1803, Global.Idioma), "#ffffff"));
			this.cboColor.Items.Add(new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1804, Global.Idioma), "#ff0000"));
            this.cboColor.Items.Add(new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1805, Global.Idioma), "#00ff00"));
            #region poblar RadioButton optCategoria
            this.optCategoria.Items.Clear();
            this.optCategoria.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1783, Global.Idioma), "1"));
            this.optCategoria.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1782, Global.Idioma), "0"));
            this.optCategoria.SelectedValue = "0";
            #endregion
            #region poblar RadioButton optNatCuenta
            this.optNatCuenta.Items.Clear();
            this.optNatCuenta.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1786, Global.Idioma), "1"));
            this.optNatCuenta.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1784, Global.Idioma), "0"));
            this.optNatCuenta.SelectedValue = "0";
            #endregion
            txtAdvertencia.Text = "(*)" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1785, Global.Idioma);
		}
		#endregion

		#region Habilitar Color
		private void optCategoria_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.optCategoria.SelectedValue == "0")
			{
				this.cboColor.Enabled = false;
				this.cboColor.SelectedValue = "#ffffff";
                this.txtAdvertenciaGas.Visible = false;
                this.txtAdvertencia.Visible = false;
			}
			else
			{
				this.cboColor.Enabled = true;
				this.txtAdvertenciaGas.Visible = true;
				this.txtAdvertencia.Visible = true;
			}
			this.ControlesMedida();
		}
		#endregion

		#region unidad de medida

		private void ControlesMedida()
		{
			if(txtManejaCapturadorVirtual.Text == "N")
				return;

			this.cboUnidadMedida.Visible = true;
			if(this.optCategoria.SelectedValue == "0")
			{				
				this.cboUnidadMedida.Visible = false;
				this.txtUnidadMedida.Visible = true;
				this.txtUnidadMedida.Enabled = false;
				this.txtUnidadMedida.Text = "UND";
				
			}
			else
			{
				this.cboUnidadMedida.Visible = true;
				this.cboUnidadMedida.Enabled = true;
				this.txtUnidadMedida.Visible = false;
				this.txtUnidadMedida.Text = cboUnidadMedida.SelectedValue;
			}



		}
		private void cboUnidadMedida_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			txtUnidadMedida.Text = cboUnidadMedida.SelectedValue;
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
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1079, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1241, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1243, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1244, Global.Idioma);
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1245, Global.Idioma);
            Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1246, Global.Idioma);
            Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1247, Global.Idioma);
           // Label10.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1248, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
        }

        #region Crear o Actualizar
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }
        #endregion
	}
}
