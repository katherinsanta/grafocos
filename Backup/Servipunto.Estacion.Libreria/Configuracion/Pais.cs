using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Ciudad
	/// </summary>
	public class Pais
	{
		#region Sección de Declaraciones
		private int _idPais;
		private string _nombre;
		private string _codigo;
		private Departamentos _departamentos;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Pais()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id del Pais
		/// </summary>
		public int IdPais
		{
			get { return this._idPais; }
			set { this._idPais = value; }
		}

		/// <summary>
		/// Nombre Descriptivo
		/// </summary>
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}

		/// <summary>
		/// Codigo Pais
		/// </summary>
		public string Codigo
		{
			get { return this._codigo; }
			set { this._codigo = value; }
		}

		/// <summary>
		/// Departamentos pertenecientes al país
		/// </summary>
		public Departamentos Departamentos
		{
			get
			{
				if (this == null)
					this._departamentos = new Departamentos(this._idPais);

				return this._departamentos;
			}
		}
		#endregion

	}
}