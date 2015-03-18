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


			//Creado:		Ing. Elvis Astaiza
			//Fecha:		03-09-2007

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
	/// <summary>
	/// Descripción breve de ConfInterfazContableNew.
	/// </summary>
	public class ConfInterfazContableNew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblTituloGenerales;
		protected System.Web.UI.WebControls.TextBox txtNCAbono;
		protected System.Web.UI.WebControls.RadioButtonList optNCAbono;
		protected System.Web.UI.WebControls.CheckBox chkNTAbono;
		protected System.Web.UI.WebControls.TextBox txtNCDescuentos;
		protected System.Web.UI.WebControls.RadioButtonList optNCDescuentos;
		protected System.Web.UI.WebControls.CheckBox chkNTDescuentos;
		protected System.Web.UI.WebControls.TextBox txtNCIva;
		protected System.Web.UI.WebControls.RadioButtonList optNCIva;
		protected System.Web.UI.WebControls.CheckBox chkNTIva;
		protected System.Web.UI.WebControls.TextBox txtNCVentasGNV;
		protected System.Web.UI.WebControls.RadioButtonList optNCVentasGNV;
		protected System.Web.UI.WebControls.CheckBox chkNCVentasGNV;
		protected System.Web.UI.WebControls.TextBox txtNCVentasCanas;
		protected System.Web.UI.WebControls.RadioButtonList optNCVentasCanas;
		protected System.Web.UI.WebControls.CheckBox chkNCVentasCanas;
		protected System.Web.UI.WebControls.TextBox txtCodCentroCostos;
		protected System.Web.UI.WebControls.TextBox txtNumCompFacturas;
		protected System.Web.UI.WebControls.TextBox txtCodSucursal;
		protected System.Web.UI.WebControls.Label lblTituloConfiguracion;
		protected System.Web.UI.WebControls.HyperLink lblBackConf;
		protected System.Web.UI.WebControls.TextBox txtClasePedido;
		protected System.Web.UI.WebControls.TextBox txtOrganizacionVentas;
		protected System.Web.UI.WebControls.TextBox txtCanal;
		protected System.Web.UI.WebControls.TextBox txtGrupoVendedores;
		protected System.Web.UI.WebControls.TextBox txtOficinaVentas;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.HyperLink lblBack;
		//Declaración de variable que contiene la colección de objetos
		protected Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables;
		//Declaración de Variable que contiene 1 solo elemento de la colección de objetos
		protected Servipunto.Estacion.Libreria.InterfazContable objInterfazContable;
		protected System.Web.UI.WebControls.LinkButton lblGuardar;
		protected System.Web.UI.WebControls.LinkButton lblGuardar2;
		protected System.Web.UI.WebControls.TextBox txtSector;
		//Declaración de variable que se encarga de contener el estado de la forma
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.TextBox txtAsignacion;
		protected System.Web.UI.WebControls.TextBox txtPuestoExpedicion;
		protected System.Web.UI.WebControls.TextBox txtCodClientesContado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.TextBox txtClaseDoc;
		protected System.Web.UI.WebControls.TextBox txtSociedad;
		protected System.Web.UI.WebControls.TextBox txtTipoMoneda;
		protected System.Web.UI.WebControls.LinkButton lblGuardar3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.LinkButton lblGuardar4;
		protected System.Web.UI.WebControls.TextBox txtRutaImportar;
		protected System.Web.UI.WebControls.TextBox txtRutaExportar;
		protected System.Web.UI.WebControls.TextBox txtRutaImportarClientesCorporativos;
		protected System.Web.UI.WebControls.TextBox txtCodigoEstacionSap;
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
        protected System.Web.UI.WebControls.Label Label21;
        protected System.Web.UI.WebControls.Label Label22;
        protected System.Web.UI.WebControls.Label Label23;
        protected System.Web.UI.WebControls.Label Label24;
        protected System.Web.UI.WebControls.Label Label25;
        protected System.Web.UI.WebControls.Label Label26;
        protected System.Web.UI.WebControls.Label Label27;
        protected System.Web.UI.WebControls.Label Label28;
        protected System.Web.UI.WebControls.Label Label29;
        protected System.Web.UI.WebControls.Label Label30;
        protected System.Web.UI.WebControls.Label Label31;
        protected System.Web.UI.WebControls.Label Label32;
        protected System.Web.UI.WebControls.Label Label33;
        protected System.Web.UI.WebControls.Label Label34;
        protected System.Web.UI.WebControls.Label Label35;
        protected AjaxControlToolkit.TabPanel TabPanelEstandar;
        protected AjaxControlToolkit.TabPanel TabPanelSAP;
        protected AjaxControlToolkit.TabPanel TabPanelFilaCabeceraTraslados;
        protected AjaxControlToolkit.TabPanel TabPanelFilaCabeceraVentas;
        protected AjaxControlToolkit.TabPanel TabPanelFilaVarios;
        protected System.Web.UI.WebControls.Panel pnlForm;
		
		protected Libreria.Comercial.Cliente _objClientes = null;
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
		#region Form Load Event


		private void Page_Load(object sender, System.EventArgs e)
		{
			//Poblo la variable con la colección de configuraciones disponibles en la BD
			objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
			if (objInterfazContables != null)
			{
				if(objInterfazContables.Count > 0)
				{
					this._mode = WebApplication.FormMode.Edit;
					this.Session["IdInterfaz"] = objInterfazContables[0].IDInterfaz;
				}
				else
					this._mode = WebApplication.FormMode.New;

				if(!this.Page.IsPostBack)
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,172, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					this.InicializarForma();
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
                this.pnlForm.Visible = false;

        }

        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
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
            TabPanelEstandar.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1548, Global.Idioma);
            TabPanelSAP.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1564, Global.Idioma);
            TabPanelFilaCabeceraTraslados.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1203, Global.Idioma);
            TabPanelFilaCabeceraVentas.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1208, Global.Idioma);
            TabPanelFilaVarios.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1217, Global.Idioma);            

            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1808, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1583, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1249, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1246, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1247, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1278, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1551, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1552, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1553, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1554, Global.Idioma);

            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1555, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1556, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1557, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1558, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1559, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1579, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1580, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1581, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1582, Global.Idioma);
            Label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1567, Global.Idioma);

            Label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1568, Global.Idioma);
            Label22.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1569, Global.Idioma);
            Label23.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1570, Global.Idioma);
            Label24.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1571, Global.Idioma);
            Label25.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1572, Global.Idioma);
            Label26.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1573, Global.Idioma);
            Label27.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1574, Global.Idioma);
            Label28.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1575, Global.Idioma);
            Label29.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1576, Global.Idioma);
            Label30.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1584, Global.Idioma);

            Label31.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1585, Global.Idioma);
            Label32.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1586, Global.Idioma);
            Label33.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1587, Global.Idioma);
            Label34.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1588, Global.Idioma);
            Label35.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1589, Global.Idioma);


            chkNTAbono.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1278, Global.Idioma);
            chkNTDescuentos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1278, Global.Idioma);
            chkNTIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1278, Global.Idioma);
            chkNCVentasGNV.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1278, Global.Idioma);
            chkNCVentasCanas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1278, Global.Idioma);

            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1272, Global.Idioma);
            lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            lblGuardar3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            Hyperlink1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblTituloConfiguracion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1808, Global.Idioma);
            lblGuardar2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBackConf.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            lblGuardar4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            Hyperlink2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  optNCAbono
            this.optNCAbono.Items.Clear();
            this.optNCAbono.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(693, Global.Idioma), "1"));
            this.optNCAbono.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1976, Global.Idioma), "0"));
            this.optNCAbono.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  optNCDescuentos
            this.optNCDescuentos.Items.Clear();
            this.optNCDescuentos.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(693, Global.Idioma), "1"));
            this.optNCDescuentos.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1976, Global.Idioma), "0"));
            this.optNCDescuentos.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  optNCIva
            this.optNCIva.Items.Clear();
            this.optNCIva.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(693, Global.Idioma), "1"));
            this.optNCIva.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1976, Global.Idioma), "0"));
            this.optNCIva.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  optNCVentasGNV
            this.optNCVentasGNV.Items.Clear();
            this.optNCVentasGNV.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(693, Global.Idioma), "1"));
            this.optNCVentasGNV.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1976, Global.Idioma), "0"));
            this.optNCVentasGNV.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  optNCVentasCanas
            this.optNCVentasCanas.Items.Clear();
            this.optNCVentasCanas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(693, Global.Idioma), "1"));
            this.optNCVentasCanas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1976, Global.Idioma), "0"));
            this.optNCVentasCanas.SelectedValue = "0";
            #endregion

        }
        #endregion
		#region Método Inicializar Forma
		private void InicializarForma()
		{
			if(this.VerificarPermisos())
			{
                RadioButtonTraduccion();
				try
				{
					//this.lblFormTitle.Text = "<b>Creación, Configuración y Generación de Archivos Planos</b>";
					this.lblBack.NavigateUrl = "Default.aspx";
					if(this._mode == WebApplication.FormMode.New)
					{
						#region Modo Inserción
					
						#endregion
					}
					else
					{
						#region Modo Edición
						objInterfazContable = objInterfazContables[0];
						//Abono
						this.txtNCAbono.Text = objInterfazContable.NCAbono.ToString().Trim();
						this.optNCAbono.SelectedValue = objInterfazContable.NATAbono==false ? "0" : "1";
						this.chkNTAbono.Checked = objInterfazContable.NTAbono;
						//Descuentos
						this.txtNCDescuentos.Text = objInterfazContable.NCDescuento.ToString().Trim();
						this.optNCDescuentos.SelectedValue = objInterfazContable.NATDescuento==false ? "0" : "1";
						this.chkNTDescuentos.Checked = objInterfazContable.NTDescuento;
						//IVA
						this.txtNCIva.Text = objInterfazContable.NCIva.ToString().Trim();
						this.optNCIva.SelectedValue = objInterfazContable.NATIva==false ? "0" : "1";
						this.chkNTIva.Checked = objInterfazContable.NTIva;
						//Ventas GNV
						this.txtNCVentasGNV.Text = objInterfazContable.NCVentasGNV.ToString().Trim();
						this.optNCVentasGNV.SelectedValue = objInterfazContable.NATVentasGNV==false ? "0" : "1";
						this.chkNCVentasGNV.Checked = objInterfazContable.NTVentasGNV;
						//Ventas Canastilla
						this.txtNCVentasCanas.Text = objInterfazContable.NCVentasCanas.ToString().Trim();
						this.optNCVentasCanas.SelectedValue = objInterfazContable.NATVentasCanas==false ? "0" : "1";
						this.chkNCVentasCanas.Checked = objInterfazContable.NTVentasCanas;
						//Parámetros Específicos
						this.txtCodCentroCostos.Text = objInterfazContable.CODCentroCostos.ToString().Trim();
						this.txtNumCompFacturas.Text = objInterfazContable.NUMCompFacturas.ToString().Trim();
						this.txtCodSucursal.Text = objInterfazContable.CODSucursal.ToString().Trim();

						//Parámetros para SAP
						this.txtClasePedido.Text = objInterfazContable.ClasedePedido_Sap.Trim();
						this.txtOrganizacionVentas.Text = objInterfazContable.OrganizaciondeVentas_Sap.Trim();
						this.txtCanal.Text = objInterfazContable.Canal_Sap.Trim();
						this.txtSector.Text = objInterfazContable.Sector_Sap.Trim();
						this.txtOficinaVentas.Text = objInterfazContable.OficinadeVentas_Sap.Trim();
						this.txtGrupoVendedores.Text = objInterfazContable.GrupodeVendedores_Sap.Trim();
						this.txtAsignacion.Text = objInterfazContable.Asignacion_Sap.Trim();
						this.txtCodClientesContado.Text = objInterfazContable.Cod_Cli_Contado_Sap.Trim();
						this.txtPuestoExpedicion.Text = objInterfazContable.Puesto_Exp_Sap.Trim();
						this.txtClaseDoc.Text = objInterfazContable.Clase_Doc_Sap.Trim();
						this.txtSociedad.Text = objInterfazContable.Sociedad_Sap.Trim();
						this.txtTipoMoneda.Text = objInterfazContable.Tipo_Moneda_Sap.Trim();
						this.txtRutaImportar.Text = objInterfazContable.RutaImportarSap.Trim();
						this.txtRutaExportar.Text = objInterfazContable.RutaExportarSap.Trim();
						this.txtCodigoEstacionSap.Text = objInterfazContable.CodigoEstacionSap.Trim();
						//otros
						this.txtRutaImportarClientesCorporativos.Text = objInterfazContable.RutaImportarClientesCorporativos.Trim();

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

		private void lblGuardar_Click(object sender, System.EventArgs e)
		{
			this.Guardar();
		}

		private void lblGuardar2_Click(object sender, System.EventArgs e)
		{
			this.Guardar();
		}

		
		private void Guardar()
		{
			if(this.Validar())
			{
				try
				{
					if(this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,173, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this.objInterfazContable = new Servipunto.Estacion.Libreria.InterfazContable();
						
						//Abono
						this.objInterfazContable.NCAbono = this.txtNCAbono.Text.ToString().Trim();
						this.objInterfazContable.NATAbono = this.optNCAbono.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTAbono = this.chkNTAbono.Checked;
						//this.objInterfazContable.NTAbono = this.txtNTAbono.Text.Length==0 ? 0 : Convert.ToInt32(this.txtNTAbono.Text.ToString().Trim());
						
						//Descuento
						this.objInterfazContable.NCDescuento = this.txtNCDescuentos.Text.ToString().Trim();
						this.objInterfazContable.NATDescuento = this.optNCDescuentos.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTDescuento = this.chkNTDescuentos.Checked;
						//this.objInterfazContable.NTDescuento = this.txtNTDescuentos.Text.Length==0 ? 0 : Convert.ToInt32(this.txtNTDescuentos.Text.ToString().Trim());
						
						//IVA
						this.objInterfazContable.NCIva = this.txtNCIva.Text.ToString().Trim();
						this.objInterfazContable.NATIva = this.optNCIva.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTIva = this.chkNTIva.Checked;
						//this.objInterfazContable.NTIva = this.txtNTIva.Text.Length==0 ? 0 : Convert.ToInt32(this.txtNTIva.Text.ToString().Trim());
						
						//Ventas GNV
						this.objInterfazContable.NCVentasGNV = this.txtNCVentasGNV.Text.ToString().Trim();
						this.objInterfazContable.NATVentasGNV = this.optNCVentasGNV.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTVentasGNV = this.chkNCVentasGNV.Checked;
						
						//Ventas Canastilla
						this.objInterfazContable.NCVentasCanas = this.txtNCVentasCanas.Text.ToString().Trim();
						this.objInterfazContable.NATVentasCanas = this.optNCVentasCanas.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTVentasCanas = this.chkNCVentasCanas.Checked;
						
						
						//Parámetros específicos
						this.objInterfazContable.CODCentroCostos = this.txtCodCentroCostos.Text.ToString().Trim();
						this.objInterfazContable.NUMCompFacturas = this.txtNumCompFacturas.Text.ToString().Trim();
						this.objInterfazContable.CODSucursal = this.txtCodSucursal.Text.ToString().Trim();

						//Parámetros para SAP
						this.objInterfazContable.ClasedePedido_Sap = this.txtClasePedido.Text.ToString().Trim();
						this.objInterfazContable.OrganizaciondeVentas_Sap = this.txtOrganizacionVentas.Text.ToString().Trim();
						this.objInterfazContable.Canal_Sap = this.txtCanal.Text.ToString().Trim();
						this.objInterfazContable.Sector_Sap = this.txtSector.Text.ToString().Trim();
						this.objInterfazContable.OficinadeVentas_Sap = this.txtOficinaVentas.Text.ToString().Trim();
						this.objInterfazContable.GrupodeVendedores_Sap = this.txtGrupoVendedores.Text.ToString().Trim();
						this.objInterfazContable.Asignacion_Sap = this.txtAsignacion.Text.ToString().Trim();
						this.objInterfazContable.Cod_Cli_Contado_Sap = this.txtCodClientesContado.Text.ToString().Trim();
						this.objInterfazContable.Puesto_Exp_Sap = this.txtPuestoExpedicion.Text.ToString().Trim();
						this.objInterfazContable.Clase_Doc_Sap = this.txtClaseDoc.Text.ToString().Trim();
						this.objInterfazContable.Sociedad_Sap = this.txtSociedad.Text.ToString().Trim();
						this.objInterfazContable.Tipo_Moneda_Sap = this.txtTipoMoneda.Text.ToString().Trim();
						this.objInterfazContable.RutaImportarSap = this.txtRutaImportar.Text.ToString().Trim();
						this.objInterfazContable.RutaExportarSap = this.txtRutaExportar .Text.ToString().Trim();
						this.objInterfazContable.CodigoEstacionSap = this.txtCodigoEstacionSap.Text.Trim();
						//otros
						this.objInterfazContable.RutaImportarClientesCorporativos = this.txtRutaImportarClientesCorporativos.Text.ToString().Trim();

						//Se envia el objeto completo al método Insertar
						Servipunto.Estacion.Libreria.Planos.InterfazContables.Adicionar(this.objInterfazContable);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,174, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this.objInterfazContable = new Servipunto.Estacion.Libreria.InterfazContable();
						//Clarifica que es para el idInterfaz que se encontro en primer lugar
						this.objInterfazContable.IDInterfaz = Convert.ToInt32(this.Session["IdInterfaz"]);

						//Abono
						this.objInterfazContable.NCAbono = this.txtNCAbono.Text.ToString().Trim();
						this.objInterfazContable.NATAbono = this.optNCAbono.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTAbono = this.chkNTAbono.Checked;
						//this.objInterfazContable.NTAbono = this.txtNTAbono.Text.Length==0 ? 0 : Convert.ToInt32(this.txtNTAbono.Text.ToString().Trim());
						//Descuento
						this.objInterfazContable.NCDescuento = this.txtNCDescuentos.Text.ToString().Trim();
						this.objInterfazContable.NATDescuento = this.optNCDescuentos.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTDescuento = this.chkNTDescuentos.Checked;
						//this.objInterfazContable.NTDescuento = this.txtNTDescuentos.Text.Length==0 ? 0 : Convert.ToInt32(this.txtNTDescuentos.Text.ToString().Trim());
						//IVA
						this.objInterfazContable.NCIva = this.txtNCIva.Text.ToString().Trim();
						this.objInterfazContable.NATIva = this.optNCIva.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTIva = this.chkNTIva.Checked;
						//this.objInterfazContable.NTIva = this.txtNTIva.Text.Length==0 ? 0 : Convert.ToInt32(this.txtNTIva.Text.ToString().Trim());
						
						//Ventas GNV
						this.objInterfazContable.NCVentasGNV = this.txtNCVentasGNV.Text.ToString().Trim();
						this.objInterfazContable.NATVentasGNV = this.optNCVentasGNV.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTVentasGNV = this.chkNCVentasGNV.Checked;

						//Ventas Canastilla
						this.objInterfazContable.NCVentasCanas = this.txtNCVentasCanas.Text.ToString().Trim();
						this.objInterfazContable.NATVentasCanas = this.optNCVentasCanas.SelectedValue=="0"?false:true;
						this.objInterfazContable.NTVentasCanas = this.chkNCVentasCanas.Checked;
						
						//Parámetros específicos
						this.objInterfazContable.CODCentroCostos = this.txtCodCentroCostos.Text.ToString().Trim();
						this.objInterfazContable.NUMCompFacturas = this.txtNumCompFacturas.Text.ToString().Trim();
						this.objInterfazContable.CODSucursal = this.txtCodSucursal.Text.ToString().Trim();
						
						//Parámetros para SAP
						this.objInterfazContable.ClasedePedido_Sap = this.txtClasePedido.Text.ToString().Trim();
						this.objInterfazContable.OrganizaciondeVentas_Sap = this.txtOrganizacionVentas.Text.ToString().Trim();
						this.objInterfazContable.Canal_Sap = this.txtCanal.Text.ToString().Trim();
						this.objInterfazContable.Sector_Sap = this.txtSector.Text.ToString().Trim();
						this.objInterfazContable.OficinadeVentas_Sap = this.txtOficinaVentas.Text.ToString().Trim();
						this.objInterfazContable.GrupodeVendedores_Sap = this.txtGrupoVendedores.Text.ToString().Trim();
						this.objInterfazContable.Asignacion_Sap = this.txtAsignacion.Text.ToString().Trim();
						this.objInterfazContable.Cod_Cli_Contado_Sap = this.txtCodClientesContado.Text.ToString().Trim();
						this.objInterfazContable.Puesto_Exp_Sap = this.txtPuestoExpedicion.Text.ToString().Trim();
						this.objInterfazContable.Clase_Doc_Sap = this.txtClaseDoc.Text.ToString().Trim();
						this.objInterfazContable.Sociedad_Sap = this.txtSociedad.Text.ToString().Trim();
						this.objInterfazContable.Tipo_Moneda_Sap = this.txtTipoMoneda.Text.ToString().Trim();
						this.objInterfazContable.RutaImportarSap = this.txtRutaImportar.Text.ToString().Trim();
						this.objInterfazContable.RutaExportarSap = this.txtRutaExportar .Text.ToString().Trim();
						this.objInterfazContable.CodigoEstacionSap = this.txtCodigoEstacionSap.Text.Trim();
						
						//otros
						this.objInterfazContable.RutaImportarClientesCorporativos = this.txtRutaImportarClientesCorporativos.Text.ToString().Trim();

						//Se envia el objeto al método Modificar



						this.objInterfazContable.Modificar();
						#endregion
					}
					Response.Redirect("Default.aspx");
				}
				catch (Exception ex)
				{
					this.lblError.Visible=true;
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
					this.objInterfazContable = null;
				}
			}
			else
			{
				this.lblError.Visible = true;
			}
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
			this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
			this.lblGuardar3.Click += new System.EventHandler(this.lblGuardar2_Click);
			this.lblGuardar2.Click += new System.EventHandler(this.lblGuardar2_Click);
			this.lblGuardar4.Click += new System.EventHandler(this.lblGuardar2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Verificar Permisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Interfaz Contable";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion,"Configuracion Interfaz Contable");

			if(!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                this.pnlForm.Visible = false;
                //this.MyForm.Visible=false;
				return false;
			}
			return true;
		}
		#endregion		

		#region Validar
		private bool Validar()
		{
			if (this.txtNCAbono.Text.Trim().Length != 0 ) 
			{
				try
				{
					if( int.Parse(this.txtNCAbono.Text.Trim()) < 1)
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1977, Global.Idioma), false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1978, Global.Idioma), false);
					return false;
				}
			}

			if (this.txtNCDescuentos.Text.Trim().Length != 0 ) 
			{
				try
				{
					if( int.Parse(this.txtNCDescuentos.Text.Trim()) < 1)
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1977, Global.Idioma), false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1978, Global.Idioma), false);
					return false;
				}
			}

			if (this.txtNCIva.Text.Trim().Length != 0 ) 
			{
				try
				{
					if( int.Parse(this.txtNCIva.Text.Trim()) < 1)
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1977, Global.Idioma), false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1978, Global.Idioma), false);
					return false;
				}
			}

			if (this.txtCodCentroCostos.Text.Trim().Length != 0 ) 
			{
				try
				{
					if( int.Parse(this.txtNCIva.Text.Trim()) < 1)
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1979, Global.Idioma), false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1980, Global.Idioma), false);
					return false;
				}
			}

			if (this.txtNumCompFacturas.Text.Trim().Length != 0 ) 
			{
				try
				{
					if( int.Parse(this.txtNumCompFacturas.Text.Trim()) < 1)
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1981, Global.Idioma), false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1982, Global.Idioma), false);
					return false;
				}
			}

			if (this.txtCodSucursal.Text.Trim().Length != 0 ) 
			{
				try
				{
					if( int.Parse(this.txtCodSucursal.Text.Trim()) < 1)
					{
                        this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1983, Global.Idioma), false);
						return false;
					}

				}
				catch
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1984, Global.Idioma), false);
					return false;
				}
			}

			//validacion para SAP

			//valida si el cliente de contado existe en la tabla cliente
			/*if(this.txtCodClientesContado.Text.Length == 0)
			{
				return true;
			}
			else
			{	_objClientes = Libreria.Comercial.Clientes.ObtenerItem(this.txtCodClientesContado.Text.Trim());
				if(this._objClientes == null)
				{
					this.SetError("El código '" + this.txtCodClientesContado.Text.Trim() + "' para clientes de contado no existe en clientes!", false);
					return false;
				}
			}
			*/
			return true;
		}
		#endregion
	}
}
