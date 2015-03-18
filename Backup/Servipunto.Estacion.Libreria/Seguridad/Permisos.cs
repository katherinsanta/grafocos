using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Set de Permisos Asociados a un Rol
	/// </summary>
	public class Permisos : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private byte _idRol;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		/// <param name="idRol">Código del Rol</param>
		internal Permisos(byte idRol)
		{
			this._idRol = idRol;
		}		
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Permiso this[string key]
		{
			get { return (Permiso)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Permiso this[int index]
		{
			get { return (Permiso)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección
		/// </summary>		
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarPermiso");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, this._idRol);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Permiso objPermiso = new Permiso();
				objPermiso.IdRol = dr.GetByte(0);
				objPermiso.IdModulo = dr.GetString(1);
				objPermiso.IdOpcion = dr.GetString(2);
				objPermiso.IdAccion = dr.GetString(3);
				objPermiso.Descripcion = dr.GetString(4);

				base.AddItem(objPermiso.IdModulo + "@" + objPermiso.IdOpcion + "@" + objPermiso.IdAccion, objPermiso);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Método Adicionar
		/// <summary>
		/// Inserción de un registro en la base de datos
		/// </summary>
		public void Adicionar(string idModulo, string idOpcion, string idAccion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarPermiso");
			sql.ParametersNumber = 4;
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, this._idRol);
			sql.AddParameter("@IdModulo", SqlDbType.VarChar, idModulo);
			sql.AddParameter("@IdOpcion", SqlDbType.VarChar, idOpcion);
			sql.AddParameter("@IdAccion", SqlDbType.VarChar, idAccion);			
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

		#region Método Remover
		/// <summary>
		/// Eliminación de todos los permisos asociados a una Opción en particular
		/// </summary>
		public void Remover(string idModulo, string idOpcion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarPermiso");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, this._idRol);
			sql.AddParameter("@IdModulo", SqlDbType.VarChar, idModulo);
			sql.AddParameter("@IdOpcion", SqlDbType.VarChar, idOpcion);
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

		#region Método RemoverTodo
		/// <summary>
		/// Eliminación de todos los permisos asociados a al Rol
		/// </summary>
		public void RemoverTodo()
		{				
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarPermiso");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, this._idRol);
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

		#region Método Verificar
		/// <summary>
		/// Método utilizado para verificar si un permiso esta o no asignado al Rol del Usuario autenticado
		/// </summary>
		/// <param name="idModulo">Código del Módulo</param>
		/// <param name="idOpcion">Código de la Opción</param>
		/// <param name="idAccion">Código de la Acción</param>
		/// <returns>True, si el usuario tiene permiso ó False, en caso contrario</returns>
		public bool Verificar(string idModulo, string idOpcion, string idAccion)
		{
			if (this._idRol != 0)
			{
				foreach (Permiso objPermiso in this)
				{
					if (objPermiso.IdModulo == idModulo && objPermiso.IdOpcion == idOpcion && objPermiso.IdAccion == idAccion)
						return true;
				}
				return false;
			}
			else
			{
				return true;
//				if (idModulo == "Panel de Control")
//				{
//					if (idOpcion == "Usuarios" || idOpcion == "Roles" || idOpcion == "Companias")
//						return true;
//					else
//						return false;
//				}
//				else
//					return false;
			}			
		}
		#endregion

		#region Método AsignarTodo
		/// <summary>
		/// Asignación de todos los permisos asociados a al Rol
		/// </summary>
		public void AsignarTodo()
		{
			this.RemoverTodo();

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("Insert Into Permiso (IdRol, IdModulo, IdOpcion, IdAccion) Select @IdRol, IdModulo, IdOpcion, IdAccion From Accion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, this._idRol);
			#endregion
			
			#region Execute Sql
			try
			{
				if (Aplicacion.Conexion.SqlTransaction == null)
					SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
				else
					SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.SqlTransaction, CommandType.Text, sql.Text, sql.Parameters);
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