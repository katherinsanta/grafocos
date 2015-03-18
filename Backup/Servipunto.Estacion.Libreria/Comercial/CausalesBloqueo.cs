using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	///  CausalesBloqueo.
	/// </summary>
	public class CausalesBloqueo : Servipunto.Libreria.Collection {
		
		#region Declarations
		private object _causal = null, _descripcion = null;
		#endregion
	
		#region Constructor
		/// <summary>
		/// Consulta todas las Causales de Bloqueo
		/// </summary>
		public CausalesBloqueo(){ }

		/// <summary>
		/// Consulta una causal especifica
		/// </summary>
		/// <param name="Descripcion">Descripcion de la causal</param>
		public CausalesBloqueo(string Descripcion){
			this._descripcion = Descripcion;
		}

		/// <summary>
		/// Consulta una causal especifica
		/// </summary>
		/// <param name="Causal">Codigo de la causal</param>
		public CausalesBloqueo (int Causal) {
			this._causal = Causal;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Index by Key
		/// </summary>
		new public CausalBloqueo this[string key]{
			get{ return (CausalBloqueo) base[key]; }
		}

		/// <summary>
		/// Index by cllection index
		/// </summary>
		new public CausalBloqueo this[int index] {
			get { return (CausalBloqueo) base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e) {
		
			#region Prepare SqlStatement
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CausalesBloqQuery");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Causal", SqlDbType.Int, this._causal);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, this._descripcion);
			sql.AddParameter("@Responsable", SqlDbType.VarChar, null);
			#endregion

			#region Execute SqlStatement
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read()){
				CausalBloqueo objCausalBloqueo = new CausalBloqueo();

				objCausalBloqueo.CodigoCausal = dr.IsDBNull(0)?(int)0:(int)dr.GetInt16(0);
				objCausalBloqueo.DescripcionCausal = dr.IsDBNull(1)?"(Sin Definir)":dr.GetString(1).Trim();
				objCausalBloqueo.ResponsableCausal = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();
				
				try{
					base.AddItem(objCausalBloqueo.CodigoCausal.ToString(), objCausalBloqueo);
				}catch (Exception){ /*Elemento repetido en la Db*/}
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Inserta una causal en la DB.
		/// </summary>
		/// <param name="objCausalBloqueo"></param>
		public static void Adicionar(CausalBloqueo objCausalBloqueo){

			#region Prepare Sql
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CausalesbloqInsertion");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, objCausalBloqueo.DescripcionCausal);
			sql.AddParameter("@Responsable", SqlDbType.VarChar, objCausalBloqueo.ResponsableCausal);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe la causal " + objCausalBloqueo.CodigoCausal  + " !ERROR BD! ");
				else
					throw new Exception(e.Message  + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Delete
		/// <summary>
		/// Elimina Casuales de la DB.
		/// </summary>
		/// <param name="Causal">Codigo a eliminar </param>
		public static void Eliminar(int Causal) {
			
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("CausalesBloqDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Causal", SqlDbType.Int, Causal);				
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

		#region GetItem
		/// <summary>
		/// Metodo para obtener una causal
		/// </summary>
		/// <param name="Causal">Codigo de la causal.</param>
		/// <returns></returns>
		public static CausalBloqueo ObtenerItem (int Causal) {
			CausalesBloqueo objCausalesBloqueo = new CausalesBloqueo(Causal);
			if (objCausalesBloqueo.Count == 1)
				return objCausalesBloqueo[0];
			else
				return null;
		}
		#endregion

		#region GetItems
		/// <summary>
		/// Permite obtener todos las causales
		/// </summary>
		/// <returns></returns>
		public static CausalesBloqueo ObtenerItems(){
			CausalesBloqueo objCausalesBloqueo = new CausalesBloqueo();
			if (objCausalesBloqueo.Count > 0)
				return objCausalesBloqueo;
			else 
				return null;
		}

		#endregion
	}
}
