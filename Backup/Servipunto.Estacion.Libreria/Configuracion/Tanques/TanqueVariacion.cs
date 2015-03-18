using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.Tanques
{
	/// <summary>
	/// Clase para la administracion de Variaciones de tanques
	/// </summary>
	public class TanqueVariacion
	{

		#region Declarations
		private int _idTanque;
		private DateTime _fecha;
		private decimal _saldo_Inicial;
		private decimal _lect_Inicial_Agua;
		private decimal _compras;
		private decimal _saldo_Final;
        private decimal _transito;
        private decimal _compraFactura;

		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public TanqueVariacion() {}
		#endregion 

		#region Public Properties

		/// <summary>
		/// Codigo del tanque
		/// </summary>
		public int CodigoTanque 
		{
			get { return this._idTanque; }
			set { this._idTanque = value;}
		}

		/// <summary>
		/// Fecha del registro
		/// </summary>
		public DateTime Fecha
		{
			get { return this._fecha; }
			set { this._fecha = value;}
		}

		/// <summary>
		/// Saldo inicial del tanque
		/// </summary>
		public decimal SaldoInicial 
		{
			get { return this._saldo_Inicial; }
			set { this._saldo_Inicial = value;}
		}

		/// <summary>
		/// Lectura inicial del tanque
		/// </summary>
		public decimal LecturaInicialAgua
		{
			get { return this._lect_Inicial_Agua; }
			set { this._lect_Inicial_Agua = value;}
		}

		/// <summary>
		/// Compras
		/// </summary>
		public decimal Compras
		{
			get { return this._compras; }
			set { this._compras = value;}
		}

		/// <summary>
		/// Saldo final
		/// </summary>
		public decimal SaldoFinal
		{
			get { return this._saldo_Final; }
			set { this._saldo_Final = value;}
		}

        /// <summary>
        /// Transito
        /// </summary>
        public decimal Transito
        {
            get { return this._transito; }
            set { this._transito = value; }
        }

        /// <summary>
        /// Compra Factura
        /// </summary>
        public decimal CompraFactura
        {
            get { return this._compraFactura; }
            set { this._compraFactura = value; }
        }

		#endregion

		#region Modify
		/// <summary>
		/// Permite Modificar Tanques
		/// </summary>
		public void Modificar () 
		{
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarTanquesVariacion");
			sql.ParametersNumber = 8;
			sql.AddParameter("@IdTanque", SqlDbType.Int, this._idTanque);
			sql.AddParameter("@Fecha", SqlDbType.DateTime, this._fecha);
			sql.AddParameter("@Saldo_Inicial", SqlDbType.Decimal, this._saldo_Inicial);
			sql.AddParameter("@Lect_Inicial_Agua", SqlDbType.Decimal, this._lect_Inicial_Agua);
			sql.AddParameter("@Compras", SqlDbType.Decimal, this._compras);
			sql.AddParameter("@Saldo_Final", SqlDbType.Decimal, this._saldo_Final);
            sql.AddParameter("@Transito", SqlDbType.Decimal, this._transito);
            sql.AddParameter("@CompraFactura", SqlDbType.Decimal, this._compraFactura);
			#endregion 

			#region Execute Sql command
			try 
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) 
			{
				throw new Exception(e.Message + " !ERROR BD! ");
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
