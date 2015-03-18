using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Capturador
	/// </summary>
	public class Capturador
	{
		#region Sección de Declaraciones
		private short _idCapturador;
		private string _idPuerto;
		private Puerto _puerto;
		private bool _capturadorSerial;
		private string _direccionIP;
		private int _puertoSocketEscucha;
		private int _puertoSocket3ro;
		private string _direccionIP3ro;
		int _idRegistro = -1;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la clase.
		/// </summary>
		public Capturador()
		{
		}

		/// <summary>
		/// Destructor de la clase.
		/// </summary>
		~Capturador()
		{
			this._puerto = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Capturador
		/// </summary>
		public short IdCapturador
		{
			get { return this._idCapturador; }
			set { this._idCapturador = value; }
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
		/// Aplica Capturador Serial
		/// </summary>
		public bool CapturadorSerial
		{
			get { return this._capturadorSerial; }
			set { this._capturadorSerial = value; }
		}
		
		/// <summary>
		/// Direccion ip del controlador
		/// </summary>
		public string DireccionIP
		{
			get { return this._direccionIP; }
			set { this._direccionIP = value; }
		}

		/// <summary>
		/// Puerto socket por el cual escuchara informacion proveniento desde el servidor del tercero
		/// </summary>
		public int PuertoSocketEscucha
		{
			get { return this._puertoSocketEscucha; }
			set { this._puertoSocketEscucha = value; }
		}
		
		/// <summary>
		/// Puerto socket por el cual se establecera comunicacion con el servidor del tercero
		/// </summary>
		public int PuertoSocket3ro
		{
			get { return this._puertoSocket3ro; }
			set { this._puertoSocket3ro = value; }
		}		/// <summary>
		/// Direccion IP del servidor del 3ro donde enviara los datos de pagos de venta la MRVirtual
		/// </summary>
		public string DireccionIP3ro
		{
			get { return this._direccionIP3ro; }
			set { this._direccionIP3ro = value; }
		}

		/// <summary>
		/// Id del Registro
		/// </summary>
		public int IdRegistro
		{
			get { return this._idRegistro; }
			set { this._idRegistro = value; }
		}

		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: IdPuerto
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarCapturador"); 
			sql.ParametersNumber = 8;
			sql.AddParameter("@IdCapturador", SqlDbType.SmallInt, this._idCapturador);
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, this._idPuerto);
			sql.AddParameter("@CapturadorSerial", SqlDbType.TinyInt, this._capturadorSerial);
			sql.AddParameter("@DireccionIP", SqlDbType.VarChar, this._direccionIP);
			sql.AddParameter("@Puerto_Socket_Escucha", SqlDbType.Int, this._puertoSocketEscucha);
			sql.AddParameter("@DireccionIP3ro", SqlDbType.VarChar, this._direccionIP3ro);
			sql.AddParameter("@Puerto_Socket3ro", SqlDbType.Int, this._puertoSocket3ro);
			sql.AddParameter("@IdRegistro", SqlDbType.Int, this._idRegistro);
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

		#region Referencia a objecto Puerto
		/// <summary>
		/// Referencia al objeto Puerto asociado al capturador.
		/// </summary>
		public Puerto Puerto
		{
			get
			{
				if (this._puerto == null)
					this._puerto = Puertos.ObtenerItem(this._idPuerto);

				return this._puerto;
			}
		}
		#endregion
	}
}