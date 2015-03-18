using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Puertos COM Configurados en el sistema.
	/// </summary>
	public class Puertos : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idPuerto = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los puertos configurados.
		/// </summary>
		public Puertos()
		{
		}

		/// <summary>
		/// Consulta de un puerto en particular.
		/// </summary>
		internal Puertos(string idPuerto)
		{
			this._idPuerto = idPuerto;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Puerto this[string key]
		{
			get { return (Puerto)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Puerto this[int index]
		{
			get { return (Puerto)base[index]; }
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

			sql.Append("ConsultarPuertos");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, this._idPuerto);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Puerto objPuerto = new Puerto();
				objPuerto.IdPuerto = dr.GetString(0);
				objPuerto.BaudRate = dr.IsDBNull(1)?0:dr.GetInt32(1);
				objPuerto.Parity = dr.IsDBNull(2)?"":dr.GetString(2);
				objPuerto.DataBits = dr.IsDBNull(3)?"":dr.GetString(3);
				objPuerto.Stop = dr.IsDBNull(4)?"":dr.GetString(4);
				
				base.AddItem(objPuerto.IdPuerto, objPuerto);
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
		public static void Adicionar(Puerto objPuerto)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarPuerto");
			sql.ParametersNumber = 5;
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, objPuerto.IdPuerto);
			sql.AddParameter("@BaudRate", SqlDbType.Int, objPuerto.BaudRate);
			sql.AddParameter("@Parity", SqlDbType.VarChar, objPuerto.Parity);
			sql.AddParameter("@DataBits", SqlDbType.VarChar, objPuerto.DataBits);
			sql.AddParameter("@Stop", SqlDbType.VarChar, objPuerto.Stop);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.ToUpper().IndexOf("VIOLATION OF PRIMARY KEY") != -1)
					throw new Exception("El puerto " + objPuerto.IdPuerto + " ya esta configurado!" + " !ERROR BD! ");
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

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		/// <param name="idPuerto">"0" Truncates table Puertos.</param>
		public static void Eliminar(string idPuerto)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarPuerto");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, idPuerto);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message);
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
		/// Método para obtener de manera directa un puerto en particular
		/// </summary>
		public static Puerto ObtenerItem(string idPuerto)
		{
			Puertos objElementos = new Puertos(idPuerto);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}