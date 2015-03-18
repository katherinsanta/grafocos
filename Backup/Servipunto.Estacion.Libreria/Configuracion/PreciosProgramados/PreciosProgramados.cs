using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.PreciosProgramados
{
	/// <summary>
	/// Descripción breve de PreciosProgramados.
	/// </summary>
	public class PreciosProgramados : Servipunto.Libreria.Collection {
		
		#region Declarations
		private DateTime _date = new DateTime(1800,1,28);
		private object _cod_Art = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta todos los Precios Programados
		/// </summary>
		public PreciosProgramados()	{ }

		/// <summary>
		/// Consulta un precio programado especifico.
		/// </summary>
		/// <param name="date">Fecha para cambio de precio</param>
		/// <param name="cod_Art">Codigo del articulo del precio programado a consultar</param>
		public PreciosProgramados(DateTime date, int cod_Art){
			this._cod_Art = cod_Art;
			this._date = date;
		}

		/// <summary>
		/// Consulta todos los precios programados para una fecha especifica
		/// </summary>
		/// <param name="date"></param>
		public PreciosProgramados(DateTime date){
			this._date = date;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexa por llave
		/// </summary>
		new public PrecioProgramado this [string key] {
			get { return (PrecioProgramado)base[key]; }
		}

		/// <summary>
		/// Indexa por Indice 
		/// </summary>
		new public PrecioProgramado this [int index] {
			get { return (PrecioProgramado)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e) {	
	
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("PreciosProgramadosQuery");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Date", SqlDbType.VarChar, this._date.Year == 1800?null: this._date.ToString("yyyyMMdd"));
			sql.AddParameter("@Cod_Art", SqlDbType.Int, this._cod_Art);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 0;
			while (dr.Read()) {
				PrecioProgramado objPrecioProgramado = new PrecioProgramado();
				try{
					objPrecioProgramado.Fecha = dr.IsDBNull(0)?new DateTime(1800,1,28):dr.GetDateTime(0);ParamNumber++;
					objPrecioProgramado.CodigoArticulo = dr.IsDBNull(1)?(int)0:dr.GetInt32(1);ParamNumber++;
					objPrecioProgramado.NombreArticulo = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();ParamNumber++;
					objPrecioProgramado.PrecioArticulo = dr.IsDBNull(3)?(decimal)0:dr.GetDecimal(3);ParamNumber++;
					objPrecioProgramado.Precio2Articulo = dr.IsDBNull(4)?(decimal)0:dr.GetDecimal(4);ParamNumber++;
					objPrecioProgramado.Precio3Articulo = dr.IsDBNull(5)?(decimal)0:dr.GetDecimal(5);ParamNumber++;
					objPrecioProgramado.Precio4Articulo = dr.IsDBNull(6)?(decimal)0:dr.GetDecimal(6);ParamNumber++;
					objPrecioProgramado.EstadoProgramacion = dr.IsDBNull(7)?"(Sin Definir)":dr.GetString(7);ParamNumber++;
				}catch {
					throw new Exception("(Configuracion.PreciosProgramados.Load) Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString() );
				}
				try{
					base.AddItem(objPrecioProgramado.CodigoArticulo.ToString() + objPrecioProgramado.Fecha.ToString("yyyyMMdd"), objPrecioProgramado);
				}catch{
					throw new Exception("(Configuracion.PreciosProgramados.Load) Error al agregar registro objeto objPrecioProgramado !!" );
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
		/// Permite Adicionar PreciosProgramados
		/// </summary>
		public static void Adicionar (PrecioProgramado objPrecioProgramado) 
		{
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("PreciosProgramadosInsertion");
			sql.ParametersNumber = 6;
			sql.AddParameter("@Date", SqlDbType.VarChar, objPrecioProgramado.Fecha.ToString("yyyyMMdd"));
			sql.AddParameter("@Cod_Art", SqlDbType.Int, objPrecioProgramado.CodigoArticulo);
			sql.AddParameter("@Precio", SqlDbType.Decimal, objPrecioProgramado.PrecioArticulo);
			sql.AddParameter("@Precio2", SqlDbType.Decimal, objPrecioProgramado.Precio2Articulo);
			sql.AddParameter("@Precio3", SqlDbType.Decimal, objPrecioProgramado.Precio3Articulo);
			sql.AddParameter("@Precio4", SqlDbType.Decimal, objPrecioProgramado.Precio4Articulo);
			
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
		/// <summary>
		/// Elimina un Precio Programado de la DB
		/// </summary>
		/// <param name="date">Fecha del Precio Programado a eliminar</param>
		/// <param name="cod_Art">Codigo del articulo del precio programado a eliminar</param>
		public static void Eliminar(DateTime date, int cod_Art){

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("PreciosProgramadosDeletion");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Date", SqlDbType.VarChar, date.ToString("yyyyMMdd"));
			sql.AddParameter("@Cod_Art", SqlDbType.Int, cod_Art);
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

		#region GetItems
		/// <summary>
		/// Metodo para obtener todos los precios programados para una fecha en particular.
		/// </summary>
		/// <param name="date">Fecha del precio programado a consultar</param>
		/// <returns></returns>
		public static PreciosProgramados ObtenerItems(DateTime date) 
		{
			PreciosProgramados objPreciosProgramados = new PreciosProgramados(date);
			if (objPreciosProgramados.Count >= 1)
				return objPreciosProgramados;
			else
				return null;
		}
		#endregion

		#region GetItem
		/// <summary>
		/// Metodo para obtener un precio programado para una fecha y un articulo en particular.
		/// </summary>
		/// <param name="date">Fecha del precio programado a consultar</param>
		/// <param name="cod_Art">Codigo del articulo del precio programado a consultar</param>
		/// <returns></returns>
		public static PrecioProgramado ObtenerItem(DateTime date, int cod_Art) 
		{
			PreciosProgramados objPreciosProgramados = new PreciosProgramados(date, cod_Art);
			if (objPreciosProgramados.Count == 1)
				return objPreciosProgramados[0];
			else
				return null;
		}
		#endregion

   	}
}
