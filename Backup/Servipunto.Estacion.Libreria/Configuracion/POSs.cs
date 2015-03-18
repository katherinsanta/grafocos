using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.IO;


namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Descripción breve de POSs. 
	/// </summary>
	public class POSs: Servipunto.Libreria.Collection {

		#region Sección de Declaraciones
		private object _num_Pos = null;
		private object _num_Cap = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de un capturador en particular.
		/// </summary>
		public POSs(int num_Pos, int num_Cap) {
			this._num_Pos = num_Pos;
			this._num_Cap = num_Cap;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public POS this[string key] {
			get { return (POS)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public POS this[int index] {
			get { return (POS)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e) {		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ConsultarPos");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Num_Pos", SqlDbType.Int, this._num_Pos);
			sql.AddParameter("@Num_Cap", SqlDbType.Int, this._num_Cap);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
//			int p = 0;
//			StreamWriter sw = new StreamWriter(@"c:\debud.txt");
			while (dr.Read()) {
				POS objPos = new POS();
				objPos.IdPos = dr.IsDBNull(0)?(short)0:dr.GetInt16(0);
				objPos.IdIsla = dr.IsDBNull(1)?(short)0:dr.GetInt16(1);
				objPos.IdCapturador = dr.IsDBNull(2)?(short)0:dr.GetInt16(2);
                byte valor = dr.IsDBNull(3) ? (byte)0 : dr.GetByte(3);
                objPos.ManejaPolyDisplay = valor == 0 ? false : true;
                objPos.ProtocoloPolyDisplay = dr.IsDBNull(4) ? "" : dr.GetString(4);
                objPos.PuertoPolyDisplay = dr.IsDBNull(5) ? "" : dr.GetString(5);
//				sw.Write(p + ") Agregando" + objPos.IdPos.ToString());
				base.AddItem(objPos.IdPos.ToString(), objPos);
//				p++;
			}
//			sw.Close();
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
		public static void Adicionar(POS objPos) {
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarPos");
			sql.ParametersNumber = 6;
			sql.AddParameter("@Num_Pos", SqlDbType.Int, objPos.IdPos);
			sql.AddParameter("@Cod_Isl", SqlDbType.Int, objPos.IdIsla);
			sql.AddParameter("@Num_Cap", SqlDbType.Int, objPos.IdCapturador);
            sql.AddParameter("@ManejaPolyDisplay", SqlDbType.TinyInt, objPos.ManejaPolyDisplay);
            sql.AddParameter("@ProtocoloPolyDisplay", SqlDbType.VarChar, objPos.ProtocoloPolyDisplay);
            sql.AddParameter("@PuertoPolyDisplay", SqlDbType.VarChar, objPos.PuertoPolyDisplay);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe un Pos identificado con el número " + objPos.IdPos.ToString() + " !ERROR BD! ");
				else
					throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Eliminar
		
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		/// <param name="num_Pos">Numero del Pos a Eliminar. </param>
		public static void Eliminar(int num_Pos) {
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarPos");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Num_Pos", SqlDbType.Int, num_Pos);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa un Pos en particular
		/// </summary>
		/// <param name="num_Pos">Numero del Pos a retornar informacion. </param>
		/// <param name="num_Cap">Numero de Capturador </param>
		/// <returns>El Pos o Null</returns>
		public static POS ObtenerItem(int num_Pos, int num_Cap) {
			POSs objElementos = new POSs(num_Pos, num_Cap);
			if (objElementos.Count >= 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

	}
}
