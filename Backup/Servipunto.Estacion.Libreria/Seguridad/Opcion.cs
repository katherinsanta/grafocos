using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Opción de un Módulo
	/// </summary>
	public class Opcion
	{
		#region Sección de Declaraciones
		private string _idModulo;
		private string _idOpcion;

		private Acciones _acciones;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		internal Opcion()
		{
		}

		/// <summary>
		/// Destructor de la clase
		/// </summary>
		~Opcion()
		{
			this._acciones = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Código del Modulo
		/// </summary>
		public string IdModulo
		{
			get { return this._idModulo; }
			set { this._idModulo = value; }
		}

		/// <summary>
		/// Código de la Opción
		/// </summary>
		public string IdOpcion
		{
			get { return this._idOpcion; }
			set { this._idOpcion = value; }
		}
		#endregion

		#region Referencia a Acciones de la Opción
		/// <summary>
		/// Referencia a todas las acciones asociadas a la opción
		/// </summary>
		public Acciones Acciones
		{
			get
			{
				if (this._acciones == null)
					this._acciones = new Acciones(this._idModulo, this._idOpcion);

				return this._acciones;
			}
		}
		#endregion
	}
}