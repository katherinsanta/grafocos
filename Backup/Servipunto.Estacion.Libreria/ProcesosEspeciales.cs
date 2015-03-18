using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Procesos Especiales.
	/// </summary>
	public class ProcesosEspeciales
	{
		#region Constructor
		internal ProcesosEspeciales()
		{
		}
		#endregion

		#region ActualizarNit
		/// <summary>
		/// Actualización de Nit a un rango de ventas.
		/// </summary>
		public static void ActualizarNit(string nit)
		{
//			#region Prepare Sql Command
//			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
//
//			sql.Append("EliminarArticulo");
//			sql.ParametersNumber = 1;
//			sql.AddParameter("@Nit", SqlDbType., idArticulo);
//			#endregion
//
//			#region Execute Sql
//			try
//			{
//				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
//			}
//			catch (SqlException e)
//			{
//				throw new Exception(e.Message);
//			}
//			finally 
//			{
//				sql = null;
//			}
//			#endregion
		}
		#endregion

	}
}