using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Clase para adminstrar registros log de sesiones de usuario.
	/// </summary>
	public class UsuarioLog
	{
		#region Sección de Declaraciones
		private string _cod_Emp;
		private bool _inicioSesion;
		private int _num_Tur;
		#endregion
		
		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		
		public UsuarioLog()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Código del Empleado
		/// </summary>
		public string CodigoEmpleado
		{
			get { return this._cod_Emp; }
			set { this._cod_Emp = value; }
		}

		/// <summary>
		/// Estado para determinar si inicia sesión o termina sesión
		/// </summary>
		public bool InicioSesion
		{
			get { return this._inicioSesion; }
			set { this._inicioSesion = value; }
		}

		/// <summary>
		/// Numero del turno
		/// </summary>
		public int NumeroTruno
		{
			get { return this._num_Tur; }
			set { this._num_Tur = value; }
		}
		
		#endregion

		#region Método Adicionar
		/// <summary>
		/// Adiciona un registro de Log de usuario a la BD
		/// </summary>
		/// <param name="objUsuarioLog">Información del usuario</param>
		public static void Adicionar(UsuarioLog objUsuarioLog)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarUsuarioLog");
			sql.ParametersNumber = 3;

			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, objUsuarioLog.CodigoEmpleado);
			sql.AddParameter("@Num_Tur", SqlDbType.Int, objUsuarioLog.NumeroTruno);

			if(objUsuarioLog.InicioSesion)
				sql.AddParameter("@Opcion", SqlDbType.Int, 1);
			else
				sql.AddParameter("@Opcion", SqlDbType.Int, 2);
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
