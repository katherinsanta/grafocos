using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Turnos 
{
	/// <summary>
	/// Biblioteca de Colección Clases para administrar Jornadas Zeta en las estaciones de servicio
	/// </summary>
	public class JornadasZeta : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		int _opcion;
		Object _fechaInicial;
		Object _fechaFinal;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todas las jornadas Zetas
		/// </summary>
		/// <param name="opcion">1; todas las jornadas zeta de mayor a menor abiertas, 2; todas las jornadas zetas de mayor a menor</param>
		public JornadasZeta(int opcion)
		{
			this._opcion = opcion;
		}

		/// <summary>
		/// Consulta de todas las jornadas Zetas entre un rango de fechas
		/// </summary>
		/// <param name="opcion">1; todas las jornadas zeta de mayor a menor abiertas, 2; todas las jornadas zetas de mayor a menor</param>
		/// <param name="fechaInicial">Rango fecha inicial a consultar</param>
		/// <param name="fechaFinal">Rango fecha final a consultar</param>
		public JornadasZeta(int opcion, DateTime fechaInicial, DateTime fechaFinal)
		{
			this._opcion = opcion;
			this._fechaInicial = fechaInicial;
			this._fechaFinal = fechaFinal;
		}

		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public JornadaZeta this[string key]
		{
			get { return (JornadaZeta)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public JornadaZeta this[int index]
		{
			get { return (JornadaZeta)base[index]; }
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
			sql.Append("RecuperarJornadaZeta");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Opcion", SqlDbType.Int, this._opcion);
			if(_fechaInicial != null && _fechaFinal != null)
			{
				sql.AddParameter("@FechaInicial", SqlDbType.DateTime, this._fechaInicial);
				sql.AddParameter("@FechaFinal", SqlDbType.DateTime, this._fechaFinal);
			}
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				JornadaZeta objJornadaZeta = new JornadaZeta();
				objJornadaZeta.Fecha = dr.IsDBNull(0)?DateTime.Parse("01-01-1900"):DateTime.Parse(dr.GetValue(0).ToString());
				objJornadaZeta.Fecha_Real = dr.IsDBNull(1)?DateTime.Parse("01-01-1900"):DateTime.Parse(dr.GetValue(1).ToString());
				objJornadaZeta.Hora_Inicial = dr.IsDBNull(2)?DateTime.Parse("01-01-1900"):DateTime.Parse("01-01-1900 " + dr.GetValue(2).ToString());
				objJornadaZeta.Hora_Final = dr.IsDBNull(3)?DateTime.Parse("01-01-1900"):DateTime.Parse("01-01-1900 " + dr.GetValue(3).ToString());
				objJornadaZeta.Estado = dr.IsDBNull(4)?"C":dr.GetValue(4).ToString();
				objJornadaZeta.CodigoEmpleado = dr.IsDBNull(5)?"":dr.GetValue(5).ToString();
				base.AddItem(objJornadaZeta.Fecha.ToString(), objJornadaZeta);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Método Adicionar
		/// <summary>
		/// Adiciona una nueva jornada zeta en el sistema
		/// </summary>
		/// <param name="objJornadaZeta">Datos para adicionar</param>
		/// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
		/// Fecha:  03/09/2008
		/// Autor:  Elvis Astaiza Gutierrez
		public static void Adicionar(JornadaZeta objJornadaZeta)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarJornadaZeta");
			sql.ParametersNumber = 6;
			sql.AddParameter("@Fecha", SqlDbType.DateTime, objJornadaZeta.Fecha);
			sql.AddParameter("@FechaReal", SqlDbType.DateTime, objJornadaZeta.Fecha_Real);
			sql.AddParameter("@HoraInicial", SqlDbType.DateTime, objJornadaZeta.Hora_Inicial);
			sql.AddParameter("@HoraFinal", SqlDbType.DateTime, objJornadaZeta.Hora_Final);
			sql.AddParameter("@Estado", SqlDbType.VarChar, objJornadaZeta.Estado);
			sql.AddParameter("@CodigoEmpleado", SqlDbType.VarChar, objJornadaZeta.CodigoEmpleado);

			#endregion
			
			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
					throw new Exception("Error adicionando una jornada Zeta. " + e.Message + " !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa una jornada en particular
		/// </summary>
		public static JornadaZeta ObtenerItem(int opcion)
		{
			JornadasZeta objElementos = new JornadasZeta(opcion);
			if (objElementos.Count > 0)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region ObtenerItemsRangoFecha
		/// <summary>
		/// Consulta de todas las jornadas Zetas entre un rango de fechas
		/// </summary>
		/// <param name="opcion">1; todas las jornadas zeta de mayor a menor abiertas, 2; todas las jornadas zetas de mayor a menor</param>
		/// <param name="fechaInicial">Rango fecha inicial a consultar</param>
		/// <param name="fechaFinal">Rango fecha final a consultar</param>		
		public static JornadasZeta ObtenerItemsRangoFecha(int opcion, DateTime fechaInicial, DateTime fechaFinal)
		{
			JornadasZeta objElementos = new JornadasZeta(opcion,fechaInicial,fechaFinal);
			if (objElementos.Count > 0)
				return objElementos;
			else
				return null;
		}
		#endregion

	}
}
