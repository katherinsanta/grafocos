using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
 
namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Bibioteca de colección de Clases para la administración de la tabla ventas
	/// </summary>
	public class Ventas : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _consecutivo = null;
		private object _fecha = null;
		private object _codigoIsla = null;
		private object _numeroTurno = null;

		#endregion

		#region Constructor
		/// <summary>
		/// Consulta ventas.
		/// </summary>
		public Ventas()
		{
		}

		/// <summary>
		/// Consulta de una venta en particular.
		/// </summary>
		public Ventas(object consecutivo,object fecha,object codigoIsla,object numeroTurno)
		{
			this._consecutivo = consecutivo;
			this._fecha = fecha;
			this._codigoIsla = codigoIsla;
			this._numeroTurno = numeroTurno;

		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Venta this[string key]
		{
			get { return (Venta)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Venta this[int index]
		{
			get { return (Venta)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>				
		/// Modificaciones
		/// Se adicionaron nuevois campos necesarios para la impresion del tiquete de venta
		/// Fecha: 11/02/2009
		/// Autor: Rodrigo Figueroa Rivera		
		/// Referencia Documental: Automatizacion > Automatizacion de Islas_DT_SC_16
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarVenta");
			sql.ParametersNumber = 4;
			sql.AddParameter("@Consecutivo", SqlDbType.Int, this._consecutivo);
			sql.AddParameter("@Fecha", SqlDbType.DateTime, this._fecha);
			sql.AddParameter("@Cod_Isl", SqlDbType.Int, this._codigoIsla);
			sql.AddParameter("@Num_Tur", SqlDbType.Int, this._numeroTurno);

			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Venta objVenta = new Venta();
				objVenta.IdVentas = dr.GetInt32(0);
				objVenta.PrefijoVenta = dr.IsDBNull(1)?"(sin definir)":dr.GetString(1);
				objVenta.Consecutivo = dr.GetInt32(2);
				objVenta.CodigoFormaPago  = dr.GetInt32(3);
				objVenta.Total = dr.GetValue(4).ToString().Trim() == ""?0:decimal.Parse(dr.GetValue(4).ToString().Trim());
				objVenta.Fecha = DateTime.Parse(dr.GetValue(5).ToString().Trim());
				objVenta.CodigoIsla  = dr.GetInt32(6);
				objVenta.NumeroTurno  = dr.GetInt16(7);
				objVenta.FechaReal = DateTime.Parse(dr["fecha_real"].ToString());
				objVenta.Cantidad = Decimal.Parse(dr["cantidad"].ToString());
                objVenta.ValorNeto = Decimal.Parse(dr["valorneto"].ToString());
				objVenta.Descuento = Decimal.Parse(dr["descuento"].ToString());
				objVenta.SubTotal = Decimal.Parse(dr["subtotal"].ToString());				
				objVenta.ValorIva = Decimal.Parse(dr["vr_iva"].ToString());
				objVenta.TotalCuota = Decimal.Parse(dr["total_cuota"].ToString());
				objVenta.CodigoArticulo = int.Parse(dr["cod_art"].ToString());
				#region nuevos campos incluidos rf
				objVenta.CodigoEmpleado = dr["cod_emp"].ToString();
				objVenta.CodigoCara = int.Parse(dr["cod_car"].ToString());
				objVenta.CodigoSurtidor = int.Parse(dr["cod_sur"].ToString());
				objVenta.CodigoManguera= int.Parse(dr["cod_man"].ToString());
				objVenta.CodigoEmpleado = dr["cod_emp"].ToString();
				objVenta.Preset = (int)decimal.Parse(dr["preset"].ToString());
				objVenta.Hora = DateTime.Parse(dr["hora"].ToString());
				objVenta.PorcDescuento = Decimal.Parse(dr["PorcDescuento"].ToString());		
				objVenta.TiqueteImpreso = int.Parse(dr["imp_tiquete"].ToString());
				objVenta.PrecioUnitario = Decimal.Parse(dr["precio"].ToString());
				objVenta.FechaMantenimiento = DateTime.Parse(dr["fechamant"].ToString());
				objVenta.KilometrajeActual = (int)decimal.Parse(dr["kil_act"].ToString());
				objVenta.CodigoCliente = dr["Cod_Cli"].ToString();
				objVenta.Placa = dr["placa"].ToString();
				#endregion
				base.AddItem(objVenta.IdVentas.ToString(), objVenta);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Adicionar
		/// <summary>
		/// Inserción de un registro de venta con informacion basica.
		/// </summary>
		public static void AdicionarBasico(Venta objVenta)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarVentaBasico");
			sql.ParametersNumber = 6;
			sql.AddParameter("@CodigoFormaPago",SqlDbType.SmallInt,objVenta.CodigoFormaPago);
			sql.AddParameter("@CodigoArticulo",SqlDbType.Int,objVenta.CodigoArticulo);
			sql.AddParameter("@CodigoCara",SqlDbType.Int,objVenta.CodigoCara);
			sql.AddParameter("@Placa",SqlDbType.VarChar,objVenta.Placa);
			sql.AddParameter("@Total",SqlDbType.Decimal,objVenta.Total);
			sql.AddParameter("@CodigoEmpleado",SqlDbType.VarChar,objVenta.CodigoEmpleado);

			#endregion

			#region Execute Sql
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

		#region ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa una venta en particular
		/// <param name="consecutivo">Consecutivo de la venta</param>
		/// <param name="fecha">Fecha de la vena</param>
		/// <param name="codigoIsla">Codigo de la isla</param>
		/// <param name="numeroTurno">Numero del turno</param>
		/// </summary>
		public static Venta ObtenerItem(int consecutivo, DateTime fecha,int codigoIsla,int numeroTurno)
		{
			Ventas objElementos = new Ventas(consecutivo,fecha,codigoIsla,numeroTurno);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region ObtenerItems no Cancelados 
		/// <summary>
		/// Método para obtener de manera directa todas las ventas que no han sido pagadas
		/// <param name="opcion">dependiendo la opcion realizara la consulta
		/// opcion = 0, busca todas las ventas
		/// opcion = 1, busca en detalle las ventas realizadas a una placa</param>
		/// <param name="placa">placa a la que se quiere consultar en especial</param>
		/// <param name="enviada">Filtrara por enviadas o no enviadas 1 o 0</param>
		/// <param name="grupoConsecutivo">Grupo de consecutivo al cual pertenece el presente registro</param>
		/// </summary>
		public static DataSet ObtenerItemsSinCancelar(int opcion, string placa, int enviada, string grupoConsecutivo)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarVentaSinCancelar");
			sql.ParametersNumber = 4;
			sql.AddParameter("@Opcion", SqlDbType.Int, opcion);
			sql.AddParameter("@GrupoConsecutivo", SqlDbType.VarChar, grupoConsecutivo);
			if(opcion == 1)
			{
				sql.AddParameter("@Placa", SqlDbType.VarChar, placa);
				sql.AddParameter("@Enviada", SqlDbType.TinyInt, enviada);
			}
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters));
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

		#region ObtenerItem consecutivo por medio de una placa en ventas de combustibles o ventas de canastilla
		/// <summary>
		/// <param name="placa">placa a la que se quiere consultar en especial para traer el maximo consecutivo sin cancelar</param>
		/// </summary>
		public static DataSet ObtenerItemConsecutivo(string placa)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarVentaConsecutivo");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Placa", SqlDbType.VarChar, placa);
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters));
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

		#region Reporte de ventas por empleado CapturadorVirtual
		/// <summary>
		/// Reporte de ventas por empleado CapturadorVirtual
		/// <param name="fechaInicial">Fecha inicial desde donde se generará el reporte</param>
		/// <param name="fechaFinal">Fecha Final hasta donde se generará el reporte</param>
		/// <param name="codigoEmpleado">Codigo del empleado para el cual se buscará la informacion ('-1'= todos los empleados)</param>
		/// </summary>
		public static DataSet RptVentasEmpleado(DateTime fechaInicial,DateTime fechaFinal,string codigoEmpleado)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RptVentasEmpleadoCV");
			sql.ParametersNumber = 4;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal);
			sql.AddParameter("@opcion", SqlDbType.Int,1);
			if(codigoEmpleado!="-1")	
				sql.AddParameter("@cod_emp", SqlDbType.VarChar,codigoEmpleado);
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters));
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

		#region Reporte de ventas por turno CapturadorVirtual
		/// <summary>
		/// Reporte de ventas por turno CapturadorVirtual
		/// <param name="fechaInicial">Fecha inicial desde donde se generará el reporte</param>
		/// <param name="fechaFinal">Fecha Final hasta donde se generará el reporte</param>
		/// <param name="codigoEmpleado">Codigo del empleado para el cual se buscara la informacion ('-1'= todos los empleados)</param>
		/// <param name="turno">Turno para el cual se buscará la informacion ('-1'= todos los turnos)</param>
		/// </summary>
		public static DataSet RptVentasTurno(DateTime fechaInicial,DateTime fechaFinal,string codigoEmpleado,int turno)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RptVentasEmpleadoCV");
			sql.ParametersNumber = 5;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal);
			sql.AddParameter("@opcion", SqlDbType.Int,2);
			if(codigoEmpleado!="-1")	
				sql.AddParameter("@cod_emp", SqlDbType.VarChar,codigoEmpleado);
			if(turno != -1)	
				sql.AddParameter("@turno", SqlDbType.Int,turno);
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters));
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
 
		#region Reporte de ventas por pagar CapturadorVirtual
		/// <summary>
		/// Reporte de ventas pendientes por pagar
		/// <param name="fechaInicial">Fecha inicial desde donde se generará el reporte</param>
		/// <param name="fechaFinal">Fecha final hasta donde se generará el reporte</param>
		/// </summary>
		public static DataSet RptVentasPendientesPagar(DateTime fechaInicial,DateTime fechaFinal)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RptVentasPendientesPagarCV");
			sql.ParametersNumber = 2;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal);
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters));
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

		#region Reporte de ventas por pagar CapturadorVirtual
		/// <summary>
		/// Reporte de ventas que fueron registradas manualmente
		/// <param name="fechaInicial">Fecha inicial desde donde se generará el reporte</param>
		/// <param name="fechaFinal">Fecha final hasta donde se generará el reporte</param>
		/// </summary>
		public static DataSet RptVentasManuales(DateTime fechaInicial,DateTime fechaFinal)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RptVentasManualesCV");
			sql.ParametersNumber = 2;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal);
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters));
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

		#region reporte de ventas por articulo
		/// <summary>
		/// Reporte de ventas pendientes por pagar
		/// <param name="fechaInicial">Fecha inicial desde donde se generará el reporte</param>
		/// <param name="fechaFinal">Fecha final hasta donde se generará el reporte</param>
		/// <param name="codigoCliente">Codigo del cliente a consultar</param>
		/// </summary>
		public static DataSet RptVentasPorArticulo(DateTime fechaInicial,DateTime fechaFinal,string codigoCliente)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RptConsolidadoVentasArticulo");
			sql.ParametersNumber = 3;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal);
			if(codigoCliente.Trim().Length > 0)
				sql.AddParameter("@codigoCliente", SqlDbType.VarChar, codigoCliente);
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters));
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

		#region Marcar ventas no transmitidas
		/// <summary>
		/// Generar plano de ventas no transmitidas hacia el servidor de un tercero
		/// </summary>
		/// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
		/// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
		/// <param name="consecutivo">actualiza todas las ventas menores o iguales a este consecutivo</param>
		
		public static void PlanoVentasNoTransmitidas(
			DateTime fechaInicial,
			DateTime fechaFinal,
			int consecutivo
			)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ActualizarVentasNoTransmitidas");
			sql.ParametersNumber = 3;
			sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@FechaFinal", SqlDbType.DateTime, fechaFinal);
			sql.AddParameter("@Consecutivo", SqlDbType.Int, consecutivo);
			
			#endregion

			#region Execute Sql			
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message + " Error al marcar las ventas como enviadas !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}

			#endregion

		}
		#endregion


        #region Ventas de Canastilla
        /// <summary>
        /// Generar plano de ventas no transmitidas hacia el servidor de un tercero
        /// </summary>
        /// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
        /// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
        /// <param name="consecutivo">actualiza todas las ventas menores o iguales a este consecutivo</param>

        public static DataSet VentasCanastilla(
            DateTime fechaInicial,
            DateTime fechaFinal ,
            string codigoCliente,
            string estado,
            string turno
            )
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ConsultaVentaCanastilla");
            sql.ParametersNumber = 5;
            sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fechaInicial);
            sql.AddParameter("@FechaFinal", SqlDbType.DateTime, fechaFinal);
            sql.AddParameter("@CodigoCliente", SqlDbType.VarChar, codigoCliente);
            sql.AddParameter("@Estado", SqlDbType.VarChar, estado);
            sql.AddParameter("@Turno", SqlDbType.VarChar, turno);      


            #endregion

            #region Execute Sql
            try
            {
                return (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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

        #region Ventas de Canastilla
        /// <summary>
        /// Generar plano de ventas no transmitidas hacia el servidor de un tercero
        /// </summary>
        /// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
        /// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
        /// <param name="consecutivo">actualiza todas las ventas menores o iguales a este consecutivo</param>

        public static DataTable VentasCanastilla( )
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ConsultaVentaCanastilla");
            sql.ParametersNumber = 5;
            sql.AddParameter("@FechaInicial", SqlDbType.DateTime, DateTime.Today);
            sql.AddParameter("@FechaFinal", SqlDbType.DateTime, DateTime.Today);
            sql.AddParameter("@CodigoCliente", SqlDbType.VarChar, "0");
            sql.AddParameter("@Estado", SqlDbType.VarChar, "2");
            sql.AddParameter("@Turno", SqlDbType.VarChar, "0");
            //Servipunto.Estacion.AccesoDatos.StoredProcedureCallerClasses.RetrievalProcedures.ConsultaVentaCanastilla(
            #endregion

            #region Execute Sql
            try
            {
                return (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters)).Tables[0];
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


        #region Ventas de Canastilla
        /// <summary>
        /// Generar plano de ventas no transmitidas hacia el servidor de un tercero
        /// </summary>
        /// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
        /// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
        /// <param name="consecutivo">actualiza todas las ventas menores o iguales a este consecutivo</param>

        public static DataSet VentaCanastillaItems(
            string prefijo,
            int consecutivo
            )
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ConsultaVentaCanastillaItems");
            sql.ParametersNumber = 2;
            sql.AddParameter("@Prefijo", SqlDbType.VarChar, prefijo);
            sql.AddParameter("@Consecutivo", SqlDbType.Int, consecutivo);

            #endregion

            #region Execute Sql
            try
            {
                return (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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


        #region Obtener Venta Canastilla
        /// <summary>
        /// Generar plano de ventas no transmitidas hacia el servidor de un tercero
        /// </summary>
        /// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
        /// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
        /// <param name="consecutivo">actualiza todas las ventas menores o iguales a este consecutivo</param>

        public static DataSet ObtenerVentaCanastilla(
            string prefijo,
            int consecutivo
            )
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ObtenerVentaCanastilla");
            sql.ParametersNumber = 2;
            sql.AddParameter("@Prefijo", SqlDbType.VarChar, prefijo);
            sql.AddParameter("@Consecutivo", SqlDbType.Int, consecutivo);

            #endregion

            #region Execute Sql
            try
            {
                return (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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


        #region Obtener Venta Canastilla
        /// <summary>
        /// Generar plano de ventas no transmitidas hacia el servidor de un tercero
        /// </summary>
        /// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
        /// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
        /// <param name="consecutivo">actualiza todas las ventas menores o iguales a este consecutivo</param>

        public static void ActualizarVentaCanastilla(
            string anulada,
            string cod_cli,
            string placa,
            int consecutivo
            )
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ActualizarVentaCanastilla");
            sql.ParametersNumber = 4;
            sql.AddParameter("@Anulada", SqlDbType.VarChar, anulada);
            sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, cod_cli);
            sql.AddParameter("@Placa", SqlDbType.VarChar, placa);
            sql.AddParameter("@Consecutivo", SqlDbType.Int, consecutivo);

            #endregion

            #region Execute Sql
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

        #region Convertir Numeros a Letras
        private string ConvertirNumerosaLetras(string num)
        {

            string res, dec = "";

            Int64 entero;

            int decimales;

            double nro;

            try
            {

                nro = Convert.ToDouble(num);

            }

            catch
            {

                return "";

            }

            entero = Convert.ToInt64(Math.Truncate(nro));

            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));

            if (decimales > 0)
            {

                dec = " CON " + decimales.ToString() + "/100";

            }

            res = toText(Convert.ToDouble(entero)) + dec;

            return res;

        }

        private string toText(double value)
        {

            string Num2Text = "";

            value = Math.Truncate(value);

            if (value == 0) Num2Text = "CERO";

            else if (value == 1) Num2Text = "UNO";

            else if (value == 2) Num2Text = "DOS";

            else if (value == 3) Num2Text = "TRES";

            else if (value == 4) Num2Text = "CUATRO";

            else if (value == 5) Num2Text = "CINCO";

            else if (value == 6) Num2Text = "SEIS";

            else if (value == 7) Num2Text = "SIETE";

            else if (value == 8) Num2Text = "OCHO";

            else if (value == 9) Num2Text = "NUEVE";

            else if (value == 10) Num2Text = "DIEZ";

            else if (value == 11) Num2Text = "ONCE";

            else if (value == 12) Num2Text = "DOCE";

            else if (value == 13) Num2Text = "TRECE";

            else if (value == 14) Num2Text = "CATORCE";

            else if (value == 15) Num2Text = "QUINCE";

            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);

            else if (value == 20) Num2Text = "VEINTE";

            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);

            else if (value == 30) Num2Text = "TREINTA";

            else if (value == 40) Num2Text = "CUARENTA";

            else if (value == 50) Num2Text = "CINCUENTA";

            else if (value == 60) Num2Text = "SESENTA";

            else if (value == 70) Num2Text = "SETENTA";

            else if (value == 80) Num2Text = "OCHENTA";

            else if (value == 90) Num2Text = "NOVENTA";

            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);

            else if (value == 100) Num2Text = "CIEN";

            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);

            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";

            else if (value == 500) Num2Text = "QUINIENTOS";

            else if (value == 700) Num2Text = "SETECIENTOS";

            else if (value == 900) Num2Text = "NOVECIENTOS";

            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);

            else if (value == 1000) Num2Text = "MIL";

            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);

            else if (value < 1000000)
            {

                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";

                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);

            }

            else if (value == 1000000) Num2Text = "UN MILLON";

            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);

            else if (value < 1000000000000)
            {

                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";

                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);

            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";

            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {

                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";

                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            }

            return Num2Text;

        }
        #endregion

        #region Recuperar Ventas 98 por Turno
        /// <summary>
        /// Genera reporte para las ventas con codigo 98
        /// </summary>
        /// <param name="TipoReporte"></param> si es 1 es resimido si es 2 es detallado
        /// <param name="Turno"></param>       determina el turno, sie s 0 trae todos los turnos
        /// <param name="Articulo"></param>    si es 0 se traen todos los articulos, si no se trae el reporte solo pa el codigo de el articulo
        /// <param name="Fechainicio"></param> determina la fecha de inicio en el rango de busqueda 
        /// <param name="Fechafinal"></param>  determina la fecha de final  en el rango de busqueda 
        /// <returns></returns>

        public static DataTable RecuperarVentas98Turno(string TipoReporte, string Turno, string Articulo, DateTime Fechainicio, DateTime Fechafinal)
        {
            try
            {
                #region Prepare Sql Command
                SqlDataReader dr = null;
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

                if (TipoReporte == "1")
                    sql.Append("SELECT consecutivo, dbo.Finteger(FECHA) 'FECHA', dbo.HINTEGER(HORA) 'HORA',NUM_TUR, dbo.ARTICULO.DESCRIPCION, dbo.VENTAS.VALORNETO,dbo.VENTAS.COD_CAR ,dbo.VENTAS.COD_MAN, dbo.VENTAS.CANTIDAD FROM dbo.VENTAS INNER JOIN dbo.ARTICULO ON dbo.VENTAS.COD_ART = dbo.ARTICULO.COD_ART WHERE dbo.VENTAS.COD_FOR_PAG = 98 and dbo.Finteger(dbo.VENTAS.Fecha) between '" + Fechainicio.ToString("yyyyMMdd") + "' and '" + Fechafinal.ToString("yyyyMMdd") + "' ");

                else if (TipoReporte == "2")
                    sql.Append("SELECT consecutivo, dbo.Finteger(Fecha_Real) 'FECHA', dbo.HINTEGER(HORA) 'HORA',NUM_TUR, dbo.ARTICULO.DESCRIPCION, dbo.VENTAS.VALORNETO ,dbo.VENTAS.COD_CAR ,dbo.VENTAS.COD_MAN, dbo.VENTAS.CANTIDAD FROM dbo.VENTAS INNER JOIN dbo.ARTICULO ON dbo.VENTAS.COD_ART = dbo.ARTICULO.COD_ART WHERE dbo.VENTAS.COD_FOR_PAG = 98 and dbo.Finteger(dbo.VENTAS.Fecha_Real) between '" + Fechainicio.ToString("yyyyMMdd") + "' and '" + Fechafinal.ToString("yyyyMMdd") + "' ");
                if (Turno != "0")
                    sql.Append(" and dbo.VENTAS.NUM_TUR=" + Turno);

                if (Articulo != "0")
                    sql.Append(" and dbo.ARTICULO.COD_ART =" + Articulo);
                if (TipoReporte == "1")
                    sql.Append(" order by FECHA asc");
                if (TipoReporte == "2")
                    sql.Append(" order by FECHA_Real asc");
                #endregion
                #region Crea datatable
                DataTable TablaVentas98Turno = new DataTable();
                TablaVentas98Turno.Columns.Add("Consecutivo", typeof(int));
                TablaVentas98Turno.Columns.Add("Fecha", typeof(DateTime));
                TablaVentas98Turno.Columns.Add("Hora", typeof(DateTime));
                TablaVentas98Turno.Columns.Add("Turno", typeof(int));
                TablaVentas98Turno.Columns.Add("Articulo", typeof(string));
                TablaVentas98Turno.Columns.Add("Valor", typeof(int));
                TablaVentas98Turno.Columns.Add("Cara", typeof(int));
                TablaVentas98Turno.Columns.Add("Manguera", typeof(int));
                TablaVentas98Turno.Columns.Add("Cantidad", typeof(decimal));
                #endregion
                #region Execute Sql
                dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
                while (dr.Read())
                {
                    DataRow FilaVenta98 = TablaVentas98Turno.NewRow();

                    for (int i = 0; i < dr.FieldCount; i++)
                        FilaVenta98[i] = dr.GetValue(i);

                    TablaVentas98Turno.Rows.Add(FilaVenta98);

                }
                dr.Close();
                dr = null;
                sql = null;
                return TablaVentas98Turno;
                #endregion
            }

            catch (Exception er)
            {
                #region Si hay Error

                string error = er.Message;
                DataTable TablaVentas98Turno = new DataTable();
                return TablaVentas98Turno;
                #endregion
            }

        }
        #endregion

        #region Recuperar Ventas Otros Ingresos
        /// <summary>
        /// Recupera todos los Articulos
        /// </summary>		
        public static DataTable RecuperarVentasOtrosIngresos(string Fechade, string TipoReporte, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                #region Prepare Sql Command
                SqlDataReader dr = null;
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

                if (Fechade == "1")
                {
                    if (TipoReporte == "1")
                    {
                        sql.Append(" select dbo.Finteger(FECHA) 'FECHA',b.nombreotroingreso ,valorotroingreso from  consolidadootrosingresos a join  conceptootroingreso b on (a.idconceptootroingreso= b.idconceptootroingreso) where dbo.Finteger(a.FECHA) between '" + FechaInicial.ToString("yyyyMMdd") + "' and '" + FechaFinal.ToString("yyyyMMdd") + "' ");
                        sql.Append(" order by FECHA asc");

                    }
                    else
                    {
                        sql.Append("select  dbo.Finteger(FECHA) 'FECHA', dbo.HINTEGER(HORA) 'HORA',c.Nombreotroingreso ,valorotroingreso from registrootrosingresos r join conceptootroingreso  c on (r.idconceptootrosingresos =  c.idconceptootroingreso) where dbo.Finteger(r.FECHA) between '" + FechaInicial.ToString("yyyyMMdd") + "' and '" + FechaFinal.ToString("yyyyMMdd") + "' ");
                        sql.Append(" order by FECHA asc");
                    }

                }

                else if (Fechade == "2")
                {
                    sql.Append("select  dbo.Finteger(FECHAREAL) 'FECHA', dbo.HINTEGER(HORA) 'HORA',c.Nombreotroingreso ,valorotroingreso from registrootrosingresos r join conceptootroingreso  c on (r.idconceptootrosingresos =  c.idconceptootroingreso) where dbo.Finteger(r.FECHAREAL) between '" + FechaInicial.ToString("yyyyMMdd") + "' and '" + FechaFinal.ToString("yyyyMMdd") + "' ");
                    sql.Append(" order by FECHAREAL asc");
                }


                #endregion

                DataTable TablaVentasOtrosIngresos = new DataTable();
                TablaVentasOtrosIngresos.Columns.Add("Fecha", typeof(DateTime));
                TablaVentasOtrosIngresos.Columns.Add("Hora", typeof(DateTime));
                TablaVentasOtrosIngresos.Columns.Add("OtroIngreso", typeof(string));
                TablaVentasOtrosIngresos.Columns.Add("Valor", typeof(int));



                #region Execute Sql
                dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);

                if (Fechade == "1" && TipoReporte == "1")
                {
                    TablaVentasOtrosIngresos.Columns.Remove("Hora");
                }

                while (dr.Read())
                {
                    DataRow FilaVentaOtrosIngresos = TablaVentasOtrosIngresos.NewRow();

                    for (int i = 0; i < dr.FieldCount; i++)
                        FilaVentaOtrosIngresos[i] = dr.GetValue(i);

                    TablaVentasOtrosIngresos.Rows.Add(FilaVentaOtrosIngresos);

                }




                dr.Close();
                dr = null;
                sql = null;
                return TablaVentasOtrosIngresos;
                #endregion
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);

            }
        }
        #endregion


        #region MAXIMO CONSECUTIVO factura
        /// <summary>
        ///  ObtenerProxima
        /// </summary>
        /// <param name="prefijo"></param>
        /// <param name="consecutivo"></param>
        /// <param name="idOrden"></param>
        /// <param name="strOrden"></param>
        public void ProximoConsecutivoFactura(ref string prefijo, ref int consecutivo, ref int idOrden, ref string strOrden)
        {
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("SP_GetNextConsec");

            try
            {
                sql.ParametersNumber = 5;
                sql.AddParameter("@Prefijo", SqlDbType.VarChar, 10, ParameterDirection.Output);
                sql.AddParameter("@Consec", SqlDbType.Int, ParameterDirection.Output);
                sql.AddParameter("@NumOrder", SqlDbType.VarChar, 20, ParameterDirection.Output);
                sql.AddParameter("@IdNumOrden", SqlDbType.Int, ParameterDirection.Output);
                sql.AddParameter("@Table", SqlDbType.VarChar, "C");                
                SqlDataReader dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
                
                if (dr.Read())
                {
                    prefijo = dr.GetString(0);
                    consecutivo = dr.GetInt32(1);
                    strOrden = dr.GetString(2);
                    idOrden = dr.GetInt32(3);

                }
                dr.Close();
                dr = null;
                sql = null;

            }
            catch(Exception ex)
            {
                throw new Exception("Err " + ex.Message);
            }
                

        }
        #endregion

        #region total ventas
        /// <summary>
        /// Total venta Efectivo
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public void TotalVentasEfectivo(DateTime fecha)
        {
            decimal total = 0;
            int cod_art = 0;
            decimal parcial = 0;
            decimal cantidad = 0;
            decimal precio = 0;
            string prefijo ="";
            int consecutivo = 0;
            int idOrden = 0;
            string strOrden = "";
            DataTable datos = new DataTable("datos");
            datos.Columns.Add("Cod_art");
            datos.Columns.Add("total");
            datos.Columns.Add("cantidad");
            datos.Columns.Add("precio");

            ProximoConsecutivoFactura(ref  prefijo, ref  consecutivo, ref  idOrden, ref  strOrden);

            if (consecutivo > 0)
            {

                #region Prepare Sql Command
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

                sql.Append("TotalVentasContado");
                sql.ParametersNumber = 1;
                sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);


                #endregion

                #region Execute Sql
                try
                {
                    SqlDataReader dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cod_art = dr.GetInt32(0);
                            parcial = dr.GetDecimal(1);
                            cantidad = dr.GetDecimal(2);
                            precio = dr.GetDecimal(3);
                            datos.Rows.Add(cod_art, parcial, cantidad, precio);
                            total += parcial;
                        }
                    }

                    if (total > 0)
                    {
                        InsertarVentaCanastillaCombustible(total, prefijo, consecutivo, idOrden, strOrden);
                        InsertarDetalle(datos, prefijo, consecutivo);
                    }

                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message + " !ERROR BD! ");
                }
                finally
                {
                    sql = null;
                }
            }
            else
            {
                throw new Exception("No existen resoluciones de facturas Activas");
            }

            #endregion
         

        }

        #endregion

        /// <summary>
        /// Obtener venta Canastilla
        /// </summary>
        /// <param name="total"></param>
        private void InsertarVentaCanastillaCombustible(decimal total, string prefijo, int consecutivo, int idOrden, string strOrden )
        {
          
            SqlParameter[] arParams;

            Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDatoGene = Servipunto.Estacion.Libreria.Configuracion.Datos_Gene.ObtenerItem();

            Servipunto.Estacion.Libreria.Turnos.JornadaZeta objJornada = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(3);

            if (objJornada == null)
            {
                throw new Exception("Error obteniendo jornada");
            }

            else
            {
                string sql = "insert into VentaCanastilla (" +
                        "PREFIJO," +
                        "CONSECUTIVO," +
                        "COD_FOR_PAG," +
                        "FECHA," +
                        "FECHA_REAL," +
                        "HORA    ," +
                        "COD_EMP ," +
                        "COD_ISL ," +
                        "SUBTOTAL," +
                        "TOTAL  ," +
                        "TOTALIVA  ," +
                        "COD_EST, " +
                        "NUM_TURN, " +
                        "IDNUMORDEN, " +
                        "FECHA_NUM_DIA, " +
                        "FECHA_NUM_MES, " +
                        "PLACA, " +
                        "ENVIADA, " +
                        "CANCELADA, " +
                        "TipoFactura) " +                        
                        " values (" +
                        "@PREFIJO," +
                        "@CONSECUTIVO," +
                        "@COD_FOR_PAG," +
                        "dbo.Fjuliana(@FECHA)," +
                        "dbo.Fjuliana(@FECHA_REAL)," +
                        "dbo.Hjuliana(@HORA)    ," +
                        "@COD_EMP ," +
                        "@COD_ISL ," +
                        "@SUBTOTAL," +
                        "@TOTAL  ," +
                        "@TOTALIVA  ," +
                        "@COD_EST, " +
                        "@NUM_TURN, " +
                        "@IDNUMORDEN, " +
                        "@FECHA_NUM_DIA, " +
                        "@FECHA_NUM_MES, " +
                        "@PLACA, " +
                        "@ENVIADA, " +
                        "@CANCELADA, " +
                        "@TipoFactura) ";

                arParams = new SqlParameter[20];
                arParams[0] = new SqlParameter("@PREFIJO", SqlDbType.VarChar);
                //arParams[0].Value = this.Turno.Isla.Estacion.Prefijo;
                arParams[0].Value = prefijo;
                arParams[1] = new SqlParameter("@CONSECUTIVO", SqlDbType.Int);
                arParams[1].Value = consecutivo;
                arParams[2] = new SqlParameter("@COD_FOR_PAG", SqlDbType.SmallInt);
                arParams[2].Value = 4;
                arParams[3] = new SqlParameter("@FECHA", SqlDbType.DateTime);
                arParams[3].Value = objJornada.Fecha;
                arParams[4] = new SqlParameter("@FECHA_REAL", SqlDbType.DateTime);
                arParams[4].Value = DateTime.Today;
                arParams[5] = new SqlParameter("@HORA", SqlDbType.DateTime);
                arParams[5].Value = DateTime.Now;
                arParams[6] = new SqlParameter("@COD_EMP", SqlDbType.VarChar);
                arParams[6].Value = objJornada.CodigoEmpleado;
                arParams[7] = new SqlParameter("@COD_ISL", SqlDbType.SmallInt);
                arParams[7].Value = 1;
                arParams[8] = new SqlParameter("@SUBTOTAL", SqlDbType.Decimal);
                arParams[8].Value = total;
                arParams[9] = new SqlParameter("@TOTALIVA", SqlDbType.Decimal);
                arParams[9].Value = 0;
                arParams[10] = new SqlParameter("@TOTAL", SqlDbType.Decimal);
                arParams[10].Value = total;
                arParams[11] = new SqlParameter("@COD_EST", SqlDbType.Int);
                arParams[11].Value = objDatoGene.CodEstacion;
                arParams[12] = new SqlParameter("@NUM_TURN", SqlDbType.SmallInt);
                arParams[12].Value = 1;
                arParams[13] = new SqlParameter("@IDNUMORDEN", SqlDbType.VarChar);
                arParams[13].Value = idOrden.ToString();

                arParams[14] = new SqlParameter("@FECHA_NUM_DIA", SqlDbType.Int);
                arParams[14].Value = System.Convert.ToInt32(DateTime.Today.DayOfWeek);
                arParams[15] = new SqlParameter("@FECHA_NUM_MES", SqlDbType.Int);
                arParams[15].Value = DateTime.Today.Month;

                arParams[16] = new SqlParameter("@PLACA", SqlDbType.VarChar);
                arParams[16].Value = "";

                arParams[17] = new SqlParameter("@ENVIADA", SqlDbType.TinyInt);
                arParams[17].Value =1;

                arParams[18] = new SqlParameter("@CANCELADA", SqlDbType.TinyInt);
                arParams[18].Value = 1;


                arParams[19] = new SqlParameter("@TipoFactura", SqlDbType.VarChar);
                arParams[19].Value = '1';

                SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql, arParams);
            }				
            
        }


        private void InsertarDetalle(DataTable datos, string prefijo, int consecutivo)
        {
            foreach (DataRow fila in datos.Rows)
            {
                int cod_art = Convert.ToInt32(fila.ItemArray.GetValue(0).ToString());
                decimal total = Convert.ToDecimal(fila.ItemArray.GetValue(1).ToString());
                decimal cantidad = Convert.ToDecimal(fila.ItemArray.GetValue(2).ToString());
                decimal precio = Convert.ToDecimal(fila.ItemArray.GetValue(3).ToString());
                if ( total > 0)
                    InsertarDetalleVentaCanastillaCombustible(prefijo, consecutivo, cod_art, total, cantidad, precio);
            }

        }


        private void InsertarDetalleVentaCanastillaCombustible( string prefijo,  int consecutivo, int cod_art, decimal total, decimal cantidad, decimal precio)
        {
            string sql;
            SqlDataReader objDR = null;
            SqlParameter[] arParams;
            try
            {
                #region RegistraCanastilla
                sql = "insert into VENTACANASTILLAITEMS (" +
                    "PREFIJO," +
                    "CONSECUTIVO," +
                    "SUBTOTAL," +
                    "TOTAL  ," +
                    "VR_IVA  ," +
                    "COD_ART," +
                    "CANTIDAD," +
                    "PRECIO_UNI," +
                    "IVA) " +
                    "values (" +
                    "@PREFIJO," +
                    "@CONSECUTIVO," +
                    "@SUBTOTAL," +
                    "@TOTAL  ," +
                    "@TOTALIVA  ," +
                    "@COD_ART," +
                    "@CANTIDAD," +
                    "@PRECIO_UNI," +
                    "@IVA)";

                arParams = new SqlParameter[9];
                arParams[0] = new SqlParameter("@PREFIJO", SqlDbType.VarChar);
                //arParams[0].Value = this.Prefijo;
                arParams[0].Value = prefijo;
                arParams[1] = new SqlParameter("@CONSECUTIVO", SqlDbType.Int);
                arParams[1].Value = consecutivo;
                arParams[2] = new SqlParameter("@SUBTOTAL", SqlDbType.Decimal);
                arParams[2].Value = total;
                arParams[3] = new SqlParameter("@TOTALIVA", SqlDbType.Decimal);
                arParams[3].Value = 0;
                arParams[4] = new SqlParameter("@TOTAL", SqlDbType.Decimal);
                arParams[4].Value = total;
                arParams[5] = new SqlParameter("@COD_ART", SqlDbType.Int);
                arParams[5].Value = cod_art;
                arParams[6] = new SqlParameter("@CANTIDAD", SqlDbType.Decimal);
                arParams[6].Value = cantidad;
                arParams[7] = new SqlParameter("@PRECIO_UNI", SqlDbType.Decimal);
                arParams[7].Value = precio;
                arParams[8] = new SqlParameter("@IVA", SqlDbType.SmallInt);
                arParams[8].Value = 0;
                SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql, arParams);
                #endregion
            }
            catch (SqlException sqe)
            {
               
            }
            catch (Exception e)
            {
              
            }

            if (objDR != null)
            {
                objDR.Close();
                objDR = null;
            }        
        }
        #region Recuperar Ventas por combustible
        /// <summary>
        /// Recupera todos los Articulos
        /// </summary>		
        public static DataTable RecuperarVentasPorCombustible(DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                #region Prepare Sql Command
                SqlDataReader dr = null;
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

                sql.Append(" select PREFIJO,CONSECUTIVO ,dbo.Finteger( FECHA), dbo.Hinteger( HORA),SUBTOTAL, TOTALIVA, TOTAL from ventacanastilla where tipofactura=1 and dbo.Finteger(FECHA) between '" + FechaInicial.ToString("yyyyMMdd") + "' and '" + FechaFinal.ToString("yyyyMMdd") + "' ");
                sql.Append(" order by FECHA asc");


                #endregion

                DataTable TablaVentasCombustible = new DataTable();
                TablaVentasCombustible.Columns.Add("Prefijo", typeof(string));
                TablaVentasCombustible.Columns.Add("Consecutivo", typeof(int));
                TablaVentasCombustible.Columns.Add("Fecha", typeof(DateTime));
                TablaVentasCombustible.Columns.Add("Hora", typeof(DateTime));
                TablaVentasCombustible.Columns.Add("Subtotal", typeof(decimal));
                TablaVentasCombustible.Columns.Add("TotalIva", typeof(decimal));
                TablaVentasCombustible.Columns.Add("Total", typeof(decimal));


                #region Execute Sql
                dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);


                while (dr.Read())
                {
                    DataRow FilaVentaCombustibles = TablaVentasCombustible.NewRow();

                    for (int i = 0; i < dr.FieldCount; i++)
                        FilaVentaCombustibles[i] = dr.GetValue(i);

                    TablaVentasCombustible.Rows.Add(FilaVentaCombustibles);

                }




                dr.Close();
                dr = null;
                sql = null;
                return TablaVentasCombustible;
                #endregion
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);

            }
        }
        #endregion

        #region Recuperar Detalle de venta por combustible
        /// <summary>
        /// Recupera todos los Articulos
        /// </summary>		
        public static DataTable RecuperarDetalleVentasPorCombustible(int Consecutivo)
        {
            try
            {
                #region Prepare Sql Command
                SqlDataReader dr = null;
                Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

                sql.Append("select a.CONSECUTIVO ,dbo.Finteger( a.FECHA), dbo.Hinteger( a.HORA),a.SUBTOTAL, a.TOTALIVA, a.TOTAL, b.COD_ART, e.descripcion, b.CANTIDAD, b.PRECIO_UNI,b.IVA,b.SUBTOTAL,b.IVA,b.TOTAL,b.VR_IVA   from (ventacanastilla a join ventacanastillaitems b on (a.CONSECUTIVO= b.consecutivo))  join  articulo e on (b.cod_art= e.cod_art) where a.Consecutivo =" + Consecutivo);
                sql.Append(" order by FECHA asc");





                #endregion

                DataTable TablaDetalleVentasCombustible = new DataTable();

                TablaDetalleVentasCombustible.Columns.Add("Consecutivo", typeof(int));
                TablaDetalleVentasCombustible.Columns.Add("Fecha", typeof(DateTime));
                TablaDetalleVentasCombustible.Columns.Add("Hora", typeof(DateTime));
                TablaDetalleVentasCombustible.Columns.Add("Subtotal", typeof(decimal));
                TablaDetalleVentasCombustible.Columns.Add("TotalIva", typeof(decimal));
                TablaDetalleVentasCombustible.Columns.Add("Total", typeof(decimal));

                TablaDetalleVentasCombustible.Columns.Add("CodigoArticulo", typeof(int));
                TablaDetalleVentasCombustible.Columns.Add("Descripcion", typeof(string));
                TablaDetalleVentasCombustible.Columns.Add("Cantidad", typeof(decimal));
                TablaDetalleVentasCombustible.Columns.Add("PrecioUnitario", typeof(decimal));
                TablaDetalleVentasCombustible.Columns.Add("Iva", typeof(decimal));
                TablaDetalleVentasCombustible.Columns.Add("SubtotalD", typeof(decimal));
                TablaDetalleVentasCombustible.Columns.Add("IvaD", typeof(decimal));
                TablaDetalleVentasCombustible.Columns.Add("TotalD", typeof(decimal));
                TablaDetalleVentasCombustible.Columns.Add("TotalIvaD", typeof(decimal));

                #region Execute Sql
                dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);


                while (dr.Read())
                {
                    DataRow FilaVentaDetalladaCombustibles = TablaDetalleVentasCombustible.NewRow();

                    for (int i = 0; i < dr.FieldCount; i++)
                        FilaVentaDetalladaCombustibles[i] = dr.GetValue(i);

                    TablaDetalleVentasCombustible.Rows.Add(FilaVentaDetalladaCombustibles);

                }




                dr.Close();
                dr = null;
                sql = null;
                return TablaDetalleVentasCombustible;
                #endregion
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);

            }
        }
        #endregion
    }
}
