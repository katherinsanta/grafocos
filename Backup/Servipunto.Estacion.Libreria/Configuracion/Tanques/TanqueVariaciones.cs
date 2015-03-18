using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;


namespace Servipunto.Estacion.Libreria.Configuracion.Tanques
{
	/// <summary>
	/// Biblioteca de Colección Clases para la administracion de Variaciones de tanques
	/// </summary>
	public class TanqueVariaciones : Servipunto.Libreria.Collection 
	{

		#region Declarations
		private object _cod_Tan;
		private object _fecha;		
		#endregion

		#region Constructor
		/// <summary>
		/// Obtiene todas las variaciones de tanques
		/// </summary>
		public TanqueVariaciones() { }

		/// <summary>
		/// Recupera info. de la variacion de un tanque especifico.
		/// </summary>
		/// <param name="cod_Tan">Codigo del tanque</param>
		/// <param name="fecha">Fecha a Consultar</param>
		public TanqueVariaciones(int cod_Tan,DateTime fecha) 
		{
			this._cod_Tan = cod_Tan;
			this._fecha = fecha;			
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexa por llave
		/// </summary>
		new public TanqueVariacion this [string key] 
		{
			get { return (TanqueVariacion)base[key]; }
		}

		/// <summary>
		/// Indexa por Indice 
		/// </summary>
		new public TanqueVariacion this [int index] 
		{
			get { return (TanqueVariacion)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e) 
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarTanquesVariacion");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdTanque", SqlDbType.Int, this._cod_Tan);
			sql.AddParameter("@Fecha", SqlDbType.DateTime, this._fecha);

			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 0;
			while (dr.Read()) 
			{
				TanqueVariacion objTanqueVariacion = new TanqueVariacion();
				try	
				{
					objTanqueVariacion.CodigoTanque = dr.IsDBNull(0)?(int)0:(int)dr.GetInt16(0);ParamNumber++;
					objTanqueVariacion.Fecha = dr.IsDBNull(1)?DateTime.Parse("1900-01-01 "):dr.GetDateTime(1);ParamNumber++;
					objTanqueVariacion.SaldoInicial = dr.IsDBNull(2)?(Decimal)0:dr.GetDecimal(2);ParamNumber++;
					objTanqueVariacion.LecturaInicialAgua = dr.IsDBNull(3)?(Decimal)0:dr.GetDecimal(3);ParamNumber++;
					objTanqueVariacion.Compras = dr.IsDBNull(4)?(Decimal)0:dr.GetDecimal(4);ParamNumber++;
					objTanqueVariacion.SaldoFinal = dr.IsDBNull(5)?(Decimal)0:dr.GetDecimal(5);ParamNumber++;
                    objTanqueVariacion.Transito = dr.IsDBNull(6) ? (Decimal)0 : dr.GetDecimal(6); ParamNumber++;
                    objTanqueVariacion.CompraFactura = dr.IsDBNull(7) ? (Decimal)0 : dr.GetDecimal(7); ParamNumber++;

				}
				catch 
				{
					throw new Exception("(Configuracion.Tanques.Tanques.Load) Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString() );
				}
				try 
				{
					base.AddItem(objTanqueVariacion.CodigoTanque.ToString(), objTanqueVariacion);
				}
				catch 
				{
					throw new Exception("(Configuracion.Tanques.Tanques.Load) Error al agregar registro objeto objTanque !!" );
				}
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Permite Adicionar Tanque
		/// </summary>
		public static void Adicionar (TanqueVariacion objTanqueVariacion)
		{
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarTanqueVariacion");
			sql.ParametersNumber = 8;
			//sql.AddParameter("@Cod_Tan", SqlDbType.Int, objTanque.CodigoTanque);
			sql.AddParameter("@IdTanque", SqlDbType.Int, objTanqueVariacion.CodigoTanque);
			sql.AddParameter("@Fecha", SqlDbType.DateTime, objTanqueVariacion.Fecha);
			sql.AddParameter("@Saldo_Inicial", SqlDbType.Decimal, objTanqueVariacion.SaldoInicial);
			sql.AddParameter("@Lect_Inicial_Agua", SqlDbType.Decimal, objTanqueVariacion.LecturaInicialAgua);
			sql.AddParameter("@Compras", SqlDbType.Decimal, objTanqueVariacion.Compras);
			sql.AddParameter("@Saldo_Final", SqlDbType.Decimal, objTanqueVariacion.SaldoFinal);
            sql.AddParameter("@Transito", SqlDbType.Decimal, objTanqueVariacion.Transito);
            sql.AddParameter("@CompraFactura", SqlDbType.Decimal, objTanqueVariacion.CompraFactura);
           
			#endregion 

			#region Execute Sql command
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

		#region Delete
	/*	/// <summary>
		/// Permite eliminar un tanque especifico.
		/// </summary>
		/// <param name="cod_Tan">Codigo de tanque a eliminar</param>
		public static void Eliminar(int cod_Tan)
		{

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("TanquesDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Cod_Tan", SqlDbType.Int, cod_Tan);
			#endregion

			#region Execute Sql
			try 
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) 
			{
				throw new Exception(e.Message);
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}*/
		#endregion

		#region GetItem
		/// <summary>
		/// Metodo para obtener una variacion de un tanque.
		/// </summary>
		/// <param name="cod_Tan">Codigo del tanque a consultar</param>
		/// <param name="fecha">Fecha a consultar</param>
		/// <returns></returns>
		public static TanqueVariacion ObtenerItem(int cod_Tan,DateTime fecha) 
		{
			TanqueVariaciones objTanqueVariaciones = new TanqueVariaciones(cod_Tan,fecha);
			if (objTanqueVariaciones.Count == 1)
				return objTanqueVariaciones[0];
			else
				return null;
		}
		#endregion

		#region GetItems
		/// <summary>
		/// Metodo para obtener todos los tanques.
		/// </summary>
		/// <returns></returns>
		public static TanqueVariaciones ObtenerItems() 
		{
			TanqueVariaciones  objTanquVariaciones = new TanqueVariaciones();
			if (objTanquVariaciones.Count >= 1)
				return objTanquVariaciones;
			else
				return null;
		}
		#endregion

		#region RecuperarDatosEntradaVariacion
		/// <summary>
		/// Recupera los registros de variacion de todos los tanques en una determinada fecha
		/// </summary>
		/// <param name="fecha">Fecha a consultar</param>
		/// <returns>Retorna un dataSet con los registros de estrada de variacion consultados</returns>
		/// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
		/// Fecha:  03/09/2008
		/// Autor:  Elvis Astaiza Gutierrez
		public static DataSet RecuperarDatosEntradaVariacion(DateTime fecha) 
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
	
			sql.Append("RecuperarDatosEntradaVariacion"); 
			sql.ParametersNumber = 1;
			sql.AddParameter("@fecha", SqlDbType.DateTime, fecha);			
			#endregion

			#region Execute Sql
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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

		#region Reporte variacion o balance
		/// <summary>
		/// Reporte para variación mensual
		/// </summary>
		/// <param name="fechaInicial">Fecha inicial de la consulta</param>
		/// <param name="fechaFinal">Fecha Final de la consulta</param>
		/// <param name="idTanque">id del tanque a consultar, si son todos los tanques tanque = -1</param>		
		/// <param name="idArticulo">id del articulo a consultar, si son todos los articulos = -1</param>		
		/// <param name="gasOLiquido">False: Variacion, True: Balance</param>		
		/// <returns></returns>
		public static DataSet RptVariacionMensual(DateTime fechaInicial,DateTime fechaFinal, int idTanque, Int16 idArticulo, bool gasOLiquido) 
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
	
			sql.Append("RptTanqueVariacionMensaje");
			sql.ParametersNumber = 5;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);			
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal);
			sql.AddParameter("@GasOLiquido", SqlDbType.Bit, gasOLiquido);
			
			if(idTanque != -1)
				sql.AddParameter("@idTanque", SqlDbType.Int, idTanque);	
			if(idArticulo != -1)
				sql.AddParameter("@IdArticulo", SqlDbType.SmallInt, idArticulo);					
			#endregion

			#region Execute Sql
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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
