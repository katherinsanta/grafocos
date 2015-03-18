using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Cupo por Automotor.
	/// </summary>
	public class CupoAutomotor
	{
		#region Declarations
		private string _placa; string _unidades = "P";
		private decimal _cupo_Asig, _cupo_Disp, _pagarCupo;
		#endregion

		#region Constructor
		/// <summary>
		/// Cupo por Automotor
		/// </summary>
		public CupoAutomotor() { }
		#endregion

		#region Public Properties
		/// <summary>
		/// Placa del Automotor al cual esta asociado el cupo.
		/// </summary>
		public string PlacaAutomotor{
			get {return this._placa; }
			set {this._placa = value;}
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
		/// Actualiza Propiedades del cupo del automotor.
		/// </summary>
		public void Modificar (){

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CupoAutomotoresModification");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
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
