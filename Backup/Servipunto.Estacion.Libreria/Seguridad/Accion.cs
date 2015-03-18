using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Acciones asociadas a una opci�n de un m�dulo
	/// </summary>
	public class Accion
	{
		#region Secci�n de Declaraciones
		private string _idModulo;
		private string _idOpcion;
		private string _idAccion;
		private string _descripcion;

		private bool _existe;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		internal Accion()
		{
		}
		#endregion

		#region Propiedades P�blicas
		/// <summary>
		/// C�digo del Modulo
		/// </summary>
		public string IdModulo
		{
			get { return this._idModulo; }
			set { this._idModulo = value; }
		}

		/// <summary>
		/// C�digo de la Opci�n
		/// </summary>
		public string IdOpcion
		{
            
			get { return this._idOpcion; }
			set { this._idOpcion = value; }
		}

		/// <summary>
		/// C�digo de la Acci�n
		/// </summary>
		public string IdAccion
		{
			get { return this._idAccion; }
			set { this._idAccion = value; }
		}

		/// <summary>
		/// Descripci�n de la acci�n
		/// </summary>
		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value; }
		}

		/// <summary>
		/// Determina si la acci�n esta o no asignada al rol
		/// </summary>
		public bool Existe
		{
			get { return this._existe; }
			set {
				this._existe = value; }
		}
		#endregion

	}
}