using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Clase Permiso
	/// </summary>
	public class Permiso
	{
		#region Secci�n de Declaraciones
		private byte _idRol;
		private string _idModulo;
		private string _idOpcion;
		private string _idAccion;
		private string _descripcion;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Permiso()
		{
		}
		#endregion

		#region Propiedades P�blicas
		/// <summary>
		/// C�digo del Rol
		/// </summary>
		public byte IdRol
		{
			get { return this._idRol; }
			set { this._idRol = value; }
		}

		/// <summary>
		/// C�digo del m�dulo
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
		#endregion

	}
}