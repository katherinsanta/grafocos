using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Descripción breve de ConfiguracionTiqueteVenta.
	/// </summary>
	public class ConfiguracionesTiqueteVenta : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idConfiguracion = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos las configuraciones.
		/// </summary>
		public ConfiguracionesTiqueteVenta()
		{
		}

		/// <summary>
		/// Consulta de una configuración en particular.
		/// </summary>
		internal ConfiguracionesTiqueteVenta(int IdConfiguracion)
		{
			this._idConfiguracion = IdConfiguracion;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public ConfiguracionTiqueteVenta this[string key]
		{
			get { return (ConfiguracionTiqueteVenta)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public ConfiguracionTiqueteVenta this[int index]
		{
			get { return (ConfiguracionTiqueteVenta)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ConsultarConfiguracionTiqueteVenta");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdConfiguracion", SqlDbType.Int, this._idConfiguracion);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				ConfiguracionTiqueteVenta objConfiguracionTiqueteVenta = new ConfiguracionTiqueteVenta();
				objConfiguracionTiqueteVenta.IdConfiguracion = dr.GetInt16(0) ;
				objConfiguracionTiqueteVenta.RazonSocial = dr.GetBoolean(1);
				objConfiguracionTiqueteVenta.Nit = dr.GetBoolean(2);
				objConfiguracionTiqueteVenta.NombreEstacion = dr.GetBoolean(3);
				objConfiguracionTiqueteVenta.TituloTiquete = dr.GetBoolean(4);
				objConfiguracionTiqueteVenta.Direccion = dr.GetBoolean(5);
				objConfiguracionTiqueteVenta.Telefono = dr.GetBoolean(6);
				objConfiguracionTiqueteVenta.FechaHora = dr.GetBoolean(7);
				objConfiguracionTiqueteVenta.ConsecutivoPlaca = dr.GetBoolean(8);
				objConfiguracionTiqueteVenta.TurnoIsla = dr.GetBoolean(1);
				objConfiguracionTiqueteVenta.SurtidorCara = dr.GetBoolean(10);
				objConfiguracionTiqueteVenta.Manguera = dr.GetBoolean(11);
				objConfiguracionTiqueteVenta.Kilometraje = dr.GetBoolean(12);
				objConfiguracionTiqueteVenta.Articulo = dr.GetBoolean(13);
				objConfiguracionTiqueteVenta.MedidaPrecio = dr.GetBoolean(14);
				objConfiguracionTiqueteVenta.ValorNeto = dr.GetBoolean(15);
				objConfiguracionTiqueteVenta.Descuento = dr.GetBoolean(16);
				objConfiguracionTiqueteVenta.Subtotal = dr.GetBoolean(17);
				objConfiguracionTiqueteVenta.AbonoCuota = dr.GetBoolean(18);
				objConfiguracionTiqueteVenta.Total = dr.GetBoolean(19);
				objConfiguracionTiqueteVenta.Formapago = dr.GetBoolean(20);
				objConfiguracionTiqueteVenta.NombreCliente = dr.GetBoolean(21);
				objConfiguracionTiqueteVenta.Atendio = dr.GetBoolean(22);
				objConfiguracionTiqueteVenta.FechaProxMantenimiento = dr.GetBoolean(23);
				objConfiguracionTiqueteVenta.Slogan = dr.GetBoolean(24);
				objConfiguracionTiqueteVenta.Puntosreservadosfidelizacion = dr.GetBoolean(25);
				base.AddItem(objConfiguracionTiqueteVenta.IdConfiguracion.ToString(), objConfiguracionTiqueteVenta);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Adicionar
		/// <summary>
		/// Inserción de un registro en la base de datos.
		/// </summary>
		public static void Adicionar(ConfiguracionTiqueteVenta objConfiguracionTiqueteVenta)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarConfiguracionTiqueteVenta");
			sql.ParametersNumber = 26;

			sql.AddParameter("@IdConfiguracion", SqlDbType.SmallInt, objConfiguracionTiqueteVenta.IdConfiguracion);
			sql.AddParameter("@RazonSocial", SqlDbType.Bit, objConfiguracionTiqueteVenta.RazonSocial);
			sql.AddParameter("@Nit", SqlDbType.Bit, objConfiguracionTiqueteVenta.Nit);
			sql.AddParameter("@NombreEstacion", SqlDbType.Bit, objConfiguracionTiqueteVenta.NombreEstacion);
			sql.AddParameter("@TituloTiquete", SqlDbType.Bit, objConfiguracionTiqueteVenta.TituloTiquete);
			sql.AddParameter("@Direccion", SqlDbType.Bit, objConfiguracionTiqueteVenta.Direccion);
			sql.AddParameter("@Telefono", SqlDbType.Bit, objConfiguracionTiqueteVenta.Telefono);
			sql.AddParameter("@FechaHora", SqlDbType.Bit, objConfiguracionTiqueteVenta.FechaHora);
			sql.AddParameter("@ConsecutivoPlaca", SqlDbType.Bit, objConfiguracionTiqueteVenta.ConsecutivoPlaca);
			sql.AddParameter("@TurnoIsla", SqlDbType.Bit, objConfiguracionTiqueteVenta.TurnoIsla);
			sql.AddParameter("@SurtidorCara", SqlDbType.Bit, objConfiguracionTiqueteVenta.SurtidorCara);
			sql.AddParameter("@Manguera", SqlDbType.Bit, objConfiguracionTiqueteVenta.Manguera);
			sql.AddParameter("@Kilometraje", SqlDbType.Bit, objConfiguracionTiqueteVenta.Kilometraje);
			sql.AddParameter("@Articulo", SqlDbType.Bit, objConfiguracionTiqueteVenta.Articulo);
			sql.AddParameter("@MedidaPrecio", SqlDbType.Bit, objConfiguracionTiqueteVenta.MedidaPrecio);
			sql.AddParameter("@ValorNeto", SqlDbType.Bit, objConfiguracionTiqueteVenta.ValorNeto);
			sql.AddParameter("@Descuento", SqlDbType.Bit, objConfiguracionTiqueteVenta.Descuento);
			sql.AddParameter("@Subtotal", SqlDbType.Bit, objConfiguracionTiqueteVenta.Subtotal);
			sql.AddParameter("@AbonoCuota", SqlDbType.Bit, objConfiguracionTiqueteVenta.AbonoCuota);
			sql.AddParameter("@Total", SqlDbType.Bit, objConfiguracionTiqueteVenta.Total);
			sql.AddParameter("@FormaPago", SqlDbType.Bit, objConfiguracionTiqueteVenta.Formapago);
			sql.AddParameter("@NombreCliente", SqlDbType.Bit, objConfiguracionTiqueteVenta.NombreCliente);
			sql.AddParameter("@Atendio", SqlDbType.Bit, objConfiguracionTiqueteVenta.Atendio);
			sql.AddParameter("@FechaProximaRevision", SqlDbType.Bit, objConfiguracionTiqueteVenta.FechaProxMantenimiento);
			sql.AddParameter("@Slogan", SqlDbType.Bit, objConfiguracionTiqueteVenta.Slogan);
			sql.AddParameter("@PuntosReservadosFidelizado", SqlDbType.Bit, objConfiguracionTiqueteVenta.Puntosreservadosfidelizacion);			

			

			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				objConfiguracionTiqueteVenta.IdConfiguracion = Convert.ToInt16(sql.Parameters[0].Value);
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

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		public static void Eliminar(int idConfiguracion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarConfiguracionTiqueteVenta");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdConfiguracion", SqlDbType.Int, idConfiguracion);
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

		#region Método ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa una configuración en particular
		/// </summary>
		public static ConfiguracionTiqueteVenta ObtenerItem(int idConfiguracion)
		{
			ConfiguracionesTiqueteVenta objElementos = new ConfiguracionesTiqueteVenta(idConfiguracion);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}
