using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Cupo por cliente
	/// </summary>
	public class CupoCliente
	{
		#region Declarations
		//int _id;
		private string _cod_Cli; string _unidades = "P";
		private decimal _cupo_Asig, _cupo_Disp, _pagarCupo;
		#endregion

		#region Constructor
		/// <summary>
		/// Cupo por Clientes
		/// </summary>
		public CupoCliente() {}

		#endregion

		#region Public Properties
		/// <summary>
		/// Codigo del Cliente al cual esta asociado el cupo.
		/// </summary>
		public string CodigoCliente{
			get {return this._cod_Cli; }
			set {this._cod_Cli = value;}
		}


		/// <summary>
		/// Cupo Asigando al cliente
		/// </summary>
		public decimal CupoAsignado {
			get {return this._cupo_Asig; }
			set {this._cupo_Asig = value;}
		}
        

		/// <summary>
		/// Cupo Disponible del cliente
		/// </summary>
		public decimal CupoDisponible {
			get {return this._cupo_Disp; }
			set {this._cupo_Disp = value;}
		}


		/// <summary>
		/// Unidades del Credito.
		/// Web: No utilizar
		/// </summary>
		public string Unidades {
			get {return this._unidades; }
			set {this._unidades = value;}
		}


		/// <summary>
		/// Cantidad para abonar al cupo disponible
		/// </summary>
		public decimal PagarCupo {
			get { return this._pagarCupo; }
			set { this._pagarCupo = value;}
		}
		#endregion

		#region Modify
		/// <summary>
		/// Actualiza Propiedades del cupo del cliente.
		/// </summary>
		public void Modificar (){

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CupoClientesModification");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, this._cod_Cli);
			sql.AddParameter("@PagarCupo", SqlDbType.Decimal, this._pagarCupo);
			sql.AddParameter("@Unidades", SqlDbType.VarChar, this._unidades);
										
			#endregion

			#region Execute SqlCommand
			try{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}catch(SqlException exx){
				throw new Exception(exx.Message + " !ERROR BD! ");
			}finally{
				sql = null;
			}
			#endregion

		}
		#endregion
	}
}
