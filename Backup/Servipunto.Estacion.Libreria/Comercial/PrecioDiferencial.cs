using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial {
	/// <summary>
	/// Summary description for PrecioDiferencial.
	/// </summary>
	public class PrecioDiferencial {

		#region Declarations
		private int _idPrecio, _cod_Art;
		private decimal _precio;
		private string _nombreArt;
		#endregion

		#region Constructor
		/// <summary>
		/// Precio Diferencial
		/// </summary>
		public PrecioDiferencial() {}
		#endregion

		#region Public Properties
		/// <summary>
		/// Id de la lista de precios diferenciales
		/// </summary>
		public int IdPrecioDiferencial {
			get { return this._idPrecio; }
			set { this._idPrecio = value;}
		}

		/// <summary>
		/// Codigo del articulo con precio diferencial
		/// </summary>
		public int CodigoArticulo {
			get { return this._cod_Art; }
			set { this._cod_Art = value;}
		}

		/// <summary>
		/// Precio Diferencial del Articulo
		/// </summary>
		public decimal PrecioDiferencialArticulo {
			get { return this._precio; }
			set { this._precio = value;}
		}

		/// <summary>
		/// Nombre del Articulo con precio diferencial
		/// </summary>
		public string NombreArticulo {
			get { return this._nombreArt; }
			set { this._nombreArt = value;}
		}
		#endregion

		#region Modify
		/// <summary>
		/// Permite modificar el precio de un articulo en una lista de precio diferencial
		/// </summary>
		public void Modificar (){

			#region Prepare SqlStatement
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ListaPreciosModification");
			sql.ParametersNumber = 3;
			sql.AddParameter("@IdPrecio", SqlDbType.Int, this._idPrecio);
			sql.AddParameter("@Cod_Art", SqlDbType.Int, this._cod_Art);
			sql.AddParameter("@Precio", SqlDbType.Decimal, this._precio);			
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
