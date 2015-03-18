using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Mangueras.
	/// </summary>
	public class Mangueras : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idCara = null;
		private object _idManguera = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Lista de mangueras asociadas a una cara o una manguera en particular.
		/// </summary>
		public Mangueras(short id, bool filtroCara, bool filtroManguera)
		{
			if (filtroCara)
				this._idCara = id;
			else
				this._idManguera = id;
		}

		/// <summary>
		/// Consulta todas las mangueras
		/// </summary>
		public Mangueras(){		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Manguera this[string key]
		{
			get { return (Manguera)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Manguera this[int index]
		{
			get { return (Manguera)base[index]; }
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

			sql.Append("ConsultarMangueras");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdCara", SqlDbType.SmallInt, this._idCara);
			sql.AddParameter("@IdManguera", SqlDbType.SmallInt, this._idManguera);			
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Manguera objManguera = new Manguera();
				objManguera.IdManguera = dr.GetInt16(0);
				objManguera.IdIsla = dr.GetInt16(1);
				objManguera.IdSurtidor = dr.GetInt16(2);
				objManguera.IdCara = dr.GetInt16(3);				
				objManguera.IdTanque = dr.IsDBNull(4)?(short)1:dr.GetInt16(4);
				objManguera.IdArticulo = dr.GetInt16(5);
				objManguera.Grado = dr.GetInt16(6);
				objManguera.LectorConfigurado = dr.GetByte(7)==1?true:false;
				objManguera.IdLector = dr.IsDBNull(8)?"":dr.GetString(8).Trim();
				objManguera.Estado = dr.GetString(9);
				objManguera.Articulo = dr.GetString(10);

				base.AddItem(objManguera.IdManguera.ToString(), objManguera);
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
		public static void Adicionar(Manguera objManguera)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarManguera");
			sql.ParametersNumber = 10;
			sql.AddParameter("@IdManguera", SqlDbType.SmallInt, objManguera.IdManguera);
			sql.AddParameter("@IdCara", SqlDbType.SmallInt, objManguera.IdCara);
			sql.AddParameter("@IdIsla", SqlDbType.SmallInt, objManguera.IdIsla);
			sql.AddParameter("@IdSurtidor", SqlDbType.SmallInt, objManguera.IdSurtidor);			
			if (objManguera.IdTanque == 0)
				sql.AddParameter("@IdTanque", SqlDbType.SmallInt, null);
			else
				sql.AddParameter("@IdTanque", SqlDbType.SmallInt, objManguera.IdTanque);
			sql.AddParameter("@IdArticulo", SqlDbType.SmallInt, objManguera.IdArticulo);
			sql.AddParameter("@Grado", SqlDbType.SmallInt, objManguera.Grado);
			sql.AddParameter("@LectorConfigurado", SqlDbType.Bit, objManguera.LectorConfigurado);
			if (objManguera.LectorConfigurado)
				sql.AddParameter("@IdLector", SqlDbType.VarChar, objManguera.IdLector);
			else
				sql.AddParameter("@IdLector", SqlDbType.VarChar, null);
			sql.AddParameter("@Estado", SqlDbType.VarChar, objManguera.Estado);
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
		public static void Eliminar(short idManguera)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarManguera");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdManguera", SqlDbType.SmallInt, idManguera);
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
		public static Manguera ObtenerItem(short idManguera)
		{
			Mangueras objElementos = new Mangueras(idManguera, false, true);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

	}
}