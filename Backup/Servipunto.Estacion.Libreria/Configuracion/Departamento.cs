using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Departamento
	/// </summary>
	public class Departamento
	{
		#region Sección de Declaraciones
		private string _idCompania;
		private int _idDepartamento;
		private int _idPais;
		private string _nombre;
		private string _codigo;

		private Ciudades _ciudades;		
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Departamento()
		{
		}

		/// <summary>
		/// Destructor de la Clase
		/// </summary>
		~Departamento()
		{
			this._ciudades = null;
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
		/// Código del Departamento
		/// </summary>
		public int IdDepartamento
		{
			get { return this._idDepartamento; }
			set { this._idDepartamento = value; }
		}

		/// <summary>
		/// Código del Pais
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
		/// Codigo Departamento
		/// </summary>
		public string Codigo
		{
			get { return this._codigo; }
			set { this._codigo = value; }
		}

		/// <summary>
		/// Ciudades pertenecientes al departamento
		/// </summary>
		public Ciudades Ciudades
		{
			get
			{
				if (this._ciudades == null)
					this._ciudades = new Ciudades(this._idDepartamento);

				return this._ciudades;
			}
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

			sql.Append("ModificarDepartamento");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdDepartamento", SqlDbType.Int, this._idDepartamento);
			sql.AddParameter("@Departamento", SqlDbType.VarChar, this._nombre);
			sql.AddParameter("@CodigoDepartamento", SqlDbType.VarChar, this._codigo);
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