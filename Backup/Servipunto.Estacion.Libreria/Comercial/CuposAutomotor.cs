using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Descripción breve de CuposAutomotor.
	/// </summary>
	public class CuposAutomotor : Servipunto.Libreria.Collection
	{
		#region Declarations
		private object _placa = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta todos los cupos
		/// </summary>
		public CuposAutomotor()	{}

		/// <summary>
		/// Consulta un cupo en particular.
		/// </summary>
		/// <param name="Placa">Placa a consultarle el cupo.</param>
		public CuposAutomotor(string Placa){
			this._placa = Placa;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexes by pk
		/// </summary>
		new public CupoAutomotor this[string key]{
			get{ return (CupoAutomotor) base[key]; }
		}
		/// <summary>
		/// Indexes by cllection index
		/// </summary>
		new public CupoAutomotor this[int index]{
			get{ return (CupoAutomotor) base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e) {

			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CupoAutomotoresQuery");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			#endregion
		
			#region Execute sql Command
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read()){
				CupoAutomotor objCupoAutomotor = new CupoAutomotor();
				objCupoAutomotor.PlacaAutomotor = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();
				objCupoAutomotor.CupoAsignado = dr.IsDBNull(1)?(decimal)0:dr.GetDecimal(1);
				objCupoAutomotor.CupoDisponible = dr.IsDBNull(2)?(decimal)0:dr.GetDecimal(2);
				try {
					base.AddItem(objCupoAutomotor.PlacaAutomotor, objCupoAutomotor);
				}catch(Exception) { /*Element already added to collection*/ }
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Inserta un cupo de automotor en la DB.
		/// </summary>
		/// <param name="objCupoAutomotor">Objeto tipo CupoAutomotor con la informacion a insertar en la DB</param>
		public static void Adicionar(CupoAutomotor objCupoAutomotor){

			#region Prepare Sql
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CupoAutomotoresInsertion");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Placa", SqlDbType.VarChar, objCupoAutomotor.PlacaAutomotor);
			sql.AddParameter("@Cupo_Asig", SqlDbType.Decimal, objCupoAutomotor.CupoAsignado);
			sql.AddParameter("@Unidades", SqlDbType.VarChar, objCupoAutomotor.Unidades);
						
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe cupo para el Automotor " + objCupoAutomotor.PlacaAutomotor + " !ERROR BD! ");
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
		/// Elimina un cupo de automotor de la DB
		/// </summary>
		/// <param name="Placa">Placa del automotor a Eliminarle cupo.</param>
		public static void Eliminar(string Placa) {
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("CupoAutomotoresDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Placa", SqlDbType.VarChar, Placa);	
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
		/// Metodo para obtener un cupo automotor en particular.
		/// </summary>
		/// <param name="Placa">Placa del Automotor a Consultarle el cupo</param>
		/// <returns>Datos del cupo si existe. Null si no.</returns>
		public static CupoAutomotor ObtenerItem(string Placa) {
			CuposAutomotor objCuposAutomotor = new CuposAutomotor(Placa);
			if (objCuposAutomotor.Count == 1)
				return objCuposAutomotor[0];
			else
				return null;
		}
		#endregion

	}
}
