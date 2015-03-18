using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Estacion
	/// </summary>
	public class Estacion
	{
		#region Sección de Declaraciones
		private short _idEstacion;
		private string _nombre;
		private string _descripcion;

		private Islas _islas;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Estacion()
		{
		}

		/// <summary>
		/// Destructor de la clase
		/// </summary>
		~Estacion()
		{
			this._islas = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Estacion
		/// </summary>
		public short IdEstacion
		{
			get { return this._idEstacion; }
			set { this._idEstacion = value; }
		}

		/// <summary>
		/// Nombre descriptivo
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}

		/// <summary>
		/// Descripción
		/// </summary>
		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value; }
		}

		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: Nombre, Descripcion
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarEstacion");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdEstacion", SqlDbType.SmallInt, this._idEstacion);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, this._nombre);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, this._descripcion);
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

		#region Islas Configuradas
		/// <summary>
		/// Islas configuradas en la estación.
		/// </summary>
		public Islas Islas
		{
			get
			{
				if (this._islas == null)
					this._islas = new Islas(this._idEstacion, true, false);

				return this._islas;
			}
		}
		#endregion
	}
}