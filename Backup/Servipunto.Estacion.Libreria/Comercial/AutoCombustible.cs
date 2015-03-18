using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial {
	/// <summary>
	/// Summary description for AutoCombustible.
	/// </summary>
	public class AutoCombustible {

		#region Declarations
		string _placa, _nombre_Art;
		int _cod_Art;
		#endregion

		#region Constructor 

		/// <summary>
		/// Auto Combustible
		/// </summary>
		public AutoCombustible() { }
		#endregion

		#region Public Properties
		/// <summary>
		/// Placa del Automotor al que se le configura combustible
		/// </summary>
		public string PlacaAuto{
			get { return this._placa; }
			set { this._placa = value;}
		}

		/// <summary>
		/// Nombre del Articulo Configurado
		/// </summary>
		public string NombreArticulo {
			get { return this._nombre_Art; }
			set { this._nombre_Art = value;}
		}

        /// <summary>
        /// Codigo del articulo configurado.
        /// </summary>
		public int CodigoArticulo {
			get { return this._cod_Art; }
			set { this._cod_Art = value;}
		}

		#endregion

	}
}
