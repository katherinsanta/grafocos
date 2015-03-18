using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;


namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Artículos registrados en el sistema.
	/// </summary>
	public class Articulos : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idArticulo = null;
		private object _tipo = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los artículos.
		/// </summary>
		public Articulos()
		{
		}

		/// <summary>
		/// Consulta de artículos de un tipo en especial.
		/// </summary>
		public Articulos(TipoArticulo tipo)
		{
			this._tipo = tipo;
		}

		/// <summary>
		/// Consulta de un artículo en particular.
		/// </summary>
		internal Articulos(short idArticulo)
		{
			this._idArticulo = idArticulo;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Articulo this[string key]
		{
			get { return (Articulo)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Articulo this[int index]
		{
			get { return (Articulo)base[index]; }
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

			sql.Append("ConsultarArticulos");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdArticulo", SqlDbType.SmallInt, this._idArticulo);
			sql.AddParameter("@Tipo", SqlDbType.TinyInt, this._tipo);
			#endregion

			#region Execute Sql
			try
			{
				dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				while (dr.Read())
				{
					Articulo objArticulo = new Articulo();
					objArticulo.IdArticulo = dr.GetInt16(0);
					objArticulo.Descripcion = dr.IsDBNull(1)?"":dr.GetString(1);
					objArticulo.UnidadMedida = dr.IsDBNull(2)?"":dr.GetString(2);
					objArticulo.Precio = dr.IsDBNull(3)?0:dr.GetDecimal(3);
					objArticulo.Precio2 = dr.IsDBNull(4)?0:dr.GetDecimal(4);
					objArticulo.Precio3 = dr.IsDBNull(5)?0:dr.GetDecimal(5);
					objArticulo.Iva = dr.IsDBNull(6)?(short)0:dr.GetInt16(6);
					objArticulo.Tipo = dr.IsDBNull(7)?TipoArticulo.Combustible:(TipoArticulo)dr.GetByte(7);
					//objArticulo.Color = dr.IsDBNull(8)?ColorEnum.NoColor:(dr.GetString(8).Trim() == ""?ColorEnum.NoColor:(ColorEnum)Convert.ToInt32(dr.GetString(8)));
					objArticulo.Color = dr.IsDBNull(8)?"#FFFFFF":(dr.GetString(8).Trim() == ""?"#FFFFFF":dr.GetString(8).Replace("0x", "#").Trim());
					//Interface Contable
					objArticulo.NumCuenta = dr.IsDBNull(9)?"(sin definir)":dr.GetString(9).Trim();
					objArticulo.NatCuenta = dr.IsDBNull(10)?false:dr.GetBoolean(10);
					objArticulo.CodigoAlterno = dr.IsDBNull(11)?"":dr.GetString(11).Trim();

					base.AddItem(objArticulo.IdArticulo.ToString(), objArticulo);
				}
				dr.Close();
				dr = null;
				sql = null;
			}
			catch(Exception ex)
			{
				string errorx = ex.ToString();
			}
			#endregion
		}
		#endregion

		#region Adicionar
		/// <summary>
		/// Inserción de un registro en la base de datos.
		/// </summary>
		public static void Adicionar(Articulo objArticulo)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarArticulo");
			sql.ParametersNumber = 13;
			sql.AddParameter("@IdArticulo", SqlDbType.SmallInt, objArticulo.IdArticulo, ParameterDirection.Output);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, objArticulo.Descripcion);
			sql.AddParameter("@UnidadMedida", SqlDbType.VarChar, objArticulo.UnidadMedida);
			sql.AddParameter("@Precio", SqlDbType.Decimal, objArticulo.Precio);
			sql.AddParameter("@Precio2", SqlDbType.Decimal, objArticulo.Precio2);
			sql.AddParameter("@Precio3", SqlDbType.Decimal, objArticulo.Precio3);
			sql.AddParameter("@Iva", SqlDbType.SmallInt, objArticulo.Iva);
			sql.AddParameter("@Tipo", SqlDbType.TinyInt, objArticulo.Tipo);
			sql.AddParameter("@Color", SqlDbType.Int, int.Parse(objArticulo.Color));
			sql.AddParameter("@Cod_Art", SqlDbType.Int, objArticulo.CodigoArticulo);
			sql.AddParameter("@NUM_CUENTA", SqlDbType.VarChar, objArticulo.NumCuenta);
			sql.AddParameter("@NAT_CUENTA", SqlDbType.Bit, objArticulo.NatCuenta);
			sql.AddParameter("@CodigoAlterno", SqlDbType.Char, objArticulo.CodigoAlterno);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				objArticulo.IdArticulo = Convert.ToInt16(sql.Parameters[0].Value);
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
		public static void Eliminar(short idArticulo)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarArticulo");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdArticulo", SqlDbType.SmallInt, idArticulo);
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

		#region Método ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa un artículo en particular
		/// </summary>
		public static Articulo ObtenerItem(short idArticulo)
		{
			Articulos objElementos = new Articulos(idArticulo);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}