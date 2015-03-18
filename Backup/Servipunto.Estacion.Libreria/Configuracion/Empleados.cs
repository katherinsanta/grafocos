using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Empleados.
	/// </summary>
	public class Empleados : Servipunto.Libreria.Collection {
		
		#region Declarations
		private object _cod_Emp = null;
		#endregion
		
		#region Constructor/Destructor
		/// <summary>
		/// Obtener todos los Empleados
		/// </summary>
		public Empleados() {
		}
		/// <summary>
		/// Obtiene un empleado en particular
		/// </summary>
		/// <param name="cod_Emp">Codigo de Empleado. </param>
		internal Empleados(string cod_Emp){
			this._cod_Emp = cod_Emp;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexar por Llave.
		/// </summary>
		new public Empleado this[string key]{
			get {return (Empleado) base[key]; }
		}
		/// <summary>
		/// Indexar por indice.
		/// </summary>
		new public Empleado this[int index]{
			get {return (Empleado) base[index];}
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e) {

			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("EmployeeQuery");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, this._cod_Emp);
			#endregion
		
			#region Execute sql Command
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read()){
				Empleado objEmpleado = new Empleado();
				objEmpleado.CodigoEmpleado = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();
				objEmpleado.NombreEmpleado = dr.IsDBNull(1)?"(Sin Definir)":dr.GetString(1).TrimEnd();
				objEmpleado.CedulaEmpleado = dr.IsDBNull(2)?"(Sin Definir)":dr.GetString(2).TrimEnd();
				objEmpleado.TipoEmpleado   = dr.IsDBNull(3)?"(Sin Definir)":dr.GetString(3).ToUpper().TrimEnd();
				objEmpleado.EstadoEmpleado = dr.IsDBNull(4)?"(Sin Definir)":dr.GetString(4).Trim();
				base.AddItem(objEmpleado.CodigoEmpleado, objEmpleado);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Inserta un Empleado en la DB.
		/// </summary>
		/// <param name="objEmpleado"></param>
		public static void Adicionar(Empleado objEmpleado){
			#region Prepare Sql
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("EmployeeInsertion");
			sql.ParametersNumber = 5;
			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, objEmpleado.CodigoEmpleado);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, objEmpleado.NombreEmpleado);
			sql.AddParameter("@Cedula", SqlDbType.VarChar, objEmpleado.CedulaEmpleado);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, objEmpleado.TipoEmpleado);
			sql.AddParameter("@Activo", SqlDbType.VarChar, objEmpleado.EstadoEmpleado);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe el empleado " + objEmpleado.CodigoEmpleado  + " !ERROR BD! ");
				else
					throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Delete
		/// <summary>
		/// Elimina un empleado de la DB
		/// </summary>
		/// <param name="cod_Emp">codigo del Empleado a Eliminar.</param>
		public static void Eliminar(string cod_Emp) {
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EmployeeDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, cod_Emp);			
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region GetItem
		/// <summary>
		/// Metodo para obtener una impresora en particular.
		/// </summary>
		/// <param name="cod_Emp">Codigo del empleado a Consultar</param>
		/// <returns>Empleado si existe. Null si no.</returns>
		public static Empleado ObtenerItem(string cod_Emp) {
			Empleados objEmpleados = new Empleados(cod_Emp);
			if (objEmpleados.Count == 1)
				return objEmpleados[0];
			else
				return null;
		}
		#endregion

        
	}
}
