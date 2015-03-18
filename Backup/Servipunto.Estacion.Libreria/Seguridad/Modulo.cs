using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Módulo del Sistema
	/// </summary>
	public class Modulo
	{
		#region Sección de Declaraciones
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

		#region Propiedades Públicas
		/// <summary>
		/// Nombre del Modulo
		/// </summary>
		public string IdModulo
		{
			get { return this._idModulo; }
			set { this._idModulo = value; }
		}
		#endregion

		#region Referencia a Opciones del Módulo
		/// <summary>
		/// Referencia a todas las opciones asociadas al módulo
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