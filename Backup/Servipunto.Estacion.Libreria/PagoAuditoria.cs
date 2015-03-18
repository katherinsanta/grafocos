using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// clase para adminsitrar la auditoria de cambios a las formas de pago de las venta(s)
	/// </summary>
	public class PagoAuditoria
	{
		#region Sección de Declaraciones
		private int _idPagosA;
		private int _Consecutivo;
		private Decimal _valorInicial;
		private int _codigoFormaPagoInicial;
		private Decimal _valorFinal;
		private int _codigoFormaPagoFinal;
		private string _idUsuario;
		private DateTime _fechaCambio;
		private string _observaciones;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public PagoAuditoria()
		{
		}
		#endregion

		#region Propiedades Públicas
		
		
		/// <summary>
		/// LLave primaria de pagos de auditoria
		/// </summary>
		public int CodigoPagosAuditoria
		{
			get { return this._idPagosA; }
			set { this._idPagosA = value; }
		}
	
		/// <summary>
		/// Codigo consecutivo de la forma de pago
		/// </summary>
		public int Consecutivo
		{
			get { return this._Consecutivo; }
			set { this._Consecutivo = value; }
		}

		/// <summary>
		/// Valor inicial de la forma de pago
		/// </summary>
		public Decimal ValorInicial
		{
			get { return this._valorInicial; }
			set { this._valorInicial = value; }
		}

		/// <summary>
		/// Codigo la forma de pago inicial
		/// </summary>
		public int CodigoFormaPagoInicial
		{
			get { return this._codigoFormaPagoInicial; }
			set { this._codigoFormaPagoInicial = value; }
		}

		/// <summary>
		/// Valor final de la nueva forma de pago
		/// </summary>
		public Decimal ValorFinal
		{
			get { return this._valorFinal; }
			set { this._valorFinal = value; }
		}

		/// <summary>
		/// Codigo de la forma de pago final
		/// </summary>
		public int CodigoFormaPagoFinal
		{
			get { return this._codigoFormaPagoFinal; }
			set { this._codigoFormaPagoFinal = value; }
		}

		/// <summary>
		/// id del usuario que inicio sesion para cambiar el pago
		/// </summary>
		public string IdUsuario
		{
			get { return this._idUsuario; }
			set { this._idUsuario = value; }
		}

		/// <summary>
		/// Fecha actual en la que se realizo el cambio
		/// </summary>
		public DateTime FechaCambio
		{
			get { return this._fechaCambio; }
			set { this._fechaCambio = value; }
		}
		/// <summary>
		/// Observaciones por la cual se realizo el cambio
		/// </summary>
		public string Observaciones
		{
			get { return this._observaciones; }
			set { this._observaciones = value; }
		}

		
		#endregion

	}
}
