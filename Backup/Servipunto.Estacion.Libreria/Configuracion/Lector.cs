using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Lector DS
	/// </summary>
	public class Lector
	{
		#region Sección de Declaraciones
		private string _idLector;
		private string _idPuerto;
		private string _idInterfaz;
		private short _version;
		private bool _monitoreo;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Lector()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Lector
		/// </summary>
		public string IdLector
		{
			get { return this._idLector; }
			set { this._idLector = value; }
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
		/// Id Interfaz DS
		/// </summary>
		public string IdInterfaz
		{
			get { return this._idInterfaz; }
			set { this._idInterfaz = value; }
		}

		/// <summary>
		/// Número de la versión
		/// </summary>
		public short Version
		{
			get { return this._version; }
			set { this._version = value; }
		}

		/// <summary>
		/// Indicador que determina si el lector soporta o no control de monitoreo.
		/// </summary>
		public bool Monitoreo
		{
			get { return this._monitoreo; }
			set { this._monitoreo = value; }
		}
		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: IdPuerto, IdInterfaz, Version, Monitoreo
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarLector");
			sql.ParametersNumber = 5;
			sql.AddParameter("@IdLector", SqlDbType.VarChar, this._idLector);
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, this._idPuerto);
			sql.AddParameter("@IdInterfaz", SqlDbType.VarChar, this._idInterfaz);
			sql.AddParameter("@Version", SqlDbType.SmallInt, this._version);
			sql.AddParameter("@Monitoreo", SqlDbType.Bit, this._monitoreo);
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
	}
}