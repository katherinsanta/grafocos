using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Surtidores.
	/// </summary>
	public class Surtidores : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idIsla = null;
		private object _idSurtidor = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de surtidores por isla o un surtidor en particular.
		/// </summary>
		public Surtidores(short id, bool filtroIsla, bool filtroSurtidor)
		{
			if (filtroIsla)
				this._idIsla = id;
			else
				this._idSurtidor = id;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Surtidor this[string key]
		{
			get { return (Surtidor)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Surtidor this[int index]
		{
			get { return (Surtidor)base[index]; }
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

			sql.Append("ConsultarSurtidores");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdIsla", SqlDbType.SmallInt, this._idIsla);
			sql.AddParameter("@IdSurtidor", SqlDbType.SmallInt, this._idSurtidor);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Surtidor objSurtidor = new Surtidor();
				objSurtidor.IdSurtidor = dr.IsDBNull(0)?(short)0:dr.GetInt16(0);
				objSurtidor.IdIsla = dr.IsDBNull(1)?(short)0:dr.GetInt16(1);
				objSurtidor.Marca = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();
				objSurtidor.Protocolo = dr.IsDBNull(3)?"(Sin Definir)":dr.GetString(3).Trim();
				objSurtidor.Densidad = dr.IsDBNull(4)?0:dr.GetDecimal(4);
				objSurtidor.FactorDivision = dr.IsDBNull(5)?(short)1:dr.GetInt16(5);

				try {//Recover for new Table Surtidor
					objSurtidor.TiempoEstado = dr.IsDBNull(6)?(int)0:dr.GetInt32(6);
					objSurtidor.TiempoDespacho = dr.IsDBNull(7)?(int)0:dr.GetInt32(7);
					objSurtidor.TiempoAutorizacion = dr.IsDBNull(8)?(int)0:dr.GetInt32(8);
					objSurtidor.TiempoTotalizadores = dr.IsDBNull(9)?(int)0:dr.GetInt32(9);				
				}catch {//Recover for old Table Surtidor
					objSurtidor.TiempoEstado = dr.IsDBNull(6)?(int)0:(int)dr.GetByte(6);
					objSurtidor.TiempoDespacho = dr.IsDBNull(7)?(int)0:(int)dr.GetByte(7);
					objSurtidor.TiempoAutorizacion =  (int)0;
					objSurtidor.TiempoTotalizadores = (int)0;
				}

				base.AddItem(objSurtidor.IdSurtidor.ToString(), objSurtidor);
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
		public static void Adicionar(Surtidor objSurtidor)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarSurtidor");
			sql.ParametersNumber = 10;
			sql.AddParameter("@IdSurtidor", SqlDbType.SmallInt, objSurtidor.IdSurtidor);
			sql.AddParameter("@IdIsla", SqlDbType.SmallInt, objSurtidor.IdIsla);
			sql.AddParameter("@Marca", SqlDbType.VarChar, objSurtidor.Marca);
			if (objSurtidor.Protocolo.Trim().Length > 0)
				sql.AddParameter("@Protocolo", SqlDbType.VarChar, objSurtidor.Protocolo);
			else
				sql.AddParameter("@Protocolo", SqlDbType.VarChar, null);
			sql.AddParameter("@Densidad", SqlDbType.Decimal, objSurtidor.Densidad);
			sql.AddParameter("@FactorDivision", SqlDbType.SmallInt, objSurtidor.FactorDivision);
			sql.AddParameter("@TiempoEstado", SqlDbType.Int, objSurtidor.TiempoEstado);
			sql.AddParameter("@TiempoDespacho", SqlDbType.Int, objSurtidor.TiempoDespacho);
			sql.AddParameter("@TiempoAutorizacion", SqlDbType.Int, objSurtidor.TiempoAutorizacion);
			sql.AddParameter("@TiempoTotalizadores", SqlDbType.Int, objSurtidor.TiempoTotalizadores);
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
		public static void Eliminar(short idSurtidor)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarSurtidor");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdSurtidor", SqlDbType.SmallInt, idSurtidor);
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
		/// Método para obtener de manera directa un surtidor en particular.
		/// </summary>
		public static Surtidor ObtenerItem(short idSurtidor)
		{
			Surtidores objElementos = new Surtidores(idSurtidor, false, true);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}