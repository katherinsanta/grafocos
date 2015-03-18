using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Cliente
	/// </summary>
	public class Cliente
	{
		#region Secci�n de Declaraciones
		private string _idCliente;
		private string _nombre;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Cliente()
		{
		}
		#endregion

		#region Propiedades P�blicas
		/// <summary>
		/// C�digo del Cliente
		/// </summary>
		public string IdCliente
		{
			get { return this._idCliente; }
			set { this._idCliente = value; }
		}

		/// <summary>
		/// Nombre del Cliente
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}
		#endregion

	}
}