using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Biblioteca de colección de Clases para Administrar el Horario permitido de tanqueo para automotores.
	/// </summary>
	public class Restricciones : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _placa = null;
		private object _dia = null;
		private object _hora_Inicio = null;
		private object _hora_Fin = null;
		private object _opcion = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta todas las restriccoines.
		/// </summary>
		public Restricciones()
		{
		}

		/// <summary>
		/// Consulta de una restrinción en particular.
		/// </summary>
		public Restricciones(object placa, object dia, object hora_Inicio)//string placa, short dia, DateTime hora_Inicio)
		{
			this._placa = placa;
			this._dia = dia;
			this._hora_Inicio = hora_Inicio;
			
			
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Restriccion this[string key]
		{
			get { return (Restriccion)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Restriccion this[int index]
		{
			get { return (Restriccion)base[index]; }
		}
		#endregion

		#region Dia de la semana
		/// <summary>
		/// Devuelve un numero de 0 a 8 en el nombre de un dia
		/// <param name="numeroDia">Numero del entre 0 y 8</param>
		/// </summary>

		private string NombreDia(int numeroDia)
		{
			switch (numeroDia)
			{
				case 0: return "Domingo";
				case 1: return "Lunes";
				case 2: return "Martes";
				case 3: return "Miercoles";
				case 4: return "Jueves";
				case 5: return "Viernes";
				case 6: return "Sabado";
				case 7: return "Lunes - Viernes";
				case 8: return "Todos los días";
				default: return "Lunes - Viernes";
			}

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
			sql.Append("RecuperarRestriccion");
			sql.ParametersNumber = 5;
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			sql.AddParameter("@Dia", SqlDbType.Int, this._dia);
			sql.AddParameter("@Hora_Inicio", SqlDbType.DateTime, this._hora_Inicio);
			sql.AddParameter("@Hora_Fin", SqlDbType.DateTime, this._hora_Fin);
			sql.AddParameter("@Opcion", SqlDbType.SmallInt, this._opcion);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Restriccion objRestriccion = new Restriccion();
				objRestriccion.Placa = dr.GetString(0).Trim();
				objRestriccion.Dia = dr.IsDBNull(1)?(short)0:dr.GetInt16(1);
				objRestriccion.NombreDia = NombreDia(objRestriccion.Dia);
				//objRestriccion.HoraInicio = dr.IsDBNull(2)?new DateTime(0,0,0,1,0,0):dr.GetDateTime(2);
				//objRestriccion.HoraFin = dr.IsDBNull(3)?new DateTime(0,0,0,1,0,0):dr.GetDateTime(3);
				objRestriccion.HoraInicio = DateTime.Parse("01-01-1900 " + dr.GetValue(2).ToString());
				objRestriccion.HoraFin = DateTime.Parse("01-01-1900 " + dr.GetValue(3).ToString());
				objRestriccion.HoraInicioDisplay = dr.GetValue(2).ToString();
				objRestriccion.HoraFinDisplay = dr.GetValue(3).ToString();

				base.AddItem(objRestriccion.Placa + objRestriccion.Dia.ToString() + objRestriccion.HoraInicio.ToString(), objRestriccion);
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
		public static void Adicionar(Restriccion objRestriccion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarRestriccion");
			sql.ParametersNumber = 4;
			sql.AddParameter("@Placa", SqlDbType.VarChar, objRestriccion.Placa);
			sql.AddParameter("@Dia", SqlDbType.Int, objRestriccion.Dia);
			sql.AddParameter("@Hora_Inicio", SqlDbType.DateTime, objRestriccion.HoraInicio);
			sql.AddParameter("@Hora_Fin", SqlDbType.DateTime, objRestriccion.HoraFin);
			//sql.AddParameter("@Opcion", SqlDbType.SmallInt, this._Opcion);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Number == 2627)
					throw new Exception("La restriccion para " + objRestriccion.Placa + " ya esta configurada, rectifique por favor!" + " !ERROR BD! ");
				else
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
		/// <param name="placa">Placa del automotor</param>
		/// <param name="dia">Día de la restricción</param>
		/// <param name="hora_Inicio">Hora de inicio de la restricción</param>
		public static void Eliminar(string placa,short dia, DateTime hora_Inicio)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("EliminarRestriccion");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Placa", SqlDbType.VarChar, placa);
			sql.AddParameter("@Dia", SqlDbType.Int, dia);
			sql.AddParameter("@Hora_Inicio", SqlDbType.DateTime, hora_Inicio);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message);
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa una restricción en particular
		/// </summary>
		public static Restriccion ObtenerItem(string placa,short dia, DateTime fecha_Inicio)
		{
			Restricciones objElementos = new Restricciones(placa,dia,fecha_Inicio);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}

}
