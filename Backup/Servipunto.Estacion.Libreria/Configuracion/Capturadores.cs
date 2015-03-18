using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Capturadores (MRs)
	/// </summary>
	public class Capturadores : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idCapturador = null;
		private string _direccionIP="";
		#endregion

		#region Constructor
		/// <summary>
		/// Lista de todos los capturadores configurados.
		/// </summary>
		public Capturadores()
		{
		}

		/// <summary>
		/// Consulta de un capturador en particular.
		/// </summary>
		internal Capturadores(short idCapturador, string direccionIp)
		{
			this._idCapturador = idCapturador;
			this._direccionIP = direccionIp;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Capturador this[string key]
		{
			get { return (Capturador)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Capturador this[int index]
		{
			get { return (Capturador)base[index]; }
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

			sql.Append("ConsultarCapturadores");
			sql.ParametersNumber = 1; 
			if(_direccionIP.Length<3)
				sql.AddParameter("@IdCapturador", SqlDbType.SmallInt, this._idCapturador);
			else
				sql.AddParameter("@DireccionIP", SqlDbType.Char,_direccionIP);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Capturador objCapturador = new Capturador();
				objCapturador.IdCapturador = dr.IsDBNull(0)?(short)0:dr.GetInt16(0);
				objCapturador.IdPuerto = dr.IsDBNull(1)?"":dr.GetString(1).Trim();
				byte valor = dr.IsDBNull(2)?(byte)0:dr.GetByte(2);
				objCapturador.CapturadorSerial = valor == (byte)1 ? true : false;
				objCapturador.DireccionIP = dr.IsDBNull(3)?"":dr.GetString(3).Trim();
				objCapturador.PuertoSocketEscucha = dr.IsDBNull(4)?0:dr.GetInt32(4);
				objCapturador.DireccionIP3ro = dr.IsDBNull(5)?"":dr.GetString(5).Trim();
				objCapturador.PuertoSocket3ro = dr.IsDBNull(6)?0:dr.GetInt32(6);
				objCapturador.IdRegistro = dr.IsDBNull(7)?-1:dr.GetInt32(7);
				base.AddItem(objCapturador.IdCapturador.ToString(), objCapturador);
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
		public static void Adicionar(Capturador objCapturador)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarCapturador");
			sql.ParametersNumber = 8;
			sql.AddParameter("@IdCapturador", SqlDbType.SmallInt, objCapturador.IdCapturador);
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, objCapturador.IdPuerto);
			sql.AddParameter("@CapturadorSerial", SqlDbType.TinyInt, objCapturador.CapturadorSerial);
			sql.AddParameter("@DireccionIP", SqlDbType.VarChar, objCapturador.DireccionIP);
			sql.AddParameter("@Puerto_Socket_Escucha", SqlDbType.Int, objCapturador.PuertoSocketEscucha);
			sql.AddParameter("@DireccionIP3ro", SqlDbType.VarChar, objCapturador.DireccionIP3ro);
			sql.AddParameter("@Puerto_Socket3ro", SqlDbType.Int, objCapturador.PuertoSocket3ro);
			sql.AddParameter("@IdRegistro", SqlDbType.Int, objCapturador.IdRegistro);

			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe un capturador identificado con el número " + objCapturador.IdCapturador.ToString());
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
		public static void Eliminar(short idCapturador)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarCapturador");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdCapturador", SqlDbType.SmallInt, idCapturador);
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
		public static Capturador ObtenerItem(short idCapturador,string direccionIp)
		{
			Capturadores objElementos = new Capturadores(idCapturador,direccionIp);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}