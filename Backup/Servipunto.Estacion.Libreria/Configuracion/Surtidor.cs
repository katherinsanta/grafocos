using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Surtidor.
	/// </summary>
	public class Surtidor
	{
		#region Sección de Declaraciones
		private short _idIsla;
		private short _idSurtidor;
		private string _marca;
		private string _protocolo;
		private decimal _densidad;
		private short _factorDivision;
		private int _tiempoEstado;
		private int _tiempoDespacho;
		private int _tiempoAutorizacion, _tiempoTotalizadores;
		
		private Caras _caras;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Surtidor()
		{
		}

		/// <summary>
		/// Destructor de la clase
		/// </summary>
		~Surtidor()
		{
			this._caras = null;
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Id Isla
		/// </summary>
		public short IdIsla
		{
			get { return this._idIsla; }
			set { this._idIsla = value; }
		}

		/// <summary>
		/// Id Surtidor
		/// </summary>
		public short IdSurtidor
		{
			get { return this._idSurtidor; }
			set { this._idSurtidor = value; }
		}

		/// <summary>
		/// Marca
		/// </summary>
		public string Marca
		{
			get { return this._marca; }
			set { this._marca = value; }
		}

		/// <summary>
		/// Protocolo
		/// </summary>
		public string Protocolo
		{
			get { return this._protocolo; }
			set { this._protocolo = value; }
		}

		/// <summary>
		/// Densidad
		/// </summary>
		public decimal Densidad
		{
			get { return this._densidad; }
			set { this._densidad = value; }
		}

		/// <summary>
		/// Factor de Division
		/// </summary>
		public short FactorDivision
		{
			get { return this._factorDivision; }
			set { this._factorDivision = value; }
		}

		/// <summary>
		/// Tiempo de Espera para consultar el Estado
		/// </summary>
		public int TiempoEstado
		{
			get { return this._tiempoEstado; }
			set { this._tiempoEstado = value; }
		}

		/// <summary>
		/// Tiempo de Espera para consultar el Despacho
		/// </summary>
		public int TiempoDespacho
		{
			get { return this._tiempoDespacho; }
			set { this._tiempoDespacho = value; }
		}

		/// <summary>
		/// Tiempo espera para solicitud de autorizacion
		/// </summary>
		public int TiempoAutorizacion {
			get { return this._tiempoAutorizacion; }
			set { this._tiempoAutorizacion = value;}
		}

		/// <summary>
		/// Tiempo Espera para solicitud de totalizadores
		/// </summary>
		public int TiempoTotalizadores {
			get { return this._tiempoTotalizadores; }
			set { this._tiempoTotalizadores = value;}
		}

		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: Marca, Protocolo, Densidad, FactorDivision, TempoEstado, TiempoDespacho
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarSurtidor");
			sql.ParametersNumber = 9;
			sql.AddParameter("@IdSurtidor", SqlDbType.SmallInt, this._idSurtidor);
			sql.AddParameter("@Marca", SqlDbType.VarChar, this._marca);
			if (this._protocolo.Length > 0)
				sql.AddParameter("@Protocolo", SqlDbType.VarChar, this._protocolo);
			else
				sql.AddParameter("@Protocolo", SqlDbType.VarChar, null);
			sql.AddParameter("@Densidad", SqlDbType.Decimal, this._densidad);
			sql.AddParameter("@FactorDivision", SqlDbType.SmallInt, this._factorDivision);

			sql.AddParameter("@TiempoEstado", SqlDbType.Int, this._tiempoEstado);
			sql.AddParameter("@TiempoDespacho", SqlDbType.Int, this._tiempoDespacho);
			sql.AddParameter("@TiempoAutorizacion", SqlDbType.Int, this._tiempoAutorizacion);
			sql.AddParameter("@TiempoTotalizadores", SqlDbType.Int, this._tiempoTotalizadores);
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

		#region Caras
		/// <summary>
		/// Caras asociadas al surtidor.
		/// </summary>
		public Caras Caras
		{
			get
			{
				if (this._caras == null)
					this._caras = new Caras(this._idSurtidor, true, false);

				return this._caras;
			}
		}
		#endregion
	}
}