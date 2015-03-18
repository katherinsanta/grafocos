using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Controlador
	/// </summary>
	public class Controlador
	{
		#region Sección de Declaraciones
		private short _idControlador;
		private string _idPuerto;
		private string _descripcion;
		private string _puertoConcentrador;

		private Puerto _puerto;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la clase.
		/// </summary>
		public Controlador()
		{
		}

		/// <summary>
		/// Destructor de la clase.
		/// </summary>
		~Controlador()
		{
			this._puerto = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Controlador
		/// </summary>
		public short IdControlador
		{
			get { return this._idControlador; }
			set { this._idControlador = value; }
		}

		/// <summary>
		/// Puerto Serial
		/// </summary>
		public string IdPuerto
		{
			get { return this._idPuerto; }
			set { this._idPuerto = value; }
		}

		/// <summary>
		/// Descripción
		/// </summary>
		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value; }
		}

		/// <summary>
		/// Puerto para el concentrador
		/// </summary>
		public string PuertoConcentrador
		{
			get { return this._puertoConcentrador; }
			set { this._puertoConcentrador = value; }
		}
		#endregion

		
		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: IdPuerto, Descripcion
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarControlador");
			sql.ParametersNumber = 4;
			sql.AddParameter("@IdControlador", SqlDbType.SmallInt, this._idControlador);
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, this._idPuerto);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, this._descripcion);
			if(_puertoConcentrador.Trim() != "(sin definir)")
				sql.AddParameter("@PuertoConcentrador", SqlDbType.VarChar, this._puertoConcentrador);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Referencia a objeto Puerto
		/// <summary>
		/// Referencia al puerto asociado al controlador.
		/// </summary>
		public Puerto Puerto
		{
			get 
			{
				if (this._puerto == null)
					this._puerto = Libreria.Configuracion.Puertos.ObtenerItem(this._idPuerto);

				return this._puerto;
			}
		}
		#endregion

		#region ToString()
		/// <summary>
		/// Full descripción del controlador (Nombre del Controlador + Detalles del Puerto)
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this._descripcion + " [" + this.Puerto.ToString() + "]";
		}
		#endregion

	}
}