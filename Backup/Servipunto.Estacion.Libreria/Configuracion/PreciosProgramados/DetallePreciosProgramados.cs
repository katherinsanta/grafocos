using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion.PreciosProgramados {
	/// <summary>
	/// Summary description for DetallePreciosProgramados.
	/// </summary>
	public class DetallePreciosProgramados : Servipunto.Libreria.Collection {

		#region Declarations
		private DateTime _date;
		private object _Cod_Art;
		
		DateTime _fecha;
		int _cod_Art, _cod_Man;
		decimal _precio;
		string _estado, _nombre_Articulo;
		#endregion

		#region Constructor

		/// <summary>
		/// Consulta el detalle del precio programado para una fecha y articulo especifico
		/// </summary>
		public DetallePreciosProgramados(DateTime date, int cod_Art) {
			this._date = date;
			this._Cod_Art = cod_Art;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public DetallePreciosProgramados(){}
		#endregion

		#region Public_Properties

		/// <summary>
		/// Fecha de aplicacion del cambio de precio
		/// </summary>
		public DateTime Fecha 
		{
			get{ return this._fecha;  }
			set{ this._fecha = value; }
		}

		/// <summary>
		/// Codigo del Articulo al cual se le cambio el precio
		/// </summary>
		public int CodigoArticulo 
		{
			get { return this._cod_Art; }
			set { this._cod_Art = value;}
		}

		/// <summary>
		/// Nombre del Articulo
		/// </summary>
		public string NombreArticulo 
		{
			get { return this._nombre_Articulo; }
			set { this._nombre_Articulo = value;}
		}

		/// <summary>
		/// Estado de la Aplicacion
		/// Aplicado.        No Aplicado.
		/// </summary>
		public string EstadoAplicacion 
		{
			get { return this._estado; }
			set { this._estado = value;}
		}

		/// <summary>
		/// Nuevo Precio configurado
		/// </summary>
		public decimal PrecioArticulo 
		{
			get { return this._precio; } 
			set { this._precio = value;}
		}

		/// <summary>
		/// Manguera  con articulo con nuevo precio
		/// </summary>
		public int MangueraArticulo 
		{
			get { return this._cod_Man; } 
			set { this._cod_Man = value;}
		}

		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e) {	
	
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("PreciosProgramadosDetQuery");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Date", SqlDbType.VarChar, this._date.ToString("yyyyMMdd"));
			sql.AddParameter("@Cod_Art", SqlDbType.Int, this._Cod_Art);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParamNumber = 0;
			while (dr.Read()) {
				DetallePreciosProgramados objDetallePreciosProgramados = new DetallePreciosProgramados();
				try	{
					objDetallePreciosProgramados.Fecha = dr.IsDBNull(0)?new DateTime(1800,1,28):dr.GetDateTime(0);ParamNumber++;
					objDetallePreciosProgramados.CodigoArticulo = dr.IsDBNull(1)?(int)0:dr.GetInt32(1);ParamNumber++;
					objDetallePreciosProgramados.NombreArticulo = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).Trim();ParamNumber++;
					objDetallePreciosProgramados.MangueraArticulo = dr.IsDBNull(3)?(int)0:(int)dr.GetInt16(3);ParamNumber++;
					objDetallePreciosProgramados.PrecioArticulo = dr.IsDBNull(4)?(decimal)0:dr.GetDecimal(4);ParamNumber++;
					objDetallePreciosProgramados.EstadoAplicacion = dr.IsDBNull(5)?"(Sin Definir)":dr.GetString(5);ParamNumber++;
				}
				catch {
					throw new Exception("(Configuracion.PreciosProgramados.DetallePreciosProgramados.Load) Error al cargar Tipo de Dato, Parametro #: " + ParamNumber.ToString() );
				}
				try {
					base.AddItem(objDetallePreciosProgramados.Fecha.ToString("yyyyMMdd") + objDetallePreciosProgramados.CodigoArticulo.ToString() + objDetallePreciosProgramados.MangueraArticulo.ToString(), objDetallePreciosProgramados);
				}
				catch {
					throw new Exception("(Configuracion.PreciosProgramados.DetallePreciosProgramados.Load) Error al agregar registro objeto objDetallePreciosProgramados !!" );
				}
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region GetItems
		/// <summary>
		/// Metodo para obtener detalle de todas las mangueras con precios aplicados.
		/// </summary>
		/// <param name="date">Fecha del precio programado a consultar detalle</param>
		/// <param name="cod_Art">Codigo articulo del precio programado a consultar detalle</param>
		/// <returns></returns>
		public static DetallePreciosProgramados ObtenerItem(DateTime date, int cod_Art) 
		{
			DetallePreciosProgramados objDetallePreciosProgramados = new DetallePreciosProgramados(date, cod_Art);
			if (objDetallePreciosProgramados.Count >= 1)
				return objDetallePreciosProgramados;
			else
				return null;
		}
		#endregion
	}
}
