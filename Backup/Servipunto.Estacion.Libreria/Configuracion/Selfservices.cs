using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Descripción breve de Selfservices.
	/// </summary>
	public class Selfservices : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idSelfservice = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos las configuraciones.
		/// </summary>
		public Selfservices()
		{
		}

		/// <summary>
		/// Consulta de una configuración en particular.
		/// </summary>
		internal Selfservices(int IdSelfservice)
		{
			this._idSelfservice = IdSelfservice;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Selfservice this[string key]
		{
			get { return (Selfservice)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Selfservice this[int index]
		{
			get { return (Selfservice)base[index]; }
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

			sql.Append("ConsultarSelfservice");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdSelfservice", SqlDbType.Int, this._idSelfservice);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Selfservice objSelfservice = new Selfservice();
				objSelfservice.IdSelfservice = dr.GetInt32(0);
				objSelfservice.ValorBoton1 =  dr.IsDBNull(1)?0:dr.GetDecimal(1);
				objSelfservice.ValorBoton2 =  dr.IsDBNull(2)?0:dr.GetDecimal(2);
				objSelfservice.ValorBoton3 =  dr.IsDBNull(3)?0:dr.GetDecimal(3);
				objSelfservice.ValorBoton4 =  dr.IsDBNull(4)?0:dr.GetDecimal(4);
				objSelfservice.ValorBoton5 =  dr.IsDBNull(5)?0:dr.GetDecimal(5);
				objSelfservice.ValorBoton6 =  dr.IsDBNull(6)?0:dr.GetDecimal(6);
				objSelfservice.CaraBoton1 =  dr.IsDBNull(7)?(short)0:dr.GetInt16(7);
				objSelfservice.CaraBoton2 =  dr.IsDBNull(8)?(short)0:dr.GetInt16(8);
				objSelfservice.CaraBoton3 =  dr.IsDBNull(9)?(short)0:dr.GetInt16(9);
				objSelfservice.CaraBoton4 =  dr.IsDBNull(10)?(short)0:dr.GetInt16(10);
				objSelfservice.CaraBoton5 =  dr.IsDBNull(11)?(short)0:dr.GetInt16(11);
				objSelfservice.CaraBoton6 =  dr.IsDBNull(12)?(short)0:dr.GetInt16(12);
				objSelfservice.CaraBoton7 =  dr.IsDBNull(13)?(short)0:dr.GetInt16(13);
				objSelfservice.CaraBoton8 =  dr.IsDBNull(14)?(short)0:dr.GetInt16(14);
				objSelfservice.CaraBoton9 =  dr.IsDBNull(15)?(short)0:dr.GetInt16(15);
				objSelfservice.CaraBoton10 =  dr.IsDBNull(16)?(short)0:dr.GetInt16(16);
				objSelfservice.CaraBoton11 =  dr.IsDBNull(17)?(short)0:dr.GetInt16(17);
				objSelfservice.CaraBoton12 =  dr.IsDBNull(18)?(short)0:dr.GetInt16(18);
				objSelfservice.PuertoLectorFidelizacion =  dr.IsDBNull(19)?"":dr.GetString(19);

				
				base.AddItem(objSelfservice.IdSelfservice.ToString(), objSelfservice);
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
		public static void Adicionar(Selfservice objSelfservice)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarSelfservice");
			sql.ParametersNumber = 20;
			sql.AddParameter("@IdSelfservice", SqlDbType.Int, objSelfservice.IdSelfservice);
			sql.AddParameter("@ValorBoton1", SqlDbType.Decimal, objSelfservice.ValorBoton1);
			sql.AddParameter("@ValorBoton2", SqlDbType.Decimal, objSelfservice.ValorBoton2);
			sql.AddParameter("@ValorBoton3", SqlDbType.Decimal, objSelfservice.ValorBoton3);
			sql.AddParameter("@ValorBoton4", SqlDbType.Decimal, objSelfservice.ValorBoton4);
			sql.AddParameter("@ValorBoton5", SqlDbType.Decimal, objSelfservice.ValorBoton5);
			sql.AddParameter("@ValorBoton6", SqlDbType.Decimal, objSelfservice.ValorBoton6);
			sql.AddParameter("@CaraBoton1", SqlDbType.SmallInt, objSelfservice.CaraBoton1);
			sql.AddParameter("@CaraBoton2", SqlDbType.SmallInt, objSelfservice.CaraBoton2);
			sql.AddParameter("@CaraBoton3", SqlDbType.SmallInt, objSelfservice.CaraBoton3);
			sql.AddParameter("@CaraBoton4", SqlDbType.SmallInt, objSelfservice.CaraBoton4);
			sql.AddParameter("@CaraBoton5", SqlDbType.SmallInt, objSelfservice.CaraBoton5);
			sql.AddParameter("@CaraBoton6", SqlDbType.SmallInt, objSelfservice.CaraBoton6);
			sql.AddParameter("@CaraBoton7", SqlDbType.SmallInt, objSelfservice.CaraBoton7);
			sql.AddParameter("@CaraBoton8", SqlDbType.SmallInt, objSelfservice.CaraBoton8);
			sql.AddParameter("@CaraBoton9", SqlDbType.SmallInt, objSelfservice.CaraBoton9);
			sql.AddParameter("@CaraBoton10", SqlDbType.SmallInt, objSelfservice.CaraBoton10);
			sql.AddParameter("@CaraBoton11", SqlDbType.SmallInt, objSelfservice.CaraBoton11);
			sql.AddParameter("@CaraBoton12", SqlDbType.SmallInt, objSelfservice.CaraBoton12);
			if(objSelfservice.PuertoLectorFidelizacion.Trim().Length>0)
				sql.AddParameter("@PuertoLectorFidelizacion", SqlDbType.Char, objSelfservice.PuertoLectorFidelizacion);

			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				objSelfservice.IdSelfservice = Convert.ToInt16(sql.Parameters[0].Value);
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
		public static void Eliminar(int idSelfservice)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarSelfservice");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdSelfservice", SqlDbType.Int, idSelfservice);
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
		/// Método para obtener de manera directa una configuración en particular
		/// </summary>
		public static Selfservice ObtenerItem(int idSelfservice)
		{
			Selfservices objElementos = new Selfservices(idSelfservice);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}
