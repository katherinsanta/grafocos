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

namespace Servipunto.Estacion.Web.Modules.Comerciales
{
	/// <summary>
	/// Summary description for Automotor.
	/// </summary>
	public class Automotor : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblHideIdCliente;
        protected System.Web.UI.WebControls.Label lblHideIdNombreCliente;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtTelefono;
		protected System.Web.UI.WebControls.DropDownList ddlEstado;
		protected System.Web.UI.WebControls.HyperLink lblBack1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.HyperLink lblBack2;
		protected System.Web.UI.WebControls.DropDownList ddlFormasPago;
		protected System.Web.UI.WebControls.TextBox txtCupoDisponible;
		protected System.Web.UI.WebControls.TextBox txtCupoAsignado;
		protected System.Web.UI.WebControls.LinkButton lbGuardar;
        protected System.Web.UI.WebControls.LinkButton lbGuardar1;
		protected System.Web.UI.WebControls.LinkButton lbEliminarCupo;
		protected System.Web.UI.WebControls.TextBox txtPagar;
		protected System.Web.UI.WebControls.TextBox txtPlaca;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox txtMarca;
		protected System.Web.UI.WebControls.TextBox txtAño;
		protected System.Web.UI.WebControls.TextBox txtModelo;
		protected System.Web.UI.WebControls.DropDownList ddlCausalBloqueo;
        //ddlTipoAutorizacion
        protected System.Web.UI.WebControls.DropDownList ddlTipoAutorizacion;
		protected System.Web.UI.WebControls.TextBox txtDescuento;
		protected static Libreria.Comercial.CupoAutomotor _objCupo = null;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.ImageButton ibMostrarCalendario;
		protected System.Web.UI.WebControls.Calendar Calendario;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.DropDownList ddlTipoAutomotor;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton EstadoActivo;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton EstadoInactivo;
		protected System.Web.UI.WebControls.TextBox txtNumTanques;
		protected System.Web.UI.WebControls.TextBox txtCapacidadTotal;
		protected System.Web.UI.WebControls.TextBox txtMaximoTanques;
		protected Libreria.Comercial.Automotor _objAutomotor = null;
		protected string _id = null;
		protected string _idCliente = null;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDescuento;
		protected string _nombre = null;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.Label Label12;
        protected System.Web.UI.WebControls.Label Label13;
        protected System.Web.UI.WebControls.Label Label14;
        protected System.Web.UI.WebControls.Label Label15;
        protected System.Web.UI.WebControls.Label Label16;
        protected System.Web.UI.WebControls.Label Label17;
        protected System.Web.UI.WebControls.Label Label18;
        protected System.Web.UI.WebControls.Label Label19;
        protected System.Web.UI.WebControls.Label Label20;
        protected System.Web.UI.WebControls.Label lblLeyendaTipoAutorizacion;
        protected System.Web.UI.WebControls.Label lbLeyendaTipo;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected AjaxControlToolkit.TabPanel TabPanelfilaBasicos;
        protected AjaxControlToolkit.TabPanel TabPanelfilaComerciales;
        protected System.Web.UI.WebControls.TextBox txtFecha;
        protected System.Web.UI.WebControls.TextBox txtCodigoInterno;
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
            Traducir();
            ViewState["Control"] = "0";
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

            if ((Request.QueryString["IdAutomotor"] == null || Request.QueryString["IdAutomotor"] == "") && lblHide.Text == "")
            {
                this._mode = WebApplication.FormMode.New;
                if (lblHideIdCliente.Text == "")
                {
                    lblHideIdCliente.Text = DecryptText(Convert.ToString(Request.QueryString["IdCliente"].Replace(" ", "+")));
                    lblHideIdNombreCliente.Text = DecryptText(Convert.ToString(Request.QueryString["IdNombreCliente"].Replace(" ", "+")));
                }
            }
            else
            {
                this._mode = WebApplication.FormMode.Edit;
            }
			
