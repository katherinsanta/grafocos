using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.Tanques
{
	/// <summary>
	/// Clase para la administracion de mensajes de variacion de tanques
	/// </summary>
	public class TanqueVariacionMensaje
	{
		#region Declarations
		int _idVariacionTanqueMensaje;
		int _idTanque;
		decimal _valorInicial;
		decimal _valorFinal;
		string _mensaje;
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public TanqueVariacionMensaje() {}
		#endregion 

		#region Public Properties

		/// <summary>
		/// Codigo del mensaje para la variacion del tanque
		/// </summary>
		public int CodigoMensaje
		{
			get { return this._idVariacionTanqueMensaje; }
			set { this._idVariacionTanqueMensaje = value;}
		}

		/// <summary>
		/// Capacidad del tanque
		/// </summary>
		public int CodigoTanque 
		{
			get { return this._idTanque; }
			set { this._idTanque = value;}
		}
		#endregion


		/// <summary>
		/// Valor Inicial 
		/// </summary>
		public decimal ValorInicial 
		{
			get { return this._valorInicial; }
			set { this._valorInicial = value;}
		}


		/// <summary>
		/// Valor Final
		/// </summary>
		public decimal ValorFinal 
		{
			get { return this._valorFinal; }
			set { this._valorFinal = value;}
		}

		/// <summary>
		/// Mensaje 
		/// </summary>
		public string Mensaje 
		{
			get { return this._mensaje; }
			set { this._mensaje = value;}
		}


		#endregion

		#region Modify
		/// <summary>
		/// Permite Modificar los datos de configuracion para un mensaje
		/// </summary>
		public void Modificar () 
		{
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarTanqueVariacionMensaje");
			sql.ParametersNumber = 5;
			sql.AddParameter("@idVariacionTanqueMensaje", SqlDbType.Int, this._idVariacionTanqueMensaje);
			sql.AddParameter("@IdTanque", SqlDbType.Int, this._idTanque);
			sql.AddParameter("@ValorInicial", SqlDbType.Decimal, this._valorInicial);
			sql.AddParameter("@ValorFinal", SqlDbType.Decimal, this._valorFinal);
			sql.AddParameter("@Mensaje", SqlDbType.VarChar, this._mensaje);
			#endregion 

			#region Execute Sql command
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
