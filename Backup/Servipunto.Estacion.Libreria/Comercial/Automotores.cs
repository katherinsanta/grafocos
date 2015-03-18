using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Automotores.
	/// </summary>
	public class Automotores : Servipunto.Libreria.Collection {

		#region Declarations
		private object _cod_Cli = null, _placa = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta todos los Automtores registrados
		/// </summary>
		public Automotores() { }


		/// <summary>
		/// Consulta automotores
		/// </summary>
		/// <param name="Param">0. Por Codigo de Cliente   1. Por Placa de Automotor</param>
		/// <param name="ParamData">codigo del cliente ó Placa del automotor</param>
		public Automotores(int Param, string ParamData){
			if (Param == 0){
				this._cod_Cli = ParamData;
			}else{
				this._placa = ParamData;
			}
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Index by Key
		/// </summary>
		new public Automotor this[string key]{
			get{ return (Automotor) base[key]; }
		}

		/// <summary>
		/// Index by cllection index
		/// </summary>
		new public Automotor this[int index] {
			get { return (Automotor) base[index]; }
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
			sql.Append("AutomotoQuery");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, this._cod_Cli);
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			#endregion

			#region Execute SqlStatement
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 1;
			while (dr.Read()){
				Automotor objAutomotor = new Automotor();
				try{
					objAutomotor.CodigoCliente = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();ParamNumber++;
					objAutomotor.PlacaAutomotor = dr.IsDBNull(1)?"(Sin Definir)":dr.GetString(1).Trim();ParamNumber++;
					objAutomotor.MarcaAutomotor = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();ParamNumber++;
					objAutomotor.ModeloAutomotor = dr.IsDBNull(3)?"(Sin Definir)":dr.GetString(3).Trim();ParamNumber++;
					objAutomotor.AñoAutomotor = dr.IsDBNull(4)?(int)0:(int)dr.GetInt16(4);ParamNumber++;
					objAutomotor.TipoAutomotor = dr.IsDBNull(5)?"":dr.GetString(5).Trim();ParamNumber++;
					objAutomotor.CodigoFormaDePagoAutomtor = dr.IsDBNull(6)?(int)0:(int)dr.GetInt16(6);ParamNumber++;
					objAutomotor.FechaProximoMantenimientoAutomotor = dr.IsDBNull(7)? new DateTime(1800,12,28,0,0,0,0):dr.GetDateTime(7);ParamNumber++;
					objAutomotor.CodigoCausalDeBloqueoAutomotor = dr.IsDBNull(8)?(int)0:(int)dr.GetInt16(8);ParamNumber++;
					objAutomotor.DescuentoAutomtor = dr.IsDBNull(9)?(decimal)0:dr.GetDecimal(9);ParamNumber++;
					objAutomotor.Monitoreo = dr.IsDBNull(10)?"InActivo":dr.GetString(10).Trim();ParamNumber++;
					objAutomotor.CapacidadTotalAutomtor = dr.IsDBNull(11)?(decimal)0:dr.GetDecimal(11);ParamNumber++;
					objAutomotor.NumeroMaxTanqueosDia = dr.IsDBNull(12)?(int)0:(int)dr.GetInt16(12);ParamNumber++;
					objAutomotor.NumeroTanquesAuto = dr.IsDBNull(13)?(int)0:(int)dr.GetInt16(13);ParamNumber++;
					objAutomotor.TipoDescuento = dr.IsDBNull(14)?(int)0:dr.GetInt32(14);ParamNumber++;
                    objAutomotor.CodigoInterno = dr.IsDBNull(15) ?"" : dr.GetString(15); ParamNumber++;
                    objAutomotor.IdTipoAutorizacioExterna = dr.IsDBNull(16) ? (int)1 : (int)dr.GetByte(16); ParamNumber++;		

				}catch {
					throw new Exception("(Servipunto.Estacion.Libreria.Comercial.Load) Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString()  + " !ERROR BD! ");
				}
				try{
					base.AddItem(objAutomotor.PlacaAutomotor, objAutomotor);
				}catch(Exception ex){
					throw new Exception("(Servipunto.Estacion.Libreria.Comercial.Load) Error al agregar registro objeto objAutomotor Placa: !!" + objAutomotor.PlacaAutomotor.Trim()  + " !ERROR APP! " + ex.Message);
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
		/// Inserta un automotor en la DB.
		/// </summary>
		/// <param name="objAutomotor"></param>
		public static void Adicionar(Automotor objAutomotor){

			#region Prepare Sql
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("AutomotoInsertion");
			sql.ParametersNumber = 17;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, objAutomotor.CodigoCliente);
			sql.AddParameter("@Placa", SqlDbType.VarChar, objAutomotor.PlacaAutomotor);
			sql.AddParameter("@Marca", SqlDbType.VarChar, objAutomotor.MarcaAutomotor);
			sql.AddParameter("@Modelo", SqlDbType.VarChar, objAutomotor.ModeloAutomotor);
			sql.AddParameter("@Ano", SqlDbType.Int, objAutomotor.AñoAutomotor);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, objAutomotor.TipoAutomotor);
			sql.AddParameter("@Cod_For_Pag", SqlDbType.Int, objAutomotor.CodigoFormaDePagoAutomtor);
			sql.AddParameter("@Fech_PrMa", SqlDbType.DateTime, objAutomotor.FechaProximoMantenimientoAutomotor);
			sql.AddParameter("@Descuento", SqlDbType.Decimal, objAutomotor.DescuentoAutomtor);
			sql.AddParameter("@Monitoreo", SqlDbType.VarChar, objAutomotor.Monitoreo);
			sql.AddParameter("@Cap_Total", SqlDbType.Decimal, objAutomotor.CapacidadTotalAutomtor);
			sql.AddParameter("@Max_Num_Tan", SqlDbType.Int, objAutomotor.NumeroMaxTanqueosDia);
			sql.AddParameter("@No_Tanques", SqlDbType.Int, objAutomotor.NumeroTanquesAuto);
			sql.AddParameter("@TipoDescuento", SqlDbType.Int, objAutomotor.TipoDescuento);
			sql.AddParameter("@Causal", SqlDbType.Int, objAutomotor.CodigoCausalDeBloqueoAutomotor);
            sql.AddParameter("@CodigoInterno", SqlDbType.VarChar, objAutomotor.CodigoInterno);
            sql.AddParameter("@IdTipoAutorizacionExterna", SqlDbType.TinyInt, objAutomotor.IdTipoAutorizacioExterna);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe el automotor " + objAutomotor.PlacaAutomotor  + " !ERROR BD! ");
				else
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
		/// Elimina vehiculos de la DB.
		/// </summary>
		/// <param name="Param">0. Por Codigo Cliente      1. Por Placa automotor</param>
		/// <param name="ParamData">Codigo de Cliente ó placa a eliminar</param>
		public static void Eliminar(int Param, string ParamData) {
			
			#region Choose Dletetion Parameter
			string Cod_Cli = null, Placa = null;
			if(Param == 0){
				Cod_Cli = ParamData;
			}else{
				Placa = ParamData;
			}
			#endregion
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("AutomotoDeletion");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, Cod_Cli);	
			sql.AddParameter("@Placa", SqlDbType.VarChar, Placa);
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

		#region GetItem
		/// <summary>
		/// Metodo para obtener un automotor en particular.
		/// </summary>
		/// <param name="Placa">Placa del automotor a Consultar</param>
		/// <returns>Datos de Automotor si existe. Null si no.</returns>
		public static Automotor ObtenerItem(string Placa) {
			Automotores objAutomotores = new Automotores(1, Placa);
			if (objAutomotores.Count == 1)
				return objAutomotores[0];
			else
				return null;
		}
		#endregion

		#region GetItems
		/// <summary>
		/// Permite obtener todos los automores asociados a un mismo cliente.
		/// </summary>
		/// <param name="CodCliente">Codigo del cliente a consultar.</param>
		/// <returns></returns>
		public static Automotores ObtenerItems(string CodCliente){
			Automotores objAutomotores = new Automotores(0, CodCliente);
			if (objAutomotores.Count > 0)
				return objAutomotores;
			else 
				return null;
		}

		#endregion
	}
}
