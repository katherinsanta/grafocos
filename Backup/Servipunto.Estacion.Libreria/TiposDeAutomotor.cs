using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Class TiposDeAutomotor.
	/// </summary>
	public class TiposDeAutomotor
	{
		#region Constructor

		/// <summary>
		/// Consulta los tipos de automotor 
		/// </summary>
		public TiposDeAutomotor() {}
		#endregion

		#region Methods
		/// <summary>
		/// Retorna ArrayList con todos los tipos de automotor
		/// </summary>
		/// <returns></returns>
		public ArrayList Tipos(){
			
			#region Declarations
			ArrayList ar = new ArrayList();
			String Type = "";
			#endregion

			#region Prepare SQL Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			
			sql.Append("if Not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Auto_Tipo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) Begin Select Distinct ISNull(Tipo, '') From AUTOMOTO (NoLock) End Else Begin Select TipoAutomotor From Auto_Tipo (NoLock) order by TipoAutomotor End");			
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.Text, sql.Text);
			while (dr.Read()) {//leo el data reader y lo voy metiendo en el arraylist
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
