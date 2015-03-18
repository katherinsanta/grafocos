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
	public class DatosGenerales : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		//protected System.Web.UI.WebControls.Calendar CalendarioInicial;
		protected System.Web.UI.WebControls.DropDownList ddlHoraInicial;
		protected System.Web.UI.WebControls.DropDownList ddlMinutosIniciales;
		protected System.Web.UI.WebControls.DropDownList ddlHoraFinal;
		protected System.Web.UI.WebControls.DropDownList ddlMinutosFinales;
        //protected System.Web.UI.WebControls.ImageButton ibMostrarCalendarioInicial;
        //protected System.Web.UI.WebControls.ImageButton ibMostrarCalendarioFinal;
        //protected System.Web.UI.WebControls.Calendar CalendarioFinal;
		protected System.Web.UI.WebControls.Label lblTituloGenerales;
		protected System.Web.UI.WebControls.DropDownList ddlGeneralCompañia;
		protected System.Web.UI.WebControls.TextBox txtGeneralNit;
		protected System.Web.UI.WebControls.TextBox txtGeneralNitDive;
		protected System.Web.UI.WebControls.DropDownList ddlGeneralGrupo;
		protected System.Web.UI.WebControls.TextBox txtGeneralDireccion;
		protected System.Web.UI.WebControls.DropDownList ddlGeneralEstacion;
		protected System.Web.UI.WebControls.TextBox txtGeneralTelefono;
		protected System.Web.UI.WebControls.DropDownList ddlGeneralRazonSocial;
		//protected System.Web.UI.WebControls.TextBox txtGeneralCiudad;
		protected System.Web.UI.WebControls.TextBox txtGeneralRazonSocial;
		protected System.Web.UI.WebControls.TextBox txtGeneralSlogan;
		protected System.Web.UI.WebControls.Label lblTituloConfiguracion;
		protected System.Web.UI.WebControls.DropDownList ddlConfiguracionConfiguracionTipoEstacion;
		protected System.Web.UI.WebControls.DropDownList ddlConfiguracionVentasPredefinidas;
		protected System.Web.UI.WebControls.DropDownList ddlConfiguracionFidelizado;
		protected System.Web.UI.WebControls.DropDownList ddlConfiguracionCapturarPantalla;
		protected System.Web.UI.WebControls.TextBox txtConfiguracionValorBolsa;
		protected System.Web.UI.WebControls.TextBox txtConfiguracionCodigoSucursal;
		protected System.Web.UI.WebControls.DropDownList ddlConfiguracionPermitirCreacionEmpleadosTarjetas;
		protected System.Web.UI.WebControls.Label lblTituloTributaria;
		protected System.Web.UI.WebControls.TextBox txtTributarioResolucionGradesCont;
		protected System.Web.UI.WebControls.TextBox txtTributarioPrefijo;
		protected System.Web.UI.WebControls.TextBox txtTributarioResolucionAutoretenedor;
		protected System.Web.UI.WebControls.TextBox txtTributarioConsecutivoInicial;
		protected System.Web.UI.WebControls.TextBox txtTributarioResolucionFactura;
		protected System.Web.UI.WebControls.TextBox txtTributarioConsecutivoFinal;
		protected System.Web.UI.WebControls.DropDownList ddlTributarioTipoTiquete;
		protected System.Web.UI.WebControls.DropDownList ddlTributarioRegimen;
        //protected System.Web.UI.WebControls.Label lblTituloDescuentos;
        //protected System.Web.UI.WebControls.TextBox txtDescuentosDescuento;
        //protected System.Web.UI.WebControls.TextBox txtDescuentosFechaInicial;
        //protected System.Web.UI.WebControls.TextBox txtDescuentosFechaFinal;
        //protected System.Web.UI.WebControls.DropDownList ddlDescuentosHoraInicial;
        //protected System.Web.UI.WebControls.DropDownList ddlDescuentosMinutosIniciales;
        //protected System.Web.UI.WebControls.DropDownList ddlDescuentosHoraFinal;
        //protected System.Web.UI.WebControls.DropDownList ddlDescuentosMinutosFinales;
		protected System.Web.UI.WebControls.Label lblTituloGas;
		protected System.Web.UI.WebControls.DropDownList ddlGasControlMantenimiento;
		protected System.Web.UI.WebControls.DropDownList ddlGasVersionIdentificador;
		protected System.Web.UI.WebControls.DropDownList ddlGasTipoCentroComputo;
		protected System.Web.UI.WebControls.DropDownList ddlGasRecaudo;
		protected System.Web.UI.WebControls.DropDownList ddlGasActualizarFormasPago;
		protected System.Web.UI.WebControls.HyperLink lblBackGeneral;
		protected System.Web.UI.WebControls.HyperLink lblBackConf;
		protected System.Web.UI.WebControls.LinkButton lblGuardarOtros;
		protected System.Web.UI.WebControls.LinkButton lblGuardarGenerar;
		protected System.Web.UI.WebControls.HyperLink lblBackOtros;
		protected System.Web.UI.WebControls.HyperLink lblBackTributaria;
        //protected System.Web.UI.WebControls.HyperLink lblBackDescuentos;
		protected System.Web.UI.WebControls.HyperLink lblBackGas;
		protected System.Web.UI.WebControls.DropDownList ddlConfiguracionLimpiarDisplay;
		protected System.Web.UI.WebControls.HyperLink hlCompañia;
		protected System.Web.UI.WebControls.HyperLink hlgrupo;
		protected System.Web.UI.WebControls.HyperLink hlEstacion;
		protected System.Web.UI.WebControls.DropDownList ddlConfiguracionTipoEstacion;
        //protected System.Web.UI.WebControls.CheckBox cbSinFechaDefinida;
		protected System.Web.UI.WebControls.LinkButton lbGeneral;
		protected System.Web.UI.WebControls.LinkButton lbConf;
	//	protected System.Web.UI.WebControls.LinkButton lbtributaria;
		protected System.Web.UI.WebControls.LinkButton lbGas;
        //protected System.Web.UI.WebControls.LinkButton lbDesc;
		protected System.Web.UI.WebControls.TextBox txtCodigoOrden;
		protected System.Web.UI.WebControls.DropDownList ddlLecturasMecanicas;
        //protected System.Web.UI.WebControls.RadioButtonList optDctoFidelizacion;
		protected System.Web.UI.WebControls.DropDownList cboSAP;
		protected System.Web.UI.WebControls.DropDownList cboPais;
		protected System.Web.UI.WebControls.DropDownList cboDepartamento;
		protected System.Web.UI.WebControls.DropDownList cboCiudad;
		protected System.Web.UI.WebControls.DropDownList cboPeriodoVariacionTanque;
        protected System.Web.UI.WebControls.DropDownList ddlTipoAutorizacionCaraManguera;
        protected System.Web.UI.WebControls.DropDownList ddlTipoAutorizacionExterna;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		//Juan F Obando -> 29-08-2006 | Ingreso de un nuevo check, almacenara el Descuento a Recaudo
        //protected System.Web.UI.WebControls.CheckBox cbDescuentoRecaudo;
		protected System.Web.UI.WebControls.RadioButtonList rblZeta;
		protected System.Web.UI.WebControls.RadioButtonList rblCapturadores;
		protected System.Web.UI.WebControls.TextBox txtIPServidorMRVirtual;
		protected System.Web.UI.WebControls.TextBox txtIpTanques;
		protected System.Web.UI.WebControls.TextBox txtPuerto;
		protected System.Web.UI.WebControls.CheckBox cbDebug;
		protected System.Web.UI.WebControls.CheckBox cbDebugSurtidores;
		protected System.Web.UI.WebControls.TextBox txtRutaPlanoVentasPendientes;
		protected System.Web.UI.WebControls.TextBox txtRutaPlanoVentasProcesadas;
		//protected System.Web.UI.WebControls.TextBox txtMensajeDctoFidelizado;
		protected System.Web.UI.WebControls.TextBox txtCodigoAlternoEstacion;
		protected System.Web.UI.WebControls.TextBox txtRutaExportarPredeterminada;
		protected System.Web.UI.WebControls.TextBox txtRutaImportarPredeterminada;
		protected System.Web.UI.WebControls.TextBox txtRutaPlanoVentas;
		protected System.Web.UI.WebControls.TextBox txtRutaPlanoLecturas;
		protected System.Web.UI.WebControls.TextBox txtRutaPlanoInventarios;
        protected System.Web.UI.WebControls.TextBox txtPasswordCalibracion;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoCreditoContado;
		protected System.Web.UI.WebControls.CheckBox cbConexionOracle;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoVentaSap;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoTrasladoSap;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoLecturaSap;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoReporte;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoTotalElectronico;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoMapa;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoCuenta;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoPrecio;
		protected System.Web.UI.WebControls.CheckBox ckbGenerarPlanoInventarios;
		protected System.Web.UI.WebControls.CheckBox chkGenerarPlanoVentas;
		protected System.Web.UI.WebControls.CheckBox chkGenerarPlanoLecturas;

		protected System.Web.UI.WebControls.CheckBox chkTiqueteVentaConfigurable;
		protected System.Web.UI.WebControls.TextBox txtSeparadorPlanosPredeterminado;
		protected System.Web.UI.WebControls.DropDownList ddlLecturasPorVenta;
		protected System.Web.UI.WebControls.RadioButtonList rblUtilizaServidorCapturadores;
		protected System.Web.UI.WebControls.TextBox txtIntentosAEstacion;
		protected System.Web.UI.WebControls.TextBox txtIntervaloAEstacion;
		protected System.Web.UI.WebControls.TextBox txtIntervaloACapturador;
		protected System.Web.UI.WebControls.TextBox txtIntentosACapturador;
		protected System.Web.UI.WebControls.TextBox txtPuertoServidorCapturadores;
		protected System.Web.UI.WebControls.CheckBox chkImprimirMensajeAdicional;
		protected System.Web.UI.WebControls.TextBox txtMensajeAdicionalMayoresA;
		protected System.Web.UI.WebControls.TextBox txtMensajeAdicional;
		protected System.Web.UI.WebControls.CheckBox chkSeguridadImpresion;
		protected System.Web.UI.WebControls.TextBox txtTiempoSeguridadImpresion;
		protected System.Web.UI.WebControls.TextBox txtClaveImpresion;


        protected System.Web.UI.WebControls.TextBox txtUrlWebServiceCi;
        protected System.Web.UI.WebControls.TextBox txtUsuarioCi;
        protected System.Web.UI.WebControls.TextBox txtPasswordCI;
        protected System.Web.UI.WebControls.TextBox txtDiasActualizaCI;
        protected System.Web.UI.WebControls.TextBox txtMinutosEncuestaCI;
        protected System.Web.UI.WebControls.TextBox txtDiasAvisoResolucionCanastilla;
        protected System.Web.UI.WebControls.TextBox txtFacturasAvisoResolucionCanastilla;
        protected System.Web.UI.WebControls.CheckBox ChkVentaAutorizadaConConductor;
        protected System.Web.UI.WebControls.CheckBox chkDescargueInventario;
        protected System.Web.UI.WebControls.CheckBox chkZetaAutomatico;
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
        //protected System.Web.UI.WebControls.Label Label34;
        //protected System.Web.UI.WebControls.Label Label35;
        //protected System.Web.UI.WebControls.Label Label36;
        //protected System.Web.UI.WebControls.Label Label37;
        //protected System.Web.UI.WebControls.Label Label38;
        //protected System.Web.UI.WebControls.Label Label39;
        //protected System.Web.UI.WebControls.Label Label40;
        protected System.Web.UI.WebControls.Label Label41;
        protected System.Web.UI.WebControls.Label Label42;
        protected System.Web.UI.WebControls.Label Label43;
        protected System.Web.UI.WebControls.Label Label44;
        protected System.Web.UI.WebControls.Label Label45;
        protected System.Web.UI.WebControls.Label Label46;
        protected System.Web.UI.WebControls.Label Label47;
        protected System.Web.UI.WebControls.Label Label48;
        protected System.Web.UI.WebControls.Label Label49;
        protected System.Web.UI.WebControls.Label Label50;
        protected System.Web.UI.WebControls.Label Label51;
        protected System.Web.UI.WebControls.Label Label52;
        protected System.Web.UI.WebControls.Label Label53;
        protected System.Web.UI.WebControls.Label Label54;
        protected System.Web.UI.WebControls.Label Label55;
        protected System.Web.UI.WebControls.Label Label56;
        protected System.Web.UI.WebControls.Label Label57;
        protected System.Web.UI.WebControls.Label Label58;
        protected System.Web.UI.WebControls.Label Label59;
        protected System.Web.UI.WebControls.Label Label60;
        protected System.Web.UI.WebControls.Label Label61;
        protected System.Web.UI.WebControls.Label Label62;
        protected System.Web.UI.WebControls.Label Label63;
        protected System.Web.UI.WebControls.Label Label64;
        protected System.Web.UI.WebControls.Label Label65;
        protected System.Web.UI.WebControls.Label Label66;
        protected System.Web.UI.WebControls.Label Label67;
        protected System.Web.UI.WebControls.Label Label68;
        protected System.Web.UI.WebControls.Label Label69;
        protected System.Web.UI.WebControls.Label Label70;
        protected System.Web.UI.WebControls.Label Label71;
        protected System.Web.UI.WebControls.Label Label72;
        protected System.Web.UI.WebControls.Label lblLeyendaTipoAutorizacion;
        protected System.Web.UI.WebControls.Label lblLeyendaTipo;
        protected System.Web.UI.WebControls.HyperLink Hyperlink1;
        protected AjaxControlToolkit.TabPanel TabPanelGeneral;
        protected AjaxControlToolkit.TabPanel TabPanelConfiguracion;
        protected AjaxControlToolkit.TabPanel TabPanelGenerar;
        protected AjaxControlToolkit.TabPanel TabPanelOtros;
        protected AjaxControlToolkit.TabPanel TabPanelGas;
        //protected AjaxControlToolkit.TabPanel TabPanelDescuento;
        protected System.Web.UI.WebControls.Panel pnlForm;

		protected Libreria.Configuracion.Dat_Gene _objDat_Gene = null;
		Libreria.Configuracion.Ciudad _objCiudad = null;


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
			if (!this.IsPostBack)
			{
				this.InicializarForma();
				Session["Tab"] = "";
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
            TabPanelGeneral.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1404, Global.Idioma);
            TabPanelConfiguracion.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1157, Global.Idioma);
            //TabPanelDescuento.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1175, Global.Idioma);
            TabPanelGas.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1186, Global.Idioma);
            TabPanelGenerar.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1195, Global.Idioma);
            TabPanelOtros.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1217, Global.Idioma);

            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1869, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1870 , Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1727, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1150, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1089, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1151, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1142, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1152, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1143, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(725, Global.Idioma);

            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1145, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(683, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1147, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1153, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1149, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1154, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1159, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1168, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1160, Global.Idioma);
            Label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1169, Global.Idioma);

            Label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1161, Global.Idioma);
            Label22.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1170, Global.Idioma);
            Label23.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1162, Global.Idioma);
            Label24.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1171, Global.Idioma);
            Label25.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1163, Global.Idioma);
            Label26.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1172, Global.Idioma);
            Label27.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1164, Global.Idioma);
            Label28.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1173, Global.Idioma);
            Label29.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1165, Global.Idioma);
            Label30.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1167, Global.Idioma);

            Label31.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1174, Global.Idioma);
            Label32.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1875, Global.Idioma);
            Label33.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1876, Global.Idioma);
            //Label34.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1177, Global.Idioma);
            //Label35.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1178, Global.Idioma);
            //Label36.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1183, Global.Idioma);
            //Label37.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1507, Global.Idioma);
            //Label38.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1508, Global.Idioma);
            //Label39.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1181, Global.Idioma);
            //Label40.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1185, Global.Idioma);

            Label41.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1188, Global.Idioma);
            Label42.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1192, Global.Idioma);
            Label43.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1189, Global.Idioma);
            Label44.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1193, Global.Idioma);
            Label45.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1190, Global.Idioma);
            //Label46.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1191, Global.Idioma);
            Label47.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1194, Global.Idioma);
            Label48.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1197, Global.Idioma);
            Label49.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1214, Global.Idioma);
            Label50.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1198, Global.Idioma);

            Label51.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1215, Global.Idioma);
            Label52.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1199, Global.Idioma);
            Label53.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1216, Global.Idioma);
            Label54.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1200, Global.Idioma);
            Label55.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1201, Global.Idioma);
            Label56.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1218, Global.Idioma);
            Label57.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1230, Global.Idioma);
            Label58.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1219, Global.Idioma);
            Label59.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1231, Global.Idioma);
            Label60.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1382, Global.Idioma);

            Label61.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1232, Global.Idioma);
            Label62.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1221, Global.Idioma);
            Label63.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1333, Global.Idioma);
            Label64.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1222, Global.Idioma);
            Label65.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1879, Global.Idioma);
            Label66.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1223, Global.Idioma);
            Label67.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1234, Global.Idioma);
            Label68.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1227, Global.Idioma);
            Label69.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1236, Global.Idioma);
            Label70.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1228, Global.Idioma);

            Label71.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1237, Global.Idioma);
            Label72.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1229, Global.Idioma);

            chkImprimirMensajeAdicional.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1148, Global.Idioma);
            chkSeguridadImpresion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1166, Global.Idioma);
            //cbSinFechaDefinida.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1181, Global.Idioma);
            //cbDescuentoRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1182, Global.Idioma);
            ckbGenerarPlanoCreditoContado.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1202, Global.Idioma);
            ckbGenerarPlanoVentaSap.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1208, Global.Idioma);
            ckbGenerarPlanoTrasladoSap.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1203, Global.Idioma);
            ckbGenerarPlanoLecturaSap.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1209, Global.Idioma);
            ckbGenerarPlanoReporte.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1204, Global.Idioma);
            ckbGenerarPlanoTotalElectronico.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1210, Global.Idioma);
            ckbGenerarPlanoMapa.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1205, Global.Idioma);
            ckbGenerarPlanoCuenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1211, Global.Idioma);
            ckbGenerarPlanoPrecio.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1206, Global.Idioma);
            ckbGenerarPlanoInventarios.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1212, Global.Idioma);
            chkGenerarPlanoVentas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1207, Global.Idioma);
            chkGenerarPlanoLecturas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1213, Global.Idioma);
            cbDebug.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1224, Global.Idioma);
            cbDebugSurtidores.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1225, Global.Idioma);
            chkTiqueteVentaConfigurable.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1235, Global.Idioma);
            cbConexionOracle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1226, Global.Idioma);


            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1405, Global.Idioma);
            lbGeneral.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBackGeneral.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblTituloConfiguracion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1158, Global.Idioma);
            lbConf.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBackConf.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            //lblTituloDescuentos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1176, Global.Idioma);
            //lbDesc.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            //lblBackDescuentos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblTituloGas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1187, Global.Idioma);
            lbGas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBackGas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblGuardarGenerar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            Hyperlink1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblGuardarOtros.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBackOtros.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);

            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion        

        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlConfiguracionTipoEstacion
            this.ddlConfiguracionTipoEstacion.Items.Clear();
            this.ddlConfiguracionTipoEstacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlConfiguracionTipoEstacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1872, Global.Idioma), "Gasolina"));
            this.ddlConfiguracionTipoEstacion.Items.Insert(0, new ListItem("Gas", "Gas"));
            this.ddlConfiguracionTipoEstacion.Items.Insert(0, new ListItem("Dual", "Dual"));
            this.ddlConfiguracionTipoEstacion.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlConfiguracionFidelizado
            this.ddlConfiguracionFidelizado.Items.Clear();
            this.ddlConfiguracionFidelizado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlConfiguracionFidelizado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlConfiguracionFidelizado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlConfiguracionFidelizado.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlConfiguracionVentasPredefinidas
            this.ddlConfiguracionVentasPredefinidas.Items.Clear();
            this.ddlConfiguracionVentasPredefinidas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlConfiguracionVentasPredefinidas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlConfiguracionVentasPredefinidas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlConfiguracionVentasPredefinidas.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlConfiguracionCapturarPantalla
            this.ddlConfiguracionCapturarPantalla.Items.Clear();
            this.ddlConfiguracionCapturarPantalla.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlConfiguracionCapturarPantalla.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "1"));
            this.ddlConfiguracionCapturarPantalla.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "0"));
            this.ddlConfiguracionCapturarPantalla.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlConfiguracionPermitirCreacionEmpleadosTarjetas
            this.ddlConfiguracionPermitirCreacionEmpleadosTarjetas.Items.Clear();
            this.ddlConfiguracionPermitirCreacionEmpleadosTarjetas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlConfiguracionPermitirCreacionEmpleadosTarjetas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlConfiguracionPermitirCreacionEmpleadosTarjetas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlConfiguracionPermitirCreacionEmpleadosTarjetas.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlConfiguracionLimpiarDisplay
            this.ddlConfiguracionLimpiarDisplay.Items.Clear();
            this.ddlConfiguracionLimpiarDisplay.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlConfiguracionLimpiarDisplay.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlConfiguracionLimpiarDisplay.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlConfiguracionLimpiarDisplay.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlTributarioTipoTiquete
            this.ddlTributarioTipoTiquete.Items.Clear();
            this.ddlTributarioTipoTiquete.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlTributarioTipoTiquete.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1873, Global.Idioma), "Factura"));
            this.ddlTributarioTipoTiquete.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1874, Global.Idioma), "Tiquete"));
            this.ddlTributarioTipoTiquete.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlLecturasPorVenta
            this.ddlLecturasPorVenta.Items.Clear();            
            this.ddlLecturasPorVenta.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlLecturasPorVenta.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlLecturasPorVenta.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlTipoAutorizacione
            this.ddlTipoAutorizacionCaraManguera.Items.Clear();
            this.ddlTipoAutorizacionCaraManguera.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma), "1"));
            this.ddlTipoAutorizacionCaraManguera.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1369, Global.Idioma), "2"));
            this.ddlTipoAutorizacionCaraManguera.SelectedValue = "1";
            #endregion
            //#region poblar RadioButton  optDctoFidelizacion
            //this.optDctoFidelizacion.Items.Clear();            
            //this.optDctoFidelizacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            //this.optDctoFidelizacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            //this.optDctoFidelizacion.SelectedValue = "0";
            //#endregion
            #region poblar RadioButton  ddlGasControlMantenimiento
            this.ddlGasControlMantenimiento.Items.Clear();
            this.ddlGasControlMantenimiento.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlGasControlMantenimiento.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "Activo"));
            this.ddlGasControlMantenimiento.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "Inactivo"));
            this.ddlGasControlMantenimiento.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlGasRecaudo
            this.ddlGasRecaudo.Items.Clear();
            this.ddlGasRecaudo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlGasRecaudo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "Activo"));
            this.ddlGasRecaudo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "Inactivo"));
            this.ddlGasRecaudo.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlGasActualizarFormasPago
            this.ddlGasActualizarFormasPago.Items.Clear();
            this.ddlGasActualizarFormasPago.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlGasActualizarFormasPago.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "Activo"));
            this.ddlGasActualizarFormasPago.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "Inactivo"));
            this.ddlGasActualizarFormasPago.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlLecturasMecanicas
            this.ddlLecturasMecanicas.Items.Clear();
            this.ddlLecturasMecanicas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlLecturasMecanicas.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlLecturasMecanicas.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  rblZeta
            this.rblZeta.Items.Clear();
            this.rblZeta.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "S"));
            this.rblZeta.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "N"));
            this.rblZeta.SelectedValue = "N";
            #endregion
            #region poblar RadioButton  rblCapturadores
            this.rblCapturadores.Items.Clear();
            this.rblCapturadores.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "S"));
            this.rblCapturadores.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "N"));
            this.rblCapturadores.SelectedValue = "N";
            #endregion
            #region poblar RadioButton  cboPeriodoVariacionTanque
            this.cboPeriodoVariacionTanque.Items.Clear();
            this.cboPeriodoVariacionTanque.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1878, Global.Idioma), "S"));
            this.cboPeriodoVariacionTanque.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1877, Global.Idioma), "M"));
            this.cboPeriodoVariacionTanque.SelectedValue = "S";
            #endregion
            #region poblar RadioButton  rblCapturadores
            this.rblCapturadores.Items.Clear();
            this.rblCapturadores.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "S"));
            this.rblCapturadores.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "N"));
            this.rblCapturadores.SelectedValue = "N";
            #endregion
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
			this.lbGeneral.Click += new System.EventHandler(this.lbGeneral_Click);
			this.lbConf.Click += new System.EventHandler(this.lbGeneral_Click);
			//this.lbtributaria.Click += new System.EventHandler(this.lbGeneral_Click);
            //this.lbDesc.Click += new System.EventHandler(this.lbGeneral_Click);
            //this.cbSinFechaDefinida.CheckedChanged += new System.EventHandler(this.cbSinFechaDefinida_CheckedChanged);
            //this.ibMostrarCalendarioInicial.Click += new System.Web.UI.ImageClickEventHandler(this.ibMostrarCalendarioInicial_Click);
            //this.ibMostrarCalendarioFinal.Click += new System.Web.UI.ImageClickEventHandler(this.ibMostrarCalendarioFinal_Click);
            //this.CalendarioInicial.SelectionChanged += new System.EventHandler(this.CalendarioInicial_SelectionChanged);
            //this.CalendarioFinal.SelectionChanged += new System.EventHandler(this.CalendarioFinal_SelectionChanged);
			this.lbGas.Click += new System.EventHandler(this.lbGeneral_Click);
			//			//JuanF Obando -> 29-08-2006 | Descuento a Recaudo
			//			this.cbDescuentoRecaudo.CheckedChanged += new System.EventHandler(this.cbDescuentoRecaudo_CheckedChanged);
			this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
			this.cboDepartamento.SelectedIndexChanged += new System.EventHandler(this.cboDepartamento_SelectedIndexChanged);
			this.lblGuardarOtros.Click += new System.EventHandler(this.lbGeneral_Click);
			this.lblGuardarGenerar.Click += new System.EventHandler(this.lbGeneral_Click);
            //this.optDctoFidelizacion.SelectedIndexChanged += new System.EventHandler(this.optDctoFidelizacion_SelectedIndexChanged);
			this.chkImprimirMensajeAdicional.CheckedChanged += new System.EventHandler(this.chkImprimirMensajeAdicional_CheckedChanged);
			this.chkSeguridadImpresion.CheckedChanged += new System.EventHandler(this.chkSeguridadImpresion_CheckedChanged);

			this.Load += new System.EventHandler(this.Page_Load);



		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Datos Generales";
			bool permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}			
			return true;
		}
		#endregion

		#region ObtenerObjetoDatosGenerales
		private bool ObtenerObjetoDatosGenerales()
		{
			try
			{
				this._objDat_Gene = Libreria.Configuracion.Datos_Gene.ObtenerItem();
				if (this._objDat_Gene == null)
				{
					this._objDat_Gene = new Servipunto.Estacion.Libreria.Configuracion.Dat_Gene();
					return true;
				}
				else
					return true;
			}
			catch (FormatException)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objDat_Gene + "]", true);
                return false;
			}
		}
		#endregion

		#region Inicialización del Formulario
		/// <summary>
		/// inicia el formulario y carga la informacion de datos generales
		/// </summary>
		/// Modificacion: Se adiciono el campo GenerarPlanoInventario para definir si se genera el plano de inventarios
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez		
	
		private void InicializarForma()
		{

			if (this.VerificarPermisos())
			{
				try
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,124, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					this.CargarCompañias();
					this.CargarGrupos();
					this.CargarEstaciones();
                    //this.CargarMinutos();
                    this.CargarTipoAutorizacionExterna();
                    if (this.IsPostBack)
                        this.CargarPaises();
                    this.RadioButtonTraduccion();
					if (this.ObtenerObjetoDatosGenerales())
					{
						try
						{
							//Visualización de Datos
							#region Carga Pestaña generales
							if(_objDat_Gene.CodCompania == 0)
								ddlGeneralCompañia.SelectedIndex = 0;
							else
								ddlGeneralCompañia.SelectedValue = _objDat_Gene.CodCompania.ToString();

							if(_objDat_Gene.CodGrupo == 0)
								ddlGeneralGrupo.SelectedIndex = 0;
							else
								ddlGeneralGrupo.SelectedValue = _objDat_Gene.CodGrupo.ToString();

							if(_objDat_Gene.CodEstacion == 0)
								ddlGeneralEstacion.SelectedIndex = 0;
							else
								ddlGeneralEstacion.SelectedValue = _objDat_Gene.CodEstacion.ToString();

							if(_objDat_Gene.TipoNit == "(Sin Definir)")
								ddlGeneralRazonSocial.SelectedIndex = 0;
							else
								ddlGeneralRazonSocial.SelectedValue = _objDat_Gene.TipoNit;
						
							cboPais.SelectedValue = _objDat_Gene.idPais.ToString()=="0"?"1":_objDat_Gene.idPais.ToString();
							this.CargarDepartamento(_objDat_Gene.Ciudad!=null?_objDat_Gene.Ciudad.Trim():"11001");

                            //optDctoFidelizacion.SelectedValue = _objDat_Gene.DctoFidelizado?"1":"0";
                            //if(optDctoFidelizacion.SelectedValue=="1")
                            //    txtMensajeDctoFidelizado.Enabled = true;
                            //else
                            //    txtMensajeDctoFidelizado.Enabled = false;

							cboSAP.SelectedValue = _objDat_Gene.Sap.ToString();
							txtGeneralRazonSocial.Text = _objDat_Gene.RazonSocial;
							txtGeneralNit.Text = _objDat_Gene.Nit;
							txtGeneralNitDive.Text = _objDat_Gene.NitDive;
							txtGeneralDireccion.Text = _objDat_Gene.Direccion;
							txtGeneralTelefono.Text = _objDat_Gene.Telefono;
							//txtGeneralCiudad.Text = _objDat_Gene.Ciudad;
						
							txtGeneralSlogan.Text = _objDat_Gene.Slogan;							
							chkImprimirMensajeAdicional.Checked = _objDat_Gene.ImprimirMensajeAdicional;
							txtMensajeAdicional.Text = _objDat_Gene.MensajeAdicional;
							txtMensajeAdicionalMayoresA.Text = _objDat_Gene.MensajeAdicionalMayoresA.ToString();
							txtMensajeAdicional.Enabled = _objDat_Gene.ImprimirMensajeAdicional;
							txtMensajeAdicionalMayoresA.Enabled = _objDat_Gene.ImprimirMensajeAdicional;								
							#endregion

							#region Cargar Pestaña Configuración
							if(_objDat_Gene.TipoEstacion == "0")
								ddlConfiguracionTipoEstacion.SelectedIndex = 0;
							else
								ddlConfiguracionTipoEstacion.SelectedValue = _objDat_Gene.TipoEstacion;
					        
							ddlConfiguracionVentasPredefinidas.SelectedValue = _objDat_Gene.SelfService?"1":"0";
							ddlConfiguracionFidelizado.SelectedValue = _objDat_Gene.EDSFideliza?"1":"0";
							ddlConfiguracionPermitirCreacionEmpleadosTarjetas.SelectedValue = _objDat_Gene.CrearTarjActivas?"1":"0";
							txtConfiguracionValorBolsa.Text = _objDat_Gene.ValorBolsaDinero.ToString();
							txtConfiguracionCodigoSucursal.Text = _objDat_Gene.CodigoSucursal.ToString();
							ddlConfiguracionCapturarPantalla.SelectedValue = _objDat_Gene.CapturadorEnPantalla?"1":"0";
							ddlConfiguracionLimpiarDisplay.SelectedValue = _objDat_Gene.LimpiarDisplay?"1":"0";
							ddlLecturasPorVenta.SelectedValue = _objDat_Gene.LecturasPorVenta?"1":"0";

                            this.ddlTipoAutorizacionCaraManguera.SelectedValue = _objDat_Gene.TipoAutorizacion.ToString();
							chkSeguridadImpresion.Checked = _objDat_Gene.SeguridadImpresion;
							txtTiempoSeguridadImpresion.Text = _objDat_Gene.TiempoSeguridadImpresion.ToString();
							txtClaveImpresion.Text = _objDat_Gene.ClaveImpresion.ToString();
							txtTiempoSeguridadImpresion.Enabled = _objDat_Gene.SeguridadImpresion;
							txtClaveImpresion.Enabled = _objDat_Gene.SeguridadImpresion;
                            chkDescargueInventario.Checked = _objDat_Gene.DescargueInventario;
                            chkZetaAutomatico.Checked = _objDat_Gene.ZetaAutomatico;
                            lblLeyendaTipoAutorizacion.Text = "Estandar";
							#endregion

							#region Cargar Pestaña Tributarios
							// COMENTARIOS POR R.F. ENERO 19-2007
							//txtTributarioResolucionGradesCont.Text = _objDat_Gene.ResolucionCont;
							//txtTributarioResolucionAutoretenedor.Text = _objDat_Gene.ResolucionAutoretenedor;
							//txtTributarioResolucionFactura.Text = _objDat_Gene.ResolucionFacturacion;
							ddlTributarioTipoTiquete.SelectedValue = _objDat_Gene.TiqueteFactura;
							txtTributarioPrefijo.Text = _objDat_Gene.PrefijoFactura;
							//txtTributarioConsecutivoInicial.Text = _objDat_Gene.ConsecutivoInicial.ToString();
							//txtTributarioConsecutivoFinal.Text = _objDat_Gene.ConsecutivoFinal.ToString();
							//ddlTributarioRegimen.SelectedValue = _objDat_Gene.Regimen;
							//txtCodigoOrden.Text = _objDat_Gene.IdNumOrden.ToString();
							#endregion

							#region Cargar Pestaña Descuentos
							//txtDescuentosDescuento.Text = _objDat_Gene.PorcentajeDescuento.ToString();
							//cbDescuentoRecaudo.Checked = _objDat_Gene.DctoRecaudo;
						
                            //if(_objDat_Gene.FechaInicialDescuento.Year == 1800 || _objDat_Gene.FechaInicialDescuento.Year == 1)
                            //{
                            ////	CalendarioInicial.SelectedDate = DateTime.Today;
                            ////	cbSinFechaDefinida.Checked = true;
                            //    //SinFechaDefAux();
                            //}
                            //else
                            //{
                            ////	CalendarioInicial.SelectedDate = _objDat_Gene.FechaInicialDescuento;
                            ////	txtDescuentosFechaInicial.Text = _objDat_Gene.FechaInicialDescuento.ToString("dd/MM/yyyy");
                            //}						
						
                            //if(_objDat_Gene.FechaFinalDescuento.Year == 1800 || _objDat_Gene.FechaFinalDescuento.Year == 1)
                            //{
                            ////	CalendarioFinal.SelectedDate = DateTime.Today;
                            ////	cbSinFechaDefinida.Checked = true;
                            //    //SinFechaDefAux();
                            //}
                            //else
                            //{
                            ////	CalendarioFinal.SelectedDate = _objDat_Gene.FechaFinalDescuento;
                            ////	txtDescuentosFechaFinal.Text = _objDat_Gene.FechaFinalDescuento.ToString("dd/MM/yyyy");
                            //}

                            //if(_objDat_Gene.HoraInicialDescuento.Year == 1800)
                            //{
                            ////	ddlDescuentosHoraInicial.SelectedIndex = 0;
                            //}
                            //else
                            //{
                            ////	ddlDescuentosHoraInicial.SelectedValue = _objDat_Gene.HoraInicialDescuento.Hour.ToString();
                            ////	ddlDescuentosMinutosIniciales.SelectedValue = _objDat_Gene.HoraInicialDescuento.Minute.ToString();
                            //}

                            //if(_objDat_Gene.HoraFinalDescuento.Year == 1800)
                            //{
                            ////	ddlDescuentosHoraFinal.SelectedIndex = 0;
                            //}
                            //else
                            //{
                            ////	ddlDescuentosHoraFinal.SelectedValue = _objDat_Gene.HoraFinalDescuento.Hour.ToString();
                            ////	ddlDescuentosMinutosFinales.SelectedValue = _objDat_Gene.HoraFinalDescuento.Minute.ToString();
                            //}

                            //if(_objDat_Gene.HoraInicialDescuento.Hour ==  _objDat_Gene.HoraFinalDescuento.Hour &&
                            //    _objDat_Gene.HoraInicialDescuento.Minute == _objDat_Gene.HoraFinalDescuento.Minute
                            //    )
                            //{
                            ////	ddlDescuentosHoraInicial.SelectedIndex = 0;
							//	ddlDescuentosHoraFinal.SelectedIndex = 0;
                            //}
							//txtMensajeDctoFidelizado.Text = _objDat_Gene.MensajeDctoFidelizado;
							#endregion

							#region Cargar Pestaña Gas
							ddlGasControlMantenimiento.SelectedValue = _objDat_Gene.ControlMantenimiento?"Activo":"Inactivo";
							ddlGasTipoCentroComputo.SelectedValue = _objDat_Gene.TipoCentroComputo;
							ddlGasActualizarFormasPago.SelectedValue = _objDat_Gene.ActualizarFormPagGenerador?"Activo":"Inactivo";
							ddlGasVersionIdentificador.SelectedValue = _objDat_Gene.VersionSuic;
							ddlGasRecaudo.SelectedValue = _objDat_Gene.CobrarRecaudo?"Activo":"Inactivo";
							ddlLecturasMecanicas.SelectedValue = _objDat_Gene.SolicitaLectsMecanicas?"Si":"No";


                            txtPasswordCalibracion.Text = _objDat_Gene.PasswordCierreXAjuste;
							#endregion
							
							#region Cargar Pestaña Generar
							txtRutaExportarPredeterminada.Text = _objDat_Gene.RutaExportarPredeterminada;
							txtRutaImportarPredeterminada.Text = _objDat_Gene.RutaImportarPredeterminada;
							txtRutaPlanoVentasPendientes.Text = _objDat_Gene.RutaPlanoVentasPendientes;
							txtRutaPlanoVentasProcesadas.Text = _objDat_Gene.RutaPlanoVentasProcesadas;	
							txtSeparadorPlanosPredeterminado.Text = _objDat_Gene.SeparadorPlanosPredeterminado;


							txtRutaPlanoVentas.Text = _objDat_Gene.DirPlanoVentas ;
							txtRutaPlanoLecturas.Text = _objDat_Gene.DirPlanoLecturas;

							ckbGenerarPlanoCreditoContado.Checked = _objDat_Gene.PlanoVentasCreditoContado;
							ckbGenerarPlanoVentaSap.Checked = _objDat_Gene.GenerarPlanoVentaSap;
							ckbGenerarPlanoTrasladoSap.Checked = _objDat_Gene.GenerarPlanoTrasladoSap;							
							ckbGenerarPlanoLecturaSap.Checked = _objDat_Gene.GenerarPlanoLecturaSap;
							ckbGenerarPlanoReporte.Checked = _objDat_Gene.GenerarPlanoReporte;
							ckbGenerarPlanoTotalElectronico.Checked = _objDat_Gene.GenerarPlanoTotalElectronico;
							ckbGenerarPlanoMapa.Checked = _objDat_Gene.GenerarPlanoMapa;
							ckbGenerarPlanoCuenta.Checked = _objDat_Gene.GenerarPlanoCuenta;
							ckbGenerarPlanoPrecio.Checked = _objDat_Gene.GenerarPlanoPrecio;
							ckbGenerarPlanoInventarios.Checked = _objDat_Gene.GenerarPlanoInventario;
							chkGenerarPlanoVentas.Checked = _objDat_Gene.GenerarPlanoventas;
							chkGenerarPlanoLecturas.Checked = _objDat_Gene.GenerarPlanoLecturas;
							#endregion

							#region Cargar Pestaña Otros
							rblZeta.SelectedValue = _objDat_Gene.JornadaZeta;
							rblCapturadores.SelectedValue = _objDat_Gene.Mr_Socket_Activo;
							txtPuerto.Text = _objDat_Gene.Mr_Socket_Local_Puerto.ToString();
							txtIPServidorMRVirtual.Text = _objDat_Gene.Mr_Socket_Local_Address;
							cbDebug.Checked = _objDat_Gene.ManejaDebug;
							txtIpTanques.Text = _objDat_Gene.IpControlTanques;
							cboPeriodoVariacionTanque.SelectedValue = _objDat_Gene.PeriodoVariacionTanque;
							txtCodigoAlternoEstacion.Text = _objDat_Gene.CodigoAlternoEstacion;					
							cbConexionOracle.Checked = _objDat_Gene.ConexionOracle;							
							cbDebugSurtidores.Checked = _objDat_Gene.DebugTramasSurtidores;

							rblUtilizaServidorCapturadores.SelectedValue = _objDat_Gene.UtilizaServidorCapturadores?"S":"N";
							txtIntentosAEstacion.Text = _objDat_Gene.IntentosAEstacion.ToString();
							txtIntentosACapturador.Text = _objDat_Gene.IntentosACapturador.ToString();
							txtIntervaloAEstacion.Text = _objDat_Gene.IntervaloAEstacion.ToString();
							txtIntervaloACapturador.Text = _objDat_Gene.IntervaloACapturador.ToString();
							txtPuertoServidorCapturadores.Text = _objDat_Gene.PuertoServidorCapturadores.ToString();
							chkTiqueteVentaConfigurable.Checked = _objDat_Gene.TiqueteVentaConfigurable;

							#endregion

                            #region ci
                            txtUrlWebServiceCi.Text = _objDat_Gene.UrlWebServiceCI;
                            txtUsuarioCi.Text = _objDat_Gene.UsuarioCI;
                            txtPasswordCI.Text = _objDat_Gene.ClaveDescargaCI;
                            txtMinutosEncuestaCI.Text = _objDat_Gene.TiempoEncuestaCI.ToString();
                            txtDiasActualizaCI.Text = _objDat_Gene.DiasActualizacionCI.ToString();                            
                            #endregion

                            #region control Canastilla
                            txtDiasAvisoResolucionCanastilla.Text = _objDat_Gene.DiasAvisoVencimientoCanastilla.ToString();
                            txtFacturasAvisoResolucionCanastilla.Text = _objDat_Gene.FacturasAvisoVencimientoCanastilla.ToString();
                            #endregion



                            #region Nuevos
                            ChkVentaAutorizadaConConductor.Checked = _objDat_Gene.AutorizacionConductor == "S" ? true : false;
                            chkDescargueInventario.Checked = _objDat_Gene.DescargueInventario;
                            chkZetaAutomatico.Checked = _objDat_Gene.ZetaAutomatico;
                            #endregion

                            #region Autorizacion Externa
                            ddlTipoAutorizacionExterna.SelectedValue = _objDat_Gene.IdTipoAutorizacionExterna.ToString() == "0" ? "1" : _objDat_Gene.IdTipoAutorizacionExterna.ToString();
                            Libreria.TipoAutorizacionExterna objTipoAutorizacionEx = Libreria.TiposAutorizacionExterna.ObtenerItem(Convert.ToInt32(ddlTipoAutorizacionExterna.SelectedValue));
                            lblLeyendaTipo.Text =  objTipoAutorizacionEx.TipoAutorizacion;
                            lblLeyendaTipoAutorizacion.Text = objTipoAutorizacionEx.Descripcion;
                            #endregion
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
		}

     
		#endregion

		#region Guardar
		/// <summary>
		/// Guarda la informacion de datos generales
		/// </summary>
		/// Modificacion: Se adiciono el campo GenerarPlanoInventario para definir si se genera el plano de inventarios
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez	
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
					if (this.ObtenerObjetoDatosGenerales())
					{
						#region Carga Pestaña generales
						_objDat_Gene.CodCompania = int.Parse(ddlGeneralCompañia.SelectedValue);
						_objDat_Gene.CodGrupo = int.Parse(ddlGeneralGrupo.SelectedValue);
						_objDat_Gene.CodEstacion = int.Parse(ddlGeneralEstacion.SelectedValue);
						_objDat_Gene.TipoNit = ddlGeneralRazonSocial.SelectedValue;

						_objDat_Gene.RazonSocial = txtGeneralRazonSocial.Text;
						_objDat_Gene.Nit = txtGeneralNit.Text;
						_objDat_Gene.NitDive = txtGeneralNitDive.Text;
						_objDat_Gene.Direccion = txtGeneralDireccion.Text;
						_objDat_Gene.Telefono = txtGeneralTelefono.Text;
						_objDat_Gene.Ciudad = this.cboCiudad.SelectedValue;
						_objDat_Gene.Slogan = txtGeneralSlogan.Text;
						_objDat_Gene.ImprimirMensajeAdicional = chkImprimirMensajeAdicional.Checked;
						_objDat_Gene.MensajeAdicional = txtMensajeAdicional.Text;
						_objDat_Gene.MensajeAdicionalMayoresA = Decimal.Parse(txtMensajeAdicionalMayoresA.Text.Replace(',', '.'));

						#endregion

						#region Cargar Pestaña Configuración
						_objDat_Gene.TipoEstacion = ddlConfiguracionTipoEstacion.SelectedValue;
						_objDat_Gene.SelfService = ddlConfiguracionVentasPredefinidas.SelectedValue=="1"?true:false;
						_objDat_Gene.EDSFideliza = ddlConfiguracionFidelizado.SelectedValue=="1"?true:false;
						_objDat_Gene.CrearTarjActivas = ddlConfiguracionPermitirCreacionEmpleadosTarjetas.SelectedValue=="1"?true:false;
						_objDat_Gene.ValorBolsaDinero = System.Decimal.Parse(txtConfiguracionValorBolsa.Text);
						_objDat_Gene.CodigoSucursal = int.Parse(txtConfiguracionCodigoSucursal.Text);
						_objDat_Gene.CapturadorEnPantalla = ddlConfiguracionCapturarPantalla.SelectedValue=="1"?true:false;
						_objDat_Gene.LimpiarDisplay = ddlConfiguracionLimpiarDisplay.SelectedValue=="1"?true:false;
						_objDat_Gene.idPais = int.Parse(cboPais.SelectedValue);
						//_objDat_Gene.DctoFidelizado = optDctoFidelizacion.SelectedValue=="1"?true:false;
						_objDat_Gene.Sap = int.Parse(cboSAP.SelectedValue);
						_objDat_Gene.LecturasPorVenta = ddlLecturasPorVenta.SelectedValue =="1"? true:false;
						_objDat_Gene.TipoAutorizacion = Int16.Parse(ddlTipoAutorizacionCaraManguera.SelectedValue);
						_objDat_Gene.SeguridadImpresion = chkSeguridadImpresion.Checked;
						_objDat_Gene.TiempoSeguridadImpresion = byte.Parse(txtTiempoSeguridadImpresion.Text.Trim());
                        _objDat_Gene.IdTipoAutorizacionExterna = byte.Parse(ddlTipoAutorizacionExterna.SelectedValue);
						if(txtClaveImpresion.Text.Trim().Length > 0)
							_objDat_Gene.ClaveImpresion = Servipunto.Libreria.Cryptography.Encrypt(txtClaveImpresion.Text.Trim());
						if(_objDat_Gene.SeguridadImpresion == true && _objDat_Gene.ClaveImpresion.Length == 0)
						{
							Session["Tab"] = "Configuracion";
                            throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1864, Global.Idioma));
						}
                        _objDat_Gene.DescargueInventario = chkDescargueInventario.Checked;
                        _objDat_Gene.ZetaAutomatico = chkZetaAutomatico.Checked;

						#endregion

						#region Cargar Pestaña Tributarios
						//						_objDat_Gene.ResolucionCont = txtTributarioResolucionGradesCont.Text;
						//						_objDat_Gene.ResolucionAutoretenedor = txtTributarioResolucionAutoretenedor.Text;
						//						_objDat_Gene.ResolucionFacturacion = txtTributarioResolucionFactura.Text;
						_objDat_Gene.TiqueteFactura = ddlTributarioTipoTiquete.SelectedValue;
						_objDat_Gene.PrefijoFactura = txtTributarioPrefijo.Text;
						//						_objDat_Gene.ConsecutivoInicial = txtTributarioConsecutivoInicial.Text.Trim().Length == 0?0:int.Parse(txtTributarioConsecutivoInicial.Text);
						//						_objDat_Gene.ConsecutivoFinal = txtTributarioConsecutivoFinal.Text.Trim().Length == 0?0:int.Parse(txtTributarioConsecutivoFinal.Text);
						//						_objDat_Gene.Regimen = ddlTributarioRegimen.SelectedValue;
						_objDat_Gene.IdNumOrden = int.Parse(txtCodigoOrden.Text);
						#endregion

						#region Cargar Pestaña Descuentos
                        _objDat_Gene.PorcentajeDescuento = 0;
                        _objDat_Gene.DctoRecaudo = false;

                     
                        
                            _objDat_Gene.FechaInicialDescuento = _objDat_Gene.FechaFinalDescuento = new DateTime(1800,12,28);
                            _objDat_Gene.HoraInicialDescuento = _objDat_Gene.HoraFinalDescuento = new DateTime(2099, 1, 1, 0, 0, 0, 0);
                    
                            //_objDat_Gene.HoraInicialDescuento = new DateTime(2099,1,1,int.Parse(ddlDescuentosHoraInicial.SelectedValue),int.Parse(ddlDescuentosMinutosIniciales.SelectedValue),0,0);
                            _objDat_Gene.HoraFinalDescuento = new DateTime(2099, 1, 1,0, 0, 0, 0);
                        

                        _objDat_Gene.MensajeDctoFidelizado ="";
						#endregion

						#region Cargar Pestaña Gas
						_objDat_Gene.ControlMantenimiento = ddlGasControlMantenimiento.SelectedValue=="Activo"?true:false;
						_objDat_Gene.TipoCentroComputo = ddlGasTipoCentroComputo.SelectedValue;
						_objDat_Gene.ActualizarFormPagGenerador = ddlGasActualizarFormasPago.SelectedValue=="Activo"?true:false;
						_objDat_Gene.VersionSuic = ddlGasVersionIdentificador.SelectedValue;
						_objDat_Gene.CobrarRecaudo = ddlGasRecaudo.SelectedValue =="Activo"?true:false;
						
                        if(txtPasswordCalibracion.Text.Trim().Length > 0)
                            _objDat_Gene.PasswordCierreXAjuste = txtPasswordCalibracion.Text;
                        //_objDat_Gene.SolicitaLectsMecanicas = 
                        //    ddlLecturasMecanicas.SelectedValue == "Si"?true:false;
						#endregion

						#region Cargar Pestaña Generar
						_objDat_Gene.RutaExportarPredeterminada = txtRutaExportarPredeterminada.Text.Trim();
						_objDat_Gene.RutaImportarPredeterminada = txtRutaImportarPredeterminada.Text.Trim();
						_objDat_Gene.PlanoVentasCreditoContado = ckbGenerarPlanoCreditoContado.Checked;
						_objDat_Gene.RutaPlanoVentasPendientes = txtRutaPlanoVentasPendientes.Text.Trim();
						_objDat_Gene.RutaPlanoVentasProcesadas = txtRutaPlanoVentasProcesadas.Text.Trim();
						_objDat_Gene.SeparadorPlanosPredeterminado = txtSeparadorPlanosPredeterminado.Text.Trim();
						_objDat_Gene.DirPlanoVentas = txtRutaPlanoVentas.Text.Trim();
						_objDat_Gene.DirPlanoLecturas = txtRutaPlanoLecturas.Text.Trim();

						_objDat_Gene.GenerarPlanoVentaSap = ckbGenerarPlanoVentaSap.Checked;
						_objDat_Gene.GenerarPlanoTrasladoSap = ckbGenerarPlanoTrasladoSap.Checked;							
						_objDat_Gene.GenerarPlanoLecturaSap = ckbGenerarPlanoLecturaSap.Checked;
						_objDat_Gene.GenerarPlanoReporte = ckbGenerarPlanoReporte.Checked;
						_objDat_Gene.GenerarPlanoTotalElectronico = ckbGenerarPlanoTotalElectronico.Checked;
						_objDat_Gene.GenerarPlanoMapa = ckbGenerarPlanoMapa.Checked;
						_objDat_Gene.GenerarPlanoCuenta = ckbGenerarPlanoCuenta.Checked;
						_objDat_Gene.GenerarPlanoPrecio = ckbGenerarPlanoPrecio.Checked;
						_objDat_Gene.GenerarPlanoInventario = ckbGenerarPlanoInventarios.Checked;
						_objDat_Gene.GenerarPlanoLecturas = chkGenerarPlanoLecturas.Checked;
						_objDat_Gene.GenerarPlanoventas = chkGenerarPlanoVentas.Checked;
						//_objDat_Gene.GenerarPlanoLecturas
						#endregion

						#region Cargar Pestaña Otros
						_objDat_Gene.JornadaZeta = rblZeta.SelectedValue;
						_objDat_Gene.Mr_Socket_Activo = rblCapturadores.SelectedValue;
						_objDat_Gene.Mr_Socket_Local_Puerto = txtPuerto.Text == "" ? 0: int.Parse(txtPuerto.Text);
						_objDat_Gene.Mr_Socket_Local_Address = txtIPServidorMRVirtual.Text;
						_objDat_Gene.ManejaDebug = cbDebug.Checked;
						_objDat_Gene.IpControlTanques = txtIpTanques.Text;
						_objDat_Gene.PeriodoVariacionTanque = cboPeriodoVariacionTanque.SelectedValue;
						_objDat_Gene.CodigoAlternoEstacion = txtCodigoAlternoEstacion.Text.Trim();
						_objDat_Gene.ConexionOracle = cbConexionOracle.Checked;
						_objDat_Gene.DebugTramasSurtidores = cbDebugSurtidores.Checked;						
						_objDat_Gene.UtilizaServidorCapturadores = rblUtilizaServidorCapturadores.SelectedValue == "S"? true : false;
						_objDat_Gene.IntentosAEstacion = Int16.Parse(txtIntentosAEstacion.Text.Trim());
						_objDat_Gene.IntentosACapturador = Int16.Parse(txtIntentosACapturador.Text.Trim());
						_objDat_Gene.IntervaloAEstacion = int.Parse(txtIntervaloAEstacion.Text.Trim());
						_objDat_Gene.IntervaloACapturador = int.Parse(txtIntervaloACapturador.Text.Trim());				
						_objDat_Gene.PuertoServidorCapturadores = int.Parse(txtPuertoServidorCapturadores.Text.Trim());
						_objDat_Gene.TiqueteVentaConfigurable = chkTiqueteVentaConfigurable.Checked;

                        _objDat_Gene.UrlWebServiceCI = txtUrlWebServiceCi.Text;
                        _objDat_Gene.UsuarioCI = txtUsuarioCi.Text;
                        _objDat_Gene.ClaveDescargaCI = txtPasswordCI.Text;
                        _objDat_Gene.DiasActualizacionCI = Convert.ToInt32(txtDiasActualizaCI.Text);
                        _objDat_Gene.TiempoEncuestaCI = Convert.ToInt32(txtMinutosEncuestaCI.Text);

                        _objDat_Gene.DiasAvisoVencimientoCanastilla = Convert.ToInt32(txtDiasAvisoResolucionCanastilla.Text);
                        _objDat_Gene.FacturasAvisoVencimientoCanastilla = Convert.ToInt32(txtFacturasAvisoResolucionCanastilla.Text);
                        _objDat_Gene.AutorizacionConductor = ChkVentaAutorizadaConConductor.Checked ? "S" : "N";
                        _objDat_Gene.DescargueInventario = chkDescargueInventario.Checked;
                        _objDat_Gene.ZetaAutomatico = chkZetaAutomatico.Checked;
						#endregion

						if(Libreria.Configuracion.Datos_Gene.ObtenerItem() == null)
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,125, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							Servipunto.Estacion.Libreria.Configuracion.Datos_Gene.Adicionar(this._objDat_Gene);
						}
						else
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,126, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objDat_Gene.Modificar();
						}

						Response.Redirect("default.aspx");
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
					this._objDat_Gene = null;
				}
			}
		}
		#endregion

		#region Validar
		private bool Validar()
		{
			this.ClearError();

			#region Validaciones de la pestaña generales
			if(ddlGeneralCompañia.Items.Count == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1880, Global.Idioma), false);
				return false;
			}

			if(ddlGeneralGrupo.Items.Count == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1881, Global.Idioma), false);
				return false;
			}

			if(ddlGeneralEstacion.Items.Count == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1882, Global.Idioma), false);
				return false;
			}
			if(txtGeneralRazonSocial.Text.Length == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1883, Global.Idioma), false);
				return false;
			}

			if(txtGeneralNit.Text.Length == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1884, Global.Idioma), false);
				return false;
			}

			if(txtGeneralNitDive.Text.Length == 0)
			{
				Session["Tab"] = "GenFeral";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1885, Global.Idioma), false);
				return false;
			}

			if(txtGeneralDireccion.Text.Length == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1886, Global.Idioma), false);
				return false;
			}
			if(txtGeneralTelefono.Text.Length == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1887, Global.Idioma), false);
				return false;
			}
			/*if(txtGeneralCiudad.Text.Length == 0)
			{
				Session["Tab"] = "General";
				this.SetError("Falta ingresar la ciudad", false);
				return false;
			}
			*/
			if(txtGeneralSlogan.Text.Length == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1888, Global.Idioma), false);
				return false;
			}	

			if(chkImprimirMensajeAdicional.Checked && txtMensajeAdicional.Text.Trim().Length == 0)
			{
				Session["Tab"] = "General";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1889, Global.Idioma), false);
				return false;
			}	

			txtMensajeAdicionalMayoresA.Text = txtMensajeAdicionalMayoresA.Text.Replace(".",",");
			if(txtMensajeAdicionalMayoresA.Text.Length == 0)
			{
				txtMensajeAdicionalMayoresA.Text = "0";
			}	
			

			#endregion

			#region Validaciones de la pestaña Configuración
			if(ddlConfiguracionTipoEstacion.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Configuracion";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1890, Global.Idioma), false);
				return false;
			}
			if(ddlConfiguracionVentasPredefinidas.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Configuracion";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1891, Global.Idioma), false);
				return false;
			}
			if(ddlConfiguracionFidelizado.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Configuracion";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1892, Global.Idioma), false);
				return false;
			}
			if(ddlConfiguracionPermitirCreacionEmpleadosTarjetas.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Configuracion";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1893, Global.Idioma), false);
				return false;
			}

			if(txtConfiguracionValorBolsa.Text.Length == 0)
			{
				Session["Tab"] = "Configuracion";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1894, Global.Idioma), false);
				return false;
			}

			if(txtConfiguracionCodigoSucursal.Text.Length == 0)
			{
				Session["Tab"] = "Configuracion";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1895, Global.Idioma), false);
				return false;
			}

			if(ddlConfiguracionCapturarPantalla.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Configuracion";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1896, Global.Idioma), false);
				return false;
			}
			if(ddlConfiguracionLimpiarDisplay.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Configuracion";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1897, Global.Idioma), false);
				return false;
			}

			try
			{
				Session["Tab"] = "Configuracion";
				txtClaveImpresion.Text = txtClaveImpresion.Text.Trim();
				if(txtClaveImpresion.Text.Trim().Length > 0)
				{
					if(txtClaveImpresion.Text.Trim().Length == 4)
					{
						int.Parse(txtClaveImpresion.Text.Trim());
					}
					else
					{
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1898, Global.Idioma), false);
						return false;
					}
				}
			}
			catch(Exception)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1898, Global.Idioma), false);
				return false;
			}
			
			try
			{
				Session["Tab"] = "Configuracion";
				if(chkSeguridadImpresion.Checked)
				{
					byte tiempo = byte.Parse(txtTiempoSeguridadImpresion.Text); 
					if(tiempo < 1)
					{
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1899, Global.Idioma), false);
						return false;
					}
				}
			}
			catch(Exception)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1899, Global.Idioma), false);
				return false;
			}
				

			#endregion

			#region Validaciones de la pestaña tributaria
			if(ddlTributarioTipoTiquete.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Tributario";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1901, Global.Idioma), false);
				return false;
			}

			// COMENTARIOS POR R.F. ENERO 19-2007
			//			if(ddlTributarioRegimen.SelectedValue == "(Sin Definir)")
			//			{
			//				Session["Tab"] = "Tributario";
			//				this.SetError("Falta seleccionar el regimen", false);
			//				return false;
			//			}
			#endregion

            #region Validaciones de la pestaña descuentos
            ////if(txtDescuentosDescuento.Text.Length > 0)
            //{
            //    try
            //    {
            //        //float.Parse(txtDescuentosDescuento.Text);
            //    }
            //    catch
            //    {
            //        Session["Tab"] = "Descuentos";
            //        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1902, Global.Idioma), false);
            //        return false;
            //    }				
            //}

            ////if(CalendarioFinal.SelectedDate < CalendarioInicial.SelectedDate)
            ////{
            //    Session["Tab"] = "Descuentos";
            //    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1903, Global.Idioma), false);
            //    return false;
            ////}

            ////if(ddlDescuentosHoraInicial.SelectedIndex == 0 && ddlDescuentosHoraFinal.SelectedIndex != 0)
            ////{
            //    Session["Tab"] = "Descuentos";
            //    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1904, Global.Idioma), false);
            //    return false;
            ////}

            ////if(ddlDescuentosHoraFinal.SelectedIndex == 0 && ddlDescuentosHoraInicial.SelectedIndex != 0)
            ////{
            //    Session["Tab"] = "Descuentos";
            //    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1905, Global.Idioma), false);
            //    return false;
            ////}

            ///*if(ddlDescuentosHoraFinal.SelectedValue != "24" && 
            //    int.Parse(ddlDescuentosHoraFinal.SelectedValue)*60 + int.Parse(ddlDescuentosMinutosFinales.SelectedValue) < 
            //    int.Parse(ddlDescuentosHoraInicial.SelectedValue)*60 + int.Parse(ddlDescuentosMinutosIniciales.SelectedValue))
            //{
            //    Session["Tab"] = "Descuentos";
            //    this.SetError("La hora de descuento inicial no puede ser mayor que la final", false);
            //    return false;				
            //}
            //*/
            //try
            //{
            //    //ddlDescuentosHoraInicial.SelectedValue = ddlDescuentosHoraInicial.SelectedValue == "24" ? "0": ddlDescuentosHoraInicial.SelectedValue;
            //    //ddlDescuentosHoraFinal.SelectedValue = ddlDescuentosHoraFinal.SelectedValue == "24" ? "0": ddlDescuentosHoraFinal.SelectedValue;

            //    //DateTime fechaInicial = DateTime.Parse(CalendarioInicial.SelectedDate.ToString("yyyy-MM-dd") + " " + ddlDescuentosHoraInicial.SelectedValue.PadLeft(2,'0') + ":" + ddlDescuentosMinutosIniciales.SelectedValue.PadLeft(2,'0'));
            //    //DateTime fechaFinal = DateTime.Parse(CalendarioFinal.SelectedDate.ToString("yyyy-MM-dd") + " " + ddlDescuentosHoraFinal.SelectedValue.PadLeft(2,'0') + ":" + ddlDescuentosMinutosFinales.SelectedValue.PadLeft(2,'0'));
            //    //if(fechaInicial > fechaFinal)
            //    //{
            //        Session["Tab"] = "Descuentos";
            //        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1906, Global.Idioma), false);
            //        return false;				
            //    //}
            //}
            //catch(Exception)
            //{

            //}
            #endregion

            #region Validaciones de la pestaña Gas
            if (ddlGasControlMantenimiento.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Gas";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1907, Global.Idioma), false);
				return false;			
			}
			if(ddlGasTipoCentroComputo.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Gas";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1908, Global.Idioma), false);
				return false;	
			}
			if(ddlGasActualizarFormasPago.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Gas";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1909, Global.Idioma), false);
				return false;	
			}
			if(ddlGasVersionIdentificador.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Gas";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1910, Global.Idioma), false);
				return false;	
			}
			if(ddlGasRecaudo.SelectedValue == "(Sin Definir)")
			{
				Session["Tab"] = "Gas";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1911, Global.Idioma), false);
				return false;	
			}			

			if(txtCodigoOrden.Text.Length > 0)
			{
				try
				{
					int.Parse(txtCodigoOrden.Text);
				}
				catch
				{
					Session["Tab"] = "Gas";
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1912, Global.Idioma), false);
					return false;
				}				
			}
			else
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1913, Global.Idioma), false);
			}
			#endregion

			#region validacion de la pestaña otros

			try
			{
				if(rblCapturadores.SelectedValue == "N")
					return true;
				//valida si el puerto es entero 
				try
				{
					int puerto = int.Parse(txtPuerto.Text);
					if(puerto <= 0)
						throw new Exception();
				}
				catch(Exception)
				{
					Session["Tab"] = "Otros";
					txtPuerto.Text = "7000";
                    throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1914, Global.Idioma));				
				}


				//valida las ip
				string [] cadena = txtIPServidorMRVirtual.Text.Split(".".ToCharArray());
				if(cadena.Length != 4)
                    throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1915, Global.Idioma));
				for(int i=0; i<=3; i++)
				{
					if(int.Parse(cadena[i])< 0 || int.Parse(cadena[i]) > 255)
					{
						Session["Tab"] = "Otros";
                        throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1915, Global.Idioma));
					}
				}

				if(txtIpTanques.Text.Length>0)
				{
					cadena = txtIpTanques.Text.Split(".".ToCharArray());
					if(cadena.Length != 4)
                        throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1916, Global.Idioma));
					for(int i=0; i<=3; i++)
					{
						if(int.Parse(cadena[i])< 0 || int.Parse(cadena[i]) > 255)
						{
							Session["Tab"] = "Otros";
                            throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1916, Global.Idioma));
						}
					}
				}
				//valida el puerto del servidor de capturadores				
				try
				{
					txtPuertoServidorCapturadores.Text = txtPuertoServidorCapturadores.Text.Trim().Length == 0?"7010":txtPuertoServidorCapturadores.Text.Trim();
					int puertoServidorCapturadores = int.Parse(txtPuertoServidorCapturadores.Text.Trim());
					if(puertoServidorCapturadores <= 0)
						throw new Exception();
				}
				catch(Exception)
				{
					Session["Tab"] = "Otros";
					txtPuertoServidorCapturadores.Text = "7010";
                    throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1917, Global.Idioma));				
				}
				//valida intentos a estacion
				try
				{
					txtIntentosAEstacion.Text = txtIntentosAEstacion.Text.Trim().Length == 0?"0":txtIntentosAEstacion.Text.Trim();
					Int16 intentos = Int16.Parse(txtIntentosAEstacion.Text.Trim());
					if(intentos < 0)
						throw new Exception();
				}
				catch(Exception)
				{
					Session["Tab"] = "Otros";
					txtIntentosAEstacion.Text = "0";
                    throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1918, Global.Idioma));				
				}
				//valida los intentos a capturador
				try
				{
					txtIntentosACapturador.Text = txtIntentosACapturador.Text.Trim().Length == 0?"0":txtIntentosACapturador.Text.Trim();
					Int16 intentos = Int16.Parse(txtIntentosACapturador.Text.Trim());
					if(intentos < 0)
						throw new Exception();
				}
				catch(Exception)
				{
					Session["Tab"] = "Otros";
					txtIntentosACapturador.Text = "0";
                    throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1919, Global.Idioma));				
				}

				//valida el tiempo entre reintentos de estacion
				try
				{
					txtIntervaloAEstacion.Text = txtIntervaloAEstacion.Text.Trim().Length == 0?"10000":txtIntervaloAEstacion.Text.Trim();
					int reintentos = int.Parse(txtIntervaloAEstacion.Text.Trim());
					if(reintentos <= 0)
						throw new Exception();
				}
				catch(Exception)
				{
					Session["Tab"] = "Otros";
					txtIntervaloAEstacion.Text = "10000";
                    throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1920, Global.Idioma));				
				}

				//valida el tiempo entre reintentos de capturador
				try
				{
					txtIntervaloACapturador.Text = txtIntervaloACapturador.Text.Trim().Length == 0?"500":txtIntervaloACapturador.Text.Trim();
					int reintentos = int.Parse(txtIntervaloACapturador.Text.Trim());
					if(reintentos <= 0)
						throw new Exception();
				}
				catch(Exception)
				{
					Session["Tab"] = "Otros";
					txtIntervaloACapturador.Text = "500";
                    throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1921, Global.Idioma));				
				}

			}
			catch(Exception ex)
			{
				this.SetError("error; " + ex.Message, false);
				return false;			
			}

			#endregion

			return true;
		}
		#endregion

		#region Llenar Listas
		private void CargarCompañias()
		{
			try
			{
				Libreria.Configuracion.Companias objCompañias = new Libreria.Configuracion.Companias();

				this.ddlGeneralCompañia.DataSource = objCompañias;
				this.ddlGeneralCompañia.DataTextField = "Nombre";
				this.ddlGeneralCompañia.DataValueField = "IdCompania";
				this.ddlGeneralCompañia.DataBind();

				if (this.ddlGeneralCompañia.Items.Count == 0)
				{
                    this.ddlGeneralCompañia.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1865, Global.Idioma));
					this.hlCompañia.Visible = true;
					this.lbGeneral.Enabled = false;
					this.lbConf.Enabled=false;
//					this.lbtributaria.Enabled=false;
                    //this.lbDesc.Enabled = false;
					this.lbGas.Enabled = false;
				}
			}
			catch(Exception ex)
			{
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1866, Global.Idioma) + ex.Message, false);
			}
		}

		private void CargarGrupos()
		{
			try
			{
				Libreria.Configuracion.Grupos objGrupos = new Libreria.Configuracion.Grupos();
				this.ddlGeneralGrupo.DataSource = objGrupos;
				this.ddlGeneralGrupo.DataTextField = "Nombre";
				this.ddlGeneralGrupo.DataValueField = "IdGrupo";
				this.ddlGeneralGrupo.DataBind();
				if (this.ddlGeneralGrupo.Items.Count == 0)
				{
                    this.ddlGeneralGrupo.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma));
					this.hlgrupo.Visible = true;
					this.lbGeneral.Enabled = false;
					this.lbConf.Enabled=false;
	//				this.lbtributaria.Enabled=false;
                    //this.lbDesc.Enabled = false;
					this.lbGas.Enabled = false;
				}
			}
			catch(Exception ex)
			{
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma) + ex.Message, false);
			}			
		}

		private void CargarEstaciones()
		{
            try
            {
                Libreria.Configuracion.Estaciones objEstaciones = new Libreria.Configuracion.Estaciones();
                this.ddlGeneralEstacion.DataSource = objEstaciones;
                this.ddlGeneralEstacion.DataTextField = "Nombre";
                this.ddlGeneralEstacion.DataValueField = "IdEstacion";
                this.ddlGeneralEstacion.DataBind();
                if (this.ddlGeneralEstacion.Items.Count == 0)
                {
                    this.ddlGeneralEstacion.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma));
                    this.hlEstacion.Visible = true;
                    this.lbGeneral.Enabled = false;
                    this.lbConf.Enabled = false;
                    //					this.lbtributaria.Enabled=false;
                    //this.lbDesc.Enabled = false;
                    this.lbGas.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma) + ex.Message, false);
            }				
		}
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

        //private void CargarMinutos()
        //{
        //    try
        //    {
        //        Libreria.Configuracion.Estaciones objEstaciones = new Libreria.Configuracion.Estaciones();
        //        for(int i = 0 ; i < 60 ; i++)
        //            if(i < 10)
        //            {
        //                //this.ddlDescuentosMinutosIniciales.Items.Add(new ListItem("0" + i, i.ToString()));
        //                //this.ddlDescuentosMinutosFinales.Items.Add(new ListItem("0" + i, i.ToString()));
        //            }
        //            else
        //            {
        //                //this.ddlDescuentosMinutosIniciales.Items.Add(new ListItem(i.ToString(), i.ToString()));
        //                //this.ddlDescuentosMinutosFinales.Items.Add(new ListItem(i.ToString(), i.ToString()));
        //            }
        //    }
        //    catch(Exception ex)
        //    {
        //        SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma) + ex.Message, false);
        //    }			
        //}
		
		
		#region Método CargarDepartamento por ciudad para edición
		private void CargarDepartamento(string codCiudad)
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

		#endregion

		# region Eventos de calendario
		#region Mostrar Calendario Inicial
        //private void ibMostrarCalendarioInicial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    //this.CalendarioInicial.Visible = !this.CalendarioInicial.Visible;
        //    //if(this.CalendarioFinal.Visible)
        //    //    this.CalendarioFinal.Visible = !this.CalendarioFinal.Visible;
        //    Session["Tab"] = "Descuentos";
        //}
		#endregion

		#region Mostrar Calendario Final
        //private void ibMostrarCalendarioFinal_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    this.CalendarioFinal.Visible = !this.CalendarioFinal.Visible;
        //    if(this.CalendarioInicial.Visible)
        //        this.CalendarioInicial.Visible = !this.CalendarioInicial.Visible;
        //    Session["Tab"] = "Descuentos";
        //}
		#endregion

        //#region Seleccionar Fecha en el Calendario Inicial
        //private void CalendarioInicial_SelectionChanged(object sender, System.EventArgs e)
        //{
        //    //this.txtDescuentosFechaInicial.Text = this.CalendarioInicial.SelectedDate.ToString("dd/MM/yyyy");
        //    //this.CalendarioInicial.Visible = !this.CalendarioInicial.Visible;
        //}
        //#endregion

        //#region Seleccionar Fecha en el Calendario Final
        //private void CalendarioFinal_SelectionChanged(object sender, System.EventArgs e)
        //{
        //    this.txtDescuentosFechaFinal.Text = this.CalendarioFinal.SelectedDate.ToString("dd/MM/yyyy");
        //    this.CalendarioFinal.Visible = !this.CalendarioFinal.Visible;
        //}
        //#endregion
		#endregion

		#region ActivarMensaje
		private void chkImprimirMensajeAdicional_CheckedChanged(object sender, System.EventArgs e)
		{			
			txtMensajeAdicional.Enabled = chkImprimirMensajeAdicional.Checked;
			txtMensajeAdicionalMayoresA.Enabled = chkImprimirMensajeAdicional.Checked;
		}
		#endregion

		#region ActivarSeguridadImpresion
		private void chkSeguridadImpresion_CheckedChanged(object sender, System.EventArgs e)
		{
			Session["Tab"] = "Configuracion";
			txtTiempoSeguridadImpresion.Enabled = chkSeguridadImpresion.Checked;
			txtClaveImpresion.Enabled = chkSeguridadImpresion.Checked;
		}
		#endregion
		
		#region Sin Fecha Definida
        //private void cbSinFechaDefinida_CheckedChanged(object sender, System.EventArgs e)
        //{
        //    Session["Tab"] = "Descuentos";
        //    //SinFechaDefAux();
        //}
		#endregion

		#region Funcion Auxiliar sin Fecha Definida
        //private void SinFechaDefAux()
        //{
        //    if(cbSinFechaDefinida.Checked)
        //    {
        //        txtDescuentosFechaInicial.Text = txtDescuentosFechaFinal.Text = "(Sin Fecha Definida)";
        //        ibMostrarCalendarioInicial.Visible = false;
        //        ibMostrarCalendarioFinal.Visible = false;
        //        CalendarioInicial.Visible = false;
        //        CalendarioFinal.Visible = false;
        //    }
        //    else
        //    {
        //        txtDescuentosFechaInicial.Text = CalendarioInicial.SelectedDate.ToString("dd/MM/yyyy");
        //        txtDescuentosFechaFinal.Text = CalendarioFinal.SelectedDate.ToString("dd/MM/yyyy");
        //        ibMostrarCalendarioInicial.Visible = true;
        //        ibMostrarCalendarioFinal.Visible = true;
        //    }
        //}
		#endregion

		#region Guarda Los datos ingresados
		private void lbGeneral_Click(object sender, System.EventArgs e)
		{
			Guardar();
		}
		#endregion

        //private void optDctoFidelizacion_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
            //Session["Tab"] = "Descuentos";
            //if(optDctoFidelizacion.SelectedValue=="1")
                //txtMensajeDctoFidelizado.Enabled = true;
            //else
                //txtMensajeDctoFidelizado.Enabled = false;
		
        //}

      /*  private void CargarTipoAutizacionExterna()
        {
            Libreria.TipoAutotipo objFormasPago = new Libreria.Configuracion.FormasPago();
            ddlFormaDePagoEdit.DataSource = objFormasPago;
            ddlFormaDePagoEdit.DataTextField = "Descripcion";
            ddlFormaDePagoEdit.DataValueField = "IdFormaPago";
            ddlFormaDePagoEdit.DataBind();
            ddlFormaDePagoEdit.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "0"));
        }*/
	}
}
