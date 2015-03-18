using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.Tanques
{
	/// <summary>
	/// Biblioteca de Colección de Clases para la administracion de Tanques
	/// </summary>
	public class Tanques : Servipunto.Libreria.Collection {

		#region Declarations
		private object _cod_Tan;
		#endregion

		#region Constructor
		/// <summary>
		/// Obtiene todos los tanques
		/// </summary>
		public Tanques() { }

		/// <summary>
		/// Recupera info. de un tanque especifico.
		/// </summary>
		/// <param name="cod_Tan">Codigo del tanque</param>
		public Tanques(int cod_Tan) {
			this._cod_Tan = cod_Tan;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexa por llave
		/// </summary>
		new public Tanque this [string key] 
		{
			get { return (Tanque)base[key]; }
		}

		/// <summary>
		/// Indexa por Indice 
		/// </summary>
		new public Tanque this [int index] 
		{
			get { return (Tanque)base[index]; }
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

			sql.Append("TanquesQuery");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Cod_Tan", SqlDbType.Int, this._cod_Tan);
			#endregion

			#region Execute Sql
				dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 0;
			while (dr.Read()) {
				Tanque objTanque = new Tanque();
				try	{
					objTanque.CodigoTanque = dr.IsDBNull(0)?(int)0:(int)dr.GetInt16(0);ParamNumber++;
					objTanque.CapacidadTanque = dr.IsDBNull(1)?(int)0:dr.GetDecimal(1);ParamNumber++;
					objTanque.CodigoArticulo = dr.IsDBNull(2)?(int)-1:int.Parse(dr.GetValue(2).ToString());ParamNumber++;
					objTanque.ConvierteLitrosAGalones = dr.IsDBNull(3)?(byte)0:dr.GetByte(3);ParamNumber++;
					objTanque.GasOLiquido = dr.IsDBNull(4)?false:dr.GetBoolean(4);ParamNumber++;					
				}
				catch {
					throw new Exception("(Configuracion.Tanques.Tanques.Load) Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString() );
				}
				try {
					base.AddItem(objTanque.CodigoTanque.ToString(), objTanque);
				}
				catch {
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
		public static void Adicionar (Tanque objTanque){
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("TanquesInsertion");
			sql.ParametersNumber = 4;
			//sql.AddParameter("@Cod_Tan", SqlDbType.Int, objTanque.CodigoTanque);
			sql.AddParameter("@Capacidad", SqlDbType.Decimal, objTanque.CapacidadTanque);
			sql.AddParameter("@Cod_art", SqlDbType.Decimal, objTanque.CodigoArticulo);
			sql.AddParameter("@ConvierteLitrosAGalones", SqlDbType.TinyInt, objTanque.ConvierteLitrosAGalones);
			sql.AddParameter("@GasOLiquido", SqlDbType.Bit, objTanque.GasOLiquido);
			#endregion 

			#region Execute Sql command
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}catch (SqlException e) {
				throw new Exception(e.Message + " !ERROR BD! ");
			}finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Delete
		/// <summary>
		/// Permite eliminar un tanque especifico.
		/// </summary>
		/// <param name="cod_Tan">Codigo de tanque a eliminar</param>
		public static void Eliminar(int cod_Tan){

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("TanquesDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Cod_Tan", SqlDbType.Int, cod_Tan);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}catch (SqlException e) {
				throw new Exception(e.Message + " !ERROR BD! ");
			}finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region GetItem
		/// <summary>
		/// Metodo para obtener un tanque.
		/// </summary>
		/// <param name="cod_Tan">Codigo del tanque a consultar</param>
		/// <returns></returns>
		public static Tanque ObtenerItem(int cod_Tan) {
			Tanques objTanques = new Tanques(cod_Tan);
			if (objTanques.Count == 1)
				return objTanques[0];
			else
				return null;
		}
		#endregion

		#region GetItems
		/// <summary>
		/// Metodo para obtener todos los tanques.
		/// </summary>
		/// <returns></returns>
		public static Tanques ObtenerItems() {
			Tanques objTanques = new Tanques();
			if (objTanques.Count >= 1)
				return objTanques;
			else
				return null;
		}
		#endregion

		#region Reporte inicial y final del estado de tanques en una apertura Z o cierre Z
		/// <summary>
		/// Reporte inicial y final del estado de tanques en una apertura Z o cierre Z
		/// <param name="opcion">1: Para inicio repote de apertura, 2: Para reporte de salida</param>
		/// </summary>
		public static DataSet RptTanquesEstado(int opcion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RptTanquesEstado");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Opcion", SqlDbType.Int, opcion);
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

	}
}
