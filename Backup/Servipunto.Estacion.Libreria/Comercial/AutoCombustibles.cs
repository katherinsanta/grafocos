using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial {
	/// <summary>
	/// Summary description for AutoCombustibles.
	/// </summary>
	public class AutoCombustibles : Servipunto.Libreria.Collection {

		#region Declarations
		private object _placa = null;
		//private object _cod_Art = null;
		#endregion

		#region Constructor

		/// <summary>
		/// Consulta todas las configuraciones de la tabla Auto_Comb 
		/// </summary>
		public AutoCombustibles() {}

		/// <summary>
		/// Consulta todos los combustibles configurados para una placa
		/// </summary>
		/// <param name="Placa"></param>
		public AutoCombustibles (string Placa){
			this._placa = Placa;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Index by Key
		/// </summary>
		new public AutoCombustible this[string key]{
			get{ return (AutoCombustible) base[key]; }
		}

		/// <summary>
		/// Index by cllection index
		/// </summary>
		new public AutoCombustible this[int index] {
			get { return (AutoCombustible) base[index]; }
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
			sql.Append("AutoCombQuery");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			#endregion

			#region Execute SqlStatement
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 0;
			while (dr.Read()){
				AutoCombustible objAutoCombustible = new AutoCombustible();
				try{
					objAutoCombustible.PlacaAuto = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();ParamNumber++;
					objAutoCombustible.CodigoArticulo = dr.IsDBNull(1)?(int)0:(int) dr.GetInt16(1);ParamNumber++;
					objAutoCombustible.NombreArticulo = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();ParamNumber++;
				}catch {
					throw new Exception("(Servipunto.Estacion.Libreria.Comercial.AutoCombustibles.Load) Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString()  + " !ERROR BD! ");
				}
				try{
					base.AddItem(objAutoCombustible.PlacaAuto + objAutoCombustible.CodigoArticulo.ToString(), objAutoCombustible);
				}catch{
					throw new Exception("(Servipunto.Estacion.Libreria.Comercial.AutoCombustibles.Load) Error al agregar registro objeto objAutoCombustible Placa: !!" + objAutoCombustible.PlacaAuto.Trim()  + " !ERROR BD! ");
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
		/// Inserta un combustible.
		/// </summary>
		/// <param name="objAutoCombustible"></param>
		public static void Adicionar(AutoCombustible objAutoCombustible){

			#region Prepare Sql
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("AutoCombInsertion");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Placa", SqlDbType.VarChar, objAutoCombustible.PlacaAuto);
			sql.AddParameter("@Cod_Art", SqlDbType.Int, objAutoCombustible.CodigoArticulo);			
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya esta configurado el combustiblle " + objAutoCombustible.CodigoArticulo + ", para el vehiculo " + objAutoCombustible.PlacaAuto  + " !ERROR BD! ");
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
		/// Elimina Combustilbes configurados a vehiculos de la DB.
		/// </summary>
		/// <param name="Placa">Placa a eliminarle configuracion</param>
		/// <param name="Cod_Art">Articulo a eliminar de la configuracion del vehiculo.</param>
 
		public static void Eliminar(string Placa, int Cod_Art) {
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("AutoCombDeletion");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Placa", SqlDbType.VarChar, Placa);
			sql.AddParameter("@Cod_Art", SqlDbType.Int, Cod_Art);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				throw new Exception(e.Message  + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region GetItems
		/// <summary>
		/// Permite obtener todos los combustibles configurados a una placa.
		/// </summary>
		/// <param name="Placa">Placa del Vehiculo a consultarle combustibles</param>
		/// <returns></returns>
		public static AutoCombustibles ObtenerItems(string Placa){
			AutoCombustibles objAutoCombustibles = new AutoCombustibles(Placa);
			if (objAutoCombustibles.Count > 0)
				return objAutoCombustibles;
			else 
				return null;
		}

		#endregion

	}
}
