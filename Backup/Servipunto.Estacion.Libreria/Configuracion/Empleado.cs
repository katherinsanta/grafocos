using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Empleado.
	/// </summary>
	public class Empleado{
		
		#region Declarations
			string _cod_Emp, _nombre, _cedula, _tipo, _activo;
		#endregion

		#region Constructor/Destructor
			/// <summary>
			/// Empleado Class Constructor
			/// </summary>
			public Empleado(){}
		#endregion

		#region Public_Properties
			/// <summary>
			/// Representa el codigo del Empleado.
			/// </summary>
			public string CodigoEmpleado{
				get{ return this._cod_Emp;  }
				set{ this._cod_Emp = value; }
			}
			/// <summary>
			/// Representa el Nombre del empleado.
			/// </summary>
			public string NombreEmpleado{
				get{ return this._nombre;  }
				set{ this._nombre = value; }
			}
			/// <summary>
			/// Representa la cedula del empleado.
			/// </summary>
			public string CedulaEmpleado{
				get{ return this._cedula;  }
				set{ this._cedula = value; }					 
			}
			/// <summary>
			/// Representa el Tipo de empleado.
			/// </summary>
			public string TipoEmpleado{
				get{ return this._tipo;  }
				set{ this._tipo = value; }
			}
			/// <summary>
			/// Representa el estado del empleado, Activo o Inactivo.
			/// </summary>
			public string EstadoEmpleado{
				get{ return this._activo;  }
				set{ this._activo = value; }
			}
		#endregion

		#region Modify
			/// <summary>
			/// Actualiza Propiedades del Empleado.
			/// </summary>
			public void Modificar (){
				#region Prepare Sql Command
					Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
					sql.Append("EmployeeModification");
					sql.ParametersNumber = 5;
					sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, this._cod_Emp);
					sql.AddParameter("@Nombre", SqlDbType.VarChar, this._nombre);
					sql.AddParameter("@Cedula", SqlDbType.VarChar, this._cedula);
					sql.AddParameter("@Tipo", SqlDbType.VarChar, this._tipo);
					sql.AddParameter("@Activo", SqlDbType.VarChar, this._activo);
					
				#endregion

				#region Execute SqlCommand
				try{
					SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				}catch(SqlException exx){
					throw new Exception(exx.Message + " !ERROR BD! ");
				}finally{
					sql = null;
				}
				#endregion
			}
		#endregion
	}
}
