using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Administración de Empleados.
	/// </summary>
	public class Empleados : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idEmpleado;
		#endregion

		#region Propiedades Públicas
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de Todos los Clientes
		/// </summary>
		public Empleados()
		{
		}

		/// <summary>
		/// Consulta de un Cliente en Particular
		/// </summary>
		internal Empleados(string idEmpleado)
		{
			this._idEmpleado = idEmpleado;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Empleado this[string key]
		{
			get { return (Empleado)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Empleado this[int index]
		{
			get { return (Empleado)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección
		/// </summary>		
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("Select Cod_Emp, Nombre From Empleado");
			if (this._idEmpleado != null)
			{
				sql.Append(" Where Cod_Emp = @IdEmpleado");
				sql.ParametersNumber = 1;
				sql.AddParameter("@IdEmpleado", SqlDbType.VarChar, this._idEmpleado);
			}
			sql.Append(" Order By NOMBRE");
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Empleado objEmpleado = new Empleado();
				objEmpleado.IdEmpleado = dr.GetString(0);
				objEmpleado.Nombre = dr.IsDBNull(1)?"(sin definir)":dr.GetString(1);

				base.AddItem(objEmpleado.IdEmpleado, objEmpleado);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa un empleado en particular
		/// </summary>
		public static Empleado Obtener(string idEmpleado)
		{
			Empleados objElementos = new Empleados(idEmpleado);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}