using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Descripción breve de CuposCliente.
	/// </summary>
	public class CuposCliente : Servipunto.Libreria.Collection
	{
		#region Declarations
		private object _cod_Cli = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta todos los cupos existentes
		/// </summary>
		public CuposCliente() {}

		/// <summary>
		/// Consulta un cupo en particular.
		/// </summary>
		/// <param name="CodCliente">Codigo del cliente a consultarle el cupo.</param>
		public CuposCliente(string CodCliente){
			this._cod_Cli = CodCliente;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexes by pk
		/// </summary>
		new public CupoCliente this[string key]{
			get{ return (CupoCliente) base[key]; }
		}
		/// <summary>
		/// Indexes by cllection index
		/// </summary>
		new public CupoCliente this[int index]{
			get{ return (CupoCliente) base[index]; }
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
			sql.Append("CupoClientesQuery");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, this._cod_Cli);
			#endregion
		
			#region Execute sql Command
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read()){
				CupoCliente objCupoCliente = new CupoCliente();
				objCupoCliente.CodigoCliente = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();
				objCupoCliente.CupoAsignado = dr.IsDBNull(1)?(decimal)0:dr.GetDecimal(1);
				objCupoCliente.CupoDisponible = dr.IsDBNull(2)?(decimal)0:dr.GetDecimal(2);
				
				base.AddItem(objCupoCliente.CodigoCliente, objCupoCliente);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Inserta un cupo de Cliente en la DB.
		/// </summary>
		/// <param name="objCupoCliente"></param>
		public static void Adicionar(CupoCliente objCupoCliente){

			#region Prepare Sql
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CupoClientesInsertion");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, objCupoCliente.CodigoCliente);
			sql.AddParameter("@Cupo_Asig", SqlDbType.Decimal, objCupoCliente.CupoAsignado);
			sql.AddParameter("@Unidades", SqlDbType.VarChar, objCupoCliente.Unidades);
						 
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe cupo para el cliente " + objCupoCliente.CodigoCliente + " !ERROR BD! ");
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
		/// Elimina un cupo de Cliene de la DB
		/// </summary>
		/// <param name="CodCliente">codigo del cliente a Eliminarle cupo.</param>
		public static void Eliminar(string CodCliente) {
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("CupoClientesDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, CodCliente);	
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
		/// Metodo para obtener un cupo cliente en particular.
		/// </summary>
		/// <param name="CodCliente">Codigo del cliente a Consultarle el cupo</param>
		/// <returns>Datos del cupo si existe. Null si no.</returns>
		public static CupoCliente ObtenerItem(string CodCliente) {
			CuposCliente objCuposCliente = new CuposCliente(CodCliente);
			if (objCuposCliente.Count == 1)
				return objCuposCliente[0];
			else
				return null;
		}
		#endregion

	}
}
