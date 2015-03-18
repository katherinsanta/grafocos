using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Cliente.
	/// </summary>
	public class Cliente
	{
		#region Declarations
		private string _cod_Cli, _nombre, _tipo_Nit, _dir_Oficina, _tel_Oficina, _estado, _idciudad;
		private string _codigoAlterno;
		private int _cod_For_Pag, _idPrecio;
		string _nit;
		private decimal _cupo_Asignado;
		private decimal _cupo_Disponible;
		private int _igNit;
		private string _tipoCredito;
		private string _tipoTransaccion;
        private int _idTipoAutorizacionExterna;
		#endregion

		#region Constructor
		/// <summary>
		/// Cliente
		/// </summary>
		public Cliente(){}
		#endregion

		#region Public Properties
		/// <summary>
		/// Codigo Asignado al cliente para identificarlo dentro de la aplicacion
		/// </summary>
		public string CodigoCliente{
			get{ return this._cod_Cli; }
			set{ this._cod_Cli = value;}
		}

		/// <summary>
		/// Nombre del Cliente
		/// </summary>
		public string NombreCliente{
			get{ return this._nombre; }
			set{ this._nombre = value;}
		}

		/// <summary>
		/// Tipo Nit: Nit - Cédula Ciudadanía - Cédula Extanjería -  Pasaporte
		/// </summary>
		public string TipoNit{
			get{ return this._tipo_Nit; }
			set{ this._tipo_Nit = value;}
		}

		/// <summary>
		/// Direccion del Cliente
		/// </summary>
		public string DireccionCliente{
			get{ return this._dir_Oficina; }
			set{ this._dir_Oficina = value;}
		}

		/// <summary>
		/// Telefono del cliente
		/// </summary>
		public string TelefonoCliente{
			get{ return this._tel_Oficina; }
			set{ this._tel_Oficina = value;}
		}

		/// <summary>
		/// Documento identificacion del cliente
		/// </summary>
		public string NitCedulaCliente{
			get{ return this._nit.Trim(); }
			set{ this._nit = value.Trim();}
		}

		/// <summary>
		/// Codigo forma de pago configurada al cliente
		/// </summary>
		public int FormaDePagoCliente{
			get { return this._cod_For_Pag; }
			set { this._cod_For_Pag = value;}
		}

		/// <summary>
		/// Estado.  A Activo   I inactivo
		/// </summary>
		public string Estadocliente{
			get{ return this._estado; }
			set{ this._estado = value;}
		}

		/// <summary>
		/// Id Lista Precio Diferencial Asociado
		/// </summary>
		public int PrecioDiferencial{
			get { return this._idPrecio; }
			set { this._idPrecio = value;}
		}
		

		/// <summary>
		/// Id de la Ciudad a la que corresponde un cliente.
		/// </summary>
		public string IdCiudad
		{
			get { return this._idciudad; }
			set { this._idciudad = value;}
		}

		/// <summary>
		/// Codigo alternativo para aplicaciones de terceros.
		/// </summary>
		public string CodigoAlterno
		{
			get { return this._codigoAlterno; }
			set { this._codigoAlterno = value;}
		}


		/// <summary>
		/// Digito de verificación NIT
		/// </summary>
		public int IgNit
		{
			get { return this._igNit; }
			set { this._igNit = value;}
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
		/// Define el tipo de credito del cliente
		/// </summary>
		public string TipoCredito
		{
			get { return this._tipoCredito;}
			set { this._tipoCredito = value;}

		}

		/// <summary>
		/// Define el de transaccion para el cliente
		/// </summary>
		public string TipoTransaccion
		{
			get { return this._tipoTransaccion;}
			set { this._tipoTransaccion = value;}

		}
        /// <summary>
        /// Define el tipo de autizacion del cliente
        /// </summary>

        public int IdTipoAutorizacionExterna
        {
            get { return _idTipoAutorizacionExterna; }
            set { _idTipoAutorizacionExterna = value; }
        }


		#endregion

		#region Modify
		/// <summary>
		/// Actualiza Propiedades del Cliente.
		/// </summary>
		public void Modificar ()
		{

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ClientesModification");
			sql.ParametersNumber = 14;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, this._cod_Cli);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, this._nombre);
			sql.AddParameter("@Tipo_Nit", SqlDbType.VarChar, this._tipo_Nit);
			sql.AddParameter("@Nit", SqlDbType.VarChar, this._nit);
            sql.AddParameter("@Dir_Oficina", SqlDbType.VarChar, this._dir_Oficina);
			sql.AddParameter("@Tel_Oficina", SqlDbType.VarChar, this._tel_Oficina);
			sql.AddParameter("@Estado_", SqlDbType.Bit, this._estado == "Activo"?1:0);	
			sql.AddParameter("@Cod_For_Pag", SqlDbType.Int, this._cod_For_Pag);
			sql.AddParameter("@IdPrecio", SqlDbType.Int, this._idPrecio);
			sql.AddParameter("@IdCiudad", SqlDbType.VarChar, this._idciudad);
			sql.AddParameter("@CodigoAlterno", SqlDbType.Char, this._codigoAlterno);
			sql.AddParameter("@TipoCredito", SqlDbType.VarChar, this._tipoCredito);
			sql.AddParameter("@TipoTransaccion", SqlDbType.VarChar, this._tipoTransaccion);
            sql.AddParameter("@IdTipoAutorizacionExterna", SqlDbType.Int, this._idTipoAutorizacionExterna);
			#endregion

			#region Execute SqlCommand
			try{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}catch(SqlException exx){
				throw new Exception(exx.Message + " !ERROR BD! ");
			}finally{
				sql = null;
			}
			#endregion

		}
		#endregion

		#region Modificar Basicos provenientes de archivos planos de sap
		/// <summary>
		/// Modifica solo los datos basicos de clientes, los demas datos los deja igual
		/// </summary>
		public void ModificarBasicos()
		{

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ModificacionBasicaCliente");
			sql.ParametersNumber = 8;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, this._cod_Cli);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, this._nombre);
			sql.AddParameter("@Nit", SqlDbType.VarChar, this._nit);
			sql.AddParameter("@IgNit", SqlDbType.Int, this._igNit); //== NULL?0:1);
			sql.AddParameter("@Estado_", SqlDbType.Bit, this._estado == "A"?1:0);	
			sql.AddParameter("@CodigoAlterno", SqlDbType.VarChar, this._codigoAlterno);
			sql.AddParameter("@Cupo_Asignado", SqlDbType.VarChar, this._cupo_Asignado);
			sql.AddParameter("@Cupo_Disponible", SqlDbType.VarChar, this._cupo_Disponible);

			#endregion

			#region Execute SqlCommand
			try
			{
				
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);				
			}
			catch(SqlException exx)
			{
				throw new Exception(exx.Message + " !ERROR BD! ");
			}
			finally
			{
				sql = null;				
			}
			#endregion

		}
		#endregion

		#region Actualizar Ciudad Cliente
		/// <summary>
		/// Crea una relación del campo ciudad de los clientes que no estan relacionados con la tabla ciudad, ej: 'Bogota DC' lo acutaliza por '11001' .
		/// </summary>
		public void ActualizarCiudadCliente()
		{

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ActualizarCiudadCliente");
			#endregion

			#region Execute SqlCommand
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch(SqlException exx)
			{
				throw new Exception(exx.Message + " !ERROR BD! ");
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
