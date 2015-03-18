using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Empleado.
	/// </summary>
	public class Empleado
	{
		#region Sección de Declaraciones
		private string _idEmpleado;
		private string _nombre;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Empleado()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Código del Empleado.
		/// </summary>
		public string IdEmpleado
		{
			get { return this._idEmpleado; }
			set { this._idEmpleado = value; }
		}

		/// <summary>
		/// Nombre del Empleado.
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}
		#endregion
	}
}