using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


namespace Servipunto.Estacion.Libreria.Turnos
{
	/// <summary>
	/// Clase para administrar Turnos laborales en las estaciones de servicio
	/// </summary>
	public class TurnoLaboral
	{
		#region Sección de Declaraciones
		private DateTime _fecha;
		private short _num_tur;
		private short _cod_isl;
		private string _estado;
		private DateTime _hora_Ini;
		private DateTime _hora_Fin;
		private string _cod_emp;
		private int _conciliado;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>	
		public TurnoLaboral()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Fecha del turno
		/// </summary>
		public DateTime Fecha
		{
			get { return this._fecha; }
			set { this._fecha = value; }
		}


		/// <summary>
		/// Hora inicial del turno
		/// </summary>
		public DateTime Hora_Inicial
		{
			get { return this._hora_Ini; }
			set { this._hora_Ini = value; }
		}

		/// <summary>
		/// Hora final del turno
		/// </summary>
		public DateTime Hora_Final
		{
			get { return this._hora_Fin; }
			set { this._hora_Fin = value; }
		}

		/// <summary>
		/// Estado del turno
		/// 'C' = Cerrado
		/// 'A' = Abierto
		/// </summary>
		public string Estado
		{
			get { return this._estado; }
			set { this._estado = value; }
		}

		/// <summary>
		/// Numero de turno
		/// </summary>
		public short NumeroTurno
		{
			get { return this._num_tur; }
			set { this._num_tur = value; }
		}

		/// <summary>
		/// Codigo de la isla
		/// </summary>
		public short CodigoIsla
		{
			get { return this._cod_isl; }
			set { this._cod_isl = value; }
		}

		/// <summary>
		/// Codigo del empleado
		/// </summary>
		public string CodigoEmpleado
		{
			get { return this._cod_emp; }
			set { this._cod_emp = value; }
		}

		
		/// <summary>
		/// Conciliado
		/// </summary>
		public int Conciliado
		{
			get { return this._conciliado; }
			set { this._conciliado = value; }
		}

		#endregion

				
	}
}
