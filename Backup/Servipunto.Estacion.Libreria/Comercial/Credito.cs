using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Summary description for Credito.
	/// </summary>
	public class Credito
	{
		#region Declarations
		private string _ent_Consig, _placa, _tipo, _financiera, _nombrefinanciera, _tipoporcentaje;
		private int _numero;
		private Decimal _monto, _saldo, _porcentaje;
		#endregion

		#region Constructor
		/// <summary>
		/// 
		/// </summary>
		public Credito()
		{}
		#endregion

		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public string NombreFinanciera
		{
			get{ return this._nombrefinanciera;}
			set{ this._nombrefinanciera = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EntConsig
		{
			get{ return this._ent_Consig;}
			set{this._ent_Consig = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Financiera
		{
			get{ return this._financiera;}
			set{this._financiera = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlacaAutomotor
		{
			get{ return this._placa;}
			set{this._placa = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tipo
		{
			get{ return this._tipo;}
			set{this._tipo = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Numero
		{
			get{ return this._numero;}
			set{this._numero = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Decimal Monto
		{
			get{ return this._monto;}
			set{ this._monto = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Decimal Saldo
		{
			get{ return this._saldo;}
			set{ this._saldo = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Decimal Porcentaje
		{
			get{ return this._porcentaje;}
			set{ this._porcentaje = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TipoPorcentaje
		{
			get{ return this._tipoporcentaje;}
			set{ this._tipoporcentaje = value;}
		}
		#endregion

		#region Modificar Credito
		/// <summary>
		/// 
		/// </summary>
		public  void Modificar()
		{
			#region Prepara el estamento SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CreditoModification");
			sql.ParametersNumber = 8;
			sql.AddParameter("@Numero", SqlDbType.Int, this._numero);
			sql.AddParameter("@Ent_Consig", SqlDbType.VarChar, this._ent_Consig);
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, this._tipo);
			sql.AddParameter("@Financiera", SqlDbType.Int, Convert.ToString(this._financiera));
			sql.AddParameter("@TipoPorcentaje", SqlDbType.VarChar, this._tipoporcentaje);
			sql.AddParameter("@Monto", SqlDbType.Decimal, this._monto);
			sql.AddParameter("@Saldo", SqlDbType.Decimal, this._saldo);
			#endregion

			#region Ejecutar SQL
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException exx)
			{
				throw new Exception(exx.Message + " !ERROR BD! ");
			}
			finally
			{
				sql = null;
			}
			#endregion
		}
		#endregion
	}
}
