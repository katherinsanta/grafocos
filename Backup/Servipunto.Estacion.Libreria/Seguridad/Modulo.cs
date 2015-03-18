using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// M�dulo del Sistema
	/// </summary>
	public class Modulo
	{
		#region Secci�n de Declaraciones
		private string _idModulo;

		private Opciones _opciones;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		internal Modulo()
		{
		}

		/// <summary>
		/// Destructor de la Clase
		/// </summary>
		~Modulo()
		{
			this._opciones = null;
		}
		#endregion

		#region Propiedades P�blicas
		/// <summary>
		/// Nombre del Modulo
		/// </summary>
		public string IdModulo
		{
			get { return this._idModulo; }
			set { this._idModulo = value; }
		}
		#endregion

		#region Referencia a Opciones del M�dulo
		/// <summary>
		/// Referencia a todas las opciones asociadas al m�dulo
		/// </summary>
		public Opciones Opciones
		{
			get
			{
				if (this._opciones == null)
					this._opciones = new Opciones(this._idModulo);

				return this._opciones;
			}
		}
		#endregion
	}
}