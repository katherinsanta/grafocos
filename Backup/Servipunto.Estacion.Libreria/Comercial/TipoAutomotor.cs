using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Clase para la administración de tipo de automotor
	/// </summary>
	public class TipoAutomotor
	{

		#region Declarations
		private string _tipoAutomotor;
		#endregion

		#region Constructor
		/// <summary>
		/// Tipo de automotor
		/// </summary>
		public TipoAutomotor(){ }
		#endregion

		#region Public Properties
		/// <summary>
		/// Nombre del tipo de automotor
		/// </summary>
		public string NombreTipoAutomotor
		{
			get{ return this._tipoAutomotor; }
			set{ this._tipoAutomotor = value;}
		}
		#endregion

		#region Modificar
		/// <summary>
		/// Permite actualizar los tipos de Automotor en la tabla auto_tipo
		/// </summary>
		public void Modificar ()
		{

			#region Prepare SqlStatement
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ModificarTipoAutomotor");
			sql.ParametersNumber = 1;
			sql.AddParameter("@TipoAutomotor", SqlDbType.VarChar, this._tipoAutomotor);
			#endregion

			#region Execute SqlStatement
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch(SqlException exx)
			{
				throw new Exception(exx.Message + " !ERROR BD! ");
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
