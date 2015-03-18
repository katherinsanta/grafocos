using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Artículo
	/// </summary>
	public class Articulo
	{
		#region Sección de Declaraciones
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

		#region Propiedades Públicas
		/// <summary>
		/// Código del Artículo
		/// </summary>
		public short IdArticulo
		{
			get { return this._idArticulo; }
			set { this._idArticulo = value; }
		}

		/// <summary>
		/// Nombre descriptivo del artículo
		/// </summary>
		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value; }
		}
		#endregion
	}
}