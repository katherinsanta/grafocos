using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Configuración de ventas tipo PRESET o Selfservice.
	/// </summary>
	public class Selfservice
	{
		#region Sección de Declaraciones
		private int _idSelfservice;
		private decimal _valorBoton1;
		private decimal _valorBoton2;
		private decimal _valorBoton3;
		private decimal _valorBoton4;
		private decimal _valorBoton5;
		private decimal _valorBoton6;
		private short _caraBoton1;
		private short _caraBoton2;
		private short _caraBoton3;
		private short _caraBoton4;
		private short _caraBoton5;
		private short _caraBoton6;
		private short _caraBoton7;
		private short _caraBoton8;
		private short _caraBoton9;
		private short _caraBoton10;
		private short _caraBoton11;
		private short _caraBoton12;
		private string _puertoLectorFidelizacion;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Selfservice()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Código de la configuración selfservice.
		/// </summary>
		public int IdSelfservice
		{
			get { return this._idSelfservice; }
			set { this._idSelfservice = value; }
		}

		/// <summary>
		/// Valor del selfservice para el Botón 1.
		/// </summary>
		public decimal ValorBoton1 
		{
			get { return this._valorBoton1; }
			set { this._valorBoton1 = value; }
		}

		/// <summary>
		/// Valor del selfservice para el Botón 2.
		/// </summary>
		public decimal ValorBoton2 
		{
			get { return this._valorBoton2; }
			set { this._valorBoton2 = value; }
		}

		/// <summary>
		/// Valor del selfservice para el Botón 3.
		/// </summary>
		public decimal ValorBoton3 
		{
			get { return this._valorBoton3; }
			set { this._valorBoton3 = value; }
		}
		
		/// <summary>
		/// Valor del selfservice para el Botón 4.
		/// </summary>
		public decimal ValorBoton4
		{
			get { return this._valorBoton4; }
			set { this._valorBoton4 = value; }
		}
		
		/// <summary>
		/// Valor del selfservice para el Botón 5.
		/// </summary>
		public decimal ValorBoton5 
		{
			get { return this._valorBoton5; }
			set { this._valorBoton5 = value; }
		}
		
		/// <summary>
		/// Valor del selfservice para el Botón 6.
		/// </summary>
		public decimal ValorBoton6 
		{
			get { return this._valorBoton6; }
			set { this._valorBoton6 = value; }
		}
		
		
		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton1
		{
			get { return this._caraBoton1; }
			set { this._caraBoton1 = value; }
		}

		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton2
		{
			get { return this._caraBoton2; }
			set { this._caraBoton2 = value; }
		}

		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton3
		{
			get { return this._caraBoton3; }
			set { this._caraBoton3 = value; }
		}
		
		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton4
		{
			get { return this._caraBoton4; }
			set { this._caraBoton4 = value; }
		}

		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton5
		{
			get { return this._caraBoton5; }
			set { this._caraBoton5 = value; }
		}
		
		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton6
		{
			get { return this._caraBoton6; }
			set { this._caraBoton6 = value; }
		}

		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton7
		{
			get { return this._caraBoton7; }
			set { this._caraBoton7 = value; }
		}
		
		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton8
		{
			get { return this._caraBoton8; }
			set { this._caraBoton8 = value; }
		}

		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton9
		{
			get { return this._caraBoton9; }
			set { this._caraBoton9 = value; }
		}

		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton10
		{
			get { return this._caraBoton10; }
			set { this._caraBoton10 = value; }
		}

		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton11
		{
			get { return this._caraBoton11; }
			set { this._caraBoton11 = value; }
		}
		
		/// <summary>
		/// Cara que manejará el valor del botón 1 del selfservice.
		/// </summary>
		public short CaraBoton12
		{
			get { return this._caraBoton12; }
			set { this._caraBoton12 = value; }
		}

		/// <summary>
		/// Maneja el puerto de fidelizacion
		/// </summary>
		public string PuertoLectorFidelizacion
		{
			get { return this._puertoLectorFidelizacion; }
			set { this._puertoLectorFidelizacion = value; }
		}
		
		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de la configuración del selfservice.
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarSelfservice");
			sql.ParametersNumber = 20;
			sql.AddParameter("@IdSelfservice", SqlDbType.Int, this._idSelfservice);
			sql.AddParameter("@ValorBoton1", SqlDbType.Decimal, this._valorBoton1);
			sql.AddParameter("@ValorBoton2", SqlDbType.Decimal, this._valorBoton2);
			sql.AddParameter("@ValorBoton3", SqlDbType.Decimal, this._valorBoton3);
			sql.AddParameter("@ValorBoton4", SqlDbType.Decimal, this._valorBoton4);
			sql.AddParameter("@ValorBoton5", SqlDbType.Decimal, this._valorBoton5);
			sql.AddParameter("@ValorBoton6", SqlDbType.Decimal, this._valorBoton6);
			sql.AddParameter("@CaraBoton1", SqlDbType.SmallInt, this._caraBoton1);
			sql.AddParameter("@CaraBoton2", SqlDbType.SmallInt, this._caraBoton2);
			sql.AddParameter("@CaraBoton3", SqlDbType.SmallInt, this._caraBoton3);
			sql.AddParameter("@CaraBoton4", SqlDbType.SmallInt, this._caraBoton4);
			sql.AddParameter("@CaraBoton5", SqlDbType.SmallInt, this._caraBoton5);
			sql.AddParameter("@CaraBoton6", SqlDbType.SmallInt, this._caraBoton6);
			sql.AddParameter("@CaraBoton7", SqlDbType.SmallInt, this._caraBoton7);
			sql.AddParameter("@CaraBoton8", SqlDbType.SmallInt, this._caraBoton8);
			sql.AddParameter("@CaraBoton9", SqlDbType.SmallInt, this._caraBoton9);
			sql.AddParameter("@CaraBoton10", SqlDbType.SmallInt, this._caraBoton10);
			sql.AddParameter("@CaraBoton11", SqlDbType.SmallInt, this._caraBoton11);
			sql.AddParameter("@CaraBoton12", SqlDbType.SmallInt, this._caraBoton12);
			if(_puertoLectorFidelizacion.Trim().Length>0)
				sql.AddParameter("@PuertoLectorFidelizacion", SqlDbType.Char, this._puertoLectorFidelizacion);

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
