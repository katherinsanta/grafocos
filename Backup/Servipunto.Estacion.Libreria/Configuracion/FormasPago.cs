using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria.Configuracion
{
	/// <summary>
	/// Biblioteca de Coleccion de Clases para la administración de Formas de Pago para las ventas
	/// </summary>
	public class FormasPago : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idFormaPago = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todas las formas de pago configuradas.
		/// </summary>
		public FormasPago()
		{
		}

		/// <summary>
		/// Consulta de una forma de pago en particular.
		/// </summary>
		internal FormasPago(short idFormaPago)
		{
			this._idFormaPago = idFormaPago;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public FormaPago this[string key]
		{
			get { return (FormaPago)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public FormaPago this[int index]
		{
			get { return (FormaPago)base[index]; }
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

			sql.Append("ConsultarFormasPago");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdFormaPago", SqlDbType.SmallInt, this._idFormaPago);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				FormaPago objFormaPago = new FormaPago();
				objFormaPago.IdFormaPago = dr.GetInt16(0);
				objFormaPago.Descripcion = dr.IsDBNull(1)?"(sin definir)":dr.GetString(1).Trim();
				objFormaPago.TransmisionOnline = dr.GetString(2)=="S"?true:false;
				objFormaPago.RequiereConsecutivo = dr.IsDBNull(3)?false:Convert.ToBoolean(dr.GetByte(3));
				//Interface Contable
				objFormaPago.NumCuenta = dr.IsDBNull(4)?"(sin definir)":dr.GetString(4).Trim();
				objFormaPago.NatCuenta = dr.IsDBNull(5)?false:dr.GetBoolean(5);
				objFormaPago.TerCuenta = dr.IsDBNull(6)?false:dr.GetBoolean(6);
				//interface Contable SAP
				objFormaPago.Num_CuentaCredito_Sap = dr.IsDBNull(7)?"(sin definir)":dr.GetString(7).Trim();
				objFormaPago.AsignacionCredito_Sap = dr.IsDBNull(8)?"(sin definir)":dr.GetString(8).Trim();
				objFormaPago.TextoCredito_Sap = dr.IsDBNull(9)?"(sin definir)":dr.GetString(9).Trim();
				objFormaPago.DivisionCredito_Sap = dr.IsDBNull(10)?"(sin definir)":dr.GetString(10).Trim();		
				objFormaPago.Num_CuentaDebito_Sap = dr.IsDBNull(11)?"(sin definir)":dr.GetString(11).Trim();
				objFormaPago.AsignacionDebito_Sap = dr.IsDBNull(12)?"(sin definir)":dr.GetString(12).Trim();
				objFormaPago.TextoDebito_Sap = dr.IsDBNull(13)?"(sin definir)":dr.GetString(13).Trim();
				objFormaPago.DivisionDebito_Sap = dr.IsDBNull(14)?"(sin definir)":dr.GetString(14).Trim();		
				objFormaPago.ReportaTraslados_Sap = dr.IsDBNull(15)?false:dr.GetBoolean(15);
				objFormaPago.DetalleCierreTurno = dr.IsDBNull(16)?false:dr.GetBoolean(16);
				base.AddItem(objFormaPago.IdFormaPago.ToString(), objFormaPago);
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
		public static void Adicionar(FormaPago objFormaPago)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarFormaPago");
			sql.ParametersNumber = 18;
			sql.AddParameter("@DefaultFp", SqlDbType.Int, 0);
			sql.AddParameter("@IdFormaPago", SqlDbType.SmallInt, objFormaPago.IdFormaPago);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, objFormaPago.Descripcion);
			sql.AddParameter("@TransmisionOnline", SqlDbType.Bit, objFormaPago.TransmisionOnline);
			sql.AddParameter("@RequiereConsecutivo", SqlDbType.Bit, objFormaPago.RequiereConsecutivo);
			sql.AddParameter("@NUM_CUENTA", SqlDbType.VarChar, objFormaPago.NumCuenta);
			sql.AddParameter("@NAT_CUENTA", SqlDbType.Bit, objFormaPago.NatCuenta);
			sql.AddParameter("@TER_CUENTA", SqlDbType.Bit, objFormaPago.TerCuenta);
			//datos de interfaz para sap
			sql.AddParameter("@Num_CuentaC_Sap", SqlDbType.VarChar, objFormaPago.Num_CuentaCredito_Sap);
			sql.AddParameter("@AsignacionC_Sap", SqlDbType.VarChar, objFormaPago.AsignacionCredito_Sap);
			sql.AddParameter("@TextoC_Sap", SqlDbType.VarChar, objFormaPago.TextoCredito_Sap);
			sql.AddParameter("@DivisionC_Sap", SqlDbType.VarChar, objFormaPago.DivisionCredito_Sap);
			sql.AddParameter("@Num_CuentaD_Sap", SqlDbType.VarChar, objFormaPago.Num_CuentaDebito_Sap);
			sql.AddParameter("@AsignacionD_Sap", SqlDbType.VarChar, objFormaPago.AsignacionDebito_Sap);
			sql.AddParameter("@TextoD_Sap", SqlDbType.VarChar, objFormaPago.TextoDebito_Sap);
			sql.AddParameter("@DivisionD_Sap", SqlDbType.VarChar, objFormaPago.DivisionDebito_Sap);
			sql.AddParameter("@ReportaTraslados_Sap", SqlDbType.Bit, objFormaPago.ReportaTraslados_Sap);
			sql.AddParameter("@DetalleCierreTurno", SqlDbType.Bit, objFormaPago.DetalleCierreTurno);

			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.ToUpper().IndexOf("VIOLATION OF PRIMARY KEY") != -1)
					throw new Exception("Ya existe una forma de pago identificada con el código " + objFormaPago.IdFormaPago.ToString() + "!");
				else
					throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}

		/// <summary>
		/// Insercion de las 6 Formas de Pago Iniciales del Programa Estacion
		/// </summary>
		public static void AddDefault(){
			
			#region Prepare Sql command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarFormaPago");
			sql.ParametersNumber = 17;
			sql.AddParameter("@DefaultFp", SqlDbType.Int, 1);
			sql.AddParameter("@IdFormaPago", SqlDbType.SmallInt, 0);
			sql.AddParameter("@Descripcion", SqlDbType.VarChar, "0");
			sql.AddParameter("@TransmisionOnline", SqlDbType.Bit, 0);
			sql.AddParameter("@RequiereConsecutivo", SqlDbType.Bit, 0);
			sql.AddParameter("@NUM_CUENTA", SqlDbType.VarChar, "");
			sql.AddParameter("@NAT_CUENTA", SqlDbType.Bit, 0);
			sql.AddParameter("@TER_CUENTA", SqlDbType.Bit, 0);
			//datos de interfaz para sap
			sql.AddParameter("@Num_CuentaC_Sap", SqlDbType.VarChar,"0");
			sql.AddParameter("@AsignacionC_Sap", SqlDbType.VarChar,"0");
			sql.AddParameter("@TextoC_Sap", SqlDbType.VarChar,"0");
			sql.AddParameter("@DivisionC_Sap", SqlDbType.VarChar,"0");
			sql.AddParameter("@Num_CuentaD_Sap", SqlDbType.VarChar,"0");
			sql.AddParameter("@AsignacionD_Sap", SqlDbType.VarChar,"0");
			sql.AddParameter("@TextoD_Sap", SqlDbType.VarChar,"0");
			sql.AddParameter("@DivisionD_Sap", SqlDbType.VarChar,"0");
			sql.AddParameter("@DetalleCierreTurno", SqlDbType.Bit,0);
			

            #endregion

			#region Execute Sql
			try 
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.ToUpper().IndexOf("VIOLATION OF PRIMARY KEY") != -1)
					throw new Exception("Ya existe una forma de pago identificada con el código!" + " !ERROR BD! ");
				else
					throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Eliminar
		/// <summary>
		/// Eliminación de un registro de la base de datos.
		/// </summary>
		public static void Eliminar(short idFormaPago)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarFormaPago");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdFormaPago", SqlDbType.SmallInt, idFormaPago);
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

		#region ObtenerItem
		/// <summary>
		/// Método para obtener de manera directa una forma de pago en particular
		/// </summary>
		public static FormaPago ObtenerItem(short idFormaPago)
		{
			FormasPago objElementos = new FormasPago(idFormaPago);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion
	}
}