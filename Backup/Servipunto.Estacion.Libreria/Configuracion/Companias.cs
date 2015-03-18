using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Companias
	/// </summary>
	public class Companias : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idCompania = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos las compañías configuradas.
		/// </summary>
		public Companias()
		{
		}

		/// <summary>
		/// Consulta de una compañía en particular.
		/// </summary>
		internal Companias(short idCompania)
		{
			this._idCompania = idCompania;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Compania this[string key]
		{
			get { return (Compania)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Compania this[int index]
		{
			get { return (Compania)base[index]; }
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

			sql.Append("ConsultarCompanias");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdCompania", SqlDbType.SmallInt, this._idCompania);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Compania objCompania = new Compania();
				objCompania.IdCompania = dr.GetInt16(0);
				objCompania.Nombre = dr.GetString(1).Trim();
				objCompania.Descripcion = dr.IsDBNull(2)?"":dr.GetString(2).Trim();
				
				base.AddItem(objCompania.IdCompania.ToString(), objCompania);
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
		public static void Adicionar(Compania objCompania)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarCompania");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdCompania", SqlDbType.SmallInt, objCompania.IdCompania/*, ParameterDirection.InputOutput*/);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, objCompania.Nombre);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, objCompania.Descripcion);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				//objCompania.IdCompania = Convert.ToInt16(sql.Parameters[0].Value);
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
		public static void Eliminar(short idCompania)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarCompania");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdCompania", SqlDbType.SmallInt, idCompania);
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
		/// Método para obtener de manera directa una compañía en particular
		/// </summary>
		public static Compania ObtenerItem(short idCompania)
		{
			Companias objElementos = new Companias(idCompania);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}