using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Colección de Departamentos
	/// </summary>
	public class Departamentos : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idDepartamento = null;
		private object _idPais = null;
		private string _idCiudad = null;

		#endregion

		#region Propiedades Públicas

		/// <summary>
		/// Filtro para recuperar un Departamento en particular
		/// </summary>
		public int IdDepartamento
		{
			set { this._idDepartamento = value; }
		}

		/// <summary>
		/// Filtro para recuperar un Departamento en particular
		/// </summary>
		public string IdCiudad
		{
			set { this._idCiudad = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public Departamentos(int idPais)
		{
			this._idPais = idPais;
		}	
	
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public Departamentos()
		{
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Departamento this[string key]
		{
			get { return (Departamento)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Departamento this[int index]
		{
			get { return (Departamento)base[index]; }
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

			sql.Append("RecuperarDepartamento");

			sql.ParametersNumber = 3;
			sql.AddParameter("@IdDepartamento", SqlDbType.Int, this._idDepartamento);
			sql.AddParameter("@IdCiudad", SqlDbType.VarChar, this._idCiudad);
			sql.AddParameter("@IdPais", SqlDbType.Int, this._idPais);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Departamento objDepartamento = new Departamento();
				objDepartamento.IdDepartamento = dr.GetInt32(0);
				objDepartamento.IdPais = dr.GetInt32(1);
				objDepartamento.Nombre = dr.GetString(2);
				objDepartamento.Codigo = dr.IsDBNull(3)?"":dr.GetString(3);

				base.AddItem(objDepartamento.IdDepartamento.ToString(), objDepartamento);
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
		/// <param name="objDepartamento">Instancia del objeto que contiene la información</param>
		public static void Adicionar(Departamento objDepartamento)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarDepartamento");
			sql.ParametersNumber = 4;
			if (objDepartamento.IdDepartamento == 0)
				sql.AddParameter("@IdDepartamento", SqlDbType.Int, objDepartamento.IdDepartamento, System.Data.ParameterDirection.Output);
			else
				sql.AddParameter("@IdDepartamento", SqlDbType.Int, objDepartamento.IdDepartamento);
			sql.AddParameter("@IdPais", SqlDbType.Int, objDepartamento.IdPais);
			sql.AddParameter("@Departamento", SqlDbType.VarChar, objDepartamento.Nombre);
			sql.AddParameter("@CodigoDepartamento", SqlDbType.VarChar, objDepartamento.Codigo);
			#endregion
			
			#region Execute Sql
			try
			{
				Aplicacion.Conexion.BeginTransaction();
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.SqlTransaction, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				objDepartamento.IdDepartamento = Convert.ToInt32(sql.Parameters[0].Value);
				Aplicacion.Conexion.CommitTransaction();
			}
			catch (SqlException e)
			{
				Aplicacion.Conexion.RollbackTransaction();
				throw new Exception(e.Message + " !ERROR BD! " + " !ERROR BD! ");
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
		/// <param name="idDepartamento">Código del Departamento</param>
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static Departamento Obtener(int idDepartamento)
		{
			Departamentos objElementos = new Departamentos();
			objElementos.IdDepartamento = idDepartamento;
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
		/// <param name="idDepartamento">Código del Departamento</param>
		public static void Remover(int idDepartamento)
		{
			Departamento objDepartamento = null;
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarDepartamento");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdDepartamento", SqlDbType.Int, idDepartamento);
			#endregion
			
			#region Execute Sql
			try
			{
				objDepartamento= Departamentos.Obtener(idDepartamento);

				Aplicacion.Conexion.BeginTransaction();
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.SqlTransaction, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				Aplicacion.Conexion.CommitTransaction();
			}
			catch (SqlException e)
			{
				Aplicacion.Conexion.RollbackTransaction();
				if (e.Message.IndexOf("Departamento") != -1)
					throw new Exception("Existen países asociados al Departamento que desea eliminar." + " !ERROR BD! ");
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