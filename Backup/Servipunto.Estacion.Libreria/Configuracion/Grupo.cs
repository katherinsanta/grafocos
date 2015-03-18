using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Grupo
	/// </summary>
	public class Grupo
	{
		#region Sección de Declaraciones
		private short _idGrupo;
		private string _nombre;
		private string _descripcion;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Grupo()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Grupo
		/// </summary>
		public short IdGrupo
		{
			get { return this._idGrupo; }
			set { this._idGrupo = value; }
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

			sql.Append("ModificarGrupo");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdGrupo", SqlDbType.SmallInt, this._idGrupo);
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
	}
}