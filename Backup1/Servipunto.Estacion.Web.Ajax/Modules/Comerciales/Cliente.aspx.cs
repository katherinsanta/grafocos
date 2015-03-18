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
	/// Summary description for Cliente.
	/// </summary>
	public class Cliente : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow filaPlaca;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtNIT;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.TextBox txtTelefono;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDoc;
		protected System.Web.UI.WebControls.TextBox txtDireccion;
		protected System.Web.UI.WebControls.DropDownList ddlEstado;
		protected System.Web.UI.WebControls.HyperLink lblBack1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.HyperLink lblBack2;
		protected System.Web.UI.WebControls.DropDownList ddlFormasPago;
		protected System.Web.UI.WebControls.DropDownList cboPais;
		protected System.Web.UI.WebControls.DropDownList cboDepartamento;
		protected System.Web.UI.WebControls.DropDownList cboCiudad;
		protected System.Web.UI.WebControls.TextBox txtCupoDisponible;
		protected System.Web.UI.WebControls.TextBox txtCupoAsignado;
		protected System.Web.UI.WebControls.LinkButton lbGuardar;
		protected System.Web.UI.WebControls.LinkButton lbGuardar1;
		protected System.Web.UI.WebControls.LinkButton lbEliminarCupo;
		protected System.Web.UI.WebControls.TextBox txtPagar;
		protected System.Web.UI.WebControls.TextBox txtCodigoAlterno;
		protected System.Web.UI.WebControls.TextBox txtTipoCredito;
		protected System.Web.UI.WebControls.DropDownList ddlTipoTransaccion;
        protected System.Web.UI.WebControls.DropDownList ddlTipoAutorizacionExterna;
		protected Libreria.Comercial.Cliente _objClientes = null;
		protected System.Web.UI.WebControls.DropDownList ddlPrecioDiferencial;
		protected static Libreria.Comercial.CupoCliente _objCupo = null;
		Libreria.Configuracion.Ciudad _objCiudad = null;
		protected string _id = null;
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
        protected System.Web.UI.WebControls.Label lblLeyendaTipoAutorizacion;
        protected System.Web.UI.WebControls.Label lblleyendatipo;
        protected AjaxControlToolkit.TabPanel TabPanelfilaBasicos;
        protected AjaxControlToolkit.TabPanel TabPanelfilaComerciales;
        protected System.Web.UI.WebControls.Panel pnlForm;

        protected System.Web.UI.WebControls.DropDownList ddlModo;
        protected System.Web.UI.WebControls.DropDownList ddlTipo;
        protected System.Web.UI.WebControls.DropDownList ddlPeriodicidad;

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
			if ((Request.QueryString["IdCliente"] == null || Request.QueryString["IdCliente"] == "") && lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else
				this._mode = WebApplication.FormMode.Edit;
			
			if(!IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdCliente"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                }
                if (ViewState["Control"].ToString() != "1")
                {
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
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(263, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1665, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1084, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(855, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(725, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1145, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(683, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(856, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(148, Global.Idioma);

            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(579, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1675, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1676, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1677, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1679, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1680, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1681, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(265, Global.Idioma);
            lbEliminarCupo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1682, Global.Idioma);


            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1678, Global.Idioma);
            lblBack2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1662, Global.Idioma);
            lblBack1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lbGuardar1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lbGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            TabPanelfilaBasicos.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1662, Global.Idioma);
            TabPanelfilaComerciales.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1678, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
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
			this.lbGuardar.Click += new System.EventHandler(this.lbGuardar_Click);
			this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
			this.cboDepartamento.SelectedIndexChanged += new System.EventHandler(this.cboDepartamento_SelectedIndexChanged);
			this.lbGuardar1.Click += new System.EventHandler(this.lbGuardar1_Click);
			this.lbEliminarCupo.Click += new System.EventHandler(this.lbEliminarCupo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Comerciales";
			const string opcion = "Clientes";
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

		#region ObtenerObjetoClientes
		private bool ObtenerObjetoClientes()
		{
			try
			{
				if(lblHide.Text != "")
					_objClientes = Libreria.Comercial.Clientes.ObtenerItem(lblHide.Text,1);
				else
					_objClientes = null;

				if (this._objClientes == null)
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

        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlTipoDoc
            this.ddlTipoDoc.Items.Clear();
            this.ddlTipoDoc.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlTipoDoc.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(265, Global.Idioma), "Nit"));
            this.ddlTipoDoc.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1124, Global.Idioma), "Cédula Ciudadanía"));
            this.ddlTipoDoc.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2380, Global.Idioma), "Cédula Extanjeréa"));
            this.ddlTipoDoc.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2381, Global.Idioma), "Pasaporte"));            
            this.ddlTipoDoc.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlEstado
            this.ddlEstado.Items.Clear();
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "Activo"));
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "Inactivo"));            
            this.ddlEstado.SelectedValue = "Activo";
            #endregion
            #region poblar RadioButton  ddlTipoTransaccion
            this.ddlTipoTransaccion.Items.Clear();
            this.ddlTipoTransaccion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2383, Global.Idioma), "CREDITO"));
            this.ddlTipoTransaccion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2384, Global.Idioma), "EFECTIVO"));
            this.ddlTipoTransaccion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2385, Global.Idioma), "PRIVADA"));
            this.ddlTipoTransaccion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2382, Global.Idioma), ""));   
            this.ddlTipoTransaccion.SelectedValue = "";
            #endregion

        }
        #endregion

		#region Inicialización del Formulario
		private void InicializarForma()
		{			
			try
			{
                RadioButtonTraduccion();
				CargarFormasPago();
                CargarTipoAutorizacionExterna();
				CargarPrecios();
				this.CargarPaises();
				txtCupoDisponible.Enabled = false;


				if (this.VerificarPermisos())
				{
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						txtPagar.Enabled = false;
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoClientes())
                        {
                            //Visualización de Datos
                            txtCodigo.Enabled = false;
                            txtCodigo.Text = _objClientes.CodigoCliente;
                            txtNIT.Text = _objClientes.NitCedulaCliente.ToString();
                            ddlTipoDoc.SelectedValue = _objClientes.TipoNit;
                            txtNombre.Text = _objClientes.NombreCliente;
                            txtDireccion.Text = _objClientes.DireccionCliente;
                            txtTelefono.Text = _objClientes.TelefonoCliente;
                            txtCodigoAlterno.Text = _objClientes.CodigoAlterno.Trim();
                            txtTipoCredito.Text = _objClientes.TipoCredito.Trim();
                            ddlEstado.SelectedValue = _objClientes.Estadocliente;
                            ddlFormasPago.SelectedValue = _objClientes.FormaDePagoCliente.ToString();
                            ddlPrecioDiferencial.SelectedValue = _objClientes.PrecioDiferencial.ToString();
                            ddlTipoTransaccion.SelectedValue = _objClientes.TipoTransaccion;
                            ddlTipoAutorizacionExterna.SelectedValue = _objClientes.IdTipoAutorizacionExterna.ToString();
                            lblLeyendaTipoAutorizacion.Text = "Estandar";
                            #region Autorizacion Externa
                                ddlTipoAutorizacionExterna.SelectedValue = _objClientes.IdTipoAutorizacionExterna.ToString();
                                Libreria.TipoAutorizacionExterna objTipoAutorizacionEx = Libreria.TiposAutorizacionExterna.ObtenerItem(Convert.ToInt32(ddlTipoAutorizacionExterna.SelectedValue));
                                lblleyendatipo.Text = objTipoAutorizacionEx.TipoAutorizacion;
                                lblLeyendaTipoAutorizacion.Text = objTipoAutorizacionEx.Descripcion;
                            #endregion
                            this.CargarDepartamento(_objClientes.IdCiudad.Trim());
                            _objCupo = Servipunto.Estacion.Libreria.Comercial.CuposCliente.ObtenerItem(_objClientes.CodigoCliente);
                           
                            if (_objCupo != null)
                            {
                                ddlModo.Enabled = false;
                                //ddlPeriodicidad.Enabled = false;
                                ddlTipo.Enabled = false;
                                txtCupoAsignado.Text = _objCupo.CupoAsignado.ToString();
                                txtCupoDisponible.Text = _objCupo.CupoDisponible.ToString();                                
                                
                            }
                            else
                            {
                               
                                txtPagar.Enabled = false;
                            }

                            //							if(objCupoCliente != null && objCupoCliente.CupoAsignado != 0)
                            //								txtCupoDisponible.Enabled = txtCupoAsignado.Enabled = false;
                            //							else
                            //								txtCupoDisponible.Enabled = txtCupoAsignado.Enabled = true;
                        }
						#endregion
					}
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
				return;
			}
		}
		#endregion

		#region Guardar Datos Basicos, Forma Pago y cupos
		private void GuardarBasicos()
		{
			if (this.ValidarBasicos())
			{
				try
				{
					lblError.Visible=false;
					_objClientes = new Libreria.Comercial.Cliente();
					_objClientes.CodigoCliente = txtCodigo.Text;
					_objClientes.DireccionCliente = txtDireccion.Text;
					_objClientes.Estadocliente = ddlEstado.SelectedValue;
					_objClientes.FormaDePagoCliente = int.Parse(ddlFormasPago.SelectedValue);
					_objClientes.NitCedulaCliente = txtNIT.Text.Trim();
					_objClientes.NombreCliente = txtNombre.Text;
					_objClientes.TelefonoCliente = txtTelefono.Text;
					_objClientes.TipoNit = ddlTipoDoc.SelectedValue;
					_objClientes.PrecioDiferencial = int.Parse(ddlPrecioDiferencial.SelectedValue);
					_objClientes.IdCiudad = this.cboCiudad.SelectedValue;
					_objClientes.CodigoAlterno = txtCodigoAlterno.Text;
					_objClientes.TipoCredito = txtTipoCredito.Text.Trim();
					_objClientes.TipoTransaccion = ddlTipoTransaccion.SelectedValue;
                    _objClientes.IdTipoAutorizacionExterna=int.Parse(ddlTipoAutorizacionExterna.SelectedValue);
                    #region Autorizacion Externa
                    ddlTipoAutorizacionExterna.SelectedValue = _objClientes.IdTipoAutorizacionExterna.ToString();
                    Libreria.TipoAutorizacionExterna objTipoAutorizacionEx = Libreria.TiposAutorizacionExterna.ObtenerItem(Convert.ToInt32(ddlTipoAutorizacionExterna.SelectedValue));
                    lblleyendatipo.Text = objTipoAutorizacionEx.TipoAutorizacion;
                    lblLeyendaTipoAutorizacion.Text = objTipoAutorizacionEx.Descripcion;
                    #endregion
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,283, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						Libreria.Comercial.Clientes.Adicionar(this._objClientes);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,284, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						_objClientes.Modificar();
						#endregion
					}
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
					this._objClientes = null;
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,287, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						_objCupo = new Libreria.Comercial.CupoCliente();
						_objCupo.CodigoCliente = txtCodigo.Text;
						_objCupo.CupoAsignado = Decimal.Parse(txtCupoAsignado.Text);
						_objCupo.PagarCupo = Decimal.Parse(txtPagar.Text);
                        _objCupo.Unidades = ddlModo.SelectedValue == "Volumen" ? "V":"P";
						Libreria.Comercial.CuposCliente.Adicionar(_objCupo);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,288, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						_objCupo = new Libreria.Comercial.CupoCliente();
						_objCupo.CodigoCliente = txtCodigo.Text;
						_objCupo.CupoAsignado = Decimal.Parse(txtCupoAsignado.Text);
						_objCupo.PagarCupo = Decimal.Parse(txtPagar.Text);
                        _objCupo.Unidades = ddlModo.SelectedValue == "Volumen" ? "V" : "P";                       
						_objCupo.Modificar();
						#endregion
					}
					Response.Redirect("Cliente.aspx?IdCliente=" + EncryptText(_objCupo.CodigoCliente.ToString()));
				}
				catch (Exception ex)
				{
					SetError(ex.Message, false);
					_objCupo = null;

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
		private bool ValidarCupos()
		{
			if (this.txtCupoAsignado.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCupoAsignado.Text.Trim()))
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1992, Global.Idioma), false);
					return false;
				}
				else
				{
					if(Decimal.Parse(this.txtCupoAsignado.Text.Trim()) < 0)
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1993, Global.Idioma), false);
						return false;
					}
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1994, Global.Idioma), false);
				return false;
			}

			if (this.txtPagar.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtPagar.Text.Trim()))
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1995, Global.Idioma), false);
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
			if (this.txtNIT.Text.Trim().Length != 0)
			{
				if(txtNIT.Text.Length < 5)	
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1996, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1997, Global.Idioma), false);
				return false;
			}
			if(ddlTipoDoc.SelectedIndex == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1998, Global.Idioma), false);
				return false;
			}
			if(txtNombre.Text.Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1999, Global.Idioma), false);
				return false;
			}			

			if(ddlPrecioDiferencial.SelectedValue == "-1")
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2000, Global.Idioma), false);
				return false;
			}

			return true;
		}
		#endregion

		#region Botones que guardan los datos
		private void lbGuardar_Click(object sender, System.EventArgs e)
		{
			Session["TabClientes"] = "Basicos";
			GuardarBasicos();
		}

		private void lbGuardar1_Click(object sender, System.EventArgs e)
		{
			Session["TabClientes"] = "Comerciales";
			GuardarBasicos();
			GuardarCupos();
		}
		#endregion

		#region Eliminar Cupo
		private void lbEliminarCupo_Click(object sender, System.EventArgs e)
		{
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,289, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				Session["TabClientes"] = "Comerciales";
				Servipunto.Estacion.Libreria.Comercial.CuposCliente.Eliminar(txtCodigo.Text);
				//Response.Redirect("Cliente.aspx?IdCliente=" + EncryptText(Request.QueryString["IdCliente"].ToString()));
				Response.Redirect("Cliente.aspx?IdCliente=" +  lblHide.Text);
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
            ddlFormasPago.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "0"));
		}
		#endregion
        #region
        private void CargarTipoAutorizacionExterna()
        {
            try
            {
                Libreria.TiposAutorizacionExterna objTipoAutorizanExterna = new Libreria.TiposAutorizacionExterna();
                this.ddlTipoAutorizacionExterna.DataSource = objTipoAutorizanExterna;
                this.ddlTipoAutorizacionExterna.DataTextField = "TipoAutorizacion";
                this.ddlTipoAutorizacionExterna.DataValueField = "IdTipoAutorizacion";
                this.ddlTipoAutorizacionExterna.DataBind();

            }
            catch (Exception ex)
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma) + ex.Message, false);
            }
        }
         #endregion

		#region CargarPrecios
		private void CargarPrecios()
		{
			ddlPrecioDiferencial.DataSource = new Servipunto.Estacion.Libreria.Comercial.PreciosDiferenciales();
			ddlPrecioDiferencial.DataTextField = "IdPrecioDiferencial";
			ddlPrecioDiferencial.DataValueField = "IdPrecioDiferencial";			
			ddlPrecioDiferencial.DataBind();
            ddlPrecioDiferencial.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "-1"));
		}
		#endregion

		#region Método CargarDepartamento por ciudad para edición

		private void CargarDepartamento(string codCiudad)
		{
			try
			{
				this._objCiudad  = Libreria.Configuracion.Ciudades.Obtener(codCiudad);
				this.CargarDepartamentos(this._objCiudad.IdPais);		
			
				if (this.cboDepartamento.Items.Count != 0)
				{
					this.cboDepartamento.SelectedValue = this._objCiudad.IdDepartamento.ToString();		

					if (this.cboDepartamento.SelectedIndex != -1)
					{
						this.CargarCiudades(Convert.ToInt32(this._objCiudad.IdDepartamento));
						this.cboCiudad.SelectedValue = codCiudad;
						this.CargarSoloPaises();			
						this.cboPais.SelectedValue = this._objCiudad.IdPais.ToString();
					}

				}
			}
			catch(Exception)
			{
				_objClientes.ActualizarCiudadCliente();
				InicializarForma();
			}
		}

		private void CargarSoloPaises()
		{
			Libreria.Configuracion.Paises objPaises = new Servipunto.Estacion.Libreria.Configuracion.Paises();
			cboPais.DataSource = objPaises;
			cboPais.DataValueField = "IdPais";
			cboPais.DataTextField = "Nombre";
			cboPais.DataBind();
			objPaises = null;
		}
		
		#endregion

		#region Cargar Paises Departamentos y Ciudades para insercion
		private void CargarPaises()
		{
			Libreria.Configuracion.Paises objPaises = new Servipunto.Estacion.Libreria.Configuracion.Paises();

			cboPais.DataSource = objPaises;
			cboPais.DataValueField = "IdPais";
			cboPais.DataTextField = "Nombre";
			cboPais.DataBind();
			cboPais.SelectedValue = "1";
			objPaises = null;

			if (this.cboPais.Items.Count != 0)
			{
				if (this.cboPais.SelectedIndex != -1)
					this.CargarDepartamentos(Convert.ToInt32(this.cboPais.SelectedValue));
			}
			else
                this.cboPais.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma));
		}

		private void CargarDepartamentos(int idPais)
		{
			Libreria.Configuracion.Departamentos objDepartamentos = new Servipunto.Estacion.Libreria.Configuracion.Departamentos(idPais);

			cboDepartamento.DataSource = objDepartamentos;
			cboDepartamento.DataValueField = "IdDepartamento";
			cboDepartamento.DataTextField = "Nombre";
			cboDepartamento.DataBind();
			objDepartamentos = null;			
			
			if (this.cboDepartamento.Items.Count == 0)
			{
                this.cboDepartamento.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma));
				this.cboCiudad.Enabled = false;
				if (this.cboCiudad.Items.Count != 0)
					this.cboCiudad.Items.Clear();
			}
			else
			{
				if (this.cboDepartamento.SelectedIndex != -1)
				{
					this.CargarCiudades(Convert.ToInt32(this.cboDepartamento.SelectedValue));
					this.cboCiudad.Enabled = true;
				}						
			}
		}

		private void CargarCiudades(int idDepartamento)
		{
			Libreria.Configuracion.Ciudades objCiudades = new Servipunto.Estacion.Libreria.Configuracion.Ciudades(idDepartamento);

			cboCiudad.Items.Clear();
			cboCiudad.DataSource = objCiudades;
			cboCiudad.DataValueField = "IdCiudad";
			cboCiudad.DataTextField = "Nombre";
			cboCiudad.DataBind();
			objCiudades = null;

			if (this.cboCiudad.Items.Count == 0)
			{
                this.cboCiudad.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma));
				this.cboCiudad.Enabled = false;
			}
			else
				this.cboCiudad.Enabled = true;
		}
		#endregion

		#region Evento para cargar Departamentos de acuerdo al país seleccionado.
		private void cboPais_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.CargarDepartamentos(Convert.ToInt32(this.cboPais.SelectedValue));
			
		}
		#endregion

		#region Evento para cargar Ciudades de acuerdo al departamento seleccionado.
		private void cboDepartamento_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.CargarCiudades(Convert.ToInt32(this.cboDepartamento.SelectedValue));
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
	}
}
