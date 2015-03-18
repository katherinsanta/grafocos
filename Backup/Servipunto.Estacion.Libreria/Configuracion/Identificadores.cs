using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion {
	/// <summary>
	/// Descripción breve de Identificadores.
	/// </summary>
	public class Identificadores : Servipunto.Libreria.Collection  {

		#region Declarations
		private object _num_Ide  = null;
		private object _rom_Iden = null;
		private object _cod_Emp  = null;
        private object _placa    = null;
		#endregion

		#region Constructor/Destructor
		/// <summary>
		/// Queries for all identificadores in identifi. 
		/// </summary>
		public Identificadores(){}

		/// <summary>
		/// Queries Identifi By IDentificador Number
		/// </summary>
		/// <param name="NumeroIdentificador">Identificador Number</param>
		public Identificadores(int NumeroIdentificador){
			this._num_Ide = NumeroIdentificador;
		}
		
		/// <summary>
		/// Queries Identifi
		/// </summary>
		/// <param name="Param">1. IdRom   2.CodEmpleado   3.Placa </param>
		/// <param name="ParamName">Parameter Value</param>
		public Identificadores(int Param, string ParamName){
			if(Param == 1){
				this._rom_Iden = ParamName;
			}else if(Param == 2){
				this._cod_Emp = ParamName;
			}else {
				this._placa = ParamName;
			}
		}

		#endregion

		#region Indexer
		/// <summary>
		/// Index by Key 
		/// </summary>
		new public Identificador this [string key]{
			get {return (Identificador) base[key]; }
		}

		/// <summary>
		/// Index by index of collection
		/// </summary>
		new public Identificador this [int index]{
			get {return (Identificador) base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Queries Idnetifi
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e) {		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("IdentifiQuery");
			sql.ParametersNumber = 4;
			sql.AddParameter("@Num_Ide", SqlDbType.Int, this._num_Ide);
			sql.AddParameter("@Rom_Iden", SqlDbType.VarChar, this._rom_Iden);
			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, this._cod_Emp);
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read()) {//lee el data reader y asigana cada valor dentro del campo en la coleccion
				Identificador objIdentifi = new Identificador();
				objIdentifi.NumeroIdentificador = dr.IsDBNull(0)?(int)0:dr.GetInt32(0);
				objIdentifi.IdRom = dr.IsDBNull(1)?"(Sin Definir)":dr.GetString(1).Trim();
				objIdentifi.CodigoEmpleado = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();
                objIdentifi.Placa = dr.IsDBNull(3)?"(Sin Definir)":dr.GetString(3).Trim();
				objIdentifi.IdentificadorActivo = dr.IsDBNull(4)?"Inactivo":(dr.GetString(4).Trim() == "S" || dr.GetString(4).Trim() == "0"?"Activo":"Inactivo");
				objIdentifi.TipoIdentificador = dr.IsDBNull(5)?"(Sin Definir)":(dr.GetString(5).Trim() == "M"?"Magnetica":"Boton");
							
				base.AddItem(objIdentifi.NumeroIdentificador.ToString(), objIdentifi);//Agrega
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion 

		#region Add

		/// <summary>
		/// Allows to add a new Identificador
		/// </summary>
		public static void Adicionar (Identificador objIdentifi){

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("IdentifiInsertion");
			sql.ParametersNumber = 5;
			sql.AddParameter("@Num_Ide", SqlDbType.Int, objIdentifi.NumeroIdentificador);
			sql.AddParameter("@Rom_Iden", SqlDbType.VarChar, objIdentifi.IdRom);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, objIdentifi.TipoIdentificador == "Magnetica"?"M":"B");
			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, objIdentifi.CodigoEmpleado);
			sql.AddParameter("@Placa", SqlDbType.VarChar, objIdentifi.Placa);
			#endregion

			#region Execute Sql command
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

		#region Delete
		/// <summary>
		/// Deletes from identifi
		/// </summary>
		/// <param name="NumIdentificador">Identificador to delete.  Null truncates table</param>
		public static void Eliminar (int NumIdentificador){
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("IdentifiDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Num_Ide", SqlDbType.Int, NumIdentificador);
			#endregion

			#region Execute Sql Command
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
		/// Gets Identificador
		/// </summary>
		/// <param name="NumIdentificador">Identificador Number</param>
		/// <returns>Identificador Info.</returns>
		public static Identificador ObtenerItem(int NumIdentificador) {
			Identificadores objIdentificadores = new Identificadores(NumIdentificador);
			if (objIdentificadores.Count == 1)
				return objIdentificadores[0];
			else
				return null;
		}
		#endregion 

		#region GetItems
		/// <summary>
		/// ObtenerItem: Obtiene todos los identificadores asociados a una empleado o una placa
		/// </summary>
		/// <param name="Parameter">1. Por IdRom   2. Por CodEmpleado      3. Placa </param>
		/// <param name="ParameterName">La llave a consultar </param>
		/// <returns></returns>
		public static Identificadores ObtenerItem(int Parameter, string ParameterName) {
			Identificadores objIdentificadores = new Identificadores(Parameter, ParameterName);
			if (objIdentificadores.Count > 0)
				return objIdentificadores;
			else
				return null;
		}
		#endregion 

	}
}
