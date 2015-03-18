using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Clase para Automotores.
	/// </summary>
	public class Automotor
	{
		#region Declarations
		private string _cod_Cli, _placa, _marca, _modelo, _tipoAuto, _monitoreo;
		private string _codigoAlterno;
		private int _cod_For_Pag, _causal, _ano, _max_Num_Tan, _no_Tanques, _tipoDescuento;
		private decimal _descuento, _cap_Total;
		private decimal _cupo_Asignado;
		private decimal _cupo_Disponible;
		private DateTime _fech_PrMa;
        private int _idTipoAutorizacionExterna;
		#endregion
        private string _codigoInterno;

        public string CodigoInterno
        {
            get { return _codigoInterno; }
            set { _codigoInterno = value; }
        }


		#region Constructor
		/// <summary>
		/// Carga los datos de automotor
		/// </summary>
		public Automotor() {}
		#endregion

		#region Public Properties
		/// <summary>
		/// Codigo del cliente al cual esta registrado el automoto
		/// </summary>
		public string CodigoCliente{
			get{ return this._cod_Cli; }
			set{ this._cod_Cli = value;}
		}

		/// <summary>
		/// Placa del automotor
		/// </summary>
		public string PlacaAutomotor {
			get { return this._placa; }
			set {this._placa = value; }
		}

		/// <summary>
		/// Marca del automotor
		/// </summary>
		public string MarcaAutomotor {
			get { return this._marca; }
			set { this._marca = value;}
		}

		/// <summary>
		/// Modelo del automotor
		/// </summary>
		public string ModeloAutomotor {
			get { return this._modelo; }
			set { this._modelo = value;}
		}

		/// <summary>
		/// Año del automotor
		/// </summary>
		public int AñoAutomotor {
			get { return this._ano; }
			set { this._ano = value;}
		}

		/// <summary>
		/// Tipo de Automotor
		/// </summary>
		public string TipoAutomotor {
			get { return this._tipoAuto; }
			set { this._tipoAuto = value;}
		}

		/// <summary>
		/// Codigo de Forma de pago del automtor
		/// </summary>
		public int CodigoFormaDePagoAutomtor{
			get { return this._cod_For_Pag; }
			set { this._cod_For_Pag = value;}
		}

		/// <summary>
		/// Codigo de la causal de bloqueo del automotor.
		/// 0: no esta bloqueado
		/// </summary>
		public int CodigoCausalDeBloqueoAutomotor {
			get { return this._causal; }
			set { this._causal = value;}
		}

		/// <summary>
		/// Fecha de proximo mantenimiento del automotor
		/// </summary>
		public DateTime FechaProximoMantenimientoAutomotor {
			get { return this._fech_PrMa; }
			set { this._fech_PrMa = value;}
		}

		/// <summary>
		/// Descuento del automotor
		/// </summary>
		public decimal DescuentoAutomtor {
			get { return this._descuento; }
			set { this._descuento = value;}
		}

		/// <summary>
		/// Capacidad Total de Combustible del automotor
		/// </summary>
		public decimal CapacidadTotalAutomtor {
			get { return this._cap_Total; }
			set { this._cap_Total = value;}
		}

		/// <summary>
		/// Numero Maximo de tanqueos diarios del Automotor.
		/// </summary>
		public int NumeroMaxTanqueosDia	{
			get { return this._max_Num_Tan; }
			set { this._max_Num_Tan = value;}
		}

		/// <summary>
		/// Numero de tanques del Automotor.
		/// </summary>
		public int NumeroTanquesAuto {
			get { return this._no_Tanques; }
			set { this._no_Tanques = value;}
		}

		/// <summary>
		/// Control de monitoreo
		/// </summary>
		public string Monitoreo {
			get { return this._monitoreo; }
			set { this._monitoreo = value;}
		}

		/// <summary>
		/// Tipo de Descuento 0=Sin descuento, 1=Valor, 2=Porcentaje
		/// </summary>
		public int TipoDescuento 
		{
			get { return this._tipoDescuento; }
			set { this._tipoDescuento = value;}
		}


		/// <summary>
		/// Codigo alternativo de cliente para aplicaciones de terceros.
		/// </summary>
		public string CodigoAlterno
		{
			get { return this._codigoAlterno; }
			set { this._codigoAlterno = value;}
		}

		/// <summary>
		/// Define el cupo asignado en valor
		/// </summary>
		public decimal Cupo_Asignado
		{
			get { return this._cupo_Asignado;}
			set { this._cupo_Asignado = value;}
		}

		/// <summary>
		/// Define el cupo disponible en valor
		/// </summary>
		public decimal Cupo_Disponible
		{
			get { return this._cupo_Disponible;}
			set { this._cupo_Disponible = value;}

		}

        /// <summary>
        /// Define el cupo disponible en valor
        /// </summary>
        public int IdTipoAutorizacioExterna
        {
            get { return this._idTipoAutorizacionExterna; }
            set { this._idTipoAutorizacionExterna = value; }

        }
		#endregion

		#region Modify
		/// <summary>
		/// Permite modificar un automotor
		/// </summary>
		public void Modificar (){

			#region Prepare SqlStatement
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("AutomotoModification");
			sql.ParametersNumber = 17;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, this._cod_Cli);
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			sql.AddParameter("@Marca", SqlDbType.VarChar, this._marca);
			sql.AddParameter("@Modelo", SqlDbType.VarChar, this._modelo);
			sql.AddParameter("@Ano", SqlDbType.Int, this._ano);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, this._tipoAuto);
			sql.AddParameter("@Cod_For_Pag", SqlDbType.Int, this._cod_For_Pag);
			sql.AddParameter("@Fech_PrMa", SqlDbType.DateTime, this._fech_PrMa);
			sql.AddParameter("@Causal", SqlDbType.Int, this._causal);
			sql.AddParameter("@Descuento", SqlDbType.Decimal, this._descuento);
			sql.AddParameter("@Monitoreo", SqlDbType.VarChar, this._monitoreo);
			sql.AddParameter("@Cap_Total", SqlDbType.Decimal, this._cap_Total);
			sql.AddParameter("@Max_Num_Tan", SqlDbType.Int, this._max_Num_Tan);
			sql.AddParameter("@No_Tanques", SqlDbType.Int, this._no_Tanques);
			sql.AddParameter("@TipoDescuento", SqlDbType.Int, this._tipoDescuento);
            sql.AddParameter("@CodigoInterno", SqlDbType.VarChar, this._codigoInterno);
            sql.AddParameter("@IdTipoAutorizacionExterna", SqlDbType.Int, this._idTipoAutorizacionExterna);

			#endregion

			#region Execute SqlStatement
			try{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}catch(SqlException exx){
				throw new Exception(exx.Message  + " !ERROR BD! ");
			}finally{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Modificar Basicos provenientes de archivos planos de sap
		/// <summary>
		/// Permite modificar un automotor
		/// </summary>
		public void ModificarBasicos()
		{

			#region Prepare SqlStatement
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ModificarBasicoAutomoto");
			sql.ParametersNumber = 11;
			//sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, this._cod_Cli);
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			sql.AddParameter("@Marca", SqlDbType.VarChar, this._marca);
			sql.AddParameter("@Modelo", SqlDbType.VarChar, this._modelo);
			sql.AddParameter("@Ano", SqlDbType.Int, this._ano);
			sql.AddParameter("@Cap_Total", SqlDbType.Decimal, this._cap_Total);
			sql.AddParameter("@Max_Num_Tan", SqlDbType.Int, this._max_Num_Tan);
			sql.AddParameter("@Cod_For_Pag", SqlDbType.Int, this._cod_For_Pag);
			sql.AddParameter("@Cupo_Asignado", SqlDbType.VarChar, this._cupo_Asignado);
			sql.AddParameter("@Cupo_Disponible", SqlDbType.VarChar, this._cupo_Disponible);
			sql.AddParameter("@CodigoAlterno", SqlDbType.VarChar, this._codigoAlterno);
			sql.AddParameter("@Causal", SqlDbType.Int, this._causal);

			#endregion

			#region Execute SqlStatement
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch(SqlException exx)
			{
				throw new Exception(exx.Message  + " !ERROR BD! ");
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
