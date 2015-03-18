using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Colección de Ciudades
	/// </summary>
	public class Ciudades : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idDepartamento;
		private object _idCiudad;

		#endregion

		#region Constructor
		/// <summary>
		/// Constructor para filtrar los datos por Departamento
		/// </summary>
		/// <param name="idDepartamento">Código del Departamento</param>
		public Ciudades(int idDepartamento)
		{
			this._idDepartamento = idDepartamento;
		}

		/// <summary>
		/// Constructor para recuperar una Ciudad en particular
		/// </summary>
		/// <param name="idCiudad">Código de la Ciudad</param>
		public Ciudades(string idCiudad)
		{
			this._idCiudad = idCiudad;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Ciudad this[string key]
		{
			get { return (Ciudad)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Ciudad this[int index]
		{
			get { return (Ciudad)base[index]; }
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

			sql.Append("RecuperarCiudad");
			if (this._idCiudad != null)
			{
				sql.ParametersNumber = 2;
				sql.AddParameter("@IdCiudad", SqlDbType.VarChar, this._idCiudad);
				sql.AddParameter("@IdDepartamento", SqlDbType.Int, null);
			}
			else if (this._idDepartamento != null)
			{
				sql.ParametersNumber = 2;
				sql.AddParameter("@IdCiudad", SqlDbType.VarChar, null);
				sql.AddParameter("@IdDepartamento", SqlDbType.Int, this._idDepartamento);
			}
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Ciudad objCiudad = new Ciudad();
				objCiudad.IdCiudad = dr.GetString(0);
				objCiudad.IdDepartamento = dr.GetInt32(1);
				objCiudad.Nombre = dr.GetString(2);
				objCiudad.Codigo = dr.IsDBNull(3)?"":dr.GetString(3);
				objCiudad.IdPais = dr.IsDBNull(4)?0:dr.GetInt32(4);

				base.AddItem(objCiudad.IdCiudad, objCiudad);
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
		/// <param name="objCiudad">Instancia del objeto que contiene la información</param>
		public static void Adicionar(Ciudad objCiudad)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarCiudad");
			sql.ParametersNumber = 4;
			if (objCiudad.IdCiudad == "0")
				sql.AddParameter("@IdCiudad", SqlDbType.VarChar, objCiudad.IdCiudad, System.Data.ParameterDirection.Output);
			else
				sql.AddParameter("@IdCiudad", SqlDbType.VarChar, objCiudad.IdCiudad);
			sql.AddParameter("@IdDepartamento", SqlDbType.Int, objCiudad.IdDepartamento);
			sql.AddParameter("@Ciudad", SqlDbType.VarChar, objCiudad.Nombre);
			sql.AddParameter("@CodigoCiudad", SqlDbType.VarChar, objCiudad.Codigo);
			#endregion
			
			#region Execute Sql
			try
			{
				Aplicacion.Conexion.BeginTransaction();
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.SqlTransaction, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				objCiudad.IdCiudad = Convert.ToString(sql.Parameters[0].Value);
				Aplicacion.Conexion.CommitTransaction();
			}
			catch (SqlException e)
			{
				Aplicacion.Conexion.RollbackTransaction();
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
		/// <param name="idCiudad">Código de la Ciudad</param>
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static Ciudad Obtener(string idCiudad)
		{
			Ciudades objElementos = new Ciudades(idCiudad);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region Método Remover
		/// <summary>
		/// Eliminación de un registro en la base de datos
		/// </summary>
		/// <param name="idCiudad">Código de la Ciudad</param>
		public static void Remover(string idCiudad)
		{
			Ciudad objCiudad= null;
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarCiudad");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdCiudad", SqlDbType.Int, idCiudad);
			#endregion
			
			#region Execute Sql
			try
			{
				objCiudad= Ciudades.Obtener(idCiudad);

				Aplicacion.Conexion.BeginTransaction();
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.SqlTransaction, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				Aplicacion.Conexion.CommitTransaction();
			}
			catch (SqlException e)
			{
				Aplicacion.Conexion.RollbackTransaction();
				if (e.Message.IndexOf("Ciudad") != -1)
					throw new Exception("Existen Departamentos asociados a la Ciudad que desea eliminar.");
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
	}
}