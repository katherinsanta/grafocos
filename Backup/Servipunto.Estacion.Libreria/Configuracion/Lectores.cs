using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Lectores Configurados (Dallas Semiconductors).
	/// </summary>
	public class Lectores : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idLector = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los lectores configurados.
		/// </summary>
		public Lectores()
		{
		}

		/// <summary>
		/// Consulta de un lector en particular.
		/// </summary>
		internal Lectores(string idLector)
		{
			this._idLector = idLector;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Lector this[string key]
		{
			get { return (Lector)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Lector this[int index]
		{
			get { return (Lector)base[index]; }
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

			sql.Append("ConsultarLectores");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdLector", SqlDbType.VarChar, this._idLector);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Lector objLector = new Lector();
				objLector.IdLector = dr.GetString(0).Trim();
				objLector.IdPuerto = dr.GetString(1).Trim();
				objLector.IdInterfaz = dr.IsDBNull(2)?"":dr.GetString(2).Trim();
				objLector.Version = dr.GetInt16(3);
				objLector.Monitoreo = Convert.ToBoolean(dr.GetInt32(4));
				
				base.AddItem(objLector.IdLector, objLector);
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
		public static void Adicionar(Lector objLector)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarLector");
			sql.ParametersNumber = 5;
			sql.AddParameter("@IdLector", SqlDbType.VarChar, objLector.IdLector);
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, objLector.IdPuerto);
			sql.AddParameter("@IdInterfaz", SqlDbType.VarChar, objLector.IdInterfaz);
			sql.AddParameter("@Version", SqlDbType.SmallInt, objLector.Version);
			sql.AddParameter("@Monitoreo", SqlDbType.Bit, objLector.Monitoreo);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(/*Aplicacion.Conexion.ConnectionString*/Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.ToUpper().IndexOf("VIOLATION OF PRIMARY KEY") != -1)
					throw new Exception("Ya existe un lector identificado con el número " + objLector.IdLector + " !ERROR BD! ");
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

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		public static void Eliminar(string idLector)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarLector");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdLector", SqlDbType.VarChar, idLector);
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
		/// Método para obtener de manera directa un lector en particular
		/// </summary>
		public static Lector ObtenerItem(string idLector)
		{
			Lectores objElementos = new Lectores(idLector);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}