			if(!IsPostBack)
			{
                if (ViewState["Control"].ToString() != "1")
                {
                    CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                    {
                                               
                        this._id = DecryptText(Convert.ToString(Request.QueryString["IdAutomotor"].Replace(" ", "+")));
                        if (lblHide.Text == "")
                        {
                            lblHide.Text = this._id;
                            CargarTipoAutorizacionExterna();       
                            lblHideIdCliente.Text = DecryptText(Convert.ToString(Request.QueryString["IdCliente"].Replace(" ", "+")));
                            lblHideIdNombreCliente.Text = DecryptText(Convert.ToString(Request.QueryString["IdNombreCliente"].Replace(" ", "+")));
                        }

                    }
                    this.InicializarForma();
                }
			}
			
			

			
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

            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(256, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(155, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(858, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            //Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1266, 1);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1362, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2001, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2002, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1127, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2003, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1384, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1188, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2004, Global.Idioma);

            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1679, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1680, Global.Idioma);
            Label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1681, Global.Idioma);
            lbEliminarCupo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1682, Global.Idioma);

            lblCliente.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(294, Global.Idioma);
            lblFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);


           lbGuardar1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
           lbGuardar1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);

            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1678, Global.Idioma);
            lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1662, Global.Idioma);

            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);

            TabPanelfilaBasicos.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1662, Global.Idioma);
            TabPanelfilaComerciales.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1678, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, 1);
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
			this.lbGuardar.Click += new System.EventHandler(this.lbGuardar_Click);
            //this.lbGuardarCupos.Click += new System.EventHandler(this.lbGuardarCupos_Click);
			this.lbGuardar1.Click += new System.EventHandler(this.lbGuardar1_Click);
			this.lbEliminarCupo.Click += new System.EventHandler(this.lbEliminarCupo_Click);
			this.ddlTipoDescuento.SelectedIndexChanged += new System.EventHandler(this.ddlTipoDescuento_SelectedIndexChanged);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Comerciales";
			const string opcion = "Automotores";
			bool permiso;

			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, 1), true);
				return false;
			}			
			return true;
		}
		#endregion

		#region ObtenerObjetoAutomotor
		private bool ObtenerObjetoAutomotor()
		{
			try
			{			
				
				if(lblHide.Text != null)
					_objAutomotor = Libreria.Comercial.Automotores.ObtenerItem(lblHide.Text);
				else
					_objAutomotor = null;

				if (this._objAutomotor == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, 1) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, 1) + "! [" + this._id + "]", true);
                return false;
			}
		}
		#endregion

		#region Inicialización del Formulario
		private void InicializarForma()
		{			
			try
			{
                ViewState["Control"] = "1";
				CargarFormasPago();
				CargaCausales();
				CargarTiposAutomotor();
                CargarTipoAutorizacionExterna();
				txtCupoDisponible.Enabled = false;
                if (lblHideIdCliente.Text == "")
                    lblCliente.Text = DecryptText(Convert.ToString(Request.QueryString["IdCliente"].Replace(" ", "+")));
                else
                    lblCliente.Text = lblHideIdCliente.Text;


				if (this.VerificarPermisos())
				{
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						txtPagar.Enabled = false;
						txtDescuento.Text = "0";
						txtMaximoTanques.Text = "0";
						txtNumTanques.Text = "0";
						txtCapacidadTotal.Text = "0";
                        //Calendario.SelectedDate = DateTime.Today;
                        CalendarExtender1.SelectedDate = DateTime.Today;
						txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
						#endregion
					}
					else
					{
						
						#region Modo de Edición
						if (this.ObtenerObjetoAutomotor())
						{
							//Visualización de Datos
							txtPlaca.Enabled = false;
							txtPlaca.Text = _objAutomotor.PlacaAutomotor;
							ddlFormasPago.SelectedValue = _objAutomotor.CodigoFormaDePagoAutomtor.ToString();
							ddlCausalBloqueo.SelectedValue = _objAutomotor.CodigoCausalDeBloqueoAutomotor.ToString();
                            //ddlTipoAutorizacion.SelectedValue = _objAutomotor.IdTipoAutorizacioExterna.ToString();	
							txtDescuento.Text = _objAutomotor.DescuentoAutomtor.ToString();
							if(_objAutomotor.Monitoreo == "Activo")
							{
								EstadoActivo.Checked = true;
								EstadoInactivo.Checked = false;
							}
							else
							{
								EstadoActivo.Checked = false;
								EstadoInactivo.Checked = true;
							}
							try
							{
								ddlTipoAutomotor.SelectedValue = _objAutomotor.TipoAutomotor;

							}
							catch(Exception)
							{
								Libreria.Comercial.TipoAutomotor _objTipoAutomotor = new Libreria.Comercial.TipoAutomotor();
								_objTipoAutomotor.NombreTipoAutomotor = _objAutomotor.TipoAutomotor;
								_objTipoAutomotor.Modificar();
								this.CargarTiposAutomotor(); 
								try
								{
									ddlTipoAutomotor.SelectedValue = _objAutomotor.TipoAutomotor;
								}
								catch(Exception){}

							}
							txtFecha.Text = _objAutomotor.FechaProximoMantenimientoAutomotor.ToString("dd/MM/yyyy");
							CalendarExtender1.SelectedDate= _objAutomotor.FechaProximoMantenimientoAutomotor;
							txtMarca.Text = _objAutomotor.MarcaAutomotor;
							txtModelo.Text = _objAutomotor.ModeloAutomotor;
							txtAño.Text = _objAutomotor.AñoAutomotor.ToString();
							txtNumTanques.Text = _objAutomotor.NumeroTanquesAuto.ToString();
							txtCapacidadTotal.Text = _objAutomotor.CapacidadTotalAutomtor.ToString();
							txtMaximoTanques.Text = _objAutomotor.NumeroMaxTanqueosDia.ToString();
                            txtCodigoInterno.Text = _objAutomotor.CodigoInterno;
							_objCupo = Servipunto.Estacion.Libreria.Comercial.CuposAutomotor.ObtenerItem(_objAutomotor.PlacaAutomotor);
                            ddlTipoAutorizacion.SelectedValue = _objAutomotor.IdTipoAutorizacioExterna.ToString();
                            #region Autorizacion Externa
                            ddlTipoAutorizacion.SelectedValue = _objAutomotor.IdTipoAutorizacioExterna.ToString();
                            Libreria.TipoAutorizacionExterna objTipoAutorizacionEx = Libreria.TiposAutorizacionExterna.ObtenerItem(Convert.ToInt32(ddlTipoAutorizacion.SelectedValue));
                            lbLeyendaTipo.Text = objTipoAutorizacionEx.TipoAutorizacion;
                            lblLeyendaTipoAutorizacion.Text = objTipoAutorizacionEx.Descripcion;
                            #endregion
							if(_objCupo != null)
							{								
								txtCupoAsignado.Text = _objCupo.CupoAsignado.ToString();
								txtCupoDisponible.Text = _objCupo.CupoDisponible.ToString();
							}
							else
							{
								txtPagar.Enabled = false;
							}
							this.ddlTipoDescuento.SelectedValue = this._objAutomotor.TipoDescuento.ToString();
							if(ddlTipoDescuento.SelectedValue != "0")
								txtDescuento.Enabled = true;
						}
						#endregion
					}
				}
			}
			catch(Exception ex)
			{
				SetError(ex.Message , false);
				return;
			}
		}
		#endregion
        #region CargarTipoAutorizacionExterna
        private void CargarTipoAutorizacionExterna()
        {
            try
            {
                Libreria.TiposAutorizacionExterna objTipoAutorizanExterna = new Libreria.TiposAutorizacionExterna();
                this.ddlTipoAutorizacion.DataSource = objTipoAutorizanExterna;
                this.ddlTipoAutorizacion.DataTextField = "TipoAutorizacion";
                this.ddlTipoAutorizacion.DataValueField = "IdTipoAutorizacion";
                this.ddlTipoAutorizacion.DataBind();
                #region Autorizacion Externa
                //ddlTipoAutorizacion.SelectedValue = _objAutomotor.IdTipoAutorizacioExterna.ToString();
                //Libreria.TipoAutorizacionExterna objTipoAutorizacionEx = Libreria.TiposAutorizacionExterna.ObtenerItem(Convert.ToInt32(ddlTipoAutorizacion.SelectedValue));
                //lblLeyendaTipoAutorizacion.Text = objTipoAutorizacionEx.Descripcion;
                //if(ddlTipoAutorizacionExterna.change)
                //{
                //    lblLeyendaTipoAutorizacion.Text;
                //}
                #endregion

            }
            catch (Exception ex)
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma) + ex.Message, false);
            }
        }
                #endregion

		#region Guardar Datos Basicos, Forma Pago y cupos
		private void GuardarBasicos(bool redirect)
		{
			if (this.ValidarBasicos())
			{
				try
				{
					lblError.Visible = false;
					_objAutomotor = new Libreria.Comercial.Automotor();
					_objAutomotor.AñoAutomotor = int.Parse(txtAño.Text);
					_objAutomotor.CodigoCausalDeBloqueoAutomotor = int.Parse(ddlCausalBloqueo.SelectedValue);
                    _objAutomotor.CodigoCliente = lblHideIdCliente.Text;
					_objAutomotor.TipoAutomotor = ddlTipoAutomotor.SelectedValue;
					_objAutomotor.Monitoreo = EstadoActivo.Checked? "Activo" : "Inactivo";
					_objAutomotor.CodigoFormaDePagoAutomtor = int.Parse(ddlFormasPago.SelectedValue);
					_objAutomotor.DescuentoAutomtor = Decimal.Parse(txtDescuento.Text.Replace(".",","));
					_objAutomotor.FechaProximoMantenimientoAutomotor = Convert.ToDateTime(this.txtFecha.Text);
					_objAutomotor.NumeroTanquesAuto = int.Parse(txtNumTanques.Text);
					_objAutomotor.CapacidadTotalAutomtor = Decimal.Parse(txtCapacidadTotal.Text);
					_objAutomotor.NumeroMaxTanqueosDia = int.Parse(txtMaximoTanques.Text);
					_objAutomotor.MarcaAutomotor = txtMarca.Text;
					_objAutomotor.ModeloAutomotor = txtModelo.Text;
					_objAutomotor.PlacaAutomotor = txtPlaca.Text;
					_objAutomotor.TipoDescuento = Convert.ToInt16(ddlTipoDescuento.SelectedItem.Value);
                    _objAutomotor.CodigoInterno =txtCodigoInterno.Text.ToString();
                    _objAutomotor.IdTipoAutorizacioExterna = Convert.ToByte (ddlTipoAutorizacion.SelectedValue);

					if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar	
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,291, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						Libreria.Comercial.Automotores.Adicionar(this._objAutomotor);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,292, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						_objAutomotor.Modificar();
						#endregion
					}
					if(redirect)
						Response.Redirect("Automotor.aspx?IdAutomotor=" +
							EncryptText(Convert.ToString(_objAutomotor.PlacaAutomotor)) + "&IdCliente=" +
							EncryptText(lblHideIdCliente.Text) + "&IdNombreCliente=" +
							EncryptText(lblHideIdNombreCliente.Text));
				}
				catch (Exception ex)
				{
					SetError(ex.Message , false);
					return;
				}
			}
			else
			{
				this.lblError.Visible = true;
			}
		}

		private void GuardarCupos()
		{
			if (this.ValidarCupos())
			{
				try
				{
					lblError.Visible = false;
					txtCupoAsignado.Text = txtCupoAsignado.Text;
					txtPagar.Text = txtPagar.Text;
					if (this._mode == WebApplication.FormMode.New || _objCupo == null)
					{
						#region Insertar	
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,371, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						_objCupo = new Libreria.Comercial.CupoAutomotor();
						_objCupo.PlacaAutomotor = txtPlaca.Text;
						_objCupo.CupoAsignado = Decimal.Parse(txtCupoAsignado.Text);
						_objCupo.PagarCupo = Decimal.Parse(txtPagar.Text);
						Libreria.Comercial.CuposAutomotor.Adicionar(_objCupo);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,372, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						_objCupo = new Libreria.Comercial.CupoAutomotor();
						_objCupo.PlacaAutomotor = txtPlaca.Text;
						_objCupo.CupoAsignado = Decimal.Parse(txtCupoAsignado.Text);
						_objCupo.PagarCupo = Decimal.Parse(txtPagar.Text);
						_objCupo.Modificar();
						#endregion
					}

					Response.Redirect("Automotor.aspx?IdAutomotor=" +
					EncryptText(Convert.ToString(_objAutomotor.PlacaAutomotor)) + "&IdCliente=" +
                    EncryptText(lblHideIdCliente.Text) + "&IdNombreCliente=" +
                    EncryptText(lblHideIdNombreCliente.Text));
				}
				catch (Exception ex)
				{
					SetError(ex.Message , false);
					//SetError("Ocurrio un error al guardar el cupo en la DB: " + ex.Message + "<br><br>Detalle del error:<br><br>" +ex.StackTrace, false);

					_objCupo = null;
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
		private bool ValidarCupos()
		{
			if (this.txtCupoAsignado.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCupoAsignado.Text.Trim()))
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1992, 1), false);
					return false;
				}
				else
				{
					if(Decimal.Parse(this.txtCupoAsignado.Text.Trim()) < 0)
					{
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1993, 1), false);
						return false;
					}
				}
			}
			else
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1994, 1), false);
				return false;
			}

			if (this.txtPagar.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtPagar.Text.Trim()))
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1995, 1), false);
					return false;
				}
			}
			else
			{
				this.txtPagar.Text = "0";
			}
			return true;
		}
		private bool ValidarBasicos()
		{
			this.ClearError();
			if (this.txtAño.Text.Trim().Length != 0)
			{
				try
				{
					int.Parse(txtAño.Text.Trim());
				}
				catch(Exception)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2005, 1), false);
					return false;
				}

			}
			else
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2006, 1), false);
				return false;
			}

			if(ddlFormasPago.SelectedIndex == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2007, 1), false);
				return false;
			}

			if (this.txtDescuento.Text.Trim().Length != 0)
			{
				try
				{
					Decimal.Parse(txtDescuento.Text);
				}
				catch(Exception)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2008, 1), false);
					return false;
				}

			}
			else
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2009, 1), false);
				return false;
			}

			if (this.txtNumTanques.Text.Trim().Length != 0)
			{
				try
				{
					int.Parse(txtNumTanques.Text);
				}
				catch(Exception)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2010, 1), false);
					return false;
				}

			}
			else
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2011, 1), false);
				return false;
			}

			if (this.txtCapacidadTotal.Text.Trim().Length != 0)
			{
				try
				{
					Decimal.Parse(txtCapacidadTotal.Text);
				}
				catch(Exception)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2012, 1), false);
					return false;
				}

			}
			else
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2013, 1), false);
				return false;
			}

			if (this.txtMaximoTanques.Text.Trim().Length != 0)
			{
				try
				{
					int.Parse(txtMaximoTanques.Text);
				}
				catch(Exception)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2014, 1), false);
					return false;
				}

			}
			else
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2015, 1), false);
				return false;
			}

			return true;
		}
		#endregion

		#region Botones que guardan los datos
		private void lbGuardar_Click(object sender, System.EventArgs e)
		{
			Session["TabAutomotores"] = "Basicos";
			GuardarBasicos(true);
		}

        private void lbGuardar1_Click(object sender, System.EventArgs e)
        {
            Session["TabAutomotores"] = "Comerciales";
            GuardarBasicos(false);
            GuardarCupos();
        }
		#endregion

		#region Eliminar Cupo
		private void lbEliminarCupo_Click(object sender, System.EventArgs e)
		{
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,373, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				Session["TabAutomotores"] = "Comerciales";
				Servipunto.Estacion.Libreria.Comercial.CuposAutomotor.Eliminar(txtPlaca.Text);
				//Response.Redirect("Automotor.aspx?IdAutomotor=" + EncryptText(Request.QueryString["IdAutomotor"]) + "&IdCliente=" + EncryptText(Request.QueryString["IdCliente"]) + "&IdNombreCliente=" + EncryptText(Request.QueryString["IdNombreCliente"]));
                Response.Redirect("Automotor.aspx?IdAutomotor=" + EncryptText(lblHide.Text) + "&IdCliente=" + EncryptText(lblHideIdCliente.Text) + "&IdNombreCliente=" + EncryptText(lblHideIdNombreCliente.Text));
			}
			catch(Exception ex)
			{
				SetError(ex.Message, false);
			}
		}
		#endregion

		#region Cargar Formas de Pago
		private void CargarFormasPago()
		{
			Libreria.Configuracion.FormasPago objFormasPago = new Libreria.Configuracion.FormasPago();
			ddlFormasPago.DataSource = objFormasPago;
			ddlFormasPago.DataTextField = "Descripcion";
			ddlFormasPago.DataValueField = "IdFormaPago";			
			ddlFormasPago.DataBind();
            ddlFormasPago.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, 1), "0"));
		}
		#endregion

		#region Cargar Los Tipos de Automotor
		private void CargarTiposAutomotor()
		{
			Libreria.TiposDeAutomotor objTipoAutomotor = new Libreria.TiposDeAutomotor();
			ddlTipoAutomotor.DataSource = objTipoAutomotor.Tipos();
			ddlTipoAutomotor.DataBind();
		}
		#endregion

		#region Cargar Causales
		private void CargaCausales()
		{
			Libreria.Comercial.CausalesBloqueo objCausales = new Libreria.Comercial.CausalesBloqueo();
			ddlCausalBloqueo.DataSource = objCausales;
			ddlCausalBloqueo.DataTextField = "DescripcionCausal";
			ddlCausalBloqueo.DataValueField = "CodigoCausal";			
			ddlCausalBloqueo.DataBind();
		}
		#endregion

		#region Seleccionar Imagen
		private void ibMostrarCalendario_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Calendario.Visible = !this.Calendario.Visible;
			this.txtFecha.Text = Calendario.SelectedDate.ToString("dd/MM/yyyy");
			Session["TabAutomotores"] = "Basicos";
		}

		#endregion

		#region Seleccionar fecha en el Calendario
		private void Calendario_SelectionChanged(object sender, System.EventArgs e)
		{
			this.Calendario.Visible = !this.Calendario.Visible;
			this.txtFecha.Text = Calendario.SelectedDate.ToString("dd/MM/yyyy");		
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

		#region Evento para escoger el tipo de descuento
		private void ddlTipoDescuento_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ddlTipoDescuento.SelectedItem.Value == "0")
			{
				this.txtDescuento.Enabled = false;
				this.txtDescuento.Text = "0";
			}
			else if (this.ddlTipoDescuento.SelectedItem.Value == "1" || this.ddlTipoDescuento.SelectedItem.Value == "2")
				this.txtDescuento.Enabled = true;
		}
		#endregion

        protected void ddlTipoAutorizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
