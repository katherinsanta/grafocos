using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Islas.
	/// </summary>
	public class Islas : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idEstacion = null;
		private object _idIsla = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de islas por estación o una isla en particular.
		/// </summary>
		public Islas(short id, bool filtroEstacion, bool filtroIsla)
		{
			if (filtroEstacion)
				this._idEstacion = id;
			else
				this._idIsla = id;
		}

		/// <summary>
		/// Consulta todas las islas configuradas en la EDS.
		/// </summary>
		public Islas () {	}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Isla this[string key]
		{
			get { return (Isla)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Isla this[int index]
		{
			get { return (Isla)base[index]; }
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

			sql.Append("ConsultarIslas");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdEstacion", SqlDbType.SmallInt, this._idEstacion);
			sql.AddParameter("@IdIsla", SqlDbType.SmallInt, this._idIsla);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Isla objIsla = new Isla();
				objIsla.IdIsla = dr.GetInt16(0);
				objIsla.IdEstacion = dr.IsDBNull(1)?(short)0:dr.GetInt16(1);
				objIsla.Descripcion = dr.IsDBNull(2)?"":dr.GetString(2);
				
				base.AddItem(objIsla.IdIsla.ToString(), objIsla);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Adicionar
		/// <summary>
		/// Inserción de un registro en la base de datos.
		/// </summary>
		public static void Adicionar(Isla objIsla)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarIsla");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdIsla", SqlDbType.SmallInt, objIsla.IdIsla);
			sql.AddParameter("@IdEstacion", SqlDbType.SmallInt, objIsla.IdEstacion);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, objIsla.Descripcion);
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

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		public static void Eliminar(short idIsla)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarIsla");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdIsla", SqlDbType.SmallInt, idIsla);
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
		/// Método para obtener de manera directa una isla en particular.
		/// </summary>
		public static Isla ObtenerItem(short idIsla)
		{
			Islas objElementos = new Islas(idIsla, false, true);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region GetItems

		/// <summary>
		/// Obtiene TODAS las islas confiuradas
		/// </summary>
		/// <returns></returns>
		public static Islas ObtenerItems() {
			Islas objElementos = new Islas();
			if (objElementos.Count == 1)
				return objElementos;
			else
				return null;
		}

		#endregion

		#region IslaTurnosCerrados

		/// <summary>
		/// Obtiene TODAS las islas cuyos turno este abierto o cerrado dependiendo del criterio de busqueda
		/// <param name="codigoEstacion">Codigo de la estación</param>
		/// <param name="estado">Estado por el cual se desea buscar; Abierto "A" o Cerrado "C"</param>
		/// </summary>
		/// <returns></returns>
		public static DataSet IslaTurnosEstado(int codigoEstacion, string estado) 
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarIslaTurnoEstado");
			sql.ParametersNumber = 2;
			sql.AddParameter("@CodigoEstacion", SqlDbType.Int, codigoEstacion);
			sql.AddParameter("@Estado", SqlDbType.VarChar, estado);
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