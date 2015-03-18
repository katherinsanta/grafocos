using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.Tanques
{
	/// <summary>
	/// Biblioteca de Colección para la administracion de mensajes de variación de tanques
	/// </summary>
	public class TanqueVariacionMensajes : Servipunto.Libreria.Collection 
	{
		#region Declarations
		private object _idTanque;
		#endregion

		#region Constructor
		/// <summary>
		/// Obtiene todos los tanques
		/// </summary>
		public TanqueVariacionMensajes() { }

		/// <summary>
		/// Recupera info. de un tanque especifico.
		/// </summary>
		/// <param name="codigoTanque">Codigo del tanque</param>
		public TanqueVariacionMensajes(int codigoTanque) 
		{
			this._idTanque = _idTanque;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexa por llave
		/// </summary>
		new public TanqueVariacionMensaje this [string key] 
		{
			get { return (TanqueVariacionMensaje)base[key]; }
		}

		/// <summary>
		/// Indexa por Indice 
		/// </summary>
		new public TanqueVariacionMensaje this [int index] 
		{
			get { return (TanqueVariacionMensaje)base[index]; }
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

			sql.Append("RecuperarTanqueVariacionMensaje");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdTanque", SqlDbType.Int, this._idTanque);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 0;
			while (dr.Read()) 
			{
				TanqueVariacionMensaje objTanqueVariacionMensaje = new TanqueVariacionMensaje();
				try	
				{
					objTanqueVariacionMensaje.CodigoMensaje = dr.IsDBNull(0)?(int)0:dr.GetInt32(0);ParamNumber++;
					objTanqueVariacionMensaje.CodigoTanque = dr.IsDBNull(1)?(int)0:dr.GetInt32(1);ParamNumber++;
					objTanqueVariacionMensaje.ValorInicial = dr.IsDBNull(2)?(decimal)0:dr.GetDecimal(2);ParamNumber++;
					objTanqueVariacionMensaje.ValorFinal = dr.IsDBNull(3)?(decimal)0:dr.GetDecimal(3);ParamNumber++;
					objTanqueVariacionMensaje.Mensaje = dr.IsDBNull(4)?"":dr.GetString(4);ParamNumber++;
				}
				catch 
				{
					throw new Exception("Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString() );
				}
				try 
				{
					base.AddItem(objTanqueVariacionMensaje.CodigoTanque.ToString(), objTanqueVariacionMensaje);
				}
				catch 
				{
					throw new Exception("Error al agregar registro objeto objTanqueVariacionMensaje !" );
				}
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Permite Adicionar Tanque
		/// </summary>
		public static void Adicionar (TanqueVariacionMensaje objTanqueMensaje)
		{
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarTanqueVariacionMensaje");
			sql.ParametersNumber = 4;
			sql.AddParameter("@IdTanque", SqlDbType.SmallInt, objTanqueMensaje.CodigoTanque);
			sql.AddParameter("@ValorInicial", SqlDbType.Decimal, objTanqueMensaje.ValorInicial);
			sql.AddParameter("@ValorFinal", SqlDbType.Decimal, objTanqueMensaje.ValorFinal);
			sql.AddParameter("@Mensaje", SqlDbType.VarChar, objTanqueMensaje.Mensaje);	

			#endregion 

			#region Execute Sql command
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

		#region Delete
		/// <summary>
		/// Permite eliminar un mensaje en espesifico.
		/// </summary>
		/// <param name="codigoMensaje">Codigo del mensaje</param>
		public static void Eliminar(int codigoMensaje)
		{

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarTanqueVariacionMensaje");
			sql.ParametersNumber = 1;
			sql.AddParameter("@idVariacionTanqueMensaje", SqlDbType.Int, codigoMensaje);
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

		#region GetItem
		/// <summary>
		/// Metodo para obtener la variacion de un tanque.
		/// </summary>
		/// <param name="cod_Tan">Codigo del tanque a consultar</param>
		/// <returns></returns>
		public static TanqueVariacionMensaje ObtenerItem(int cod_Tan) 
		{
			TanqueVariacionMensajes objTanqueMensajes = new TanqueVariacionMensajes(cod_Tan);
			if (objTanqueMensajes.Count == 1)
				return objTanqueMensajes[0];
			else
				return null;
		}
		#endregion

		#region GetItems
		/// <summary>
		/// Metodo para obtener todas las variaciones de los tanques.
		/// <param name="codigoTanque">Codigo del tanque a consultar</param>
		/// </summary>
		/// <returns></returns>
		public static DataSet ObtenerItems(int codigoTanque) 
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarTanqueVariacionMensaje");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdTanque", SqlDbType.Int, codigoTanque);			
			#endregion

			#region Execute Sql
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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
