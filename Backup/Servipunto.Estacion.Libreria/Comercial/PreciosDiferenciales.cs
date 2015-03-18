using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial {
	/// <summary>
	/// Summary description for PreciosDiferenciales.
	/// </summary>
	public class PreciosDiferenciales : Servipunto.Libreria.Collection {

		#region Declarations
		private object _idPrecio;
		private object _cod_Art;
		private int sw = 0;
		#endregion

		#region Constructor

		/// <summary>
		/// Consulta todas las listas de precios configuradas.
		/// </summary>
		public PreciosDiferenciales() {
			this.sw = 1;
		}

		/// <summary>
		/// Consulta una lista especifica de precios diferenciales.
		/// </summary>
		/// <param name="IdPrecio">Id De la Lista de precios.</param>
		public PreciosDiferenciales(int IdPrecio) {
			this._idPrecio = IdPrecio;
		}


		/// <summary>
		/// Consulta un precio diferencial de un articulo especifico dentro de una lista especifica.
		/// </summary>
		/// <param name="IdPrecio"></param>
		/// <param name="Cod_Art"></param>
		public PreciosDiferenciales(int IdPrecio, int Cod_Art) {
			this._idPrecio = IdPrecio;
			this._cod_Art = Cod_Art;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Index by Key
		/// </summary>
		new public PrecioDiferencial this[string key]{
			get{ return (PrecioDiferencial) base[key]; }
		}

		/// <summary>
		/// Index by cllection index
		/// </summary>
		new public PrecioDiferencial this[int index] {
			get { return (PrecioDiferencial) base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e) {
		
			#region Prepare SqlStatement
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ListaPreciosQuery");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdPrecio", SqlDbType.Int, this._idPrecio);
			sql.AddParameter("@Cod_Art", SqlDbType.Int, this._cod_Art);
			#endregion

			#region Execute SqlStatement
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 0;
			while (dr.Read()){
				PrecioDiferencial objPrecioDiferencial = new PrecioDiferencial();
				try{
					objPrecioDiferencial.IdPrecioDiferencial = dr.IsDBNull(0)?(int)0:dr.GetInt32(0);ParamNumber++;
					if(this.sw == 0){
						objPrecioDiferencial.CodigoArticulo = dr.IsDBNull(1)?(int)0:(int)dr.GetInt16(1);ParamNumber++;
						objPrecioDiferencial.NombreArticulo = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();ParamNumber++;
						objPrecioDiferencial.PrecioDiferencialArticulo = dr.IsDBNull(3)?(decimal)0:dr.GetDecimal(3);ParamNumber++;
					}
				}catch {
					throw new Exception("(Servipunto.Estacion.Libreria.Comercial.PreciosDiferenciales.Load) Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString() );
				}
				try{
					base.AddItem(objPrecioDiferencial.IdPrecioDiferencial.ToString() + objPrecioDiferencial.CodigoArticulo.ToString(), objPrecioDiferencial);
				}catch{
					throw new Exception("(Servipunto.Estacion.Libreria.Comercial.PreciosDiferenciales.Load) Error al agregar registro objeto objPrecioDiferencial " );
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
		/// Inserta lista de precios diferenciales en la DB.
		/// </summary>
		/// <param name="objPrecioDiferencial"></param>
		public static void Adicionar(PrecioDiferencial objPrecioDiferencial){

			#region Prepare Sql
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ListaPreciosInsertion");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdPrecio", SqlDbType.Int, objPrecioDiferencial.IdPrecioDiferencial);
			sql.AddParameter("@Cod_Art", SqlDbType.Int, objPrecioDiferencial.CodigoArticulo);
			sql.AddParameter("@Precio", SqlDbType.Decimal, objPrecioDiferencial.PrecioDiferencialArticulo);			
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe el precio diferencial "  + " !ERROR BD! ");
				else
					throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Delete
		/// <summary>
		/// Permite eleminar precio diferencial de un articulo dentro de una lista
		/// </summary>
		/// <param name="IdPrecio">Id de la lista de precio</param>
		/// <param name="Cod_Art">Codigo del articulo</param>
		public static void Eliminar(int IdPrecio, int Cod_Art) {
						
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ListaPreciosDeletion");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdPrecio", SqlDbType.Int, IdPrecio);	
			sql.AddParameter("@Cod_Art", SqlDbType.Int, Cod_Art);
			#endregion

			#region Execute Sql
			try {
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

		/// <summary>
		/// Elimina toda una lista de precios diferenciales.
		/// </summary>
		/// <param name="IdPrecio">Lista a eliminar.</param>
		public static void Eliminar(int IdPrecio) {
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ListaPreciosDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdPrecio", SqlDbType.Int, IdPrecio);				
			#endregion

			#region Execute Sql
			try {
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

		#region GetItem
		/// <summary>
		/// Metodo para obtener un precio diferencial de un articulo en una lista de precios especifico.
		/// </summary>
		/// <param name="IdPrecio">Id lista de precio a consultar</param>
		/// <param name="Cod_Art">Codigo de articulo a consultar</param>
		/// <returns></returns>
		public static PrecioDiferencial ObtenerItem(int IdPrecio, int Cod_Art) {
			PreciosDiferenciales objPreciosDiferenciales = new PreciosDiferenciales(IdPrecio, Cod_Art);
			if (objPreciosDiferenciales.Count == 1)
				return objPreciosDiferenciales[0];
			else
				return null;
		}
		#endregion

		#region GetItems
		/// <summary>
		/// Metodo para todos los precios de una lista especifica.
		/// </summary>
		/// <param name="IdPrecio">Id lista de precio a consultar</param>
		/// <returns></returns>
		public static PreciosDiferenciales ObtenerItems(int IdPrecio) {
			PreciosDiferenciales objPreciosDiferenciales = new PreciosDiferenciales(IdPrecio);
			if (objPreciosDiferenciales.Count > 0)
				return objPreciosDiferenciales;
			else
				return null;
		}
		#endregion


	}
}
