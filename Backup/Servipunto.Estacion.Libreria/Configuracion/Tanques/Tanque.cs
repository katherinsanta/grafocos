using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.Tanques {
	/// <summary>
	/// Clase para la administracion de Tanques
	/// </summary>
	public class Tanque {

		#region Declarations
		private int _cod_Tan;
		private decimal _capacidad;
		private int _cod_Art;
		private byte _convierteLitrosAGalones;
		private bool _gasOLiquido;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public Tanque() {}
		#endregion 

		#region Public Properties

		/// <summary>
		/// Codigo del tanque
		/// </summary>
		public int CodigoTanque {
			get { return this._cod_Tan; }
			set { this._cod_Tan = value;}
		}

		/// <summary>
		/// Capacidad del tanque
		/// </summary>
		public decimal CapacidadTanque {
			get { return this._capacidad; }
			set { this._capacidad = value;}
		}

		/// <summary>
		/// Codigo del Arituclo
		/// </summary>
		public int CodigoArticulo 
		{
			get { return this._cod_Art; }
			set { this._cod_Art = value; }
		}

		/// <summary>
		/// Define si convierte de litros a galones
		/// </summary>
		public byte ConvierteLitrosAGalones 
		{
			get { return this._convierteLitrosAGalones; }
			set { this._convierteLitrosAGalones = value; }
		}

		/// <summary>
		/// Define si el articulo es de gas o de liquidos
		/// </summary>
		public bool GasOLiquido 
		{
			get { return this._gasOLiquido; }
			set { this._gasOLiquido = value; }
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

			sql.Append("TanquesModification");
			sql.ParametersNumber = 5;
			sql.AddParameter("@Cod_Tan", SqlDbType.Int, this._cod_Tan);
			sql.AddParameter("@Capacidad", SqlDbType.Decimal, this._capacidad);
			sql.AddParameter("@Cod_art", SqlDbType.Decimal, this._cod_Art);
			sql.AddParameter("@ConvierteLitrosAGalones", SqlDbType.TinyInt, this._convierteLitrosAGalones);
			sql.AddParameter("@GasOLiquido", SqlDbType.Bit, this._gasOLiquido);
			
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
