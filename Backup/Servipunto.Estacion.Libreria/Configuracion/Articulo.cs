using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Artículo
	/// </summary>
	public class Articulo
	{
		#region Sección de Declaraciones
		private short _idArticulo;
		private int _cod_Art;
		private string _descripcion;
		private string _unidadMedida;
		private decimal _precio;
		private decimal _precio2;
		private decimal _precio3;
		private short _iva;
		private TipoArticulo _tipo;
		private string _color;
		private string _numCuenta;
		private bool _natCuenta;
		private string _codigoAlterno;
		//private ColorEnum _color;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public Articulo()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Código del Artículo (f)
		/// </summary>
		public short IdArticulo
		{
			get { return this._idArticulo; }
			set { this._idArticulo = value; }
		}

		/// <summary>
		/// Codigo del Arituclo
		/// </summary>
		public int CodigoArticulo {
			get { return this._cod_Art; }
			set { this._cod_Art = value; }
		}

		/// <summary>
		/// Nombre descriptivo del artículo
		/// </summary>
		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value; }
		}

		/// <summary>
		/// Unidad de Medida
		/// </summary>
		public string UnidadMedida
		{
			get { return this._unidadMedida; }
			set { this._unidadMedida = value; }
		}

		/// <summary>
		/// Precio
		/// </summary>
		public decimal Precio
		{
			get { return this._precio; }
			set { this._precio = value; }
		}

		/// <summary>
		/// Precio 2
		/// </summary>
		public decimal Precio2
		{
			get { return this._precio2; }
			set { this._precio2 = value; }
		}

		/// <summary>
		/// Precio 3
		/// </summary>
		public decimal Precio3
		{
            
			get { return this._precio3; }
			set { this._precio3 = value; }
		}

		/// <summary>
		/// Valor del Iva
		/// </summary>
		public short Iva
		{
			get { return this._iva; }
			set { this._iva = value; }
		}

		/// <summary>
		/// Tipo de Artículo
		/// </summary>
		public TipoArticulo Tipo
		{
			get { return this._tipo; }
			set { this._tipo = value; }
		}

		/// <summary>
		/// Color
		/// </summary>
		public /*ColorEnum*/string Color
		{
			get { return this._color; }
			set { this._color = value; }
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
		/// Codigo alternativo para aplicaciones de terceros.
		/// </summary>
		public string CodigoAlterno
		{
			get { return this._codigoAlterno; }
			set { this._codigoAlterno = value;}
		}
	

		#endregion

		#region Modificar
		/// <summary>
		/// Actualización de las propiedades: Descripcion, UnidadMedida, Precio, Precio2, Precio3, Iva, Tipo, Color.
		/// </summary>
		public void Modificar()
		{
			#region Prepare Sql Command
            
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ModificarArticulo");
			sql.ParametersNumber = 12;
			sql.AddParameter("@IdArticulo", SqlDbType.SmallInt, this._idArticulo);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, this._descripcion);
			sql.AddParameter("@UnidadMedida", SqlDbType.VarChar, this._unidadMedida);
			sql.AddParameter("@Precio", SqlDbType.Decimal, this._precio);
			sql.AddParameter("@Precio2", SqlDbType.Decimal, this._precio2);
			sql.AddParameter("@Precio3", SqlDbType.Decimal, this._precio3);
			sql.AddParameter("@Iva", SqlDbType.SmallInt, this._iva);
			sql.AddParameter("@Tipo", SqlDbType.TinyInt, this._tipo);
			sql.AddParameter("@Color", SqlDbType.Int, int.Parse(this._color));
			sql.AddParameter("@NUM_CUENTA", SqlDbType.VarChar, this._numCuenta);
			sql.AddParameter("@NAT_CUENTA", SqlDbType.Bit, this._natCuenta);
			sql.AddParameter("@CodigoAlterno", SqlDbType.Char, this._codigoAlterno);
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