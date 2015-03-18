using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Turnos
{
	/// <summary>
	/// Clase para administrar Jornadas Zeta en las estaciones de servicio
	/// </summary>
	public class JornadaZeta
	{
		#region Sección de Declaraciones
		private DateTime _fecha;
		private DateTime _fecha_Real;
		private DateTime _hora_Ini;
		private DateTime _hora_Fin;
		private string _estado;
		private string _codigoEmpleado;																																												 
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>		
		public JornadaZeta()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Fecha de la jornada zeta
		/// </summary>
		public DateTime Fecha
		{
			get { return this._fecha; }
			set { this._fecha = value; }
		}

		/// <summary>
		/// Fecha real de la jornada Zeta
		/// </summary>
		public DateTime Fecha_Real
		{
			get { return this._fecha_Real; }
			set { this._fecha_Real = value; }
		}



		/// <summary>
		/// Hora inicial de la jornada Zeta
		/// </summary>
		public DateTime Hora_Inicial
		{
			get { return this._hora_Ini; }
			set { this._hora_Ini = value; }
		}

		/// <summary>
		/// Hora final de la jornada Zeta
		/// </summary>
		public DateTime Hora_Final
		{
			get { return this._hora_Fin; }
			set { this._hora_Fin = value; }
		}

		/// <summary>
		/// Estado de la jornada
		/// 'C' = Cerrado
		/// 'A' = Abierto
		/// </summary>
		public string Estado
		{
			get { return this._estado; }
			set { this._estado = value; }
		}

		/// <summary>
		/// Codigo de empleado que abrio la jornada
		/// </summary>
		public string CodigoEmpleado
		{
			get { return this._codigoEmpleado; }
			set { this._codigoEmpleado = value; }
		}

		#endregion


		#region Método Modificar
		/// <summary>
		/// Actualiza una determinada jornada zeta
		/// </summary>
		/// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
		/// Fecha:  03/09/2008
		/// Autor:  Elvis Astaiza Gutierrez
		public void Modificar()
		{

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarJornadaZeta");
			sql.ParametersNumber = 6;
			sql.AddParameter("@Fecha", SqlDbType.DateTime, this._fecha);
			sql.AddParameter("@FechaReal", SqlDbType.DateTime, this._fecha_Real);
			sql.AddParameter("@HoraInicial", SqlDbType.DateTime, this._hora_Ini);
			sql.AddParameter("@HoraFinal", SqlDbType.DateTime, this._hora_Fin);
			sql.AddParameter("@Estado", SqlDbType.VarChar, this._estado);
			sql.AddParameter("@CodigoEmpleado", SqlDbType.VarChar, this._codigoEmpleado);

			#endregion
			
			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception("Error actualizando una jornada Zeta." + e.Message + " !ERROR BD! ");
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
