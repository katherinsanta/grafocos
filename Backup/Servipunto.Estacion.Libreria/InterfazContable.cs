using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Summary description for InterfazContable.
	/// </summary>
	public class InterfazContable
	{
		#region Sección de Declaracionse
		private int		_idInterfaz;
		private bool	_ntAbono, _ntDescuento, _ntIva, _ntVentasGNV, _ntVentasCanas;
		private string	_codCentroCostos, _codSucursal;
		private string	_ncAbono, _ncDescuento, _ncIva, _numCompFacturas, _ncVentasGNV, _ncVentasCanas;
		private string	_clasedePedido_Sap,_organizaciondeVentas_Sap,_canal_Sap,_sector_Sap,_oficinadeVentas_Sap,_grupodeVendedores_Sap,_asignacion_Sap,_cod_Cli_Contado_Sap,_Puesto_Exp_Sap;
		private string	_clase_Doc_Sap,_sociedad_Sap,_tipo_Mon_Sap;
		private string _rutaImportarSap; 
		private string _rutaExportarSap;
		private bool	_natAbono, _natDescuento, _natIva, _natVentasGNV, _natVentasCanas;
		private string _rutaImportarClientesCorporativos;
		private string _codigoEstacionSap;
		#endregion

		#region Definición de Constructor y Destructor
		/// <summary>
		/// Constructora por defecto
		/// </summary>
		public InterfazContable()
		{ }
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Define el IdInterfaz dado que este se convierte en llave primaria de la tabla, tambien se define para futuras aplicaciones
		/// de estas funcionalidades
		/// </summary>
		public int IDInterfaz
		{
			get { return this._idInterfaz;}
			set { this._idInterfaz = value;}
		}
		
		/// <summary>
		/// Define el Número de Cuenta del Abono par la generación del archivo plano
		/// </summary>
		public string NCAbono
		{
			get { return this._ncAbono;}
			set { this._ncAbono = value;}
		}
		/// <summary>
		/// Define la naturaleza de la Cuenta Abono para la generación del archivo plano
		/// </summary>
		public bool NATAbono
		{
			get { return this._natAbono;}
			set { this._natAbono = value;}
		}
		/// <summary>
		/// Define el número de Nit del Tercero para la generación del archivo plano
		/// </summary>
		public bool NTAbono
		{
			get { return this._ntAbono;}
			set { this._ntAbono = value;}
		}
		/// <summary>
		/// Define el Número de Cuenta del Descuento para la generación del archivo plano
		/// </summary>
		public string NCDescuento
		{
			get { return this._ncDescuento;}
			set { this._ncDescuento = value;}
		}
		/// <summary>
		/// Define la naturaleza de la cuenta de Descuentos para la generación del archivo plano
		/// </summary>
		public bool NATDescuento
		{
			get { return this._natDescuento;}
			set { this._natDescuento = value;}
		}
		/// <summary>
		/// Define el número de Nit del tercero para la cuenta Abono
		/// </summary>
		public bool NTDescuento
		{
			get { return this._ntDescuento;}
			set { this._ntDescuento = value;}
		}
		/// <summary>
		/// Define el Número de cuenta que va a manejar el IVA
		/// </summary>
		public string NCIva
		{
			get { return this._ncIva;}
			set { this._ncIva = value;}
		}
		/// <summary>
		/// Define la Naturaleza de la cuenta de Iva
		/// </summary>
		public bool NATIva
		{
			get { return this._natIva;}
			set { this._natIva = value;}
		}
		/// <summary>
		/// Define el número de Nit del tercero definido para el Iva
		/// </summary>
		public bool NTIva
		{
			get { return this._ntIva;}
			set { this._ntIva = value;}
		}
		/// <summary>
		/// Define el Código de Centro de Costos para la generación del archivo plano
		/// </summary>
		public string CODCentroCostos
		{
			get { return this._codCentroCostos;}
			set { this._codCentroCostos = value;}
		}
		/// <summary>
		/// Define el Número de Comprobante de Facturas par la generación del Archivo plano
		/// </summary>
		public string NUMCompFacturas
		{
			get { return this._numCompFacturas;}
			set { this._numCompFacturas = value;}
		}
		/// <summary>
		/// Define el Código de Sucursal para la generación del Archivo Plano
		/// </summary>
		public string CODSucursal
		{
			get { return this._codSucursal;}
			set { this._codSucursal = value;}
		}
		/// <summary>
		/// Define el Número de Cuenta de las ventas de GNV para la generación del archivo plano
		/// </summary>
		public string NCVentasGNV
		{
			get { return this._ncVentasGNV;}
			set { this._ncVentasGNV = value;}
		}
		/// <summary>
		/// Define la naturaleza de la cuenta Ventas de GNV para la generación del archivo plano
		/// </summary>
		public bool NATVentasGNV
		{
			get { return this._natVentasGNV;}
			set { this._natVentasGNV = value;}
		}
		/// <summary>
		/// Define si la cuenta de Ventas GNV maneja terceros
		/// </summary>
		public bool NTVentasGNV
		{
			get { return this._ntVentasGNV;}
			set { this._ntVentasGNV = value;}
		}
		/// <summary>
		/// Define el Número de Cuenta de las ventas de Canastilla para la generación del archivo plano
		/// </summary>
		public string NCVentasCanas
		{
			get { return this._ncVentasCanas;}
			set { this._ncVentasCanas = value;}
		}
		/// <summary>
		/// Define la naturaleza de la cuenta Ventas de Canastilla para la generación del archivo plano
		/// </summary>
		public bool NATVentasCanas
		{
			get { return this._natVentasCanas;}
			set { this._natVentasCanas = value;}
		}
		/// <summary>
		/// Define si la cuenta de Ventas de Canastilla maneja terceros
		/// </summary>
		public bool NTVentasCanas
		{
			get { return this._ntVentasCanas;}
			set { this._ntVentasCanas = value;}
		}

		/// <summary>
		/// Define la clase de pedido para SAP
		/// </summary>
		public string ClasedePedido_Sap
		{
			get { return this._clasedePedido_Sap;}
			set { this._clasedePedido_Sap = value;}
		}

		/// <summary>
		/// Define la organización de ventas para SAP
		/// </summary>
		public string OrganizaciondeVentas_Sap
		{
			get { return this._organizaciondeVentas_Sap;}
			set { this._organizaciondeVentas_Sap = value;}
		}

		/// <summary>
		/// Define la organización de canal para SAP
		/// </summary>
		public string Canal_Sap
		{
			get { return this._canal_Sap;}
			set { this._canal_Sap = value;}
		}

		/// <summary>
		/// Define el sector para SAP
		/// </summary>
		public string Sector_Sap
		{
			get { return this._sector_Sap;}
			set { this._sector_Sap = value;}
		}

		/// <summary>
		/// Define la oficina de ventas para SAP
		/// </summary>
		public string OficinadeVentas_Sap
		{
			get { return this._oficinadeVentas_Sap;}
			set { this._oficinadeVentas_Sap = value;}
		}

		/// <summary>
		/// Define el grupo de vendedores para SAP
		/// </summary>
		public string GrupodeVendedores_Sap
		{
			get { return this._grupodeVendedores_Sap;}
			set { this._grupodeVendedores_Sap = value;}
		}

		/// <summary>
		/// Define la asignación para SAP
		/// </summary>
		public string Asignacion_Sap
		{
			get { return this._asignacion_Sap;}
			set { this._asignacion_Sap = value;}
		}

		/// <summary>
		/// Define el codigo del cliente para ventas de contado de SAP
		/// </summary>
		public string Cod_Cli_Contado_Sap
		{
			get { return this._cod_Cli_Contado_Sap;}
			set { this._cod_Cli_Contado_Sap = value;}
		}


		/// <summary>
		/// Define el puesto de expedición
		/// </summary>
		public string Puesto_Exp_Sap
		{
			get { return this._Puesto_Exp_Sap;}
			set { this._Puesto_Exp_Sap = value;}
		}
		

		/// <summary>
		/// Define la clase de documento
		/// </summary>
		public string Clase_Doc_Sap
		{
			get { return this._clase_Doc_Sap;}
			set { this._clase_Doc_Sap = value;}
		}
				
		/// <summary>
		/// Define la Sociedad
		/// </summary>
		public string Sociedad_Sap
		{
			get { return this._sociedad_Sap;}
			set { this._sociedad_Sap = value;}
		}

		/// <summary>
		/// Define el tipo de moneda
		/// </summary>
		public string Tipo_Moneda_Sap
		{
			get { return this._tipo_Mon_Sap;}
			set { this._tipo_Mon_Sap = value;}
		}


		/// <summary>
		/// Define la ruta donde se importaran los archivos planos provenientes de sap
		/// </summary>
		public string RutaImportarSap
		{
			get { return this._rutaImportarSap;}
			set { this._rutaImportarSap = value;}
		}

		/// <summary>
		/// Define la ruta donde se exportaran los archivos planos provenientes de sap
		/// </summary>
		public string RutaExportarSap
		{
			get { return this._rutaExportarSap;}
			set { this._rutaExportarSap = value;}
		}

		/// <summary>
		/// Define la ruta donde se importarán los archivos planos provenientes de clientes corporativos
		/// </summary>
		public string RutaImportarClientesCorporativos
		{
			get { return this._rutaImportarClientesCorporativos;}
			set { this._rutaImportarClientesCorporativos = value;}
		}

		/// <summary>
		/// Define el codigo de la estacion
		/// </summary>
		public string CodigoEstacionSap
		{
			get { return this._codigoEstacionSap;}
			set { this._codigoEstacionSap = value;}
		}

		
		#endregion

		#region Método Modificar
		/// <summary>
		/// Método que se encarga de modificar determinado registro en la tabla InterfazContable
		/// </summary>
		public void Modificar()
		{
			#region Prepara Estamento SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ModificarIContable");
			sql.ParametersNumber = 35;
			sql.AddParameter("@IDINTERFAZ", SqlDbType.Int, this._idInterfaz);
			sql.AddParameter("@NCABONO", SqlDbType.VarChar, this._ncAbono);
			sql.AddParameter("@NATABONO", SqlDbType.Bit, this._natAbono);
			sql.AddParameter("@NTABONO", SqlDbType.Bit, this._ntAbono);
			sql.AddParameter("@NCDESCUENTO", SqlDbType.VarChar, this._ncDescuento);
			sql.AddParameter("@NATDESCUENTO", SqlDbType.Bit, this._natDescuento);
			sql.AddParameter("@NTDESCUENTO", SqlDbType.Bit, this._ntDescuento);
			sql.AddParameter("@NCIVA", SqlDbType.VarChar, this._ncIva);
			sql.AddParameter("@NATIVA", SqlDbType.Bit, this._natIva);
			sql.AddParameter("@NTIVA", SqlDbType.Bit, this._ntIva);
			sql.AddParameter("@CODCENTROCOSTOS", SqlDbType.VarChar, this._codCentroCostos);
			sql.AddParameter("@NUMCOMPFACTURAS", SqlDbType.VarChar, this._numCompFacturas);
			sql.AddParameter("@CODSUCURSAL", SqlDbType.VarChar, this._codSucursal);
			sql.AddParameter("@NCVENTASGNV", SqlDbType.VarChar, this._ncVentasGNV);
			sql.AddParameter("@NATVENTASGNV", SqlDbType.Bit, this._natVentasGNV);
			sql.AddParameter("@NTVENTASGNV", SqlDbType.Bit, this._ntVentasGNV);
			sql.AddParameter("@NCVENTASCANAS", SqlDbType.VarChar, this._ncVentasCanas);
			sql.AddParameter("@NATVENTASCANAS", SqlDbType.Bit, this._natVentasCanas);
			sql.AddParameter("@NTVENTASCANAS", SqlDbType.Bit, this._ntVentasCanas);
			
			//Modificado:	Ing. Elvis Astaiza
			//Fecha:		03-09-2007
			//Parametros para SAP
			sql.AddParameter("@ClasedePedido_Sap", SqlDbType.VarChar, this._clasedePedido_Sap);
			sql.AddParameter("@OrganizaciondeVentas_Sap", SqlDbType.VarChar, this._organizaciondeVentas_Sap);
			sql.AddParameter("@Canal_Sap", SqlDbType.VarChar, this._canal_Sap);
			sql.AddParameter("@Sector_Sap", SqlDbType.VarChar, this._sector_Sap);
			sql.AddParameter("@OficinadeVentas_Sap", SqlDbType.VarChar, this._oficinadeVentas_Sap);
			sql.AddParameter("@GrupodeVendedores_Sap", SqlDbType.VarChar, this._grupodeVendedores_Sap);
			sql.AddParameter("@Asignacion_Sap", SqlDbType.VarChar, this._asignacion_Sap);
			sql.AddParameter("@Cod_Cli_Contado_Sap", SqlDbType.VarChar, this._cod_Cli_Contado_Sap);
			sql.AddParameter("@Puesto_Exp_Sap", SqlDbType.VarChar, this._Puesto_Exp_Sap);
			sql.AddParameter("@Clase_Doc_Sap", SqlDbType.VarChar, this._clase_Doc_Sap);
			sql.AddParameter("@Sociedad_Sap", SqlDbType.VarChar, this._sociedad_Sap);
			sql.AddParameter("@Tipo_Mon_Sap", SqlDbType.VarChar, this._tipo_Mon_Sap);
			sql.AddParameter("@RutaImportarSap", SqlDbType.VarChar, this._rutaImportarSap);
			sql.AddParameter("@RutaExportarSap", SqlDbType.VarChar, this._rutaExportarSap);

			//otros
			sql.AddParameter("@RutaImportarClientesCorporativos", SqlDbType.VarChar, this._rutaImportarClientesCorporativos);
			sql.AddParameter("@CodigoEstacionSap", SqlDbType.VarChar, this._codigoEstacionSap);

	
			#endregion

			#region Ejecución del Estamento SQL
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally
			{
				sql = null;
			}
			#endregion
		}
		#endregion
	}
}
