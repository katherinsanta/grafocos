using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Estaciones
	/// </summary>
	public class Estaciones : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idEstacion = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todas las estaciones configuradas.
		/// </summary>
		public Estaciones()
		{
		}

		/// <summary>
		/// Consulta de una estación en particular.
		/// </summary>
		internal Estaciones(short idEstacion)
		{
			this._idEstacion = idEstacion;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Estacion this[string key]
		{
			get { return (Estacion)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Estacion this[int index]
		{
			get { return (Estacion)base[index]; }
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

			sql.Append("ConsultarEstaciones");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdEstacion", SqlDbType.SmallInt, this._idEstacion);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Estacion objEstacion = new Estacion();
				objEstacion.IdEstacion = dr.GetInt16(0);
				objEstacion.Nombre =dr.GetString(1);
				objEstacion.Descripcion = dr.IsDBNull(2)?"":dr.GetString(2);
				
				base.AddItem(objEstacion.IdEstacion.ToString(), objEstacion);
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
		public static void Adicionar(Estacion objEstacion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarEstacion");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdEstacion", SqlDbType.SmallInt, objEstacion.IdEstacion/*, ParameterDirection.InputOutput*/);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, objEstacion.Nombre);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, objEstacion.Descripcion);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				//objEstacion.IdEstacion = Convert.ToInt16(sql.Parameters[0].Value);
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
		public static void Eliminar(short idEstacion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarEstacion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdEstacion", SqlDbType.SmallInt, idEstacion);
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
		public static Estacion ObtenerItem(short idEstacion)
		{
			Estaciones objElementos = new Estaciones(idEstacion);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}