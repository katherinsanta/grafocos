using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Summary description for Bol_NumOrdenes.
	/// </summary>
	public class Bol_NumOrden
	{
		#region Declaraciones
		private string _num_Order, _prefijo;
		private int _ini_Consec, _fin_Consec, _id_Num_Orden;
		private byte _estado;		
		private string _actEconomica;		
		private string _regimen;
        private DateTime _fechaInicio;
        private DateTime _fechaFinal;
        private string _leyendaAdicional;
		#endregion

		#region Constructora, Destructora
		/// <summary>
		/// Constructora por defecto tiene que existir
		/// </summary>
		public Bol_NumOrden(){}
	
		#endregion

		#region Propiedades Publicas
		/// <summary>
		/// Representa el número de orden actual
		/// </summary>
		public string NumOrder
		{
			get {return this._num_Order;}
			set {this._num_Order = value;}
		}
		/// <summary>
		/// Representa el prefijo del consecutivo
		/// </summary>
		public string Prefijo
		{
			get {return this._prefijo;}
			set {this._prefijo = value;}
		}

		/// <summary>
		/// Representa la actividad economica
		/// </summary>

		public string ActEconomica
		{
			get {return this._actEconomica;}
			set {this._actEconomica = value;}
		}

		
		
		/// <summary>
		/// Representa el tipo de regimen (C)ontributivo, (S)implificado, (N)inguna
		/// </summary>

		public string Regimen
		{
			get {return this._regimen;}
			set {this._regimen = value;}
		}

		/// <summary>
		/// Representa el Numero inicial del consecutivo
		/// </summary>
		public int IniConsec
		{
			get {return this._ini_Consec;}
			set {this._ini_Consec = value;}
		}
		/// <summary>
		/// Representa el Numero final del consecutivo
		/// </summary>
		public int FinConsec
		{
			get {return this._fin_Consec;}
			set {this._fin_Consec = value;}
		}
		/// <summary>
		/// Representa al identity, es valioso para borrar.
		/// Como es el identity no se define set, dado que este lo genera la BD directamente
		/// </summary>
		public int IdNumOrden
		{
			get {return this._id_Num_Orden;}
			set {this._id_Num_Orden = value;}
		}
		/// <summary>
		/// Representa el estado del consecutivo definido
		/// 0 -> Activo, 1 -> Utilizado, 2-> En Espera
		/// </summary>
		public byte Estado
		{
			get {return this._estado;}
			set {this._estado = value;}
		}

        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaInicial
        {
            get { return this._fechaInicio; }
            set { this._fechaInicio = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaFinal
        {
            get { return this._fechaFinal; }
            set { this._fechaFinal = value; }
        }

        /// <summary>
        /// Leyenda Adicional Abril 28-2010
        /// </summary>
        public string LeyendaAdicional
        {
            get { return this._leyendaAdicional; }
            set { this._leyendaAdicional = value; }
        }
		#endregion

		#region Modificar Bol_NumOrden
		/// <summary>
		/// Permite Modificar Bol_NumOrden con los datos ingresados por el usuario
		/// La entrada principal del SP es @IdNumOrden, Dado que actúa como Identity, por ende es único
		/// </summary>
		public void Modificar ()
		{
			#region Prepara Estamento SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("Bol_NumOrdenModification");
			sql.ParametersNumber = 11;
			sql.AddParameter("@IdNumOrden", SqlDbType.Int, this._id_Num_Orden);
			sql.AddParameter("@NumOrder", SqlDbType.VarChar, this._num_Order);
			sql.AddParameter("@Prefijo", SqlDbType.VarChar, this._prefijo);
			sql.AddParameter("@IniConsec", SqlDbType.Int, this._ini_Consec);
			sql.AddParameter("@FinConsec", SqlDbType.Int, this._fin_Consec);
			sql.AddParameter("@ActEconomica", SqlDbType.VarChar, this._actEconomica);
			sql.AddParameter("@Regimen", SqlDbType.VarChar, (this._regimen == "Comun"?"C":"S"));			
			sql.AddParameter("@Estado", SqlDbType.TinyInt, this._estado);
            sql.AddParameter("@FechaInicio", SqlDbType.DateTime, this._fechaInicio);
            sql.AddParameter("@FechaFinal", SqlDbType.DateTime, this._fechaFinal);
            sql.AddParameter("@LeyendaAdicional", SqlDbType.VarChar, this._leyendaAdicional);	
			#endregion

			#region Ejecución del SQL
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
