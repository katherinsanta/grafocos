using System;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Summary description for Creditos.
	/// </summary>
	public class Creditos : Servipunto.Libreria.Collection
	{
		#region Declaraciones
		private object _placa = null;
		private object _numero = null;
		#endregion

		#region Constructores
		/// <summary>
		/// 
		/// </summary>
		public Creditos()
		{}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Param"></param>
		/// <param name="ParamData"></param>
		/// <param name="ParamData1"></param>
		public Creditos(int Param, string ParamData, string ParamData1)
		{
			if (Param == 0)
			{
				this._placa = ParamData;
				if(ParamData1!="0")
					this._numero = Convert.ToInt32(ParamData1);
				else
					this._numero = 0;
			}
		}
		#endregion

		#region Indice
		/// <summary>
		/// 
		/// </summary>
		new public Credito this[string key]
		{
			get{ return (Credito) base[key];}
		}
		/// <summary>
		/// 
		/// </summary>
		new public Credito this[int index]
		{
			get{ return (Credito) base[index];}
		}
		#endregion

		#region Evento Load
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e)
		{
			#region Preparar Estamento SQL
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CreditoQuery");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Placa", SqlDbType.VarChar, this._placa);
			sql.AddParameter("@Numero", SqlDbType.Int, this._numero);
			#endregion

			#region Ejecutar Estamento SQL
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			int ParametroNumero = 1;
			while (dr.Read())
			{
				Credito objCredito = new Credito();
				try
				{
					//objCredito.Numero = dr.IsDBNull(0)?0: dr.GetByte(0);
					objCredito.Numero = dr.IsDBNull(0)?0: (int)dr[0]; ParametroNumero++;
					objCredito.EntConsig = dr.IsDBNull(1)?"(Sin definir)":dr[1].ToString().Trim(); ParametroNumero++;
					objCredito.Financiera = dr.IsDBNull(2)?"0": dr[2].ToString().Trim(); ParametroNumero++;
					objCredito.NombreFinanciera = dr.IsDBNull(3)?"(Sin definir)":dr[3].ToString().Trim(); ParametroNumero++;
					objCredito.PlacaAutomotor = dr.IsDBNull(4)?"(Sin definir)":dr[4].ToString().Trim(); ParametroNumero++;
					objCredito.Tipo = dr.IsDBNull(5)?"(Sin definir)":dr[5].ToString().Trim(); ParametroNumero++;
					objCredito.Monto = dr.IsDBNull(6)?0: (Decimal)dr[6]; ParametroNumero++;
					objCredito.Saldo = dr.IsDBNull(7)?0: (Decimal)dr[7]; ParametroNumero++;
					objCredito.Porcentaje = dr.IsDBNull(8)?0: (Decimal)dr[8]; ParametroNumero++;
					objCredito.TipoPorcentaje = dr.IsDBNull(9)?"" : (string)dr[9]; ParametroNumero++;
				}
				catch(Exception excepcion)
				{
					//throw new Exception ("(Servipunto.Estacion.Libreria.Comercial.Load) Error al cargar el Tipo de Datos, Parametro #:"+ ParametroNumero.ToString());
					throw new Exception(excepcion.Message + " !ERROR BD! ");
				}
				try
				{
					base.AddItem(objCredito.Numero.ToString(), objCredito);
				}
				catch
				{
					throw new Exception ("(Servipunto.Estacion.Libreria.Comercial.Load) Error al agregar registro objeto objCredito placa: " + objCredito.PlacaAutomotor.Trim() + " !ERROR BD! " );
				}
			}
			dr.Close();
			dr=null;
			sql=null;
			#endregion
		}
		#endregion

		#region Adicionar Credito
		/// <summary>
		/// 
		/// </summary>
		/// <param name="objCredito"></param>
		public static void Adicionar(Credito objCredito)
		{
			#region Prepara el SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CreditoInsertion");
			sql.ParametersNumber = 7;
			sql.AddParameter("@Ent_Consig", SqlDbType.VarChar, objCredito.EntConsig);
			sql.AddParameter("@Placa", SqlDbType.VarChar, objCredito.PlacaAutomotor);
			sql.AddParameter("@Tipo", SqlDbType.VarChar, objCredito.Tipo);
			sql.AddParameter("@Financiera", SqlDbType.SmallInt, Convert.ToInt16(objCredito.Financiera));
			sql.AddParameter("@TipoPorcentaje", SqlDbType.Char, objCredito.TipoPorcentaje);
			sql.AddParameter("@Monto", SqlDbType.Decimal, objCredito.Monto);
			sql.AddParameter("@Saldo", SqlDbType.Decimal, objCredito.Saldo);
			#endregion

			#region Ejecución SQL
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message  + " !ERROR BD! ");
			}
			finally
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Borrar Crédito
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Param"></param>
		/// <param name="ParamData"></param>
		public static void Eliminar (int Param, string ParamData)
		{
			#region Escoge el parámetro de eliminación
			string Numero = null;
			if(Param==0)
				Numero = ParamData;
			#endregion
			#region Prepara el Estamento SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CreditoDeletion");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Numero", SqlDbType.VarChar, Numero);
			#endregion
			#region Ejecución SQL
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message  + " !ERROR BD! ");
			}
			finally
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Operaciones con Financieras
		
		#region ObtenerFinancieras		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public DataTable ObtenerFinancieras()
		{
			#region Preparar Estamento SQL
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("FinancierasQuery");
			#endregion
			#region Ejecutar Estamento SQL
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			
			//Creo un DataTable con los datos de las financieras
			DataTable dtFinancieras = new DataTable("Financieras");
			dtFinancieras.Columns.Add("Codigo", typeof(int));
			dtFinancieras.Columns.Add("Nombre", typeof(String));
			dtFinancieras.Columns.Add("Administrada", typeof(int));
			dtFinancieras.Columns.Add("Num_Creditos", typeof(int));
			dtFinancieras.Columns.Add("Estado", typeof(String));
			dtFinancieras.Columns.Add("Cupo", typeof(Decimal));
			dtFinancieras.Columns.Add("Utilizado", typeof(Decimal));
			dtFinancieras.Columns.Add("Fech_Ult_Actu", typeof(string));

			int ParametroNumero = 1;
			while (dr.Read())
			{
				//Credito objCredito = new Credito();
				//Creo un DataRow con el mismo esquema definido en el DataTable dtFinancieras
				DataRow drFinanciera = dtFinancieras.NewRow();
				try
				{
					//Por cada Lectura realizada en la tabla... lleno el datarow
					drFinanciera["Codigo"] = dr.IsDBNull(0)?0: (dr[0]); ParametroNumero++;
					drFinanciera["Administrada"] = dr.IsDBNull(1)?0: (dr[1]); ParametroNumero++;
					drFinanciera["Nombre"] = dr.IsDBNull(2)?"(Sin definir)": dr[2].ToString().Trim(); ParametroNumero++;
					drFinanciera["Num_Creditos"] = dr.IsDBNull(3)?0: dr[3]; ParametroNumero++;
					drFinanciera["Estado"] = dr.IsDBNull(4)?"I": dr[4].ToString().Trim(); ParametroNumero++;
					drFinanciera["Cupo"] = dr.IsDBNull(5)?0: (Decimal)dr[5]; ParametroNumero++;
					drFinanciera["Utilizado"] = dr.IsDBNull(6)?0: (Decimal)dr[6]; ParametroNumero++;
					drFinanciera["Fech_Ult_Actu"] = dr.IsDBNull(7)?DateTime.Parse("Jan 1, 1900").ToShortDateString().ToString(): ((DateTime)dr[7]).ToShortDateString().ToString(); ParametroNumero++;
					//Adiciono el DataRow con los datos al DataTable
					dtFinancieras.Rows.Add(drFinanciera);
				}
				catch(Exception excepcion)
				{
					//throw new Exception ("(Servipunto.Estacion.Libreria.Comercial.Load) Error al cargar el Tipo de Datos, Parametro #:"+ ParametroNumero.ToString());
					throw new Exception(excepcion.Message);
				}
			}
			//Cuando carga el DataTable, todas las filas aparecen con estado Adicionado, por eso hay que aceptar cambios
			dtFinancieras.AcceptChanges();
			dr.Close();
			dr=null;
			sql=null;
			return dtFinancieras;
			#endregion			
		}
		#endregion

		#region Adicionar y Modificar Financieras
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Financieras"></param>
		public void AgregarModificarFinancieras (ref DataTable Financieras)
		{
			#region Adicionar Financieras
			//Se realiza para la adicion de financieras
			DataRow [] drFinanciera = Financieras.Select("","", DataViewRowState.Added);		
			foreach(DataRow dr in drFinanciera)
			{
				//Grabo una a una cada una de las financieras adicionadas
				#region Prepara el estamento SQL
				Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
				sql.Append("FinancierasInsertion");
				sql.ParametersNumber = 6;
				sql.AddParameter("@Codigo", SqlDbType.VarChar, dr["Codigo"]);
				sql.AddParameter("@Nombre", SqlDbType.VarChar, dr["Nombre"]);
				sql.AddParameter("@Num_Creditos", SqlDbType.Int, dr["Num_Creditos"]);
				sql.AddParameter("@Estado", SqlDbType.VarChar, dr["Estado"]);
				sql.AddParameter("@Cupo", SqlDbType.Decimal, dr["Cupo"]);
				sql.AddParameter("@Utilizado", SqlDbType.Decimal, dr["Utilizado"]);
				#endregion

				#region Ejecución SQL
				try
				{
					SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				}
				catch( SqlException e)
				{
					throw new Exception(e.Message + " !ERROR BD! ");
				}
				finally
				{
					sql=null;
				}
				#endregion
			}
			#endregion

			#region Modificar Financieras
			//Se realiza para la modificación de financieras
			DataRow [] drFinancieraMod = Financieras.Select("","",DataViewRowState.ModifiedOriginal);
			foreach(DataRow dr in drFinancieraMod)
			{
				//Actualizo cada una de las financieras modificadas
				#region Prepara el estamento SQL para la modificación
				Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
				sql.Append("FinancierasModification");
				sql.ParametersNumber = 6;
				sql.AddParameter("@Codigo", SqlDbType.VarChar, dr["Codigo"]);
				sql.AddParameter("@Nombre", SqlDbType.VarChar, dr["Nombre"]);
				sql.AddParameter("@Num_Creditos", SqlDbType.Int, dr["Num_Creditos"]);
				sql.AddParameter("@Estado", SqlDbType.VarChar, dr["Estado"]);
				sql.AddParameter("@Cupo", SqlDbType.Decimal, dr["Cupo"]);
				sql.AddParameter("@Utilizado", SqlDbType.Decimal, dr["Utilizado"]);
				#endregion

				#region Ejecución SQL
				try
				{
					SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				}
				catch(SqlException exx)
				{
					throw new Exception(exx.Message + " !ERROR BD! ");
				}
				finally
				{
					sql=null ;
				}
				#endregion
			}
			#endregion
			Financieras.AcceptChanges();
		}
		#endregion

		#endregion

		#region Operaciones con Tipo_Porcentaje
		
		#region Obtener Tipo_Porcen
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public DataTable ObtenerTipoPorcen(int CodigoFinanciera)
		{
			#region Preparar Estamento SQL
			SqlDataReader dr = null;
			int intIndice=0;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("TipoPorcenQuery");
			sql.ParametersNumber = 1;
			sql.AddParameter("@Financiera", SqlDbType.SmallInt, CodigoFinanciera);
			#endregion

			#region Ejecutar Estamento SQL
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			
			//Creo un DataTable con los datos de las financieras
			DataTable dtTipoPorcen = new DataTable("Tipo_Porcen");
			dtTipoPorcen.Columns.Add("Indice", typeof(int));
			dtTipoPorcen.Columns.Add("Financiera", typeof(int));
			dtTipoPorcen.Columns.Add("Tipo", typeof(string));
			dtTipoPorcen.Columns.Add("Porcentaje", typeof(Decimal));
			dtTipoPorcen.Columns.Add("Fech_Ult_Actu", typeof(string));

			while(dr.Read())
			{
				DataRow drTipoPorcen = dtTipoPorcen.NewRow();
				try
				{
					//Indice se utiliza como contador base
					drTipoPorcen["Indice"] = intIndice++;
					drTipoPorcen["Financiera"] = dr.IsDBNull(0)?0:(dr[0]);
					drTipoPorcen["Tipo"] = dr.IsDBNull(1)?" ": dr[1].ToString();
					drTipoPorcen["Porcentaje"] = dr.IsDBNull(2)?0 : (Decimal)dr[2];
					drTipoPorcen["Fech_Ult_Actu"] = dr.IsDBNull(3)?DateTime.Parse("Jan 1, 1900").ToShortDateString().ToString(): ((DateTime)dr[3]).ToShortDateString().ToString();
					dtTipoPorcen.Rows.Add(drTipoPorcen);
				}
				catch(Exception excepcion)
				{
					//throw new Exception ("(Servipunto.Estacion.Libreria.Comercial.Load) Error al cargar el Tipo de Datos, Parametro #:"+ ParametroNumero.ToString());
					throw new Exception(excepcion.Message);
				}
			}
			//Cuando carga el DataTable, todas las filas aparecen con estado Adicionado, por eso hay que aceptar cambios
			dtTipoPorcen.AcceptChanges();
			dr.Close();
			dr=null;
			sql=null;
			return dtTipoPorcen;
			#endregion
		}
		#endregion

		#region AgregarModificar Tipo_Porcentaje
		/// <summary>
		/// 
		/// </summary>
		/// <param name="TipoPorcen"></param>
		public void AgregarModificarPorcentajes (ref DataTable TipoPorcen)
		{
			#region Adicionar Tipos de Porcentajes
			//Almaceno temporalmente los datos en un arreglo, solo los adicionados
			DataRow [] drTipoPorcen = TipoPorcen.Select("","", DataViewRowState.Added);
			foreach (DataRow dr in drTipoPorcen)
			{
				//Graba cada uno de los tipos de porcentajes adicionados
				#region Perara el estamento SQL
				Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
				sql.Append("TipoPorcenInsertion");
				sql.ParametersNumber = 3;
				sql.AddParameter("@Financiera", SqlDbType.Int, dr["Financiera"]);
				sql.AddParameter("@Tipo", SqlDbType.VarChar, dr["Tipo"]);
				sql.AddParameter("@Porcentaje", SqlDbType.Decimal, dr["Porcentaje"]);
				#endregion
				#region Ejecución SQL
				try
				{
					SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				}
				catch (SqlException e)
				{
					throw new Exception(e.Message);
				}
				finally
				{
					sql=null;
				}
				#endregion
			}
			#endregion

			#region Modificar Tipos de Porcentajes
			//Almaceno temporalmente los datos a moficar en un arreglo, solo las modificaciones
			DataRow [] drTipoPorcenMod = TipoPorcen.Select("","", DataViewRowState.ModifiedOriginal);
			foreach(DataRow dr in drTipoPorcenMod)
			{
				//Actualiza cada uno de los porcentajes modificados
				#region Prepara el Estamos SQL para la modificacion
				Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
				sql.Append("TipoPorcenModification");
				sql.ParametersNumber = 3;
				sql.AddParameter("@Financiera", SqlDbType.Int, dr["Financiera"]);
				sql.AddParameter("@Tipo", SqlDbType.VarChar, dr["Tipo"]);
				sql.AddParameter("@Porcentaje", SqlDbType.Decimal, dr["Porcentaje"]);
				#endregion
				#region Ejecución SQL
				try
				{
					SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				}
				catch(SqlException exx)
				{
					throw new Exception(exx.Message);
				}
				finally
				{
					sql = null;
				}
				#endregion
			}
			#endregion
			TipoPorcen.AcceptChanges();
		}
		#endregion

		#endregion
	}
}
