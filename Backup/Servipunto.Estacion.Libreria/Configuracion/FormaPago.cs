using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Clase para la administración de Formas de Pago para una venta
	/// </summary>
	public class FormaPago
	{
		#region Sección de Declaraciones
		private short _idFormaPago;
		private string _descripcion;
		private bool _transmisionOnline;
		private bool _requiereConsecutivo;
		private string _numCuenta;
		private bool _natCuenta;
		private bool _terCuenta;
		private string _num_CuentaC_Sap;
		private string _asignacionC_Sap;
		private string _textoC_Sap;
		private string _divisionC_Sap;
		private string _num_CuentaD_Sap;
		private string _asignacionD_Sap;
		private string _textoD_Sap;
		private string _divisionD_Sap;
		private bool _reportaTraslados_Sap;
		private bool _detalleCierreTurno;




		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public FormaPago()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Forma de Pago
		/// </summary>
		public short IdFormaPago
		{
			get { return this._idFormaPago; }
			set { this._idFormaPago = value; }
		}

		/// <summary>
		/// Descripción
		/// </summary>
		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value.Trim(); }
		}

		/// <summary>
		/// Indicador que determina si las transacciones de este tipo deben transmitirse en línea.
		/// </summary>
		public bool TransmisionOnline
		{
			get { return this._transmisionOnline; }
			set { this._transmisionOnline = value; }
		}

		/// <summary>
		/// Indicador que determina si las transacciones de este tipo requieren o no consecutivo de venta (ej. # Cheque).
		/// </summary>
		public bool RequiereConsecutivo
		{
			get { return this._requiereConsecutivo; }
			set { this._requiereConsecutivo = value; }
		}
		
		/// <summary>
		/// Campo con el número de cuenta según PUC
		/// </summary>
		public string NumCuenta
		{
			get { return this._numCuenta;}
			set { this._numCuenta = value;}
		}

		/// <summary>
		/// Almacenará la Naturaleza de la Cuenta a crear a su forma de pago
		/// </summary>
		public bool NatCuenta
		{
			get { return this._natCuenta;}
			set { this._natCuenta = value;}
		}
		
		/// <summary>
		/// Almacenará si la cuenta tiene definidos terceros para su consecución
		/// </summary>
		public bool TerCuenta
		{
			get { return this._terCuenta;}
			set { this._terCuenta = value;}
		}

		/// <summary>
		/// Almacena el numero de cuenta credito para SAP
		/// </summary>
		public string Num_CuentaCredito_Sap
		{
			get { return this._num_CuentaC_Sap;}
			set { this._num_CuentaC_Sap = value;}
		}

		/// <summary>
		/// Almacena la Asignacion credito para SAP
		/// </summary>
		public string AsignacionCredito_Sap
		{
			get { return this._asignacionC_Sap;}
			set { this._asignacionC_Sap = value;}
		}

		/// <summary>
		/// Almacena el texto credito para SAP
		/// </summary>
		public string TextoCredito_Sap
		{
			get { return this._textoC_Sap;}
			set { this._textoC_Sap = value;}
		}


		/// <summary>
		/// Almacena la división credito para SAP
		/// </summary>
		public string DivisionCredito_Sap
		{
			get { return this._divisionC_Sap;}
			set { this._divisionC_Sap = value;}
		}


		
		/// <summary>
		/// Almacena el numero de cuenta debito para SAP
		/// </summary>
		public string Num_CuentaDebito_Sap
		{
			get { return this._num_CuentaD_Sap;}
			set { this._num_CuentaD_Sap = value;}
		}

		/// <summary>
		/// Almacena la Asignacion debito para SAP
		/// </summary>
		public string AsignacionDebito_Sap
		{
			get { return this._asignacionD_Sap;}
			set { this._asignacionD_Sap = value;}
		}

		/// <summary>
		/// Almacena el texto debito para SAP
		/// </summary>
		public string TextoDebito_Sap
		{
			get { return this._textoD_Sap;}
			set { this._textoD_Sap = value;}
		}


		/// <summary>
		/// Almacena la división debito para SAP
		/// </summary>
		public string DivisionDebito_Sap
		{
			get { return this._divisionD_Sap;}
			set { this._divisionD_Sap = value;}
		}

		/// <summary>
		/// Define si la forma de pago se incluira en el archivo plano de traslados
		/// </summary>
		public bool ReportaTraslados_Sap
		{
			get { return this._reportaTraslados_Sap;}
			set { this._reportaTraslados_Sap = value;}
		}

		/// <summary>
		/// Define si la forma de pago se incluira en el archivo plano de traslados
		/// </summary>
		public bool DetalleCierreTurno
		{
			get { return this._detalleCierreTurno;}
			set { this._detalleCierreTurno = value;}
		}


		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: Descripcion, TransmisionOnline, RequiereConsecutivo
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarFormaPago");
			sql.ParametersNumber = 17;
			sql.AddParameter("@IdFormaPago", SqlDbType.SmallInt, this._idFormaPago);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, this._descripcion);
			sql.AddParameter("@TransmisionOnline", SqlDbType.Bit, this._transmisionOnline);
			sql.AddParameter("@RequiereConsecutivo", SqlDbType.Bit, this._requiereConsecutivo);
			sql.AddParameter("@NUM_CUENTA", SqlDbType.VarChar, this._numCuenta);
			sql.AddParameter("@NAT_CUENTA", SqlDbType.Bit, this._natCuenta);
			sql.AddParameter("@TER_CUENTA", SqlDbType.Bit, this._terCuenta);
			//datos de interfaz para sap
			sql.AddParameter("@Num_CuentaC_Sap", SqlDbType.VarChar, this._num_CuentaC_Sap);
			sql.AddParameter("@AsignacionC_Sap", SqlDbType.VarChar, this._asignacionC_Sap);
			sql.AddParameter("@TextoC_Sap", SqlDbType.VarChar, this._textoC_Sap);
			sql.AddParameter("@DivisionC_Sap", SqlDbType.VarChar, this._divisionC_Sap);
			sql.AddParameter("@Num_CuentaD_Sap", SqlDbType.VarChar, this._num_CuentaD_Sap);
			sql.AddParameter("@AsignacionD_Sap", SqlDbType.VarChar, this._asignacionD_Sap);
			sql.AddParameter("@TextoD_Sap", SqlDbType.VarChar, this._textoD_Sap);
			sql.AddParameter("@DivisionD_Sap", SqlDbType.VarChar, this._divisionD_Sap);
			sql.AddParameter("@ReportaTraslados_Sap", SqlDbType.Bit, this._reportaTraslados_Sap);
			sql.AddParameter("@DetalleCierreTurno", SqlDbType.Bit, this._detalleCierreTurno);


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