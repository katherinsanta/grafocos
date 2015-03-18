using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Pago relacionado a una venta.
	/// </summary>
	public class Pago
	{
		#region Sección de Declaraciones
		private int _id_Pagos;
		private string _prefijo;
		private int _consecutivo;
		private decimal _total;
		private int _cod_for_Pag;
		private DateTime _fecha;
		private DateTime _fecha_Real;
		private string _numero_Consecutivo_FP;
		private decimal _cantidad;
		private decimal _valorNeto;
		private decimal _descuento;
		private decimal _subTotal;
		private decimal _vr_Iva;
		private decimal _total_Cuota;
		private int _cod_Art;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Pago()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// LLave primaria 
		/// </summary>
		public int IdPago
		{
			get { return this._id_Pagos; }
			set { this._id_Pagos = value; }
		}

		/// <summary>
		/// Prefijo de la venta
		/// </summary>
		public string PrefijoVenta
		{
			get { return this._prefijo; }
			set { this._prefijo = value; }
		}

		/// <summary>
		/// Numero consecutivo de la venta
		/// </summary>
		public int ConsecutivoVenta
		{
			get { return this._consecutivo; }
			set { this._consecutivo = value; }
		}

		/// <summary>
		/// total de la forma del pago
		/// </summary>
		public decimal Total
		{
			get { return this._total; }
			set { this._total = value; }
		}

		/// <summary>
		/// Codigo de la forma de pago
		/// </summary>
		public int CodigoFormaPago
		{
			get { return this._cod_for_Pag; }
			set { this._cod_for_Pag = value; }
		}

		/// <summary>
		/// Fecha
		/// </summary>
		public DateTime Fecha
		{
			get { return this._fecha; }
			set { this._fecha = value; }
		}

		/// <summary>
		/// Fecha
		/// </summary>
		public DateTime FechaReal
		{
			get { return this._fecha_Real; }
			set { this._fecha_Real = value; }
		}

				
		/// <summary>
		/// Consecutivo de la forma de Pago
		/// </summary>
		public string ConsecutivoFormaPago
		{
			get { return this._numero_Consecutivo_FP; }
			set { this._numero_Consecutivo_FP = value; }
		}

		/// <summary>
		/// Cantidad
		/// </summary>
		public decimal Cantidad
		{
			get { return this._cantidad; }
			set { this._cantidad = value; }
		}

		/// <summary>
		/// Valor neto
		/// </summary>
		public decimal ValorNeto
		{
			get { return this._valorNeto; }
			set { this._valorNeto = value; }
		}

		/// <summary>
		/// Descuento
		/// </summary>
		public decimal Descuento
		{
			get { return this._descuento; }
			set { this._descuento = value; }
		}

		/// <summary>
		/// Sub total
		/// </summary>
		public decimal subTotal
		{
			get { return this._subTotal;}
			set { this._subTotal = value;}
		}

		/// <summary>
		/// Iva
		/// </summary>
		public decimal Iva
		{
			get { return this._vr_Iva;}
			set { this._vr_Iva = value;}
		}
		

		/// <summary>
		/// Total de cuota
		/// </summary>
		public decimal TotalCuota
		{
			get { return this._total_Cuota; }
			set { this._total_Cuota = value;}
		}
	

		/// <summary>
		/// Codigo del articulo
		/// </summary>
		public int CodigoArticulo
		{
			get { return this._cod_Art; }
			set { this._cod_Art = value;}
		}
	

		#endregion

		#region Modificar
		/// <summary>
		/// Actualiza un pago
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarPago");
			sql.ParametersNumber = 15;
			sql.AddParameter("@Id_Pagos", SqlDbType.Int, this._id_Pagos);
			sql.AddParameter("@Prefijo", SqlDbType.VarChar, this._prefijo);
			sql.AddParameter("@Consecutivo", SqlDbType.Int, this._consecutivo);
			sql.AddParameter("@Total", SqlDbType.Decimal, this._total);
			sql.AddParameter("@Cod_for_Pag", SqlDbType.Int, this._cod_for_Pag);
			sql.AddParameter("@Fecha", SqlDbType.DateTime, this._fecha);
			sql.AddParameter("@Fecha_Real", SqlDbType.DateTime, this._fecha_Real);
			sql.AddParameter("@Numero_Consecutivo_FP", SqlDbType.VarChar, this._numero_Consecutivo_FP);
			sql.AddParameter("@Cantidad", SqlDbType.Decimal, this._cantidad);
			sql.AddParameter("@ValorNeto", SqlDbType.Decimal, this._valorNeto);
			sql.AddParameter("@Descuento", SqlDbType.Decimal, this._descuento);
			sql.AddParameter("@SubTotal", SqlDbType.Decimal, this._subTotal);
			sql.AddParameter("@Vr_Iva", SqlDbType.Decimal, this._vr_Iva);
			sql.AddParameter("@Total_Cuota", SqlDbType.Decimal, this._total_Cuota);
			sql.AddParameter("@Cod_Art", SqlDbType.Int, this._cod_Art);

			#endregion

			#region Execute Sql
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
