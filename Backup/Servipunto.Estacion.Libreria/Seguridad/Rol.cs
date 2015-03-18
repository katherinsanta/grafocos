using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Rol
	/// </summary>
	public class Rol
	{
		#region Sección de Declaraciones
		private byte _idRol;
		private string _nombre;

		private Permisos _permisos;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Rol()
		{
		}

        /// <summary>
        /// Destructor de la Clase
        /// </summary>
		~Rol()
		{
			this._permisos = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Código del Rol
		/// </summary>
		public byte IdRol
		{
			get { return this._idRol; }
			set { this._idRol = value; }
		}

		/// <summary>
		/// Nombre descriptivo
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}
		#endregion

		#region Permisos asociados al Rol
		/// <summary>
		/// Referencia a los permisos a los cuales tiene derecho el rol
		/// </summary>
		public Permisos Permisos
		{
			get
			{
				if (this._permisos == null)
					this._permisos = new Permisos(this._idRol);

				return this._permisos;
			}
		}
		#endregion

		#region Método Modificar
		/// <summary>
		/// Actualización de las propiedades: Nombre
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarRol");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdRol", SqlDbType.TinyInt, this._idRol);
			sql.AddParameter("@Rol", SqlDbType.VarChar, this._nombre);
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

	}
}