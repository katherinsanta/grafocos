using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Art�culo
	/// </summary>
	public class Articulo
	{
		#region Secci�n de Declaraciones
		private short _idArticulo;
		private string _descripcion;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Articulo()
		{
		}
		#endregion

		#region Propiedades P�blicas
		/// <summary>
		/// C�digo del Art�culo
		/// </summary>
		public short IdArticulo
		{
			get { return this._idArticulo; }
			set { this._idArticulo = value; }
		}

		/// <summary>
		/// Nombre descriptivo del art�culo
		/// </summary>
		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value; }
		}
		#endregion
	}
}