using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Summary description for Alarma.
	/// </summary>
	public class Alarma
	{
		#region Declaraciones
		private int _idConfVentaGratis, _frecuencia, _acumulado, _horInicial, _horFinal, /*_codForPag,*/ _codForPagConf, _tiempoAlarma, _porcentaje;
		private string _puerto, _tipoAutomotor, _nomCodForPag, _nomCodForPagConf, _codForPag;
		private bool _estado;
		private DateTime _fecInicial, _fecFinal;
		private Decimal _valorMaximo;
		private Byte _tipoAlarma;
		private string _rutaArchivoAudio;
		private int _codigoArticulo;
		private decimal _valorMinimo;

		#endregion

		#region Constructora Destructora
		/// <summary>
		/// Constructora sin parámetros
		/// </summary>
		public Alarma()
		{ }
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Identity de la tabla ConfVentaGratis
		/// No utilizar SET, dado que es identity y la BD nunca lo tomará
		/// </summary>
		public int IdConfVentaGratis
		{
			get {return this._idConfVentaGratis;}
			set {this._idConfVentaGratis = value;}
		}
		/// <summary>
		/// Indica la cantidad de ventas que se deben realizar para activar la alarma
		/// </summary>
		public int Frecuencia
		{
			get {return this._frecuencia;}
			set {this._frecuencia = value;}
		}
		/// <summary>
		/// Indica el acumulado de ventas que se han realizado hasta el momento cuando es igual que la frecuencia, se activa la alarma
		/// </summary>
		public int Acumulado
		{
			get {return this._acumulado;}
			set {this._acumulado = value;}
		}
		/// <summary>
		/// Establece el puerto en el cual está conectada la alarma al PC físicamente
		/// </summary>
		public string Puerto
		{
			get {return this._puerto;}
			set {this._puerto = value;}
		}
		/// <summary>
		/// Establece la Fecha Inicial de activación de la alarma
		/// </summary>
		public DateTime FecInicial
		{
			get {return this._fecInicial;}
			set {this._fecInicial = value;}
		}
		/// <summary>
		/// Establece la Fecha Final de activación de la alarma
		/// </summary>
		public DateTime FecFinal
		{
			get {return this._fecFinal;}
			set {this._fecFinal = value;}
		}
		/// <summary>
		/// Establece la Hora inicial de activicación de la alarma
		/// </summary>
		public int HorInicial
		{
			get {return this._horInicial;}
			set {this._horInicial = value;}
		}
		/// <summary>
		/// Establece la Hora final de activación de la alarma
		/// </summary>
		public int HorFinal
		{
			get {return this._horFinal;}
			set {this._horFinal = value;}
		}
		/// <summary>
		/// Identifica el Tipo de Automotor (Nombre) que tendrá el privilegio de realizar sorteo de venta gratis
		/// </summary>
		public string TipoAutomotor
		{
			get {return this._tipoAutomotor;}
			set {this._tipoAutomotor = value;}
		}
		/// <summary>
		/// Establece el Estado en el que se encuentra la Configuración de venta gratis.
		/// 0 -> Inactivo, 1-> Activo
		/// </summary>
		public bool Estado
		{
			get {return this._estado;}
			set {this._estado = value;}
		}
		/// <summary>
		/// Indica la Forma de pago (Id) que tendrá privilegios de sorte para venta gratis
		/// </summary>
		/*public int CodForPag
		{
			get {return this._codForPag;}
			set {this._codForPag = value;}
		}*/
		public string CodForPag
		{
			get {return this._codForPag;}
			set {this._codForPag = value;}
		}
		/// <summary>
		/// Representa el nombre de la forma de pago
		/// </summary>
		public string NomCodForPag
		{
			get {return this._nomCodForPag;}
			set {this._nomCodForPag = value;}
		}
		/// <summary>
		/// Indica la forma de pago (id) con la cual se guardara en la tabla ventas cuando se realice el sorte respectivo
		/// </summary>
		public int CodForPagConf
		{
			get {return this._codForPagConf;}
			set {this._codForPagConf = value;}
		}
		/// <summary>
		/// Representa el nombre de la forma de pago de configuracion
		/// </summary>
		public string NomCodForPagConf
		{
			get {return this._nomCodForPagConf;}
			set {this._nomCodForPagConf = value;}
		}
		/// <summary>
		/// Representa el tiempo que durará la alarma emitiendo sonido
		/// </summary>
		public int TiempoAlarma
		{
			get {return this._tiempoAlarma;}
			set {this._tiempoAlarma = value;}
		}
		/// <summary>
		/// Representa el porcentaje de la venta que se catalogará como gratis
		/// </summary>
		public int Porcentaje
		{
			get {return this._porcentaje;}
			set {this._porcentaje = value;}
		}
		/// <summary>
		/// Representa el Valor Maximo de la venta * porcentaje que se va a poder identificar como venta gratis
		/// </summary>
		public Decimal ValorMaximo
		{
			get {return this._valorMaximo;}
			set {this._valorMaximo = value;}
		}

		/// <summary>
		/// Configura el tipo de alarma; 1: Por Alarma electronica, 2: Por archivo de audio
		/// </summary>
		public Byte TipoAlarma
		{
			get{ return this._tipoAlarma;  }
			set{ this._tipoAlarma = value; }
		}

		/// <summary>
		/// Ruta comleta del archivo de audio
		/// </summary>
		public string RutaArchivoAudio
		{
			get{ return this._rutaArchivoAudio;  }
			set{ this._rutaArchivoAudio = value; }
		}

		/// <summary>
		/// Codigo del articulo
		/// Modificacion: se agrego para que se pudiera filtrar por articulo
		/// Fceha: 10/03/2009
		/// Autor: Rodrigo Figueroa
		/// </summary>
		public int CodigoArticulo
		{
			get{ return this._codigoArticulo;  }
			set{ this._codigoArticulo = value; }
		}

		/// <summary>
		/// Valor Minimo
		/// Modificacion: se agrego para que se pudiera filtrar valores entre un minimo y un maximo
		/// Fceha: 10/03/2009
		/// Autor: Rodrigo Figueroa
		/// </summary>
		public Decimal ValorMinimo
		{
			get{ return this._valorMinimo;  }
			set{ this._valorMinimo = value; }
		}


		#endregion

		#region Método Modificar
		/// <summary>
		/// Método que permite modificar ConfVentasGratis con los datos ingresados por el usuario
		/// La entrada es IdConfVentaGratis, actua como identity, por lo tanto es unico
		/// </summary>
		public void Modificar()
		{
			#region Prepara Estamento SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("AlarmasModification");
			sql.ParametersNumber = 19;
			sql.AddParameter("@IdConfVentaGratis", SqlDbType.Int, this._idConfVentaGratis);
			sql.AddParameter("@Frecuencia", SqlDbType.Int, this._frecuencia);
			sql.AddParameter("@Acumulado", SqlDbType.Int, this._acumulado);
			sql.AddParameter("@Puerto", SqlDbType.VarChar, this._puerto);
			sql.AddParameter("@FecInicial", SqlDbType.DateTime, this._fecInicial);
			sql.AddParameter("@FecFinal", SqlDbType.DateTime, this._fecFinal);
			sql.AddParameter("@HorInicial", SqlDbType.Int, this._horInicial);
			sql.AddParameter("@HorFinal", SqlDbType.Int, this._horFinal);
			sql.AddParameter("@TipoAutomotor", SqlDbType.VarChar, this._tipoAutomotor);
			sql.AddParameter("@Estado", SqlDbType.Bit, this._estado);
			//sql.AddParameter("@Cod_For_Pag", SqlDbType.SmallInt , this._codForPag);
			sql.AddParameter("@Cod_For_Pag", SqlDbType.VarChar , this._codForPag);
			sql.AddParameter("@Cod_For_Pag_Conf", SqlDbType.SmallInt, this._codForPagConf);
			sql.AddParameter("@Tiempo_Alarma", SqlDbType.SmallInt, this._tiempoAlarma);
			sql.AddParameter("@Porcentaje", SqlDbType.Int, this._porcentaje);
			sql.AddParameter("@ValorMaximo", SqlDbType.Decimal, this._valorMaximo);
			sql.AddParameter("@TipoAlarma", SqlDbType.TinyInt, this._tipoAlarma);
			sql.AddParameter("@rutaArchivoAudio", SqlDbType.VarChar, this._rutaArchivoAudio);
			sql.AddParameter("@CodigoArticulo", SqlDbType.VarChar, this._codigoArticulo);
			sql.AddParameter("@ValorMinimo", SqlDbType.VarChar, this._valorMinimo);


			#endregion

			#region Ejecución Estamento SQL
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception (e.Message + " !ERROR BD! ");
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
