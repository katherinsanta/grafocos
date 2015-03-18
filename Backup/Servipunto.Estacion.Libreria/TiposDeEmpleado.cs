using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria {
	/// <summary>
	/// Class TiposDeEmpleado.
	/// </summary>
	public class TiposDeEmpleado {
		
		#region Constructor
		/// <summary>
		/// Class Constructor
		/// </summary>
		public TiposDeEmpleado(){}
		#endregion

		#region Methods
		/// <summary>
		/// Tipos: Queries Tipos de Empleados from DB
		/// </summary>
		/// <returns>Arraylist with tipos de empleados</returns>
		public ArrayList Tipos(){
			
			#region Declarations
			ArrayList ar = new ArrayList();
			String Type = "";
			#endregion

			#region Prepare SQL Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			
			sql.Append("Select Tipo From Emp_Tip");			
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
			while (dr.Read()) {//leeo el data reader y lo voy metiendo en el arraylist
				Type = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();//si es null pone (SinDefinir) de lo contrario lo que viene en la columna cero
				ar.Add(Type);//agrega al arraylist
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion

			return ar;//retorno el arraylist, pues la funcion es de tipo arraylist
		}
		#endregion
	}
}
