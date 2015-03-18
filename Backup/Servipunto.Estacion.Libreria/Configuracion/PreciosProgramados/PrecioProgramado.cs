using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.PreciosProgramados {
	
	/// <summary>
	/// Descripción breve de PrecioProgramado.
	/// </summary>
	public class PrecioProgramado {

		#region Declarations
		private DateTime _fecha;
		private int _cod_Art;
		private decimal _precio, _precio2, _precio3, _precio4;
		private string _estado, _nombre_Articulo;
		#endregion

		#region Constructor
		/// <summary>
		/// Precio Programado
		/// </summary>
		public PrecioProgramado() {	}
		#endregion

		#region Public_Properties

		/// <summary>
		/// Fecha para aplicar el cambio de precio
		/// </summary>
		public DateTime Fecha {
			get{ return this._fecha;  }
			set{ this._fecha = value; }
		}

		/// <summary>
		/// Codigo del Articulo
		/// </summary>
		public int CodigoArticulo {
			get { return this._cod_Art; }
			set { this._cod_Art = value;}
		}

		/// <summary>
		/// Nombre del Articulo
		/// </summary>
		public string NombreArticulo {
			get { return this._nombre_Articulo; }
			set { this._nombre_Articulo = value;}
		}

		/// <summary>
		/// Estado de la Programacion
		/// Aplicado.        No Aplicado.
		/// </summary>
		public string EstadoProgramacion {
			get { return this._estado; }
			set { this._estado = value;}
		}

		/// <summary>
		/// Nuevo Precio a configurar
		/// </summary>
		public decimal PrecioArticulo {
			get { return this._precio; } 
			set { this._precio = value;}
		}

		/// <summary>
		/// Nuevo Precio2 a configurar
		/// </summary>
		public decimal Precio2Articulo {
			get { return this._precio2; } 
			set { this._precio2 = value;}
		}

		/// <summary>
		/// Nuevo Precio3 a configurar
		/// </summary>
		public decimal Precio3Articulo {
			get { return this._precio3; } 
			set { this._precio3 = value;}
		}

		/// <summary>
		/// Nuevo Precio4 a configurar
		/// </summary>
		public decimal Precio4Articulo {
			get { return this._precio4; } 
			set { this._precio4 = value;}
		}

		#endregion

		#region Modify
		/// <summary>
		/// Permite Modificar PreciosProgramados
		/// </summary>
		public void Modificar () {
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("PreciosProgramadosModification");
			sql.ParametersNumber = 6;
			sql.AddParameter("@Date", SqlDbType.VarChar, this._fecha.ToString("yyyyMMdd"));
			sql.AddParameter("@Cod_Art", SqlDbType.Int, this._cod_Art);
			sql.AddParameter("@Precio", SqlDbType.Decimal, this._precio);
			sql.AddParameter("@Precio2", SqlDbType.Decimal, this._precio2);
			sql.AddParameter("@Precio3", SqlDbType.Decimal, this._precio3);
			sql.AddParameter("@Precio4", SqlDbType.Decimal, this._precio4);
			
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

	}
}
