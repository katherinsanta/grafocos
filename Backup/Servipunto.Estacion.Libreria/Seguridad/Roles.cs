using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Administración de Roles de Usuario
	/// </summary>
	public class Roles : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idRol;
		#endregion

		#region Propiedades Públicas
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta general para recuperar todos los Roles
		/// </summary>
		public Roles()
		{
		}

		/// <summary>
		/// Consulta especifica de un Rol en particular.
		/// </summary>
		/// <param name="idRol">Código del Rol</param>
		public Roles(byte idRol)
		{
			this._idRol = idRol;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Rol this[string key]
		{
			get { return (Rol)base[key]; }
		}

		/// <summary>
		/// Indexador por Rol
		/// </summary>
		new public Rol this[int index]
		{
			get { return (Rol)base[index]; }
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

			sql.Append("RecuperarRol");			
			if (this._idRol != null)
			{
				sql.ParametersNumber = 1;
				sql.AddParameter("@IdRol", SqlDbType.TinyInt, this._idRol);
			}
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Rol objRol = new Rol();
				objRol.IdRol = dr.GetByte(0);
				objRol.Nombre = dr.GetString(1);

				base.AddItem(objRol.IdRol.ToString() , objRol);
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
		/// <param name="objRol">Instancia del objeto que contiene la información</param>
		public static void Adicionar(Rol objRol)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarRol");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, objRol.IdRol, System.Data.ParameterDirection.Output);
			sql.AddParameter("@Rol", SqlDbType.VarChar, objRol.Nombre);
			#endregion
			
			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				objRol.IdRol = Convert.ToByte(sql.Parameters[0].Value);
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
		/// Eliminación de un registro en la base de datos
		/// </summary>
		/// <param name="idRol">Código del Rol</param>
		public static void Remover(byte idRol)
		{				
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarRol");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, idRol);
			#endregion
			
			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.IndexOf("Usuario") != -1)
					throw new Exception("Existen usuarios asociados al perfil que desea eliminar.");
				else
					throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa un elemento en particular
		/// </summary>
		/// <param name="idRol">Código del Rol</param>
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static Rol Obtener(byte idRol)
		{
			Roles objElementos = new Roles(idRol);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region Método ObtenerRegistros
		/// <summary>
		/// Método para obtener de manera directa uno o varios elementos en particular
		/// </summary>
		/// <param name="objRol">Objeto con la informacion a filtrar</param>
		/// <returns>Retorna un dataset con los registros encontrados</returns>
		public static DataSet ObtenerRegistros(Rol objRol)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarRolDinamico");

			if(objRol != null)
			{
				sql.ParametersNumber = 2;
			
				if(objRol.IdRol > 0)
					sql.AddParameter("@IdRol", SqlDbType.TinyInt, objRol.IdRol);
 
				if(objRol.Nombre != null)
					if(objRol.Nombre.Trim().Length > 0)
						sql.AddParameter("@Rol", SqlDbType.VarChar, objRol.Nombre.Trim());

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
	}
}