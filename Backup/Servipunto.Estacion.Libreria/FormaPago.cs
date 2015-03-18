using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Formas de pago.
	/// </summary>
	public class FormaPago
	{
		#region Sección de Declaraciones
		private short _idFormaPago;
		private string _nombre;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public FormaPago()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Código de la Forma de Pago.
		/// </summary>
		public short IdFormaPago
		{
			get { return this._idFormaPago; }
			set { this._idFormaPago = value; }
		}

		/// <summary>
		/// Nombre de la Forma de Pago.
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}
		#endregion
	}
}