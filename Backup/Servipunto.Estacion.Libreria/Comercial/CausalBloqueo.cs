using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Descripción breve de CausalBloqueo.
	/// </summary>
	public class CausalBloqueo {

		#region Declarations
		private int _causal;
		private string _descripcion, _responsable;
		#endregion

		#region Constructor
		/// <summary>
		/// Causal de bloqueo
		/// </summary>
		public CausalBloqueo(){ }
		#endregion

		#region Public Properties
		/// <summary>
		/// Codigo de la causal de bloqueo
		/// </summary>
		public int CodigoCausal{
			get{ return this._causal; }
			set{ this._causal = value;}
		}

		/// <summary>
		/// Descripcion de la causal de bloqueo
		/// </summary>
		public string DescripcionCausal {
			get { return this._descripcion; }
			set { this._descripcion = value;}
		}

		/// <summary>
		/// Responsable de la causal de bloqueo
		/// </summary>
		public string ResponsableCausal {
			get { return this._responsable; }
			set { this._responsable = value;}
		}
		#endregion

		#region Modify
		/// <summary>
		/// Permite modificar una causal de bloqueo
		/// </summary>
		public void Modificar (){

			#region Prepare SqlStatement
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CausalBloqueoModification");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Causal", SqlDbType.Int, this._causal);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, this._descripcion);
			sql.AddParameter("@Responsable", SqlDbType.VarChar, this._responsable);			
			#endregion

			#region Execute SqlStatement
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
