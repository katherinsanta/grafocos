using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion {
	/// <summary>
	/// Datos Generales. 
	/// </summary>
	public class Dat_Gene { 
		
		#region Declarations
		private int     _cod_Comp, _cod_Gru, _cod_Est, _cod_Suc;
		//private int     _cod_Comp, _cod_Gru, _cod_Est, _cons_IniFact, _cons_Actual, _cod_Suc;
		private int     _idNumOrden,_idPais;
		private string  _razon_Social, _tipo_Nit, _nit, _nit_Dive, _direccion, _telefono, _ciudad, _slogan, _imp_Factura;
		//private string  _regimen, _resolucion_Fact, _resolucion_Auto, _resolucion_Cont, 
		private string _pref_Fact;
		private string  _suic_Ver, _claveCPA, _tipoGas,  _tipoCc;
		private decimal _vr_Bolsa, _descuento;
		private bool _limpiar_display,_ventas_Pre, _capturador_Pantalla, _control_Mant, _ver_Subclases, _recuado, _activa;
		private bool _soli_Lect, _fidelizado; 
		private DateTime _horaIniDesc, _horaFinDesc, _fecIniDesc, _fecFinDesc;
		private bool _dcto_recaudo;
		private bool _dctoFidelizado;
		private int _sap;
		private string _jornadaZeta="N";
		private string _mr_Socket_Activo="N";
		private int _mr_Socket_Local_Puerto;
		private string _mr_Socket_Local_Address;
		private string _ipControlTanques;
		private bool _manejaDebug;
		private string _periodoVariacionTanque;
		private string _rutaPlanoVentasPendientes;
		private string _rutaPlanoVentasProcesadas = "c:\\Servipunto\\Planos\\ParaImportar\\Procesados";
		private string _mensajeDctoFidelizado;
		private string _rutaExportarPredeterminada = "c:\\Servipunto\\Planos\\Exportado";
		private string _rutaImportarPredeterminada = "c:\\Servipunto\\Planos\\ParaImportar";
		private string _codigoAlternoEstacion;
		private bool _planoVentasCreditoContado;
		private bool _conexionOracle;
		private bool _generarPlanoVentaSap;
		private bool _generarPlanoTrasladoSap;
		private bool _generarPlanoLecturaSap;
		private bool _generarPlanoReporte;
		private bool _generarPlanoTotalElectronico;
		private bool _generarPlanoMapa;
		private bool _generarPlanoCuenta;
		private bool _generarPlanoPrecio;
		private bool _debugTramasSurtidores;
		private string _separadorPlanosPredeterminado=";";
		private bool _lecturasPorVenta;
		private Int16 _intentosAEstacion=0;
		private Int16 _intentosACapturador=1;
		private int _intervaloACapturador=500;
		private int _intervaloAEstacion = 30000;
		private bool _utilizaServidorCapturadores = false;
		private int _puertoServidorCapturadores = 7010;
		private Int16 _tipoAutorizacion = 1; //1:Manguera 2:Cara
		private bool _imprimirMensajeAdicional = false;
		private string _mensajeAdicional;
		private decimal _mensajeAdicionalMayoresA;
		private bool _seguridadImpresion;
		private string _claveImpresion="";
		private byte _tiempoSeguridadImpresion;
		private bool _generarPlanoInventario;
		private bool _generarPlanoLecturas;
		private bool _generarPlanoVentas;
		private string _dirPlanoLecturas;
		private string _dirPlanoVentas;
		private bool _tiqueteVentaConfigurable;
        private string _urlWebServiceCI;
		private	string _claveDescargaCI;
		private	string	_usuarioCI;
		private	int	_diasActualizacionCI;
		private	int	_tiempoEncuestaCI;
        private int _diasAvisoVencimientoCanastilla;
        private int _facturasAvisoVencimientoCanastilla;
        private string _autorizacionConductor;
        private bool _descargueInventario;
        private bool _zetaAutomatico;
        private byte _idTipoAutizacionExterna;
		#endregion
		
		#region Constructor/Destructor
		/// <summary>
		/// Dat_Gene class Constructor
		/// </summary>
		public Dat_Gene()
		{			
		}
		#endregion

		#region Public_Properties
		/// <summary>
		/// Representa el Codigo de la Compañia
		/// </summary>
		public int CodCompania{
			get{ return this._cod_Comp;  }
			set{ this._cod_Comp = value; }
        }
		/// <summary>
		/// Representa el Codigo de Grupo.
		/// </summary>
		public int CodGrupo{
			get{ return this._cod_Gru;  }
			set{ this._cod_Gru = value; }
		}
        /// <summary>
        /// Representa el Codigo de la Estacion.
        /// </summary>
		public int CodEstacion{
			get { return this._cod_Est;  }
			set { this._cod_Est = value; }
		}
        /// <summary>
        /// Representa la razon social de la EDS.
        /// </summary>
		public string RazonSocial{
			get { return this._razon_Social;  }
			set { this._razon_Social = value; }
		}
		/// <summary>
		/// Representa el tipo de Nit que utiliza la EDS.
		/// Nit - Cédula Ciudadanía - Cédula Extanjería -  Pasaporte
		/// </summary>
 		public string TipoNit{
			get { return this._tipo_Nit;  }
			set { this._tipo_Nit = value; }
		}
		/// <summary>
		/// Representa el NIT de la EDS.
		/// </summary>
		public string Nit{
			get { return this._nit;  }
			set { this._nit = value; }
		}
		/// <summary>
		/// Representa el digito de verificacion del NIT.
		/// </summary>
		public string NitDive{
			get { return this._nit_Dive;  }
			set { this._nit_Dive = value; }
		}
		/// <summary>
		/// Representa la Direccion de la EDS.
		/// </summary>
		public string Direccion{
			get { return this._direccion;  }
			set { this._direccion = value; }
		}
		/// <summary>
		/// Representa el Telefono de la EDS.
		/// </summary>
		public string Telefono{
			get { return this._telefono;  }
			set { this._telefono = value; }
		}
		/// <summary>
		/// Representa la ciudad donde esta ubicada la EDS.
		/// </summary>
		public string Ciudad{
			get { return this._ciudad;  }
			set { this._ciudad = value; }
		}
		/// <summary>
		/// Representa el slogan No.1 de la EDS.
		/// </summary>
		public string Slogan{
			get { return this._slogan;  }
			set { this._slogan = value; }
		}
		/// <summary>
		/// F. Imprime Facturas, T. Imprime Tiquetes.
		/// Web: Factura    Tiquete
		/// </summary>
		public string TiqueteFactura{
			get { return this._imp_Factura;  }
			set { this._imp_Factura = value; }
		}

		/// <summary>
		/// C. Regimen Comun. S. Simplificado.
		/// Web: Comun    Simplificado
		/// </summary>
//		public string Regimen {
//			get { return this._regimen;  }
//			set { this._regimen = value; }
//		}
		/// <summary>
		/// Representa la Resolucion de Facturacion.
		/// </summary>
//		public string ResolucionFacturacion {
//			get { return this._resolucion_Fact;  }
//			set { this._resolucion_Fact = value; }
//		}
//		/// <summary>
//		/// Representa la resolucion de Autoretenedor.
//		/// </summary>
//		public string ResolucionAutoretenedor {
//			get { return this._resolucion_Auto;  }
//			set { this._resolucion_Auto = value; }
//		}
		/// <summary>
		/// Para Colombia. representa la resolucion de contribuyente.
		/// Para Bolivia. representa el numero de orden o dosificacion.
		/// </summary>
//		public string ResolucionCont {
//			get { return this._resolucion_Cont;  }
//			set { this._resolucion_Cont = value; }
//		}
		/// <summary>
		/// Representa el prefijo de la factura.
		/// </summary>
		public string PrefijoFactura {
			get { return this._pref_Fact;  }
			set { this._pref_Fact = value; }
		}
//		/// <summary>
//		/// Consecutivo inicial de facturacion.
//		/// </summary>
//		public int ConsecutivoInicial {
//			get { return this._cons_IniFact;  }
//			set { this._cons_IniFact = value; }
//		}
//		/// <summary>
//		/// Para Colombia. Representa el consecutivo actual
//		/// Para Bolivia. Representa el consecutivo final de facturacion.
//		/// </summary>
//		public int ConsecutivoFinal {
//			get { return this._cons_Actual;  }
//			set { this._cons_Actual = value; }
//		}
		/// <summary>
		/// 0. No Limpia display del surtidor. 1. Limpia Display
		/// Web: Si        No
		/// </summary>
		public bool LimpiarDisplay {
			get { return this._limpiar_display;  }
			set { this._limpiar_display = value; }
		}
		/// <summary>
		/// SelftService: A. Activo. I. Inactivo.
		/// Web: Activo      Inactivo
		/// </summary>
		public bool SelfService {
			get { return this._ventas_Pre;  }
			set { this._ventas_Pre = value; }
		}
		/// <summary>
		/// Ejecutar Simulador MR.
		/// A. Activo. I. Inactivo
		/// Web: Activo      Inactivo
		/// </summary>
		public bool CapturadorEnPantalla {
			get { return this._capturador_Pantalla;  }
			set { this._capturador_Pantalla = value; }
		}
		/// <summary>
		/// Validar COntrol de Mantenimiento.
		/// S. Si  N. No
		/// Web: Activo      Inactivo
		/// </summary>
		public bool ControlMantenimiento {
			get { return this._control_Mant;  }
			set { this._control_Mant = value; }
		}
		/// <summary>
		/// Representa el Valor de la bolsa de dinero.
		/// </summary>
		public decimal ValorBolsaDinero {
			get { return this._vr_Bolsa;  }
			set { this._vr_Bolsa = value; }
		}
		/// <summary>
		/// Actualizar Forma de pago de automotores con generador.
		/// S. Si   N. NO
		/// Web: Activo      Inactivo
		/// </summary>
		public bool ActualizarFormPagGenerador {
			get { return this._ver_Subclases;  }
			set { this._ver_Subclases = value; }
		}
		/// <summary>
		/// Cobrar Recaudo.
		/// S. Si  N. No
		/// Web: Activo      Inactivo
		/// </summary>
		public bool CobrarRecaudo {
			get { return this._recuado;  }
			set { this._recuado = value; }
		}
		/// <summary>
		/// Version de lectura de Ibuttons.
		/// N. No  S. Si  T. NTC4829
		/// Web: Si     No    NTC4829
		/// </summary>
		public string VersionSuic {
			get { return this._suic_Ver; }
			set { this._suic_Ver = value;}
		} 
		/// <summary>
		/// Representa el codigo de la sucursal para 
		/// </summary>
		public int CodigoSucursal {
			get { return this._cod_Suc; }
			set { this._cod_Suc = value;}
		}
		/// <summary>
		/// Representa el tipo de cento de computo al cual se comunica la EDS
		/// 0. TPS  1. SQL
		/// Web: TPS       SQL
		/// </summary>
		public string TipoCentroComputo {
			get { return this._tipoCc; }
			set { this._tipoCc = value;}
		}	  
		/// <summary>
		/// Permitir la Creacion de tarjetas activas en la EDS
		/// S. Si  N. No
		/// Si        No
		/// </summary>
		public bool CrearTarjActivas {
			get { return this._activa; }
			set { this._activa = value;}
		}
		/// <summary>
		/// Representa el % de descuento para aplicar a las ventas.
		/// </summary>
		public decimal PorcentajeDescuento {
			get { return this._descuento; }
			set { this._descuento = value;}
		}
		/// <summary>
		/// Representa la fecha ('aaaa-mm-dd') inicial para la cual aplica el decuento.
		/// Web: Ninguna Fecha = '1800-12-28'
		/// </summary>
		public DateTime FechaInicialDescuento {
			get { return this._fecIniDesc; }
			set { this._fecIniDesc = value;}
		}
		/// <summary>
		/// Representa la fecha ('aaaa-mm-dd') Final para la cual aplica el decuento.
		/// Web: Ninguna Fecha = '1800-12-28'
		/// </summary>
		public DateTime FechaFinalDescuento {
			get { return this._fecFinDesc; }
			set { this._fecFinDesc = value;}
		}
		/// <summary>
		///Representa la hora (DateTime) inicial para la cual aplica el decuento.
		/// </summary>
		public DateTime HoraInicialDescuento {
			get { return this._horaIniDesc; }
			set { this._horaIniDesc = value;}
		}
		/// <summary>
		/// Representa la hora (DateTime) final para la cual aplica el decuento.
		/// </summary>
		public DateTime HoraFinalDescuento {
			get { return this._horaFinDesc; }
			set { this._horaFinDesc = value;}
		}
		/// <summary>
		/// Solicitar Lecturas Mecanicas.
		/// S. Si     N. No
		/// Web:  Si    No
		/// </summary>
		public bool SolicitaLectsMecanicas {
			get { return this._soli_Lect; }
			set { this._soli_Lect = value;}
		}
		/// <summary>
		/// Guarda la clave par el cierre por Ajuste
		/// </summary>
		public string PasswordCierreXAjuste {
			get { return this._claveCPA; }
			set { this._claveCPA = value;}
		}
		/// <summary>
		/// Tipo de Estacion
		/// 0. Gasolina     1. Gas
		/// Web: Gasolina       Gas
		/// </summary>
		public string TipoEstacion {
			get { return this._tipoGas; }
			set { this._tipoGas = value;}
		}
		/// <summary>
		/// Representa si la EDS Fideliza o no
		/// S. Si          N. No
		/// Web: Si        No
		/// </summary>
		public bool EDSFideliza {
			get { return this._fidelizado; }
			set { this._fidelizado = value;}
		}
		/// <summary>
		/// Para Bolivia: Id de la tabla bol_NumOrdenes. numero de orden configurada.
		/// </summary>
		public int IdNumOrden {
			get { return this._idNumOrden; }
			set { this._idNumOrden = value;}
		}
		/// <summary>
		/// Aplica la estacion recaudo
		/// 1. S -> SI		0. N -> No
		/// Juan F Obando 29-08-2006 -> Recaudo
		/// </summary>
		public bool DctoRecaudo 
		{
			get { return this._dcto_recaudo;}
			set { this._dcto_recaudo = value;}
		}

		/// <summary>
		/// Identifica si sera aplicado descuento o solo fidelizado
		/// 0 = Descuento
		/// 1 = Fidelizado
		/// </summary>
		public bool DctoFidelizado 
		{
			get { return this._dctoFidelizado; }
			set { this._dctoFidelizado = value;}
		}

		/// <summary>
		/// Identifica el pais actual
		/// </summary>

		public int idPais 
		{
			get { return this._idPais; }
			set { this._idPais = value;}
		}

		
		/// <summary>
		/// Idetifica si sera utilizada la interfaz contable para sap de importación y exportación de archivos
		/// 0 = No activada
		/// 1 = ventas y traslados
		/// 2 = total lecturasas por dia
		/// 3 = todos
		/// </summary>
		public int Sap 
		{
			get { return this._sap; }
			set { this._sap = value;}
		}

		/// <summary>
		/// Idetifica si sera activada la jornada fiscal Z
		/// 0 = No activada
		/// 1 = Si activada
		/// </summary>
		public string JornadaZeta
		{
			get { return this._jornadaZeta; }
			set { this._jornadaZeta = value;}
		}

		/// <summary>
		/// Direccion IP donde se encontrara el servidor de MRVirtual
		/// </summary>
		public string Mr_Socket_Local_Address 
		{
			get { return this._mr_Socket_Local_Address; }
			set { this._mr_Socket_Local_Address = value;}
		}

		/// <summary>
		/// Puerto por el cual se establecera comunicacion con el servidor de MRVirtual
		/// </summary>
		public int Mr_Socket_Local_Puerto
		{
			get { return this._mr_Socket_Local_Puerto; }
			set { this._mr_Socket_Local_Puerto = value;}
		}

		/// <summary>
		/// Fija si va a manejar MR's virtuales por medio de sockets
		/// </summary>
		public string Mr_Socket_Activo
		{
			get { return this._mr_Socket_Activo; }
			set { this._mr_Socket_Activo = value;}
		}

		/// <summary>
		/// Si gurada las tramas que llegan y las tramas que salen en un archivo
		/// </summary>
		public bool ManejaDebug
		{
			get { return this._manejaDebug; }
			set { this._manejaDebug = value;}
		}

		/// <summary>
		/// Direccion ip de los tanques
		/// </summary>
		public string IpControlTanques
		{
			get { return this._ipControlTanques; }
			set { this._ipControlTanques = value;}
		}

		/// <summary>
		/// Direccion de variacion del tanque S:Semanal, M:Mensual
		/// </summary>
		public string PeriodoVariacionTanque
		{
			get { return this._periodoVariacionTanque; }
			set { this._periodoVariacionTanque = value;}
		}


			/// <summary>
			/// Ruta donde de donde se cargara un plano de ventas pendientes para el capturador virtual
			/// </summary>
		public string RutaPlanoVentasPendientes
		{
			get { return this._rutaPlanoVentasPendientes; }
			set { this._rutaPlanoVentasPendientes = value;}
		}


		/// <summary>
		/// Ruta donde de donde se colocará un plano de ventas que ya fue procesado para el capturador virtual
		/// </summary>
		public string RutaPlanoVentasProcesadas
		{
			get { return this._rutaPlanoVentasProcesadas; }
			set { this._rutaPlanoVentasProcesadas = value;}
		}


		/// <summary>
		/// Mensaje de Descuento a fidelizado
		/// </summary>
		public string MensajeDctoFidelizado 
		{
			get { return this._mensajeDctoFidelizado;}
			set { this._mensajeDctoFidelizado = value;}
		}


		/// <summary>
		/// Ruta predeterminada para exportar archivos
		/// </summary>
		public string RutaExportarPredeterminada 
		{
			get { return this._rutaExportarPredeterminada;}
			set { this._rutaExportarPredeterminada = value;}
		}

		/// <summary>
		/// Ruta predeterminada para importar archivos
		/// </summary>
		public string RutaImportarPredeterminada 
		{
			get { return this._rutaImportarPredeterminada;}
			set { this._rutaImportarPredeterminada = value;}
		}

		
		/// <summary>
		/// Codigo alterno de la estacion
		/// </summary>
		public string CodigoAlternoEstacion 
		{
			get { return this._codigoAlternoEstacion;}
			set { this._codigoAlternoEstacion = value;}
		}


		/// <summary>
		/// Establece la generacion automatica para el plano de vetas Credito y Contado
		/// </summary>
		public bool PlanoVentasCreditoContado 
		{
			get { return this._planoVentasCreditoContado;}
			set { this._planoVentasCreditoContado = value;}
		}



		/// <summary>
		/// Establece si utiliza conexion con oracle
		/// </summary>
		public bool ConexionOracle 
		{
			get { return this._conexionOracle;}
			set { this._conexionOracle = value;}
		}

		/// <summary>
		/// Establece la generacion automatica para el plano de ventas para sap
		/// </summary>
		public bool GenerarPlanoVentaSap 
		{
			get { return this._generarPlanoVentaSap;}
			set { this._generarPlanoVentaSap = value;}
		}
		/// <summary>
		/// Establece la generacion automatica para el plano de traslados para sap
		/// </summary>
		public bool GenerarPlanoTrasladoSap 
		{
			get { return this._generarPlanoTrasladoSap;}
			set { this._generarPlanoTrasladoSap = value;}
		}

		/// <summary>
		/// Establece la generacion automatica para el plano de lecturas para sap
		/// </summary>
		public bool GenerarPlanoLecturaSap
		{
			get { return this._generarPlanoLecturaSap;}
			set { this._generarPlanoLecturaSap = value;}
		}		

		/// <summary>
		/// Establece la generacion automatica para el plano de reporte de ventas
		/// </summary>
		public bool GenerarPlanoReporte 
		{
			get { return this._generarPlanoReporte;}
			set { this._generarPlanoReporte = value;}
		}
		/// <summary>
		/// Establece la generacion automatica para el plano de total electronico o de lecturas
		/// </summary>
		public bool GenerarPlanoTotalElectronico 
		{
			get { return this._generarPlanoTotalElectronico;}
			set { this._generarPlanoTotalElectronico = value;}
		}
		/// <summary>
		/// Establece la generacion automatica para el plano de mapa
		/// </summary>
		public bool GenerarPlanoMapa 
		{
			get { return this._generarPlanoMapa;}
			set { this._generarPlanoMapa = value;}
		}
		/// <summary>
		/// Establece la generacion automatica para el plano de cuentas
		/// </summary>
		public bool GenerarPlanoCuenta 
		{
			get { return this._generarPlanoCuenta;}
			set { this._generarPlanoCuenta = value;}
		}
		/// <summary>
		/// Establece la generacion automatica para el plano de precios de productos
		/// </summary>
		public bool GenerarPlanoPrecio 
		{
			get { return this._generarPlanoPrecio;}
			set { this._generarPlanoPrecio = value;}
		}
		/// <summary>
		/// Establece si guardara estacion las tramas de surtidores en un log
		/// </summary>
		public bool DebugTramasSurtidores 
		{
			get { return this._debugTramasSurtidores;}
			set { this._debugTramasSurtidores = value;}
		}

		/// <summary>
		/// Establece el separador predeterminado de archivos planos
		/// </summary>
		public string SeparadorPlanosPredeterminado 
		{
			get { return this._separadorPlanosPredeterminado;}
			set { this._separadorPlanosPredeterminado = value;}
		}

		/// <summary>
		/// Toma lecturas por venta
		/// </summary>
		public bool LecturasPorVenta 
		{
			get { return this._lecturasPorVenta;}
			set { this._lecturasPorVenta = value;}
		}

		/// <summary>
		/// Define el intervalo en milisegundos de intentos de envio hacia estacion
		/// </summary>
		public int IntervaloAEstacion 
		{
			get { return this._intervaloAEstacion;}
			set { this._intervaloAEstacion = value;}
		}

		/// <summary>
		/// Define el intervalo en milisegundos de intentos de envio hacia el capturador
		/// </summary>
		public int IntervaloACapturador 
		{
			get { return this._intervaloACapturador;}
			set { this._intervaloACapturador = value;}
		}

		/// <summary>
		/// Define el numero de intentos hacia estacion
		/// </summary>
		public Int16 IntentosAEstacion 
		{
			get { return this._intentosAEstacion;}
			set { this._intentosAEstacion = value;}
		}

		/// <summary>
		/// Define el numero de intentos hacia el capturados
		/// </summary>
		public Int16 IntentosACapturador 
		{
			get { return this._intentosACapturador;}
			set { this._intentosACapturador = value;}
		}


		/// <summary>
		/// Define si utiliza servidor de capturadores o no
		/// </summary>
		public bool UtilizaServidorCapturadores 
		{
			get { return this._utilizaServidorCapturadores;}
			set { this._utilizaServidorCapturadores = value;}
		}

		
		/// <summary>
		/// Define el puerto por el cual se conectaran los capturadores virtuales al servidor de capturadores
		/// </summary>
		public int PuertoServidorCapturadores 
		{
			get { return this._puertoServidorCapturadores;}
			set { this._puertoServidorCapturadores = value;}
		}

		/// <summary>
		/// Define el tipo de autorizacion que realizará el surtidor; 1:Mangera, 2:Cara
		/// </summary>
		public Int16 TipoAutorizacion 
		{
			get { return this._tipoAutorizacion;}
			set { this._tipoAutorizacion = value;}
		}

		/// <summary>
		/// Define si imprimira un mensaje adicional o no
		/// </summary>
		public bool ImprimirMensajeAdicional 
		{
			get { return this._imprimirMensajeAdicional;}
			set { this._imprimirMensajeAdicional = value;}
		}

		/// <summary>
		/// Define si un mensaje adicional para ser impreso
		/// </summary>
		public string MensajeAdicional 
		{
			get { return this._mensajeAdicional;}
			set { this._mensajeAdicional = value;}
		}

		/// <summary>
		/// Define si un mensaje adicional para ser impreso
		/// </summary>
		public decimal MensajeAdicionalMayoresA 
		{
			get { return this._mensajeAdicionalMayoresA;}
			set { this._mensajeAdicionalMayoresA = value;}
		}

		/// <summary>
		/// Define si activa la impresion de tiquetes con clave
		/// </summary>
		public bool SeguridadImpresion 
		{
			get { return this._seguridadImpresion;}
			set { this._seguridadImpresion = value;}
		}


		/// <summary>
		/// Define la clave de impresion
		/// </summary>
		public string ClaveImpresion 
		{
			get { return this._claveImpresion;}
			set { this._claveImpresion = value;}
		}

		/// <summary>
		/// Define el tiempo para imprimir un tiquete
		/// </summary>
		public byte TiempoSeguridadImpresion 
		{
			get { return this._tiempoSeguridadImpresion;}
			set { this._tiempoSeguridadImpresion = value;}
		}		

		/// <summary>
		/// Define si se genera o no el plano de inventarios
		/// </summary>
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez
		public bool GenerarPlanoInventario 
		{
			get { return this._generarPlanoInventario;}
			set { this._generarPlanoInventario = value;}
		}

		/// <summary>
		/// Define si se genera o no el plano de lecturas
		/// </summary>
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  11/02/2009 a.m.
		/// Autor:  Rodrigo Figueroa Rivera
		public bool GenerarPlanoLecturas
		{
			get { return this._generarPlanoLecturas;}
			set { this._generarPlanoLecturas = value;}
		}

		/// <summary>
		/// Define si se genera o no el plano de ventas
		/// </summary>
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez
		public bool GenerarPlanoventas
		{
			get { return this._generarPlanoVentas;}
			set { this._generarPlanoVentas = value;}
		}

		/// <summary>
		/// Define si se genera o no el plano de ventas
		/// </summary>
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez
		public string DirPlanoLecturas 
		{
			get { return this._dirPlanoLecturas;}
			set { this._dirPlanoLecturas = value;}
		}

		/// <summary>
		/// Define si se genera o no el plano de ventas
		/// </summary>
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez
		public string DirPlanoVentas
		{
			get { return this._dirPlanoVentas;}
			set { this._dirPlanoVentas = value;}
		}


		/// <summary>
		/// Define si se configura el tiquete venta
		/// </summary>
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  16/04/2009 11:56 a.m.
		/// Autor:  Rodrigo Figueroa
		public bool TiqueteVentaConfigurable
		{
			get { return this._tiqueteVentaConfigurable;}
			set { this._tiqueteVentaConfigurable = value;}

		}

        /// <summary>
        /// 
        /// </summary>
        public string UrlWebServiceCI
        {
            get 
            {
                return this._urlWebServiceCI;
            }
            set
            {
                this._urlWebServiceCI = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ClaveDescargaCI
        {
            get
            {
                return this._claveDescargaCI;
            }
            set
            {
                this._claveDescargaCI = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UsuarioCI
        {
            get
            {
                return this._usuarioCI;
            }
            set
            {
                this._usuarioCI = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DiasActualizacionCI
        {
            get
            {
                return this._diasActualizacionCI;
            }
            set
            {
                this._diasActualizacionCI = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TiempoEncuestaCI
        {
            get
            {
                return this._tiempoEncuestaCI;
            }
            set
            {
                this._tiempoEncuestaCI = value;
            }
        }


        public int DiasAvisoVencimientoCanastilla
        {
            get
            {
                return this._diasAvisoVencimientoCanastilla;
            }
            set
            {
                this._diasAvisoVencimientoCanastilla = value;
            }
        }

        public int FacturasAvisoVencimientoCanastilla
        {
            get
            {
                return this._facturasAvisoVencimientoCanastilla;
            }
            set
            {
                this._facturasAvisoVencimientoCanastilla = value;
            }
        }

        /// <summary>
        /// Autorizacion Conductor
        /// </summary>
        public string AutorizacionConductor
        {
            get
            {
                return this._autorizacionConductor;
            }
            set
            {
                this._autorizacionConductor = value;
            }
        }

        /// <summary>
        /// Si maneja interfaz con inventario
        /// </summary>
        public bool DescargueInventario
        {
            get { return this._descargueInventario; }
            set { this._descargueInventario = value; }
        }
		
        /// <summary>
        /// Si maneja interfaz con inventario
        /// </summary>
        public bool ZetaAutomatico
        {
            get { return this._zetaAutomatico; }
            set { this._zetaAutomatico = value; }
        }
		
        /// <summary>
        /// Tipo Autorizacion Externa
        /// </summary>
        public byte IdTipoAutorizacionExterna
        {
            get { return this._idTipoAutizacionExterna; }
            set { this._idTipoAutizacionExterna = value; }
        }
		#endregion
		#region Modify
		/// <summary>
		/// Permite Modificar Dat_Gene
		/// </summary>
		/// Modificacion: Se adiciono el campo GenerarPlanoInventario para definir si se genera el plano de inventarios
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez		

		public void Modificar () 
		{
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("Dat_GeneModification");
			sql.ParametersNumber = 93;
			sql.AddParameter("@COD_COMP", SqlDbType.Int, this._cod_Comp);
			sql.AddParameter("@COD_GRU", SqlDbType.Int, this._cod_Gru);
			sql.AddParameter("@COD_EST", SqlDbType.Int, this._cod_Est);
			sql.AddParameter("@RAZON_SOCIAL", SqlDbType.VarChar, this._razon_Social);
			sql.AddParameter("@TIPO_NIT", SqlDbType.VarChar, this._tipo_Nit);
			sql.AddParameter("@NIT", SqlDbType.VarChar, this._nit);
			sql.AddParameter("@NIT_DIVE", SqlDbType.VarChar, this._nit_Dive);
			sql.AddParameter("@DIRECCION", SqlDbType.VarChar, this._direccion);
			sql.AddParameter("@TELEFONO", SqlDbType.VarChar, this._telefono);
			sql.AddParameter("@CIUDAD", SqlDbType.VarChar, this._ciudad);
			sql.AddParameter("@SLOGAN", SqlDbType.VarChar, this._slogan);
			sql.AddParameter("@IMP_FACTURA", SqlDbType.VarChar, (this._imp_Factura == "Tiquete"?"T":"F"));
//			sql.AddParameter("@REGIMEN", SqlDbType.VarChar, (this._regimen == "Comun"?"C":"S"));
//			sql.AddParameter("@RESOLUCION_FACT", SqlDbType.VarChar, this._resolucion_Fact);
//			sql.AddParameter("@RESOLUCION_AUTO", SqlDbType.VarChar, this._resolucion_Auto);
//			sql.AddParameter("@RESOLUCION_CONT", SqlDbType.VarChar, this._resolucion_Cont);
//			sql.AddParameter("@CONS_INIFACT", SqlDbType.Int, this._cons_IniFact);
//			sql.AddParameter("@CONS_ACTUAL", SqlDbType.Int, this._cons_Actual);
			sql.AddParameter("@LIMPIAR_DISPLAY", SqlDbType.Bit, this._limpiar_display);
			sql.AddParameter("@VENTAS_PRE", SqlDbType.Bit, this._ventas_Pre);
			sql.AddParameter("@CAPTURADOR_PANTALLA", SqlDbType.Bit, this._capturador_Pantalla);
			sql.AddParameter("@CONTROL_MANT", SqlDbType.Bit, this._control_Mant);
			sql.AddParameter("@VR_BOLSA", SqlDbType.Decimal, this._vr_Bolsa);
			sql.AddParameter("@VER_SUBCLASES ", SqlDbType.Bit, this._ver_Subclases);
			sql.AddParameter("@RECAUDO", SqlDbType.Bit, this._recuado);
            sql.AddParameter("@SUIC_VER", SqlDbType.VarChar, (this._suic_Ver == "Si" ? "S" : (this._suic_Ver == "No" ? "N" : this._suic_Ver == "NTC4829" ? "T" : "E")));
			sql.AddParameter("@COD_SUC", SqlDbType.Int, this._cod_Suc);
			sql.AddParameter("@TIPOCC", SqlDbType.Int, (this._tipoCc == "TPS"?0:1) );
			sql.AddParameter("@ACTIVA", SqlDbType.Bit, this._activa);
			sql.AddParameter("@DESCUENTO", SqlDbType.Decimal, this._descuento);
			sql.AddParameter("@DCTO_FEC_INI", SqlDbType.VarChar, this._fecIniDesc.ToString("yyyyMMdd"));
			sql.AddParameter("@DCTO_FEC_FIN", SqlDbType.VarChar, this._fecFinDesc.ToString("yyyyMMdd"));
			sql.AddParameter("@DCTO_HOR_INI", SqlDbType.DateTime, this._horaIniDesc);
			sql.AddParameter("@DCTO_HOR_FIN", SqlDbType.DateTime, this._horaFinDesc);
			sql.AddParameter("@SOLI_LECT", SqlDbType.Bit, this._soli_Lect);
			sql.AddParameter("@CLAVECPA", SqlDbType.VarChar, this._claveCPA);
			sql.AddParameter("@TIPOGAS", SqlDbType.VarChar, (this._tipoGas == "Gasolina"?"0":this._tipoGas == "Gas"?"1":"2"));
			sql.AddParameter("@FIDELIZADO", SqlDbType.Bit, this._fidelizado);
			sql.AddParameter("@IdNumOrden", SqlDbType.Int, this._idNumOrden);
			sql.AddParameter("@DCTO_RECAUDO", SqlDbType.VarChar, (this._dcto_recaudo==true?"1":"0"));
			sql.AddParameter("@dctoFidelizado", SqlDbType.TinyInt, this._dctoFidelizado);
			sql.AddParameter("@idPais", SqlDbType.Int, this._idPais);
			sql.AddParameter("@Sap", SqlDbType.Int, this._sap); 
			sql.AddParameter("@JornadaZeta", SqlDbType.Char, this._jornadaZeta);
			sql.AddParameter("@Mr_Socket_Activo", SqlDbType.Char, this._mr_Socket_Activo);
			sql.AddParameter("@Mr_Socket_Local_Puerto", SqlDbType.Int, this._mr_Socket_Local_Puerto);		
			sql.AddParameter("@Mr_Socket_Local_Address", SqlDbType.VarChar, this._mr_Socket_Local_Address);
			sql.AddParameter("@ManejaDebug", SqlDbType.TinyInt, this._manejaDebug);
			sql.AddParameter("@IpControlTanques", SqlDbType.VarChar, this._ipControlTanques);
			sql.AddParameter("@PeriodoVariacionTanque", SqlDbType.VarChar, this._periodoVariacionTanque);
			sql.AddParameter("@RutaPlanoVentasPendientes", SqlDbType.VarChar, this._rutaPlanoVentasPendientes);
			sql.AddParameter("@RutaPlanoVentasProcesadas", SqlDbType.VarChar, this._rutaPlanoVentasProcesadas);
			sql.AddParameter("@MensajeDctoFidelizado", SqlDbType.VarChar, this._mensajeDctoFidelizado);
			sql.AddParameter("@RutaExportarPredeterminada", SqlDbType.VarChar, this._rutaExportarPredeterminada);
			sql.AddParameter("@CodigoAlternoEstacion", SqlDbType.VarChar, this._codigoAlternoEstacion);
			sql.AddParameter("@PlanoVentasCreditoContado", SqlDbType.TinyInt, this._planoVentasCreditoContado);
			sql.AddParameter("@ConexionOracle", SqlDbType.TinyInt, this.ConexionOracle);
			sql.AddParameter("@GenerarPlanoVentaSap", SqlDbType.TinyInt, this._generarPlanoVentaSap);
			sql.AddParameter("@GenerarPlanoTrasladoSap", SqlDbType.TinyInt, this._generarPlanoTrasladoSap);
			sql.AddParameter("@GenerarPlanoLecturaSap", SqlDbType.TinyInt, this._generarPlanoLecturaSap);
			sql.AddParameter("@GenerarPlanoReporte", SqlDbType.TinyInt, this._generarPlanoReporte);
			sql.AddParameter("@GenerarPlanoTotalElectronico", SqlDbType.TinyInt, this._generarPlanoTotalElectronico);
			sql.AddParameter("@GenerarPlanoMapa", SqlDbType.TinyInt, this._generarPlanoMapa);
			sql.AddParameter("@GenerarPlanoCuenta", SqlDbType.TinyInt, this._generarPlanoCuenta);
			sql.AddParameter("@GenerarPlanoPrecio", SqlDbType.TinyInt, this._generarPlanoPrecio);
			sql.AddParameter("@RutaImportarPredeterminada", SqlDbType.VarChar, this._rutaImportarPredeterminada);
			sql.AddParameter("@DebugTramasSurtidores", SqlDbType.TinyInt, this._debugTramasSurtidores);
			sql.AddParameter("@separadorPlanosPredeterminado", SqlDbType.VarChar, this._separadorPlanosPredeterminado);
            sql.AddParameter("@PREF_FACT", SqlDbType.VarChar, this._pref_Fact);
			sql.AddParameter("@LecturasPorVenta", SqlDbType.TinyInt, this._lecturasPorVenta);
			sql.AddParameter("@IntentosAEstacion", SqlDbType.SmallInt, this._intentosAEstacion);
			sql.AddParameter("@IntentosACapturador", SqlDbType.SmallInt, this._intentosACapturador);
			sql.AddParameter("@IntervaloACapturador", SqlDbType.Int, this._intervaloACapturador);
			sql.AddParameter("@IntervaloAEstacion", SqlDbType.Int, this._intervaloAEstacion);
			sql.AddParameter("@UtilizaServidorCapturadores", SqlDbType.Bit, this._utilizaServidorCapturadores);
			sql.AddParameter("@PuertoServidorCapturadores", SqlDbType.Int, this._puertoServidorCapturadores);
			sql.AddParameter("@TipoAutorizacion", SqlDbType.SmallInt, this._tipoAutorizacion);			
			sql.AddParameter("@ImprimirMensajeAdicional", SqlDbType.Bit, this._imprimirMensajeAdicional);
			sql.AddParameter("@MensajeAdicional", SqlDbType.VarChar, this._mensajeAdicional);
			sql.AddParameter("@MensajeAdicionalMayoresA", SqlDbType.Decimal, this._mensajeAdicionalMayoresA);
			sql.AddParameter("@SeguridadImpresion", SqlDbType.Bit, this._seguridadImpresion);
			sql.AddParameter("@ClaveImpresion", SqlDbType.VarChar, this._claveImpresion);
			sql.AddParameter("@TiempoSeguridadImpresion", SqlDbType.TinyInt, this._tiempoSeguridadImpresion);
            //sql.AddParameter("@GenerarPlanoInventario", SqlDbType.TinyInt, this._generarPlanoInventario);			
            sql.AddParameter("@GenerarPlanoLecturas", SqlDbType.TinyInt, this._generarPlanoLecturas);
            sql.AddParameter("@GenerarPlanoVentas", SqlDbType.TinyInt, this._generarPlanoVentas);
            sql.AddParameter("@DirPlanoLecturas", SqlDbType.VarChar, this._dirPlanoLecturas);
            sql.AddParameter("@DirPlanoVentas", SqlDbType.VarChar, this._dirPlanoVentas);
            //sql.AddParameter("@TiqueteVentaConfigurable", SqlDbType.Bit, this._tiqueteVentaConfigurable );
            //sql.AddParameter("@UrlWebServiceCI" , SqlDbType.VarChar, this._urlWebServiceCI );
            //sql.AddParameter("@ClaveDescargaCI", SqlDbType.VarChar, this._claveDescargaCI);
            //sql.AddParameter("@UsuarioCI", SqlDbType.VarChar, this._usuarioCI);
            //sql.AddParameter("@diasActualizacionCI", SqlDbType.VarChar, this._diasActualizacionCI);
            //sql.AddParameter("@TiempoEncuestaCI", SqlDbType.VarChar, this._tiempoEncuestaCI);
            //sql.AddParameter("@DiasAvisoVencimientoCanastilla", SqlDbType.Int , this._diasAvisoVencimientoCanastilla);
            //sql.AddParameter("@FacturasAvisoVencimientoCanastilla", SqlDbType.Int , this._facturasAvisoVencimientoCanastilla);
            //sql.AddParameter("@AutorizacionConductor", SqlDbType.VarChar, this._autorizacionConductor);
            sql.AddParameter("@DescargueInventario", SqlDbType.TinyInt, this._descargueInventario);
            sql.AddParameter("@ZetaAutomatico", SqlDbType.TinyInt, this._zetaAutomatico);
            sql.AddParameter("@IdTipoAutorizacionExterna", SqlDbType.Int, this._idTipoAutizacionExterna);
			#endregion 
 
			#region Execute Sql command
			try 
			{
                
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion
	}
}
