using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Caras.
	/// </summary>
	public class Caras : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idSurtidor = null;
		private object _idCara = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de caras por surtidor o una cara en particular.
		/// </summary>
		public Caras(short id, bool filtroSurtidor, bool filtroCara)
		{
			if (filtroSurtidor)
				this._idSurtidor = id;
			else
				this._idCara = id;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Cara this[string key]
		{
			get { return (Cara)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Cara this[int index]
		{
			get { return (Cara)base[index]; }
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

			sql.Append("ConsultarCaras");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdSurtidor", SqlDbType.SmallInt, this._idSurtidor);
			sql.AddParameter("@IdCara", SqlDbType.SmallInt, this._idCara);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Cara objCara = new Cara();
				objCara.IdCara = dr.GetInt16(0);
				objCara.IdIsla = dr.GetInt16(1);
				objCara.IdSurtidor = dr.GetInt16(2);				
				objCara.IdControlador = dr.IsDBNull(3)?(short)0:dr.GetInt16(3);
				objCara.Estado = dr.GetString(4).Trim();
				objCara.Modo = dr.GetString(5).Trim();

				base.AddItem(objCara.IdCara.ToString(), objCara);
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
		public static void Adicionar(Cara objCara)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarCara");
			sql.ParametersNumber = 6;
			sql.AddParameter("@IdCara", SqlDbType.SmallInt, objCara.IdCara);
			sql.AddParameter("@IdIsla", SqlDbType.SmallInt, objCara.IdIsla);
			sql.AddParameter("@IdSurtidor", SqlDbType.SmallInt, objCara.IdSurtidor);			
			if (objCara.IdControlador == 0)
				sql.AddParameter("@IdControlador", SqlDbType.SmallInt, null);
			else
				sql.AddParameter("@IdControlador", SqlDbType.SmallInt, objCara.IdControlador);
			sql.AddParameter("@Estado", SqlDbType.VarChar, objCara.Estado);
			sql.AddParameter("@Modo", SqlDbType.VarChar, objCara.Modo);
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

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		public static void Eliminar(short idCara)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarCara");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdCara", SqlDbType.SmallInt, idCara);
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
		/// Método para obtener de manera directa una cara en particular.
		/// </summary>
		public static Cara ObtenerItem(short idCara)
		{
			Caras objElementos = new Caras(idCara, false, true);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region obtener cara con articulos

		/// <summary>
		/// Obtiene los articulos disponibles partiendo de la cara
		/// </summary>
		public static DataSet ObtenerCaraArticulo()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarCaraArticulo");
//			sql.ParametersNumber = 1;
//			sql.AddParameter("@cod_car", SqlDbType.Int, codigoCara);
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text));
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