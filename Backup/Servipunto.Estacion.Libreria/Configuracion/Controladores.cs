using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Controladores
	/// </summary>
	public class Controladores : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idControlador = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los controladores configurados.
		/// </summary>
		public Controladores()
		{
		}

		/// <summary>
		/// Consulta de un controlador en particular.
		/// </summary>
		internal Controladores(short idControlador)
		{
			this._idControlador = idControlador;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Controlador this[string key]
		{
			get { return (Controlador)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Controlador this[int index]
		{
			get { return (Controlador)base[index]; }
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

			sql.Append("ConsultarControladores");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdControlador", SqlDbType.SmallInt, this._idControlador);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Controlador objControlador = new Controlador();
				objControlador.IdControlador = dr.GetInt16(0);
				objControlador.IdPuerto = dr.IsDBNull(1)?"":dr.GetString(1).Trim();
				objControlador.Descripcion = dr.IsDBNull(2)?"(sin definir)":dr.GetString(2).Trim();
				objControlador.PuertoConcentrador = dr.IsDBNull(3)?"(sin definir)":dr.GetString(3).Trim();
				
				base.AddItem(objControlador.IdControlador.ToString(), objControlador);
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
		public static void Adicionar(Controlador objControlador)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarControlador");
			sql.ParametersNumber = 4;
			sql.AddParameter("@IdControlador", SqlDbType.SmallInt, objControlador.IdControlador, ParameterDirection.Output);
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, objControlador.IdPuerto);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, objControlador.Descripcion);
			if(objControlador.PuertoConcentrador.Trim() != "(sin definir)")
				sql.AddParameter("@PuertoConcentrador", SqlDbType.VarChar, objControlador.PuertoConcentrador);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				objControlador.IdControlador = Convert.ToInt16(sql.Parameters[0].Value);
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

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		public static void Eliminar(short idControlador)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarControlador");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdControlador", SqlDbType.SmallInt, idControlador);
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

		#region ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa un controlador en particular
		/// </summary>
		public static Controlador ObtenerItem(short idControlador)
		{
			Controladores objElementos = new Controladores(idControlador);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}