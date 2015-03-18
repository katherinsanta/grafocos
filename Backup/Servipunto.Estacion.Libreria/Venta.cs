using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Clase para la administración de la tabla ventas
	/// </summary>
	/// /// <summary>
	/// Se adicionaron las propiedades y variables publicas necesarias
	/// parea la opcion nueva impresion tiquete de venta	
	/// Fecha: 11/02/2009
	/// Autor: Rodrigo Figueroa Rivera
	/// </summary>
	/// Referencia Documental: Automatizacion > Automatizacion de Islas_DT_SC_16
	public class Venta
	{
		#region Sección de Declaraciones
		private int _idVentas;
		private string _prefijo;
		private int _consecutivo;
		private decimal _total;
		private int _cod_for_Pag;
		private DateTime _fecha;
		private int _cod_Isl;
		private int _num_Turn;
		
		private DateTime _fecha_Real;
		private decimal _cantidad;
		private decimal _valorNeto;
		private decimal _descuento;
		private decimal _subTotal;
		private decimal _vr_Iva;
		private decimal _total_Cuota;
		private int _cod_Art;
		private bool _enviada;
		private bool _cancelada;
		private string _placa;
		private string _codigoEmpleado;
		private string _prefijoYConsecutivo;
		private string _caja;
		private string _transaccion;
		private string _anulada="";
		private string _grupoConsecutivo="";
		#region variables nuevas
		private int _codigoCara;
		private int _codigoSurtidor;
		private int _codigoManguera;
		private int _preset;
		private DateTime _hora;
		private decimal _porcDescuento;
		private int _impTiquete;
		private decimal _precioUnitario;
		private DateTime _fechaMant;
		private int _kil_act;
		private string _Cod_Cli;
		#endregion
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Venta()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// LLave primaria 
		/// </summary>
		public int IdVentas
		{
			get { return this._idVentas; }
			set { this._idVentas = value; }
		}

		/// <summary>
		/// Prefijo de la venta
		/// </summary>
		public string PrefijoVenta
		{
			get { return this._prefijo; }
			set { this._prefijo = value; }
		}

		/// <summary>
		/// Numero consecutivo de la venta
		/// </summary>
		public int Consecutivo
		{
			get { return this._consecutivo; }
			set { this._consecutivo = value; }
		}

		/// <summary>
		/// total de la forma del pago
		/// </summary>
		public decimal Total
		{
			get { return this._total; }
			set { this._total = value; }
		}

		/// <summary>
		/// Codigo de la forma de pago
		/// </summary>
		public int CodigoFormaPago
		{
			get { return this._cod_for_Pag; }
			set { this._cod_for_Pag = value; }
		}


		/// <summary>
		/// Fecha de turno
		/// </summary>
		public DateTime Fecha
		{
			get { return this._fecha; }
			set { this._fecha = value; }
		}
		/// <summary>
		/// Codigo de la isla
		/// </summary>
		public int CodigoIsla
		{
			get { return this._cod_Isl; }
			set { this._cod_Isl = value; }
		}

		/// <summary>
		/// Numero del turno
		/// </summary>
		public int NumeroTurno
		{
			get { return this._num_Turn; }
			set { this._num_Turn = value; }
		}

		/// <summary>
		/// Fecha real de venta
		/// </summary>
		public DateTime FechaReal
		{
			get { return this._fecha_Real; }
			set { this._fecha_Real = value; }
		}

		/// <summary>
		/// Cantidad
		/// </summary>
		public decimal Cantidad
		{
			get { return this._cantidad; }
			set { this._cantidad = value; }
		}

		/// <summary>
		/// Cantidad
		/// </summary>
		public decimal ValorNeto
		{
			get { return this._valorNeto; }
			set { this._valorNeto = value; }
		}

		/// <summary>
		/// Descuento
		/// </summary>
		public decimal Descuento
		{
			get { return this._descuento; }
			set { this._descuento = value; }
		}

		/// <summary>
		/// SubTotal
		/// </summary>
		public decimal SubTotal
		{
			get { return this._subTotal; }
			set { this._subTotal = value; }
		}
		
		/// <summary>
		/// Valor de iva
		/// </summary>
		public decimal ValorIva
		{
			get { return this._vr_Iva; }
			set { this._vr_Iva = value; }
		}
		
		/// <summary>
		/// Total de cuota
		/// </summary>
		public decimal TotalCuota
		{
			get { return this._total_Cuota; }
			set { this._total_Cuota = value; }
		}
				
		/// <summary>
		/// Codigo del articulo
		/// </summary>
		public int CodigoArticulo
		{
			get { return this._cod_Art; }
			set { this._cod_Art = value; }
		}

		/// <summary>
		/// Si fue enviada una venta
		/// </summary>
		public bool Enviada
		{
			get { return this._enviada; }
			set { this._enviada = value; }
		}

		/// <summary>
		/// Si fue cancelada o pagaga una venta enviada
		/// </summary>
		public bool Cancelada
		{
			get { return this._cancelada; }
			set { this._cancelada = value; }
		}

		/// <summary>
		/// Placa del automotor
		/// </summary>
		public string Placa
		{
			get { return this._placa; }
			set { this._placa = value; }
		}


		/// <summary>
		/// Prefijo y consecutivo de una venta para diferenciar cuando se va EnviaroPagarVenta de ventas de combustible o ventas de canastilla
		/// </summary>
		public string PrefijoYConsecutivo
		{
			get { return this._prefijoYConsecutivo; }
			set { this._prefijoYConsecutivo = value; }
		}

		
		/// <summary>
		/// Codigo del empleado de venta
		/// </summary>
		public string CodigoEmpleado
		{
			get { return this._codigoEmpleado; }
			set { this._codigoEmpleado = value; }
		}
		
		/// <summary>
		/// Numero de caja del 3ro
		/// </summary>
		public string Caja
		{
			get { return this._caja;}
			set { this._caja = value;}
		}

		
		/// <summary>
		/// Transaccion del 3ro
		/// </summary>
		public string Transaccion
		{
			get { return this._transaccion;}
			set { this._transaccion = value;}
		}
			

		/// <summary>
		/// Anula una venta de canastilla
		/// </summary>
		public string Anulada
		{
			get { return this._anulada;}
			set { this._anulada = value;}
		}
		

		/// <summary>
		/// Consecutivo para conformar un grupo de registros a los cuales pertenece el presente registro
		/// </summary>
		public string GrupoConsecutivo
		{
			get { return this._grupoConsecutivo;}
			set { this._grupoConsecutivo = value;}
		}

		#region Propiedades nuevas RFR
		/// <summary>
		/// Codigo de la Cara
		/// </summary>
		public int CodigoCara
		{
			get { return this._codigoCara;}
			set { this._codigoCara = value;}
		}

		
		/// <summary>
		/// Codigo de Surtidor
		/// </summary>
		public int CodigoSurtidor
		{
			get { return this._codigoSurtidor;}
			set { this._codigoSurtidor = value;}
		}

		/// <summary>
		/// Codigo de Manguera
		/// </summary>
		public int CodigoManguera
		{
			get { return this._codigoManguera;}
			set { this._codigoManguera = value;}
		}

		/// <summary>
		/// Codigo de Preset
		/// </summary>
		public int Preset
		{
			get { return this._preset;}
			set { this._preset = value;}
		}
		
		/// <summary>
		/// Hora de la venta
		/// </summary>
		public DateTime Hora
		{
			get { return this._hora;}
			set { this._hora = value;}
		}

		/// <summary>
		/// Porcentaje Descuento
		/// </summary>
		public decimal PorcDescuento
		{
			get { return this._porcDescuento;}
			set { this._porcDescuento = value;}
		}

		/// <summary>
		/// Impreso
		/// </summary>
		public int TiqueteImpreso
		{
			get { return this._impTiquete;}
			set { this._impTiquete = value;}
		}

		/// <summary>
		/// Precio Unitario
		/// </summary>
		public decimal PrecioUnitario
		{
			get{ return this._precioUnitario;}
			set{ this._precioUnitario = value;}
		}
		
		/// <summary>
		/// Fecha Mantenimiento
		/// </summary>
		public DateTime FechaMantenimiento
		{
			get{ return this._fechaMant;}
			set{ this._fechaMant = value;}
		}
		/// <summary>
		/// Kilometraje Actual
		/// </summary>
		public int KilometrajeActual
		{
			get{ return this._kil_act;}
			set{ this._kil_act = value;}
		}
		#endregion

		#region Codigo Cliente
		/// <summary>
		/// Kilometraje Actual
		/// </summary>
		public string CodigoCliente
		{
			get{ return this._Cod_Cli;}
			set{ this._Cod_Cli = value;}
		}
		#endregion



		#endregion

		#region Modificar
		/// <summary>
		/// Actualiza una venta 
		/// </summary>
		/// Modificaciones:
		/// Se adiciono el parametro TiqueteImpreso para que actualice este campo 
		/// Fecha: 11/02/2009
		/// Autor: Rodrigo Figueroa Rivera
		/// </summary>
		/// Referencia Documental: Automatizacion > Automatizacion de Islas_DT_SC_16
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarVenta");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Consecutivo", SqlDbType.Int, this._consecutivo);
			sql.AddParameter("@Cod_for_Pag", SqlDbType.Int, this._cod_for_Pag);
			sql.AddParameter("@TiqueteImpreso", SqlDbType.Int, this._impTiquete);

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

		#region Enviar o pagar Venta
		/// <summary>
		/// Paga o envia una venta pendiente por enviar o cancelar
		/// </summary>
		public void EnviaroPagarVenta(int opcion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			if(opcion!=3)
				sql.Append("EnviaroPagarVenta");
			else
				sql.Append("EnviarVentasPorPlanoCapturador");
			sql.ParametersNumber = 6;
			sql.AddParameter("@Opcion", SqlDbType.Int, opcion);			
			sql.AddParameter("@Consecutivo", SqlDbType.VarChar, this._prefijoYConsecutivo);
			sql.AddParameter("@CodigoEmpleado", SqlDbType.VarChar, this._codigoEmpleado);
			sql.AddParameter("@Caja", SqlDbType.VarChar, this._caja);
			sql.AddParameter("@Transaccion", SqlDbType.VarChar, this._transaccion);
			if(this._anulada != "")
				sql.AddParameter("@Anulada", SqlDbType.VarChar, this._anulada);

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

		#region anular ventas de canastilla
		/// <summary>
		/// para anular ventas de canastilla
		/// </summary>
		public void AnularVentasCanastilla()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ActualizarCanastillaAnuladas");

			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
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

		#region anular ventas sin enviar
		/// <summary>
		/// para anular ventas de canastilla
		/// </summary>
		public void AnularVentasSinEnviar()
		{
			#region Prepare Sql Command
            //Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            //sql.Append("ActualizarVentasNoEnviadas");

            //#endregion

            //#region Execute Sql
            //try
            //{
            //    SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
            //}
            //catch (SqlException e)
            //{
            //    throw new Exception(e.Message + " !ERROR BD! ");
            //}
            //finally 
            //{
            //    sql = null;
            //}
			#endregion
		}
		#endregion

	}
}
