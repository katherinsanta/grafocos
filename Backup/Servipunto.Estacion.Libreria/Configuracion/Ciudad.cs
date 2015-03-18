using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Ciudad
	/// </summary>
	public class Ciudad
	{
		#region Sección de Declaraciones
		private string _idCompania;
		private string _idCiudad;
		private int _idDepartamento;
		private string _nombre;
		private string _codigo;
		private int _idPais;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Ciudad()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// IDCompania
		/// </summary>
		public string IdCompania
		{
			get { return this._idCompania; }
			set { this._idCompania = value; }
		}

		/// <summary>
		/// Código de la Ciudad
		/// </summary>
		public string IdCiudad
		{
			get { return this._idCiudad; }
			set { this._idCiudad = value; }
		}

		/// <summary>
		/// Código del Departamento
		/// </summary>
		public int IdDepartamento
		{
			get { return this._idDepartamento; }
			set { this._idDepartamento = value; }
		}

		/// <summary>
		/// Código del País
		/// </summary>
		public int IdPais
		{
			get { return this._idPais; }
			set { this._idPais = value; }
		}

		/// <summary>
		/// Nombre Descriptivo
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}

		/// <summary>
		/// Codigo Ciudad
		/// </summary>
		public string Codigo
		{
			get { return this._codigo; }
			set { this._codigo = value; }
		}
		#endregion
		
		#region Método Modificar
		/// <summary>
		/// Actualización en la base de datos la propiedad: Nombre
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarCiudad");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdCiudad", SqlDbType.Int, this._idCiudad);
			sql.AddParameter("@Ciudad", SqlDbType.VarChar, this._nombre);
			sql.AddParameter("@CodigoCiudad", SqlDbType.VarChar, this._codigo);
			#endregion

			#region Execute Sql
			try
			{
				Aplicacion.Conexion.BeginTransaction();
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.SqlTransaction, CommandType.StoredProcedure, sql.Text, sql.Parameters);
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


	}
}