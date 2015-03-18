using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Puerto COM
	/// </summary>
	public class Puerto
	{
		#region Sección de Declaraciones
		private string _idPuerto;
		private int _baudRate;
		private string _parity;
		private string _dataBits;
		private string _stop;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Puerto()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Identificador del Puerto
		/// </summary>
		public string IdPuerto
		{
			get { return this._idPuerto; }
			set { this._idPuerto = value; }
		}

		/// <summary>
		/// BaudRate
		/// </summary>
		public int BaudRate
		{
			get { return this._baudRate; }
			set { this._baudRate = value; }
		}

		/// <summary>
		/// Parity
		/// </summary>
		public string Parity
		{
			get { return this._parity; }
			set { this._parity = value; }
		}

		/// <summary>
		/// DataBits
		/// </summary>
		public string DataBits
		{
			get { return this._dataBits; }
			set { this._dataBits = value; }
		}

		/// <summary>
		/// Stop
		/// </summary>
		public string Stop
		{
			get { return this._stop; }
			set { this._stop = value; }
		}

		/*
		/// <summary>
		/// Indicador que determina si el puerto esta conectado o no al computador.
		/// </summary>
		public string Estado
    	{
			get{ return "Conectado";}
		}*/

		/// <summary>
		/// Full port details
		/// </summary>
		
		public override string ToString()
		{
			return this._idPuerto + ":" + this._baudRate.ToString() + ", " + this._parity + ", " + this._dataBits + ", " + this._stop;
		}
		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: BaudRate, Parity, DataBits, Stop
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarPuerto");
			sql.ParametersNumber = 5;
			sql.AddParameter("@IdPuerto", SqlDbType.VarChar, this._idPuerto);
			sql.AddParameter("@BaudRate", SqlDbType.Int, this._baudRate);
			sql.AddParameter("@Parity", SqlDbType.VarChar, this._parity);
			sql.AddParameter("@DataBits", SqlDbType.VarChar, this._dataBits);
			sql.AddParameter("@Stop", SqlDbType.VarChar, this._stop);
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