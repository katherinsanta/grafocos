using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Grupos
	/// </summary>
	public class Grupos : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idGrupo = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los grupos configurados.
		/// </summary>
		public Grupos()
		{
		}

		/// <summary>
		/// Consulta de un grupo en particular.
		/// </summary>
		internal Grupos(short idGrupo)
		{
			this._idGrupo = idGrupo;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Grupo this[string key]
		{
			get { return (Grupo)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Grupo this[int index]
		{
			get { return (Grupo)base[index]; }
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

			sql.Append("ConsultarGrupos");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdGrupo", SqlDbType.SmallInt, this._idGrupo);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Grupo objGrupo = new Grupo();
				objGrupo.IdGrupo = dr.GetInt16(0);
				objGrupo.Nombre = dr.IsDBNull(1)?"(sin definir)":dr.GetString(1).Trim();
				objGrupo.Descripcion = dr.IsDBNull(2)?"":dr.GetString(2).Trim();
				
				base.AddItem(objGrupo.IdGrupo.ToString(), objGrupo);
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
		public static void Adicionar(Grupo objGrupo)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarGrupo");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdGrupo", SqlDbType.SmallInt, objGrupo.IdGrupo/*, ParameterDirection.InputOutput*/);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, objGrupo.Nombre);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, objGrupo.Descripcion);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				//objGrupo.IdGrupo = Convert.ToInt16(sql.Parameters[0].Value);
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
		public static void Eliminar(short idGrupo)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarGrupo");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdGrupo", SqlDbType.SmallInt, idGrupo);
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
		/// Método para obtener de manera directa un grupo en particular
		/// </summary>
		public static Grupo ObtenerItem(short idGrupo)
		{
			Grupos objElementos = new Grupos(idGrupo);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}