using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Clase para Administrar el Horario permitido de tanqueo para automotores registrados en el sistema.
	/// </summary>
	public class Restriccion
	{
		#region Sección de Declaraciones
		private string _placa;
		private short _dia;
		private DateTime _hora_Inicio;
		private DateTime _hora_Fin;
		private string _hora_Inicio_Display;
		private string _hora_Fin_Display;
		private int _opcion;
		private string _nombreDia;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Restriccion()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Placa del automotor
		/// </summary>
		public string  Placa
		{
			get { return this._placa; }
			set { this._placa = value; }
		}

		/// <summary>
		/// Dia de restricción
		/// </summary>
		public short Dia
		{
			get { return this._dia; }
			set { this._dia = value; }
		}

		/// <summary>
		/// Hora de inicio de la restricción
		/// </summary>
		public DateTime HoraInicio
		{
			get { return this._hora_Inicio; }
			set { this._hora_Inicio = value; }
		}

		/// <summary>
		/// Hora final de la restricción
		/// </summary>
		public DateTime HoraFin
		{
			get { return this._hora_Fin; }
			set { this._hora_Fin = value; }
		}
	

		/// <summary>
		/// Opcion para algunos procedimientos
		/// </summary>
		public int Opcion
		{
			get { return this._opcion; }
			set { this._opcion = value; }
		}
	
		/// <summary>
		/// Nombre del dia
		/// </summary>
		public string NombreDia
		{
			get { return this._nombreDia; }
			set { this._nombreDia = value; }
		}
	
		/// <summary>
		/// Hora de inicio en formato militar 
		/// </summary>
		public string HoraInicioDisplay
		{
			get { return this._hora_Inicio_Display; }
			set { this._hora_Inicio_Display = value; }
		}
	
		/// <summary>
		/// Hora de fin en formato militar 
		/// </summary>
		public string HoraFinDisplay
		{
			get { return this._hora_Fin_Display; }
			set { this._hora_Fin_Display = value; }
		}

		/// <summary>
		/// Todos los detalles de Restriccion
		/// </summary>
		
		public override string ToString()
		{
			return this._placa + ", " + this._dia.ToString() + ", " + this._hora_Inicio.ToString() + ", " + this._hora_Fin.ToString();
		}
		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: BaudRate, Parity, DataBits, Stop
		/// <param name="diaPK">Dia que conforma la llave primaria del registro a modificar</param>
		/// <param name="horaInicioPK">Hora de inicio que conforma la llave primaria del registro a modificar</param>
		/// </summary>
		public void Modificar(short diaPK, DateTime horaInicioPK)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarRestriccion");
			sql.ParametersNumber = 6;
			sql.AddParameter("@DiaPK", SqlDbType.Int, diaPK);
			sql.AddParameter("@Hora_InicioPK", SqlDbType.DateTime, horaInicioPK);
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			sql.AddParameter("@Dia", SqlDbType.Int, this._dia);
			sql.AddParameter("@Hora_Inicio", SqlDbType.DateTime, this._hora_Inicio);
			sql.AddParameter("@Hora_Fin", SqlDbType.DateTime, this._hora_Fin);
			//sql.AddParameter("@Opcion", SqlDbType.SmallInt, this._Opcion);			#endregion
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
