using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
	public class PrecioProgramado : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblHideArticulo;
		protected System.Web.UI.WebControls.Label lblFormTitle;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.LinkButton lbGuardar;
		protected System.Web.UI.WebControls.TextBox txtPrecio3;
		protected System.Web.UI.WebControls.TextBox txtPrecio2;
		protected System.Web.UI.WebControls.TextBox txtPrecio4;
		protected System.Web.UI.WebControls.TextBox txtPrecio1;
		protected System.Web.UI.WebControls.Calendar Calendario;
		protected System.Web.UI.WebControls.DropDownList ddlArticulo;
		protected Libreria.Configuracion.PreciosProgramados.PrecioProgramado _objPrecio = null;
		protected string _id = null;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.TextBox txtFecha;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender1;
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
            ViewState["Control"] = "0";
            ViewState["Fecha"] = "1";
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
			if (Request.QueryString["Fecha"] == null && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;

			if (!this.IsPostBack)
			{
                if (ViewState["Control"].ToString() != "1")
                {
                    if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                    {
                        this._id = DecryptText(Convert.ToString(Request.QueryString["Fecha"].Replace(" ", "+")));
                        lblHide.Text = this._id;
                        lblHideArticulo.Text = Convert.ToString(Request.QueryString["IdArticulo"].Replace(" ", "+"));
                    }
                    Traduccir();
                    this.InicializarForma();
                    CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                }
			}
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
			this.lbGuardar.Click += new System.EventHandler(this.lbGuardar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Precios Programados";
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

		#region ObtenerObjetoPrecio
		private bool ObtenerObjetoPrecio()
		{
			try
			{
                this._id = lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["Fecha"].Replace(" ", "+")));
				string fecha = this._id.Split(" ".ToCharArray())[0];
				string [] split = fecha.Split("/".ToCharArray());
				this._objPrecio = Libreria.Configuracion.PreciosProgramados.PreciosProgramados.ObtenerItem(new DateTime(int.Parse(split[2]),int.Parse(split[1]),int.Parse(split[0])),int.Parse(lblHideArticulo.Text));
				if (this._objPrecio == null)
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
                    ViewState["Control"] = "1";
					CargarArticulos();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1472,Global.Idioma) + "</b>";
                        this.lbGuardar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoPrecio())
						{
							//Visualización de Datos						
							this.ddlArticulo.SelectedValue = this._objPrecio.CodigoArticulo.ToString();
							this.txtPrecio1.Text = this._objPrecio.PrecioArticulo.ToString();
							this.txtPrecio2.Text = this._objPrecio.Precio2Articulo.ToString();
							this.txtPrecio3.Text = this._objPrecio.Precio4Articulo.ToString();
							this.txtPrecio4.Text = this._objPrecio.Precio3Articulo.ToString();
							//this.Calendario.SelectedDate = this._objPrecio.Fecha;
                            this.txtFecha.Text = this._objPrecio.Fecha.ToString();
							this.txtPrecio1.Enabled = this.txtPrecio2.Enabled =
								this.txtPrecio3.Enabled = this.txtPrecio4.Enabled =
								this.lbGuardar.Enabled =
								this._objPrecio.EstadoProgramacion == "Aplicado" ? false:true;
							this.ddlArticulo.Enabled = this.Calendario.Enabled = false;					
							this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1472,Global.Idioma) +": <b>" + this._objPrecio.NombreArticulo.ToString() + "</b>";
                            this.lbGuardar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(788, Global.Idioma);
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma), false);
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
                    txtPrecio1.Text= txtPrecio1.Text.Replace('.',char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString()));
                    txtPrecio1.Text = txtPrecio1.Text.Replace(',', char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString()));
                    txtPrecio2.Text = txtPrecio2.Text.Replace('.', char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString()));
                    txtPrecio2.Text = txtPrecio2.Text.Replace(',', char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString()));
                    txtPrecio3.Text = txtPrecio3.Text.Replace('.', char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString()));
                    txtPrecio3.Text = txtPrecio3.Text.Replace(',', char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString()));
                    txtPrecio4.Text = txtPrecio4.Text.Replace('.', char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString()));
                    txtPrecio4.Text = txtPrecio4.Text.Replace(',', char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString()));
                    
                    if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,143, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objPrecio = 
							new Servipunto.Estacion.Libreria.Configuracion.PreciosProgramados.PrecioProgramado();
							this._objPrecio.CodigoArticulo = int.Parse(ddlArticulo.SelectedValue);
							this._objPrecio.PrecioArticulo = Decimal.Parse(this.txtPrecio1.Text);
							this._objPrecio.Precio2Articulo = Decimal.Parse(this.txtPrecio2.Text);
							this._objPrecio.Precio3Articulo = Decimal.Parse(this.txtPrecio3.Text);
							this._objPrecio.Precio4Articulo = Decimal.Parse(this.txtPrecio4.Text);
							//this._objPrecio.Fecha = this.Calendario.SelectedDate;
                            this._objPrecio.Fecha = Convert.ToDateTime(this.txtFecha.Text);
							Libreria.Configuracion.PreciosProgramados.PreciosProgramados.Adicionar(this._objPrecio);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoPrecio())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,144, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objPrecio.CodigoArticulo = int.Parse(ddlArticulo.SelectedValue);
							this._objPrecio.PrecioArticulo = Decimal.Parse(this.txtPrecio1.Text);
							this._objPrecio.Precio2Articulo = Decimal.Parse(this.txtPrecio2.Text);
							this._objPrecio.Precio3Articulo = Decimal.Parse(this.txtPrecio3.Text);
							this._objPrecio.Precio4Articulo = Decimal.Parse(this.txtPrecio4.Text);
							//this._objPrecio.Fecha = this.Calendario.SelectedDate;
                            this._objPrecio.Fecha = Convert.ToDateTime(this.txtFecha.Text);
							this._objPrecio.Modificar();
						}
						#endregion
					}
					Response.Redirect("PreciosProgramados.aspx");
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

			if(ddlArticulo.SelectedIndex == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1937, Global.Idioma), false);
				return false;
			}
			
			if (this.txtPrecio1.Text.Trim().Length == 0 || this.txtPrecio2.Text.Trim().Length == 0
				|| this.txtPrecio3.Text.Trim().Length == 0 ||this.txtPrecio4.Text.Trim().Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1943, Global.Idioma), false);
				return false;
			}
			
			int i = 1;

			try
			{
				Decimal.Parse(txtPrecio1.Text);
				i++;

				Decimal.Parse(txtPrecio2.Text);
				i++;

				Decimal.Parse(txtPrecio3.Text);
				i++;

				Decimal.Parse(txtPrecio4.Text);
				i++;
			}
			catch
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1243, Global.Idioma) + " " + i + ": " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1792, Global.Idioma), false);
				return false;
			}

			if(Decimal.Parse(txtPrecio1.Text) <= 0)
			{
				this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1792, Global.Idioma)+" 1 "+Libreria.Configuracion.PalabrasIdioma.Traduccion(1944, Global.Idioma), false);
				return false;
			}

			if(Decimal.Parse(txtPrecio2.Text) <= 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1792, Global.Idioma) + " 2 " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1944, Global.Idioma), false);
				return false;
			}

			if(Decimal.Parse(txtPrecio3.Text) <= 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1792, Global.Idioma) + " 3 " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1944, Global.Idioma), false);
				return false;
			}

			if(Decimal.Parse(txtPrecio4.Text) <= 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1792, Global.Idioma) + " 4 " + Libreria.Configuracion.PalabrasIdioma.Traduccion(1944, Global.Idioma), false);
				return false;
			}
			/*
			if(Calendario.SelectedDate < DateTime.Now)
			{
				this.SetError("Debe ingresar una fecha superior al dia de hoy", false);
				return false;
			}*/

			return true;
		}
		#endregion

		#region Cargar Articulos
		private void CargarArticulos()
		{
			try
			{
				ddlArticulo.DataSource = new Libreria.Articulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);
				ddlArticulo.DataTextField = "Descripcion";
				ddlArticulo.DataValueField = "IdArticulo";				
				ddlArticulo.DataBind();
                ddlArticulo.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "0"));
			}
			catch
			{
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma), false);
			}
			
		}
		#endregion

		#region Boton Guardar
		private void lbGuardar_Click(object sender, System.EventArgs e)
		{
			Guardar();
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
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(46,Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(937,Global.Idioma) + " 1";
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma) + " 2";
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma) + " 3";
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma) + " 4";
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1465,Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);


        }

	}
}
