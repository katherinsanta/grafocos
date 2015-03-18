using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion {
	/// <summary>
	/// Descripción breve de Datos_Gene.
	/// </summary>
	public class Datos_Gene : Servipunto.Libreria.Collection {
		
		#region Declarations
		private object _cod_Est = null;
		#endregion
		
		#region Constructor/Destructor
		/// <summary>
		/// Muestra el contenido de Datos Generales
		/// </summary>
		/// <param name="Cod_Est">Codigo de la Estacion</param>
		public Datos_Gene(int Cod_Est)	{
			this._cod_Est = Cod_Est;
		}
		/// <summary>
		/// consulta Datos Generales
		/// </summary>
		public Datos_Gene() {}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexa por llave
		/// </summary>
		new public Dat_Gene this [string key] {
			get { return (Dat_Gene)base[key]; }
		}
		/// <summary>
		/// Indexa por Indice 
		/// </summary>
		new public Dat_Gene this [int index] {
			get { return (Dat_Gene)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		/// Modificacion: Se adiciono el campo GenerarPlanoInventario para definir si se genera el plano de inventarios
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez		
		protected override void Load(object sender, EventArgs e) 
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("Dat_GeneQuery");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Cod_Est", SqlDbType.Int, this._cod_Est);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read()) {
				Dat_Gene objDat_Gene = new Dat_Gene();
				objDat_Gene.CodCompania = dr.IsDBNull(0)?(short)0:dr.GetInt16(0);
				objDat_Gene.CodGrupo = dr.IsDBNull(1)?(short)0:dr.GetInt16(1);
				objDat_Gene.CodEstacion = dr.IsDBNull(2)?(short)0:dr.GetInt16(2);
				objDat_Gene.RazonSocial = dr.IsDBNull(3)?"(Sin Definir)":dr.GetString(3).Trim();				
				objDat_Gene.TipoNit = dr.IsDBNull(4)?"(Sin Definir)":dr.GetString(4).Trim();
				objDat_Gene.Nit = dr.IsDBNull(5)?"(Sin Definir)":dr.GetString(5).Trim();
				objDat_Gene.NitDive = dr.IsDBNull(6)?"(Sin Definir)":dr.GetString(6).Trim();
				objDat_Gene.Direccion = dr.IsDBNull(7)?"(Sin Definir)":dr.GetString(7).Trim();
				objDat_Gene.Telefono = dr.IsDBNull(8)?"(Sin Definir)":dr.GetString(8).Trim();
				objDat_Gene.Ciudad = dr.IsDBNull(9)?"(Sin Definir)":dr.GetString(9).Trim();
				objDat_Gene.Slogan = dr.IsDBNull(10)?"(Sin Definir)":dr.GetString(10).Trim();
				objDat_Gene.TiqueteFactura = dr.IsDBNull(11)?"(Sin Definir)":(dr.GetString(11) == "T"?"Tiquete":"Factura");
//				objDat_Gene.Regimen = dr.IsDBNull(12)?"(Sin Definir)":(dr.GetString(12).Trim() == "C"?"Comun":"Simplificado");
//				objDat_Gene.ResolucionFacturacion = dr.IsDBNull(13)?"(Sin Definir)":dr.GetString(13).Trim();
//				objDat_Gene.ResolucionAutoretenedor = dr.IsDBNull(14)?"(Sin Definir)":dr.GetString(14).Trim();
//				objDat_Gene.ResolucionCont = dr.IsDBNull(15)?"(Sin Definir)":dr.GetString(15).Trim();
//				objDat_Gene.ConsecutivoInicial = dr.IsDBNull(17)?(int)0:dr.GetInt32(17);
//				objDat_Gene.ConsecutivoFinal = dr.IsDBNull(18)?(int)0:dr.GetInt32(18);
				objDat_Gene.LimpiarDisplay = dr.IsDBNull(12)?false:Convert.ToBoolean(dr.GetString(12).Trim() == "1"?true:false);
				objDat_Gene.SelfService = dr.IsDBNull(13)?false:Convert.ToBoolean(dr.GetString(13).Trim() == "A"?true:false);
				objDat_Gene.CapturadorEnPantalla = dr.IsDBNull(14)?false:Convert.ToBoolean(dr.GetString(14).Trim() == "A"?true:false);
				objDat_Gene.ControlMantenimiento = dr.IsDBNull(15)?false:Convert.ToBoolean(dr.GetString(15).Trim() == "S"?true:false);
				objDat_Gene.ValorBolsaDinero = dr.IsDBNull(16)?(decimal)0:dr.GetDecimal(16);
				objDat_Gene.ActualizarFormPagGenerador = dr.IsDBNull(17)?false:Convert.ToBoolean(dr.GetString(17).Trim() == "S"?true:false);
				objDat_Gene.CobrarRecaudo = dr.IsDBNull(18)?false:Convert.ToBoolean(dr.GetString(18).Trim() == "S"?true:false);
				objDat_Gene.VersionSuic = dr.IsDBNull(19)?"(Sin Definir)": (dr.GetString(19).Trim() == "S"?"Si":(dr.GetString(19).Trim() == "N"?"No":dr.GetString(19).Trim() == "E"?"Enable":"NTC4829"));
				try
				{
					objDat_Gene.CodigoSucursal = dr.IsDBNull(20)?0:dr.GetInt32(20);
				}
				catch(Exception)
				{
					objDat_Gene.CodigoSucursal = dr.IsDBNull(20)?(Int16)0:dr.GetInt16(20);
				}
				objDat_Gene.TipoCentroComputo = dr.IsDBNull(21)?"(Sin Definir)":(dr.GetByte(21)== 0?"TPS":"SQL");
				objDat_Gene.CrearTarjActivas = dr.IsDBNull(22)?false:Convert.ToBoolean(dr.GetString(22).Trim() == "S"?true:false);
				objDat_Gene.PorcentajeDescuento = dr.IsDBNull(23)?(decimal)0:dr.GetDecimal(23);
				objDat_Gene.FechaInicialDescuento = dr.IsDBNull(24)?new DateTime(1800,1,28):dr.GetDateTime(24);
				objDat_Gene.FechaFinalDescuento = dr.IsDBNull(25)?new DateTime(1800,1,28):dr.GetDateTime(25);
				objDat_Gene.HoraInicialDescuento = dr.IsDBNull(26)?new DateTime(1800,1,28):new DateTime(3000,1,28, int.Parse(dr.GetString(26).Trim().Split(":".ToCharArray())[0]), int.Parse(dr.GetString(26).Trim().Split(":".ToCharArray())[1]),0,0);
				objDat_Gene.HoraFinalDescuento = dr.IsDBNull(27)?new DateTime(1800,1,28):new DateTime(3000,1,28, int.Parse(dr.GetString(27).Trim().Split(":".ToCharArray())[0]), int.Parse(dr.GetString(27).Trim().Split(":".ToCharArray())[1]),0,0);
				objDat_Gene.SolicitaLectsMecanicas = dr.IsDBNull(28)?false:Convert.ToBoolean(dr.GetString(28).Trim() == "S"?true:false);
				objDat_Gene.PasswordCierreXAjuste = dr.IsDBNull(29)?"(Sin Definir)":dr.GetString(29).Trim();
				objDat_Gene.TipoEstacion = dr.IsDBNull(30)?"(Sin Definir)":(dr.GetString(30).Trim() == "0"?"Gasolina":dr.GetString(30).Trim() == "1"?"Gas":"Dual");
				objDat_Gene.EDSFideliza = dr.IsDBNull(31)?false:Convert.ToBoolean(dr.GetString(31).Trim() == "S"?true:false);
				objDat_Gene.IdNumOrden = dr.IsDBNull(32)?(int)0:dr.GetInt32(32);
				objDat_Gene.DctoRecaudo = dr.IsDBNull(33)?false:Convert.ToBoolean(dr.GetString(33).Trim() == "S"?true:false);
				byte valor = dr.IsDBNull(34)?(byte)0:dr.GetByte(34);
				objDat_Gene.DctoFidelizado = valor == (byte)1 ? true : false;
				objDat_Gene.idPais = dr.IsDBNull(35)?(int)0:dr.GetInt32(35);
				objDat_Gene.Sap = dr.IsDBNull(36)?(int)0:int.Parse(dr.GetValue(36).ToString());
				objDat_Gene.JornadaZeta = dr.IsDBNull(37)?"N":dr.GetString(37);
				objDat_Gene.Mr_Socket_Activo = dr.IsDBNull(38)?"N":dr.GetString(38);
				objDat_Gene.Mr_Socket_Local_Puerto = dr.IsDBNull(39)?0:dr.GetInt32(39);
				objDat_Gene.Mr_Socket_Local_Address = dr.IsDBNull(40)?"":dr.GetString(40);
				valor = dr.IsDBNull(41)?(byte)0:dr.GetByte(41);
				objDat_Gene.ManejaDebug = valor == (byte)1 ? true : false; 
				objDat_Gene.IpControlTanques = dr.IsDBNull(42)?"":dr.GetString(42).Trim();
				objDat_Gene.PeriodoVariacionTanque = dr.IsDBNull(43)?"M":dr.GetString(43).Trim();
				objDat_Gene.RutaPlanoVentasPendientes = dr.IsDBNull(44)?"":dr.GetString(44).Trim();
				objDat_Gene.RutaPlanoVentasProcesadas = dr.IsDBNull(45)?"c:\\Servipunto\\Planos\\ParaImportar\\Procesados":dr.GetString(45).Trim();
				objDat_Gene.MensajeDctoFidelizado = dr.IsDBNull(46)?"":dr.GetString(46).Trim();
				objDat_Gene.RutaExportarPredeterminada = dr.IsDBNull(47)?"c:\\Servipunto\\Planos\\Exportado":dr.GetString(47).Trim();
				objDat_Gene.CodigoAlternoEstacion = dr.IsDBNull(48)?"":dr.GetString(48).Trim();
				valor = dr.IsDBNull(49)?(byte)0:dr.GetByte(49);
				objDat_Gene.PlanoVentasCreditoContado = valor == (byte)1 ? true : false; 
				valor = dr.IsDBNull(50)?(byte)0:dr.GetByte(50);
				objDat_Gene.ConexionOracle = valor == (byte)1 ? true : false; 

				valor = dr.IsDBNull(51)?(byte)0:dr.GetByte(51);
				objDat_Gene.GenerarPlanoVentaSap = valor == (byte)1 ? true : false; 
				valor = dr.IsDBNull(52)?(byte)0:dr.GetByte(52);
				objDat_Gene.GenerarPlanoTrasladoSap = valor == (byte)1 ? true : false; 
				valor = dr.IsDBNull(53)?(byte)0:dr.GetByte(53);
				objDat_Gene.GenerarPlanoLecturaSap = valor == (byte)1 ? true : false; 
				valor = dr.IsDBNull(54)?(byte)0:dr.GetByte(54);
				objDat_Gene.GenerarPlanoReporte = valor == (byte)1 ? true : false; 
				valor = dr.IsDBNull(55)?(byte)0:dr.GetByte(55);
				objDat_Gene.GenerarPlanoTotalElectronico = valor == (byte)1 ? true : false; 
				valor = dr.IsDBNull(56)?(byte)0:dr.GetByte(56);
				objDat_Gene.GenerarPlanoMapa = valor == (byte)1 ? true : false; 
				valor = dr.IsDBNull(57)?(byte)0:dr.GetByte(57);
				objDat_Gene.GenerarPlanoCuenta = valor == (byte)1 ? true : false; 
				valor = dr.IsDBNull(58)?(byte)0:dr.GetByte(58);
				objDat_Gene.GenerarPlanoPrecio = valor == (byte)1 ? true : false; 
				objDat_Gene.RutaImportarPredeterminada = dr.IsDBNull(59)?"c:\\Servipunto\\Planos\\ParaImportar":dr.GetString(59).Trim();
				valor = dr.IsDBNull(60)?(byte)0:dr.GetByte(60);
				objDat_Gene.DebugTramasSurtidores = valor == (byte)1 ? true : false; 
				objDat_Gene.SeparadorPlanosPredeterminado = dr.IsDBNull(61)?";":dr.GetString(61).Trim();
				objDat_Gene.PrefijoFactura = dr.IsDBNull(62)?"":dr.GetString(62).Trim();
				valor = dr.IsDBNull(63)?(byte)0:dr.GetByte(63);
				objDat_Gene.LecturasPorVenta = valor == (byte)1 ? true : false; 

				objDat_Gene.IntentosAEstacion = dr.IsDBNull(64)?(short)0:dr.GetInt16(64);
				objDat_Gene.IntentosACapturador = dr.IsDBNull(65)?(short)0:dr.GetInt16(65);
				objDat_Gene.IntervaloACapturador = dr.IsDBNull(66)?0:dr.GetInt32(66);
				objDat_Gene.IntervaloAEstacion = dr.IsDBNull(67)?0:dr.GetInt32(67);				
				objDat_Gene.UtilizaServidorCapturadores = dr.IsDBNull(68)?false:dr.GetBoolean(68);
				objDat_Gene.PuertoServidorCapturadores = dr.IsDBNull(69)?0:dr.GetInt32(69);

				objDat_Gene.TipoAutorizacion = dr.IsDBNull(70)?(short)1:dr.GetInt16(70);
				objDat_Gene.ImprimirMensajeAdicional = dr.IsDBNull(71)?false:dr.GetBoolean(71);
				objDat_Gene.MensajeAdicional = dr.IsDBNull(72)?"":dr.GetString(72).Trim();
				objDat_Gene.MensajeAdicionalMayoresA = dr.IsDBNull(73)?(decimal)0:dr.GetDecimal(73);				
				objDat_Gene.SeguridadImpresion = dr.IsDBNull(74)?false:dr.GetBoolean(74);
				objDat_Gene.ClaveImpresion = dr.IsDBNull(75)?"":dr.GetString(75).Trim();
				objDat_Gene.TiempoSeguridadImpresion = dr.IsDBNull(76)?(byte)0:dr.GetByte(76);
                //valor = dr.IsDBNull(77)?(byte)0:dr.GetByte(77);
                //objDat_Gene.GenerarPlanoInventario = valor == (byte)1 ? true : false;
                //valor = dr.IsDBNull(78)?(byte)0:dr.GetByte(78);
                objDat_Gene.GenerarPlanoLecturas = valor == (byte)1 ? true : false; 				
                //valor = dr.IsDBNull(79)?(byte)0:dr.GetByte(79);
                objDat_Gene.GenerarPlanoventas = valor == (byte)1 ? true : false;
                objDat_Gene.DirPlanoLecturas = dr.IsDBNull(80) ? ";" : dr.GetString(80).Trim();
                objDat_Gene.DirPlanoVentas = dr.IsDBNull(81) ? ";" : dr.GetString(81).Trim();
                //objDat_Gene.TiqueteVentaConfigurable = dr.GetBoolean(82);
                //objDat_Gene.UrlWebServiceCI = dr.IsDBNull(83) ? ";" : dr.GetString(83);
                //objDat_Gene.ClaveDescargaCI = dr.IsDBNull(84) ? ";" : dr.GetString(84);
                //objDat_Gene.UsuarioCI = dr.IsDBNull(85) ? ";" : dr.GetString(85);
                //objDat_Gene.DiasActualizacionCI = dr.IsDBNull(86) ? 1 : dr.GetInt32(86);
                //objDat_Gene.TiempoEncuestaCI = dr.IsDBNull(87) ? 5 : dr.GetInt32(87);
                //objDat_Gene.DiasAvisoVencimientoCanastilla = dr.IsDBNull(88) ? 30 : dr.GetInt32(88);
                //objDat_Gene.FacturasAvisoVencimientoCanastilla = dr.IsDBNull(89) ? 5 : dr.GetInt32(89);
                //objDat_Gene.AutorizacionConductor = dr.IsDBNull(90) ? "N" : dr.GetString(90);
                valor = dr.IsDBNull(91) ? (byte)0 : dr.GetByte(91);
                objDat_Gene.DescargueInventario = valor == (byte)1 ? true : false;
                valor = dr.IsDBNull(92) ? (byte)0 : dr.GetByte(92);
                objDat_Gene.ZetaAutomatico = valor == (byte)1 ? true : false;
                objDat_Gene.IdTipoAutorizacionExterna = dr.IsDBNull(93) ? (byte)0 : dr.GetByte (93);
                
				base.AddItem(objDat_Gene.CodEstacion.ToString(), objDat_Gene);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Permite Configurar Datos Generales.
		/// </summary>
		/// <param name="objDat_Gene">Objeto con la Informacion</param>
		/// Modificacion: Se adiciono el campo GenerarPlanoInventario para definir si se genera el plano de inventarios
		/// Referencia Documental:  Automatizacion > Automatizacion_Plano_Transaccion_Inventario_GA_CUS_CPR
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez		
		public static void Adicionar (Dat_Gene objDat_Gene)
		{

			#region Prepare Sql

			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("Dat_GeneInsertion");
			sql.ParametersNumber = 88;
			sql.AddParameter("@COD_COMP", SqlDbType.Int, objDat_Gene.CodCompania);
			sql.AddParameter("@COD_GRU", SqlDbType.Int, objDat_Gene.CodGrupo);
			sql.AddParameter("@COD_EST", SqlDbType.Int, objDat_Gene.CodEstacion);
			sql.AddParameter("@RAZON_SOCIAL", SqlDbType.VarChar, objDat_Gene.RazonSocial);
			sql.AddParameter("@TIPO_NIT", SqlDbType.VarChar, objDat_Gene.TipoNit);
			sql.AddParameter("@NIT", SqlDbType.VarChar, objDat_Gene.Nit);
			sql.AddParameter("@NIT_DIVE", SqlDbType.VarChar, objDat_Gene.NitDive);
			sql.AddParameter("@DIRECCION", SqlDbType.VarChar, objDat_Gene.Direccion);
			sql.AddParameter("@TELEFONO", SqlDbType.VarChar, objDat_Gene.Telefono);
			sql.AddParameter("@CIUDAD", SqlDbType.VarChar, objDat_Gene.Ciudad);
			sql.AddParameter("@SLOGAN", SqlDbType.VarChar, objDat_Gene.Slogan);
			sql.AddParameter("@IMP_FACTURA", SqlDbType.VarChar, (objDat_Gene.TiqueteFactura == "Tiquete"?"T":"F"));
//			sql.AddParameter("@REGIMEN", SqlDbType.VarChar, (objDat_Gene.Regimen == "Comun"?"C":"S"));
//			sql.AddParameter("@RESOLUCION_FACT", SqlDbType.VarChar, objDat_Gene.ResolucionFacturacion);
//			sql.AddParameter("@RESOLUCION_AUTO", SqlDbType.VarChar, objDat_Gene.ResolucionAutoretenedor);
//			sql.AddParameter("@RESOLUCION_CONT", SqlDbType.VarChar, objDat_Gene.ResolucionCont);
//			sql.AddParameter("@PREF_FACT", SqlDbType.VarChar, objDat_Gene.PrefijoFactura);
//			sql.AddParameter("@CONS_INIFACT", SqlDbType.Int, objDat_Gene.ConsecutivoInicial);
//			sql.AddParameter("@CONS_ACTUAL", SqlDbType.Int, objDat_Gene.ConsecutivoFinal);
			sql.AddParameter("@LIMPIAR_DISPLAY", SqlDbType.Bit, objDat_Gene.LimpiarDisplay);
			sql.AddParameter("@VENTAS_PRE", SqlDbType.Bit, objDat_Gene.SelfService);
			sql.AddParameter("@CAPTURADOR_PANTALLA", SqlDbType.Bit, objDat_Gene.CapturadorEnPantalla);
			sql.AddParameter("@CONTROL_MANT", SqlDbType.Bit, objDat_Gene.ControlMantenimiento);
			sql.AddParameter("@VR_BOLSA", SqlDbType.Decimal, objDat_Gene.ValorBolsaDinero);
			sql.AddParameter("@VER_SUBCLASES ", SqlDbType.Bit, objDat_Gene.ActualizarFormPagGenerador);
			sql.AddParameter("@RECAUDO", SqlDbType.Bit, objDat_Gene.CobrarRecaudo);
			sql.AddParameter("@SUIC_VER", SqlDbType.VarChar, (objDat_Gene.VersionSuic == "Si"?"S":(objDat_Gene.VersionSuic == "No"?"N":"T") ) );
			sql.AddParameter("@COD_SUC", SqlDbType.Int, objDat_Gene.CodigoSucursal);
			sql.AddParameter("@TIPOCC", SqlDbType.Int, (objDat_Gene.TipoCentroComputo == "TPS"?0:1));
			sql.AddParameter("@ACTIVA", SqlDbType.Bit, objDat_Gene.CrearTarjActivas);
			sql.AddParameter("@DESCUENTO", SqlDbType.Decimal, objDat_Gene.PorcentajeDescuento);
			sql.AddParameter("@DCTO_FEC_INI", SqlDbType.VarChar, objDat_Gene.FechaInicialDescuento.ToString("yyyyMMdd"));
			sql.AddParameter("@DCTO_FEC_FIN", SqlDbType.VarChar, objDat_Gene.FechaFinalDescuento.ToString("yyyyMMdd"));
			sql.AddParameter("@DCTO_HOR_INI", SqlDbType.DateTime, objDat_Gene.HoraInicialDescuento);
			sql.AddParameter("@DCTO_HOR_FIN", SqlDbType.DateTime, objDat_Gene.HoraFinalDescuento);
			sql.AddParameter("@SOLI_LECT", SqlDbType.Bit, objDat_Gene.SolicitaLectsMecanicas);
			sql.AddParameter("@CLAVECPA", SqlDbType.VarChar, objDat_Gene.PasswordCierreXAjuste);
			sql.AddParameter("@TIPOGAS", SqlDbType.VarChar, (objDat_Gene.TipoEstacion == "Gasolina"?"0":objDat_Gene.TipoEstacion == "Gas"?"1":"2") );
			sql.AddParameter("@FIDELIZADO", SqlDbType.Bit, objDat_Gene.EDSFideliza);
			sql.AddParameter("@IdNumOrden", SqlDbType.Int, objDat_Gene.IdNumOrden);
			sql.AddParameter("@DCTO_RECAUDO", SqlDbType.VarChar, (objDat_Gene.DctoRecaudo == true?"1":"0"));
			sql.AddParameter("@DctoFidelizado", SqlDbType.Int, (objDat_Gene.DctoRecaudo));
			sql.AddParameter("@idPais", SqlDbType.TinyInt, (objDat_Gene.DctoRecaudo));
			sql.AddParameter("@Sap", SqlDbType.Int, (objDat_Gene.Sap));
			sql.AddParameter("@JornadaZeta", SqlDbType.Char, objDat_Gene.JornadaZeta);
			sql.AddParameter("@Mr_Socket_Activo", SqlDbType.Char, objDat_Gene.Mr_Socket_Activo);
			sql.AddParameter("@Mr_Socket_Local_Puerto", SqlDbType.Int, objDat_Gene.Mr_Socket_Local_Puerto);		
			sql.AddParameter("@Mr_Socket_Local_Address", SqlDbType.VarChar, objDat_Gene.Mr_Socket_Local_Address);
			sql.AddParameter("@ManejaDebug", SqlDbType.TinyInt, objDat_Gene.ManejaDebug);
			sql.AddParameter("@IpControlTanques", SqlDbType.VarChar, objDat_Gene.IpControlTanques);			
			sql.AddParameter("@PeriodoVariacionTanque", SqlDbType.VarChar, objDat_Gene.PeriodoVariacionTanque);
			sql.AddParameter("@RutaPlanoVentasPendientes", SqlDbType.VarChar, objDat_Gene.RutaPlanoVentasPendientes);
			sql.AddParameter("@RutaPlanoVentasProcesadas", SqlDbType.VarChar, objDat_Gene.RutaPlanoVentasProcesadas);
			sql.AddParameter("@MensajeDctoFidelizado", SqlDbType.VarChar, objDat_Gene.MensajeDctoFidelizado);
			sql.AddParameter("@RutaExportarPredeterminada", SqlDbType.VarChar, objDat_Gene.RutaExportarPredeterminada);
			sql.AddParameter("@CodigoAlternoEstacion", SqlDbType.VarChar, objDat_Gene.CodigoAlternoEstacion);
			sql.AddParameter("@PlanoVentasCreditoContado", SqlDbType.TinyInt, objDat_Gene.PlanoVentasCreditoContado);
			sql.AddParameter("@ConexionOracle", SqlDbType.TinyInt, objDat_Gene.ConexionOracle);
			sql.AddParameter("@GenerarPlanoVentaSap", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoVentaSap);
			sql.AddParameter("@GenerarPlanoTrasladoSap", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoTrasladoSap);
			sql.AddParameter("@GenerarPlanoLecturaSAP", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoLecturaSap);
			sql.AddParameter("@GenerarPlanoReporte", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoReporte);
			sql.AddParameter("@GenerarPlanoTotalElectronico", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoTotalElectronico);
			sql.AddParameter("@GenerarPlanoMapa", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoMapa);
			sql.AddParameter("@GenerarPlanoCuenta", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoCuenta);
			sql.AddParameter("@GenerarPlanoPrecio", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoPrecio);
			sql.AddParameter("@RutaImportarPredeterminada", SqlDbType.VarChar, objDat_Gene.RutaImportarPredeterminada);
			sql.AddParameter("@DebugTramasSurtidores", SqlDbType.TinyInt, objDat_Gene.DebugTramasSurtidores);
			sql.AddParameter("@separadorPlanosPredeterminado", SqlDbType.VarChar, objDat_Gene.SeparadorPlanosPredeterminado);
			sql.AddParameter("@LecturasPorVenta", SqlDbType.TinyInt, objDat_Gene.LecturasPorVenta);
			sql.AddParameter("@IntentosAEstacion", SqlDbType.SmallInt, objDat_Gene.IntentosAEstacion);
			sql.AddParameter("@IntentosACapturador", SqlDbType.SmallInt, objDat_Gene.IntentosACapturador);
			sql.AddParameter("@IntervaloACapturador", SqlDbType.Int, objDat_Gene.IntervaloACapturador);
			sql.AddParameter("@IntervaloAEstacion", SqlDbType.Int, objDat_Gene.IntervaloAEstacion);
			sql.AddParameter("@UtilizaServidorCapturadores", SqlDbType.Bit, objDat_Gene.UtilizaServidorCapturadores);
			sql.AddParameter("@PuertoServidorCapturadores", SqlDbType.Int, objDat_Gene.PuertoServidorCapturadores);
			sql.AddParameter("@TipoAutorizacion", SqlDbType.SmallInt, objDat_Gene.TipoAutorizacion);
			sql.AddParameter("@ImprimirMensajeAdicional", SqlDbType.Bit, objDat_Gene.ImprimirMensajeAdicional);
			sql.AddParameter("@MensajeAdicional", SqlDbType.VarChar, objDat_Gene.MensajeAdicional);
			sql.AddParameter("@MensajeAdicionalMayoresA", SqlDbType.Decimal, objDat_Gene.MensajeAdicionalMayoresA);
			sql.AddParameter("@SeguridadImpresion", SqlDbType.Bit, objDat_Gene.SeguridadImpresion);
			sql.AddParameter("@ClaveImpresion", SqlDbType.VarChar, objDat_Gene.ClaveImpresion);
			sql.AddParameter("@TiempoSeguridadImpresion", SqlDbType.TinyInt, objDat_Gene.TiempoSeguridadImpresion);
			sql.AddParameter("@GenerarPlanoInventario", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoInventario );
			sql.AddParameter("@GenerarPlanoLecturas", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoLecturas );
			sql.AddParameter("@GenerarPlanoVentas", SqlDbType.TinyInt, objDat_Gene.GenerarPlanoventas );
			sql.AddParameter("@DirPlanoLecturas", SqlDbType.TinyInt, objDat_Gene.DirPlanoLecturas );
			sql.AddParameter("@DirPlanoVentas", SqlDbType.TinyInt, objDat_Gene.DirPlanoVentas );			
			sql.AddParameter("@TiqueteVentaConfigurable", SqlDbType.Bit, objDat_Gene.TiqueteVentaConfigurable );
            sql.AddParameter("@IdTipoAutorizacionExterna", SqlDbType.TinyInt, objDat_Gene.IdTipoAutorizacionExterna);
			

			#endregion

			#region Execute Sql
            try
            {
                SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
            }
            catch (SqlException e)
            {
                if (e.Message.IndexOf("Llave Duplicada!") != -1)
                    throw new Exception("Eds ya Posse Datos Generales " + objDat_Gene.RazonSocial + " !ERROR BD! ");
                else
                    throw new Exception(e.Message + e.StackTrace + " !ERROR BD! ");

            }
           
			finally {
				sql = null;
			}
			#endregion

		}
		#endregion

		#region GetItem
		/// <summary>
		/// Metodo para obtener Datos Generales de la EDS.
		/// </summary>
		/// <param name="cod_Est">Codigo de la Estaacion a Consultar</param>
		/// <returns>Informacion de Datos Generales.</returns>
		public static Dat_Gene ObtenerItem(int cod_Est) {
			Datos_Gene objDatos_Gene = new Datos_Gene(cod_Est);
			if (objDatos_Gene.Count == 1)
				return objDatos_Gene[0];
			else
				return null;
		}

		/// <summary>
		/// Metodo para obtener Datos Generales de la EDS.
		/// </summary>
		/// <returns>Informacion de Datos Generales.</returns>
		public static Dat_Gene ObtenerItem(){
			Datos_Gene objDatos_Gene = new Datos_Gene();
			if (objDatos_Gene.Count == 1)
				return objDatos_Gene[0];
			else
				return null;
		}
		#endregion

	}
}