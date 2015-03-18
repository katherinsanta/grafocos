using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion {
	/// <summary>
	/// Descripción breve de Identificador. 
	/// </summary>
	public class Identificador {

		#region Declarations
		private int _num_Ide; 
		private string _rom_Iden, _tipo, _cod_Emp, _placa, _activa;
		#endregion

		#region Constructor

		/// <summary>
		/// Modify Identifi
		/// </summary>
		public Identificador() {}

		#endregion

		#region Public Properties
		
		/// <summary>
		/// Numero de Identificador //Aqui creo como un campo dentro de la coleccion q guarda cada columan de la DB
		/// </summary>
		public int NumeroIdentificador {
			get {return this._num_Ide; }//lo consulto de la coleccion
			set {this._num_Ide = value;}//Actualizo el valor en la coleccion.
		}

		
		/// <summary>
		/// IdRom
		/// </summary>
		public string IdRom{
			get {return this._rom_Iden; }
			set {this._rom_Iden = value;}
		}

		
		/// <summary>
		/// Tipo de Identificador
		/// M. Magnetica       B. Boton
		/// </summary>
		public string TipoIdentificador{
			get {return this._tipo; } 
			set {this._tipo = value;}
		}


		/// <summary>
		/// Placa asociada al identificador
		/// </summary>
		public string Placa{
			get {return this._placa; }
			set {this._placa = value;}
		}

		
		/// <summary>
		/// Representa el Codigo del empleado asociado al identificador
		/// </summary>
		public string CodigoEmpleado{
			get {return this._cod_Emp; }
			set {this._cod_Emp = value;}
		}
		/// <summary>
		/// Estado del identificador
		/// S. Activo      N. Inactivo
		/// </summary>
		public string IdentificadorActivo {
			get {return this._activa; }
			set {this._activa = value;}
		}
		#endregion

		#region Modify
		/// <summary>
		/// Allows to modify an identificador 
		/// </summary>
		public void Modificar (){

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("IdentifiModification");//Store Procedure
			sql.ParametersNumber = 6;
			sql.AddParameter("@Num_Ide", SqlDbType.Int, this._num_Ide);
			sql.AddParameter("@Rom_Iden", SqlDbType.VarChar, this._rom_Iden);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, this._tipo);
			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, this._cod_Emp);
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			sql.AddParameter("@Activa", SqlDbType.Bit, this._activa == "Activo"?1:0);
			#endregion

			#region Execute Sql command
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

		#region Modificar basicos
		/// <summary>
		/// Allows to modify an identificador 
		/// </summary>
		public void ModificarBasicos()
		{

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ModificarBasicoIdentificador");//Store Procedure
			sql.ParametersNumber = 6;
			sql.AddParameter("@Rom_Iden", SqlDbType.VarChar, this._rom_Iden);
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			sql.AddParameter("@Activa", SqlDbType.Bit, this._activa == "A"?1:0);
			#endregion

			#region Execute Sql command
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
