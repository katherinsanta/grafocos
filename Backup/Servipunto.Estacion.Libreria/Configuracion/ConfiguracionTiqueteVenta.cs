using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Descripción breve de ConfiguracionTiqueteVenta.
	/// </summary>
	public class ConfiguracionTiqueteVenta
	{
		#region Local Variables
		private short _idConfiguracion;
		private bool _razonSocial;		
		private bool _nit;
		private bool _nombreEstacion;
		private bool _tituloTiquete;
		private bool _direccion;
		private bool _telefono;
		private bool _fechaHora;				        
		private bool _consecutivoPlaca;
		private bool _turnoIsla;
		private bool _surtidorCara;
		private bool _manguera;
		private bool _kilometraje;
		private bool _articulo;
		private bool _medidaPrecio;
		private bool _valorNeto;
		private bool _descuento;
		private bool _subtotal;
		private bool _abonoCuota;
		private bool _total;
		private bool _formapago;
		private bool _nombreCliente;
		private bool _atendio;
		private bool _fechaProxMantenimiento;
		private bool _slogan;
		private bool _puntosreservadosfidelizacion;
		#endregion

		public ConfiguracionTiqueteVenta()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		#region propiedades

		public short IdConfiguracion
		{
			get
			{
				return _idConfiguracion;
			}

			set
			{
				_idConfiguracion = value;
			}
		}        

		public bool RazonSocial
		{
			get
			{
				return _razonSocial;
			}

			set
			{
				_razonSocial = value;

			}

		}
        
		public bool Nit
		{
			get
			{
				return _nit;
			}

			set
			{
				_nit = value;

			}

		}
        
		public bool NombreEstacion
		{
			get
			{
				return _nombreEstacion;
			}

			set
			{
				_nombreEstacion = value;

			}
		}
        
		public bool TituloTiquete
		{
			get
			{
				return _tituloTiquete;
			}

			set
			{
				_tituloTiquete = value;

			}
		}
        
		public bool Direccion
		{
			get
			{
				return _direccion;
			}

			set
			{
				_direccion = value;

			}
		}
        
		public bool Telefono
		{
			get
			{
				return _telefono;
			}

			set
			{
				_telefono = value;

			}
		}

		public bool FechaHora        
		{
			get
			{
				return _fechaHora;
			}

			set
			{
				_fechaHora = value;

			}
        
		}

		public bool ConsecutivoPlaca
		{
			get
			{
				return _consecutivoPlaca;
			}

			set
			{
				_consecutivoPlaca = value;

			}
		}
        
		public bool TurnoIsla
		{
			get
			{
				return _turnoIsla;
			}

			set
			{
				_turnoIsla = value;

			}
		}
		public bool SurtidorCara
		{
			get
			{
				return _surtidorCara;
			}

			set
			{
				_surtidorCara = value;

			}
		}

		public bool Manguera
		{
			get
			{
				return _manguera;
			}

			set
			{
				_manguera = value;

			}
            
		}

		public bool Kilometraje
		{
			get
			{
				return _kilometraje;
			}

			set
			{
				_kilometraje = value;

			}

		}

		public bool Articulo
		{
			get
			{
				return _articulo;
			}

			set
			{
				_articulo = value;

			}
		}

		public bool MedidaPrecio
		{
			get
			{
				return _medidaPrecio;
			}

			set
			{
				_medidaPrecio = value;

			}
		}

		public bool ValorNeto
		{
			get
			{
				return _valorNeto;
			}

			set
			{
				_valorNeto = value;

			}
		}

		public bool Descuento
		{
			get
			{
				return _descuento;
			}

			set
			{
				_descuento = value;

			}

		}

		public bool Subtotal
		{
			get
			{
				return _subtotal;
			}

			set
			{
				_subtotal = value;

			}
		}

		public bool AbonoCuota
		{
			get
			{
				return _abonoCuota;
			}

			set
			{
				_abonoCuota = value;

			}
		}
		public bool Total
		{
			get
			{
				return _total;
			}

			set
			{
				_total = value;

			}
		}
		public bool Formapago
		{
			get
			{
				return _formapago;
			}

			set
			{
				_formapago = value;

			}
		}

		public bool NombreCliente
		{
			get
			{
				return _nombreCliente;
			}

			set
			{
				_nombreCliente = value;

			}
		}

		public bool Atendio
		{
			get
			{
				return _atendio;
			}

			set
			{
				_atendio = value;

			}

		}
		public bool FechaProxMantenimiento
		{
			get
			{
				return _fechaProxMantenimiento;
			}

			set
			{
				_fechaProxMantenimiento = value;

			}
		}

		public bool Slogan
		{
			get
			{
				return _slogan;
			}

			set
			{
				_slogan = value;

			}
		}

		public bool Puntosreservadosfidelizacion
		{
			get
			{
				return _puntosreservadosfidelizacion;
			}

			set
			{
				_puntosreservadosfidelizacion = value;

			}
		}
		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de la configuración tiquete de venta.
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarConfiguracionTiqueteVenta");
			sql.ParametersNumber = 26;	
	
			sql.AddParameter("@IdConfiguracion", SqlDbType.Int, this._idConfiguracion);
			sql.AddParameter("@RazonSocial", SqlDbType.Bit, this._razonSocial);
			sql.AddParameter("@Nit", SqlDbType.Bit, this._nit);
			sql.AddParameter("@NombreEstacion", SqlDbType.Bit, this._nombreEstacion);
			sql.AddParameter("@TituloTiquete", SqlDbType.Bit, this._tituloTiquete);
			sql.AddParameter("@Direccion", SqlDbType.Bit, this._direccion);
			sql.AddParameter("@Telefono", SqlDbType.Bit, this._telefono);
			sql.AddParameter("@FechaHora", SqlDbType.Bit, this._fechaHora);
			sql.AddParameter("@ConsecutivoPlaca", SqlDbType.Bit, this._consecutivoPlaca);
			sql.AddParameter("@TurnoIsla", SqlDbType.Bit, this._turnoIsla);
			sql.AddParameter("@SurtidorCara", SqlDbType.Bit, this._surtidorCara);
			sql.AddParameter("@Manguera", SqlDbType.Bit, this._manguera);
			sql.AddParameter("@Kilometraje", SqlDbType.Bit, this._kilometraje);
			sql.AddParameter("@Articulo", SqlDbType.Bit, this._articulo);
			sql.AddParameter("@MedidaPrecio", SqlDbType.Bit, this._medidaPrecio);
			sql.AddParameter("@ValorNeto", SqlDbType.Bit, this._valorNeto);
			sql.AddParameter("@Descuento", SqlDbType.Bit, this._descuento);
			sql.AddParameter("@Subtotal", SqlDbType.Bit, this._subtotal);
			sql.AddParameter("@AbonoCuota", SqlDbType.Bit, this._abonoCuota);
			sql.AddParameter("@Total", SqlDbType.Bit, this._total);
			sql.AddParameter("@FormaPago", SqlDbType.Bit, this._formapago);
			sql.AddParameter("@NombreCliente", SqlDbType.Bit, this._nombreCliente);
			sql.AddParameter("@Atendio", SqlDbType.Bit, this._atendio);
			sql.AddParameter("@FechaProximaRevision", SqlDbType.Bit, this._fechaProxMantenimiento);
			sql.AddParameter("@Slogan", SqlDbType.Bit, this._slogan);
			sql.AddParameter("@PuntosReservadosFidelizado", SqlDbType.Bit, this._puntosreservadosfidelizacion);			
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
